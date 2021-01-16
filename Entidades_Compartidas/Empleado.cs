using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Empleado
    {

        int _Cedula;
        string _Nombre;
        string _Contrasenia;

        public int Cedula
        {
            get { return _Cedula; }
            set 
            {
                if (value > 99999999 && value < 10000000)
                    throw new Exception("El numero de Cedula debe de tener 8 digitos.");                
                else
                    _Cedula = value;
            }
        }

        public string Nombre 
        {
            get { return _Nombre; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se debe ingresar un nombre para el Empleado");
                else if (value.Length > 20)
                    throw new Exception("El largo maximo para el nombre es de 20 caracteres.");
                else
                    _Nombre = value;
            }
        }

        public string Contrasenia 
        {
            get { return _Contrasenia; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar una contrasenia.");
                else if (value.Length < 10 || value.Length > 20)
                    throw new Exception("La contrasenia debe de tener un largo de 10 a 20 caracteres.");
                else
                    _Contrasenia = value;
            }
        }

        public Empleado(int pCedula, string pNombre, string pContrasenia) 
        {
            Cedula = pCedula;
            Nombre = pNombre;
            Contrasenia = pContrasenia;
        }

        public override string ToString()
        {
            return "Nombre: " + _Nombre + "\nCedula: " + _Cedula + ".";
        }
    }
}
