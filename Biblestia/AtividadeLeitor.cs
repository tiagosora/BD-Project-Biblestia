using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblestia
{
    class AtividadeLeitor
    {

        private String _nifLeitor, _nomeAtividade, _nomeBiblioteca;
        public String NifLeitor { get => _nifLeitor; set => _nifLeitor = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String NomeAtividade { get => _nomeAtividade; set => _nomeAtivadade = value; }
       

        public override string ToString()
        {
            return _nifLeitor + "\t" + _nomeAtividade + "\t" + _nome;
        }
    }
}
