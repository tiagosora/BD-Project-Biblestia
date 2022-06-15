using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class Material
    {
        private String _id, _nomeBiblioteca, _seccaoExposicao, _estado;
        public String Id { get => _id; set => _id = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String SeccaoExposicao { get => _seccaoExposicao; set => _seccaoExposicao = value; }
        public String Estado { get => _estado; set => _estado = value; }
        
        public override string ToString()
        {
            return _id + "\t" + _nomeBiblioteca;
        }
    }
}

