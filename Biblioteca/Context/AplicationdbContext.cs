using Biblioteca.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Context
{
    public class AplicationdbContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server = localhost; database= biblioteca; user= root; password= ");

        }

        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Roles> Roles { get; set; }


    }
}
