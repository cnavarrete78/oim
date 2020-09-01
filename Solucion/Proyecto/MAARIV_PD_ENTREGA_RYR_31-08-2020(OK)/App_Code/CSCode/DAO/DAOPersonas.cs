/*
 *******************************************************************************************
  PROGRAMA				: DAOPersonas.cs
  FECHA DE CREACION	    : 27-04-2015
  FECHA DE MODIFICACION : 20-05-2020
  VERSION               : 1.3
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
 *******************************************************************************************
  CLASE			        : DAOPersonas.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : JULIAN A. BOCANEGRA M.
 ********************************************************************************************
*/

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.persona;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOPersonas
    {
        private string cliente;

        /// Método constructor de la clase       
        public DAOPersonas()
        {
            //cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        public int administrar_personas(Persona persona, int opcion)
        {
            int valor = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_PERSONAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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
                
                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = persona.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_ID_ESTADO_CIVIL", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_CIVIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_CIVIL"].Value = persona.P_ID_ECIVIL;

                Command.Parameters.Add("@P_ID_TIPO_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_PERSONA"].Value = persona.P_ID_TIPO_PERSONA;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = persona.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ESTADO_RUV", DbType.String);
                Command.Parameters["@P_ESTADO_RUV"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_RUV"].Value = persona.P_ESTADO_RUV;

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

        // Busca las personas
        public DataSet consultar_personas(Persona persona, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_PERSONAS_MM", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = persona.P_ID_PERSONA;

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

                Command.Parameters.Add("@P_ID_TIPO_IDENTIFICACION", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_IDENTIFICACION"].Value = persona.P_TDO_NID;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_ID_DEPTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPTO"].Value = persona.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICP", DbType.Int32);
                Command.Parameters["@P_ID_MUNICP"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICP"].Value = persona.P_DAN_NID_RESIDENCIA;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = persona.P_ID_TIPO_PERSONA;
                
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

        // personas proceso
        public DataSet consultar_personas_proceso(Persona persona, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_PERSONAS_OAJ", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = persona.P_ID_PERSONA;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = persona.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = persona.P_DAN_NID_RESIDENCIA;

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

                Command.Parameters.Add("@P_ID_TIPO_IDENTIFICACION", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_IDENTIFICACION"].Value = persona.P_TDO_NID;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_ID_ETNIA", DbType.String);
                Command.Parameters["@P_ID_ETNIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ETNIA"].Value = persona.P_ETN_NID;

                Command.Parameters.Add("@P_ID_SEXO", DbType.String);
                Command.Parameters["@P_ID_SEXO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SEXO"].Value = persona.P_SEXO;

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
           
        // Busca las personas
        public DataSet Consulta_Estado_Personas(Persona persona)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ESTADO_PERSONA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_NUMERO_DOCUMENTO", DbType.String);
                Command.Parameters["@P_NUMERO_DOCUMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NUMERO_DOCUMENTO"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_NOMBRE1", DbType.String);
                Command.Parameters["@P_NOMBRE1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE1"].Value = persona.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_NOMBRE2", DbType.String);
                Command.Parameters["@P_NOMBRE2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_NOMBRE2"].Value = persona.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_APELLIDO1", DbType.String);
                Command.Parameters["@P_APELLIDO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_APELLIDO1"].Value = persona.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_APELLIDO2", DbType.String);
                Command.Parameters["@P_APELLIDO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_APELLIDO2"].Value = persona.P_PER_CAPELLIDO2;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                throw;
            }
            return ds;
        }

        // Busca las personas
        public DataSet Consultar_Estado_Victima(Persona persona)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_EV_ESTADO_VICTIMA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.String);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = persona.P_ID_PERSONA;

                Command.Parameters.Add("@P_PER_CCEDULA", DbType.String);
                Command.Parameters["@P_PER_CCEDULA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PER_CCEDULA"].Value = persona.P_PER_CEDULA;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                throw;
            }
            return ds;
        }

        public DataSet SP_PersonaS(int intOpcion, Persona persona, ref string strError)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_PersonaS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;
                
                Command.Parameters.Add("@OPCION", DbType.Int32);
                Command.Parameters["@OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@OPCION"].Value = intOpcion;

                Command.Parameters.Add("@ID_PERSONA", DbType.Int32);
                Command.Parameters["@ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PERSONA"].Value = persona.P_ID_PERSONA;

                Command.Parameters.Add("@PER_CCEDULA", DbType.String);
                Command.Parameters["@PER_CCEDULA"].Direction = ParameterDirection.Input;
                Command.Parameters["@PER_CCEDULA"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@TDO_NID", DbType.Int32);
                Command.Parameters["@TDO_NID"].Direction = ParameterDirection.Input;
                Command.Parameters["@TDO_NID"].Value = persona.P_TDO_NID;

                Command.Parameters.Add("@SEXO", DbType.Int32);
                Command.Parameters["@SEXO"].Direction = ParameterDirection.Input;
                Command.Parameters["@SEXO"].Value = persona.P_SEXO;

                Command.Parameters.Add("@PER_CNOMBRE1", DbType.String);
                Command.Parameters["@PER_CNOMBRE1"].Direction = ParameterDirection.Input;
                Command.Parameters["@PER_CNOMBRE1"].Value = persona.P_PER_CNOMBRE1;

                Command.Parameters.Add("@PER_CNOMBRE2", DbType.String);
                Command.Parameters["@PER_CNOMBRE2"].Direction = ParameterDirection.Input;
                Command.Parameters["@PER_CNOMBRE2"].Value = persona.P_PER_CNOMBRE2;

                Command.Parameters.Add("@PER_CAPELLIDO1", DbType.String);
                Command.Parameters["@PER_CAPELLIDO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@PER_CAPELLIDO1"].Value = persona.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@PER_CAPELLIDO2", DbType.String);
                Command.Parameters["@PER_CAPELLIDO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@PER_CAPELLIDO2"].Value = persona.P_PER_CAPELLIDO2;

                Command.Parameters.Add("@FECHA_NACIMIENTO", DbType.String);
                Command.Parameters["@FECHA_NACIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHA_NACIMIENTO"].Value = persona.P_FECHA_NACIMIENTO;
                
                Command.Parameters.Add("@ID_DEPARTAMENTO_RESIDENCIA", DbType.Int32);
                Command.Parameters["@ID_DEPARTAMENTO_RESIDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_DEPARTAMENTO_RESIDENCIA"].Value = persona.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_DAN_NID_RESIDENCIA", DbType.String);
                Command.Parameters["@P_DAN_NID_RESIDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DAN_NID_RESIDENCIA"].Value = persona.P_DAN_NID_RESIDENCIA;

                Command.Parameters.Add("@P_DIRECCION_CORRESPONDENCIA", DbType.String);
                Command.Parameters["@P_DIRECCION_CORRESPONDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DIRECCION_CORRESPONDENCIA"].Value = persona.P_DIRECCION_CORRESPONDENCIA;

                Command.Parameters.Add("@P_BARRIO", DbType.String);
                Command.Parameters["@P_BARRIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_BARRIO"].Value = persona.P_BARRIO;

                Command.Parameters.Add("@P_ETN_NID", DbType.Int32);
                Command.Parameters["@P_ETN_NID"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ETN_NID"].Value = persona.P_ETN_NID;

                Command.Parameters.Add("@RGD_NID", DbType.Int32);
                Command.Parameters["@RGD_NID"].Direction = ParameterDirection.Input;
                Command.Parameters["@RGD_NID"].Value = persona.P_RGD_NID;

                Command.Parameters.Add("@P_ID_TIPO_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_PERSONA"].Value = persona.P_ID_TIPO_PERSONA;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = persona.P_ID_SUJETO_COLECTIVA;

                Command.Parameters.Add("@P_TIPO_DISCAPACIDAD", DbType.Int32);
                Command.Parameters["@P_TIPO_DISCAPACIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIPO_DISCAPACIDAD"].Value = persona.P_TIPO_DISCAPACIDAD;

                Command.Parameters.Add("@P_ID_ORIENTACION_SEXUAL_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_ORIENTACION_SEXUAL_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ORIENTACION_SEXUAL_PERSONA"].Value = persona.P_ID_ORIENTACION_SEXUAL_PERSONA;

                Command.Parameters.Add("@P_TELEFONO", DbType.String);
                Command.Parameters["@P_TELEFONO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TELEFONO"].Value = persona.P_TELEFONO;

                Command.Parameters.Add("@P_EMAIL", DbType.String);
                Command.Parameters["@P_EMAIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_EMAIL"].Value = persona.P_EMAIL;

                Command.Parameters.Add("@USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@USUARIO_CREACION"].Value = persona.P_USUARIO_CREACION;
                
                Command.Parameters.Add("@USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@USUARIO_MODIFICA"].Value = persona.P_USUARIO_MODIFICA;
            
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException)
            {
                //strError = String.Concat("Persona", ex.Message.ToString());
            }

            return ds;
        }

        // hechos victimizantes de las personas
        public DataSet consulta_hechos_victimizantes_persona(Persona persona, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_HVICTIMIZANTE_PERSONA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = persona.P_ID_PERSONA;

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
        
        // permite administrar los hechos victimizantes de la persona
        public int Administrar_hvictimizante_persona(Persona persona, int opcion)
        {
            int valor = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_HVICTIMIZANTE_PERSONA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = persona.P_ID_PERSONA;

                Command.Parameters.Add("@P_ID_HECHO_VICTIMIZANTE", DbType.Int32);
                Command.Parameters["@P_ID_HECHO_VICTIMIZANTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_HECHO_VICTIMIZANTE"].Value = persona.P_ID_HECHO_VICTIMIZANTE;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.String);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = persona.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.String);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = persona.P_USUARIO_MODIFICA;

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

    }

} 