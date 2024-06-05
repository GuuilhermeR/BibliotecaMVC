using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaController
{
    public abstract class DAO<T, F> : IDAO<T, F> where T : class
    {
        private string _conexao { get; set; }
        private string _tableName { get; set; }

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

        public DAO(string conexao)
        {
            _conexao = conexao;
            _tableName = typeof(T).Name;
        }

        public string GetSQL(T obj, F filtro)
        {
            var prop = typeof(T).GetType().GetProperties();
            string sql = $"SELECT {prop[0].Name}";

            foreach (var campos in prop)
            {
                if (sql.Length == 0)
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
            var filtroProperties = filtro.GetType().GetProperties();

            foreach (var property in filtroProperties)
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
            throw new NotImplementedException();
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
