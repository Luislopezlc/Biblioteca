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
    /// Lógica de interacción para GuardarPrestamo.xaml
    /// </summary>
    public partial class GuardarPrestamo : Window
    {
        public List<Empleados> Empleados { get; set; }
        public string opcion = "";
       
        Validaciones validar = new Validaciones();
        bool nombrelib,fechapres,nombrecli,fechadevo,monto, empleado;

        public GuardarPrestamo()
        {
            InitializeComponent();
            validar.NombreLib(txtNombreLibro, valiNombreLibro);
            validar.Nombre(txtNombreCliente, valiNombreCliente);
            validar.Fecha(txtFechaPrestamo, valiFechaPrestamo);
            validar.Fecha(txtFechaDevolucion, valiFechaDevolucion);
            validar.ComboVacio(SeleccionarEmpleado, valiNombreEmpleado);
            validar.NumerosCortos(txtMonto, valiMonto);
            DatosCorrectos(nombrelib, fechapres, nombrecli, fechadevo,monto, empleado);
            ListaEmpelados();
        }

        private void txtNombreLibro_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombrelib = validar.NombreLib(txtNombreLibro, valiNombreLibro);
            DatosCorrectos(nombrelib, fechapres, nombrecli, fechadevo,monto, empleado);
        }

        private void txtNombreEmpleado_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNombreCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombrecli = validar.Nombre(txtNombreCliente, valiNombreCliente);
            DatosCorrectos(nombrelib, fechapres, nombrecli, fechadevo, monto, empleado);
        }

        private void txtFechaPrestamo_TextChanged(object sender, TextChangedEventArgs e)
        {
            fechapres = validar.Fecha(txtFechaPrestamo, valiFechaPrestamo);
            DatosCorrectos(nombrelib, fechapres, nombrecli, fechadevo, monto, empleado);
        }

        private void txtFechaDevolucion_TextChanged(object sender, TextChangedEventArgs e)
        {
            fechadevo = validar.Fecha(txtFechaDevolucion, valiFechaDevolucion);
            DatosCorrectos(nombrelib, fechapres, nombrecli, fechadevo, monto, empleado  );
        }

        private void BtGuardar_Click(object sender, RoutedEventArgs e)
        {
            int IdCliente=0;
            int IdLibro=0;
            try
            {
                    Libros libro1 = new Libros();
                    libro1.Nombre = txtNombreLibro.Text;
                    using (var _context = new AplicationdbContext())
                    {
                        try
                        {
                            libro1 = _context.Libros.Single(x => x.Nombre == libro1.Nombre);
                            IdLibro = libro1.Id;
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Este libro no existe");
                        }

                    }
                    Clientes cliente1 = new Clientes();
                    cliente1.Nombre = txtNombreCliente.Text;
                    using (var _context = new AplicationdbContext())
                    {
                        try
                        {
                            cliente1 = _context.Clientes.Single(x => x.Nombre == cliente1.Nombre);
                            IdCliente = cliente1.Id;
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Este cliente no existe");
                        }
                    }
                if (opcion == "Insertar")
                {
                    Prestamos prestamos = new Prestamos()
                    {
                        Fec_pres = txtFechaPrestamo.Text,
                        Fec_devo = txtFechaDevolucion.Text,
                        Cobro_retardo = int.Parse(txtMonto.Text),

                        FKClientes = IdCliente,
                        FKEmpleados = int.Parse(SeleccionarEmpleado.SelectedValue.ToString()),
                        FKLibros = IdLibro,
                    };
                    using(var _context = new AplicationdbContext())
                    {
                        _context.Prestamos.Add(prestamos);
                        _context.SaveChanges();
                    }
                }else if(opcion == "Editar")
                {
                    
                    Prestamos prestamosedit = new Prestamos();
                    prestamosedit.Id = int.Parse(txtIdPrestamos.Text);
                    using (var _context = new AplicationdbContext())
                    {
                        prestamosedit.FKLibros = IdLibro;
                        prestamosedit.FKEmpleados = int.Parse(SeleccionarEmpleado.SelectedValue.ToString());
                        prestamosedit.FKClientes = IdCliente;                      
                        prestamosedit.Fec_pres = txtFechaPrestamo.Text;
                        prestamosedit.Cobro_retardo = int.Parse(txtMonto.Text);
                        prestamosedit.Fec_devo = txtFechaDevolucion.Text;                   
                        _context.Entry(prestamosedit).State = EntityState.Modified;
                        //MessageBox.Show("Su préstamo a sido modificado");
                        _context.SaveChanges();
                     }
                    }
                opcion = "";
                ModuloPrestamos moduloPrestamos = new ModuloPrestamos();
                moduloPrestamos.Show();
                this.Close();
                Limpiar_Boxs();
            }
            catch(Exception)
            {

            }
        }

        private void SeleccionarEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            empleado = validar.ComboVacio(SeleccionarEmpleado, valiNombreEmpleado);
            DatosCorrectos(nombrelib, fechapres, nombrecli, fechadevo, monto, empleado);
        }
        private void BtCancelar_Click(object sender, RoutedEventArgs e)
        {
            ModuloPrestamos moduloPrestamos = new ModuloPrestamos();
            moduloPrestamos.Show();
            Limpiar_Boxs();
            this.Close();
        }

        private void txtMonto_TextChanged(object sender, TextChangedEventArgs e)
        {
            monto = validar.NumerosCortos(txtMonto, valiMonto);
            DatosCorrectos(nombrelib, fechapres, nombrecli, fechadevo, monto, empleado);
        }

        public void ListaEmpelados()
        {
            using (var _context = new AplicationdbContext())
            {
                var empleado = _context.Empleados.ToList();

                Empleados = empleado;

            }
            SeleccionarEmpleado.ItemsSource = Empleados;
                
        }
        public void Limpiar_Boxs()
    {
            txtIdPrestamos.Clear();
            txtNombreLibro.Clear();
            txtNombreCliente.Clear();
            txtFechaDevolucion.Clear();
            txtFechaPrestamo.Clear();
    }
        private void DatosCorrectos(bool nombrelib, bool fechapres, bool nombrecli, bool fechadevo, bool monto, bool empleado)
        {
            if (nombrelib == true && fechapres == true && nombrecli == true && fechadevo == true && monto == true && empleado == true)
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
