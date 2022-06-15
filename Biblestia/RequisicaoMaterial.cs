using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class RequisicaoMaterial
    {

        private String _idRequisicao, _idMaterial, _nomeBiblioteca;
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String IdRequisicao { get => _idRequisicao; set => _idRequisicao = value; }
        public String IdMaterial { get => _idMaterial; set => _idMaterial = value; }

        public override string ToString()
        {
            return _idRequisicao + "\t" + _idMaterial;
        }
    }
}
