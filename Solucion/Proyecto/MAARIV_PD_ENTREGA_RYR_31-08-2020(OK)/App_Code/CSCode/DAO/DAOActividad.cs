/*
 *******************************************************************************************
  PROGRAMA				: DAOActividad.cs
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
  FECHA DE CREACION	    : 13-04-2015
  USUARIO MODIFICA      : JULIAN A. BOCANEGRA M.
  FECHA DE MODIFICACION : 28-10-2019
  VERSION               : 1.3
 *******************************************************************************************    
  CLASE			        : DAOActividad.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : EMERSON PULIDO
 ********************************************************************************************
*/

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.actividad;
using com.GACV.lgb.modelo.persona;
using com.GACV.lgb.modelo.sujeto_colectiva;
using System;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOActividad
    {
        private string cliente;
       
        /// Método constructor de la clase       
        public DAOActividad()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        public int Administrar_actividad(Actividad actividad, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_FERIA", DbType.Int32);
                Command.Parameters["@P_ID_FERIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_FERIA"].Value = actividad.P_ID_FERIA;

                Command.Parameters.Add("@P_ID_SRC", DbType.Int32);
                Command.Parameters["@P_ID_SRC"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SRC"].Value = actividad.P_ID_SRC;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = actividad.P_ID_NOMBRE_ACTIVIDAD;

                Command.Parameters.Add("@P_DESCRIPCION_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Value = actividad.P_DESCRIPCION_ACTIVIDAD;

                //Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                //Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_ID_DEPENDENCIA"].Value = actividad.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@P_TIENE_LIMITE_PERSONAS", DbType.Int32);
                Command.Parameters["@P_TIENE_LIMITE_PERSONAS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIENE_LIMITE_PERSONAS"].Value = actividad.P_TIENE_LIMITE_PERSONAS;

                Command.Parameters.Add("@P_LIMITE_PERSONAS", DbType.Int32);
                Command.Parameters["@P_LIMITE_PERSONAS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_LIMITE_PERSONAS"].Value = actividad.P_LIMITE_PERSONAS;
                
                Command.Parameters.Add("@P_NUMERO_RESPONSABLES", DbType.String);
                Command.Parameters["@P_NUMERO_RESPONSABLES"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NUMERO_RESPONSABLES"].Value = actividad.P_NUMERO_RESPONSABLES;

                Command.Parameters.Add("@P_NUMERO_DIA_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_NUMERO_DIA_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NUMERO_DIA_ACTIVIDAD"].Value = actividad.P_NUMERO_DIA_ACTIVIDAD;

                //Command.Parameters.Add("@P_ID_TIPO_ACTIVIDAD", DbType.Int32);
                //Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Value = actividad.P_ID_TIPO_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_ESTADO;

                Command.Parameters.Add("@P_CORREGIMIENTO", DbType.String);
                Command.Parameters["@P_CORREGIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CORREGIMIENTO"].Value = actividad.P_CORREGIMIENTO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_TABLERO", DbType.Int32);
                Command.Parameters["@P_ID_TABLERO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TABLERO"].Value = actividad.P_ID_TABLERO;

                Command.Parameters.Add("@P_URL_REPORTE", DbType.String);
                Command.Parameters["@P_URL_REPORTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_URL_REPORTE"].Value = actividad.P_URL_REPORTE;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                //valor = Command.ExecuteNonQuery();
                

                if (opcion == 1)
                {
                    valor = Convert.ToInt32(Command.ExecuteScalar());
                }
                else
                {
                    valor = Command.ExecuteNonQuery();
                }

                con.Close(); 
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }

        // permite consultar la actividad
        public DataSet Consulta_actividad(Actividad actividad, Persona persona, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDADES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_DIRECTORIO", DbType.Int32);
                Command.Parameters["@P_ID_DIRECTORIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DIRECTORIO"].Value = actividad.P_ID_DIRECTORIO;

                Command.Parameters.Add("@P_ID_FERIA", DbType.Int32);
                Command.Parameters["@P_ID_FERIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_FERIA"].Value = actividad.P_ID_FERIA;

                Command.Parameters.Add("@P_ID_SRC", DbType.Int32);
                Command.Parameters["@P_ID_SRC"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SRC"].Value = actividad.P_ID_SRC;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = actividad.P_ID_NOMBRE_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = actividad.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_ESTADO;

                Command.Parameters.Add("@P_CORREGIMIENTO", DbType.String);
                Command.Parameters["@P_CORREGIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CORREGIMIENTO"].Value = actividad.P_CORREGIMIENTO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = actividad.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = actividad.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_PRIMER_NOMBRE", DbType.String);
                Command.Parameters["@P_PRIMER_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_NOMBRE"].Value = persona.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_SEGUNDO_NOMBRE", DbType.String);
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Value = persona.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_PRIMER_APELLIDO", DbType.String);
                Command.Parameters["@P_PRIMER_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_APELLIDO"].Value = persona.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_SEGUNDO_APELLIDO", DbType.String);
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Value = persona.P_PER_CAPELLIDO2;

                Command.Parameters.Add("@P_ID_RESPONSABLE", DbType.String);
                Command.Parameters["@P_ID_RESPONSABLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_RESPONSABLE"].Value = actividad.P_ID_RESPONSABLE;

                Command.Parameters.Add("@P_DESCRIPCION_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Value = actividad.P_DESCRIPCION_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_DIA_ESTADO;

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

        public int Administrar_Contactos(Actividad actividad, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_DIRECTORIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_NOMBRE", DbType.String);
                Command.Parameters["@P_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE"].Value = actividad.P_NOMBRE;

                Command.Parameters.Add("@P_ENTIDAD", DbType.String);
                Command.Parameters["@P_ENTIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ENTIDAD"].Value = actividad.P_ENTIDAD;

                Command.Parameters.Add("@P_CARGO", DbType.String);
                Command.Parameters["@P_CARGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CARGO"].Value = actividad.P_CARGO;

                Command.Parameters.Add("@P_TELEFONO", DbType.String);
                Command.Parameters["@P_TELEFONO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TELEFONO"].Value = actividad.P_TELEFONO;

                Command.Parameters.Add("@P_EMAIL", DbType.String);
                Command.Parameters["@P_EMAIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_EMAIL"].Value = actividad.P_EMAIL;

                Command.Parameters.Add("@P_ID_TIPO_CONTACTO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_CONTACTO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_CONTACTO_COLECTIVA"].Value = actividad.P_ID_TIPO_CONTACTO_COLECTIVA;

                Command.Parameters.Add("@P_ID_DIRECTORIO", DbType.Int32);
                Command.Parameters["@P_ID_DIRECTORIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DIRECTORIO"].Value = actividad.P_ID_DIRECTORIO;

                Command.Parameters.Add("@P_ID_SRC", DbType.Int32);
                Command.Parameters["@P_ID_SRC"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SRC"].Value = actividad.P_ID_SRC;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                //valor = Command.ExecuteNonQuery();

                if (opcion == 4)
                {
                    valor = Convert.ToInt32(Command.ExecuteScalar());
                }
                else
                {
                    valor = Command.ExecuteNonQuery();
                }


                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }

        // consulta las actividades de un evento
        public DataSet Consulta_actividad_calendario(Actividad actividad, Persona persona, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDADES_CALENDARIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_FERIA", DbType.Int32);
                Command.Parameters["@P_ID_FERIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_FERIA"].Value = actividad.P_ID_FERIA;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = actividad.P_ID_NOMBRE_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = actividad.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_ESTADO;

                Command.Parameters.Add("@P_CORREGIMIENTO", DbType.String);
                Command.Parameters["@P_CORREGIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CORREGIMIENTO"].Value = actividad.P_CORREGIMIENTO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = actividad.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = actividad.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_PRIMER_NOMBRE", DbType.String);
                Command.Parameters["@P_PRIMER_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_NOMBRE"].Value = persona.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_SEGUNDO_NOMBRE", DbType.String);
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Value = persona.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_PRIMER_APELLIDO", DbType.String);
                Command.Parameters["@P_PRIMER_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_APELLIDO"].Value = persona.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_SEGUNDO_APELLIDO", DbType.String);
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Value = persona.P_PER_CAPELLIDO2;

                Command.Parameters.Add("@P_ID_RESPONSABLE", DbType.String);
                Command.Parameters["@P_ID_RESPONSABLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_RESPONSABLE"].Value = actividad.P_ID_RESPONSABLE;

                Command.Parameters.Add("@P_FECHA_1", DbType.String);
                Command.Parameters["@P_FECHA_1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_1"].Value = actividad.P_FECHA_1;

                Command.Parameters.Add("@P_FECHA_2", DbType.String);
                Command.Parameters["@P_FECHA_2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_2"].Value = actividad.P_FECHA_2;

                Command.Parameters.Add("@P_DESCRIPCION_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Value = actividad.P_DESCRIPCION_ACTIVIDAD;

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

        public DataSet Consulta_fases_colectiva(Sujeto_colectiva sujeto_colectiva, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_FASES_COLECTIVA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_SRC", DbType.Int32);
                Command.Parameters["@P_ID_SRC"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SRC"].Value = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

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

        // permite consultar el reporte de la actividad
        public DataSet reporte_actividad_plan_accion(Actividad actividad, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDADES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad.P_ID_ACTIVIDAD;

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

        // permite consultar la actividad
        public DataSet Consulta_mopdulo_m(Actividad actividad, Persona persona, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_MODULO_M", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_FERIA", DbType.Int32);
                Command.Parameters["@P_ID_FERIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_FERIA"].Value = actividad.P_ID_FERIA;

                Command.Parameters.Add("@P_ID_SRC", DbType.Int32);
                Command.Parameters["@P_ID_SRC"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SRC"].Value = actividad.P_ID_SRC;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = actividad.P_ID_NOMBRE_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = actividad.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_ESTADO;

                Command.Parameters.Add("@P_CORREGIMIENTO", DbType.String);
                Command.Parameters["@P_CORREGIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CORREGIMIENTO"].Value = actividad.P_CORREGIMIENTO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = actividad.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = actividad.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_PRIMER_NOMBRE", DbType.String);
                Command.Parameters["@P_PRIMER_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_NOMBRE"].Value = persona.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_SEGUNDO_NOMBRE", DbType.String);
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Value = persona.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_PRIMER_APELLIDO", DbType.String);
                Command.Parameters["@P_PRIMER_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_APELLIDO"].Value = persona.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_SEGUNDO_APELLIDO", DbType.String);
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Value = persona.P_PER_CAPELLIDO2;

                Command.Parameters.Add("@P_ID_RESPONSABLE", DbType.String);
                Command.Parameters["@P_ID_RESPONSABLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_RESPONSABLE"].Value = actividad.P_ID_RESPONSABLE;

                Command.Parameters.Add("@P_DESCRIPCION_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Value = actividad.P_DESCRIPCION_ACTIVIDAD;

                Command.Parameters.Add("@P_FECHA_1", DbType.String);
                Command.Parameters["@P_FECHA_1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_1"].Value = actividad.P_FECHA_1;

                Command.Parameters.Add("@P_FECHA_2", DbType.String);
                Command.Parameters["@P_FECHA_2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_2"].Value = actividad.P_FECHA_2;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                Command.CommandTimeout = 0;
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // permite administrar los resgistros del archivo a procesar
        public DataSet Adm_actividad_cargue_masivo(DataTable DTable, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_CARGUE_MASIVO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@PTabla_Act", SqlDbType.Structured);
                Command.Parameters["@PTabla_Act"].Direction = ParameterDirection.Input;
                Command.Parameters["@PTabla_Act"].Value = DTable;
                Command.Parameters["@PTabla_Act"].TypeName = "dbo.TDT_ACTIVIDAD_CM_TEM";

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                //valor = Command.ExecuteNonQuery();
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

        public DataSet Consulta_actividad_2(Actividad actividad, Persona persona, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDADES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_FERIA", DbType.Int32);
                Command.Parameters["@P_ID_FERIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_FERIA"].Value = actividad.P_ID_FERIA;

                Command.Parameters.Add("@P_ID_SRC", DbType.Int32);
                Command.Parameters["@P_ID_SRC"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SRC"].Value = actividad.P_ID_SRC;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = actividad.P_ID_NOMBRE_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = actividad.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_ESTADO;

                Command.Parameters.Add("@P_CORREGIMIENTO", DbType.String);
                Command.Parameters["@P_CORREGIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CORREGIMIENTO"].Value = actividad.P_CORREGIMIENTO;

                Command.Parameters.Add("@P_FECHA_INICIO", DbType.String);
                Command.Parameters["@P_FECHA_INICIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_INICIO"].Value = actividad.P_FECHA_INICIO;

                Command.Parameters.Add("@P_FECHA_FIN", DbType.String);
                Command.Parameters["@P_FECHA_FIN"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_FIN"].Value = actividad.P_FECHA_FIN;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = actividad.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = actividad.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_PRIMER_NOMBRE", DbType.String);
                Command.Parameters["@P_PRIMER_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_NOMBRE"].Value = persona.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_SEGUNDO_NOMBRE", DbType.String);
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Value = persona.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_PRIMER_APELLIDO", DbType.String);
                Command.Parameters["@P_PRIMER_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_APELLIDO"].Value = persona.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_SEGUNDO_APELLIDO", DbType.String);
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Value = persona.P_PER_CAPELLIDO2;

                Command.Parameters.Add("@P_ID_RESPONSABLE", DbType.String);
                Command.Parameters["@P_ID_RESPONSABLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_RESPONSABLE"].Value = actividad.P_ID_RESPONSABLE;

                Command.Parameters.Add("@P_DESCRIPCION_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD"].Value = actividad.P_DESCRIPCION_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_DIA_ESTADO;

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