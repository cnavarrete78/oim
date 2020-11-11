using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOComunitario
    {
        private string cliente;
        public DAOComunitario()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];

        }
        public DataSet Get_Comunidad(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_CARACTERIZACION_COMUNIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public void Set_Comunidad(List<SqlParameter> Parametros)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_SET_TB_CARACTERIZACION_COMUNIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);
                Command.ExecuteNonQuery();

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
        }

        public void Set_Personas_Comunidad(List<SqlParameter> Parametros)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_SET_PERSONAS_COMUNIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);
                Command.ExecuteNonQuery();

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
        }

        public DataSet Get_Personas_Comunidad(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PERSONAS_COMUNIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet Get_Personas_Detalle_Comunidad(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PERSONAS_DETALLE_COMUNIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }


        public DataSet Get_Plan_RyR(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet Get_Personas_Comunidad_Plan_RyR(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PERSONAS_COMUNIDAD_PLAN_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet Get_Personas_Detalle_Comunidad_Plan_RyR(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PERSONAS_DETALLE_COMUNIDAD_PLAN_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }
        public DataSet Get_Estado_Plan_RyR()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ESTADO_PLAN_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet Get_Entorno()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_ENTORNOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet Get_Clasificacion_Actividad()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_CLASIFICACION_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public void Set_Plan_RyR(List<SqlParameter> Parametros)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_SET_TB_PLAN_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);
                Command.ExecuteNonQuery();

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
        }

        public DataSet Get_Necesidades_Comunidad(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PLAN_RYR_TB_DERECHO_NECESIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public void Set_Necesidad_Comunidad(List<SqlParameter> Parametros)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_SET_PLAN_RYR_TB_DERECHO_NECESIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);
                Command.ExecuteNonQuery();

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
        }

        public DataSet Get_Evidencia(List<SqlParameter> Parametros)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_EVIDENCIAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public void Set_Evidencia(List<SqlParameter> Parametros)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_SET_TB_EVIDENCIAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);
                Command.ExecuteNonQuery();

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
        }

        public DataSet Get_BienesServicios_Comunidad(List<SqlParameter> Parametros)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_RYR_BIEN_SERVICIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public void Set_BienesServicios_Comunidad(List<SqlParameter> Parametros)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_SET_TB_PLAN_RYR_BIEN_SERVICIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);
                Command.ExecuteNonQuery();

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
        }

        public DataSet Get_ActividadBienesServicios_Comunidad(List<SqlParameter> Parametros)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_RYR_BIEN_SERVICIO_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public void Set_ActividadBienesServicios_Comunidad(List<SqlParameter> Parametros)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_SET_TB_PLAN_RYR_BIEN_SERVICIO_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                if (Parametros != null)
                    foreach (SqlParameter param in Parametros)
                        Command.Parameters.Add(param);
                Command.ExecuteNonQuery();

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
        }


        #region Desarrollo ruta comunitaria para el plan de traslado y balance
        public DataSet LD_PlanTrasladoPorComunidad(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_TB_PLAN_ACCION_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_Entidades_Ruta_Comunitaria()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_ENTIDADES", con);
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
        public int LD_Insertar_plan_acción_traslado_Ruta_Comunitaria(int idComunidad, int id_MunSalida, int idMunLlegada, int idEntornoSalida, int idEntornoLlegada, string corregimmientoSalida, string corregimientoLlegada, DateTime fechaInicio, DateTime fechaLlegada, int idUsuario)
        {
            int idPlanTraslado = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);
                SqlParameter oParam4 = new SqlParameter("@ID_MUNICIPIO_SALIDA", id_MunSalida);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);
                SqlParameter oParam5 = new SqlParameter("@ID_MUNICIPIO_LLEGADA", idMunLlegada);
                oParam5.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam5);
                SqlParameter oParam6 = new SqlParameter("@ID_ENTORNO_SALIDA", idEntornoSalida);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);
                SqlParameter oParam7 = new SqlParameter("@ID_ENTORNO_LLEGADA", idEntornoLlegada);
                oParam7.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam7);
                SqlParameter oParam8 = new SqlParameter("@CORREGIMIENTO_SALIDA", corregimmientoSalida);
                oParam8.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam8);
                SqlParameter oParam9 = new SqlParameter("@CORREGIMIENTO_LLEGADA", corregimientoLlegada);
                oParam9.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam9);
                SqlParameter oParam10 = new SqlParameter("@FECHA_INICIO_TRASLADO", fechaInicio);
                oParam10.SqlDbType = SqlDbType.Date;
                Command.Parameters.Add(oParam10);
                SqlParameter oParam11 = new SqlParameter("@FECHA_LLEGADA", fechaLlegada);
                oParam11.SqlDbType = SqlDbType.Date;
                Command.Parameters.Add(oParam11);



                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                SqlParameter OutputParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", SqlDbType.Int);
                OutputParam.Direction = ParameterDirection.Output;
                Command.Parameters.Add(OutputParam);
                Command.ExecuteNonQuery();

                idPlanTraslado = Convert.ToInt32(Command.Parameters["@ID_PLAN_ACCION_TRASLADO"].Value);

                con.Close();
                return idPlanTraslado;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return idPlanTraslado;
        }
        public bool LD_Actualizar_plan_acción_traslado_para_balance_Ruta_Comunitaria(int idComunidad, int idPlan, int idDt, string profesional, string correo, DateTime fechaSSV, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_PARA_EL_BALANCE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);
                SqlParameter oParam4 = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);
                SqlParameter oParam5 = new SqlParameter("@ID_DT_BALANCE", idDt);
                oParam5.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam5);
                SqlParameter oParam6 = new SqlParameter("@PROFESIONAL_ELABORA_LISTADO_BALANCE", profesional);
                oParam6.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam6);
                SqlParameter oParam7 = new SqlParameter("@CORREO_PROFESIONAL_ELABORA_LISTADO_BALANCE", correo);
                oParam7.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam7);
                SqlParameter oParam8 = new SqlParameter("@FECHA_MEDICION_SSV", fechaSSV);
                oParam8.SqlDbType = SqlDbType.Date;
                Command.Parameters.Add(oParam8);
                SqlParameter oParamIdUsuario = new SqlParameter("ID_USUARIO_BALANCE", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);
                Command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return false;
            }
        }
        public bool LD_Insertar_plan_acción_traslado_entidad_ruta_comunitaria(int idPlan, int idEntidad, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_TB_PLAN_ACCION_TRASLADO_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Eliminar_plan_acción_traslado_entidad_ruta_comunitaria(int idPlan, int idEntidad)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);
                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Insertar_plan_acción_traslado_categoria_ruta_comunitaria(int idCategoria, int idPlan, int idComuidad, string resultado, string acciones, string observaciones, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_CATEGORIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam0 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam0.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam0);

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComuidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@RESULTADO", resultado);
                oParam2.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ACCIONES", acciones);
                oParam3.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@OBSERVACIONES", observaciones);
                oParam4.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam4);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Insertar_plan_acción_traslado_Categorizacion_entidad_ruta_comunitaria(int idPlan, int idEntidad, int idCategoria, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_TB_PLAN_ACCION_TRASLADO_CATEGORIA_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);


                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Eliminar_plan_acción_traslado_caracterizacion_entidad_ruta_comunitaria(int idPlan, int idEntidad, int idCategoria)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_CATEGORIA_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public DataSet LD_Consultar_plan_acción_traslado_categorias_Entidad_Ruta_Comunitaria(int idPlan, int idCategoria)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_CATEGORIA_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam2 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

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
        public bool LD_Insertar_plan_acción_traslado_balance_traslado_ruta_comunitaria(int id, int idPlan, int idComuidad, string actividad, string responsable, bool cumplida, string observaciones, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComuidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ACTIVIDAD", actividad);
                oParam2.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@RESPONSABLE", responsable);
                oParam3.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@CUMPLIDA", cumplida);
                oParam4.SqlDbType = SqlDbType.Bit;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@OBSERVACIONES", observaciones);
                oParam5.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam5);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Eliminar_plan_acción_traslado_balance_traslado_Ruta_Comunitaria(int id)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID", id);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Eliminar_plan_acción_traslado_profesionales_traslado_Ruta_Comunitaria(int id)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_PROFESIONALES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID", id);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Insertar_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(int id, int idPlan, int idComuidad, string profesional, int idEntidad, string telefono, string correo, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_PROFESIONALES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComuidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@PROFESIONAL", profesional);
                oParam2.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@TELEFONO", telefono);
                oParam4.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@CORREO_ELECTRONICO", correo);
                oParam5.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam5);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Insertar_plan_acción_traslado_alistamiento_traslado_ruta_comunitaria(int id, int idPlan, int idComunidad, DateTime fechaRegistro, int idMunicipio, string direccion, int idDt, int idEntidad, string profesional, string correo, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_ALISTAMIENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@FECHA_REGISTRO", fechaRegistro);
                oParam2.SqlDbType = SqlDbType.Date;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ID_DIRECCION_TERRITORIAL", idDt);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@ID_MUNICIPIO", idMunicipio);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@DIRECCION", direccion);
                oParam5.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                SqlParameter oParam7 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam7.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam7);

                SqlParameter oParam8 = new SqlParameter("@PROFESIONAL_REGISTRO", profesional);
                oParam8.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam8);

                SqlParameter oParam9 = new SqlParameter("@CORREO_ELECTRONICO", correo);
                oParam9.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam9);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Insertar_plan_acción_traslado_inventario_hogar_ruta_comunitaria(int id, int idPlan, int idComunidad, int idHogar, int estufas, int neveras, int utenciliosCocina, int camas, int colchones, int cobijas, int sofas, int sillas, int mesas, int equiposSonido, int juguetes, int bicicletas, int motos, int tulas, int peso, bool rotulacion, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_INVENTARIO_HOGAR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_HOGAR", idHogar);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ESTUFAS", estufas);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@NEVERAS", neveras);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@UTENCILIOS_COCINA", utenciliosCocina);
                oParam5.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                SqlParameter oParam7 = new SqlParameter("@CAMAS", camas);
                oParam7.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam7);

                SqlParameter oParam8 = new SqlParameter("@COLCHONES", colchones);
                oParam8.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam8);

                SqlParameter oParam9 = new SqlParameter("@SOFAS", sofas);
                oParam9.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam9);

                SqlParameter oParam10 = new SqlParameter("@SILLAS", sillas);
                oParam10.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam10);

                SqlParameter oParam11 = new SqlParameter("@MESAS", mesas);
                oParam11.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam11);

                SqlParameter oParam12 = new SqlParameter("@EQUIPOS_DE_SONIDO", equiposSonido);
                oParam12.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam12);

                SqlParameter oParam13 = new SqlParameter("@JUGUTES_ROPA", juguetes);
                oParam13.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam13);

                SqlParameter oParam14 = new SqlParameter("@BICICLETAS", bicicletas);
                oParam14.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam14);

                SqlParameter oParam15 = new SqlParameter("@MOTOS", motos);
                oParam15.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam15);

                SqlParameter oParam16 = new SqlParameter("@TULAS", tulas);
                oParam16.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam16);

                SqlParameter oParam17 = new SqlParameter("@PESO", peso);
                oParam17.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam17);

                SqlParameter oParam18 = new SqlParameter("@ROTULACION", rotulacion);
                oParam18.SqlDbType = SqlDbType.Bit;
                Command.Parameters.Add(oParam18);

                SqlParameter oParam19 = new SqlParameter("@COBIJAS", cobijas);
                oParam19.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam19);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);


                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public DataSet LD_Consultar_plan_acción_traslado_Ruta_Comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_Consultar_plan_acción_traslado_Entidad_Ruta_Comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_Consultar_Categoria_plan_acción_traslado_Ruta_Comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_CATEGORIA_TRASLADO_POR_ID_PLAN_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_Consultar_Tipo_Evidencia()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_TB_TIPO_EVIDENCIA", con);
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
        public DataSet LD_plan_acción_traslado_balance_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_PROFESIONALES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_ALISTAMIENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_plan_acción_traslado_Inventario_hogar_ruta_comunitaria(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_INVENTARIO_HOGAR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_plan_acción_traslado_Inventario_hogar_enseres_ruta_comunitaria(int idHogar)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_INVENTARIO_HOGAR_ENSERES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_HOGAR", idHogar);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet Get_Persona_Plan_Accion_Traslado_por_numero_documento(string numDocumetno)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_BUSQUEDA_PERSONA_POR_NUMERO_DOCUMENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@NUMERO_DOCUMENTO", numDocumetno);
                oParam.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam);

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
        public bool LD_Modificar_Persona_trasladar_plan_acción_traslado_ruta_comunitaria(int idPlan, int idComunidad, int idPersona, bool seTraslada, string motivo, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_PERSONA_NO_TRASLADA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_PERSONA", idPersona);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@MOTIVO", motivo);
                oParam3.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@SETRASLADA", seTraslada);
                oParam4.SqlDbType = SqlDbType.Bit;
                Command.Parameters.Add(oParam4);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public DataSet LD_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PERSONAS_NO_SE_TRASLADAN", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_Personas_SI_se_trasladan_plan_acción_traslado_ruta_comunitaria(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PERSONAS_SI_SE_TRASLADAN", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public bool LD_Insertar_plan_acción_traslado_balance_evidencia_traslado_ruta_comunitaria(int id, string opcion, int idRelacion, int idTipoEvidencia, string urlArchivo, string nombreArchivo, string extension, int idUsuario, bool activo)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO_EVIDENCIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID", id);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParamOp = new SqlParameter("@OPCION", opcion);
                oParamOp.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParamOp);

                SqlParameter oParam1 = new SqlParameter("@ID_RELACION", idRelacion);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_TIPO_EVIDENCIA", idTipoEvidencia);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@URL_ARCHIVO", urlArchivo);
                oParam3.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@EXTENSION", extension);
                oParam4.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@ACTIVO", activo);
                oParam5.SqlDbType = SqlDbType.Bit;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@NOMBRE_ARCHIVO", nombreArchivo);
                oParam6.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam6);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public DataSet Get_Plan_Accion_Traslado_balance_evidencia(int idRelacion, string opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO_EVIDENCIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_RELACION", idRelacion);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);
                SqlParameter oParamOp = new SqlParameter("@OPCION", opcion);
                oParamOp.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParamOp);

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
        public DataSet LD_Consultar_Balance_traslado_derechos_Ruta_Comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_BALANCE_TRASLADO_TB_DERECHO_NECESIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

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
        public DataSet LD_Consultar_Balance_Metas_Ruta_Comunitaria(int idComunidad, string opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_BALANCE_METAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParamOp = new SqlParameter("@OPCION", opcion);
                oParamOp.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParamOp);


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
        public bool LD_Insertar_plan_acción_traslado_balance_bien_servicio_ruta_comunitaria(int idPlanBienServicio, int victimasAcompanadasD, int victimasAcompanadasI, int totalVictimas, int totalNoVictimas, int personasBeneficiadas, string descripcion, string responsable, decimal costo, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_BALANCE_TRASLADO_PLAN_RYR_BIEN_SERVICIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParamOp = new SqlParameter("@ID_PLAN_RYR_BIEN_SERVICIO", idPlanBienServicio);
                oParamOp.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamOp);

                SqlParameter oParam1 = new SqlParameter("@VICTIMAS_ACOMPANADAS_DIRECTAMENTE", victimasAcompanadasD);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@VICTIMAS_ACOMPANADAS_INDIRECTAMENTE", victimasAcompanadasI);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@TOTAL_VICTIMAS_BENEFICIADAS", totalVictimas);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@PERSONAS_NO_VICTIMAS_BENEFICIADAS", totalNoVictimas);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@PERSONAS_BENEFICIADAS", personasBeneficiadas);
                oParam5.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@DESCRIPCION", descripcion);
                oParam6.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam6);

                SqlParameter oParam7 = new SqlParameter("@RESPONSABLE", responsable);
                oParam7.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam7);

                SqlParameter oParam9 = new SqlParameter("@COSTO", costo);
                oParam9.SqlDbType = SqlDbType.Money;
                Command.Parameters.Add(oParam9);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Insertar_plan_acción_traslado_balance_SSV_ruta_comunitaria(int idPlan, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_TB_BALANCE_TRASLADO_TB_DERECHO_NECESIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public bool LD_Insertar_personas_a_trasladar_ruta_comunitaria(int idPlan, int idUsuario)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_TB_RYR_PERSONAS_CARACTERIZADAS_PARA_TRASLADAR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParamIdUsuario = new SqlParameter("@ID_USUARIO", idUsuario);
                oParamIdUsuario.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParamIdUsuario);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public DataSet LD_Reportes_Ruta_Comunitaria()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.GET_DATOS_REPORTES", con);
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
        public DataSet LD_Get_Datos_Reportes_Ruta_Comunitaria(string nombreSp)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand(nombreSp, con);
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
        #endregion
    }
}