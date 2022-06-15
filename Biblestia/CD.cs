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
    class CD
    {
        private String _idMaterial, _nomeBiblioteca, _nome, _categoria, _ano, _marcaProdutora;
        public String IdMaterial { get => _idMaterial; set => _idMaterial = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String Nome { get => _nome; set => _nome = value; }
        public String Categoria { get => _categoria; set => _categoria = value; }
        public String Ano { get => _ano; set => _ano = value; }
        public String MarcaProdutora { get => _marcaProdutora; set => _marcaProdutora = value; }


        public override string ToString()
        {
            return _idMaterial + "\t" + _nomeBiblioteca + "\t" + _nome;
        }
    }
}

