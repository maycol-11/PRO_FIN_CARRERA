using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class Logica_Tramite
    {
        public static Tramite Buscar(string _Codigo, string _Nombre_Entidad)
        {
            Tramite _Tr = Persistencia_Tramite.Buscar(_Codigo, _Nombre_Entidad);
            return _Tr;
        }

        public static void Agregar(Tramite _Tr)
        {
            Persistencia_Tramite.Agregar(_Tr);
        }

        public static void Modificar(Tramite _Tr)
        {
            Persistencia_Tramite.Modificar(_Tr);            
        }

        public static void Eliminar(Tramite _Tr)
        {
            Persistencia_Tramite.Eliminar(_Tr);
        }

        public static List<Tramite> ListarTramite()
        {
            List<Tramite> _Tramites = Persistencia_Tramite.Listar_Tramite();
            return _Tramites;
        }

        public static List<Tramite> Listar_Tramite_X_Entidad(Entidad _En)
        {
            List<Tramite> _Tramites = Persistencia_Tramite.Listar_Tramite_X_Entidad(_En);
            return _Tramites;
        }
    }
}
