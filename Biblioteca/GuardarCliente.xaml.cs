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
    /// Lógica de interacción para GuardarCliente.xaml
    /// </summary>
    public partial class GuardarCliente : Window
    {
        
        public string opcion = "";
        Validaciones validar = new Validaciones();
        bool nombre, fec, direccion, edad, genero, telefono, fecn;

        public GuardarCliente()
        {
            InitializeComponent();
            validar.ComboVacio(CmbGenero, ValiGenero);
            validar.Nombre(TxtNombre, ValiNombre);
            validar.Fecha(TxtFec_regis, ValiFec_regis);
            validar.NumerosCortos(TxtEdad, ValiEdad);
            validar.Fecha(TxtFec_nac, ValiFec_nac);
            validar.Telefono(TxtTelefono, ValiTelefono);
            validar.Nombre(TxtDireccion, ValiDireccion);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);
            CmbGenero.Items.Add("Masculino");
            CmbGenero.Items.Add("Femenino");
            CmbGenero.Items.Add("Otro");
        }
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            ModuloClientes clientes = new ModuloClientes();
            clientes.Show();
            Limpiar_Boxs();
            
            this.Close();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (opcion == "Insertar")
                {
                    Clientes cliente = new Clientes()
                    {
                       //Preguntar por qué , en vez de ;
                        Nombre = TxtNombre.Text,
                        Fec_regis = TxtFec_regis.Text,
                        Direccion= TxtDireccion.Text,
                        Edad = int.Parse(TxtEdad.Text),
                        Genero = CmbGenero.Text,
                        Fec_nac = TxtFec_nac.Text,
                        Telefono = TxtTelefono.Text,

                    };

                    using (var _context = new AplicationdbContext())
                    {
                        _context.Clientes.Add(cliente);
                        _context.SaveChanges();
                    }

                }
                else if (opcion == "Editar")
                {

                    Clientes clienteedit = new Clientes();
                    clienteedit.Id = int.Parse(TxtIdClientes.Text);

                    using (var _context = new AplicationdbContext())
                    {
                        clienteedit = _context.Clientes.Find(clienteedit.Id);
                        clienteedit.Nombre = TxtNombre.Text;
                        clienteedit.Fec_regis = TxtFec_regis.Text;
                        clienteedit.Direccion = TxtDireccion.Text;
                        clienteedit.Edad = int.Parse(TxtEdad.Text);
                        clienteedit.Genero = CmbGenero.Text;
                        clienteedit.Fec_nac = TxtFec_nac.Text;
                        clienteedit.Telefono = TxtTelefono.Text;
                        _context.Entry(clienteedit).State = EntityState.Modified;
                        _context.SaveChanges();

                    }
                }
                opcion = "";
                ModuloClientes moduloClientes = new ModuloClientes();
                moduloClientes.Show();
               
                this.Close();
                Limpiar_Boxs();
            }
            catch (Exception)
            {


            }
        }

        public void Limpiar_Boxs()
        {
            TxtIdClientes.Clear();
            TxtNombre.Clear();
            TxtFec_regis.Clear();
            TxtDireccion.Clear();
            TxtEdad.Clear();
            CmbGenero= null;
            TxtFec_nac.Clear();
            TxtTelefono.Clear();
        }

        private void TxtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombre = validar.Nombre(TxtNombre, ValiNombre);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);
        }
        //private void txtFec_regis_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    fec = validar.Fecha(TxtFec_regis, ValiFec_regis);
        //    DatosCorrectos(nombre, fec, direccion, edad, genero, telefono);
        //}


        private void TxtDireccion_TextChanged(object sender, TextChangedEventArgs e)
        {
            direccion = validar.Nombre(TxtDireccion, ValiDireccion);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);
        }

        private void CmbGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CmbGenero_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            genero = validar.ComboVacio(CmbGenero, ValiGenero);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);
        }

        private void TxtFec_regis_TextChanged(object sender, TextChangedEventArgs e)
        {
            fec = validar.Fecha(TxtFec_regis, ValiFec_regis);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);
        }

        private void TxtEdad_TextChanged(object sender, TextChangedEventArgs e)
        {
            edad = validar.NumerosCortos(TxtEdad, ValiEdad);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);

        }

        private void CmbGenero_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void TxtFec_nac_TextChanged(object sender, TextChangedEventArgs e)
        {
            fecn = validar.Fecha(TxtFec_nac, ValiFec_nac);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);
        }

        private void TxtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefono = validar.Telefono(TxtTelefono, ValiTelefono);
            DatosCorrectos(nombre, fec, direccion, edad, genero, telefono, fecn);
        }

        private void DatosCorrectos(bool nombre, bool fec, bool direccion, bool edad, bool genero, bool telefono, bool fecn)
        {
            if (nombre == true && direccion == true && edad == true && genero == true && telefono == true && fecn==true)
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
