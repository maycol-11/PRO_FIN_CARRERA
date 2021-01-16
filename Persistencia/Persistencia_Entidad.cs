using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Entidades_Compartidas;
using System.Data;

namespace Persistencia
{
    public class Persistencia_Entidad
    {
        public static Entidad Buscar(string _Nombre)
        {
            string _Nombre_Entidad, _Direccion;
            Entidad _E = null;
            SqlDataReader _Lector;

            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_BuscarEntidad", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Nombre", _Nombre);            

            try
            {
                _Cnn.Open();
                _Lector = _Cmd.ExecuteReader();

                if (_Lector.HasRows)
                {
                    _Lector.Read();
                    _Nombre_Entidad = (string)_Lector["Nombre_Entidad"];
                    _Direccion = (string)_Lector["Direccion"];
                        
                    return new Entidad(_Nombre_Entidad, _Direccion, ListarTelefonos(_Nombre_Entidad));
                }
                _Lector.Close();//Siempre se cierra flujo de dato s antes de cerrar conexión. El flujo siempre se abre y hay que cerrarlo siempre
            }            
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
            return _E;
        }

        public static void Agregar(Entidad _E) 
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_AgregarEntidad", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Nombre", _E.Nombre);
            _Cmd.Parameters.AddWithValue("@Direccion", _E.Direccion);            
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
                        throw new Exception("Ya existe una Entidad con el nombre ingresado.");
                    case -2:
                        throw new Exception("Error al insertar datos en la tabla Entidad.");
                    case -3:
                        throw new Exception("Error al insertar datos en la tabla Telefonos.");
                }
                AgregarTelefono(_E);                          
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }           
        }

        public static void Modificar(Entidad _E) 
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_ModificarEntidad", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Nombre", _E.Nombre);
            _Cmd.Parameters.AddWithValue("@Direccion", _E.Direccion);
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
                        throw new Exception("No existe Entidad con el nombre " + _E.Nombre);
                    case -2:
                        throw new Exception("Error al actualizar los datos en la tabla Entidades.");
                    case -3:
                        throw new Exception("Error al actualizar los datos en la tabla Telefonos");
                    case -4:
                        throw new Exception("Ya existe el telefono ingresado para la Entidad.");
                }
                //Primero mando a eliminar los autores que hay
                EliminarTelefono(_E);
                //Segundo Actualizo con los autores que hay en el objeto
                AgregarTelefono(_E);
            }
            catch (Exception ex)//El catch captura la excepción y lo que hago es volverla a lanzar para que otro la capture
            { throw ex; }
            finally
            { _Cnn.Close(); }            
        }

        public static void Eliminar(Entidad _E) 
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_EliminarEntidad", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter _Nombre = new SqlParameter("@Nombre", _E.Nombre);
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
                        throw new Exception("No existe ninguna entidad con el nombre " + _E.Nombre);
                    case -2:
                        throw new Exception("No se puede Eliminar la entidad " + _E.Nombre + " ya que tiene solicitudes de tramites.");
                    case -3:
                        throw new Exception("Error al eliminar la entidad " + _E.Nombre);
                    case -4:
                        throw new Exception("Error al eliminar los datos de la tabla telefono.");
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }            
        }

        public static void AgregarTelefono(Entidad _E) 
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_AgregarTelefono", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Cmd.Parameters.Add(_Retorno);

            _Cmd.Parameters.AddWithValue("@Nombre", _E.Nombre);

            SqlParameter _Telefono = new SqlParameter("@Telefono", SqlDbType.VarChar, 8);
            _Cmd.Parameters.Add(_Telefono);


            try
            {
                _Cnn.Open();

                foreach (string Telefono in _E.Telefonos)
                {
                    _Telefono.Value = Telefono;
                    _Cmd.ExecuteNonQuery();

                    switch ((int)_Retorno.Value)
                    {
                        case -1:
                            throw new Exception("La entidad a la cual desea eliminar sus telefonos no existe.");
                        case -2:
                            throw new Exception("El telefono que desea ingresar ya existe.");
                        case -3:
                            throw new Exception("Error de base de datos.");
                    }
                }
            }

            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
        }

        public static void EliminarTelefono(Entidad _E)
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_EliminarTelefono", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Nombre", _E.Nombre);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Cmd.Parameters.Add(_Retorno);

            try
            {
                _Cnn.Open();
                _Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }

        }

        public static List<string> ListarTelefonos(string _Nombre)
        {
            List<string> _Telefonos = new List<string>();
            string _Telefono = "";

            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_ListarTelefonos", _Cnn);
            _Cmd.Parameters.AddWithValue("@Nombre", _Nombre);
            _Cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                _Cnn.Open();
                SqlDataReader _Lector = _Cmd.ExecuteReader();
                while (_Lector.Read())
                {
                    _Telefono = (string)_Lector["Telefono"];
                    _Telefonos.Add(_Telefono);
                }
                _Lector.Close();                
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
            return _Telefonos;
        }

        public static List<Entidad> Listar_Entidad() 
        {
            List<Entidad> listaEntidades = new List<Entidad>();
            string _Nombre_Entidad, _Direccion;
            SqlDataReader _Lector;

            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_ListarEntidad", _Cnn);

            try
            {
                _Cnn.Open();
                _Lector = _Cmd.ExecuteReader();
                while (_Lector.Read())//El read siempre me devuelve true or false, pude leer algo o no
                {
                    _Nombre_Entidad = (string)_Lector["Nombre_Entidad"];
                    _Direccion = (string)_Lector["Direccion"];
                   
                    Entidad _E = new Entidad(_Nombre_Entidad,_Direccion,ListarTelefonos(_Nombre_Entidad));
                    listaEntidades.Add(_E);
                }
                _Lector.Close();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
            return listaEntidades;
        }
    }
}
