using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteca.Modelo
{
    public class Prestamos
    {
        public int Id { get; set; }

        public int Cobro_retardo { get; set; }

        public string Fec_pres { get; set; }

        public string Fec_devo { get; set; }

        [ForeignKey("Clientes")]
        public int FKClientes { get; set; }
        public Clientes Clientes { get; set; }

        [ForeignKey("Empleados")]
        public int FKEmpleados { get; set; }
        public Empleados Empleados { get; set; }

        [ForeignKey("Libros")]
        public int FKLibros { get; set; }
        public Libros Libros { get; set; }
    }
}
