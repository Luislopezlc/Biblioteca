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
    /// Lógica de interacción para ModuloPrestamos.xaml
    /// </summary>
    public partial class ModuloPrestamos : Window
    {
        public ModuloPrestamos()
        {
            InitializeComponent();
            MostrarPrestamos();
        }

        public void MostrarPrestamos()
        {
           using (var _context = new AplicationdbContext())
           {
                PrestamosTable.ItemsSource = _context.Prestamos.Include(x => x.Libros).ToList();
                PrestamosTable.ItemsSource = _context.Prestamos.Include(x => x.Empleados).ToList();
                PrestamosTable.ItemsSource = _context.Prestamos.Include(x => x.Clientes).ToList();

            }
        }

        private void InsertarPrestamo_Click(object sender, RoutedEventArgs e)
        {
            GuardarPrestamo enviar = new GuardarPrestamo();
            enviar.opcion = "Insertar";
            enviar.Show();
            this.Close();
        }
        private void SeleccionarPrestamos(object sender, RoutedEventArgs e)
        {
            Prestamos prestamos = new Prestamos();
            Libros libro1 = new Libros();

            prestamos = (sender as FrameworkElement).DataContext as Prestamos;
            GuardarPrestamo enviar = new GuardarPrestamo();
            enviar.Show();
            enviar.opcion = "Editar";
            enviar.txtIdPrestamos.Text = prestamos.Id.ToString();
            enviar.txtFechaPrestamo.Text = prestamos.Fec_pres.ToString();
            enviar.txtFechaDevolucion.Text = prestamos.Fec_devo.ToString();
            enviar.txtNombreLibro.Text = prestamos.Libros.Nombre.ToString();
            enviar.txtNombreCliente.Text = prestamos.Clientes.Nombre.ToString();
            enviar.SeleccionarEmpleado.Text = prestamos.Empleados.Nombre.ToString();
            enviar.txtMonto.Text = prestamos.Cobro_retardo.ToString();
            this.Close();
        }
        private void CobrarPrestamos(object sender, RoutedEventArgs e)
        {
            try
            {
                Prestamos prestamos = new Prestamos();

                using (var _context = new AplicationdbContext())
                {
                    prestamos = _context.Prestamos.Find(prestamos.Cobro_retardo);

                    _context.Entry(prestamos).State = EntityState.Modified;
                    _context.SaveChanges();

                    MessageBox.Show("Se han guardado tus cambios");
                    MostrarPrestamos();
                }
            }
            catch (Exception)
            {
                
            }
        }
        private void BorrarPrestamos(object sender, RoutedEventArgs e)
        {
            Prestamos prestamos = new Prestamos();
            prestamos = (sender as FrameworkElement).DataContext as Prestamos;
            using (var _context = new AplicationdbContext())
            {
                _context.Prestamos.Remove(prestamos);
                _context.SaveChanges();
                
            }
            MostrarPrestamos();
        }
        private void PrestamosTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SalirPrestamo_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}