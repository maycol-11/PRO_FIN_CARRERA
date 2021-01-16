using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Entidad
    {
        //Atributos

        string _Nombre;
        string _Direccion;
        List<string> _Telefonos;        

        //Propiedades

        public string Nombre 
        {
            get { return _Nombre; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se debe ingresar un nombre para la Entiad.");
                else if (value.Length > 20)
                    throw new Exception("El largo maximo para el nombre es de 20 caracteres.");
                else
                    _Nombre = value;
            }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se debe ingresar la direccion de la entidad.");
                else if (value.Length > 20)
                    throw new Exception("El largo maximo para el nombre es de 20 caracteres.");
                else                
                   _Direccion = value;                
            }
        }

        public List<string> Telefonos
        {
            get { return _Telefonos; }
            set 
            {
                if (value == null)
                    throw new Exception("Error en lista de telefonos");
                if (value.Count < 0)
                    throw new Exception("La entidad no tiene numero telefonico");
                else
                    _Telefonos = value;
            }
        }

        //Constructores

        public Entidad(string pNombre, string pDireccion, List<string> pTelefonos)
        {
            Nombre = pNombre;
            Direccion = pDireccion;
            Telefonos = pTelefonos;
        }

        //Operaciones

        public override string ToString()
        {
            List<string> listaTelefonos = _Telefonos;

            string telefono = "";

            foreach (string tel in listaTelefonos) 
            {
                telefono += " - " + tel;
            }

            return "Nombre: " + _Nombre + " \nDireccion: " + _Direccion + " \nTelefono/s: " + telefono;
        }
    }
}
