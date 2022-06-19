using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class Requisicao

    {
        private String _id, _nomeBiblioteca, _idLeitor, _nomeCompletoLeitor, _idFuncResponsavel, _nomeCompletoFuncResponsavel, _dataInicio, _dataEntrega, _dataLimite;
        private ArrayList _materials = new ArrayList();
        public String Id { get => _id; set => _id = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String IdLeitor { get => _idLeitor; set => _idLeitor = value; }
        public String NomeCompletoLeitor { get => _nomeCompletoLeitor; set => _nomeCompletoLeitor = value; }
        public String IdFuncResponsavel { get => _idFuncResponsavel; set => _idFuncResponsavel = value; }
        public String NomeCompletoFuncResponsavel { get => _nomeCompletoFuncResponsavel; set => _nomeCompletoFuncResponsavel = value; }
        public String DataInicio { get => _dataInicio; set => _dataInicio = value; }
        public String DataEntrega { get => _dataEntrega; set => _dataEntrega = value; }
        public String DataLimite { get => _dataLimite; set => _dataLimite = value; }
        public ArrayList Materials { get => _materials;}

        public void addMaterial(String idMaterial)
        {
            _materials.Add(idMaterial);
        }

        public override string ToString()
        {
            DateTime inicio = DateTime.Parse(_dataInicio);
            return _id + "\t" + inicio.ToString("yyyy-MM-dd") + "   " + _nomeCompletoLeitor;
        }
    }
}

