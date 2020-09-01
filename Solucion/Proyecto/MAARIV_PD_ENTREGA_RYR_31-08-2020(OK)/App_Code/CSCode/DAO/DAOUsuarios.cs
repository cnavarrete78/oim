/*
 *******************************************************************************************
  PROGRAMA				: DAOUsuariosLGB.cs
  FECHA DE CREACION	    : Mayo 29 de 2010
  FECHA DE MODIFICACION : 29-05-2015
  VERSION               : 1.0
  AUTOR                 : Gustavo Adolfo Caicedo Viveros
  MODIFICADO            : Gustavo Adolfo Caicedo Viveros

 *******************************************************************************************

  CLASE			        : DAOUsuariosLGB
  RESPONSABILIDAD	    : Se encarga se encarga de gestionar los usuarios en la BD
  COLABORACION		    : 
********************************************************************************************
*/

using System.Data;
using com.GACV.lgb.modelo.usuario;
using System.Data.Common;
using System.Data.SqlClient;

namespace com.GACV.lgb.persistencia.dao
{

    // Clase encargada de realizar operaciones relacionadas a participantes sobre la base de datos de Litigob (BD de Negocio)    
    public class DAOUsuarios
    {
        // Método creador de la clase
        public DAOUsuarios()
        {
        }

        #region ADMINISTRAR USUARIOS DEL SISTEMA

