using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Biblioteca
{
    //Realice un clase para validar los tipos de datos para aprender como funcionaban las validaciones con Regex
    //se pudo usar un libreria y seria mas sencillo pero preferi hacerlo de este modo
    public class Validaciones//clase para validar las tipos de datos que se usan en el proyecto
    {

        public bool NombreLib(TextBox txtbox1, Label lb1)//valida un texto largo que puede contener numeros
        {
            string nulo = "*obligatorio";
            string rango = "*menor a 50 digitos";
            bool error1, error2;
            if (txtbox1.Text.Length < 1)
            {             
                error1 = true;
            }
            else
            {            
                error1 = false;
            }

            if (txtbox1.Text.Length > 49)
            {
                error2 = true;              
            }
            else
            {               
                error2 = false;
            }

            if (error1 == true && error2 == false)
            {
                lb1.Content = nulo;
            }
            else if (error1 == false && error2 == true)
            {
                lb1.Content = rango;
            }
            else if (error1 == false && error2 == false)
            {
                lb1.Content = "";
            }
            
            if (error1 == false && error2 == false)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        public bool Nombre(TextBox textBox1, Label label1)// valida un texto corto, que no contenga numeros
        {
            string nonumeros = "*No acepta numeros";
            string nulo = "*obligatorio";
            string rango = "*menor a 30 digitos";
            bool error1,error2,error3;

            

            if (textBox1.Text.Length < 1)
            {
                error1 = true;
            }
            else
            {
                error1 = false;
            }

            Regex regex = new Regex(@"[a-zA-Z]");
            if (regex.IsMatch(textBox1.Text))
            {
                error2 = false;
                
            }
            else
            {
                error2 = true;
            }

            if (textBox1.Text.Length > 30)
            {
                error3 = true;
            }
            else
            {
                error3 = false;
            }


            if (error1==true && error2 == true && error3==false)
            {
                label1.Content = nulo;
            }
            else if (error1==false && error2== true && error3==false)
            {
                label1.Content = nonumeros;
            }
            else if (error1==false && error2 == true && error3 == true)
            {
                label1.Content = nonumeros + " " + rango;
            }
            else if (error1 == false && error2 == false && error3 == true)
            {
                label1.Content = rango;
            }
            else if(error1 == false && error2 == false && error3 == false)
            {
                label1.Content = "";
            }

            if (error1 == false && error2 == false && error3 == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool Fecha(TextBox textBox1, Label label1)
        {
            string nulo = "*obligatorio";
            string fecha = "*Formato incorrecto: dd/mm/aaaa";
            bool error1, error2;
           
            if (textBox1.Text.Length < 1)
            {
                error1 = true;
            }
            else
            {
                error1 = false;
            }

            Regex regex = new Regex(@"\d{2}[/]\d{2}[/]\d{4}");
            if (regex.IsMatch(textBox1.Text))
            {
                error2 = false;

            }
            else
            {
                error2 = true;
            }

            if (error1 == true && error2 == true)
            {
                label1.Content = nulo;
            }
            else if (error1 == false && error2 == true)
            {
                label1.Content = fecha;
            }
            else if (error1 == false && error2 == false)
            {
                label1.Content = "";
            }

            if (error1 == false && error2 == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool NumerosCortos(TextBox textBox1, Label label1)
        {
            string nulo = "*obligatorio";
            string numero = "*solo numeros";
            string rango = "*menor a 3 digitos";
            bool error1, error2, error3;
           

            if (textBox1.Text.Length < 1)
            {
                error1 = true;
            }
            else
            {
                error1 = false;
            }

            Regex regex = new Regex(@"\d");
            if (regex.IsMatch(textBox1.Text))
            {
                error2 = false;

            }
            else
            {
                error2 = true;
            }

            if (textBox1.Text.Length > 3)
            {
                error3 = true;
            }
            else
            {
                error3 = false;
            }

            if (error1 == true && error2 == true && error3 == false)
            {
                label1.Content = nulo;
            }
            else if (error1 == false && error2 == true && error3 == false)
            {
                label1.Content = numero;
            }
            else if (error1 == false && error2 == true && error3 == true)
            {
                label1.Content = numero + " " + rango;
            }
            else if (error1 == false && error2 == false && error3 == true)
            {
                label1.Content = rango;
            }
            else if (error1 == false && error2 == false && error3 == false)
            {
                label1.Content = "";
            }

            if (error1 == false && error2 == false && error3 == false)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Isbn(TextBox textBox1, Label label1)
        {

            string nulo = "*obligatorio";
            string numero = "*solo numeros";
            string rango = "*menor a 13 digitos";
            bool error1, error2, error3;


            if (textBox1.Text.Length < 1)
            {
                error1 = true;
            }
            else
            {
                error1 = false;
            }

            Regex regex = new Regex(@"\d");
            if (regex.IsMatch(textBox1.Text))
            {
                error2 = false;

            }
            else
            {
                error2 = true;
            }

            if (textBox1.Text.Length > 13)
            {
                error3 = true;
            }
            else
            {
                error3 = false;
            }

            if (error1 == true && error2 == true && error3 == false)
            {
                label1.Content = nulo;
            }
            else if (error1 == false && error2 == true && error3 == false)
            {
                label1.Content = numero;
            }
            else if (error1 == false && error2 == true && error3 == true)
            {
                label1.Content = numero + " " + rango;
            }
            else if (error1 == false && error2 == false && error3 == true)
            {
                label1.Content = rango;
            }
            else if (error1 == false && error2 == false && error3 == false)
            {
                label1.Content = "";
            }

            if (error1 == false && error2 == false && error3 == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Telefono(TextBox textBox1, Label label1)
        {
            string nulo = "*obligatorio";
            string numero = "*solo numeros";
            string rango = "*menor a 10 digitos";
            bool error1, error2, error3;


            if (textBox1.Text.Length < 1)
            {
                error1 = true;
            }
            else
            {
                error1 = false;
            }

            Regex regex = new Regex(@"\d");
            if (regex.IsMatch(textBox1.Text))
            {
                error2 = false;

            }
            else
            {
                error2 = true;
            }

            if (textBox1.Text.Length > 10)
            {
                error3 = true;
            }
            else
            {
                error3 = false;
            }

            if (error1 == true && error2 == true && error3 == false)
            {
                label1.Content = nulo;
            }
            else if (error1 == false && error2 == true && error3 == false)
            {
                label1.Content = numero;
            }
            else if (error1 == false && error2 == true && error3 == true)
            {
                label1.Content = numero + " " + rango;
            }
            else if (error1 == false && error2 == false && error3 == true)
            {
                label1.Content = rango;
            }
            else if (error1 == false && error2 == false && error3 == false)
            {
                label1.Content = "";
            }

            if (error1 == false && error2 == false && error3 == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Correo(TextBox textBox1, Label label1)
        {
            string nulo = "*obligatorio";
            string fecha = "*Formato incorrecto: ejemplo@ejem.com";
            bool error1, error2;

            if (textBox1.Text.Length < 1)
            {
                error1 = true;
            }
            else
            {
                error1 = false;
            }

            Regex regex = new Regex(@"\w+[@]+[\w]+[.com]+");
            if (regex.IsMatch(textBox1.Text))
            {
                error2 = false;

            }
            else
            {
                error2 = true;
            }

            if (error1 == true && error2 == true)
            {
                label1.Content = nulo;
            }
            else if (error1 == false && error2 == true)
            {
                label1.Content = fecha;
            }
            else if (error1 == false && error2 == false)
            {
                label1.Content = "";
            }

            if (error1 == false && error2 == false)
            {
                return true;
            }
            else
            {
                return false;
            }

        //    public bool FePrestamo(TextBox textBox1, Label label1)
        //    {
        //            string nulo = "*obligatorio";
        //            string numero = "*solo numer";
        //            bool error1, error2;


        //            if (textBox1.Text.Length < 1)
        //            {
        //            error1 = true;
        //        }
        //        else
        //        {
        //            error1 = false;
        //        }

        //        Regex regex = new Regex(@"\w+[@]+[\w]+[.com]+");
        //        if (regex.IsMatch(textBox1.Text))
        //        {
        //            error2 = false;

        //        }
        //        else
        //        {
        //            error2 = true;
        //        }

        //        if (error1 == true && error2 == true)
        //        {
        //            label1.Content = nulo;
        //        }
        //        else if (error1 == false && error2 == true)
        //        {
        //            label1.Content = fecha;
        //        }
        //        else if (error1 == false && error2 == false)
        //        {
        //            label1.Content = "";
        //        }

        //        if (error1 == false && error2 == false)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        
    }
        public bool ComboVacio(ComboBox cb1, Label lb1)
        {
            if (cb1.SelectedItem == null)
            {
                lb1.Content = "*obligatorio";
                return false;
               
            }
            else
            {
                lb1.Content="";
                return true;
            }          
        }

       
    }
}
