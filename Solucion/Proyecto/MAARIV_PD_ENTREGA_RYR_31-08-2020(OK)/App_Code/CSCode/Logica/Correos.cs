using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

//using Microsoft.Reporting.WebForms;
using com.GACV.lgb.modelo.email;
using System.Net.Mail;
using com.logica.notificaciones;

/// <summary>
/// Descripción breve de Correos
/// </summary>
/// 

namespace com.logica.correo
{
    public class Correos
    {
        private Mail mail = new Mail();
        private SmtpClient clienteSmtp = new SmtpClient();

        #region DECALRACION DE VARIABLES
        //variables caso 0
        private string id_actividad;
        private string estado_anterior;
        private string estado_actual;
        private string observaciones;
        private string nombre_modulo;
        //variables caso 1
        private string correo;
        private string usuario;
        private string password_desencriptado;
        #endregion

        #region GET SET
        public string Id_actividad
        {
            get
            {
                return this.id_actividad;
            }
            set
            {
                this.id_actividad = value;
            }
        }
        public string Estado_anterior
        {
            get
            {
                return this.estado_anterior;
            }
            set
            {
                this.estado_anterior = value;
            }
        }
        public string Estado_actual
        {
            get
            {
                return this.estado_actual;
            }
            set
            {
                this.estado_actual = value;
            }
        }
        public string Observaciones
        {
            get
            {
                return this.observaciones;
            }
            set
            {
                this.observaciones = value;
            }
        }
        public string Nombre_modulo
        {
            get
            {
                return this.nombre_modulo;
            }
            set
            {
                this.nombre_modulo = value;
            }
        }
        public string Correo
        {
            get
            {
                return this.correo;
            }
            set
            {
                this.correo = value;
            }
        }
        public string Usuario
        {
            get
            {
                return this.usuario;
            }
            set
            {
                this.usuario = value;
            }
        }
        public string Password_desencriptado
        {
            get
            {
                return this.password_desencriptado;
            }
            set
            {
                this.password_desencriptado = value;
            }
        }
        #endregion

        /**
     * Constructor de correos
     */
        public Correos()
        {
            this.mail.F_USUARIO = System.Configuration.ConfigurationManager.AppSettings["F_USUARIO"];
            this.mail.F_TO = System.Configuration.ConfigurationManager.AppSettings["F_TO"];
            this.mail.F_TO_PASSWORD = System.Configuration.ConfigurationManager.AppSettings["F_TO_PASSWORD"];
            this.mail.F_HOST = System.Configuration.ConfigurationManager.AppSettings["F_HOST"];
            this.mail.F_PUERTO = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["F_PUERTO"]);
        }

        public void CrearCorreo(string asunto, string[] datos, int opcion)
        {
            this.mail.F_ASUNTO = asunto;
            this.mail.F_MENSAJE = Cuerpo_Correo_Generar(datos, opcion);
        }

        public int EnviarCorreo(List<string> email)
        {
            //NOTIFICACION CREAR PROCEDIMIENTO
            DAONotificaciones NOTI = new DAONotificaciones();
            NOTI.P_ASUNTO = this.mail.F_ASUNTO;
            NOTI.P_MENSAJE = (this.mail.F_MENSAJE);
            NOTI.P_ID_ACTIVIDAD = Convert.ToInt32(this.id_actividad);
            NOTI.P_ID_USUARIO_EMISOR = NOTI.getId_usuario(Convert.ToString(HttpContext.Current.Session["email"]));
            NOTI.P_LINK = NOTI.getLink(Convert.ToInt32(this.id_actividad));
            NOTI.P_ESTADO = 0;

            this.mail.F_FROM = email[0]; //enviar a este mail
            int valor = 0;
            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                //msg.To.Add(new MailAddress(this.mail.F_FROM));
                for (int i = 0; i < email.Count; i++)
                {
                    msg.To.Add(new MailAddress(email[i]));
                    //guardar la notificacion a cada uno de los interesados
                    NOTI.P_ID_USUARIO_RECEPTOR = NOTI.getId_usuario(Convert.ToString(email[i]));
                    NOTI.Notificaciones_Store(NOTI, 1); //guardar notificaciones
                }
                msg.From = new MailAddress(this.mail.F_TO, this.mail.F_USUARIO, System.Text.Encoding.UTF8);
                msg.Subject = this.mail.F_ASUNTO;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = this.mail.F_MENSAJE;
                msg.IsBodyHtml = true;
                msg.BodyEncoding = System.Text.Encoding.UTF8;

                this.clienteSmtp.Credentials = new System.Net.NetworkCredential(this.mail.F_TO, mail.F_TO_PASSWORD);
                this.clienteSmtp.Port = this.mail.F_PUERTO;
                this.clienteSmtp.Host = this.mail.F_HOST;
                //this.clienteSmtp.EnableSsl = false;
                this.clienteSmtp.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["F_EnableSsl"]);

