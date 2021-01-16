using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Entidades_Compartidas;
using System.Data;

namespace Persistencia
{
    public class Persistencia_Tramite
    {
        public static Tramite Buscar(string _Codigo,string _Nombre_Entidad)
        {
            string _Nombre, _Descripcion;
            Tramite _Tr = null;
            Entidad _En = null;

            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_BuscarTramite", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Codigo", _Codigo);
            _Cmd.Parameters.AddWithValue("@Nombre_Entidad", _Nombre_Entidad);
            SqlDataReader _Lector;

            try
            {
                _Cnn.Open();
                _Lector = _Cmd.ExecuteReader();

                if (_Lector.HasRows)
                {
                    _Lector.Read();
                    
                    _Nombre = (string)_Lector["Nombre_Tramite"];
                    _Descripcion = (string)_Lector["Descripcion"];
                    _En = Persistencia_Entidad.Buscar(_Nombre_Entidad);

                    _Tr = new Tramite(_Codigo, _Nombre, _Descripcion, _En);
                }
                _Lector.Close();
            }
            catch (Exception ex)
            {   throw ex;   }
            finally
            { _Cnn.Close(); }
            return _Tr;

        }

        public static void Agregar(Tramite _Tr)
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_AgregarTramite", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Codigo", _Tr.Codigo);
            _Cmd.Parameters.AddWithValue("@Nombre_Entidad", _Tr.Entidad.Nombre);
            _Cmd.Parameters.AddWithValue("@Nombre_Tramite", _Tr.Nombre);
            _Cmd.Parameters.AddWithValue("@Descripcion", _Tr.Descripcion);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Cmd.Parameters.Add(_Retorno);

            try
            {
                _Cnn.Open();
                _Cmd.ExecuteNonQuery();

                switch ((int)_Retorno.Value)
                {
                    case -1:
                        throw new Exception("La entidad ingresada no existe.");
                    case -2:
                        throw new Exception("Ya existe un Tramite con el codigo Ingresado.");
                    case -3:
                        throw new Exception("Error al insertar datos en la tabla Tramites.");
                    case -4:
                        throw new Exception("Ya existe un Tramite con el codigo Ingresado.");
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
        }

        public static void Modificar(Tramite _Tr)
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_ModificarTramite", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Codigo", _Tr.Codigo);
            _Cmd.Parameters.AddWithValue("Nombre_Entidad", _Tr.Entidad.Nombre);
            _Cmd.Parameters.AddWithValue("@Nombre_Tramite", _Tr.Nombre);
            _Cmd.Parameters.AddWithValue("@Descripcion", _Tr.Descripcion);
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
                        throw new Exception("No existe un tramite con el codigo " + _Tr.Codigo + " para la entidad " + _Tr.Entidad.Nombre);
                    case -2:
                        throw new Exception("Error al Actualizar los datos en la tabla Tramites.");
                }                
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }            
        }

        public static void Eliminar(Tramite _Tr)
        {
            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_EliminarTramite", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Codigo", _Tr.Codigo);
            _Cmd.Parameters.AddWithValue("@Nombre", _Tr.Entidad.Nombre);
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;            
            _Cmd.Parameters.Add(_Retorno);

            try
            {
                _Cnn.Open();
                _Cmd.ExecuteNonQuery();

                switch ((int)_Retorno.Value)
                {
                    case -1:
                        throw new Exception("No existe un tramite con el codigo " + _Tr.Codigo + " para la entidad " + _Tr.Entidad.Nombre);
                    case -2:
                        throw new Exception("No se puede Eliminar el tramite " + _Tr.Codigo + " ya que tiene solicitudes de tramites.");
                    case -3:
                        throw new Exception("Error al eliminar el tramite " + _Tr.Codigo + " de la entidad " + _Tr.Entidad.Nombre);
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
        }

        public static List<Tramite> Listar_Tramite()
        {
            List<Tramite> listaTramites = new List<Tramite>();
            string _Codigo, _Nombre_Entidad, _Nombre, _Descripcion;
            Entidad _En = null;

            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_ListadoTramite", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader _Lector;

            try
            {
                _Cnn.Open();
                _Lector = _Cmd.ExecuteReader();
                while (_Lector.Read())//El read siempre me devuelve true or false, pude leer algo o no
                {
                    _Codigo = (string)_Lector["Codigo"];
                    _Nombre_Entidad = (string)_Lector["Nombre_Entidad"];
                    _Nombre = (string)_Lector["Nombre_Tramite"];
                    _Descripcion = (string)_Lector["Descripcion"];

                    _En = Persistencia_Entidad.Buscar(_Nombre_Entidad);

                    Tramite _Tr = new Tramite(_Codigo, _Nombre, _Descripcion, _En);
                    listaTramites.Add(_Tr);
                }
                _Lector.Close();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
            return listaTramites;
        }

        public static List<Tramite> Listar_Tramite_X_Entidad(Entidad _En)
        {
            List<Tramite> listaTramites = new List<Tramite>();
            string _Codigo, _Nombre, _Descripcion;
            

            SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
            SqlCommand _Cmd = new SqlCommand("sp_ListarTramiteXEntidad", _Cnn);
            _Cmd.CommandType = CommandType.StoredProcedure;
            _Cmd.Parameters.AddWithValue("@Nombre_Entidad", _En.Nombre);
            SqlDataReader _Lector;

            try
            {
                _Cnn.Open();
                _Lector = _Cmd.ExecuteReader();
                while (_Lector.Read())//El read siempre me devuelve true or false, pude leer algo o no
                {
                    _Codigo = (string)_Lector["Codigo"];                    
                    _Nombre = (string)_Lector["Nombre_Tramite"];
                    _Descripcion = (string)_Lector["Descripcion"];                    

                    Tramite _Tr = new Tramite(_Codigo, _Nombre, _Descripcion, _En);
                    listaTramites.Add(_Tr);
                }
                _Lector.Close();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { _Cnn.Close(); }
            return listaTramites;
        }
    }
}
