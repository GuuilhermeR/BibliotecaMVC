using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaController
{
    public abstract class DAO<T,F> :IDAO<T,F> where T : class
    {
        public string Conexao { get; set; }

        public DAO(string conexao)
        {
            Conexao = conexao;
        }

        string IDAO<T, F>.GetSQL(T obj, F filtro)
        {
            throw new NotImplementedException();
        }

        public string Salvar(T obj)
        {
            throw new NotImplementedException();
        }

        public string Excluir(T obj)
        {
            throw new NotImplementedException();
        }

        T IDAO<T, F>.CriarObjeto(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
