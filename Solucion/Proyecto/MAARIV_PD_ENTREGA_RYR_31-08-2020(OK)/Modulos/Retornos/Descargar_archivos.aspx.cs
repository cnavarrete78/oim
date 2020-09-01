/*
 *************************************************************************************************
  PROGRAMA				: Descargar_archivos.aspx.cs
  FECHA DE CREACION	    : 02/08/2017
  FECHA DE MODIFICACION : 
  VERSION               : 1.0
  AUTOR                 : Gustavo Adolfo Caicedo Viveros
                          Control y seguimiento
 *************************************************************************************************
  CLASE			        : Descargar_archivos.aspx.cs
  RESPONSABILIDAD	    : Descarga los documentos(evidencias) del modulo maestro
  COLABORACION		    : 
**************************************************************************************************
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.GACV.lgb.persistencia.fachada;
using com.GACV.lgb.modelo.adjuntar_archivos_act;
using System.IO;

public partial class Descargar_archivos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["ID_AC"] != null)
                {
                    if (Request.QueryString["ID_U2I"] != null || Request.QueryString["ID_U3I"] != null)
                    {
                        this.id_actividad_archivo.Value = Convert.ToInt32(Base64Decode(Request.QueryString["ID_AC"])).ToString();
                        this.id_usuario_2da_instancia.Value = Convert.ToInt32(Base64Decode(Request.QueryString["ID_U2I"])).ToString();
                        this.id_usuario_3ra_instancia.Value = Convert.ToInt32(Base64Decode(Request.QueryString["ID_U3I"])).ToString();

                        gv16_SelectedIndexChanged(Convert.ToInt32(this.id_actividad_archivo.Value), Convert.ToInt32(this.id_usuario_2da_instancia.Value), Convert.ToInt32(this.id_usuario_3ra_instancia.Value));
                    }
                }
                else
                {
                    texto("Error al leer el archivo(ID)!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            catch
            {
                //Mensajes("Alerta!... Usted no posee permisos para realizar cambios en el formulario.", 1);
                texto("Alerta!... Usted no posee permisos para realizar cambios en el formulario.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            }
        }
    }

    #region LISTAS DESPLEGABLES

    // Lista desplegable del tipo de documento        

    #endregion

    #region MENSAJES

    private void Mensajes(string mensaje, int opc)
    {
        string script = "";
        switch (opc)
        {
            case 0:
                script = @"<script type='text/javascript'> alert('" + mensaje + "'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;
            case 1:
                script = @"<script type='text/javascript'> alert('" + mensaje + "'); window.close(); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;
            case 2:
                script = @"<script type='text/javascript'> alert('" + mensaje + "'); window.opener.location = window.opener.location; window.close(); </script>";
                //script = @"<script type='text/javascript'> alert('" + mensaje + "'); top.location.reload(true); window.close(); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                break;
            case 6:
                // permite abrir una ventana adicional como popup
                string popupScript = "<script language='JavaScript'> " + "{ " + " var leftPos = (screen.width-600)/2; " + " var topPos = (screen.height-400)/2; " + " window.open('" + mensaje + "','Info','status=0 , titlebar=0, location=0, scrollbars=1, status=no, resizable=0, menubar=no, top='+ topPos +', left='+ leftPos ); " + "} </script> ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript, false);
                break;
            case 7:
                // permite abrir una ventana adicional como popup
                string popupScript2 = "<script language='JavaScript'> " + "{ " + " var leftPos = (screen.width-600)/2; " + " var topPos = (screen.height-400)/2; " + " window.open('" + mensaje + "','Info','Width=400px, Height=400px, status=0 , titlebar=0, location=0, scrollbars=1, status=yes, resizable=1, menubar=no, top='+ topPos +', left='+ leftPos ); " + "} </script> ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
                break;
            case 8: // permite validar un opcion de confirmacion
                script = @"<script type='text/javascript'> confirm('" + mensaje + "'); </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Confirmar", script, false);
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
                //B_Confirmacion_accion.Visible = false;
                CB_Valida_accion.Visible = false;

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
                //B_Confirmacion_accion.Visible = false;

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
                //B_Confirmacion_accion.Visible = false;

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
                CB_Valida_accion.Visible = true;
                CB_Valida_accion.Checked = false;
                CB_Valida_accion.Text = "Aceptar";
                //B_Confirmacion_accion.Visible = true;
                //B_Confirmacion_accion.Text = "Continuar";

                break;
        }

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
        upModal.Update();
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
        }

    }

    #endregion

    #region METODOS

    private void LimpiaFormulario(Control parent)
    {
        foreach (Control ctrControl in parent.Controls)
        {
            if (object.ReferenceEquals(ctrControl.GetType(), typeof(TextBox)))
            {
                //textbox 
                ((TextBox)ctrControl).Text = string.Empty;
            }
            else if (object.ReferenceEquals(ctrControl.GetType(), typeof(DropDownList)))
            {
                //dropdownlist 
                ((DropDownList)ctrControl).SelectedIndex = -1;
            }
            else if (object.ReferenceEquals(ctrControl.GetType(), typeof(CheckBox)))
            {
                //checkboxes
                ((CheckBox)ctrControl).Checked = false;
            }
            else if (object.ReferenceEquals(ctrControl.GetType(), typeof(RadioButton)))
            {
                //RadioButtons
                ((RadioButton)ctrControl).Checked = false;
            }
            else if (object.ReferenceEquals(ctrControl.GetType(), typeof(GridView)))
            {
                //GridView
                ((GridView)ctrControl).DataSource = null;
                ((GridView)ctrControl).DataBind();
            }
            if (ctrControl.Controls.Count > 0)
            {
                //Recursividad
                LimpiaFormulario(ctrControl);
            }
        }
    }

    //Permite descargar los archivos adjuntos
    private void gv16_SelectedIndexChanged(int id_actividad_archivo, int id_usuario_2da_instancia, int id_usuario_3ra_instancia)
    {
        try
        {
            Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
            DataSet ds = new DataSet();

            byte[] Contenido;
            string extension = string.Empty;

            //adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(((Label)(gv16.SelectedRow.Cells[0].FindControl("id_actividad_archivo"))).Text);
            adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = id_actividad_archivo;
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 1);            
        
            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                
                if ((Convert.ToInt32(ds.Tables[0].Rows[0]["ID_ACTIVIDAD_ARCHIVO_ESTADO"]) == 1) && ((id_usuario_2da_instancia == Convert.ToInt32(Session["rol"])) || (id_usuario_3ra_instancia == Convert.ToInt32(Session["rol"]))))
                {
                    ActualizaGrid_archivo(id_actividad_archivo);
                } 
                FileStream Archivo = new FileStream(System.Configuration.ConfigurationManager.AppSettings["Archivos"] + Convert.ToString(ds.Tables[0].Rows[0]["URL_ARCHIVO"]), FileMode.Open, FileAccess.Read);
                extension = (Convert.ToString(ds.Tables[0].Rows[0]["EXTENSION"]));

                Contenido = new byte[Archivo.Length];
                Archivo.Read(Contenido, 0, (int)Archivo.Length);
                Response.ClearContent(); //Borra todo el contenido del buffer
                Response.ClearHeaders(); //Borra todos los encabezados
                Response.Buffer = true;
                Response.ContentType = extension; //Se establece el tipo MIME
                if (Convert.ToString(ds.Tables[0].Rows[0]["EXTENSION"]).ToUpper() == ".PDF")
                {
                    Response.AddHeader("content-disposition", " filename=" + Convert.ToString(ds.Tables[0].Rows[0]["NOMBRE_ARCHIVO"]) + extension); //attachment;
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=" + Convert.ToString(ds.Tables[0].Rows[0]["NOMBRE_ARCHIVO"]) + extension); //attachment;

                }
                Response.BinaryWrite(Contenido); //Escribe datos binarios en el flujo de salida HTTP y por tanto, se muestra o descarga el archivo
                Archivo.Close();
                Contenido = null;

                //HttpContext.Current.ApplicationInstance.CompleteRequest();

                Response.End();          
            }
            else
            {
                texto("El archivo se encuentra en blanco!.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
            }
        }
        catch//(ThreadAbortException)
        {
            texto("Error al leer el archivo!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }

        //TabName.Value = "Documentos";
    }

    //decodifica strings
    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

    // permite actualizar los datos adjuntos
    private void ActualizaGrid_archivo(int id_actividad_archivo)
    {
        try
        {
            int valor = 0;

            Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
            DataSet ds = new DataSet();

            adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = id_actividad_archivo;
            adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO = 2;
            adjuntar_archivos.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

            valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 5);

            if (valor != 0)
            {
                texto("El estado del documento fue actualizado correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                //CargaGrid_archivo();
            }
            else
            {
                texto("No se pudo actualizar el estado del documento!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            }
        }
        catch (System.Exception ex)
        {
            texto("Error al actualizar el estado del documento!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    #endregion

    #region EVENTOS

    #region DOCUMENTACION

    #endregion

    #endregion
}

