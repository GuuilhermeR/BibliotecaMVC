using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDAO.Comandos
{
    public class UpdateCommand<T> where T : class
    {
        public string ComandoUpdate(T obj, System.Reflection.PropertyInfo[] _properties, string tableName)
        {
            string condictions = "";//GetWhereClause(filtro);
            string sqlcmd = $"UPDATE {tableName} SET ";

            for (int i = 0; i < _properties.Length; i++)
            {
                sqlcmd += $"{_properties[i].Name}=";

                switch (_properties[i].PropertyType.Name)
                {
                    case "String":
                        sqlcmd += $"'{Convert.ToString(_properties[i].GetValue(obj))}'";
                        break;
                    case "DateTime":
                        sqlcmd += $"'{Convert.ToDateTime(_properties[i].GetValue(obj)):yyyy-MM-dd}'";
                        break;
                    default:
                        sqlcmd += $"{_properties[i].GetValue(obj)}";
                        break;
                }

                if (i < _properties.Length - 1)
                {
                    sqlcmd += ", ";
                }
            }

            if (!string.IsNullOrEmpty(condictions))
            {
                sqlcmd += $"WHERE {condictions}";
            }

            return sqlcmd;
        }

    }
}
