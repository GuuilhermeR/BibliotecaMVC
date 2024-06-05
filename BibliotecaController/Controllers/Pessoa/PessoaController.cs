using BibliotecaFilter.Filters.Pessoa;
using BibliotecaView.Views.Pessoa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaController.Controllers.Pessoa
{
    public class PessoaController : DAO<BibliotecaView.Views.Pessoa.Pessoa, PessoaFilter>
    {
        public PessoaController(string conexao) : base(conexao)
        {
        }

    }
}
