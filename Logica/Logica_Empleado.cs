using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades_Compartidas;
using Persistencia;

namespace Logica
{
    public class Logica_Empleado
    {
        public static Empleado Buscar(int _Cedula) 
        {
            Empleado _Em = Persistencia_Empleado.Buscar(_Cedula);
            return _Em;
        }

        public static void Agregar(Empleado _Em)
        {
           Persistencia_Empleado.Agregar(_Em);
        }

        public static void Modificar(Empleado _Em) 
        {
            Persistencia_Empleado.Modificar(_Em);
        }

        public static void Eliminar(Empleado _Em) 
        {
            Persistencia_Empleado.Eliminar(_Em);
        }

        public static Empleado Login(int _Cedula, string _Contrasenia)
        {
            Empleado _Em = Persistencia_Empleado.Login(_Cedula, _Contrasenia);
            return _Em;
        }
    }
}
