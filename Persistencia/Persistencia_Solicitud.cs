using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Entidades_Compartidas;
using System.Data;

namespace Persistencia
{
     public class Persistencia_Solicitud
    {
         public static void Agregar(Solicitud _So) 
         {
             SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
             SqlCommand _Cmd = new SqlCommand("sp_AgregarSolicitud", _Cnn);
             _Cmd.CommandType = CommandType.StoredProcedure;
             _Cmd.Parameters.AddWithValue("@Nombre_Entidad", _So.Tramite.Entidad.Nombre);
             _Cmd.Parameters.AddWithValue("@Codigo", _So.Tramite.Codigo);
             _Cmd.Parameters.AddWithValue("@Fecha", _So.Fecha);
             _Cmd.Parameters.AddWithValue("@Nombre_Solicitante", _So.Nombre_Solicitante);
             _Cmd.Parameters.AddWithValue("@Cedula", _So.Empleado.Cedula);
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
                         throw new Exception("No existe tramite para realizar la solicitud.");
                     case -2:
                         throw new Exception("No existe empleado con el numero de cedula para realizar la solicitud.");
                    case -3:
                        throw new Exception("Error al insertar datos en la tabla solicitudes.");
                 }
             }
             catch (Exception ex)
             { throw ex; }
             finally
             { _Cnn.Close(); }  
         }

         public static void ModificarEstado(Solicitud _So) 
         {
             SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
             SqlCommand _Cmd = new SqlCommand("sp_ModificarSolicitud", _Cnn);
             _Cmd.CommandType = CommandType.StoredProcedure;
             _Cmd.CommandType = CommandType.StoredProcedure;
             _Cmd.Parameters.AddWithValue("@Numero_Solicitud", _So.Numero);
             _Cmd.Parameters.AddWithValue("@Estado", _So.Estado);
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
                         throw new Exception("No existe una solicitud con el Numero ingresado.");
                     case -2:
                         throw new Exception("Error al modificar el estado de la solicitu.");
                 }
             }
             catch (Exception ex)
             { throw ex; }
             finally
             { _Cnn.Close(); }  
         }

         public static List<Solicitud> ListadoFecha(DateTime _Fecha) 
         {
             List<Solicitud> listaSolicitudes = new List<Solicitud>();
             string _Nombre_Entidad, _Nombre_Solicitante, _Codigo, _Estado;
             int _Numero_Solicitud, _Cedula;             

             Empleado _Em = null;
             Tramite _Tr = null;

             SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
             SqlCommand _Cmd = new SqlCommand("sp_ListadoSolicitudesFecha", _Cnn);
             _Cmd.CommandType = CommandType.StoredProcedure;
             _Cmd.Parameters.AddWithValue("@Fecha", _Fecha);
             SqlDataReader _Lector;

             try
             {
                 _Cnn.Open();
                 _Lector = _Cmd.ExecuteReader();
                 while (_Lector.Read())//El read siempre me devuelve true or false, pude leer algo o no
                 {
                     _Numero_Solicitud = (int)_Lector["Numero_Solicitud"];
                     _Nombre_Entidad = (string)_Lector["Nombre_Entidad"];
                     _Fecha = (DateTime)_Lector["Fecha"];
                     _Codigo = (string)_Lector["Codigo"];                     
                     _Nombre_Solicitante = (string)_Lector["Nombre_Solicitante"];
                     _Cedula = (int)_Lector["Cedula"];
                     _Estado = (string)_Lector["Estado"];

                     _Em = Persistencia_Empleado.Buscar(_Cedula);
                     _Tr = Persistencia_Tramite.Buscar(_Codigo, _Nombre_Entidad);

                     Solicitud _So = new Solicitud(_Numero_Solicitud, _Fecha, _Estado, _Nombre_Solicitante, _Tr, _Em);
                     listaSolicitudes.Add(_So);
                 }
                 _Lector.Close();
             }
             catch (Exception ex)
             { throw ex; }
             finally
             { _Cnn.Close(); }
             return listaSolicitudes;
         }

         public static Solicitud Buscar(int _Numero_Solicitud) 
         {
             Solicitud _So = null;

             SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
             SqlCommand _Cmd = new SqlCommand("sp_BuscarSolicitud", _Cnn);
             _Cmd.CommandType = CommandType.StoredProcedure;
             _Cmd.Parameters.AddWithValue("@Numero_Solicitud", _Numero_Solicitud);
             SqlDataReader _Lector;

             try 
             {
                 _Cnn.Open();
                 _Lector = _Cmd.ExecuteReader();

                 if (_Lector.HasRows)
                 {
                     _Lector.Read();
                     _Numero_Solicitud = (int)_Lector["Numero_Solicitud"];
                     DateTime _Fecha = (DateTime)_Lector["Fecha"];
                     string _Estado = (string)_Lector["Estado"];
                     string _Nombre_Entidad = (string)_Lector["Nombre_Entidad"];
                     string _Nombre_Solicitante = (string)_Lector["Nombre_Solicitante"];
                     int _Cedula = (int)_Lector["Cedula"];
                     string _Codigo = (string)_Lector["Codigo"];

                     Empleado _Em = Persistencia_Empleado.Buscar(_Cedula);
                     Tramite _Tr = Persistencia_Tramite.Buscar(_Codigo, _Nombre_Entidad);

                     _So = new Solicitud(_Numero_Solicitud, _Fecha, _Estado, _Nombre_Solicitante, _Tr, _Em);
                 }
                 _Lector.Close();
             }
             catch (Exception ex)
             { throw ex; }
             finally
             { _Cnn.Close(); }
             return _So;
         }

         public static List<Solicitud> ListarSolicitudAlta() 
         {
             List<Solicitud> solicitudAlta = new List<Solicitud>();
             Solicitud _So = null;
             Tramite _Tr = null;
             Empleado _Em = null;

             SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
             SqlCommand _Cmd = new SqlCommand("sp_ListarSolicitudAlta", _Cnn);
             _Cmd.CommandType = CommandType.StoredProcedure;
             SqlDataReader _Lector;
             try 
             {
                 _Cnn.Open();
                 _Lector = _Cmd.ExecuteReader();
                 while (_Lector.Read())
                 {
                     int _Numero_Solicitud = (int)_Lector["Numero_Solicitud"];
                     DateTime _Fecha = (DateTime)_Lector["Fecha"];
                     string _Estado = (string)_Lector["Estado"];
                     string _Nombre_Entidad = (string)_Lector["Nombre_Entidad"];
                     string _Nombre_Solicitante = (string)_Lector["Nombre_Solicitante"];
                     int _Cedula = (int)_Lector["Cedula"];
                     string _Codigo = (string)_Lector["Codigo"];

                     _Em = Persistencia_Empleado.Buscar(_Cedula);
                     _Tr = Persistencia_Tramite.Buscar(_Codigo, _Nombre_Entidad);

                     _So = new Solicitud(_Numero_Solicitud, _Fecha, _Estado, _Nombre_Solicitante, _Tr, _Em);
                     solicitudAlta.Add(_So);
                 }
                 _Lector.Close();
             }
             catch (Exception ex)
             { throw ex; }
             finally
             { _Cnn.Close(); }
             return solicitudAlta;
         }

         public static List<Solicitud> ListarSolicitud(string _Codigo, string _Estado)
         {
             List<Solicitud> lista = new List<Solicitud>();
             Solicitud _So = null;
             Empleado _Em = null;
             Tramite _Tr = null;
             SqlConnection _Cnn = new SqlConnection(Constantes.CONEXION);
             SqlCommand _Cmd = new SqlCommand("sp_ListarSolicitud", _Cnn);
             _Cmd.CommandType = CommandType.StoredProcedure;
             _Cmd.Parameters.AddWithValue("@Codigo", _Codigo);
             _Cmd.Parameters.AddWithValue("@Estado", _Estado);
             SqlDataReader _Lector;

             try 
             {
                 _Cnn.Open();
                 _Lector = _Cmd.ExecuteReader();
                 while (_Lector.Read())
                 {
                     int _Numero_Solicitud = (int)_Lector["Numero_Solicitud"];
                     DateTime _Fecha = (DateTime)_Lector["Fecha"];
                     _Estado = (string)_Lector["Estado"];
                     string _Nombre_Entidad = (string)_Lector["Nombre_Entidad"];
                     string _Nombre_Solicitante = (string)_Lector["Nombre_Solicitante"];
                     int _Cedula = (int)_Lector["Cedula"];
                     _Codigo = (string)_Lector["Codigo"];

                     _Em = Persistencia_Empleado.Buscar(_Cedula);
                     _Tr = Persistencia_Tramite.Buscar(_Codigo, _Nombre_Entidad);

                     _So = new Solicitud(_Numero_Solicitud, _Fecha, _Estado, _Nombre_Solicitante, _Tr, _Em);
                     lista.Add(_So);
                 }
                 _Lector.Close();
             }
             catch (Exception ex) { throw ex; }
             finally { _Cnn.Close(); }
             return lista;
         }
    }
}
