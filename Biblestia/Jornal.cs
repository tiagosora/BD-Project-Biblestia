using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Biblestia
{
    class Jornal
    {
        private String _idMaterial, _nomeBiblioteca, _nome, _dataPublicacao, _nomeEditora;
        public String IdMaterial { get => _idMaterial; set => _idMaterial = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String Nome { get => _nome; set => _nome = value; }
        public String DataPublicacao { get => _dataPublicacao; set => _dataPublicacao = value; }
        public String NomeEditora { get => _nomeEditora; set => _nomeEditora = value; }
        

        public override string ToString()
        {
            return _idMaterial + "\t" + _nomeBiblioteca + "\t" + _nome;
        }
    }
}