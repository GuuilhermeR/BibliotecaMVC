using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaView.Views.Usuario;

namespace BibliotecaController.Controllers.Usuario
{
    public class UsuarioController : DAO<BibliotecaView.Views.Usuario.Usuario>
    {
        public UsuarioController(string conexao) : base(conexao)
        {
        }

        protected override string GetSQL()
        {
            string sql = String.Empty;

            sql = "SELECT nome, sobrenome, cpf";
            sql += "FROM Usuario ";

            return sql;

        }

        protected override string Salvar()
        {
            throw new NotImplementedException();
        }

        protected override string Excluir()
        {
            throw new NotImplementedException();
        }

        protected override BibliotecaView.Views.Usuario.Usuario CriarObjeto(SqlDataReader reader)
        {
            BibliotecaView.Views.Usuario.Usuario usuario = new BibliotecaView.Views.Usuario.Usuario();
            while (reader.Read())
            {

            }
            return usuario;
        }
    }
}
