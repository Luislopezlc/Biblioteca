using Biblioteca.Context;
using Biblioteca.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Lógica de interacción para GuardarLibro.xaml
    /// </summary>
    public partial class GuardarLibro : Window
    {
        public string opcion = "";

        Validaciones validar = new Validaciones();
       bool nombre, categoria, editorial, fec, stock, idioma, autor, isbn;
        public GuardarLibro()
        {   
            InitializeComponent();
            validar.NombreLib(txtNombre, valiNombre);
            validar.Nombre(txtCategoria, valiCategoria);
            validar.Nombre(txtEditorial, valiEditorial);
            validar.Fecha(txtFec_pub, valiFec_pub);
            validar.NumerosCortos(txtStock, valiStock);
            validar.Nombre(txtIdioma, valiIdioma);
            validar.Nombre(txtAutor, valiAutor);
            validar.Isbn(txtIsbn, valiIsbn);
            DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            ModuloLibros moduloLibros = new ModuloLibros();
            moduloLibros.Show();
            Limpiar_Boxs();
            this.Close();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (opcion == "Insertar")
                {
                    Libros libro = new Libros()
                    {
                        Nombre = txtNombre.Text,
                        Autor = txtAutor.Text,
                        Editorial = txtEditorial.Text,
                        Isbm = txtIsbn.Text,
                        Fec_publi = txtFec_pub.Text,
                        Stock = int.Parse(txtStock.Text),
                        Estado = "Disponible",
                        Idioma = txtIdioma.Text,
                        Categoria = txtCategoria.Text,

                    };

                    using (var _context = new AplicationdbContext())
                    {
                        _context.Libros.Add(libro);
                        _context.SaveChanges();
                    }
                   
                }
                else if (opcion == "Editar")
                {
                    
                    Libros libroedit = new Libros();
                    libroedit.Id = int.Parse(txtIdLibros.Text);

                    using (var _context = new AplicationdbContext())
                    {
                        libroedit = _context.Libros.Find(libroedit.Id);
                        libroedit.Nombre = txtNombre.Text;
                        libroedit.Autor = txtAutor.Text;
                        libroedit.Editorial = txtEditorial.Text;
                        libroedit.Isbm = txtIsbn.Text;
                        libroedit.Estado = txtEstado.Text;
                        libroedit.Idioma = txtIdioma.Text;
                        libroedit.Categoria = txtCategoria.Text;                     
                        libroedit.Stock = int.Parse(txtStock.Text);                     
                        _context.Entry(libroedit).State = EntityState.Modified;
                        _context.SaveChanges();

                    }                           
                }
                opcion = "";
                ModuloLibros moduloLibros = new ModuloLibros();
                moduloLibros.Show();
                this.Close();
                Limpiar_Boxs();
            }
            catch (Exception)
            {


            }
        }

        public void Limpiar_Boxs()
        {
            txtIdLibros.Clear();
            txtNombre.Clear();
            txtAutor.Clear();
            txtEditorial.Clear();
            txtIsbn.Clear();
            txtFec_pub.Clear();
            txtStock.Clear();
            txtEstado.Clear();
            txtIdioma.Clear();
            txtCategoria.Clear();
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {                    
           nombre =  validar.NombreLib(txtNombre, valiNombre); 
           DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void txtCategoria_TextChanged(object sender, TextChangedEventArgs e)
        {
          
           categoria = validar.Nombre(txtCategoria, valiCategoria);
           DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void txtEditorial_TextChanged(object sender, TextChangedEventArgs e)
        {
           editorial = validar.Nombre(txtEditorial,valiEditorial);
           DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void txtFec_pub_TextChanged(object sender, TextChangedEventArgs e)
        {
           fec = validar.Fecha(txtFec_pub, valiFec_pub);
           DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void txtStock_TextChanged(object sender, TextChangedEventArgs e)
        {
            stock = validar.NumerosCortos(txtStock,valiStock);
            DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void txtIdioma_TextChanged(object sender, TextChangedEventArgs e)
        {
           idioma = validar.Nombre(txtIdioma,valiIdioma);
           DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void txtAutor_TextChanged(object sender, TextChangedEventArgs e)
        {
           autor = validar.Nombre(txtAutor, valiAutor);
           DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);

        }

        private void txtIsbn_TextChanged(object sender, TextChangedEventArgs e)
        {
           isbn = validar.Isbn(txtIsbn,valiIsbn);
           DatosCorrectos(nombre, categoria, editorial, fec, stock, idioma, autor, isbn);
        }

      
        private void DatosCorrectos (bool nombre, bool categoria, bool editorial, bool fec, bool stock, bool idioma, bool autor, bool isbn)
        {
            if (nombre == true && categoria == true && editorial == true && fec == true && stock==true && idioma == true && autor == true && isbn == true)
            {
                BtGuardar.IsEnabled = true;
            }
            else
            {
                BtGuardar.IsEnabled = false;
            }
        }


    }
}
