using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Modelo
{
    public class Libros
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public string Editorial { get; set; }

        public string Fec_publi { get; set; }
       
        public int Stock { get; set; }

        public string Estado { get; set; }

        public string Idioma { get; set; }

        public string Isbm { get; set; }

        public string Autor { get; set; }

    }
}
