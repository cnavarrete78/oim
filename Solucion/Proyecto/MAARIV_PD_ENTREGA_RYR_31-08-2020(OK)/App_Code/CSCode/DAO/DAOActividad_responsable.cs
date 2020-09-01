/*
 *******************************************************************************************
  PROGRAMA				: DAOActividad_responsable.cs
  FECHA DE CREACION	    : 13-04-2015
  FECHA DE MODIFICACION : 
  VERSION               : 1.0
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS

 *******************************************************************************************

  CLASE			        : DAOActividad_responsable.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : 
 ********************************************************************************************
*/

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.actividad_responsable;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOActividad_responsable
    {
        private string cliente;
       
        /// Método constructor de la clase       
        public DAOActividad_responsable()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        public int Administrar_actividad_responsable(Actividad_responsable actividad_responsable, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_RESPONSABLE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_RESPONSABLE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_RESPONSABLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_RESPONSABLE"].Value = actividad_responsable.P_ID_ACTIVIDAD_RESPONSABLE;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_responsable.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = actividad_responsable.P_ID_USUARIO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_ROL", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_ROL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_ROL"].Value = actividad_responsable.@P_ID_ACTIVIDAD_ROL;
           
                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_responsable.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_responsable.P_USUARIO_MODIFICA;

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
        
        // permite consultar la actividad responsable
        public DataSet Consulta_actividad_responsable(Actividad_responsable actividad_responsable, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDAD_RESPONSABLE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_RESPONSABLE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_RESPONSABLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_RESPONSABLE"].Value = actividad_responsable.P_ID_ACTIVIDAD_RESPONSABLE;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_responsable.P_ID_ACTIVIDAD;
             
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