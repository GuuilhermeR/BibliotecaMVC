using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaController
{
    public interface IDAO <T, F> where T : class
    {
        string Conexao { get; set; }

        string GetSQL(T obj, F filtro);

        string Salvar(T obj);

        string Excluir(T obj);

        T CriarObjeto(SqlDataReader reader);
    }
}