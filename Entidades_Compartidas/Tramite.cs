using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Tramite
    {
        //Atributos

        string _Codigo;
        string _Nombre;
        string _Descripcion;

        Entidad _En;

        //Propiedades

        public string Codigo 
        {
            get { return _Codigo; }
            set 
            {
                if (value.Length > 6)
                    throw new Exception("El codigo no puede superar los 6 caracteres.");
                else
                    _Codigo = value;
            }
        }

        public string Nombre 
        {
            get { return _Nombre; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se debe ingresar un nombre para el tramite.");
                else if (value.Length > 20)
                    throw new Exception("El largo maximo para el nombre es de 20 caracteres.");
                else
                    _Nombre = value;
            }
        }

        public string Descripcion 
        {
            get { return _Descripcion; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se debe ingresar una breve descripcion del tramite.");
                else if (value.Length > 30)
                    throw new Exception("Se puede usar un maximo de 30 caracteres.");
                else
                    _Descripcion = value;
            }
        }

        public Entidad Entidad 
        {
            get { return _En; }
            set 
            {
                if (value == null)
                    throw new Exception("Se necesita de una Entidad para el Tramite.");
                else
                    _En = value;
            }
        }

        //Constructures

        public Tramite(string pCodigo, string pNombre, string pDescripcion, Entidad pEntidad)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Entidad = pEntidad;
        }

        //Operaciones

        public override string ToString()
        {
            return "Codigo: " + _Codigo +"\nEntidad: " + _En.Nombre + "\nNombre Tramite: " + _Nombre + "\nDescripcion: " + _Descripcion;
        }
    }
}
