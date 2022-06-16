using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblestia
{
    class Livro 
    {
        private String _idMaterial, _nomeBiblioteca, _titulo, _autor, _genero, _ano, _nomeEditora;
        public String IdMaterial { get => _idMaterial; set => _idMaterial = value; }
        public String NomeBiblioteca { get => _nomeBiblioteca; set => _nomeBiblioteca = value; }
        public String Titulo { get => _titulo; set => _titulo = value; }
        public String Autor { get => _autor; set => _autor = value; }
        public String Genero { get => _genero; set => _genero = value; }
        public String Ano { get => _ano; set => _ano = value; }
        public String NomeEditora { get => _nomeEditora; set => _nomeEditora = value; }
        

        public override string ToString()
        {
            return _idMaterial + "\t" + _nomeBiblioteca + "\t" + _titulo;
        }
    }
}

