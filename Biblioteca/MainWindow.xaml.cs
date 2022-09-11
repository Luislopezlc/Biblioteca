using Biblioteca.Context;
using Biblioteca.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Cerrar_Click(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void Recordar_Click(object sender, RoutedEventArgs e)
        {
            Empleados empleado1 = new Empleados();

            empleado1.Correo = txtCorreo.Text;
            using (var _context = new AplicationdbContext())
            {
                try
                {
                    empleado1 = _context.Empleados.Single(x => x.Correo == empleado1.Correo);

                    MessageBox.Show("Su contraseña es:" + empleado1.Contraseña.ToString());
                    txtContra.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Este correo no esta registrado en el sistema");
                    
                }
                

            }

        }

        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {
            string Correo;
            string Contra;
            Empleados empleado1 = new Empleados();
            Correo = txtCorreo.Text;
            Contra = txtContra.Password.ToString();
            empleado1.FKRol = 1;

            using (var _context = new AplicationdbContext())
            {
                var result = _context.Empleados.FirstOrDefault(x => x.Correo == Correo && x.Contraseña == Contra);

                if (result != null)
                {
                    Menu menu = new Menu();
                    menu.txtrol.Content = result.FKRol.ToString();
                    menu.Show();
                   
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario ó contraseña incorrecto");
                    txtContra.Clear();  

                }


            }


        }


    }
}
