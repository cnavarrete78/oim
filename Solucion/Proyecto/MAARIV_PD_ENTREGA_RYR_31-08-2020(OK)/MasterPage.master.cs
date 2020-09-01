/*
 **********************************************************************************************
  PROGRAMA				: MasterPage.cs
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
  FECHA DE CREACION	    : Mayo 29 de 2010
  USUARIO MODIFICA      : GUSTAVO ADOLFO CAICEDO VIVEROS
  FECHA DE MODIFICACION : 15-02-2016
  VERSION               : 1.2  
 ***********************************************************************************************
  CLASE			        : MasterPage
  RESPONSABILIDAD	    : Se encarga de colocar un formato de presentacion a la pagina general
  COLABORACION		    : 
************************************************************************************************
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using com.GACV.lgb.modelo;
using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.persistencia.fachada;

using System.Security.Principal;
using System.Web.Security;
using com.logica.notificaciones; 

public partial class MasterPage : System.Web.UI.MasterPage
{

    private List<String> arr_menu = new List<String>();
    private List<String> arr_urls = new List<String>();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string path2 = Server.MapPath(".\\js\\bootstrap.min.js");

            String filename = Request.FilePath;
            String[] path = filename.Split('/');
            filename = path[path.Length - 1];

            String urlstring = Request.Url.ToString();  
            String[] urlAcceso = urlstring.Split('/');           
            
            urlstring = urlAcceso[(urlAcceso.Length) - 1];
            String[] urlResumen = urlstring.Split('?');

            string prueba = Request.QueryString["Token"]; 

            //DataTable urlPermisos;    
            string urlstring_validator = filename;
            int count = 0;

            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);

            if ((!filename.Equals("Presentacion.aspx")) && (!filename.Equals("ContenidoInicio.aspx")))
            {
                if (filename.Equals("Presentacion.aspx"))
                {
                    Session.Abandon();
                }

                if (Session["usuario"] == null || Convert.ToString(Session["usuario"]) == "")
                {
                    if (filename.Equals("Presentacion.aspx"))
                    {
                        Response.Redirect("Presentacion.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Presentacion.aspx?caso=1");
                    }
                }
                else
                {
                    if (Request.Params["Nav"] != null)
                    {
                        //LabelNavegacion.Text = Request.Params["Nav"];
                    }
                    else if (Request.Params["formato"] != null)
                    {
                        //LabelNavegacion.Text = Request.Params["formato"];
                    }

                    // ruta modulos/Seguridad/Administrador_permisos.aspx?Nav=Administracion/Seguridad
                    //this.ImageButton1.Visible = true;

                    Usuario usuario = new Usuario();

                    usuario.Identificacion = Convert.ToString(Session["identificacion"]);
                    usuario.P_ROL = Convert.ToInt32(Session["rol"]);

                    DataSet ds = new DataSet();
                    ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 7);

                    if (ds != null)
                    {
                        if (!ds.Tables[0].Rows.Count.Equals(0))
                        {
                            String[] strlist = Convert.ToString( ds.Tables[0].Rows[0]["NOMBRE"].ToString()).Split(' ');
                            String[] strlist1 = Convert.ToString(ds.Tables[0].Rows[0]["APELLIDOS"].ToString()).Split(' ');
                            this.L_B_Usuario.Text = strlist[0] + " " + strlist1[0];
                            this.L_B_Usuario.Visible = true;

                            //this.ImageButton1.Visible = true;
                            //this.LabelNavegacion.Visible = true;   
                            
                            DataSet tabPerm = null;
                            string rol = Session["rol"].ToString(); 

                            if (rol != "") //Usuarios
                            {
                                tabPerm = FachadaPersistencia.getInstancia().permisos_tipo_usuario(Convert.ToInt32(Session["rol"]));

                                if ((urlstring_validator == "Administrar_datos_src.aspx") || (urlstring_validator == "Consultar_datos_src.aspx")
                                    || (urlstring_validator == "Administrar_Actividad_Fondo_Educacion.aspx") || (urlstring_validator == "Administrar_Grupo_Fondo_Educacion.aspx")
                                    || (urlstring_validator == "Asociar_Grupo_Fondo_Educacion_Victima.aspx")
                                   )
                                {
                                    urlstring_validator = "Inicio_perfil.aspx";
                                }

                                if (urlstring_validator == "Inicio_perfil.aspx")
                                {
                                    if (!tabPerm.Tables[0].Rows.Count.Equals(0))
                                    {
                                        /* permite validar si un usuario La página Logon.aspx 
                                         * recoge las credenciales del usuario (dirección de correo electrónico y contraseña) y las autentica. Si el usuario es autenticado correctamente, 
                                         * la página de inicio de sesión le redirige a la página solicitada originalmente. En el ejemplo, las credenciales válidas están incluidas en el código de la página.
                                         */

                                        //FormsAuthentication.RedirectFromLoginPage(UserEmail.Text, Persist.Checked);

                                        PermisoRol perRol = construirPermisosRol(tabPerm);
                                        List<Permiso> listaPer = perRol.Permisos;
                                        List<Permiso> listaMod = new List<Permiso>();
                                        Permiso mod = null;

                                        for (int i = 0; i < listaPer.Count; i++)
                                        {
                                            mod = listaPer[i];
                                            if (mod.Id_padre.Equals(""))
                                            {
                                                listaMod.Add(mod);
                                            }
                                        }

                                        construirMenu(listaPer, listaMod, perRol);
                                        construirMenu2(listaPer, listaMod, perRol);
                                    }
                                }
                                else
                                {
                                    // recorro los permisos a los que puede acceder un usuario
                                    for (int i = 0; i <= tabPerm.Tables[0].Rows.Count - 1; i++)
                                    {
                                        String[] path_val = tabPerm.Tables[0].Rows[i]["Url_Permiso"].ToString().Split('/');
                                        string filename_val = path_val[path_val.Length - 1];


                                        if (urlstring_validator == filename_val)
                                        {
                                            count++;
                                        }
                                    }

                                    if (count == 0)
                                    {
                                        Session.Abandon();
                                        Response.Redirect("~/Presentacion.aspx");
                                    }
                                    else 
                                    {
                                        if (!tabPerm.Tables[0].Rows.Count.Equals(0))
                                        {
                                            PermisoRol perRol = construirPermisosRol(tabPerm);
                                            List<Permiso> listaPer = perRol.Permisos;
                                            List<Permiso> listaMod = new List<Permiso>();
                                            Permiso mod = null;

                                            for (int i = 0; i < listaPer.Count; i++)
                                            {
                                                mod = listaPer[i];
                                                if (mod.Id_padre.Equals(""))
                                                {
                                                    listaMod.Add(mod);
                                                }
                                            }

                                            construirMenu(listaPer, listaMod, perRol);
                                            construirMenu2(listaPer, listaMod, perRol);
                                        }
                                    }
                                }
                                
                                                              
                            }
                        }
                    }
                    else
                    {
                        //this.L_B_nombre_entidad.Text = "";
                        //this.L_B_nombre_entidad.Visible = true;

                        this.L_B_Usuario.Text = "";
                        this.L_B_Usuario.Visible = true;

                        //this.ImageButton1.Visible = true;
                        //this.LabelNavegacion.Visible = true;

                        //this.ImageButton1.Visible = true;
                    }                   
                }
            }
        }
        catch (System.Exception ex)
        {
            Mensajes("No hay conexion con la base de datos" ,0);
        }

        #region NOTIFICACIONES
        try
        {
            //datalist create
           String datalistmenu = "<datalist id='menus'>";
           for (int i = 0; i < this.arr_menu.Count; i++)
           {
               datalistmenu += "<option value='" + this.arr_urls[i] + "' label='" + this.arr_menu[i] + "'></option>";
           }
           datalistmenu += "</datalist>";
           //datalistMenu.Text = datalistmenu;

            DataSet ds_noti = new DataSet();
            DAONotificaciones NOTI = new DAONotificaciones();
            NOTI.P_ID_USUARIO_RECEPTOR = Convert.ToInt32(Session["id_usuario"]);
            ds_noti = NOTI.Notificaciones_Store(NOTI,0); //buscar notificaciones
            if (!ds_noti.Tables[0].Rows.Count.Equals(0))
            {
                notificacion_label.Text = NOTI.printLabel(ds_noti);
                numero_bell.Text = Convert.ToString(ds_noti.Tables[0].Rows.Count);
            }
            

        }
        catch (System.Exception ex)
        {
            //Mensajes("No existen notificiaciones", 0);
        }
        #endregion
    }

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

    #endregion
    
    #region METODOS

        //  permite la construccion del menu
        private void construirMenu(List<Permiso> permisos, List<Permiso> modulos, PermisoRol perRol)
        {
            MenuItem item = null;
            Permiso modulo = null;
            List<Permiso> hijosMod = null;
            Menu1.Items.Clear();
            for (int i = 1; i < modulos.Count; i++)
            {
                item = new MenuItem();
                modulo = modulos[i];
                item.Text = modulo.Nombre_permiso;
                item.Value = modulo.Id_permiso;
                item.ImageUrl = modulo.Icono;
                item.NavigateUrl = modulo.Url_permiso;
                Menu1.Items.Add(item);
                hijosMod = perRol.obtenerHijos(modulo.Id_permiso);
               
                for (int j = 0; j < hijosMod.Count; j++)
                {
                    construirSubMenu(hijosMod[j], item, perRol);
                }
            }
        }

        private void construirMenu2(List<Permiso> permisos, List<Permiso> modulos, PermisoRol perRol)
        {
            MenuItem item1 = null;
            Permiso modulo = null;
            List<Permiso> hijosMod = null;
            Menu2.Items.Clear();
            for (int i = 0; i < 1; i++)
            {
                item1 = new MenuItem();
                modulo = modulos[i];
                item1.Text = modulo.Nombre_permiso;
                item1.Value = modulo.Id_permiso;
                item1.ImageUrl = modulo.Icono;
                item1.NavigateUrl = modulo.Url_permiso;
                Menu2.Items.Add(item1);
                hijosMod = perRol.obtenerHijos(modulo.Id_permiso);

                for (int j = 0; j < hijosMod.Count; j++)
                {
                    construirSubMenu(hijosMod[j], item1, perRol);
                }
            }
        }

        // permite construir el submenu
        private void construirSubMenu(Permiso permiso, MenuItem padre, PermisoRol perRol)
        {
            MenuItem hijo = new MenuItem();
            hijo.Text = permiso.Nombre_permiso;
            hijo.Value = permiso.Id_permiso;
            hijo.ImageUrl = permiso.Icono;
            hijo.NavigateUrl = permiso.Url_permiso;            
            padre.ChildItems.Add(hijo);

            // permite construir una lista en javascript de las url y nombres
            this.arr_urls.Add(permiso.Url_permiso);
            this.arr_menu.Add(padre.Text + " - " + permiso.Nombre_permiso);

            List<Permiso> nuevosHijos = perRol.obtenerHijos(permiso.Id_permiso);
            for (int i = 0; i < nuevosHijos.Count; i++)
            {
                construirSubMenu(nuevosHijos[i], hijo, perRol);
            }
        }

        // permite construirl los permisos por rol
        private PermisoRol construirPermisosRol(DataSet tabPerm)
        {
            PermisoRol permisoRol = new PermisoRol();
            Permiso permiso = null;

            for (int i = 0; i < tabPerm.Tables[0].Rows.Count; i++)
            {
                permiso = new Permiso();
                permiso.Id_permiso = tabPerm.Tables[0].Rows[i]["Id_Permiso"].ToString();
                permiso.Url_permiso = tabPerm.Tables[0].Rows[i]["Url_permiso"].ToString();
                permiso.Id_padre = tabPerm.Tables[0].Rows[i]["Id_Padre"].ToString();
                permiso.Nombre_permiso = tabPerm.Tables[0].Rows[i]["Nombre_Permiso"].ToString();
                permiso.Descripcion_permiso = tabPerm.Tables[0].Rows[i]["Descripcion_Permiso"].ToString();
                permiso.Icono = tabPerm.Tables[0].Rows[i]["Icono"].ToString();

                permisoRol.adicionarPermiso(permiso);
            }
            // string id_perm = "";
            return permisoRol;
        }

    #endregion

    #region EVENTOS

        void mnuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Salir.aspx");
        }
    /*

        // TODO:  PRUEBAS PARA MEJORAR LA SEGURIDAD
        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;

            //Chequeo de usuario y contraseña 
            SeguridadEnAspNet.Usuario oUser = new SeguridadEnAspNet.Usuario();
            string perfil = oUser.GetPerfil(user, password);
            
            if (perfil.Length > 0) // perfil vacío significa que no fue encontrado 
            {
                //Invoca a componente que se encarga del Cache de los datos 
                //en este caso de las páginas a las que el perfil tiene acceso 
                SeguridadEnAspNet.UserCache.AddPaginasToCache(perfil, SeguridadEnAspNet.Perfiles.GetPaginas(perfil), System.Web.HttpContext.Current);
                // Crea un ticket de Autenticación de forma manual, 
                // donde guardaremos información que nos interesa 
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(   2,  // version 
                                                                                        user,
                                                                                        DateTime.Now,
                                                                                        DateTime.Now.AddMinutes(60),
                                                                                        false,
                                                                                        perfil, // guardo el perfil del usuario 
                                                                                        FormsAuthentication.FormsCookiePath
                                                                                     );
                // Encripto el Ticket. 
                string crypTicket = FormsAuthentication.Encrypt(authTicket);
                
                // Creo la Cookie 
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, crypTicket);
                Response.Cookies.Add(authCookie);
                // Redirecciono al Usuario - Importante!! no usar el RedirectFromLoginPage 
                // Para que se puedan usar las Cookies de los HttpModules 
                Response.Redirect(FormsAuthentication.GetRedirectUrl(user, false));
            }
            else
                // Muestro mensaje de error 
                tblWarning.Style["display"] = "";
        }

        
        /// <summary> 
        /// Modulo de Administración de la Seguridad 
        /// Seguridad basada en Forms 
        /// </summary> 
        public class CustomAuthenticationModule : IHttpModule
        {
            public CustomAuthenticationModule()
            { }

            /// <summary> 
            /// Inicializa el HTTPModule y asigna los EventHandlers a cada Evento 
            /// Esta es la parte donde se define a que eventos va a atender el HttpModule 
            /// </summary> 
            /// <param name="oHttpApp"></param> 
            public void Init(HttpApplication oHttpApp)
            {
                // Se Registran los Manejadores de Evento que nos interesa 
                oHttpApp.AuthorizeRequest += new EventHandler(this.AuthorizaRequest);
                oHttpApp.AuthenticateRequest += new EventHandler(this.AuthenticateRequest);
            }

            public void Dispose()
            { }

            /// <summary> 
            /// Administra la autorización por Request 
            /// </summary> 
            /// <param name="sender"></param> 
            /// <param name="e"></param> 
            private void AuthorizaRequest(object sender, EventArgs e) 
            {     
                if (HttpContext.Current.User != null) 
                { 
                    //Si el usuario esta Autenticado 
                    if (HttpContext.Current.User.Identity.IsAuthenticated) 
                    { 
                            if (HttpContext.Current.User is MyApp.Seguridad.FormsPrincipal) 
                            { 
                                MyApp.Seguridad.FormsPrincipal principal = (SeguridadEnAspNet.FormsPrincipal) HttpContext.Current.User; 
                                    
                                //Se verifica si el Perfil del usuario tiene autorización para acceder a la página 
                                if (!principal.IsPageEnabled(HttpContext.Current.Request.Path) ) 
                                    HttpContext.Current.Server.Transfer( "Presentacion.aspx"); 
                            } 
                    } 
                } 
            }

            /// <summary> 
            /// Autentica en Cada Request 
            /// </summary> 
            /// <param name="sender"> HttpApplication </param> 
            /// <param name="e"></param> 
            private void AuthenticateRequest(object sender, EventArgs e)
            {
                if (HttpContext.Current.User != null)
                {
                    //Si el usuario esta Autenticado 
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        if (HttpContext.Current.User.Identity is FormsIdentity)
                        {
                            //Traigo el Rol que esta guardado en una Cookie encriptada 
                            FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                            FormsAuthenticationTicket ticket = id.Ticket;

                            string cookieName = System.Web.Security.FormsAuthentication.FormsCookieName;
                            string userData = System.Web.HttpContext.Current.Request.Cookies[cookieName].Value;
                            ticket = FormsAuthentication.Decrypt(userData);
                            string rol = "";

                            if (userData.Length > 0)
                                rol = ticket.UserData;

                            //Se crea la clase Principal  y se asigna al CurrenUser del Contexto
                            HttpContext.Current.User = new SeguridadEnAspNet.FormsPrincipal(_identity, perfil);
                        }
                    }
                }
            }//AuthenticateRequest 
        
        } //class 
        
     * */
    #endregion
            
}
