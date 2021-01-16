using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class Logica_Entidad
    {
        public static Entidad Buscar(string _Nombre)
        {
            Entidad _En = Persistencia_Entidad.Buscar(_Nombre);
            return _En;
        }

        public static void Agregar(Entidad e) 
        {
            Persistencia_Entidad.Agregar(e);
        }

        public static void Modificar(Entidad e)
        {
            Persistencia_Entidad.Modificar(e);
        }

        public static void Eliminar(Entidad e)
        {
            Persistencia_Entidad.Eliminar(e);
        }

        public static List<Entidad> Listar_Entidad() 
        {
            List<Entidad> Entidades = Persistencia_Entidad.Listar_Entidad();
            return Entidades;
        }
    }
}
