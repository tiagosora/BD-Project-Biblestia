using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class Requisicao

    {
        private String _id, _nomeBiblioteca, _idLeitor, _idFuncResponsavel, _dataInicio, _dataEntrega, _dataLimite;
        public String Id { get => _id; set => _id = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String IdLeitor { get => _idLeitor; set => _idLeitor = value; }
        public String IdFuncResponsavel { get => _idFuncResponsavel; set => _idFuncResponsavel = value; }
        public String DataInicio { get => _dataInicio; set => _dataInicio = value; }
        public String DataEntrega { get => _dataEntrega; set => _dataEntrega = value; }
        public String DataLimite { get => _dataLimite; set => _dataLimite = value; }
       
        public override string ToString()
        {
            return _id + "\t" + _idLeitor + "\t" + DataInicio;
        }
    }
}