        /// Método encargado de la administracion de los usuarios       
        public int administrar_usuario(Usuario usuario, int opcion)
        {
            int valor = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_USUARIOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_usuario", DbType.Int32);
                Command.Parameters["@p_id_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_usuario"].Value = usuario.F_ID_USUARIO;

                Command.Parameters.Add("@p_login", DbType.String);
                Command.Parameters["@p_login"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_login"].Value = usuario.Login;

                Command.Parameters.Add("@p_password", DbType.String);
                Command.Parameters["@p_password"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_password"].Value = usuario.Password;

                Command.Parameters.Add("@p_email", DbType.String);
                Command.Parameters["@p_email"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_email"].Value = usuario.Email;

                Command.Parameters.Add("@p_id_estado_usuario", DbType.Int32);
                Command.Parameters["@p_id_estado_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_estado_usuario"].Value = usuario.P_id_estado_usuario;

                Command.Parameters.Add("@p_id_tipo_usuario", DbType.Int32);
                Command.Parameters["@p_id_tipo_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_usuario"].Value = usuario.F_TIPO_USUARIO;

                Command.Parameters.Add("@p_id_institucion", DbType.Int32);
                Command.Parameters["@p_id_institucion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_institucion"].Value = 0;

                Command.Parameters.Add("@p_usuario_creacion", DbType.String);
                Command.Parameters["@p_usuario_creacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_usuario_creacion"].Value = usuario.P_usuario_creacion;

                Command.Parameters.Add("@p_usuario_modifica", DbType.String);
                Command.Parameters["@p_usuario_modifica"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_usuario_modifica"].Value = usuario.P_usuario_modifica;

                Command.Parameters.Add("@p_id_persona", DbType.Int32);
                Command.Parameters["@p_id_persona"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_persona"].Value = usuario.F_id_persona;

                Command.Parameters.Add("@p_nombre", DbType.String);
                Command.Parameters["@p_nombre"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_nombre"].Value = usuario.F_Nombre;

                Command.Parameters.Add("@p_apellidos", DbType.String);
                Command.Parameters["@p_apellidos"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_apellidos"].Value = usuario.Apellidos;

                Command.Parameters.Add("@p_identificacion", DbType.String);
                Command.Parameters["@p_identificacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_identificacion"].Value = usuario.Identificacion;

                Command.Parameters.Add("@p_primer_nombre", DbType.String);
                Command.Parameters["@p_primer_nombre"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_primer_nombre"].Value = usuario.P_PRIMER_NOMBRE;

                Command.Parameters.Add("@p_segundo_nombre", DbType.String);
                Command.Parameters["@p_segundo_nombre"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_segundo_nombre"].Value = usuario.P_SEGUNDO_NOMBRE;

                Command.Parameters.Add("@p_primer_apellido", DbType.String);
                Command.Parameters["@p_primer_apellido"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_primer_apellido"].Value = usuario.P_PRIMER_APELLIDO;

                Command.Parameters.Add("@p_segundo_apellido", DbType.String);
                Command.Parameters["@p_segundo_apellido"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_segundo_apellido"].Value = usuario.P_SEGUNDO_APELLIDO;

                Command.Parameters.Add("@p_id_territorial", DbType.Int32);
                Command.Parameters["@p_id_territorial"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_territorial"].Value = usuario.P_ID_TERRITORIAL;

                Command.Parameters.Add("@p_id_tipo_identificacion", DbType.Int32);
                Command.Parameters["@p_id_tipo_identificacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_identificacion"].Value = usuario.P_tipo_identificación;

                Command.Parameters.Add("@p_telefono_fijo", DbType.String);
                Command.Parameters["@p_telefono_fijo"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_telefono_fijo"].Value = usuario.P_telefono_fijo;

                Command.Parameters.Add("@p_telefono_movil", DbType.String);
                Command.Parameters["@p_telefono_movil"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_telefono_movil"].Value = usuario.P_telefono_movil;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = usuario.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@p_id_municipio", DbType.Int32);
                Command.Parameters["@p_id_municipio"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_municipio"].Value = usuario.P_ID_MUNICIPIO;

                Command.Parameters.Add("@p_id_dependencia", DbType.Int32);
                Command.Parameters["@p_id_dependencia"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_dependencia"].Value = usuario.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@p_jefe_dependencia", DbType.Int32);
                Command.Parameters["@p_jefe_dependencia"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_jefe_dependencia"].Value = usuario.P_ID_JEFE_AREA;

                Command.Parameters.Add("@p_id_jefe_dependencia", DbType.Int32);
                Command.Parameters["@p_id_jefe_dependencia"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_jefe_dependencia"].Value = usuario.P_ID_JEFE_DEPENDENCIA;

                Command.Parameters.Add("@p_id_tipo_vinculacion", DbType.Int32);
                Command.Parameters["@p_id_tipo_vinculacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_vinculacion"].Value = usuario.P_ID_TIPO_VINCULACION;

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

        /// Método encargado de la administracion de los usuarios    
        /// 

        // -- =====================================================================
        // -- Author:		BRAYAN STIVEN HERREÑO BELTRAN
        // -- Create date: 20180423
        // -- Description: permite administrar historial activacion de usuarios
        // -- UserUpdate:	------------------------------
        // -- DateUpdate:  --/--/----
        // -- Version:		1.0
        // -- =====================================================================
        public DataSet activacion_usuario_sp(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVACION_USUARIOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_IdUsuario", DbType.Int32);
                Command.Parameters["@p_IdUsuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_IdUsuario"].Value = usuario.F_id_persona;

                Command.Parameters.Add("@p_IdDependencia", DbType.String);
                Command.Parameters["@p_IdDependencia"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_IdDependencia"].Value = usuario.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@p_IdSupervisor", DbType.String);
                Command.Parameters["@p_IdSupervisor"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_IdSupervisor"].Value = usuario.F_ID_USUARIO;

                Command.Parameters.Add("@p_FechaActivacion", DbType.String);
                Command.Parameters["@p_FechaActivacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_FechaActivacion"].Value = usuario.F_FECHA_INGRESO;

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

        /// Método consultar si existe una sesion abierta      
        public DataSet administrar_ip_cambiada(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_VERIFICAR_IP", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_usuario", DbType.Int32);
                Command.Parameters["@p_id_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_usuario"].Value = usuario.F_ID_USUARIO;

                Command.Parameters.Add("@p_IP", DbType.String);
                Command.Parameters["@p_IP"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_IP"].Value = usuario.F_Nombre;

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

        /// Método consultar si existe una sesion abierta      
        public DataSet administrar_sesion_duplicada(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_SESION_DUPLICADA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_usuario", DbType.Int32);
                Command.Parameters["@p_id_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_usuario"].Value = usuario.F_ID_USUARIO;

                //Command.Parameters.Add("@p_login", DbType.String);
                //Command.Parameters["@p_login"].Direction = ParameterDirection.Input;
                //Command.Parameters["@p_login"].Value = usuario.Login;

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

        /// Método encargado de la administracion de los usuarios       
        /// 
        public int administrar_sesiones(Usuario usuario, int opcion)
        {
            int valor = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_HISTORIAL_LOGIN", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_u_login", DbType.String);
                Command.Parameters["@p_u_login"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_u_login"].Value = usuario.Login;

                Command.Parameters.Add("@p_Registro_Estado", DbType.String);
                Command.Parameters["@p_Registro_Estado"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_Registro_Estado"].Value = usuario.Apellidos;

                Command.Parameters.Add("@p_Tipo_Bloqueo", DbType.String);
                Command.Parameters["@p_Tipo_Bloqueo"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_Tipo_Bloqueo"].Value = usuario.Email;

                Command.Parameters.Add("@p_id_Registro_Estado", DbType.String);
                Command.Parameters["@p_id_Registro_Estado"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_Registro_Estado"].Value = usuario.F_id_persona;

                Command.Parameters.Add("@p_id_Tipo_Bloqueo", DbType.String);
                Command.Parameters["@p_id_Tipo_Bloqueo"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_Tipo_Bloqueo"].Value = usuario.F_TIPO_USUARIO;

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

        public DataSet administrar_usuario_ds(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_USUARIOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_usuario", DbType.Int32);
                Command.Parameters["@p_id_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_usuario"].Value = usuario.F_ID_USUARIO;

                Command.Parameters.Add("@p_login", DbType.String);
                Command.Parameters["@p_login"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_login"].Value = usuario.Login;

                Command.Parameters.Add("@p_password", DbType.String);
                Command.Parameters["@p_password"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_password"].Value = usuario.Password;

                Command.Parameters.Add("@p_email", DbType.String);
                Command.Parameters["@p_email"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_email"].Value = usuario.Email;

                Command.Parameters.Add("@p_id_estado_usuario", DbType.Int32);
                Command.Parameters["@p_id_estado_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_estado_usuario"].Value = usuario.P_id_estado_usuario;

                Command.Parameters.Add("@p_id_tipo_usuario", DbType.Int32);
                Command.Parameters["@p_id_tipo_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_usuario"].Value = usuario.F_TIPO_USUARIO;

                Command.Parameters.Add("@p_id_institucion", DbType.Int32);
                Command.Parameters["@p_id_institucion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_institucion"].Value = 0;

                Command.Parameters.Add("@p_usuario_creacion", DbType.String);
                Command.Parameters["@p_usuario_creacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_usuario_creacion"].Value = usuario.P_usuario_creacion;

                Command.Parameters.Add("@p_usuario_modifica", DbType.String);
                Command.Parameters["@p_usuario_modifica"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_usuario_modifica"].Value = usuario.P_usuario_modifica;

                Command.Parameters.Add("@p_id_persona", DbType.Int32);
                Command.Parameters["@p_id_persona"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_persona"].Value = usuario.F_id_persona;

                Command.Parameters.Add("@p_nombre", DbType.String);
                Command.Parameters["@p_nombre"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_nombre"].Value = usuario.F_Nombre;

                Command.Parameters.Add("@p_apellidos", DbType.String);
                Command.Parameters["@p_apellidos"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_apellidos"].Value = usuario.Apellidos;

                Command.Parameters.Add("@p_primer_nombre", DbType.String);
                Command.Parameters["@p_primer_nombre"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_primer_nombre"].Value = usuario.P_PRIMER_NOMBRE;

                Command.Parameters.Add("@p_segundo_nombre", DbType.String);
                Command.Parameters["@p_segundo_nombre"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_segundo_nombre"].Value = usuario.P_SEGUNDO_NOMBRE;

                Command.Parameters.Add("@p_primer_apellido", DbType.String);
                Command.Parameters["@p_primer_apellido"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_primer_apellido"].Value = usuario.P_PRIMER_APELLIDO;

                Command.Parameters.Add("@p_segundo_apellido", DbType.String);
                Command.Parameters["@p_segundo_apellido"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_segundo_apellido"].Value = usuario.P_SEGUNDO_APELLIDO;

                Command.Parameters.Add("@p_id_territorial", DbType.Int32);
                Command.Parameters["@p_id_territorial"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_territorial"].Value = usuario.P_ID_TERRITORIAL;

                Command.Parameters.Add("@p_identificacion", DbType.String);
                Command.Parameters["@p_identificacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_identificacion"].Value = usuario.Identificacion;

                Command.Parameters.Add("@p_id_tipo_identificacion", DbType.Int32);
                Command.Parameters["@p_id_tipo_identificacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_identificacion"].Value = usuario.P_tipo_identificación;

                Command.Parameters.Add("@p_telefono_fijo", DbType.String);
                Command.Parameters["@p_telefono_fijo"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_telefono_fijo"].Value = usuario.P_telefono_fijo;

                Command.Parameters.Add("@p_telefono_movil", DbType.String);
                Command.Parameters["@p_telefono_movil"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_telefono_movil"].Value = usuario.P_telefono_movil;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = usuario.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@p_id_municipio", DbType.Int32);
                Command.Parameters["@p_id_municipio"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_municipio"].Value = usuario.P_ID_MUNICIPIO;

                Command.Parameters.Add("@p_fecha_ingreso", DbType.String);
                Command.Parameters["@p_fecha_ingreso"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_fecha_ingreso"].Value = usuario.F_FECHA_INGRESO;

                Command.Parameters.Add("@p_fecha_retiro", DbType.String);
                Command.Parameters["@p_fecha_retiro"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_fecha_retiro"].Value = usuario.F_FECHA_RETIRO;

                Command.Parameters.Add("@p_id_auditoria", DbType.String);
                Command.Parameters["@p_id_auditoria"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_auditoria"].Value = usuario.P_ID_AUDITORIA;

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

        //CAMBIO BRAYAN HERREÑO 18-03-2019
        /// Metodo encargado de realizar el reporte de ingreso general     
        public DataSet sp_reporte_usuarios(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_REPORTE_USUARIOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_fecha_inicio", DbType.String);
                Command.Parameters["@p_fecha_inicio"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_fecha_inicio"].Value = usuario.F_FECHA_INGRESO;

                Command.Parameters.Add("@p_fecha_final", DbType.String);
                Command.Parameters["@p_fecha_final"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_fecha_final"].Value = usuario.F_FECHA_RETIRO;

                Command.Parameters.Add("@p_id_dependencia", DbType.Int32);
                Command.Parameters["@p_id_dependencia"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_dependencia"].Value = usuario.P_ID_DEPENDENCIA;

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

        /// Método encargado de la administracion de roles de los usuarios       
        public int administrar_roles(Usuario usuario, int opcion)
        {
            int valor = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_USUARIOS_ROL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_USUARIOS_TIPO_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIOS_TIPO_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIOS_TIPO_USUARIO"].Value = usuario.P_ID_USUARIOS_TIPO_USUARIO;

                Command.Parameters.Add("@P_ID_ANO", DbType.String);
                Command.Parameters["@P_ID_ANO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ANO"].Value = usuario.P_ID_ANO;

                Command.Parameters.Add("@P_ID_TIPO_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_USUARIO"].Value = usuario.F_TIPO_USUARIO;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = usuario.F_ID_USUARIO;

                Command.Parameters.Add("@P_FECHA_INGRESO", DbType.String);
                Command.Parameters["@P_FECHA_INGRESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_INGRESO"].Value = usuario.F_FECHA_INGRESO;

                Command.Parameters.Add("@P_FECHA_RETIRO", DbType.String);
                Command.Parameters["@P_FECHA_RETIRO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_FECHA_RETIRO"].Value = usuario.F_FECHA_RETIRO;

                Command.Parameters.Add("@P_ID_ESTADO_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_USUARIO"].Value = usuario.P_id_estado_usuario;

                Command.Parameters.Add("@P_OBSERVACION", DbType.String);
                Command.Parameters["@P_OBSERVACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OBSERVACION"].Value = usuario.P_OBSERVACION;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.String);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = usuario.P_usuario_creacion;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.String);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = usuario.P_usuario_modifica;

                Command.Parameters.Add("@P_ID_TIPO_NOVEDAD", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_NOVEDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_NOVEDAD"].Value = usuario.F_ID_TIPO_NOVEDAD;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = usuario.F_id_persona;

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

        /// Método encargado de la administracion de roles de los usuarios       
        public DataSet administrar_roles_ds(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_USUARIOS_ROL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_USUARIOS_TIPO_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIOS_TIPO_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIOS_TIPO_USUARIO"].Value = usuario.P_ID_USUARIOS_TIPO_USUARIO;

                Command.Parameters.Add("@P_ID_ANO", DbType.String);
                Command.Parameters["@P_ID_ANO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ANO"].Value = usuario.P_ID_ANO;

                Command.Parameters.Add("@P_ID_TIPO_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_USUARIO"].Value = usuario.F_TIPO_USUARIO;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = usuario.F_ID_USUARIO;

                //Command.Parameters.Add("@P_FECHA_INGRESO", DbType.DateTime);
                //Command.Parameters["@P_FECHA_INGRESO"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_FECHA_INGRESO"].Value = usuario.F_FECHA_INGRESO;

                //Command.Parameters.Add("@P_FECHA_RETIRO", DbType.DateTime);
                //Command.Parameters["@P_FECHA_RETIRO"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_FECHA_RETIRO"].Value = usuario.F_FECHA_RETIRO;

                Command.Parameters.Add("@P_ID_ESTADO_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_ESTADO_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ESTADO_USUARIO"].Value = usuario.P_id_estado_usuario;

                Command.Parameters.Add("@P_OBSERVACION", DbType.String);
                Command.Parameters["@P_OBSERVACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OBSERVACION"].Value = usuario.P_OBSERVACION;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.String);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = usuario.P_usuario_creacion;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.String);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = usuario.P_usuario_modifica;

                Command.Parameters.Add("@P_ID_TIPO_NOVEDAD", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_NOVEDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_NOVEDAD"].Value = usuario.F_ID_TIPO_NOVEDAD;

                Command.Parameters.Add("@P_ID_PERSONA", DbType.Int32);
                Command.Parameters["@P_ID_PERSONA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERSONA"].Value = usuario.F_id_persona;

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

        // permite consultar los usuarios para asociarlos a un supervisor
        public DataSet Consultar_usuarios_por_supervisor(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_SUPERVISOR_ASIGNADOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = usuario.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = usuario.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = usuario.P_ID_SUPERVISOR;

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

        /// Método encargado de la administracion de la asignacion de los usuarios a un supervisor     
        public int Administrador_asignaciones(Usuario usuario, int opcion)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("ADMINISTRAR_ASIGNACION_PERSONAL_S", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_USUARIO_SUPERVISOR", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO_SUPERVISOR"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO_SUPERVISOR"].Value = usuario.P_ID_USUARIO_SUPERVISOR;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.String);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = usuario.F_ID_USUARIO;

                Command.Parameters.Add("@P_ID_SUPERVISOR", DbType.Int32);
                Command.Parameters["@P_ID_SUPERVISOR"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUPERVISOR"].Value = usuario.P_ID_SUPERVISOR;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = usuario.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = usuario.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.String);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = usuario.P_usuario_creacion;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.String);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = usuario.P_usuario_modifica;

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

        /// Brayan Herreño 31-07-2018
        /// Método encargado de los indicadores_ingresos_maariv      
        public DataSet Indicadores_ingresos_maariv_data(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_INDICADORES_INGRESO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        #endregion

    }
}