                try
                {
                    this.clienteSmtp.Send(msg);
                    valor = 1;
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    valor = 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return valor;
        }

        public string Cuerpo_Correo_Generar(string[] datos, int opcion)
        {
            string cuerpo = Encabezado();

            //switch opcion para determinar como es el cuerpo del correo
            switch (opcion)
            {
                #region envio de actualizaciones en jornadas/actividades
                case 0:
                    /*
                     * DATOS[]
                     * 0-id_actividad 
                     * 1-estado_anterior 
                     * 2-estado_actual 
                     * 3-observaciones 
                     * 4-nombre_modulo
                     */
                    cuerpo += "<body>" +
                            "<div style='padding: 10px;margin:10px;font-family:'Montserrat', 'Courier New', Courier, monospace;'>" +
                                "<h1>Actualización modúlo de " + this.nombre_modulo + "</h1>" +
                                "<p>" +
                                    "Cordial saludo <strong>Grupo de trabajo modúlo " + this.nombre_modulo + "</strong>" +
                                    "<br><br>" +
                                    "<h3>Modificación Estado</h3>" +
                                    "<br><br>" +
                                    "Al desarrollo de la actividad con ID <strong>\"" + this.id_actividad + "\"</strong>, se realizó un cambio de estado <strong>" + "</strong> " +
                                    " que se ve reflejado en la siguiente tabla: " +
                                    "<br><br>" +
                                    "<table class='blueTable'>" +
                                        "<tr>" +
                                            "<th>Estado Anterior</th>" +
                                            "<th>Estado Actual</th>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<th>" + this.estado_anterior + "</th>" +
                                            "<th>" + this.estado_actual + "</th>" +
                                        "</tr>" +
                                    "</table>" +
                                    "<strong>Observaciones: </strong><br>" + this.observaciones +
                                    "Usted puede ver esta información detallada en <a href='https://maariv.unidadvictimas.gov.co/'>MAARIV</a>," +
                                    "la cual se encuentra en el submenu " + this.nombre_modulo + "." +
                                    "</p>" +
                            "</div>";
                    cuerpo += Pie();
                    break;
                #endregion

                #region envio de reestablecimiento de contraseña
                case 1: //
                    /**
                     * DATOS[]
                     * 0-correo
                     * 1-usuario
                     * 2-password_desencriptado
                     */
                    cuerpo += "<body>" +
                        "<div style='width: 100%;padding: 10px;background: white;'>" +
                            "<div style='font-family: 'Montserrat', sans-serif;padding: 10px;padding-left: 10%;padding-right: 10%; width: 80%;text-align: justify;'>" +
                                "<h4>Formato de restablecimiento contraseña:</h4>" +
                                "<p>Buen día<br><br>" +
                                "Cordial Saludo <strong>" + this.correo + "</strong><br><br>" +
                                "Ingrese al siguiente enlace para cambiar su contraseña para el usuario <strong>" + this.usuario + "</strong>.<br>" +
                                "Enlace: <a href='https://maariv.unidadvictimas.gov.co/'>maariv</a><br><br>" +
                                "USUARIO: <strong>" + this.usuario + "</strong><br><br>" +
                                "PASSWORD: <strong>" + this.password_desencriptado + "</strong><br><br>";
                    cuerpo += Pie();

                    break;
                #endregion

                #region Colectiva email (guarda estado dias)
                /*
                * DATOS[]
                * 0-sujeto_colectiva 
                * 1-id_actividad_dia 
                * 2-fase 
                * 3-dia_actividad_estado 
                * 4-LD_Estado_dia
                */
                case 2: //
                    cuerpo += "<body>" +
                                    "<div style='padding: 10px;margin:10px;font-family:'Montserrat', 'Courier New', Courier, monospace;'>" +
                                        "<h1>Actualización modúlo de colectiva</h1>" +
                                        "<p>" +
                                            "Cordial saludo <strong>Grupo de trabajo modúlo en colectiva</strong>" +
                                            "<br><br>" +
                                            "<h3>Modificación Estado</h3>" +
                                            "<br><br>" +
                                            "Al sujeto de reparación colectiva <strong>\"" + datos[0] + "\"</strong>, se realizó un cambio de estado en la actividad <strong>" + datos[1] + "</strong> " +
                                            "de la fase <strong>" + datos[2] + "</strong> que se ve reflejado en la siguiente tabla: " +
                                            "<br><br>" +
                                            "<table class='blueTable'>" +
                                                "<tr>" +
                                                    "<th>Estado Anterior</th>" +
                                                    "<th>Estado Actual</th>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<th>" + datos[3] + "</th>" +
                                                    "<th>" + datos[4] + "</th>" +
                                                "</tr>" +
                                            "</table>" +
                                            "Usted puede ver esta información detallada en <a href='https://maariv.unidadvictimas.gov.co/modulos/Colectiva/Planes_RC.aspx'>MAARIV</a>," +
                                            "la cual se encuentra en el submenu Programa de reparación colectiva del menú Rep.Colectiva." +
                                         "</p>" +
                                    "</div>";
                    cuerpo += Pie();
                    break;
                #endregion

                #region Colectiva email (guarda bitacora)
                /*
                * DATOS[]
                * 0-sujeto_colectiva 
                * 1-actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE 
                * 2-usuario 
                * 3-actividad_detalle.P_ID_ACTIVIDAD 
                * 4-fase
                */
                case 3: //
                    cuerpo += "<body>" +
                        "<div style='padding: 10px;margin:10px;font-family:'Montserrat', 'Courier New', Courier, monospace;'>" +
                            "<h1>Actualización modúlo de colectiva</h1>" +
                            "<p>" +
                                "Cordial saludo <strong>Grupo de trabajo modúlo en colectiva</strong>" +
                                "<br><br>" +
                                "<h3>Bitácora</h3>" +
                                "<br><br>" +
                                "Al sujeto de reparación colectiva <strong>\"" + datos[0] + "\"</strong>, se agrego una observación :<ul><li>" +
                                datos[1] +
                                " <small>(\"" + datos[2] + "\")</small></li></ul> <br>A la bitácora correspondiante a la actividad <strong>" +
                                datos[3] + "</strong> de la FASE: <strong>\"" + datos[4] + "\"</strong>" +
                                "<br><br>" +

                                "Usted puede ver esta información detallada en <a href='https://maariv.unidadvictimas.gov.co/modulos/Colectiva/Planes_RC.aspx'>MAARIV</a>," +
                                "la cual se encuentra en el submenu Programa de reparación colectiva del menú Rep.Colectiva." +
                             "</p>" +
                        "</div>";
                    cuerpo += Pie();
                    break;
                #endregion

                #region Colectiva email (crear archivo)
                /*
                * DATOS[]
                * 0-sujeto_colectiva 
                * 1-adjuntar_archivos.P_ID_ACTIVIDAD_DIA 
                * 2-LD_tipo_archivo.SelectedItem 
                * 3-adjuntar_archivos.P_FECHA_EXPEDICION 
                * 4-adjuntar_archivos.P_PERSONAS
                 * 5-adjuntar_archivos.P_NOMBRE_ARCHIVO
                 * 6-adjuntar_archivos.P_DESCRIPCION
                 * 7-Convert.ToString(ViewState["fase"])
                 * 8-Convert.ToString(Session["usuario"])
                */
                case 4: //
                    cuerpo += "<body>" +
                                    "<div style='padding: 10px;margin:10px;font-family:'Montserrat', 'Courier New', Courier, monospace;'>" +
                                        "<h1>Actualización modúlo de colectiva</h1>" +
                                        "<p>" +
                                            "Cordial saludo <strong>Grupo de trabajo modúlo en colectiva</strong>" +
                                            "<br><br>" +
                                            "<h3>Adjunto nuevo documento</h3>" +
                                            "<br><br>" +
                                            " Al sujeto de reparación colectiva <strong>\"" + datos[0] +
                                            "\"</strong>, se realizó un cargue de información en el sistema, correspondiente a la acción <strong>" + datos[1] +
                                            "</strong> en donde se adiciono un archivo de tipo <strong>" + datos[2] + "</strong> con fecha de ejecucion ("
                                            + datos[3] + ")" + " junto con un número de participantes <strong>" + datos[4] +
                                            "</strong>  " +
                                            ".<br><br>" +
                                            "Los datos trazados en esta acción son:<br><br>" +
                                            "<table class='blueTable'>" +
                                            "    <tr>" +
                                                    "<th>Nombre del archivo</th>" +
                                                    "<th>Descripción</th>" +
                                                    "<th>Nombre Fase</th>" +
                                                    "<th>Usuario creación </th>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<td>" + datos[5] + "</td>" +
                                                    "<td>" + datos[6] + "</td>" +
                                                    "<td>\"" + datos[7] + "\"</td>" +
                                                    "<td>\"" + datos[8] + "\"</td>" +
                                                "</tr>" +
                                            "</table> " +
                                            "<br><br>" +
                                            "Usted puede ver esta información detallada en <a href='https://maariv.unidadvictimas.gov.co/'>MAARIV</a>," +
                                            "la cual se encuentra en el submenu Programa de reparación colectiva del menú Rep.Colectiva." +
                                         "</p>" +
                                     "</div>";
                    cuerpo += Pie();
                    break;
                #endregion

                #region Colectiva email (guarda estado fase)
                /*
                * DATOS[]
                * 0-sujeto_colectiva 
                * 1-id_actividad
                * 2-fase 
                * 3-dia_actividad_estado 
                * 4-LD_Estado_dia
                */
                case 5: //
                    cuerpo += "<body>" +
                                    "<div style='padding: 10px;margin:10px;font-family:'Montserrat', 'Courier New', Courier, monospace;'>" +
                                        "<h1>Actualización modúlo de colectiva</h1>" +
                                        "<p>" +
                                            "Cordial saludo <strong>Grupo de trabajo modúlo en colectiva</strong>" +
                                            "<br><br>" +
                                            "<h3>Modificación Estado</h3>" +
                                            "<br><br>" +
                                            "Al sujeto de reparación colectiva <strong>\"" + datos[0] + "\"</strong>, se realizó un cambio de estado en la fase <strong>" + datos[2] + "</strong> que se ve reflejado en la siguiente tabla: " +
                                            "<br><br>" +
                                            "<table class='blueTable'>" +
                                                "<tr>" +
                                                    "<th>Estado Anterior</th>" +
                                                    "<th>Estado Actual</th>" +
                                                "</tr>" +
                                                "<tr>" +
                                                    "<th>" + datos[3] + "</th>" +
                                                    "<th>" + datos[4] + "</th>" +
                                                "</tr>" +
                                            "</table>" +
                                            "<br><br>" +
                                             "OBSERVACIONES: <strong>\"" + datos[5] + "\"</strong>" +
                                            "Usted puede ver esta información detallada en <a href='https://maariv.unidadvictimas.gov.co/modulos/Colectiva/Planes_RC.aspx'>MAARIV</a>," +
                                            "la cual se encuentra en el submenu Programa de reparación colectiva del menú Rep.Colectiva." +
                                         "</p>" +
                                    "</div>";
                    cuerpo += Pie();
                    break;
                #endregion

                #region Invitacion Capacitacion
                /*
                * DATOS[]
                * 0-Nombre_capacitacion 
                * 1-id_actividad
                * 2-fase 
                * 3-dia_actividad_estado 
                * 4-LD_Estado_dia
                */
                case 6: //
                    cuerpo += "<body>"+
                                    "<div style='padding: 10px;margin:10px;font-family:´Montserrat´, ´Courier New´, Courier, monospace;' >" +
                                        "<center>"+
                                            "<div>"+
                                                "<img style='width: 300px;' src='https://maariv.unidadvictimas.gov.co/Img/capacita.png' />" +
                                            "</div>" +
                                            "<h1> Invitación Capacitación </h1>" +

                                            "<p>" +
                                                "Cordial saludo<strong> en coordinación con el equipo de control y seguimiento de la subdirección de reparación informa que:</strong>" +
                                                "<br/><br/>" +
                                                "<h3> Se realizará la capacitación del módulo "+datos[0]+"</h3>" +
                                                "<br><br>" +
                                                "MAARIV presentará esta capacitación en el modulo de capacitaciones de la herramienta, ubicado en el menú de perfil. Esperamos la participación de "+
                                                "todos y el diligenciamiento de sus respuestas." +
                                            "</p>"+
                                        "</center>" +
                                    "</div>" ;
                    cuerpo += Pie();
                    break;
                #endregion

                #region Recordatorio Capacitacion
                /*
                * DATOS[]
                * 0-Nombre_capacitacion 
                * 1-id_actividad
                * 2-fase 
                * 3-dia_actividad_estado 
                * 4-LD_Estado_dia
                */
                case 7: //
                    cuerpo += "<body>" +
                                    "<div style='padding: 10px;margin:10px;font-family:´Montserrat´, ´Courier New´, Courier, monospace;' >" +
                                        "<center>" +
                                            "<div>" +
                                                "<img style='width: 300px;' src='https://maariv.unidadvictimas.gov.co/Img/recordatorio.png' />" +
                                            "</div>" +
                                            "<h1> Recordatorio Capacitación </h1>" +

                                            "<p>" +
                                                "Cordial saludo<strong> en coordinación con el equipo de control y seguimiento de la subdirección de reparación informa que:</strong>" +
                                                "<br/><br/>" +
                                                "<h3>Aún no has entrado a la capacitación del módulo " + datos[0] + "</h3>" +
                                                "<br><br>" +
                                                "MAARIV presentará esta capacitación en el modulo de capacitaciones de la herramienta, ubicado en el menú de perfil. Esperamos la participación de " +
                                                "todos y el diligenciamiento de sus respuestas." +
                                            "</p>" +
                                        "</center>" +
                                    "</div>";
                    cuerpo += Pie();
                    break;
                    #endregion
            }
            return cuerpo;
        }

