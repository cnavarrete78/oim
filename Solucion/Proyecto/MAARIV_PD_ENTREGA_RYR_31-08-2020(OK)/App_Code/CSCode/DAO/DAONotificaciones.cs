using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.persistencia.fachada;

/// <summary>
/// Descripción breve de Notificaciones
/// </summary>
/// 
namespace com.logica.notificaciones
{
    public class DAONotificaciones
    {
        #region DECLARACION DE VARIABLES
        private int     ID_NOTIFICACION = 0;
        private string  ASUNTO = "";
        private string  MENSAJE = "";
        private int     ID_USUARIO_RECEPTOR = 0;
        private int     ID_USUARIO_EMISOR = 0;
        private int     ID_ACTIVIDAD = 0;
        private string  LINK = "";
        private int     ESTADO = 0;
        #endregion

        #region GET y SET
        public int P_ID_NOTIFICACION
        {
            get
            {
                return this.ID_NOTIFICACION;
            }
            set
            {
                this.ID_NOTIFICACION = value;
            }
        }
        public string P_ASUNTO
        {
            get
            {
                return this.ASUNTO;
            }
            set
            {
                this.ASUNTO = value;
            }
        }
        public string P_MENSAJE
        {
            get
            {
                return this.MENSAJE;
            }
            set
            {
                this.MENSAJE = value;
            }
        }
        public int P_ID_USUARIO_RECEPTOR
        {
            get
            {
                return this.ID_USUARIO_RECEPTOR;
            }
            set
            {
                this.ID_USUARIO_RECEPTOR = value;
            }
        }
        public int P_ID_USUARIO_EMISOR
        {
            get
            {
                return this.ID_USUARIO_EMISOR;
            }
            set
            {
                this.ID_USUARIO_EMISOR = value;
            }
        }
        public int P_ID_ACTIVIDAD
        {
            get
            {
                return this.ID_ACTIVIDAD;
            }
            set
            {
                this.ID_ACTIVIDAD = value;
            }
        }
        public string P_LINK
        {
            get
            {
                return this.LINK;
            }
            set
            {
                this.LINK = value;
            }
        }
        public int P_ESTADO
        {
            get
            {
                return this.ESTADO;
            }
            set
            {
                this.ESTADO = value;
            }
        }
        #endregion

        public DAONotificaciones()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public DAONotificaciones(  int     ID_NOTIFICACION,
                                string  ASUNTO,
                                string  MENSAJE,
                                int     ID_USUARIO_RECEPTOR,
                                int     ID_USUARIO_EMISOR,
                                int     ID_ACTIVIDAD,
                                string  LINK,
                                int     ESTADO)
        {
            this.ID_NOTIFICACION = ID_NOTIFICACION;
            this.ASUNTO = ASUNTO;
            this.MENSAJE = MENSAJE;
            this.ID_USUARIO_RECEPTOR = ID_USUARIO_RECEPTOR;
            this.ID_USUARIO_EMISOR = ID_USUARIO_EMISOR;
            this.ID_ACTIVIDAD = ID_ACTIVIDAD;
            this.LINK = LINK;
            this.ESTADO = ESTADO;
        }


        public DataSet Notificaciones_Store(DAONotificaciones NOTI, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_NOTIFICACIONES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_NOTIFICACION", DbType.Int32);
                Command.Parameters["@P_ID_NOTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOTIFICACION"].Value = Convert.ToString(NOTI.P_ID_NOTIFICACION);

                Command.Parameters.Add("@P_ASUNTO", DbType.String);
                Command.Parameters["@P_ASUNTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ASUNTO"].Value = NOTI.P_ASUNTO;

                Command.Parameters.Add("@P_MENSAJE", DbType.String);
                Command.Parameters["@P_MENSAJE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_MENSAJE"].Value = NOTI.P_MENSAJE;

                Command.Parameters.Add("@P_ID_USUARIO_RECEPTOR", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO_RECEPTOR"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO_RECEPTOR"].Value = Convert.ToString(NOTI.P_ID_USUARIO_RECEPTOR);

                Command.Parameters.Add("@P_ID_USUARIO_EMISOR", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO_EMISOR"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO_EMISOR"].Value = Convert.ToString(NOTI.P_ID_USUARIO_EMISOR);

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = Convert.ToString(NOTI.P_ID_ACTIVIDAD);

                Command.Parameters.Add("@P_LINK", DbType.String);
                Command.Parameters["@P_LINK"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_LINK"].Value = Convert.ToString(NOTI.P_LINK);

                Command.Parameters.Add("@P_ESTADO", DbType.Int32);
                Command.Parameters["@P_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO"].Value = Convert.ToString(NOTI.P_ESTADO);

                Command.Parameters.Add("@P_opcion", DbType.Int32);
                Command.Parameters["@P_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_opcion"].Value = Convert.ToString(opcion);

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

        public int getId_usuario(string correo)
        {
            int ID_USUARIO = 0;
            DataSet ds = new DataSet();
            Usuario usuario = new Usuario();
            usuario.Email = correo;
            ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 23);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                ID_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["ID_USUARIO"]);
            }

            return ID_USUARIO;
        }

        public string getLink(int id_actividad)
        {
            string link = "";

            if(id_actividad == 0){ //ip no autorizada
                
            }
            else if(id_actividad == 1){ //restablecimiento contraseña

            }
            else
            {

            }

            return link;
        }

        public string printLabel(DataSet ds_noti)
        {
            string label = "";
            for (int i = 0; i <= ds_noti.Tables[0].Rows.Count - 1; i++)
            {
                label += "<li><strong>ID: " +
                        ds_noti.Tables[0].Rows[i]["ID_ACTIVIDAD"].ToString()
                        + " <br><small></strong><a href='/Modulos/Seguridad/Notificaciones.aspx?id_notificacion=" + ds_noti.Tables[0].Rows[i]["ID_NOTIFICACION"].ToString() + "'>" +
                        ds_noti.Tables[0].Rows[i]["ASUNTO"].ToString().Substring(0,20)
                        + "... <br><label>  "+
                        ds_noti.Tables[0].Rows[i]["FECHA_CREACION"].ToString()
                        +"</label></small></a></li>";
            }
            return label;
        }

    }
}
