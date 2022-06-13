using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class Cargo
    {
        private String _nomeBiblioteca, _idFuncionario, _nomeCargo, _dataInicio, _dataFim;

        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String IdFuncionario { get => _idFuncionario; set => _idFuncionario = value; }
        public String NomeCargo { get => _nomeCargo; set => _nomeCargo = value; }
        public String DataInicio { get => _dataInicio; set => _dataInicio = value; }
        public String DataFim { get => _dataFim; set => _dataFim = value; }

        public override string ToString()
        {
            return _nomeCargo;
        }
    }
}
