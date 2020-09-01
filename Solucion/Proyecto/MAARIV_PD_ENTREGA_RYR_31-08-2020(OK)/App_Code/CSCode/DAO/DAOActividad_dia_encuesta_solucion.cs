using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using com.GACV.lgb.modelo.ADES;

/// <summary>
/// Descripción breve de DAOActividad_dia_encuesta_solucion
/// </summary>
namespace com.GACV.lgb.DAO.ADES 
{
    public class DAOActividad_dia_encuesta_solucion
    {
	    public DAOActividad_dia_encuesta_solucion()
	    {
		    //
		    // TODO: Agregar aquí la lógica del constructor
		    //
	    }

        public DataSet actividad_dia_encuesta_solucion(Actividad_dia_encuesta_solucion ADES, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_DIA_ENCUESTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = ADES.F_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION", DbType.String);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = ADES.F_USUARIO_CREACION;

                Command.Parameters.Add("@P_FECHA_CREACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_CREACION"].Value = ADES.F_FECHA_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICACION"].Value = ADES.F_USUARIO_MODIFICACION;

                Command.Parameters.Add("@P_FECHA_MODIFICACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_MODIFICACION"].Value = ADES.F_FECHA_MODIFICACION;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

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

        public DataSet consulta_act_dia_encuesta_solucion(Actividad_dia_encuesta_solucion ADES, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_ACTIVIDAD_DIA_ENCUESTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = ADES.F_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION", DbType.String);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = ADES.F_USUARIO_CREACION;

                Command.Parameters.Add("@P_FECHA_CREACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_CREACION"].Value = ADES.F_FECHA_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICACION"].Value = ADES.F_USUARIO_MODIFICACION;

                Command.Parameters.Add("@P_FECHA_MODIFICACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_MODIFICACION"].Value = ADES.F_FECHA_MODIFICACION;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

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


        public DataSet administrar_acti_dia_encuesta_solucion(Actividad_dia_encuesta_solucion ADES, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_DIA_ENCUESTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = ADES.F_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION", DbType.String);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION"].Value = ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION;

                Command.Parameters.Add("@P_USUARIO_INTERACCION", DbType.Int32);
                Command.Parameters["@P_USUARIO_INTERACCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_INTERACCION"].Value = ADES.F_USUARIO_INTERACCION;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

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