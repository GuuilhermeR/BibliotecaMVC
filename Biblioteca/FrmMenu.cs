using BibliotecaDAO.Controllers.Pessoa;
using BibliotecaFilter.Filters.Pessoa;
using BibliotecaView.Views.Pessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BibliotecaDAO.Controllers.Pessoa.PessoaController;

namespace Biblioteca
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnCadPessoa_Click(object sender, EventArgs e)
        {
            PessoaController pessoaController = new PessoaController("");
            Pessoa model = new Pessoa();
            PessoaFilter filter = new PessoaFilter
            {
                Cpf = "233"
            };
            pessoaController.Salvar(model);
        }
    }
}
