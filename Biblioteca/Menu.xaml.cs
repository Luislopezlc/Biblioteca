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

namespace Biblioteca
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    /// 
    public partial class Menu : Window
    {
       
        public Menu()
        {
            InitializeComponent();
            
        }

        private void EmpleadosAbrir_Click(object sender, RoutedEventArgs e)
        {
            ModuloEmpleados empleado = new ModuloEmpleados();
            // evento para abrir la ventana del modulo empleados
            
            empleado.Show();
            
            this.Close();

        }

        private void ClientesAbrir_Click(object sender, RoutedEventArgs e)
        {
            //evento para abrir la ventana del modulo clientes
            ModuloClientes clientes= new ModuloClientes();
            clientes.Show();
           
            this.Close();
        }
        

        private void LibrosAbrir_Click(object sender, RoutedEventArgs e)
        {
            //evento para abrir la ventana del modulo libros
            ModuloLibros libro = new ModuloLibros();
            libro.Show();
            this.Close();
        }

        private void CerrarMenu_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            
        }

        private void PrestamosAbrir_Click(object sender, RoutedEventArgs e)
        {
            //evento para abrir la ventana del modulo prestamos
            ModuloPrestamos prestamos = new ModuloPrestamos();
            prestamos.Show();
            this.Close();
        }
    }
}
