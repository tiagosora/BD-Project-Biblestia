using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblestia
{
    class Atividade
    {
        private String _nomeAtividade, _nomeBiblioteca, _dataAtividade, _tematica, _duracaoMin, _idFuncResponsavel;
        public String NomeAtividade { get => _nomeAtividade; set => _nomeAtividade = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String DataAtividade { get => _dataAtividade; set => _dataAtividade = value; }
        public String Tematica { get => _tematica; set => _tematica = value; }
        public String DuracaoMin { get => _duracaoMin; set => _duracaoMin = value; }
        public String IdFuncResponsavel { get => _idFuncResponsavel; set => _idFuncResponsavel = value; }

        public override string ToString()
        {
            return _dataAtividade + "\t" + _nomeAtividade;
        }
    }
}
