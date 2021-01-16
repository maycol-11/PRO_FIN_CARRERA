using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades_Compartidas
{
    public class Solicitud
    {
        int _Numero;
        DateTime _Fecha;
        string _Estado;
        string _Nombre_Solicitante;

        Tramite _Tr;
        Empleado _Em;

        public int Numero 
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public DateTime Fecha 
        {
            get { return _Fecha; }
            set 
            {
                if (value == null)
                    throw new Exception("Se debe Ingresar una fecha para la solicitud");
                else
                    _Fecha = value;
            }
        }

        public string Estado 
        {
            get { return _Estado; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se debe ingresar un estado para la solicitud.");
                else if (value != "ALTA" && value != "EJECUTADA" && value != "ANULADA")
                    throw new Exception("El Estado Ingresado no es valido. Intente con ALTA, EJECUTADA, ANULADA.");
                else
                    _Estado = value;
            }
        }

        public string Nombre_Solicitante 
        {
            get { return _Nombre_Solicitante; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Se debe ingresaer el nombre del solicitante.");
                else if (value.Length > 20)
                    throw new Exception("El largo maximo para el nombre es de 20 caracteres.");
                else
                    _Nombre_Solicitante = value;
            }
        }

        public Tramite Tramite 
        {
            get { return _Tr; }
            set 
            {
                if (value == null)
                    throw new Exception("Se debe ingresar un tramite a la solicitud.");
                else
                    _Tr = value;
            }
        }

        public Empleado Empleado 
        {
            get { return _Em; }
            set 
            {
                if (value == null)
                    throw new Exception("Se debe ingresar un Empleado a la solicitud.");
                else
                    _Em = value;
            }
        }

        public Solicitud(int pNumero , DateTime pFecha, string pEstado, string pNombre_Solicitante, Tramite pTramite, Empleado pEmpleado) 
        {
            Fecha = pFecha;
            Estado = pEstado;
            Nombre_Solicitante = pNombre_Solicitante;
            Tramite = pTramite;
            Empleado = pEmpleado;
            Numero = pNumero;
        }

        public override string ToString()
        {
            return "Numero: " + _Numero + "\nFecha: " + _Fecha + "\nEstado: " + _Estado + "\nNombre Solicitante: " + _Nombre_Solicitante + ".";
        }
    }
}
