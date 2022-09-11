using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Biblioteca.Context;
using Biblioteca.Modelo;
using System.Linq;

namespace Biblioteca
{
    /// <summary>
    /// Lógica de interacción para GuardarEmpleado.xaml
    /// </summary>
    public partial class GuardarEmpleado : Window
    {
        Empleados empleadorol;
        public List<Roles>  Roles { get; set; }
        
        public string opcion = "";
        Validaciones validar = new Validaciones();
        bool nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña, rol;
        public GuardarEmpleado()
        {
            InitializeComponent();
            validar.Nombre(txtNombre, valiNombre);
            validar.Nombre(txtApellido, valiApellido);
            validar.NombreLib(txtDireccion, valiDireccion);
            validar.Fecha(txtFec_nac, valiFec_nac);
            validar.NumerosCortos(txtEdad, valiEdad);
            validar.ComboVacio(CmbGenero, valiGenero);
            validar.Fecha(txtFec_reg, valiFec_reg);
            validar.Telefono(txtTelefono, valiTelefono);
            validar.Correo(txtCorreo, valiCorreo);
            validar.ComboVacio(CmbRol, valiRol);
            validar.NombreLib(txtContraseña, valiContraseña);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol);
           CmbGenero.Items.Add("Masculino");
           CmbGenero.Items.Add("Femenino");
           CmbGenero.Items.Add("Otro");
            ListaRoles();
        }
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        { 
            ModuloEmpleados moduloEmpleados = new ModuloEmpleados();
            moduloEmpleados.Show();
            Limpiar_Boxs();
            this.Close();
        }
        
        private void txtApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            apellido = validar.Nombre(txtApellido, valiApellido);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol); 
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombre = validar.Nombre(txtNombre, valiNombre);
            DatosCorrectos(nombre, apellido, correo, edad, genero, contraseña, telefono, fec_reg, direccion, fec_nac,rol);
        }

        private void txtDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            direccion = validar.NombreLib(txtDireccion,valiDireccion);
            DatosCorrectos(nombre, apellido, correo, edad, genero, contraseña, telefono, fec_reg, direccion, fec_nac,rol);

        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (opcion == "Insertar")
                {
                    Empleados empleados = new Empleados()
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Direccion = txtDireccion.Text,
                        Genero = CmbGenero.Text,
                        Fec_nac = txtFec_nac.Text,
                        Fec_reg = txtFec_reg.Text,
                        Correo = txtCorreo.Text,
                        FKRol = int.Parse(CmbRol.SelectedValue.ToString()),
                        Contraseña = txtContraseña.Text,
                        Edad = int.Parse(txtEdad.Text),
                        Telefono = txtTelefono.Text,
                    };

                    using (var _context = new AplicationdbContext())
                    {
                        _context.Empleados.Add(empleados);
                        _context.SaveChanges();
                    }

                }
                else if (opcion == "Editar")
                {

                    Empleados empleadoedit = new Empleados();
                    empleadoedit.Id = int.Parse(txtIdEmpleados.Text);

                    using (var _context = new AplicationdbContext())
                    {
                        empleadoedit = _context.Empleados.Find(empleadoedit.Id);
                        empleadoedit.Nombre = txtNombre.Text;
                        empleadoedit.Apellido = txtApellido.Text;
                        empleadoedit.Direccion = txtDireccion.Text;
                        empleadoedit.Genero = CmbGenero.Text;
                        empleadoedit.Fec_nac = txtFec_nac.Text;
                        empleadoedit.FKRol = int.Parse(CmbRol.SelectedValue.ToString());
                        empleadoedit.Fec_reg = txtFec_reg.Text;
                        empleadoedit.Correo = txtCorreo.Text;
                        empleadoedit.Contraseña = txtContraseña.Text;
                        empleadoedit.Edad = int.Parse(txtEdad.Text);
                        empleadoedit.Telefono = txtTelefono.Text;
                        _context.Entry(empleadoedit).State = EntityState.Modified;
                        _context.SaveChanges();

                    }
                }
                opcion = "";
                ModuloEmpleados moduloEmpleados = new ModuloEmpleados();
                moduloEmpleados.Show();
                this.Close();
                Limpiar_Boxs();
            }
            catch (Exception)
            {


            }
        }

        private void CmbGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            genero = validar.ComboVacio(CmbGenero, valiGenero);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol);
        }

        private void CmbRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rol = validar.ComboVacio(CmbRol, valiRol);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol);

        }

        private void txtFec_nac_TextChanged(object sender, TextChangedEventArgs e)
        {
            fec_nac = validar.Fecha(txtFec_nac, valiFec_nac);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol);
        }

        private void txtEdad_TextChanged(object sender, TextChangedEventArgs e)
        {
            edad = validar.NumerosCortos(txtEdad, valiEdad);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol);
        }

        private void txtGenero_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtFec_reg_TextChanged(object sender, TextChangedEventArgs e)
        {
            fec_reg = validar.Fecha(txtFec_reg, valiFec_reg);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol);
        }

        private void txtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefono = validar.Telefono(txtTelefono, valiTelefono);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña,rol);
        }

        private void txtCorreo_TextChanged(object sender, TextChangedEventArgs e)
        {
            correo = validar.Correo(txtCorreo, valiCorreo);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña, rol); 
        }

        private void txtContraseña_TextChanged(object sender, TextChangedEventArgs e)
        {
            contraseña = validar.NombreLib(txtContraseña, valiContraseña);
            DatosCorrectos(nombre, apellido, fec_nac, direccion, edad, fec_reg, genero, telefono, correo, contraseña, rol);
        }
        private void DatosCorrectos(bool nombre, bool apellido, bool fec_nac, bool direccion, bool edad, bool fec_reg, bool genero, bool telefono, bool correo, bool contraseña,bool rol)
        {
            if (nombre == true && apellido == true && fec_nac == true && direccion == true && edad == true && fec_reg == true && genero == true && telefono == true && correo == true && contraseña == true && rol == true)
            {
                BtGuardar.IsEnabled = true;
            }
            else
            {
                BtGuardar.IsEnabled = false;
            }
        }
        public void Limpiar_Boxs()
        {
            txtIdEmpleados.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtFec_nac.Clear();
            txtEdad.Clear();           
            txtFec_reg.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();
        }

        public void ListaRoles()
        {

            using (var _context = new AplicationdbContext())
            {

                var rol = _context.Roles.ToList();

                Roles = rol;


            }

            CmbRol.ItemsSource = Roles;
        }
    }
}
