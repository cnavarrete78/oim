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

    }
}