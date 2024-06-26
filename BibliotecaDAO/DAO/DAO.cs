﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDAO
{
    public abstract class DAO<T, F> : IDAO<T, F> where T : class
    {
        private string _conexao { get; set; }
        private string _tableName { get; set; }
        private System.Reflection.PropertyInfo[] _properties { get; set; }
        private System.Reflection.PropertyInfo[] _propertiesFilter { get; set; }

        public string Conexao
        {
            get
            {
                return _conexao;
            }
        }

        public string TableName
        {
            get
            {
                return _tableName;
            }
        }

        private bool Existe { get; set; }

        public DAO(string conexao)
        {
            _conexao = conexao;
            _tableName = typeof(T).Name;
            _properties = typeof(T).GetProperties();
            _propertiesFilter = typeof(F).GetProperties();
        }

        public virtual string GetSQL(T obj, F filtro)
        {
            string sql = string.Empty;

            foreach (var campos in this._properties)
            {
                if (string.IsNullOrEmpty(sql))
                {
                    sql += $"SELECT {campos.Name}\n";
                    continue;
                }
                sql += $", {campos.Name}\n";
            }

            if (sql.StartsWith("SELECT"))
            {
                sql += $"FROM {this.TableName}\n";

                if (filtro != null)
                {
                    string condictions = GetWhereClause(filtro);
                    if (!string.IsNullOrEmpty(condictions))
                    {
                        sql += $"WHERE {condictions}";
                    }
                }
            }

            return sql;
        }

        public virtual string Salvar(T obj)
        {
            string mensagem = string.Empty;
            string sqlcmd = string.Empty;

            if (!this.Existe)
            {
                var insertCommand = new Comandos.InsertCommand<T>();
                sqlcmd = insertCommand.ComandoInsert(obj, _properties, this.TableName);
            }
            else
            {
                var updateCommand = new Comandos.UpdateCommand<T>();
                sqlcmd = updateCommand.ComandoUpdate(obj, _properties, this.TableName);
            }

            ExecutarComando(sqlcmd);

            return mensagem;
        }

        public virtual string Excluir(T obj, F filtro)
        {
            string condictions = GetWhereClause(filtro);
            string sqlcmd = $"DELETE FROM {this.TableName}";

            if (!string.IsNullOrEmpty(condictions))
            {
                sqlcmd += $"WHERE {condictions}";
            }

            ExecutarComando(sqlcmd);

            return sqlcmd;
        }

        public virtual List<T> LoadObjeto(string sql)
        {
            List<T> result = Activator.CreateInstance<List<T>>();

            using (SqlCommand s = new SqlCommand(sql, new SqlConnection(Conexao)))
            {
                using (SqlDataReader dr = s.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        T obj = Activator.CreateInstance<T>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            PropertyInfo prop = obj.GetType().GetProperty(dr.GetName(i));
                            if (prop != null && !DBNull.Value.Equals(dr.GetValue(i))) 
                            {
                                prop.SetValue(obj, dr.GetValue(i), null);
                            }
                        }
                        result.Add(obj);
                    }
                }
            }

            return result;
        }

        private string GetWhereClause(F filtro)
        {
            string whereClause = string.Empty;

            foreach (var property in this._propertiesFilter)
            {
                var value = property.GetValue(filtro);
                if (value != null)
                {
                    if (whereClause.Length > 0)
                    {
                        whereClause += " AND ";
                    }
                    whereClause += $"{property.Name} = '{value}'\n";
                }
            }

            return whereClause.ToString();
        }

        private string ExecutarComando(string sqlcmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Conexao))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sqlcmd;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return $"Ocorreu um erro ao executar o COMMAND \n{ex.Message}";
            }
            return "COMMAND com sucesso!";
        }
    }
}
