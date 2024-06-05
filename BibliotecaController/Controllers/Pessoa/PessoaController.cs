using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDAO.Controllers.Pessoa
{
    public class PessoaController : DAO<BibliotecaView.Views.Pessoa.PessoaModel, BibliotecaFilter.Filters.Pessoa.PessoaFilter>
    {
        public PessoaController(string conexao) : base(conexao)
        {
        }
    }
}
