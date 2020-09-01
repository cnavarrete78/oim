/*
 *******************************************************************************************
  PROGRAMA				: DAOActividad_dia.cs
  FECHA DE CREACION	    : 13-04-2015
  FECHA DE MODIFICACION : 16-08-2019
  VERSION               : 1.3
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
 *******************************************************************************************
  CLASE			        : DAOActividad_dia.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : Brayan Steven Herreño
 ********************************************************************************************
*/

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.persona;
using com.GACV.lgb.modelo.actividad_dia;
using com.GACV.lgb.modelo.actividad_producto;
using System;


namespace com.GACV.lgb.persistencia.dao
{
    public class DAOActividad_dia
    {
        private string cliente;
       
        /// Método constructor de la clase       
        public DAOActividad_dia()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        public int Administrar_actividad_dia_Colectiva(Actividad_dia actividad_dia, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_DIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_dia.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_DIA_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_DIA_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DIA_ACTIVIDAD"].Value = actividad_dia.P_DIA_ACTIVIDAD;

                Command.Parameters.Add("@P_HORA_FIN", DbType.String);
                Command.Parameters["@P_HORA_FIN"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_HORA_FIN"].Value = actividad_dia.P_HORA_FIN;

                Command.Parameters.Add("@P_HORA_INICIO", DbType.String);
                Command.Parameters["@P_HORA_INICIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_HORA_INICIO"].Value = actividad_dia.P_HORA_INICIO;

                Command.Parameters.Add("@P_LUGAR_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_LUGAR_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_LUGAR_ACTIVIDAD"].Value = "";

                Command.Parameters.Add("@P_OBSERVACION_ACTIVIDAD_DIA", DbType.String);
                Command.Parameters["@P_OBSERVACION_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OBSERVACION_ACTIVIDAD_DIA"].Value = actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_PROYECCION", DbType.Int32);
                Command.Parameters["@P_PROYECCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PROYECCION"].Value = 0;

                Command.Parameters.Add("@P_GESTION", DbType.Int32);
                Command.Parameters["@P_GESTION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_GESTION"].Value = actividad_dia.P_GESTION;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DETALLE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Value = actividad_dia.P_ID_ACTIVIDAD_DETALLE;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_dia.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad_dia.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Value = actividad_dia.P_ID_ACTIVIDAD_DIA_ESTADO;

                Command.Parameters.Add("@P_GESTION1", DbType.Int64);
                Command.Parameters["@P_GESTION1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_GESTION1"].Value = actividad_dia.P_GESTION1;

                Command.Parameters.Add("@P_DESCRIPCION_PRODUCTO", DbType.String);
                Command.Parameters["@P_DESCRIPCION_PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_PRODUCTO"].Value = actividad_dia.P_LUGAR_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_PRODUCTO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_PRODUCTO"].Value = actividad_dia.P_PROYECCION;



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

        public int Administrar_actividad_producto(Actividad_producto actividad_producto, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_PRODUCTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_PRODUCTO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_PRODUCTO"].Value = actividad_producto.P_ID_ACTIVIDAD_PRODUCTO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_NOMBRE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_NOMBRE"].Value = actividad_producto.P_ID_ACTIVIDAD_NOMBRE;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = actividad_producto.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_producto.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_producto.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_PRODUCTO", DbType.String);
                Command.Parameters["@P_PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRODUCTO"].Value = actividad_producto.P_PRODUCTO;

                Command.Parameters.Add("@P_DESCRIPCION", DbType.String);
                Command.Parameters["@P_DESCRIPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION"].Value = actividad_producto.P_DESCRIPCION;

                Command.Parameters.Add("@P_ID_TIPO_MEDIDA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_MEDIDA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_MEDIDA"].Value = actividad_producto.P_ID_TIPO_MEDIDA;




                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                valor = Convert.ToInt32(Command.ExecuteScalar());
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }

        public int Administrar_actividad_dia(Actividad_dia actividad_dia, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_DIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_dia.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_DIA_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_DIA_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DIA_ACTIVIDAD"].Value = actividad_dia.P_DIA_ACTIVIDAD;

                Command.Parameters.Add("@P_HORA_FIN", DbType.String);
                Command.Parameters["@P_HORA_FIN"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_HORA_FIN"].Value = actividad_dia.P_HORA_FIN;

                Command.Parameters.Add("@P_HORA_INICIO", DbType.String);
                Command.Parameters["@P_HORA_INICIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_HORA_INICIO"].Value = actividad_dia.P_HORA_INICIO;

                Command.Parameters.Add("@P_LUGAR_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_LUGAR_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_LUGAR_ACTIVIDAD"].Value = actividad_dia.P_LUGAR_ACTIVIDAD;

                Command.Parameters.Add("@P_OBSERVACION_ACTIVIDAD_DIA", DbType.String);
                Command.Parameters["@P_OBSERVACION_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OBSERVACION_ACTIVIDAD_DIA"].Value = actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_PROYECCION", DbType.Int32);
                Command.Parameters["@P_PROYECCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PROYECCION"].Value = actividad_dia.P_PROYECCION;

                Command.Parameters.Add("@P_GESTION", DbType.Int32);
                Command.Parameters["@P_GESTION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_GESTION"].Value = actividad_dia.P_GESTION;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DETALLE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Value = actividad_dia.P_ID_ACTIVIDAD_DETALLE;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_dia.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad_dia.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_ESTADO"].Value = actividad_dia.P_ID_ACTIVIDAD_DIA_ESTADO;

                Command.Parameters.Add("@P_GESTION1", DbType.Int64);
                Command.Parameters["@P_GESTION1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_GESTION1"].Value = actividad_dia.P_GESTION1;

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
        
        // permite consultar la actividad
        public DataSet consulta_actividad_dia(Actividad_dia actividad_dia, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDAD_DIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_dia.P_ID_ACTIVIDAD;

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
        public DataSet consulta_tipos_material(int id_nombre_actividad, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_MATERIAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = id_nombre_actividad;

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

        public int administrar_asociar_personas(Actividad_dia actividad_dia, Persona persona, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_PERSONAS_MATERIAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_TIPO_MATERIAL", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_MATERIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_MATERIAL"].Value = actividad_dia.P_ID_TIPO_MATERIAL;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = persona.P_ID_PERSONA;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = persona.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = persona.P_DAN_NID_RESIDENCIA;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_ID_TIPO_IDENTIFICACION", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_IDENTIFICACION"].Value = persona.P_TDO_NID;

                Command.Parameters.Add("@P_ID_SEXO", DbType.Int32);
                Command.Parameters["@P_ID_SEXO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SEXO"].Value = persona.P_SEXO;

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

                Command.Parameters.Add("@P_FECHA_NACIMIENTO", DbType.String);
                Command.Parameters["@P_FECHA_NACIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_NACIMIENTO"].Value = persona.P_FECHA_NACIMIENTO;

                Command.Parameters.Add("@P_DIRECCION_RESIDENCIA", DbType.String);
                Command.Parameters["@P_DIRECCION_RESIDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DIRECCION_RESIDENCIA"].Value = persona.P_DIRECCION_CORRESPONDENCIA;

                Command.Parameters.Add("@P_BARRIO", DbType.String);
                Command.Parameters["@P_BARRIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_BARRIO"].Value = persona.P_BARRIO;

                Command.Parameters.Add("@P_E_MAIL", DbType.String);
                Command.Parameters["@P_E_MAIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_E_MAIL"].Value = persona.P_EMAIL;

                Command.Parameters.Add("@P_TELEFONO", DbType.String);
                Command.Parameters["@P_TELEFONO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TELEFONO"].Value = persona.P_TELEFONO;

                Command.Parameters.Add("@P_ID_ETNIA", DbType.Int32);
                Command.Parameters["@P_ID_ETNIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ETNIA"].Value = persona.P_ETN_NID;

                Command.Parameters.Add("@P_ID_RESGUARDO", DbType.Int32);
                Command.Parameters["@P_ID_RESGUARDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_RESGUARDO"].Value = persona.P_RGD_NID;

                Command.Parameters.Add("@P_ID_OSEXUAL", DbType.Int32);
                Command.Parameters["@P_ID_OSEXUAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_OSEXUAL"].Value = persona.P_ID_ORIENTACION_SEXUAL_PERSONA;

                Command.Parameters.Add("@P_ID_CIUDAD", DbType.Int32);
                Command.Parameters["@P_ID_CIUDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_CIUDAD"].Value = persona.P_ID_CIUDAD;

                Command.Parameters.Add("@P_ID_PAIS", DbType.Int32);
                Command.Parameters["@P_ID_PAIS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PAIS"].Value = persona.P_ID_PAIS;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = persona.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_ID_DISCAPACIDAD", DbType.Int32);
                Command.Parameters["@P_ID_DISCAPACIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DISCAPACIDAD"].Value = persona.P_ID_DISCAPACIDAD;

                Command.Parameters.Add("@P_ID_IDGENERO", DbType.Int32);
                Command.Parameters["@P_ID_IDGENERO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_IDGENERO"].Value = persona.P_ID_IDENTIDAD_GENERO;

                Command.Parameters.Add("@P_ID_ENFGRAVE", DbType.Int32);
                Command.Parameters["@P_ID_ENFGRAVE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ENFGRAVE"].Value = persona.P_ID_ENFERMEDAD;

                Command.Parameters.Add("@P_ID_ESTADO_CIVIL", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_CIVIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_CIVIL"].Value = persona.P_ID_ECIVIL;

                Command.Parameters.Add("@P_ID_TIPO_PERSONA", DbType.String);
                Command.Parameters["@P_ID_TIPO_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_PERSONA"].Value = persona.P_ID_TIPO_PERSONA;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_dia.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_MATERIAL", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_MATERIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_MATERIAL"].Value = actividad_dia.P_ID_ACTIVIDAD_MATERIAL;

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
        
        // permite consultar las personas, la asistencia y el material o accion aplicada a la persona
        public DataSet consultar_persona_actividad(Actividad_dia actividad_dia, Persona persona, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDAD_PERSONAS_MAT", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = persona.P_ID_PERSONA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_dia.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_TIPO_MATERIAL", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_MATERIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_MATERIAL"].Value = actividad_dia.P_ID_TIPO_MATERIAL;

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

        public DataSet asistencia_persona_actividad(Actividad_dia actividad_dia, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDAD_PERSONAS_MAT", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_dia.P_ID_ACTIVIDAD;

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

        public DataSet Consulta_documentos_obligatorios(int id_nombre_actividad, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("ADMINISTRACION_VALIDACION_DIA_ARCHIVO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = id_nombre_actividad;

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

        public DataSet consulta_actividad_dia_pae(Actividad_dia actividad_dia)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_TEST", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_dia.P_ID_ACTIVIDAD;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet consulta_tipo_medida()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_MEDIDA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = 3;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        //guarda los test
        public int Administrar_test(Actividad_dia actividad_dia, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("ADMINISTRAR_TEST", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_dia.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_NOMBRE_COMPLETO", DbType.String);
                Command.Parameters["@P_NOMBRE_COMPLETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE_COMPLETO"].Value = actividad_dia.P_LUGAR_ACTIVIDAD;

                Command.Parameters.Add("@P_BUENAS", DbType.String);
                Command.Parameters["@P_BUENAS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_BUENAS"].Value = actividad_dia.P_GESTION;

                Command.Parameters.Add("@P_MALAS", DbType.String);
                Command.Parameters["@P_MALAS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_MALAS"].Value = actividad_dia.P_PROYECCION;

                Command.Parameters.Add("@P_PORCENTAJE", DbType.String);
                Command.Parameters["@P_PORCENTAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PORCENTAJE"].Value = actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_FECHA_EXAMEN", DbType.String);
                Command.Parameters["@P_FECHA_EXAMEN"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_EXAMEN"].Value = actividad_dia.P_DIA_ACTIVIDAD;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia.P_USUARIO_CREACION;

                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }

    }

}