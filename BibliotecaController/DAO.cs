using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaController
{
    public abstract class DAO<T> where T: class
    {
        public string Conexao { get; set; }

        public DAO(string conexao)
        {
            Conexao = conexao;
        }

        protected abstract string GetSQL();

        protected abstract string Salvar();

        protected abstract string Excluir();

        protected abstract T CriarObjeto(SqlDataReader reader);

    }
}
