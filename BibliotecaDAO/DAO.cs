﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            _properties = typeof(T).GetType().GetProperties();
        }

        public string GetSQL(T obj, F filtro)
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
                sql += $"FROM {this.TableName}";

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

        private string GetWhereClause(F filtro)
        {
            string whereClause = string.Empty;

            foreach (var property in this._properties)
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

        public string Salvar(T obj)
        {
            string mensagem = string.Empty;
            string sqlcmd = string.Empty;

            if (!this.Existe)
                sqlcmd = ComandoInsert(obj);
            else
                sqlcmd = ComandoUpdate(obj);

            using (SqlConnection conn = new SqlConnection(Conexao))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlcmd;
                cmd.ExecuteNonQuery();
            }

            return mensagem;
        }

        private string ComandoInsert(T obj)
        {
            string sqlcmd = $"INSERT INTO {this.TableName} (";
            for (int i = 0; i <= _properties.Length; i++)
            {
                if (i == _properties.Length)
                {
                    sqlcmd += $"{_properties[i].Name})";
                    continue;
                }
                sqlcmd += $"{_properties[i].Name},";
            }

            sqlcmd += " \nVALUES (";

            for (int i = 0; i <= _properties.Length; i++)
            {
                switch (_properties[i].PropertyType.Name)
                {
                    case "String":
                        sqlcmd += $"'{_properties[i].GetValue(obj)}'";
                        break;
                    default:
                        sqlcmd += $"{_properties[i].GetValue(obj)}";
                        break;
                }

                if (i < _properties.Length)
                {
                    sqlcmd += ", ";
                }
                else
                {
                    sqlcmd += ")";
                }
            }

            return sqlcmd;
        }

        private string ComandoUpdate(T obj)
        {
            string condictions = "";//GetWhereClause(filtro);
            string sqlcmd = $"UPDATE {this.TableName} SET";

            for (int i = 0; i <= _properties.Length; i++)
            {
                sqlcmd += $"{_properties[i].Name}=";

                switch (_properties[i].PropertyType.Name)
                {
                    case "String":
                        sqlcmd += $"'{_properties[i].GetValue(obj)}'";
                        break;
                    default:
                        sqlcmd += $"{_properties[i].GetValue(obj)}";
                        break;
                }

                if (i < _properties.Length)
                {
                    sqlcmd += ", ";
                }
                else
                {
                    sqlcmd += ")";
                }
            }

            if (!string.IsNullOrEmpty(condictions))
            {
                sqlcmd += $"WHERE {condictions}";
            }

            return sqlcmd;
        }

        public string Excluir(T obj)
        {
            throw new NotImplementedException();
        }

        public T CriarObjeto(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}