        #region ENCABEZADO y PIE
        /**
     * REFERENCIAS DE PIE y ENCABEZADO DE PAGINAS
     */
        public string Encabezado()
        {
            string head = "";
            head = "<html><head><meta > <link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet'><style>table.blueTable {border: 1px solid #1C6EA4;" +
                    "background-color: #EEEEEE;width: 100%;text-align: left;border-collapse: collapse;}" +
                    "table.blueTable td, table.blueTable th {border: 1px solid #FFFFFF;padding: 3px 2px;}" +
                    "table.blueTable tbody td {font-size: 13px;}" +
                    "table.blueTable tr:nth-child(even) {background: #D0E4F5;}" +
                    "table.blueTable thead {}" +
                    "table.blueTable thead th {font-size: 15px;font-weight: bold;color: #000000;}" +
                    "table.blueTable tfoot {font-size: 14px;font-weight: bold;color: #FFFFFF;}" +
                    "table.blueTable tfoot td {font-size: 14px;}" +
                    "table.blueTable tfoot .links {text-align: right;}" +
                    "table.blueTable tfoot .links a{display: inline-block;background: #1C6EA4;color: #FFFFFF;padding: 2px 8px;border-radius: 5px;}" +
                    "</style></head>";
            return head;
        }

        public string Pie()
        {
            string cuerpo = "<br><br>Este correo es enviado de manera automática por el sistema, por favor no contestar.<br>" +
                            "Para mayor información del manejo de la herramienta realice la consulta por el correo controlseguimientodr@unidadvictimas.gov.co<br><br>" +
                            "Agradecemos su atención y esperamos que esta herramienta les resulte útil.<br><br>" +
                            "Quedamos atentos<br>" +
                                "Muchas gracias<br><br>" +
                                "<strong>Equipo Control y Seguimiento</strong><br>" +
                                "Dirección de Reparación- Control y Seguimiento<br>" +
                                "Unidad para las Victimas<br>" +
                                "Carrera 85D No. 46A-65 Piso 3<br>" +
                                "Complejo Logístico San Cayetano, Bogotá</p>" +
                            "</div>" +
                            "<div style='width: 100%;'>" +
                                "<img style='width: 50%;' src='https://www.unidadvictimas.gov.co/sites/default/files/logo.png'>" +
                            "</div>" +
                        "</div>" +
                    "</body>" +
                    "</html>";
            return cuerpo;
        }

        #endregion

    }
}
