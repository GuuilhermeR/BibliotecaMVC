using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaView.Views.Pessoa
{
    public class PessoaModel
    {
        private readonly string _nome;
        private readonly string _sobrenome;
        private readonly string _cpf;
        private readonly string _endereco;
        private readonly DateTime _dataCadastro;
        private readonly int _numero;
        private readonly string _cidade;
        private readonly string _estado;
        private readonly string _bairro;
        private readonly string _telefone;
        private readonly DateTime _dataNascimento;

        public string Nome {
            get
            {
                return _nome;
            }
        }
        public string Sobrenome {
            get
            {
                return _sobrenome;
            }
        }
        public string Cpf {
            get
            {
                return _cpf;
            }
        }
        public string Endereco {
            get
            {
                return _endereco;
            }
        }
        public int Numero {
            get
            {
                return _numero;
            }
        }
        public string Cidade {
            get
            {
                return _cidade;
            }
        }
        public string Estado {
            get
            {
                return _estado;
            }
        }
        public string Bairro {
            get
            {
                return _bairro;
            }
        }
        public string Telefone {
            get
            {
                return _telefone;
            }
        }
        public DateTime DataNascimento {
            get
            {
                return _dataNascimento;
            }
        }
        public DateTime DataCadastro { 
            get 
            { 
                return _dataCadastro; 
            } 
        }

        public PessoaModel() { }

        public PessoaModel(string nome, string sobrenome, string cpf, string endereco, DateTime dataCadastro, int numero, string cidade, string estado, string bairro, string telefone, DateTime dataNascimento)
        {
            _nome = nome;
            _sobrenome = sobrenome;
            _cpf = cpf;
            _endereco = endereco;
            _dataCadastro = dataCadastro;
            _numero = numero;
            _cidade = cidade;
            _estado = estado;
            _bairro = bairro;
            _telefone = telefone;
            _dataNascimento = dataNascimento;
        }
    }
}
