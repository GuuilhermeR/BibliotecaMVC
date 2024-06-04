using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static BibliotecaView.Views.Pessoa.Pessoa;

namespace BibliotecaController.Controllers.Pessoa
{
    public class PessoaController : DAO<BibliotecaView.Views.Pessoa.Pessoa>
    {
        public PessoaController(string conexao) : base(conexao)
        {
        }

        protected override string GetSQL()
        {
            string sql = "SELECT nome\n";
            sql += ", sobrenome\n";
            sql += ", cpf\n";
            sql += ", endereco\n";
            sql += ", dataCadastro\n";
            sql += ", numero\n";
            sql += ", cidade\n";
            sql += ", estado\n";
            sql += ", bairro\n";
            sql += ", telefone\n";
            sql += ", dataNascimento\n";
            sql += "FROM Pessoa";

            return sql;
        }

        protected override string Salvar(BibliotecaView.Views.Pessoa.Pessoa pessoa)
        {
            string erro = string.Empty;

            using (SqlConnection sqlConnection = new SqlConnection(Conexao))
            {
                sqlConnection.Open();
                try
                {
                    string insert = $"INSERT INTO Usuario (nome, sobrenome, cpf) VALUES ('{pessoa.Nome}', '{pessoa.Sobrenome}', '{pessoa.Cpf}')";
                    SqlCommand cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = insert;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
            return erro;
        }

        protected override string Excluir(BibliotecaView.Views.Pessoa.Pessoa pessoa)
        {
            string erro = string.Empty;

            using (SqlConnection sqlConnection = new SqlConnection(Conexao))
            {
                sqlConnection.Open();
                try
                {
                    string delete = $"DELETE FROM Pessoa WHERE cpf = '{pessoa.Cpf}'";
                    SqlCommand cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = delete;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
            return erro;
        }

        protected override BibliotecaView.Views.Pessoa.Pessoa CriarObjeto(SqlDataReader reader)
        {
            BibliotecaView.Views.Pessoa.Pessoa pessoa = new BibliotecaView.Views.Pessoa.Pessoa();
            while (reader.Read())
            {

            }
            return pessoa;
        }
    }
}
