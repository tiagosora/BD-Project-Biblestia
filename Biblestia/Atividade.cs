using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblestia
{
    class Atividade
    {
        private String _nomeAtividade, _nomeBiblioteca, _dataAtividade, _tematica, _duracao, _nifFuncResponsavel;
        public String NomeAtividade { get => _nomeAtividade; set => _nomeAtividade = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String DataAtividade { get => _dataAtividade; set => _dataAtividade = value; }
        public String Tematica { get => _tematica; set => _tematica = value; }
        public String Duracao { get => _duracao; set => _duracao = value; }
        public String NifFuncResponsavel { get => _nifFuncResponsavel; set => _nifFuncResponsavel = value; }

        public override string ToString()
        {
            return _nomeAtividade;
        }
    }
}
