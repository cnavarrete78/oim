/*
 *******************************************************************************************
  PROGRAMA				: Restablecer_contrasena.aspx.cs
  FECHA DE CREACION	    : 01-06-2013
  FECHA DE MODIFICACION : 28-03-2017
  AUTHOR MODIFICACION   : Fredy Alejandro Moreno Castro
  FECHA DE MODIFICACION : 16-06-2020
  VERSION               : 1.2
  AUTOR                 : Gustavo Adolfo Caicedo Viveros
                          Control y seguimiento

 *******************************************************************************************

  CLASE			        : Restablecer_contrasena.cs
  RESPONSABILIDAD	    : Se encarga de restablecer la contraseña de los usuarios
  COLABORACION		    : JULIAN A. BOCANEGRA M.
********************************************************************************************
*/

using System;
using System.Data;
using System.Web.UI;
using com.GACV.lgb.persistencia.fachada;
using com.GACV.lgb.modelo.email;
using System.Net.Mail;
using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.modelo.usuario;

public partial class Restablecer_contrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btnAceptar);
    }

    #region MENSAJES

        private void Mensajes(string mensaje, int opc)
        {
            string script = "";
            switch (opc)
            {
                //string script = @"<script type='text/javascript'> alert('" + mensaje + "'); </script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //string script = @"<script type='text/javascript'> <a href='http://tu-sitio.com' onclick='javascript:alert('Mensaje');'></a>";

                case 0:
                    script = @"<script type='text/javascript'> alert('" + mensaje + "'); </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;

                case 1:
                    script = @"<script type='text/javascript'> alert('" + mensaje + "');"
                             + "window.location.href = 'mailto:maariv@unidadvictimas.gov.co?subject=Restablecer contraseña MAARIV';" + "</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;

                case 2:
                    script = @"<script type='text/javascript'> alert('" + mensaje + "'); window.location = './Presentacion.aspx'; </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;
            }
        }

    #endregion


    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        string Mensaje = "";

        if (this.ValidarExisteDatoConsulta())
        {            
            FachadaPersistencia objFachada = new FachadaPersistencia();
            Usuario usuario = new Usuario();

            usuario.Identificacion = this.TextBoxUsuario.Text.Trim();
            usuario.Email = this.TextBoxEmail.Text.Trim();

            DataSet ds = new DataSet();
            ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 4);
          
            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                // genera un password aleatorio para la nueva contraseña
                string password = FachadaPersistencia.getInstancia().contraseña_randomica();
                string password_encriptado = FachadaPersistencia.getInstancia().Encriptar(password, System.Configuration.ConfigurationManager.AppSettings["encryptPass"]);
               
                usuario.Password = password_encriptado;
                usuario.Identificacion = Convert.ToString(ds.Tables[0].Rows[0]["identificacion"]);
                usuario.Login = Convert.ToString(ds.Tables[0].Rows[0]["u_login"]);

                // realiza el cambio de la contraseña
                //int res = FachadaPersistencia.getInstancia().administrar_usuario(usuario, 5);
                int valor_mail = Enviar_correo_cambio_contrasena(ds.Tables[0].Rows[0]["u_login"].ToString(), password_encriptado, ds.Tables[0].Rows[0]["email"].ToString());

                if (valor_mail == 1)
                {
                    int res = FachadaPersistencia.getInstancia().administrar_usuario(usuario, 5);

                    if ((res != 0) && (valor_mail > 0))
                    {
                        Mensajes("La contraseña fue modificada y reenviada exitosamente. \\nPor favor revise su correo registrado en MAARIV, e inicie sesión nuevamente con la contraseña nueva generada. \\n\\nGracias.", 2);
                    }
                    else
                    {
                        Mensajes("La contraseña no pudo ser restablecida", 0);
                    }
                }
                else 
                {
                    //Mensajes("Error al enviar el mensaje al correo, por favor solicite el cambio de contraseña al mail: <a href='mailto:maariv@unidadvictimas.gov.co'>Maariv</a> </br></br>Gracias.");
                    Mensajes("Error al enviar el mensaje al correo, por favor solicite el cambio de contraseña al mail: maariv@unidadvictimas.gov.co \\n\\nGracias.", 1);
                }
            }           
            else
            {
                Mensajes("Los datos no corresponden a usuarios del sistema.", 0);
            }            
        }
        else
        {
            Mensajes("Debe proporcionar por lo menos un dato para realizar la recuperación de la contraseña", 0);
        }

        this.TextBoxEmail.Text = "";
        this.TextBoxUsuario.Text = "";
        this.LabelMensaje.Text = Mensaje;
    }


    // PERMITE ENVIAR UN CORREO CON LOS DATOS DEL RESTABLECIMIENTO DE LA CONTRASEÑA
    public int Enviar_correo_cambio_contrasena(string usuario, string pass, string correo)
    {
        Mail mail = new Mail();
       
        mail.F_ASUNTO = "RESTABLECIMIENTO DE CONTRASEÑA";
        mail.F_USUARIO = System.Configuration.ConfigurationManager.AppSettings["F_USUARIO"];
        mail.F_TO = System.Configuration.ConfigurationManager.AppSettings["F_TO"];
        mail.F_TO_PASSWORD = System.Configuration.ConfigurationManager.AppSettings["F_TO_PASSWORD"];
        mail.F_HOST = System.Configuration.ConfigurationManager.AppSettings["F_HOST"];
        mail.F_PUERTO = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["F_PUERTO"]);

        int valor_mail = 0;

        string password_desencriptado = FachadaPersistencia.getInstancia().Desencriptar(pass, System.Configuration.ConfigurationManager.AppSettings["encryptPass"]);

        if ((usuario != "") && (password_desencriptado != "") && (correo != "")) 
        {
            mail.F_FROM = correo;

            mail.F_MENSAJE = 
                "<!DOCTYPE html>"+
"<html>"+
"<head>"+
	"<title></title>"+
	"<link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet'>"+
"</head>"+
"<body>"+
	"<div style='width: 100%;padding: 10px;background: white;'>"+
		"<div style='font-family: 'Montserrat', sans-serif;padding: 10px;padding-left: 10%;padding-right: 10%; width: 80%;text-align: justify;'>"+
			"<h4>Formato de restablecimiento contraseña:</h4>"+

			"<p>Buen día<br><br>"+

            "Cordial Saludo <strong>" + correo + "</strong><br><br>" +

            "Ingrese al siguiente enlace para cambiar su contraseña para el usuario <strong>" + usuario + "</strong>.<br>" +

            "Enlace: <a href='https://maariv.unidadvictimas.gov.co/'>maariv</a><br><br>" +
            "USUARIO: <strong>" + usuario + "</strong><br><br>" +
            "PASSWORD: <strong>" + password_desencriptado + "</strong><br><br>" +

			"Este correo es enviado de manera automática por el sistema, por favor no contestar.<br>"+

            "Para mayor información del manejo de la herramienta realice la consulta por el correo controlseguimientodr@unidadvictimas.gov.co<br><br>" +

			"Agradecemos su atención y esperamos que esta herramienta les resulte útil.<br><br>"+

            "Quedamos atentos<br>" +

                "Muchas gracias<br><br>" +

                "<strong>Equipo Control y Seguimiento</strong><br>" +

                "Dirección de Reparación- Control y Seguimiento<br>" +

                "Unidad para las Victimas<br>" +

                "Carrera 85D No. 46A-65 Piso 3<br>" +

                "Complejo Logístico San Cayetano, Bogotá</p>" +
		"</div>"+
        "<div style='width: 100%;'>" +
            "<img style='width: 50%;' src='https://www.unidadvictimas.gov.co/sites/default/files/logo.png'>" +
        "</div>" +
	"</div>"+
"</body>"+
"</html>";

            //Thread.Sleep(5000);
            valor_mail = Enviar_Correo(mail);  
         }

        return valor_mail;
    }

    // realiza el envio del correo
    public int Enviar_Correo(Mail mail)
    {
        int valor = 0;
        try
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(new MailAddress(mail.F_FROM));
            msg.From = new MailAddress(mail.F_TO, mail.F_USUARIO, System.Text.Encoding.UTF8);
            msg.Subject = mail.F_ASUNTO;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = mail.F_MENSAJE;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient clienteSmtp = new SmtpClient();
            clienteSmtp.Credentials = new System.Net.NetworkCredential(mail.F_TO, mail.F_TO_PASSWORD);
            clienteSmtp.Port = mail.F_PUERTO;
            clienteSmtp.Host = mail.F_HOST;
            //clienteSmtp.EnableSsl = false;
            clienteSmtp.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["F_EnableSsl"]);

            try
            {
                clienteSmtp.Send(msg);
                valor = 1;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Mensajes("No se a podido enviar el correo");
                valor = 0;
            }
        }
        catch (Exception ex)
        {
            Mensajes("Ocurrió un error al enviar la notificación", 0);
        }

        return valor;
    }

    private bool ValidarExisteDatoConsulta()
    {
        return (this.TextBoxUsuario.Text != "" || this.TextBoxEmail.Text != "");
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Presentacion.aspx");
    }

}
