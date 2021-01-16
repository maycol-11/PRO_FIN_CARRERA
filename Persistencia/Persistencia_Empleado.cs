using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Entidades_Compartidas;
using System.Data;

namespace Persistencia
{
    public class Persistencia_Empleado
    {

        public static Empleado Buscar(int _Cedula) 
        {
            string _Nombre_Empleado, _Contrasenia;
            Empleado _Em = null;
            SqlDataReader _Lector;

            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_BuscarEmpleado", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Cedula", _Cedula);

            try
            {
                _Cnn.Open();
                _Lector = _Cmd.ExecuteReader();

                if (_Lector.HasRows)
                {
                    _Lector.Read();
                    _Nombre_Empleado = (string)_Lector["Nombre_Empleado"];
                    _Contrasenia = (string)_Lector["Contrasenia"];
                        
                   return new Empleado(_Cedula, _Nombre_Empleado, _Contrasenia);
                }
                _Lector.Close();
             }
            
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
            return _Em;
        }

        public static void Agregar(Empleado _Em) 
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_AgregarEmpleado", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Cedula", _Em.Cedula);
            _Cmd.Parameters.AddWithValue("@Nombre", _Em.Nombre);
            _Cmd.Parameters.AddWithValue("@Contrasenia", _Em.Contrasenia);
            SqlParameter _Retorno = new SqlParameter();
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Cmd.Parameters.Add(_Retorno);

            try 
            {
                _Cnn.Open();
                _Cmd.ExecuteNonQuery();

                switch ((int)_Retorno.Value)
                {
                    case -1:
                        throw new Exception("Ya existe una Empleado con la C.I. ingresada.");
                    case -2:
                        throw new Exception("Error al insertar datos en la tabla Empleados.");
                }                       
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }           
        }

        public static void Modificar(Empleado _Em) 
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_ModificarEmpleado", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Cedula", _Em.Cedula);
            _Cmd.Parameters.AddWithValue("@Nombre", _Em.Nombre);
            _Cmd.Parameters.AddWithValue("@Contrasenia", _Em.Contrasenia);

            SqlParameter _Retorno = new SqlParameter();
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Cmd.Parameters.Add(_Retorno);

            try
            {
                _Cnn.Open();
                _Cmd.ExecuteNonQuery();

                switch ((int)_Retorno.Value)
                {
                    case -1:
                        throw new Exception("No existe Empleado con el nombre " + _Em.Nombre);
                    case -2:
                        throw new Exception("Error al actualizar los datos en la tabla Empleados.");
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
        }

        public static void Eliminar(Empleado _Em)
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_EliminarEmpleado", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter _Nombre = new SqlParameter("@Cedula", _Em.Cedula);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Cmd.Parameters.Add(_Nombre);
            _Cmd.Parameters.Add(_Retorno);

            try
            {
                _Cnn.Open();
                _Cmd.ExecuteNonQuery();

                switch ((int)_Retorno.Value)
                {
                    case -1:
                        throw new Exception("No existe ninguna empleDo con la cC.I. " + _Em.Cedula);
                    case -2:
                        throw new Exception("No se puede Eliminar al Empleado " + _Em.Nombre + " ya que tiene solicitudes de tramites.");
                    case -3:
                        throw new Exception("Error al eliminar al empleado " + _Em.Nombre);                    
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
        }

        public static Empleado Login(int _Cedula, string _Contrasenia) 
        {
            Empleado _Em = null;
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_LoginEmpleado", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Cedula", _Cedula);
            _Cmd.Parameters.AddWithValue("@Contrasenia", _Contrasenia);
            SqlDataReader _Lector;

            try
            {
                _Cnn.Open();
                _Lector = _Cmd.ExecuteReader();

                if (_Lector.HasRows)
                {
                    _Lector.Read();
                     string _Nombre_Empleado = (string)_Lector["Nombre_Empleado"];

                    _Em = new Empleado(_Cedula, _Nombre_Empleado, _Contrasenia);
                    return _Em;
                }
                _Lector.Close();

            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
            return _Em;
        }

        internal static Empleado Buscar(string _Nombre_Entidad)
        {
            throw new NotImplementedException();
        }
    }
}
