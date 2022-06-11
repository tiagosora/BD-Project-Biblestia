using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class Biblioteca
    {
        private String _nome, _morada, _email, _telefone;

        public String Nome { get => _nome; set => _nome = value; }
        public String Morada { get => _morada; set => _morada = value; }
        public String Email { get => _email; set => _email = value; }
        public String Telefone { get => _telefone; set => _telefone = value; }

        public override string ToString()
        {
            return _nome;
        }
    }
}
