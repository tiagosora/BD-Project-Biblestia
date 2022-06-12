using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class Funcionario
    {
        private String _nomeCompleto, _nomeBiblioteca, _email, _morada, _nif, _idFuncionario, _ssn, _telefone, _dataNascimento;
        public String NomeCompleto { get => _nomeCompleto; set => _nomeCompleto = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String Email { get => _email; set => _email = value; }
        public String Morada { get => _morada; set => _morada = value; }
        public String Nif { get => _nif; set => _nif = value; }
        public String IdFuncionario { get => _idFuncionario; set => _idFuncionario = value; }
        public String Ssn { get => _ssn; set => _ssn = value; }
        public String Telefone { get => _telefone; set => _telefone = value; }
        public String DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }

        public override string ToString()
        {
            return _idFuncionario + "\t" + _nomeCompleto;
        }
    }
}
