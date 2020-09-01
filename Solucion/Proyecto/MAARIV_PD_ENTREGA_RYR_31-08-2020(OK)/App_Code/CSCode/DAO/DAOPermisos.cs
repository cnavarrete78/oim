/*
 *******************************************************************************************
  PROGRAMA				: DAOPermisos.cs
  FECHA DE CREACION	    : Mayo 29 de 2010
  FECHA DE MODIFICACION : Mayo 29 de 2010
  VERSION               : 1.0
  AUTOR                 : Gustavo Adolfo Caicedo Viveros

 *******************************************************************************************

  CLASE			        : DAOPermisos
  RESPONSABILIDAD	    : Se encarga de gestionar los permisos
  COLABORACION		    : 
********************************************************************************************
*/

using System.Data;
using System.Collections.Generic;
using com.GACV.lgb.modelo;
using com.GACV.lgb.modelo.usuario;
using System.Data.Common;
using System.Data.SqlClient;

namespace com.GACV.lgb.persistencia.dao
{
    /// <summary>
    /// Summary description for DAOPermisos
    /// </summary>
    public class DAOPermisos
    {
        /// <summary>
        /// Método constructor de la clase
        /// </summary>
        public DAOPermisos()
        {
        }

        /// <summary>
        /// Obtener los permisos de un tipo de usuario
        /// </summary>
        /// <param name="id_tipo_part">Identificador del tipo de usuario</param>
        /// <returns>Todos los permisos asociados a un tipo de usuario</returns>
        public DataSet permisos_tipo_usuario(int id_tipo_usuario)
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_SEGURIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@id_tipo_usuario", DbType.Int32);
                Command.Parameters["@id_tipo_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_tipo_usuario"].Value = id_tipo_usuario;

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
        
        /// <summary>
        /// Obtener todos los items o permisos del menú
        /// </summary>
        /// <returns>Colección de todos los permisos del menú</returns>
        public DataSet Permisos()
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_PERMISOS", con);
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

        /// <summary>
        /// Obtener los módulos del menú principal
        /// </summary>
        /// <returns>Los modulos asociados al menú principal</returns>
        public DataSet Permisos_modulo()
        {
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_PERMISOS_MODULO", con);
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

        /// <summary>
        /// Guardar los permisos de un tipo de usuario
        /// </summary>
        /// <param name="permisos">Colección de permisos asignados</param>
        public void Permisos_guardar(PermisoRol permisos)
        {
            int valor = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                //----------- realiza el borrado de los permisos ---------------------//
                SqlCommand Command = new SqlCommand("ADMINISTRAR_PERMISOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_tipo_usuario", DbType.Int32);
                Command.Parameters["@p_id_tipo_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_usuario"].Value = permisos.Id_rol;

                Command.Parameters.Add("@p_id_permiso", DbType.Int32);
                Command.Parameters["@p_id_permiso"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_permiso"].Value = 0;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = 3;

                valor = Command.ExecuteNonQuery();                

                // ------ Creara los nuevos permisos para el tipo de usuario seleccionado -----///
                List<Permiso> p = permisos.Permisos;

                for (int i = 0; i < p.Count; i++)
                {
                    if (p[i].Estado)
                    {
                        SqlCommand Command2 = new SqlCommand("ADMINISTRAR_PERMISOS", con);
                        Command2.CommandType = CommandType.StoredProcedure;
                        Command2.Connection = con;

                        Command2.Parameters.Add("@p_id_tipo_usuario", DbType.Int32);
                        Command2.Parameters["@p_id_tipo_usuario"].Direction = ParameterDirection.Input;
                        Command2.Parameters["@p_id_tipo_usuario"].Value = permisos.Id_rol;

                        Command2.Parameters.Add("@p_id_permiso", DbType.Int32);
                        Command2.Parameters["@p_id_permiso"].Direction = ParameterDirection.Input;
                        Command2.Parameters["@p_id_permiso"].Value = p[i].Id_permiso;

                        Command2.Parameters.Add("@p_opcion", DbType.Int32);
                        Command2.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                        Command2.Parameters["@p_opcion"].Value = 1;

                        valor = Command2.ExecuteNonQuery();
                        
                    }
                }

                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }           
        }



        /// <summary>
        /// Obtener los permisos de un tipo de participante
        /// </summary>
        /// <param name="id_tipo_part">Identificador del tipo de participante</param>
        /// <returns>Todos los permisos asociados a un tipo de participante</returns>
        public DataTable getURLPermisos(string id_tipo_part, string urlPeticion)
        {
            // ConexionDB conn = new ConexionDB();
            DataTable tab = null;
            //string query = "";
            //conn.conectar();
            //query = "select p.Url_Permiso from WEB_S_PERMISOS_TIPO_USUARIO pt, S_Permisos p " +
            //        " where p.Id_Permiso = pt.Id_Permiso AND pt.id_tipo_usuario =" + id_tipo_part + " AND p.url_permiso LIKE '%" + urlPeticion + "%'";

            //tab = conn.ejecutarQuerySelect(query);

            return tab;
        }

        internal DataSet getPermisosTipoParticipanteSIC(string id_part)
        {            
            DataSet tabPermisos = null;
           
            //Database db = DatabaseFactory.CreateDatabase("cadenaConexion2");
            //DbCommand dbCommand = db.GetSqlStringCommand("SELECT WEB_S_PERMISOS_TIPO_USUARIO.Id_Permiso, web_S_Permisos.Url_Permiso, web_S_Permisos.Id_Padre, web_S_Permisos.Nombre_Permiso, " +
            //                        "web_S_Permisos.Descripcion_Permiso, web_S_Permisos.Icono, WEB_S_PERMISOS_TIPO_USUARIO.id_tipo_usuario " +
            //                       " FROM web_S_Permisos INNER JOIN WEB_S_PERMISOS_TIPO_USUARIO ON web_S_Permisos.Id_permiso = WEB_S_PERMISOS_TIPO_USUARIO.Id_Permiso " +
            //                        " WHERE WEB_S_PERMISOS_TIPO_USUARIO.id_tipo_usuario = " + id_part + " order by web_s_permisos.id_permiso asc");
            //tabPermisos = db.ExecuteDataSet(dbCommand);           
            return tabPermisos;             
        }
        
        //Insertar permiso para ususario por primera vez
        public int insert_permisos_usuario_uno(int opcion)
        {
            int valor =1;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();
                SqlCommand Command = new SqlCommand("sp_permiso_inicial", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                valor = Command.ExecuteNonQuery();

            }
             catch (System.Data.SqlClient.SqlException ex)
             {
                 //MsgBox(ex.Message);
             }

            return valor;
        }
    
    }
}