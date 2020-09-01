/*
 *******************************************************************************************
  PROGRAMA				: DAOAdjuntar_archivos_act.cs
  FECHA DE CREACION	    : 13-05-2014
  FECHA DE MODIFICACION : 07-09-2017
  VERSION               : 1.0
  AUTOR                 : Gustavo Adolfo Caicedo Viveros

 *******************************************************************************************

  CLASE			        : DAOAdjuntar_archivos_act.cs
  RESPONSABILIDAD	    : Se encarga de las consultas en la BD de los archivos adjuntos
  COLABORACION		    : Jose Miguel Acosta I.
 ********************************************************************************************
*/


using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.adjuntar_archivos_act;


namespace com.GACV.lgb.persistencia.dao
{
    public class DAOAdjuntar_archivos_act
    {
        private string cliente;
     
        /// Método constructor de la clase       
        public DAOAdjuntar_archivos_act()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        #region ACTIVIDAD_ARCHIVO_MM

            public DataSet consultar_actividad_archivos(Adjuntar_archivos_act adjuntar_archivos, int opcion)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlConnection con;
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                    con.Open();
                    
                    SqlCommand Command = new SqlCommand("SP_CONSULTAR_ACTIVIDAD_ARCHIVO", con);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Connection = con;

                    Command.Parameters.Add("@P_ID_ACTIVIDAD_ARCHIVO", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO;

                    Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD"].Value = adjuntar_archivos.P_ID_ACTIVIDAD;

                    Command.Parameters.Add("@P_ID_TIPO_ACTIVIDAD_ARCHIVO", DbType.Int32);
                    Command.Parameters["@P_ID_TIPO_ACTIVIDAD_ARCHIVO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_TIPO_ACTIVIDAD_ARCHIVO"].Value = adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO;

                    Command.Parameters.Add("@P_FECHA_EXPEDICION", DbType.String);
                    Command.Parameters["@P_FECHA_EXPEDICION"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_FECHA_EXPEDICION"].Value = adjuntar_archivos.P_FECHA_EXPEDICION;

                    Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_DIA;

                    Command.Parameters.Add("@P_ID_SRC", DbType.Int32);
                    Command.Parameters["@P_ID_SRC"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_SRC"].Value = adjuntar_archivos.P_ID_SRC;

                    Command.Parameters.Add("@P_OPCION", DbType.Int32);
                    Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_OPCION"].Value = opcion;

                    DataAdapter.SelectCommand = Command;
                    DataAdapter.Fill(ds);
                    con.Close();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                }

                return ds;
            }

        public DataSet consultar_actividad_archivos_obligatorios(Adjuntar_archivos_act adjuntar_archivos, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_DOCUMENTOS_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_TIPO_ARCHIVO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_TIPO_ARCHIVO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_TIPO_ARCHIVO"].Value = adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int Administrar_actividad_archivos(Adjuntar_archivos_act adjuntar_archivos, int opcion)
            {
                int valor = 0;

                try
                {
                    SqlConnection con;
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                    con.Open();

                    SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_ARCHIVO", con);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Connection = con;

                    Command.Parameters.Add("@P_ID_ACTIVIDAD_ARCHIVO", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO;

                    Command.Parameters.Add("@P_NOMBRE_ARCHIVO", DbType.String);
                    Command.Parameters["@P_NOMBRE_ARCHIVO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_NOMBRE_ARCHIVO"].Value = adjuntar_archivos.P_NOMBRE_ARCHIVO;

                    Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD"].Value = adjuntar_archivos.P_ID_ACTIVIDAD;

                    Command.Parameters.Add("@P_ID_TIPO_ACTIVIDAD_ARCHIVO", DbType.Int32);
                    Command.Parameters["@P_ID_TIPO_ACTIVIDAD_ARCHIVO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_TIPO_ACTIVIDAD_ARCHIVO"].Value = adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO;

                    Command.Parameters.Add("@P_FECHA_EXPEDICION", DbType.String);
                    Command.Parameters["@P_FECHA_EXPEDICION"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_FECHA_EXPEDICION"].Value = adjuntar_archivos.P_FECHA_EXPEDICION;

                    Command.Parameters.Add("@P_URL_ARCHIVO", DbType.String);
                    Command.Parameters["@P_URL_ARCHIVO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_URL_ARCHIVO"].Value = adjuntar_archivos.P_URL_ARCHIVO;

                    Command.Parameters.Add("@P_EXTENSION", DbType.String);
                    Command.Parameters["@P_EXTENSION"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_EXTENSION"].Value = adjuntar_archivos.P_EXTENSION;

                    Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                    Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_USUARIO_CREACION"].Value = adjuntar_archivos.P_USUARIO_CREACION;

                    Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                    Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_USUARIO_MODIFICA"].Value = adjuntar_archivos.P_USUARIO_MODIFICA;

                    Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_DIA;

                    Command.Parameters.Add("@P_ID_ACTIVIDAD_ARCHIVO_ESTADO", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO_ESTADO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO_ESTADO"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO;


                    Command.Parameters.Add("@P_ID_ACTIVIDAD_ARCHIVO_DETALLE", DbType.Int32);
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO_DETALLE"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_ACTIVIDAD_ARCHIVO_DETALLE"].Value = adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_DETALLE;

                    Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                    Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_ID_MUNICIPIO"].Value = adjuntar_archivos.P_ID_MUNICIPIO;

                    Command.Parameters.Add("@P_PERSONAS", DbType.Int32);
                    Command.Parameters["@P_PERSONAS"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_PERSONAS"].Value = adjuntar_archivos.P_PERSONAS;

                    Command.Parameters.Add("@P_DESCRIPCION", DbType.Int32);
                    Command.Parameters["@P_DESCRIPCION"].Direction = ParameterDirection.Input;
                    Command.Parameters["@P_DESCRIPCION"].Value = adjuntar_archivos.P_DESCRIPCION;


                    Command.Parameters.Add("@p_opcion", DbType.Int32);
                    Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                    Command.Parameters["@p_opcion"].Value = opcion;

                    valor = Command.ExecuteNonQuery();
                    con.Close();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //MsgBox(ex.Message);
                }

                return valor;
            }

        #endregion
    }
}