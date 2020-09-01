/*
 *******************************************************************************************
  PROGRAMA				: Presentacion.aspx.cs
  FECHA DE CREACION	    : 01-06-2013
  FECHA DE MODIFICACION : 16-06-2020
  VERSION               : 1.1
  AUTOR                 : Gustavo Adolfo Caicedo Viveros

 *******************************************************************************************
 
  CLASE			        : Presentacion
  RESPONSABILIDAD	    : Se encarga de gestionar el ingreso al sistema
  COLABORACION		    : 
********************************************************************************************
*/

using System;
using System.Data;
using System.Web.UI;
using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.persistencia.fachada;
using com.GACV.lgb.modelo.email;
using System.Net.Mail;

public partial class Presentacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        if (Request.Params["caso"] != null)
        {
            string parametro = Request.Params["caso"];

            if (parametro.Equals("0"))
            {
                //Mensajes("Usted no tiene permisos para acceder esta página", 0);
                texto("Usted no tiene permisos para acceder esta página...!<p> <br>Intente nuevamente. </p>", 2);
                Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

            }
            else
            {
                if (parametro.Equals("1"))
                {
                    // Mensajes("Su sesión expiró, inicie sesión nuevamente", 0);
                }
            }
        }
        this.L_mensaje.Text = "";

        //SetFocus(TextBoxUsuario);

        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(Page);
        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(TextBoxCorreoAlternativo);

    }

    #region MENSAJES

    private void Mensajes(string mensaje, int opc)
    {
        string script = "";
        switch (opc)
        {
            case 0:

                script = @"<script type='text/javascript'> 
                    $( '#ContentPlaceHolder1_myModal' ).modal('hide'); 
                    $('#M_Confirmar').modal('hide');
                    $('.modal-backdrop').remove(); 
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                script = @"<script type='text/javascript'> alert('" + mensaje + "'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                break;
            case 1:
                script = @"<script type='text/javascript'> alert('" + mensaje + "'); window.close(); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;
            case 2:
                script = @"<script type='text/javascript'> window.close(); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;
            case 3:

                // Muestra una ventana nueva en un formulario principal                 
                script = "<script language='JavaScript'> " + "{ " + " window.open(' " + mensaje + "' ); " + "} </script> ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", script, false);



                break;
        }
    }


    private void Mensajes_2(string titulo, string mensaje, int opc)
    {
        switch (opc)
        {
            case 1://correcto
                if (titulo == "")
                {
                    lblModalTitle.Text = " <span class='text-success'> <span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>  Transaccion realizada correctamente</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-success'> <span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>  " + titulo + "</span>";
                }

                lblModalBody.Text = "<span> " + mensaje + "</span>";
                B_12.Visible = false;
                CB_Valida_accion.Visible = false;
                TextBoxCorreoAlternativo.Visible = false;

                break;

            case 2://Alerta
                if (titulo == "")
                {
                    lblModalTitle.Text = "    <span class='text-warning'> <span class=\"glyphicon glyphicon-warning-sign\" aria-hidden=\"true\"></span>   Alerta</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-warning'>  <span class=\"glyphicon glyphicon-warning-sign\" aria-hidden=\"true\"></span> " + titulo + "</span>";
                }

                lblModalBody.Text = "<span> " + mensaje + "</span>";
                CB_Valida_accion.Visible = false;
                B_12.Visible = false;
                TextBoxCorreoAlternativo.Visible = false;

                break;

            case 3://Error
                if (titulo == "")
                {
                    lblModalTitle.Text = " <span class='text-danger'> <span class=\"glyphicon glyphicon-remove-sign\" aria-hidden=\"true\"></span> Se ha detectado una excepción</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-danger'> <span class=\"glyphicon glyphicon-remove-sign\" aria-hidden=\"true\"></span> " + titulo + "</span>";
                }

                lblModalBody.Text = "<span> " + mensaje + "</span>";
                CB_Valida_accion.Visible = false;
                B_12.Visible = false;
                TextBoxCorreoAlternativo.Visible = false;

                break;

            case 4://Alerta + validacion
                if (titulo == "")
                {
                    lblModalTitle.Text = " <span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro?</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> " + titulo + " </span>";
                }

                TextBoxCorreoAlternativo.Visible = false;

                lblModalBody.Text = "<span> " + mensaje + "</span>";
                CB_Valida_accion.Visible = true;
                CB_Valida_accion.Checked = false;
                CB_Valida_accion.Text = "Aceptar";
                B_12.Visible = true;
                B_12.Text = "Continuar";

                break;
        }

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        //upModal.Update();
    }

    private void Mensajes_3(string titulo, string mensaje, int opc)
    {

        switch (opc)
        {
            case 1://correcto
                if (titulo == "")
                {
                    lblModalTitle.Text = " <span class='text-success'> <span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>  Transaccion realizada correctamente</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-success'> <span class=\"glyphicon glyphicon-ok-sign\" aria-hidden=\"true\"></span>  " + titulo + "</span>";
                }

                lblModalBody.Text = "<span> " + mensaje + "</span>";
                B_12.Visible = false;
                TextBoxCorreoAlternativo.Visible = false;
                //CB_Valida_accion.Visible = false;

                break;

            case 2://Alerta
                if (titulo == "")
                {
                    lblModalTitle.Text = "    <span class='text-warning'> <span class=\"glyphicon glyphicon-warning-sign\" aria-hidden=\"true\"></span>   Alerta</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-warning'>  <span class=\"glyphicon glyphicon-warning-sign\" aria-hidden=\"true\"></span> " + titulo + "</span>";
                }

                lblModalBody.Text = "<span> " + mensaje + "</span>";
                //CB_Valida_accion.Visible = false;
                B_12.Visible = false;
                B_13.Visible = true;
                TextBoxCorreoAlternativo.Visible = true;


                break;

            case 3://Error
                if (titulo == "")
                {
                    lblModalTitle.Text = " <span class='text-danger'> <span class=\"glyphicon glyphicon-remove-sign\" aria-hidden=\"true\"></span> Se ha detectado una excepción</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-danger'> <span class=\"glyphicon glyphicon-remove-sign\" aria-hidden=\"true\"></span> " + titulo + "</span>";
                }

                lblModalBody.Text = "<span> " + mensaje + "</span>";
                //CB_Valida_accion.Visible = false;
                B_12.Visible = false;

                break;

            case 4://Alerta + validacion
                if (titulo == "")
                {
                    lblModalTitle.Text = " <span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro?</span>";
                }
                else
                {
                    lblModalTitle.Text = " <span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> " + titulo + " </span>";
                }

                lblModalBody.Text = "<span> " + mensaje + "</span>";

                //CB_Valida_accion.Visible = true;
                //CB_Valida_accion.Checked = false;
                //CB_Valida_accion.Text = "Aceptar";
                B_12.Visible = true;
                //B_13.Visible = true;
                B_12.Text = "Continuar";

                break;
        }

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        //upModal.Update();
    }

    private void texto(string mensaje, int opc)
    {
        switch (opc)
        {
            case 1://correcto
                this.L_mensaje.Text = this.L_mensaje.Text + " <span class='text-success'> </br> <span class=\"glyphicon glyphicon-ok-circle\" aria-hidden=\"true\"></span> " + mensaje + "   </span>";
                break;
            case 2://Alerta
                this.L_mensaje.Text = this.L_mensaje.Text + "<span class='text-warning'> </br> <span class=\"glyphicon glyphicon-exclamation-sign\" aria-hidden=\"true\"></span> " + mensaje + "   </span>";
                break;
            case 3://Error
                this.L_mensaje.Text = this.L_mensaje.Text + "<span class='text-danger'> </br> <span class=\"glyphicon glyphicon-remove-circle\" aria-hidden=\"true\"></span>  " + mensaje + "   </span>";
                break;
            case 4://Sin icono y sin color
                this.L_mensaje.Text = this.L_mensaje.Text + mensaje;
                break;
        }

    }

    //2018-05-08
    // PERMITE ENVIAR UN CORREO CON LOS DATOS DE LA ACTIVACION DEL USUARIO
    public bool Enviar_datos_activacion(string codigo_verificacion, string correo)
    {
        Mail mail = new Mail();

        mail.F_ASUNTO = "(MAARIV) Inicio de sesión desde IP no Autorizada";
        mail.F_USUARIO = System.Configuration.ConfigurationManager.AppSettings["F_USUARIO"];
        mail.F_TO = System.Configuration.ConfigurationManager.AppSettings["F_TO"];
        mail.F_TO_PASSWORD = System.Configuration.ConfigurationManager.AppSettings["F_TO_PASSWORD"];
        mail.F_HOST = System.Configuration.ConfigurationManager.AppSettings["F_HOST"];
        mail.F_PUERTO = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["F_PUERTO"]);

        bool valor_mail = false;

        //string password_desencriptado = FachadaPersistencia.getInstancia().Desencriptar(pass, System.Configuration.ConfigurationManager.AppSettings["encryptPass"]);

        if ((codigo_verificacion != "") && (correo != ""))
        {
            mail.F_FROM = correo;

            mail.F_MENSAJE = "<!DOCTYPE html>" +
"<html>" +
"<head>" +
    "<title></title>" +
    "<link href='https://fonts.googleapis.com/css?family=Montserrat' rel='stylesheet'>" +
"</head>" +
"<body>" +
    "<div style='width: 100%;padding: 10px;background: white;'>" +
        "<div style='font-family: 'Montserrat', sans-serif;padding: 10px;padding-left: 10%;padding-right: 10%; width: 80%;text-align: justify;'>" +

            "<center><img style='width:100px;' src='https://image.flaticon.com/icons/svg/149/149079.svg'><br><br></center>" +

            "Cordial Saludo <strong>" + correo + "</strong>,<br><br>" +

            "<strong>Alerta de actividad de inicio de sesión sospechosa:</strong><br><br>" +

            "Para poder minimizar los daños de un acceso no autorizado a tu cuenta, MAARIV cuenta con un sistema de seguridad el cual indica que alguien ha accedido a tu cuenta desde una IP diferente a la que usaste anteriormente. Un inicio de sesión se considera sospechoso si implica una ubicación con la que hayas iniciado sesión anteriormente." +

            "<br><br><strong>Cómo proteger tu cuenta:<br><br></strong>" +

            "MAARIV te da algunos tips de seguridad para asegurarte que nadie, a parte de ti, intente acceder a tu cuenta. El primero y mas importante es responsabilizarse del usuario que creamos para ti, este es único, intransferible y personal. El segundo tip es cambiar la contraseña periódicamente, con el fin de no tener inconvenientes con los curiosos del internet. El tercero y último asegurate de tener un lugar preferido y seguro para conectarte, esto evitará que los curiosos del internet puedan ingresar al sistema.<i> La seguridad de la información esta en tus manos</i>" +

            "<br><br>CODIGO VERIFICACION: <strong>" + codigo_verificacion + "</strong><br><br>" +

            "Quedamos atentos<br>" +

            "Muchas gracias<br><br>" +

            "<strong>Equipo Control y Seguimiento</strong><br>" +

            "Dirección de Reparación- Control y Seguimiento<br>" +

            "Unidad para las Victimas<br>" +

            "Carrera 85D No. 46A-65 Piso 3<br>" +

            "Complejo Logístico San Cayetano, Bogotá<br>" +

        "</div>" +
        "<div style='width: 100%;'>" +
            "<img style='width: 50%;' src='http://localhost:56047/img/loging_Maariv.png'>" +
        "</div>" +
    "</div>" +
"</body>" +
"</html>";

            //Thread.Sleep(5000);
            valor_mail = Enviar_Correo(mail);
        }

        return valor_mail;
    }

    //2018-05-08
    // realiza el envio del correo
    public bool Enviar_Correo(Mail mail)
    {
        bool valor = false;
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
                valor = true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Mensajes("No se a podido enviar el correo");
                valor = false;
            }
        }
        catch (Exception ex)
        {
            Mensajes("Ocurrió un error al enviar la notificación", 0);
        }

        return valor;
    }

    #endregion

    #region METODOS

    #endregion

    #region EVENTOS

    protected void Button2_Click(object sender, EventArgs e)
    {
        error_segunda.Visible = false;
        try
        {
            Usuario usuario = new Usuario();
            Usuario usuario_sesion_duplicada = new Usuario();
            //encripcion de password                
            string password_encriptado = FachadaPersistencia.getInstancia().Encriptar(TextBoxPassword.Text.Trim(), System.Configuration.ConfigurationManager.AppSettings["encryptPass"]);

            usuario.Login = TextBoxUsuario.Text.Trim();
            usuario.Password = password_encriptado;



            DataSet ds = null;
            DataSet ds2 = null;
            DataSet ds_sesion_duplicada = null;
            DataSet ds_verificar_ip = null;

            ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 18);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Columns.Count == 1)
                {
                    ds.Tables[0].Rows[0]["VALIDACION_USUARIO"].ToString();
                    //Mensajes("Advertencia: acceso al sistema no permitido", 0); //no esta
                    texto("acceso al sistema no permitido...!<p>Por favor verifique que su usuario y contraseña sean correctos. <br>Intente nuevamente. </p>", 2);
                    Mensajes_2("Advertencia", this.L_mensaje.Text, 2);
                }
                else if (ds.Tables[0].Columns.Count == 2)
                {
                    //Mensajes("Advertencia: el usuario " + ds.Tables[0].Rows[0]["ESTADO_VALIDADO"].ToString() + ", verifica con tu supervisor", 0);
                    string tx = "Usuario " + ds.Tables[0].Rows[0]["ESTADO_VALIDADO"].ToString() + ", Por favor comunícate con <a href='mailto:controlseguimientodr@unidadvictimas.gov.co'> controlseguimientodr@unidadvictimas.gov.co</a> para que puedas activar tu usuario.";

                    texto("acceso al sistema no permitido...!<p> " + tx + " </p>", 3);
                    Mensajes_2("Advertencia", this.L_mensaje.Text, 3);

                    usuario.Apellidos = "Rechazado";
                    usuario.Email = "Usuario bloqueado";
                    usuario.F_id_persona = 0; //id_estado
                    usuario.F_TIPO_USUARIO = 2;  //id_tipo_bloqueo
                    usuario.Login = TextBoxUsuario.Text.Trim();
                    Session["conteo_pass"] = 0;
                    FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                }
                else if (ds.Tables[0].Columns.Count == 3)
                {
                    //Mensajes("Advertencia: el usuario no esta validado por supervisor", 0);
                    texto("acceso al sistema no permitido...!<p>El usuario no esta validado por supervisor. <br>Intente nuevamente. </p>", 2);
                    Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

                    usuario.Apellidos = "Rechazado";
                    usuario.Email = "Usuario no validado por supervisor";
                    usuario.F_id_persona = 0; //id_estado
                    usuario.F_TIPO_USUARIO = 3;  //id_tipo_bloqueo
                    usuario.Login = TextBoxUsuario.Text.Trim();
                    Session["conteo_pass"] = 0;
                    FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 
                }
                else
                if (ds.Tables[0].Columns.Count > 3)
                {
                    //si esta
                    // ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 18);
                    Session.Add("flag_verificar_roles", 0);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 1)
                        {


                            //Panel1.Visible = true;
                            //Panel0.Visible = false;
                            //RadioButtonList1.Items.Clear();

                            if (!ds.Tables[0].Rows.Count.Equals(0))
                            {
                                //RadioButtonList1.DataValueField = "id_tipo_usuario";
                                //RadioButtonList1.DataTextField = "tipo_usuario";
                                //RadioButtonList1.DataSource = ds;
                                //RadioButtonList1.DataBind();

                                //Session["identificacion"] = ds.Tables[0].Rows[0]["identificacion"].ToString(); // numero del documento del usuario
                                //Session["login"] = ds.Tables[0].Rows[0]["u_login"].ToString();
                                //Session["id_persona"] = ds.Tables[0].Rows[0]["id_persona"].ToString();
                                //Session["email"] = ds.Tables[0].Rows[0]["email"].ToString();
                                //Session["Telefono_Movil"] = ds.Tables[0].Rows[0]["telefono_movil"].ToString();
                                //Session["tipo_usuario"] = ds.Tables[0].Rows[0]["tipo_usuario"].ToString();

                                //Session["WS_Asistencia_User"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_User"];
                                //Session["WS_Asistencia_Pass"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_Pass"];
                                //Session["Peso_Maximo_Carga_Archivos"] = System.Configuration.ConfigurationManager.AppSettings["Peso_Maximo_Carga_Archivos"];
                                //Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];

                                //usuario.Apellidos = "Exitoso";
                                //usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                                //Session["conteo_pass"] = 0;
                                //usuario.F_id_persona = 1; //id_estado
                                //usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                                //usuario.Login = TextBoxUsuario.Text.Trim();
                                //FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 


                                //Session.Add("codigo_verificacion", FachadaPersistencia.getInstancia().contraseña_randomica());

                                //Enviar_datos_activacion(Convert.ToString(Session["codigo_verificacion"]), Convert.ToString(Session["email"]));

                                usuario.P_usuario_creacion = Convert.ToString(ds.Tables[0].Rows[0]["id_usuario"]);
                                usuario.F_Nombre = ip_mac();
                                usuario.F_TIPO_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_tipo_usuario"]);
                                usuario_sesion_duplicada.F_ID_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_usuario"]);

                                ds_sesion_duplicada = FachadaPersistencia.getInstancia().administrar_sesion_duplicada(usuario_sesion_duplicada, 0);
                                if (ds_sesion_duplicada.Tables[0].Rows.Count > 0)
                                {
                                    if (ds_sesion_duplicada.Tables[0].Rows[0]["FECHA_HORA_SALIDA"].ToString() == "")
                                    {

                                        texto("Encontramos una sesión abierta.<p><br>Puede que hayas cerrado el navegador sin cerrar tu sesión o ya tengas una abierta en otro navegador. A continuación cerraremos la sesión que percibimos activa y podrás continuar con la sesión actual. </p>", 2);

                                        Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

                                        usuario.P_ID_AUDITORIA = ds_sesion_duplicada.Tables[0].Rows[0]["ID_AUDITORIA"].ToString();

                                        //// permite realizar el seguimiento de cuando entra un usuario a la aplicacion
                                        FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 19);

                                        //Usuario usuario_auditoria = new Usuario();
                                        //usuario_auditoria.P_ID_AUDITORIA = ds_sesion_duplicada.Tables[0].Rows[0]["ID_AUDITORIA"].ToString();
                                        //FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario_auditoria, 19);
                                    }


                                    //Panel1.Visible = true;
                                    //Panel0.Visible = false;
                                    //RadioButtonList1.Items.Clear();

                                    //texto("datos ingresados, acceso al sistema no permitido...!<p>exitoso. <br>Intente nuevamente. </p>", 2);
                                    //Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

                                    usuario.F_ID_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_usuario"]);
                                    ds_verificar_ip = FachadaPersistencia.getInstancia().administrar_ip_cambiada(usuario, 0);

                                    if (ds_verificar_ip.Tables[0].Rows[0]["RESPUESTA"].ToString() == "1")
                                    {
                                        //ds2 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 13);
                                        //Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());


                                        Panel1.Visible = true;
                                        Panel0.Visible = false;
                                        RadioButtonList1.Items.Clear();

                                        RadioButtonList1.DataValueField = "id_tipo_usuario";
                                        RadioButtonList1.DataTextField = "tipo_usuario";
                                        RadioButtonList1.DataSource = ds;
                                        RadioButtonList1.DataBind();

                                        Session["identificacion"] = ds.Tables[0].Rows[0]["identificacion"].ToString(); // numero del documento del usuario
                                        Session["login"] = ds.Tables[0].Rows[0]["u_login"].ToString();
                                        Session["id_persona"] = ds.Tables[0].Rows[0]["id_persona"].ToString();
                                        Session["email"] = ds.Tables[0].Rows[0]["email"].ToString();
                                        Session["Telefono_Movil"] = ds.Tables[0].Rows[0]["telefono_movil"].ToString();
                                        Session["tipo_usuario"] = ds.Tables[0].Rows[0]["tipo_usuario"].ToString();

                                        Session["WS_Asistencia_User"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_User"];
                                        Session["WS_Asistencia_Pass"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_Pass"];
                                        Session["Peso_Maximo_Carga_Archivos"] = System.Configuration.ConfigurationManager.AppSettings["Peso_Maximo_Carga_Archivos"];
                                        Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];

                                        usuario.Apellidos = "Exitoso";
                                        usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                                        Session["conteo_pass"] = 0;
                                        usuario.F_id_persona = 1; //id_estado
                                        usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                                        usuario.Login = TextBoxUsuario.Text.Trim();
                                        FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 



                                    }
                                    else
                                    {

                                        //string codigo_verificacion = FachadaPersistencia.getInstancia().contraseña_randomica();
                                        //Panel1.Visible = true;
                                        //Panel0.Visible = false;
                                        RadioButtonList1.Items.Clear();

                                        RadioButtonList1.DataValueField = "id_tipo_usuario";
                                        RadioButtonList1.DataTextField = "tipo_usuario";
                                        RadioButtonList1.DataSource = ds;
                                        RadioButtonList1.DataBind();

                                        Session["identificacion"] = ds.Tables[0].Rows[0]["identificacion"].ToString(); // numero del documento del usuario
                                        Session["login"] = ds.Tables[0].Rows[0]["u_login"].ToString();
                                        Session["id_persona"] = ds.Tables[0].Rows[0]["id_persona"].ToString();
                                        Session["email"] = ds.Tables[0].Rows[0]["email"].ToString();
                                        Session["Telefono_Movil"] = ds.Tables[0].Rows[0]["telefono_movil"].ToString();
                                        Session["tipo_usuario"] = ds.Tables[0].Rows[0]["tipo_usuario"].ToString();

                                        Session["WS_Asistencia_User"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_User"];
                                        Session["WS_Asistencia_Pass"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_Pass"];
                                        Session["Peso_Maximo_Carga_Archivos"] = System.Configuration.ConfigurationManager.AppSettings["Peso_Maximo_Carga_Archivos"];
                                        Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];

                                        Session.Add("codigo_verificacion", FachadaPersistencia.getInstancia().contraseña_randomica());

                                        Enviar_datos_activacion(Convert.ToString(Session["codigo_verificacion"]), Convert.ToString(Session["email"]));

                                        TextBoxCorreoAlternativo.Text = Convert.ToString(Session["codigo_verificacion"]); //BRAYAN

                                        //TextBoxCorreoAlternativo.Text = codigo_verificacion;

                                        texto("Cambio de ordenador... <p> Detectamos que actualmente estas ingresando desde un ordenador distinto al registrado por última vez en el sistema. A continuación se enviara un código de verificación a tu correo registrado. </p> <p> <i>Nota: Ten en cuenta que si cierras esta ventana volveremos a generar un nuevo código de verificación cuando intentes volver a ingresar</i> </p>", 2);

                                        Mensajes_3("Advertencia", this.L_mensaje.Text, 2);
                                    }


                                }
                                else
                                {


                                    //ds2 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 13);
                                    //Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());


                                    Panel1.Visible = true;
                                    Panel0.Visible = false;
                                    RadioButtonList1.Items.Clear();

                                    RadioButtonList1.DataValueField = "id_tipo_usuario";
                                    RadioButtonList1.DataTextField = "tipo_usuario";
                                    RadioButtonList1.DataSource = ds;
                                    RadioButtonList1.DataBind();

                                    Session["identificacion"] = ds.Tables[0].Rows[0]["identificacion"].ToString(); // numero del documento del usuario
                                    Session["login"] = ds.Tables[0].Rows[0]["u_login"].ToString();
                                    Session["id_persona"] = ds.Tables[0].Rows[0]["id_persona"].ToString();
                                    Session["email"] = ds.Tables[0].Rows[0]["email"].ToString();
                                    Session["Telefono_Movil"] = ds.Tables[0].Rows[0]["telefono_movil"].ToString();
                                    Session["tipo_usuario"] = ds.Tables[0].Rows[0]["tipo_usuario"].ToString();

                                    Session["WS_Asistencia_User"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_User"];
                                    Session["WS_Asistencia_Pass"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_Pass"];
                                    Session["Peso_Maximo_Carga_Archivos"] = System.Configuration.ConfigurationManager.AppSettings["Peso_Maximo_Carga_Archivos"];
                                    Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];

                                    usuario.Apellidos = "Exitoso";
                                    usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                                    Session["conteo_pass"] = 0;
                                    usuario.F_id_persona = 1; //id_estado
                                    usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                                    usuario.Login = TextBoxUsuario.Text.Trim();
                                    FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 
                                }



                                //TextBoxCorreoAlternativo.Text = codigo_verificacion;

                                //texto("datos ingresados, acceso al sistema no permitido...!<p>actualmente usted esta ingresando desde un  ordenador distinto al registrado por ultima vez en el sistema. A continuacion se enviara un codigo de verificacion a su correo registrado. </p>", 2);

                                //Mensajes_3("Advertencia", this.L_mensaje.Text, 2);

                                Session["ds"] = ds;
                            }
                        }
                        else
                        {

                            Session.Add("usuario", ds.Tables[0].Rows[0]["nombre"].ToString() + " " + ds.Tables[0].Rows[0]["apellidos"].ToString());  // nombre del usuario
                            Session.Add("id_usuario", ds.Tables[0].Rows[0]["id_usuario"].ToString());                                                // id del usuario en la base de datos
                            Session.Add("rol", ds.Tables[0].Rows[0]["id_tipo_usuario"].ToString());                                                  // rol del participante (Tipo de particiapante)
                            Session.Add("id_dependencia", ds.Tables[0].Rows[0]["id_dependencia"].ToString());                                        // Nit de la entidad
                            Session.Add("identificacion", ds.Tables[0].Rows[0]["identificacion"].ToString());                                        // numero del documento del usuario
                            Session.Add("login", ds.Tables[0].Rows[0]["u_login"].ToString());
                            Session.Add("id_persona", ds.Tables[0].Rows[0]["id_persona"].ToString());
                            Session.Add("email", ds.Tables[0].Rows[0]["email"].ToString());
                            Session.Add("Telefono_Movil", ds.Tables[0].Rows[0]["telefono_movil"].ToString());
                            Session["WS_Asistencia_User"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_User"];
                            Session["WS_Asistencia_Pass"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_Pass"];
                            Session["Peso_Maximo_Carga_Archivos"] = System.Configuration.ConfigurationManager.AppSettings["Peso_Maximo_Carga_Archivos"];
                            Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];
                            //Session.Add("nombre_entidad", partic.Nombre_Entidad);
                            //Session.Add("ruta_archivo", partic.Ruta);

                            Session["flag_verificar_roles"] = 1;

                            if (ds.Tables[0].Rows[0]["id_departamento"].ToString() != "")
                            {
                                Session.Add("id_departamento", ds.Tables[0].Rows[0]["id_departamento"].ToString());
                            }
                            else
                            {
                                Session.Add("id_departamento", 0);
                            }

                            usuario.P_usuario_creacion = Convert.ToString(ds.Tables[0].Rows[0]["id_usuario"]);
                            usuario.F_Nombre = ip_mac();
                            usuario.F_TIPO_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_tipo_usuario"]);
                            usuario_sesion_duplicada.F_ID_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_usuario"]);

                            ds_sesion_duplicada = FachadaPersistencia.getInstancia().administrar_sesion_duplicada(usuario_sesion_duplicada, 0);
                            if (ds_sesion_duplicada.Tables[0].Rows.Count > 0)
                            {
                                if (ds_sesion_duplicada.Tables[0].Rows[0]["FECHA_HORA_SALIDA"].ToString() == "")
                                {

                                    texto("datos ingresados, acceso al sistema no permitido...!<p>existe una sesion abierta. A continuacion se cerrara la sesion existente.<br>Intente nuevamente. </p>", 2);

                                    Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

                                    usuario.P_ID_AUDITORIA = ds_sesion_duplicada.Tables[0].Rows[0]["ID_AUDITORIA"].ToString();

                                    //// permite realizar el seguimiento de cuando entra un usuario a la aplicacion
                                    FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 19);

                                    //Usuario usuario_auditoria = new Usuario();
                                    //usuario_auditoria.P_ID_AUDITORIA = ds_sesion_duplicada.Tables[0].Rows[0]["ID_AUDITORIA"].ToString();
                                    //FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario_auditoria, 19);
                                }
                                else
                                {


                                    //texto("datos ingresados, acceso al sistema no permitido...!<p>exitoso. <br>Intente nuevamente. </p>", 2);
                                    //Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

                                    usuario.F_ID_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_usuario"]);
                                    ds_verificar_ip = FachadaPersistencia.getInstancia().administrar_ip_cambiada(usuario, 0);

                                    if (ds_verificar_ip.Tables[0].Rows[0]["RESPUESTA"].ToString() == "1")
                                    {
                                        ds2 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 13);
                                        Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());

                                        Session["conteo_pass"] = 0;



                                        usuario.Apellidos = "Exitoso";
                                        usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                                        //Session["conteo_pass"] = 0;



                                        usuario.F_id_persona = 1; //id_estado
                                        usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                                        usuario.Login = TextBoxUsuario.Text.Trim();
                                        FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                                        Response.Redirect("Inicio_perfil.aspx");
                                    }
                                    else
                                    {

                                        //string codigo_verificacion = FachadaPersistencia.getInstancia().contraseña_randomica();

                                        Session.Add("codigo_verificacion", FachadaPersistencia.getInstancia().contraseña_randomica());

                                        Enviar_datos_activacion(Convert.ToString(Session["codigo_verificacion"]), Convert.ToString(Session["email"]));
                                        TextBoxCorreoAlternativo.Text = Convert.ToString(Session["codigo_verificacion"]); // BRAYAN

                                        //TextBoxCorreoAlternativo.Text = codigo_verificacion;

                                        texto("Cambio de ordenador... <p> Detectamos que actualmente estas ingresando desde un ordenador distinto al registrado por última vez en el sistema. A continuación se enviara un código de verificación a tu correo registrado. </p> <p> <i>Nota: Ten en cuenta que si cierras esta ventana volveremos a generar un nuevo código de verificación cuando intentes volver a ingresar</i> </p>", 2);

                                        Mensajes_3("Advertencia", this.L_mensaje.Text, 2);
                                    }


                                }
                            }
                            else
                            {
                                ds2 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 13);
                                Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());

                                Session["conteo_pass"] = 0;



                                usuario.Apellidos = "Exitoso";
                                usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                                //Session["conteo_pass"] = 0;



                                usuario.F_id_persona = 1; //id_estado
                                usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                                usuario.Login = TextBoxUsuario.Text.Trim();
                                FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                                Response.Redirect("Inicio_perfil.aspx");
                            }

                            // permite realizar el seguimiento de cuando entra un usuario a la aplicacion

                            //ds2 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 13);
                            //Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());

                            //Session["conteo_pass"] = 0;



                            //usuario.Apellidos = "Exitoso";
                            //usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                            ////Session["conteo_pass"] = 0;



                            //usuario.F_id_persona = 1; //id_estado
                            //usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                            //usuario.Login = TextBoxUsuario.Text.Trim();
                            //FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                            //Response.Redirect("Inicio_perfil.aspx");
                        }
                    }
                    else
                    {
                        ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 8);

                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["conteo"]) == 0)
                        {
                            Session["conteo_pass"] = 0;
                            Session.Add("usuario", "gustavo");      // nombre del usuario
                            Session.Add("id_usuario", "1");         // id del particiapante en la base de datos
                            Session.Add("rol", "1");                // rol del participante (Tipo de particiapante)
                            Session.Add("id_dependencia", "0");     // Nit de la entidad
                            Session.Add("identificacion", "0");     // numero del documento del participante
                            Session.Add("login", "gustavo");
                            Session.Add("id_persona", "0");
                            Session.Add("email", "");
                            Session.Add("telefono_movil", "");
                            Session["WS_Asistencia_User"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_User"];
                            Session["WS_Asistencia_Pass"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_Pass"];
                            Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];

                            usuario.Apellidos = "Exitoso";
                            usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                            //Session["conteo_pass"] = 0;
                            usuario.F_id_persona = 1; //id_estado
                            usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                            usuario.Login = TextBoxUsuario.Text.Trim();
                            FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                            Response.Redirect("Modulos/Seguridad/Administrador_usuarios.aspx");
                        }
                        else
                        {
                            //Mensajes("Advertencia: en los datos ingresados, acceso al sistema no permitido", 0);
                            texto("datos ingresados, acceso al sistema no permitido...!<p>El usuario no esta validado por supervisor. <br>Intente nuevamente. </p>", 2);
                            Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

                            Session["conteo_pass"] = Convert.ToInt32(Session["conteo_pass"]) + 1;


                            usuario.Login = TextBoxUsuario.Text.Trim();

                            usuario.Apellidos = "Rechazado";
                            usuario.Email = "Clave incorrecta";
                            usuario.Login = TextBoxUsuario.Text.Trim();
                            usuario.F_id_persona = 0; //id_estado
                            usuario.F_TIPO_USUARIO = 1;  //id_tipo_bloqueo
                            FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                            if (Convert.ToInt32(Session["conteo_pass"]) >= 3)
                            {
                                Session["conteo_pass"] = 0;
                                FachadaPersistencia.getInstancia().administrar_usuario(usuario, 6);
                            }
                        }
                    }
                }

            }
            else
            {
                ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 8);

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["conteo"]) == 0)
                {
                    Session["conteo_pass"] = 0;
                    Session.Add("usuario", "gustavo");      // nombre del usuario
                    Session.Add("id_usuario", "1");         // id del particiapante en la base de datos
                    Session.Add("rol", "1");                // rol del participante (Tipo de particiapante)
                    Session.Add("id_dependencia", "0");     // Nit de la entidad
                    Session.Add("identificacion", "0");     // numero del documento del participante
                    Session.Add("login", "gustavo");
                    Session.Add("id_persona", "0");
                    Session.Add("email", "");
                    Session.Add("telefono_movil", "");
                    Session["WS_Asistencia_User"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_User"];
                    Session["WS_Asistencia_Pass"] = System.Configuration.ConfigurationManager.AppSettings["WS_Asistencia_Pass"];
                    Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];

                    usuario.Apellidos = "Exitoso";
                    usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                    Session["conteo_pass"] = 0;
                    usuario.F_id_persona = 1; //id_estado
                    usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                    usuario.Login = TextBoxUsuario.Text.Trim();
                        FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion

                        Response.Redirect("Modulos/Seguridad/Administrador_usuarios.aspx");
                    }
                    else
                    {

                        //Mensajes("Advertencia: en los datos ingresados, Acceso al sistema no permitido, Intento: " + (Convert.ToInt32(Session["conteo_pass"]) + 1), 0);

                        string tx = "Intento " + (Convert.ToInt32(Session["conteo_pass"]) + 1 + " de 3");

                        texto("Error en los datos ingresados...!<p> " + tx + "<br> <br>Ten en cuenta que por seguridad en tu 3 intento fallido, tu usuario será bloqueado..<br> <br>Si no recuerdas tu contraseña, da click en 'recuperar contraseña' y solicita una nueva contraseña e Intenta nuevamente. </p>", 3);
                        Mensajes_2("Advertencia", this.L_mensaje.Text, 3);


                        Session["conteo_pass"] = Convert.ToInt32(Session["conteo_pass"]) + 1;
                        if (Convert.ToInt32(Session["conteo_pass"]) >= 3)
                        {
                            Session["conteo_pass"] = 0;
                            FachadaPersistencia.getInstancia().administrar_usuario(usuario, 6);
                        }





                    usuario.Apellidos = "Rechazado";
                    usuario.Email = "Clave incorrecta";
                    usuario.Login = TextBoxUsuario.Text.Trim();
                    usuario.F_id_persona = 0; //id_estado
                    usuario.F_TIPO_USUARIO = 1;  //id_tipo_bloqueo
                    FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                    usuario.Login = TextBoxUsuario.Text.Trim();


                }

            }


            /**/
        }
        catch (System.Exception ex)
        {
            //Mensajes("No hay conexión a la Base de datos", 0);
            texto("acceso al sistema no permitido...!<p> No hay conexión a la Base de datos <br>Intente nuevamente. </p>", 2);
            Mensajes_2("Advertencia", this.L_mensaje.Text, 2);

        }
    }

    //protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Usuario usuario = new Usuario();

    //        //encripcion de password                
    //        string password_encriptado = FachadaPersistencia.getInstancia().Encriptar(TextBoxPassword.Text.Trim(), System.Configuration.ConfigurationManager.AppSettings["encryptPass"]);

    //        usuario.Login = TextBoxUsuario.Text.Trim();
    //        usuario.Password = password_encriptado;

    //        DataSet ds = null;
    //        DataSet ds2 = null;
    //        ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 7);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            if (ds.Tables[0].Rows.Count > 1)
    //            {
    //                Panel1.Visible = true;
    //                Panel0.Visible = false;
    //                RadioButtonList1.Items.Clear();

    //                if (!ds.Tables[0].Rows.Count.Equals(0))
    //                {
    //                    RadioButtonList1.DataValueField = "id_tipo_usuario";
    //                    RadioButtonList1.DataTextField = "tipo_usuario";
    //                    RadioButtonList1.DataSource = ds;
    //                    RadioButtonList1.DataBind();

    //                    Session["ds"] = ds;
    //                }
    //            }
    //            else
    //            {
    //                Session["conteo_pass"] = 0;
    //                Session.Add("usuario", ds.Tables[0].Rows[0]["nombre"].ToString() + " " + ds.Tables[0].Rows[0]["apellidos"].ToString());  // nombre del usuario
    //                Session.Add("id_usuario", ds.Tables[0].Rows[0]["id_usuario"].ToString());                                                // id del usuario en la base de datos
    //                Session.Add("rol", ds.Tables[0].Rows[0]["id_tipo_usuario"].ToString());                                                  // rol del participante (Tipo de particiapante)
    //                Session.Add("id_dependencia", ds.Tables[0].Rows[0]["id_dependencia"].ToString());                                        // Nit de la entidad
    //                Session.Add("identificacion", ds.Tables[0].Rows[0]["identificacion"].ToString());                                        // numero del documento del usuario
    //                Session.Add("login", ds.Tables[0].Rows[0]["u_login"].ToString());
    //                Session.Add("id_persona", ds.Tables[0].Rows[0]["id_persona"].ToString());
    //                Session["Peso_Maximo_Carga_Archivos"] = System.Configuration.ConfigurationManager.AppSettings["Peso_Maximo_Carga_Archivos"];
    //                Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];
    //                //Session.Add("nombre_entidad", partic.Nombre_Entidad);
    //                //Session.Add("ruta_archivo", partic.Ruta);

    //                if (ds.Tables[0].Rows[0]["id_departamento"].ToString() != "")
    //                {
    //                    Session.Add("id_departamento", ds.Tables[0].Rows[0]["id_departamento"].ToString());
    //                }
    //                else
    //                {
    //                    Session.Add("id_departamento", 0);
    //                }

    //                usuario.P_usuario_creacion = Convert.ToString(ds.Tables[0].Rows[0]["id_usuario"]);
    //                usuario.F_Nombre = ip_mac();
    //                usuario.F_TIPO_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_tipo_usuario"]);

    //                // permite realizar el seguimiento de cuando entra un usuario a la aplicacion
    //                ds2=FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 13);
    //                Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());

    //                Response.Redirect("Inicio_perfil.aspx");
    //            }
    //        }
    //        else
    //        {
    //            ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 8);

    //            if (Convert.ToInt32(ds.Tables[0].Rows[0]["conteo"]) == 0)
    //            {
    //                Session.Add("usuario", "gustavo");      // nombre del usuario
    //                Session.Add("id_usuario", "1");         // id del particiapante en la base de datos
    //                Session.Add("rol", "1");                // rol del participante (Tipo de particiapante)
    //                Session.Add("id_dependencia", "0");     // Nit de la entidad
    //                Session.Add("identificacion", "0");     // numero del documento del participante
    //                Session.Add("login", "gustavo");
    //                Session.Add("id_persona", "0");
    //                Session["Peso_Maximo_Carga_Archivos"] = System.Configuration.ConfigurationManager.AppSettings["Peso_Maximo_Carga_Archivos"];
    //                Session["PATH_SALVAR_ARCHIVO"] = System.Configuration.ConfigurationManager.AppSettings["PATH_SALVAR_ARCHIVO"];
    //                Response.Redirect("Modulos/Seguridad/Administrador_usuarios.aspx");
    //            }
    //            else
    //            {
    //                //Mensajes("Error en los datos ingresados, Acceso al sistema no permitido", 0);

    //                string tx = "Intento " + (Convert.ToInt32(Session["conteo_pass"]) + 1);

    //                texto("Error en los datos ingresados, Acceso al sistema no permitido...!<p> " + tx + " <br>Intente nuevamente. </p>", 3);
    //                Mensajes_2("Advertencia", this.L_mensaje.Text, 3);

    //                if (Session["login_ultimo"] == usuario.Login)
    //                {
    //                    Session["conteo_pass"] = Convert.ToInt32(Session["conteo_pass"]) + 1;
    //                }
    //                else
    //                {
    //                    Session["conteo_pass"] = 0;
    //                }

    //                usuario.Login = TextBoxUsuario.Text.Trim();


    //                if (Convert.ToInt32(Session["conteo_pass"]) >= 3)
    //                {
    //                    FachadaPersistencia.getInstancia().administrar_usuario(usuario, 6);
    //                }
    //            }
    //        }
    //    }
    //    catch (System.Exception ex)
    //    {
    //        //Mensajes("No hay conexión a la Base de datos", 0);
    //        texto("acceso al sistema no permitido...!<p> No hay conexión a la Base de datos <br>Intente nuevamente. </p>", 2);
    //        Mensajes_2("Advertencia", this.L_mensaje.Text, 2);
    //    }
    //}

    // permite continuar con el perfil seleccionado
    protected void Continuar_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = (DataSet)Session["ds"];
        DataSet ds2 = null;

        if (RadioButtonList1.SelectedValue != "")
        {
            Session["conteo_pass"] = 0;
            Session.Add("usuario", ds.Tables[0].Rows[0]["nombre"].ToString() + " " + ds.Tables[0].Rows[0]["apellidos"].ToString());  // nombre del usuario
            Session.Add("id_usuario", ds.Tables[0].Rows[0]["id_usuario"].ToString());                                                // id del usuario en la base de datos
            Session.Add("rol", RadioButtonList1.SelectedValue);                                                                      // rol del participante (Tipo de particiapante)            
            Session.Add("identificacion", ds.Tables[0].Rows[0]["identificacion"].ToString());                                        // numero del documento del usuario
            Session.Add("login", ds.Tables[0].Rows[0]["u_login"].ToString());
            Session.Add("id_persona", ds.Tables[0].Rows[0]["id_persona"].ToString());
            Session.Add("id_dependencia", ds.Tables[0].Rows[0]["id_dependencia"].ToString());                                       // id_dependencia

            if (ds.Tables[0].Rows[0]["id_departamento"].ToString() != "")
            {
                Session.Add("id_departamento", ds.Tables[0].Rows[0]["id_departamento"].ToString());
            }
            else
            {
                Session.Add("id_departamento", 0);
            }

            Usuario usuario = new Usuario();
            usuario.P_usuario_creacion = Convert.ToString(ds.Tables[0].Rows[0]["id_usuario"]);
            usuario.F_Nombre = ip_mac();
            usuario.F_TIPO_USUARIO = Convert.ToInt32(RadioButtonList1.SelectedValue);

            // permite realizar el seguimiento de cuando entra un usuario a la aplicacion
            ds2 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 13);
            Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());


            Response.Redirect("Inicio_perfil.aspx");
        }
        else
        {
            //Mensajes("Seleccione un perfil", 0);
            texto("Seleccione un perfil...!<p>  <br>Intente nuevamente. </p>", 2);
            Mensajes_2("Advertencia", this.L_mensaje.Text, 2);
        }
    }

    // imagen facebook
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("http://www.facebook.com/pages/Gama-Soluciones-Empresariales-SAS/502604956448591?ref=hl", "_blank", "");
    }

    // imagen de twiter
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }

    // imagen de youtube
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Presentacion.aspx");
    }

    // permite obtener información de la ip y mac de un equipo remoto
    public string ip_mac()
    {
        // ManagementClass objMC;
        // ManagementObjectCollection objMOC;
        /* string[] ipaddresses;   // direccion ip
         string[] subnets;       // mascara
         string[] gateways;      // puerta de enlace
         string[] dns;           // dns
         string hostname;        // nombre del host
         string mac_address;     // direccion mac*/
        //string ip;
        // int i = 0;

        //  objMC = new ManagementClass("Win32_NetworkAdapterConfiguration"); 
        //  objMOC = objMC.GetInstances();

        //ip = Request.ServerVariables.Get("REMOTE_ADDR");
        /* ip = Request.UserHostAddress;

         foreach(ManagementObject objMO in objMOC) 
         {
             if (!(bool)objMO["ipEnabled"])
             {
                 continue;
             }
             else
             {
                 i = i + 1; // i = nº de NICs                
                 ipaddresses = (string[])objMO["IPAddress"];
                 subnets = (string[])objMO["IPSubnet"];
                 gateways = (string[])objMO["DefaultIPGateway"];
                 dns = (string[])objMO["DNSServerSearchOrder"];
                 hostname = (String)objMO["DNSHostName"];
                 mac_address = (string)objMO["MacAddress"];
             }
         }       

         */
        //return ip;

        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            
            if (addresses.Length != 0)
            {
                string[] Ip_puerto = addresses[0].Split(':');
                return Ip_puerto[0];
            }
        }

        string[] addresses2 = context.Request.UserHostAddress.Split(';');
        string aux = null;
        if (addresses2.Length != 0)
        {
            aux =  addresses2[0];
        }
        return aux;

        //return context.Request.ServerVariables["REMOTE_ADDR"];
    }

    #endregion


    protected void TextBoxUsuario_TextChanged(object sender, EventArgs e)
    {
        Session["conteo_pass"] = 0;

    }

    protected void B_13_Click(object sender, EventArgs e)
    {
        error_segunda.Visible = false;
        string password_encriptado = FachadaPersistencia.getInstancia().Encriptar(TextBoxPassword.Text.Trim(), System.Configuration.ConfigurationManager.AppSettings["encryptPass"]);
        Usuario usuario1 = new Usuario();
        usuario1.Login = TextBoxUsuario.Text.Trim();
        usuario1.Password = password_encriptado;



        DataSet ds = null;
        ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario1, 18);


        if (Convert.ToInt32(Session["flag_verificar_roles"]) > 0)
        {
            if (TextBoxCorreoAlternativo.Text == Convert.ToString(Session["codigo_verificacion"]))
            {
                DataSet ds2 = null;


                usuario1.P_usuario_creacion = Convert.ToString(ds.Tables[0].Rows[0]["id_usuario"]);
                usuario1.F_Nombre = ip_mac();
                usuario1.F_TIPO_USUARIO = Convert.ToInt32(ds.Tables[0].Rows[0]["id_tipo_usuario"]);


                Usuario usuario = new Usuario();

                usuario.F_ID_USUARIO = Convert.ToInt32(Session["id_usuario"]);

                ds2 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario1, 13);
                Session.Add("ID_AUDITORIA", ds2.Tables[0].Rows[0]["ID_AUDITORIA"].ToString());

                Session["conteo_pass"] = 0;

                usuario.Apellidos = "Exitoso";
                usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                //Session["conteo_pass"] = 0;



                usuario.F_id_persona = 1; //id_estado
                usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                usuario.Login = TextBoxUsuario.Text.Trim();
                FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

                Response.Redirect("Inicio_perfil.aspx");
            }
            else
            {

                error_segunda.Visible = true;
                Mensajes("El codigo no es valido", 0);
                texto("Cambio de ordenador... <p> Detectamos que actualmente estas ingresando desde un ordenador distinto al registrado por última vez en el sistema. A continuación se enviara un código de verificación a tu correo registrado. </p> <p> <i>Nota: Ten en cuenta que si cierras esta ventana volveremos a generar un nuevo código de verificación cuando intentes volver a ingresar</i> </p>", 2);
                Mensajes_3("Advertencia", this.L_mensaje.Text, 2);

            }

        }
        else
        {


            if (TextBoxCorreoAlternativo.Text == Convert.ToString(Session["codigo_verificacion"]))
            {

                Panel1.Visible = true;
                Panel0.Visible = false;

                DataSet ds2 = null;

                Usuario usuario = new Usuario();

                //msm.Visible = false;
                string script = "";
                usuario.Apellidos = "Exitoso";
                usuario.Email = "Ingreso Correcto, Cantidad de veces fallidas: " + Convert.ToString(Session["conteo_pass"]);
                Session["conteo_pass"] = 0;
                usuario.F_id_persona = 1; //id_estado
                usuario.F_TIPO_USUARIO = 0;  //id_tipo_bloqueo
                usuario.Login = TextBoxUsuario.Text.Trim();
                FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 
                //script = @"<script type='text/javascript'> $( '#ContentPlaceHolder1_upModal' ).hide(); </script>";
                script = @"<script type='text/javascript'> 
                    $( '#ContentPlaceHolder1_myModal' ).modal('hide'); 
                    $('#M_Confirmar').modal('hide');
                    $('.modal-backdrop').remove(); 
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //myModal.Visible = false;
            }
            else
            {
                error_segunda.Visible = true;
                Mensajes("El codigo no es valido", 0);
                texto("Cambio de ordenador... <p> Detectamos que actualmente estas ingresando desde un ordenador distinto al registrado por última vez en el sistema. A continuación se enviara un código de verificación a tu correo registrado. </p> <p> <i>Nota: Ten en cuenta que si cierras esta ventana volveremos a generar un nuevo código de verificación cuando intentes volver a ingresar</i> </p>", 2);
                Mensajes_3("Advertencia", this.L_mensaje.Text, 2);

            }
        }




    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        DataSet ds_sesion_duplicada = null;
        Usuario usuario_sesion_duplicada = new Usuario();

        usuario_sesion_duplicada.F_ID_USUARIO = Convert.ToInt32(Session["id_usuario"]);
        ds_sesion_duplicada = FachadaPersistencia.getInstancia().administrar_sesion_duplicada(usuario_sesion_duplicada, 0);
        if (ds_sesion_duplicada.Tables[0].Rows.Count > 0)
        {
            if (ds_sesion_duplicada.Tables[0].Rows[0]["FECHA_HORA_SALIDA"].ToString() != "")
            {
                Response.Redirect("Salir.aspx");
            }
        }


    }


}
