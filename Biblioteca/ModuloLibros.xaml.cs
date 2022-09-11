using Biblioteca.Context;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace Biblioteca
{
   
    /// <summary>
    /// Lógica de interacción para ModuloLibros.xaml
    /// </summary>
    public partial class ModuloLibros : Window
    {
        public ModuloLibros()
        {
            
            InitializeComponent();
            MostrarLibros();
            
        }

        public void MostrarLibros()
        {
            using (var _context = new AplicationdbContext())
            {
                LibrosTable.ItemsSource = _context.Libros.ToList();
               
            }

        }

        private void SalirLibros_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();

        }

        private void InsertarLibro_Click(object sender, RoutedEventArgs e)
        {
            GuardarLibro enviar = new GuardarLibro();
            enviar.opcion = "Insertar";
            enviar.Show();
            this.Close();
        }

        private void LibrosTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SeleccionarLibros(object sender, RoutedEventArgs e)
        {
                    
            Libros libro = new Libros();
            libro = (sender as FrameworkElement).DataContext as Libros;
            GuardarLibro enviar = new GuardarLibro();
            enviar.Show();
            enviar.opcion = "Editar";
            enviar.txtIdLibros.Text = libro.Id.ToString();
            enviar.txtNombre.Text = libro.Nombre.ToString();
            enviar.txtAutor.Text = libro.Autor.ToString();
            enviar.txtEditorial.Text = libro.Editorial.ToString();
            enviar.txtIsbn.Text = libro.Isbm.ToString();
            enviar.txtFec_pub.Text = libro.Fec_publi.ToString();
            enviar.txtStock.Text = libro.Stock.ToString();
            enviar.txtEstado.Text = libro.Estado.ToString();
            enviar.txtIdioma.Text = libro.Idioma.ToString();
            enviar.txtCategoria.Text = libro.Categoria.ToString();
            this.Close();
        }

        private void BorrarLibro(object sender, RoutedEventArgs e)
        {
            Libros libro = new Libros();
            libro = (sender as FrameworkElement).DataContext as Libros;

            using (var _context = new AplicationdbContext())
            {
                if (libro.Stock == 1)
                {

                    _context.Libros.Remove(libro);
                    
                   
                }
                else
                {
                    libro.Stock = libro.Stock - 1;
                    _context.Entry(libro).State = EntityState.Modified;
                    
                }
                _context.SaveChanges();
            }
            MostrarLibros();

        }

      


    }
}
