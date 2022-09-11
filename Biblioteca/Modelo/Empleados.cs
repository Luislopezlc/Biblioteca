using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteca.Modelo
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }      
        public string Fec_reg { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; } 
        public string Fec_nac { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        [ForeignKey("Roles")]
        public int FKRol { get; set; }
        public Roles Roles { get; set; }

    }
}
