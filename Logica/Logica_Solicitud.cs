using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class Logica_Solicitud
    {
        public static Solicitud Buscar(int _Numero_Solicitud) 
        {
            Solicitud _So = Persistencia_Solicitud.Buscar(_Numero_Solicitud);
           return _So;
        }

        public static void Agregar(Solicitud _So)
        {
            Persistencia_Solicitud.Agregar(_So);
        }

        public static void ModificarEstado(Solicitud _So)
        {
            Persistencia_Solicitud.ModificarEstado(_So);
        }

        public static List<Solicitud> ListarSolicitud(string _Codigo, string _Estado) 
        {
            List<Solicitud> lista = Persistencia_Solicitud.ListarSolicitud(_Codigo, _Estado);
            return lista;
        }

        public static List<Solicitud> ListadoSolicitudAlta()
        {
            List<Solicitud> listaSolicitudAlta = Persistencia_Solicitud.ListarSolicitudAlta();
            return listaSolicitudAlta;
        }

        public static List<Solicitud> ListadoFecha(DateTime _Fecha) 
        {
            List<Solicitud> listaSolicitudes = Persistencia_Solicitud.ListadoFecha(_Fecha);
            return listaSolicitudes;
        }
    }
}