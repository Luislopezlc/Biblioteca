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
    /// Lógica de interacción para ModuloClientes.xaml
    /// </summary>
    public partial class ModuloClientes : Window
    {
        
        public ModuloClientes()
        {
            InitializeComponent();
            MostrarClientes();

        }
        public void MostrarClientes()
        {
            using (var _context = new AplicationdbContext())
            {
                ClientesTable.ItemsSource = _context.Clientes.ToList();
           
            }

        }
        private void InsertarCliente_Click(object sender, RoutedEventArgs e)
        {
            GuardarCliente enviar = new GuardarCliente();
            enviar.opcion = "Insertar";
            enviar.Show();
           
            this.Close();
        }


        private void BorrarCliente(object sender, RoutedEventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente = (sender as FrameworkElement).DataContext as Clientes;

            using (var _context = new AplicationdbContext())
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
            MostrarClientes();
        }

        private void SalirClientes_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void ClientesTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SeleccionarClientes(object sender, RoutedEventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente = (sender as FrameworkElement).DataContext as Clientes;
            GuardarCliente enviar = new GuardarCliente();
            enviar.Show();
            enviar.opcion = "Editar";
            enviar.TxtIdClientes.Text = cliente.Id.ToString();
            enviar.TxtNombre.Text = cliente.Nombre.ToString();
            enviar.TxtFec_regis.Text = cliente.Fec_regis.ToString();
            enviar.TxtDireccion.Text = cliente.Direccion.ToString();
            enviar.TxtEdad.Text = cliente.Edad.ToString();
            enviar.CmbGenero.Text = cliente.Genero.ToString();
            enviar.TxtFec_nac.Text = cliente.Fec_nac.ToString();
            enviar.TxtTelefono.Text = cliente.Telefono.ToString();
            this.Close();
        }
    }
}
