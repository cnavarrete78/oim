using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using com.GACV.lgb.modelo.ADEP;

/// <summary>
/// Descripción breve de Actividad_dia_encuesta_pregunta
/// </summary>
/// 
namespace com.GACV.lgb.DAO.ADEP
{
    public class DAOActividad_dia_encuesta_pregunta
    {
        public DAOActividad_dia_encuesta_pregunta()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public DataSet actividad_dia_encuesta_pregunta(Actividad_dia_encuesta_pregunta ADEP, int opcion)
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

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Value = ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = ADEP.F_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA", DbType.String);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO", DbType.Int32);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO", DbType.Int32);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO", DbType.Int32);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = ADEP.F_USUARIO_CREACION;

                Command.Parameters.Add("@P_FECHA_CREACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_CREACION"].Value = ADEP.F_FECHA_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICACION"].Value = ADEP.F_USUARIO_MODIFICACION;

                Command.Parameters.Add("@P_FECHA_MODIFICACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_MODIFICACION"].Value = ADEP.F_FECHA_MODIFICACION;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL"].Value = ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL;


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
        
        public DataSet actividad_dia_encuesta_material(Actividad_dia_encuesta_pregunta ADEP, int opcion)
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
              
                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL"].Value = ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Value = ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_TITULO", DbType.String);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_TITULO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_TITULO"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_TITULO;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_PARRAFO1", DbType.Int32);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PARRAFO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PARRAFO1"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PARRAFO1;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_PARRAFO2", DbType.Int32);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PARRAFO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_PARRAFO2"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PARRAFO2;

                Command.Parameters.Add("@P_URL_ARCHIVO", DbType.Int32);
                Command.Parameters["@P_URL_ARCHIVO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_URL_ARCHIVO"].Value = ADEP.F_URL_ARCHIVO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = ADEP.F_USUARIO_CREACION;

                Command.Parameters.Add("@P_FECHA_CREACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_CREACION"].Value = ADEP.F_FECHA_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICACION"].Value = ADEP.F_USUARIO_MODIFICACION;

                Command.Parameters.Add("@P_FECHA_MODIFICACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_MODIFICACION"].Value = ADEP.F_FECHA_MODIFICACION;

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

        public DataSet actividad_dia_encuesta_respuesta_utlima(Actividad_dia_encuesta_pregunta ADEP, int opcion)
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

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA"].Value = ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA", DbType.Int32);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA;

                Command.Parameters.Add("@P_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO", DbType.String);
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO"].Value = ADEP.F_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA", DbType.String);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA"].Value = ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO", DbType.String);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO"].Value = ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = ADEP.F_USUARIO_CREACION;

                Command.Parameters.Add("@P_FECHA_CREACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_CREACION"].Value = ADEP.F_FECHA_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICACION"].Value = ADEP.F_USUARIO_MODIFICACION;

                Command.Parameters.Add("@P_FECHA_MODIFICACION", DbType.DateTime);
                Command.Parameters["@P_FECHA_MODIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_MODIFICACION"].Value = ADEP.F_FECHA_MODIFICACION;

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
