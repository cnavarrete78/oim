/*
 *******************************************************************************************
  PROGRAMA				: DAOActividad_cobertura.cs
  FECHA DE CREACION	    : 13-04-2015
  FECHA DE MODIFICACION : 
  VERSION               : 1.0
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS

 *******************************************************************************************

  CLASE			        : DAOActividad_cobertura.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : 
 ********************************************************************************************
*/

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.actividad_cobertura;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOActividad_cobertura
    {
        private string cliente;
       
        /// Método constructor de la clase       
        public DAOActividad_cobertura()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        // permite administrar la cobertura de las actividades
        public int Administrar_actividad_cobertura(Actividad_cobertura actividad_cobertura, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_COBERTURA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_COBERTURA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_COBERTURA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_COBERTURA"].Value = actividad_cobertura.P_ID_ACTIVIDAD_COBERTURA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_cobertura.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.String);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad_cobertura.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_ESTADO_ACTIVIDAD_COBERTURA", DbType.Int32);
                Command.Parameters["@P_ESTADO_ACTIVIDAD_COBERTURA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_ACTIVIDAD_COBERTURA"].Value = actividad_cobertura.P_ESTADO_ACTIVIDAD_COBERTURA;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_cobertura.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_cobertura.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }
        
        // permite consultar la actividad cobertura
        public DataSet Consulta_actividad_cobertura(Actividad_cobertura actividad_cobertura, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDAD_COBERTURA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_COBERTURA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_COBERTURA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_COBERTURA"].Value = actividad_cobertura.P_ID_ACTIVIDAD_COBERTURA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_cobertura.P_ID_ACTIVIDAD;
             
                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

    }

}