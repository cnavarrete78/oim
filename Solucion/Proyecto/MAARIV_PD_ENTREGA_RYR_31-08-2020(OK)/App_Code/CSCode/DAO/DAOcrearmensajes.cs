/*
 *******************************************************************************************
  PROGRAMA				: DAOEntrega_cartas.cs
  FECHA DE CREACION	    : Julio 29 de 2013
  FECHA DE MODIFICACION : Abril 01 de 2020
  VERSION               : 1.1
  AUTOR                 : Jose Miguel Acosta I

 *******************************************************************************************

  CLASE			        : DAOEntrega_cartas.cs
  RESPONSABILIDAD	    : se encarga de hacerl las consultas nesesarias  :/
  COLABORACION		    : Alejandro Moreno
 ********************************************************************************************
*/


using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.crear_mensajes;

//using Microsoft.Practices.EnterpriseLibrary.Data;
//using System.Data.OracleClient;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOcrearmensajes
    {
        private string cliente;
        // PJMasterPage.Class.Radicados ObjRadicado;

        /// Método constructor de la clase       
        public DAOcrearmensajes()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }


        public int Administrar_creacion_mensajes(creacion_mensajes mensajes, int opcion)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_MENSAJES_POPUP", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_MENSAJE", DbType.String);
                Command.Parameters["@P_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_MENSAJE"].Value = mensajes.P_MENSAJE;

                Command.Parameters.Add("@P_DEPENDENCIA", DbType.String);
                Command.Parameters["@P_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DEPENDENCIA"].Value = mensajes.P_DEPENDENCIA;

                Command.Parameters.Add("@P_USUARIO", DbType.Int32);
                Command.Parameters["@P_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO"].Value = mensajes.P_USUARIO;

                Command.Parameters.Add("@P_FECHA_DE_INGRESO", DbType.String);
                Command.Parameters["@P_FECHA_DE_INGRESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_DE_INGRESO"].Value = mensajes.P_FECHA_DE_INGRESO;

                Command.Parameters.Add("@P_ID_TIPO_MENSAJE", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_MENSAJE"].Value = mensajes.P_ID_TIPO_MENSAJE;

                Command.Parameters.Add("@P_TIPO_MENSAJE", DbType.String);
                Command.Parameters["@P_TIPO_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIPO_MENSAJE"].Value = mensajes.P_TIPO_MENSAJE;

                Command.Parameters.Add("@P_URL_IMAGEN", DbType.String);
                Command.Parameters["@P_URL_IMAGEN"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_URL_IMAGEN"].Value = mensajes.P_URL_IMAGEN;



                valor = Command.ExecuteNonQuery();
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return valor;
        }

        public DataSet Buscar_mensajes()
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_MENSAJES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return ds;
        }

        public DataSet Buscar_mensajes(creacion_mensajes mensajes)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_MENSAJES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = mensajes.P_USUARIO;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return ds;
        }
        
        public DataSet buscar_mensajes_fecha(creacion_mensajes mensajes)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_BUSCAR_MENSAJES_POPUP", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;



                Command.Parameters.Add("@P_FECHA_DE_INGRESO", DbType.String);
                Command.Parameters["@P_FECHA_DE_INGRESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_DE_INGRESO"].Value = mensajes.P_FECHA_DE_INGRESO;

                Command.Parameters.Add("@P_DEPENDENCIA", DbType.String);
                Command.Parameters["@P_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DEPENDENCIA"].Value = mensajes.P_DEPENDENCIA;

                Command.Parameters.Add("@P_USUARIO", DbType.Int32);
                Command.Parameters["@P_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO"].Value = mensajes.P_USUARIO;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return ds;
        }
        
        public DataSet buscar_mensajes_fecha_grilla(creacion_mensajes mensajes)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_BUSCAR_MENSAJES_POPUP_GRILLA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_USUARIO", DbType.Int32);
                Command.Parameters["@P_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO"].Value = mensajes.P_USUARIO;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return ds;
        }
         
        public int Administrar_calificacion(creacion_mensajes mensajes, int opcion)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_CALIFICACIONES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_MENSAJES", DbType.String);
                Command.Parameters["@P_ID_MENSAJES"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MENSAJES"].Value = mensajes.P_ID_MENSAJES;

                Command.Parameters.Add("@P_CALIFICACION_TEXT", DbType.String);
                Command.Parameters["@P_CALIFICACION_TEXT"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CALIFICACION_TEXT"].Value = mensajes.P_CALIFICACION_TEXT;

                Command.Parameters.Add("@P_USUARIO", DbType.Int32);
                Command.Parameters["@P_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO"].Value = mensajes.P_USUARIO;

                Command.Parameters.Add("@P_ID_TIPO_MENSAJE", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_MENSAJE"].Value = mensajes.P_ID_TIPO_MENSAJE;


                valor = Command.ExecuteNonQuery();
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return valor;
        }

        public DataSet Administrar_pop_up(creacion_mensajes mensajes, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_MENSAJES_POPUP", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_MENSAJE", DbType.String);
                Command.Parameters["@P_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_MENSAJE"].Value = mensajes.P_MENSAJE;

                Command.Parameters.Add("@P_DEPENDENCIA", DbType.String);
                Command.Parameters["@P_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DEPENDENCIA"].Value = mensajes.P_DEPENDENCIA;

                Command.Parameters.Add("@P_USUARIO", DbType.Int32);
                Command.Parameters["@P_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO"].Value = mensajes.P_USUARIO;

                Command.Parameters.Add("@P_FECHA_DE_INGRESO", DbType.String);
                Command.Parameters["@P_FECHA_DE_INGRESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_DE_INGRESO"].Value = mensajes.P_FECHA_DE_INGRESO;

                Command.Parameters.Add("@P_ID_TIPO_MENSAJE", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_MENSAJE"].Value = mensajes.P_ID_TIPO_MENSAJE;

                Command.Parameters.Add("@P_TIPO_MENSAJE", DbType.String);
                Command.Parameters["@P_TIPO_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIPO_MENSAJE"].Value = mensajes.P_TIPO_MENSAJE;

                Command.Parameters.Add("@P_URL_IMAGEN", DbType.String);
                Command.Parameters["@P_URL_IMAGEN"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_URL_IMAGEN"].Value = mensajes.P_URL_IMAGEN;

                Command.Parameters.Add("@P_opcion", DbType.Int32);
                Command.Parameters["@P_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_opcion"].Value = opcion;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return ds;
        }

    }
    
}