/*
 *******************************************************************************************
  PROGRAMA				: DAOColectiva.cs
  FECHA DE CREACION	    : 02-09-2013
  FECHA DE MODIFICACION : 13-08-2019
  VERSION               : 1.1
  AUTOR                 : Julian Bocanegra

 *******************************************************************************************

  CLASE			        : DAOColectiva.cs
  RESPONSABILIDAD	    : Se encarga de las consultas en la BD de colectiva
  COLABORACION		    : Alejandro Moreno
 ********************************************************************************************
*/


using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.adjuntar_archivos;
using com.GACV.lgb.modelo.sujeto_colectiva;

//using Microsoft.Practices.EnterpriseLibrary.Data;
//using System.Data.OracleClient;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOColectiva
    {
        private string cliente;
       // PJMasterPage.Class.Radicados ObjRadicado;

        /// Método constructor de la clase       
        public DAOColectiva()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        public DataSet Consultar_sujeto(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_SUJETO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ZONA", DbType.Int32);
                Command.Parameters["@P_ID_ZONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ZONA"].Value = sujeto_colectiva.P_ID_ZONA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = sujeto_colectiva.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_ALCANCE", DbType.Int32);
                Command.Parameters["@P_ID_ALCANCE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ALCANCE"].Value = sujeto_colectiva.P_ID_ALCANCE;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = sujeto_colectiva.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = sujeto_colectiva.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA_DET", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET;

                Command.Parameters.Add("@P_NIT", DbType.String);
                Command.Parameters["@P_NIT"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NIT"].Value = sujeto_colectiva.P_NIT;




                Command.Parameters.Add("@P_NOMBRE_SUJETO_COLECTIVA", DbType.String);
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_NOMBRE_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ESTADO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_TIPO_ACCESO", DbType.String);
                Command.Parameters["@P_TIPO_ACCESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIPO_ACCESO"].Value = sujeto_colectiva.P_TIPO_ACCESO;

                Command.Parameters.Add("@P_FUD", DbType.String);
                Command.Parameters["@P_FUD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FUD"].Value = sujeto_colectiva.P_FUD;

                Command.Parameters.Add("@P_ESTADO_RUV", DbType.String);
                Command.Parameters["@P_ESTADO_RUV"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_RUV"].Value = sujeto_colectiva.P_ESTADO_RUV;




                Command.Parameters.Add("@P_FASE", DbType.Int32);
                Command.Parameters["@P_FASE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FASE"].Value = sujeto_colectiva.P_FASE;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = sujeto_colectiva.P_IDENTIFICACION;

                Command.Parameters.Add("@P_NOMBRE1", DbType.String);
                Command.Parameters["@P_NOMBRE1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE1"].Value = sujeto_colectiva.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_NOMBRE2", DbType.String);
                Command.Parameters["@P_NOMBRE2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE2"].Value = sujeto_colectiva.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_APELLIDO1", DbType.String);
                Command.Parameters["@P_APELLIDO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_APELLIDO1"].Value = sujeto_colectiva.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_APELLIDO2", DbType.String);
                Command.Parameters["@P_APELLIDO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_APELLIDO2"].Value = sujeto_colectiva.P_PER_CAPELLIDO2;


                Command.Parameters.Add("@P_ID_USUARIO", DbType.String);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = sujeto_colectiva.P_ID_USUARIO;


                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                Command.CommandTimeout = 0;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }
            return ds;
        }

        public DataSet Consultar_bandeja_colectiva(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_BANDEJA_COLECTIVA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ALCANCE", DbType.Int32);
                Command.Parameters["@P_ID_ALCANCE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ALCANCE"].Value = sujeto_colectiva.P_ID_ALCANCE;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = sujeto_colectiva.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = sujeto_colectiva.P_ID_MUNICIPIO;              

                Command.Parameters.Add("@P_NOMBRE_SUJETO_COLECTIVA", DbType.String);
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_NOMBRE_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ESTADO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = sujeto_colectiva.P_ID_USUARIO;

                Command.Parameters.Add("@P_ID_ROL", DbType.Int32);
                Command.Parameters["@P_ID_ROL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ROL"].Value = sujeto_colectiva.P_ID_ROL;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA_DET", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET;

                Command.Parameters.Add("@P_NIT", DbType.String);
                Command.Parameters["@P_NIT"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NIT"].Value = sujeto_colectiva.P_NIT;

                Command.Parameters.Add("@P_ID_ZONA", DbType.Int32);
                Command.Parameters["@P_ID_ZONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ZONA"].Value = sujeto_colectiva.P_ID_ZONA;

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

        // Admistrar las ofertas
        public int Administrar_sujeto(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_SUJETO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ALCANCE", DbType.Int32);
                Command.Parameters["@P_ID_ALCANCE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ALCANCE"].Value = sujeto_colectiva.P_ID_ALCANCE;

                Command.Parameters.Add("@P_ID_ZONA", DbType.Int32);
                Command.Parameters["@P_ID_ZONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ZONA"].Value = sujeto_colectiva.P_ID_ZONA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = sujeto_colectiva.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA_DET", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = sujeto_colectiva.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = sujeto_colectiva.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_NIT", DbType.Int32);
                Command.Parameters["@P_NIT"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NIT"].Value = sujeto_colectiva.P_NIT;

                Command.Parameters.Add("@P_NOMBRE_SUJETO_COLECTIVA", DbType.String);
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_NOMBRE_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_OBSERVACION_ESTADO_SUJETO", DbType.String);
                Command.Parameters["@P_OBSERVACION_ESTADO_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OBSERVACION_ESTADO_SUJETO"].Value = sujeto_colectiva.P_OBSERVACION_ESTADO_SUJETO;
                //Command.Parameters.Add("@P_ID_ESTADO_SUJETO_COLECTIVA", DbType.Int32);
                //Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ESTADO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_TIPO_ACCESO", DbType.String);
                Command.Parameters["@P_TIPO_ACCESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIPO_ACCESO"].Value = sujeto_colectiva.P_TIPO_ACCESO;

                Command.Parameters.Add("@P_FUD", DbType.String);
                Command.Parameters["@P_FUD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FUD"].Value = sujeto_colectiva.P_FUD;

                Command.Parameters.Add("@P_ESTADO_RUV", DbType.String);
                Command.Parameters["@P_ESTADO_RUV"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_RUV"].Value = sujeto_colectiva.P_ESTADO_RUV;    


                Command.Parameters.Add("@P_FASE", DbType.Int32);
                Command.Parameters["@P_FASE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FASE"].Value = sujeto_colectiva.P_FASE;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = sujeto_colectiva.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = sujeto_colectiva.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                Command.CommandTimeout = 0;
                DataAdapter.InsertCommand = Command;
                valor = Command.ExecuteNonQuery();
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }

            return valor;
        }

        //Consulta la asignacion de un sujeto colectivo   
        public DataSet Consultar_asignacion(Sujeto_colectiva sujeto_colectiva)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ASIGNACION_SC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ASIGNACION_SUJETOS", DbType.Int32);
                Command.Parameters["@P_ID_ASIGNACION_SUJETOS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ASIGNACION_SUJETOS"].Value = sujeto_colectiva.P_ID_ASIGNACION_SUJETOS;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Administrar la asignacion de los sujetos
        public int Administrar_asignacion_sujeto(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ASIGNACION_SUJETO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ASIGNACION_SUJETOS", DbType.Int32);
                Command.Parameters["@P_ID_ASIGNACION_SUJETOS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ASIGNACION_SUJETOS"].Value = sujeto_colectiva.P_ID_ASIGNACION_SUJETOS;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ROL", DbType.Int32);
                Command.Parameters["@P_ID_ROL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ROL"].Value = sujeto_colectiva.P_ID_ROL;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = sujeto_colectiva.P_ID_USUARIO;

                Command.Parameters.Add("@P_ID_ESTADO_ASIGNACION_SUJETO", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_ASIGNACION_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_ASIGNACION_SUJETO"].Value = sujeto_colectiva.P_ID_ESTADO_ASIGNACION_SUJETO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = sujeto_colectiva.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = sujeto_colectiva.P_USUARIO_MODIFICA;

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

        //Consulta las preguntas segun el tipo de sujeto colectivo        
        public DataSet Consultar_tipo_preguntas(Sujeto_colectiva sujeto_colectiva)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_TIPO_PREGUNTAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ROL", DbType.Int32);
                Command.Parameters["@P_ID_ROL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ROL"].Value = sujeto_colectiva.P_ID_ROL;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }
        
        public DataSet Consultar_directorio(Sujeto_colectiva sujeto_colectiva)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_DIRECTORIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_DIRECTORIO", DbType.Int32);
                Command.Parameters["@P_ID_DIRECTORIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DIRECTORIO"].Value = sujeto_colectiva.P_ID_DIRECTORIO;

                Command.Parameters.Add("@P_ID_TIPO_CONTACTO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_CONTACTO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_CONTACTO_COLECTIVA"].Value = sujeto_colectiva.P_ID_TIPO_CONTACTO_COLECTIVA;

                Command.Parameters.Add("@P_ENTIDAD", DbType.String);
                Command.Parameters["@P_ENTIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ENTIDAD"].Value = sujeto_colectiva.P_ENTIDAD;

                Command.Parameters.Add("@P_NOMBRE", DbType.String);
                Command.Parameters["@P_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE"].Value = sujeto_colectiva.P_NOMBRE;

                Command.Parameters.Add("@P_CARGO", DbType.String);
                Command.Parameters["@P_CARGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CARGO"].Value = sujeto_colectiva.P_CARGO;

                Command.Parameters.Add("@P_EMAIL", DbType.String);
                Command.Parameters["@P_EMAIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_EMAIL"].Value = sujeto_colectiva.P_EMAIL;

                Command.Parameters.Add("@P_TELEFONO", DbType.String);
                Command.Parameters["@P_TELEFONO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TELEFONO"].Value = sujeto_colectiva.P_TELEFONO;

                Command.Parameters.Add("@P_ESTADO_DIRECTORIO", DbType.Int32);
                Command.Parameters["@P_ESTADO_DIRECTORIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_DIRECTORIO"].Value = sujeto_colectiva.P_ESTADO_DIRECTORIO;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Admistrar los contactos del directorio
        public int Administrar_directorio(Sujeto_colectiva sujeto_colectivo, int opcion)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_DIRECTORIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DIRECTORIO", DbType.Int32);
                Command.Parameters["@P_ID_DIRECTORIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DIRECTORIO"].Value = sujeto_colectivo.P_ID_DIRECTORIO;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectivo.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_TIPO_CONTACTO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_CONTACTO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_CONTACTO_COLECTIVA"].Value = sujeto_colectivo.P_ID_TIPO_CONTACTO_COLECTIVA;

                Command.Parameters.Add("@P_ENTIDAD", DbType.String);
                Command.Parameters["@P_ENTIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ENTIDAD"].Value = sujeto_colectivo.P_ENTIDAD;

                Command.Parameters.Add("@P_NOMBRE", DbType.String);
                Command.Parameters["@P_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE"].Value = sujeto_colectivo.P_NOMBRE;

                Command.Parameters.Add("@P_CARGO", DbType.String);
                Command.Parameters["@P_CARGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CARGO"].Value = sujeto_colectivo.P_CARGO;

                Command.Parameters.Add("@P_EMAIL", DbType.String);
                Command.Parameters["@P_EMAIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_EMAIL"].Value = sujeto_colectivo.P_EMAIL;

                Command.Parameters.Add("@P_TELEFONO", DbType.String);
                Command.Parameters["@P_TELEFONO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TELEFONO"].Value = sujeto_colectivo.P_TELEFONO;

                Command.Parameters.Add("@P_ESTADO_DIRECTORIO", DbType.Int32);
                Command.Parameters["@P_ESTADO_DIRECTORIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_DIRECTORIO"].Value = sujeto_colectivo.P_ESTADO_DIRECTORIO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = sujeto_colectivo.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = sujeto_colectivo.P_USUARIO_MODIFICA;

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
   
        //Permite consultar los archivos adjuntos
        public DataSet consultar_adjuntar_archivos(Adjuntar_archivos adjuntar_archivos, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_ARCHIVOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                //Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                //Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_ID_USUARIO"].Value = adjuntar_archivos.P_ID_USUARIO;

                Command.Parameters.Add("@P_ID_DOCUMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DOCUMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DOCUMENTO"].Value = adjuntar_archivos.P_ID_DOCUMENTO;

                //Command.Parameters.Add("@P_USUARIO", DbType.String);
                //Command.Parameters["@P_USUARIO"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_USUARIO"].Value = adjuntar_archivos.P_USUARIO;

                Command.Parameters.Add("@P_NOMBRE_DOCUMENTO", DbType.String);
                Command.Parameters["@P_NOMBRE_DOCUMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE_DOCUMENTO"].Value = adjuntar_archivos.P_NOMBRE_DOCUMENTO;

                Command.Parameters.Add("@P_ID_TIPO_DOCUMENTO", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_DOCUMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_DOCUMENTO"].Value = adjuntar_archivos.P_ID_TIPO_DOCUMENTO;

                Command.Parameters.Add("@P_FECHA_EXPEDICION", DbType.String);
                Command.Parameters["@P_FECHA_EXPEDICION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_EXPEDICION"].Value = adjuntar_archivos.P_FECHA_EXPEDICION;

                Command.Parameters.Add("@P_FECHA_VENCIMIENTO", DbType.String);
                Command.Parameters["@P_FECHA_VENCIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_VENCIMIENTO"].Value = adjuntar_archivos.P_FECHA_VENCIMIENTO;

                Command.Parameters.Add("@P_ID_OFERTA", DbType.Int32);
                Command.Parameters["@P_ID_OFERTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_OFERTA"].Value = adjuntar_archivos.P_ID_OFERTA;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }                

        //Administrar adjuntar archivos
        public int Administrar_adjuntar_archivos(Adjuntar_archivos adjuntar_archivos, int opcion)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ARCHIVOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DOCUMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DOCUMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DOCUMENTO"].Value = adjuntar_archivos.P_ID_DOCUMENTO;

                //Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                //Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_ID_USUARIO"].Value = adjuntar_archivos.P_ID_USUARIO;

                Command.Parameters.Add("@P_NOMBRE_DOCUMENTO", DbType.String);
                Command.Parameters["@P_NOMBRE_DOCUMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE_DOCUMENTO"].Value = adjuntar_archivos.P_NOMBRE_DOCUMENTO;

                Command.Parameters.Add("@P_ID_TIPO_DOCUMENTO", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_DOCUMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_DOCUMENTO"].Value = adjuntar_archivos.P_ID_TIPO_DOCUMENTO;

                Command.Parameters.Add("@P_FECHA_EXPEDICION", DbType.DateTime);
                Command.Parameters["@P_FECHA_EXPEDICION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_EXPEDICION"].Value = adjuntar_archivos.P_FECHA_EXPEDICION;

                Command.Parameters.Add("@P_FECHA_VENCIMIENTO", DbType.DateTime);
                Command.Parameters["@P_FECHA_VENCIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_VENCIMIENTO"].Value = adjuntar_archivos.P_FECHA_VENCIMIENTO;

                Command.Parameters.Add("@P_ARCHIVO", DbType.Byte);
                Command.Parameters["@P_ARCHIVO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ARCHIVO"].Value = adjuntar_archivos.P_ARCHIVO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = adjuntar_archivos.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = adjuntar_archivos.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_OFERTA", DbType.Int32);
                Command.Parameters["@P_ID_OFERTA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_OFERTA"].Value = adjuntar_archivos.P_ID_OFERTA;

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

        /**
        * Cambio alejandro para reporte de colectiva en sp_reporte_colectiva 
        */
        // Reporte estado colectiva
        public DataSet reporte_colectiva(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_REPORTE_COLECTIVA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_ZONA", DbType.Int32);
                Command.Parameters["@P_ID_ZONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ZONA"].Value = sujeto_colectiva.P_ID_ZONA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = sujeto_colectiva.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_ALCANCE", DbType.Int32);
                Command.Parameters["@P_ID_ALCANCE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ALCANCE"].Value = sujeto_colectiva.P_ID_ALCANCE;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = sujeto_colectiva.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = sujeto_colectiva.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_TIPO_SUJETO_COLECTIVA_DET", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SUJETO_COLECTIVA_DET"].Value = sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET;

                Command.Parameters.Add("@P_NIT", DbType.String);
                Command.Parameters["@P_NIT"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NIT"].Value = sujeto_colectiva.P_NIT;



                Command.Parameters.Add("@P_ID_ESTADO_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_TIPO_ACCESO", DbType.String);
                Command.Parameters["@P_TIPO_ACCESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIPO_ACCESO"].Value = sujeto_colectiva.P_TIPO_ACCESO;

                Command.Parameters.Add("@P_FUD", DbType.String);
                Command.Parameters["@P_FUD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FUD"].Value = sujeto_colectiva.P_FUD;

                Command.Parameters.Add("@P_ESTADO_RUV", DbType.String);
                Command.Parameters["@P_ESTADO_RUV"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_RUV"].Value = sujeto_colectiva.P_ESTADO_RUV;




                Command.Parameters.Add("@P_NOMBRE_SUJETO_COLECTIVA", DbType.String);
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE_SUJETO_COLECTIVA"].Value = sujeto_colectiva.P_NOMBRE_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_FASE", DbType.Int32);
                Command.Parameters["@P_FASE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FASE"].Value = sujeto_colectiva.P_FASE;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = sujeto_colectiva.P_IDENTIFICACION;

                Command.Parameters.Add("@P_NOMBRE1", DbType.String);
                Command.Parameters["@P_NOMBRE1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE1"].Value = sujeto_colectiva.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_NOMBRE2", DbType.String);
                Command.Parameters["@P_NOMBRE2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE2"].Value = sujeto_colectiva.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_APELLIDO1", DbType.String);
                Command.Parameters["@P_APELLIDO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_APELLIDO1"].Value = sujeto_colectiva.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_APELLIDO2", DbType.String);
                Command.Parameters["@P_APELLIDO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_APELLIDO2"].Value = sujeto_colectiva.P_PER_CAPELLIDO2;


                Command.Parameters.Add("@P_ID_USUARIO", DbType.String);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = sujeto_colectiva.P_ID_USUARIO;

                Command.Parameters.Add("@P_ID_ROL", DbType.Int32);
                Command.Parameters["@P_ID_ROL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ROL"].Value = sujeto_colectiva.P_ID_ROL;


                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                Command.CommandTimeout = 0;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string error = "error";
            }
            return ds;
        }
        /**
        * Fin cambio alejandro
        */

    }

}