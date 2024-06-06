using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDAO.Comandos
{
    public class InsertCommand<T> where T : class
    {
        public string ComandoInsert(T obj, System.Reflection.PropertyInfo[] _properties, string tableName)
        {
            string sqlcmd = $"INSERT INTO {tableName} (";
            for (int i = 0; i < _properties.Length; i++)
            {
                sqlcmd += $"{_properties[i].Name}";

                if (i < _properties.Length - 1)
                    sqlcmd += ", ";
                else
                    sqlcmd += ")";
            }

            sqlcmd += " \nVALUES (";

            for (int i = 0; i < _properties.Length; i++)
            {
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
                    sqlcmd += ", ";
                else
                    sqlcmd += ")";

            }

            return sqlcmd;
        }
    }
}
