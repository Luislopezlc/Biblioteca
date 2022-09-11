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
using Microsoft.EntityFrameworkCore;
using Biblioteca.Context;
using Biblioteca.Modelo;

namespace Biblioteca
{
    /// <summary>
    /// Lógica de interacción para ModuloEmpleados.xaml
    /// </summary>
    public partial class ModuloEmpleados : Window
    {
        public Empleados empleadorol;
        public ModuloEmpleados()
        {
            
            InitializeComponent();
            MostrarEmpleados();
            
            
        }
        private void BtInsertarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            GuardarEmpleado enviar = new GuardarEmpleado();
            enviar.opcion = "Insertar";
            
            enviar.Show();
            this.Close();
        }
        private void BtSalirEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
        private void BorrarEmpleado(object sender, RoutedEventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado = (sender as FrameworkElement).DataContext as Empleados;

            using (var _context = new AplicationdbContext())
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
            MostrarEmpleados();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void MostrarEmpleados()
        {
            using (var _context = new AplicationdbContext())
            {
                EmpleadoTable.ItemsSource = _context.Empleados.Include(x => x.Roles).ToList();
            }
        }

        private void SeleccionarEmpleado(object sender, RoutedEventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados = (sender as FrameworkElement).DataContext as Empleados;
            GuardarEmpleado enviar = new GuardarEmpleado();
            enviar.Show();
            enviar.opcion = "Editar";
            enviar.txtIdEmpleados.Text = empleados.Id.ToString();
            enviar.txtNombre.Text = empleados.Nombre.ToString();
            enviar.txtApellido.Text = empleados.Apellido.ToString();
            enviar.txtDireccion.Text = empleados.Direccion.ToString();
            enviar.CmbGenero.Text = empleados.Genero.ToString();
            enviar.CmbRol.Text = empleados.Roles.Nombre.ToString();
            enviar.txtFec_reg.Text = empleados.Fec_reg.ToString();
            enviar.txtFec_nac.Text = empleados.Fec_nac.ToString();
            enviar.txtCorreo.Text = empleados.Correo.ToString();
            enviar.txtTelefono.Text = empleados.Telefono.ToString();
            enviar.txtEdad.Text = empleados.Edad.ToString();
            enviar.txtContraseña.Text = empleados.Contraseña.ToString();
            
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void EmpleadoTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
