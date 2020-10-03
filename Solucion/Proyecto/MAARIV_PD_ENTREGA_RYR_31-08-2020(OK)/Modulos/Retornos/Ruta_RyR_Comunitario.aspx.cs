/*
 *************************************************************************************************
  PROGRAMA				: Ruta_RyR_Comunitario.aspx.cs
  FECHA DE CREACION	    : 21/03/2019
  FECHA DE MODIFICACION : --/--/---
  VERSION               : 1.0
  AUTOR                 : Brayan Stiven Herreño Beltran

 *************************************************************************************************

  CLASE			        : Ruta_RyR_Comunitario.aspx.cs
  FECHA DE MODIFICACION : 25/11/2019
  RESPONSABILIDAD	    : Se encarga se encarga de administrar el proceso de r y r comunitario
  COLABORACION		    : JOSE MIGUEL ACOSTA IMBACHI - EMERSON PULIDO NOY - Brayan Stiven Herreño Beltran
**************************************************************************************************
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.GACV.lgb.persistencia.fachada;
using com.GACV.lgb.modelo.sujeto_colectiva;
using com.GACV.lgb.modelo.actividad;
using com.GACV.lgb.modelo.actividad_detalle;
using com.GACV.lgb.modelo.actividad_responsable;
using com.GACV.lgb.modelo.actividad_cobertura;
using com.GACV.lgb.modelo.actividad_dia;
using com.GACV.lgb.modelo.persona;
using com.GACV.lgb.modelo.adjuntar_archivos_act;
using com.GACV.lgb.modelo.arbolespirc;
using System.IO;
using com.GACV.lgb.modelo.Actividad_dia_bitacora;
using com.GACV.lgb.modelo.actividad_dia_costo;
using com.GACV.lgb.modelo.actividad_producto;
using System.Text;
using System.Web.UI.HtmlControls;

using System.Web.Security;

using System.Threading;

//using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using com.GACV.lgb.modelo.email;
using System.Net.Mail;

using com.logica.correo;
using com.logica.Buscador;

using System.IO.Compression;
using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.modelo.ADEP;
using com.GACV.lgb.modelo.ADES;

public partial class Ruta_RyR_Comunitario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (this.IsPostBack)
        {
            TabName.Value = Request.Form[TabName.UniqueID];

            this.L_mensaje.Text = "";

            if (gv16.Visible && Panel252.Visible && gv16.Rows.Count > 0)
            {
                gv16_visual();
            }

            if (gv.Visible && gv.Rows.Count > 0)
            {
                gv_visual();
            }

        }

        if (!IsPostBack)
        {


            this.id_dependencia.Value = "14"; //ID de la dependencia a la cual pertenece la actividad
            this.id_actividad_nombre.Value = "49"; //Parametriza los metodos y valida la busqueda de las personas en la pestaña CONVOCATORIA segun el tipo y/o grupo de las actividades (focalización), cuando aplique
            this.id_actividad_responsable_rol.Value = "14"; //ID opción lista desplegable del ROL en la pestaña responsable al crear una actividad(default)
            this.id_usuario_territorio.Value = "46"; //Puede crear y actualizar sus eventos mientras esten en estado ACTIVO
            this.id_usuario_2da_instancia.Value = "47"; //Puede actualizar el estado de la actividad a REVISADO
            this.id_usuario_3ra_instancia.Value = "9"; //Puede actualizar el estado de la actividad a APROBADO
            this.id_val_pduplicadas_asist.Value = "1"; //Valida si se puede o no duplicar personas en las actividades (1->SI, 2->NO) ASISTENCIA
            this.id_val_pduplicadas_convo.Value = "1"; //Valida si se puede o no duplicar personas en las actividades (1->SI, 2->NO) CONVOCATORIA
            this.archivo_filesystem.Value = "MM\\RUTA_RYR_COMUNITARIO"; //Establece la ruta del sistema de archivos donde se guardaran los docs y/o evidencias de este modulo
            this.opcion_tipo_archivo.Value = "68"; //Valida los tipos de documentos adjuntos para su cargue segun la actividad
            this.opcion_tipo_detalle.Value = "31"; //Valida las opciones de la lista desplegable de tipo detalle
            this.opcion_Subcategoria.Value = "10"; //Valida las opciones de la lista desplegable de tipo detalle
            this.opcion_rol_responsable.Value = "25"; //Valida las opciones para el rol de los responsables -> 0 para valor dafault(valores estandar) en el SP
            this.id_val_HV_asist.Value = "3"; //Valida hecho victimizante (0->no visible 1->modifica(obligatorio >=1) 2->modifica(no obligatorio)  3->consulta(HV persona, no modifica))
            this.id_val_HV_convo.Value = "3"; //Valida hecho victimizante (0->no visible 1->modifica(obligatorio >=1) 2->modifica(no obligatorio)  3->consulta(HV persona, no modifica))            
            this.opcion_lista_usuarios.Value = "23"; //Valida el listado de usuarios para los filtros de busqueda, tanto en actividades como en responsables en el SP
            this.id_tipo_persona.Value = "48"; //Asigna el ID tipo persona al momento de crear personas nuevas en la tabla TBL_RPERSONA, NO incluir valores 0 y ""            
            this.id_consultap_focalizados_asis.Value = "1"; //Asigna el ID de la opcion para la consulta de personas en asistencia. 1->consulta tabla tbl_rpersona 2->consulta tabla tbl_rpersona_focalizacion
            this.id_consultap_focalizados_convo.Value = "1"; //Asigna el ID de la opcion para la consulta de personas en convocatoria. 1->consulta tabla tbl_rpersona 2->consulta tabla tbl_rpersona_focalizacion

            this.opcion_tipo_detalle_costos.Value = "50"; //variable que carga los tipos de costos de un producto o actividad ---""··para colectiva ---""--



            L_D_Zona();
            L_D_tipo_sujeto();
            L_D_alcance(Convert.ToInt32(Session["rol"]));
            //guardar.Visible = true;
            actualizar.Visible = false;
            Session["ID_RYR_COMUNIDAD"] = "";
            ViewState["ID_RYR_COMUNIDAD"] = "0";
            LD_Actividad_nombre(14, 1);
            LD_Tipo_archivo(1, 3);
            LD_departamento();
            L_D_Territorial();
            L_D_Usuario(Convert.ToInt32(this.id_dependencia.Value), Convert.ToInt32(this.opcion_lista_usuarios.Value));
            LD_Rol_responsable();
            L_D_DepArchivo();

            valida_permisos_rol();

            //carga departamentos 
            //LD_Departamento.Enabled = true;
            L_D_Departamentos_2();
            //LD_Municipio.Items.Clear();
            //carga departamentos
            if (Convert.ToString(Session["rol"]) != "1" && Convert.ToString(Session["rol"]) != "37" && Convert.ToString(Session["rol"]) != "145")
            {
                LD_estado_sujeto_colectivodiv.Visible = false;
            }
            else
            {
                LD_estado_sujeto_colectivodiv.Visible = true;
            }




        }

        ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(EXCEL);
        //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(descargar_todo);
    }

    //CLASE PÚBLICA PARA VALIDAR LOS ROLES QUE TENDRÁN ACCESO A LA CREACIÓN DE PERSONAS.
    public class GlobalVariables
    {
        public static int[] id_rol_permiso_creacion_persona = { 0, 0, 0, 0, 0 }; //agregar los ID rol (usuarios) que pueden crear personas en asistencia, NO SE DEBE INCLUIR EL ROL ADMIN(1)
        public static int[] id_rol_territorio_colectiva = { 133, 136, 139, 142, 151, 152, 153 };
        public static int[] id_rol_2da_instancia_colectiva = { 132, 138, 146, 144, 152 };


        public static int[] id_roles_permiso
        {
            get { return id_rol_permiso_creacion_persona; }
            set { id_rol_permiso_creacion_persona = value; }
        }


        public static int[] id_usuario_territorioA
        {
            get { return id_rol_territorio_colectiva; }
            set { id_rol_territorio_colectiva = value; }
        }



        public static int[] id_usuario_2da_instanciaA
        {
            get { return id_rol_2da_instancia_colectiva; }
            set { id_rol_2da_instancia_colectiva = value; }
        }
    }


    #region correo
    // PERMITE ENVIAR UN CORREO 
    public int Crear_correo(DataSet correos_enviar, string asunto, string[] datos, int opcion, int responsables)
    {
        Correos correo = new Correos();

        //creacion del correo
        correo.CrearCorreo(asunto, datos, opcion); //opcion 2 envio de actualizaciones en jornadas/actividades
        //envio a los diferentes correos del dataset
        int valor_mail = 0;
        List<string> send_to = new List<string>();
        string cor = "";
        if (correos_enviar != null)
        {
            if (responsables == 0) // a todos
            {
                for (int i = 0; i < correos_enviar.Tables[0].Rows.Count; i++)
                {
                    cor = correos_enviar.Tables[0].Rows[i]["EMAIL"].ToString();
                    if (Convert.ToString(HttpContext.Current.Session["email"]) != cor)
                    {
                        send_to.Add(cor);
                    }

                }
                if (opcion == 5)
                {
                    send_to.Add("angela.rojas@unidadvictimas.gov.co");
                    send_to.Add("erika.rueda@unidadvictimas.gov.co");
                }

            }
            else if (responsables > 0)
            {
                cor = correos_enviar.Tables[0].Rows[responsables]["EMAIL"].ToString();
                send_to.Add(cor);
            }

        }
        valor_mail = correo.EnviarCorreo(send_to);
        return valor_mail;
    }
    #endregion


    #region LISTAS DESPLEGABLES


    // lista de los dias de la actividad
    public void LD_Dia_actividad(int id_actividad)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().LD_Dia_actividad(id_actividad, 1);

        L_D_dia_actividad_documentos.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            L_D_dia_actividad_documentos.DataValueField = "id_actividad_dia";
            L_D_dia_actividad_documentos.DataTextField = "dia_actividad";
            L_D_dia_actividad_documentos.DataSource = ds;
            L_D_dia_actividad_documentos.DataBind();
            L_D_dia_actividad_documentos.Items.Insert(0, new ListItem("Seleccione el día", "0"));


        }
        else
        {
            L_D_dia_actividad_documentos.Items.Insert(0, new ListItem("Seleccione el día", "0"));
        }
    }

    public void LD_Departamento_Dia()
    {
        DataSet ds_m = new DataSet();

        //ds_m = FachadaPersistencia.getInstancia().L_D_Municipio(Convert.ToInt32(LD_DepartamentoDia.SelectedValue));
        ds_m = FachadaPersistencia.getInstancia().L_D_Municipio(Convert.ToInt32(LD_DepartamentoDia.SelectedValue), 0, 0);

        LD_MunicipioDia.Items.Clear();

        if (!ds_m.Tables[0].Rows.Count.Equals(0))
        {
            LD_MunicipioDia.DataValueField = "id_municipio";
            LD_MunicipioDia.DataTextField = "municipio";
            LD_MunicipioDia.DataSource = ds_m;
            LD_MunicipioDia.DataBind();
            LD_MunicipioDia.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
        else
        {
            LD_MunicipioDia.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
    }


    public void L_D_DepArchivo()
    {
        //Tierras tierras = new Tierras();
        DataSet ds = new DataSet();

        ds = FachadaPersistencia.getInstancia().L_D_Departamentos(0);
        LD_DepArchivo.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_DepArchivo.DataValueField = "id_departamento";
            LD_DepArchivo.DataTextField = "departamento";
            LD_DepArchivo.DataSource = ds;
            LD_DepArchivo.DataBind();
            LD_DepArchivo.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
        else
        {
            LD_DepArchivo.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
    }

    public void L_D_MunArchivo()
    {
        DataSet ds_m = new DataSet();

        //ds_m = FachadaPersistencia.getInstancia().L_D_Municipio(Convert.ToInt32(LD_DepartamentoDia.SelectedValue));
        ds_m = FachadaPersistencia.getInstancia().L_D_Municipio(Convert.ToInt32(LD_DepArchivo.SelectedValue), 0, 0);

        LD_MunArchivo.Items.Clear();

        if (!ds_m.Tables[0].Rows.Count.Equals(0))
        {
            LD_MunArchivo.DataValueField = "id_municipio";
            LD_MunArchivo.DataTextField = "municipio";
            LD_MunArchivo.DataSource = ds_m;
            LD_MunArchivo.DataBind();
            LD_MunArchivo.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
        else
        {
            LD_MunArchivo.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
    }

    // lista deplegable de las zonas
    public void L_D_Zona()
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Zona();
        L_D_zona.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            L_D_zona.DataValueField = "id_zona";
            L_D_zona.DataTextField = "zona";
            L_D_zona.DataSource = ds;
            L_D_zona.DataBind();
            L_D_zona.Items.Insert(0, new ListItem("Seleccionar la zona", "0"));
        }
        else
        {
            L_D_zona.Items.Insert(0, new ListItem("Seleccionar la zona", "0"));
        }
    }

    public void L_D_Encuentro(int fase)
    {

        DataSet ds = new DataSet();
        ViewState["fase"] = "";

        try
        {
            //ds = FachadaPersistencia.getInstancia().LD_Tipo_actividad2(fase, Convert.ToInt32(this.opcion_tipo_detalle.Value));

            //LD_tipo_actividad.Items.Clear();

            //if (!ds.Tables[0].Rows.Count.Equals(0))
            //{
            //    LD_tipo_actividad.DataValueField = "id_tipo_actividad";
            //    LD_tipo_actividad.DataTextField = "tipo_actividad";
            //    LD_tipo_actividad.DataSource = ds;
            //    LD_tipo_actividad.DataBind();
            //    LD_tipo_actividad.Items.Insert(0, new ListItem("Seleccione el tipo de actividad", "0"));
            //}
            //else
            //{
            //    LD_tipo_actividad.Items.Insert(0, new ListItem("Seleccione el tipo de actividad", "0"));
            //}


        }
        catch
        {
            texto("Error al realizar la consulta de tipo de actividad", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }

        LD_Encuentro.Items.Clear();

        if (fase == 47)//FASE DE IDENTIFICACIÓN
        {
            LD_Encuentro.Items.Insert(0, new ListItem("Identificación", "Identificación"));
            LD_Encuentro.Items.Insert(0, new ListItem("Seleccione", "0"));

            ViewState["fase"] = "Ruta";
            //div_implementacion.Visible = true;
            gv5.Columns[2].Visible = false;
            gv5.Columns[3].Visible = false;
            gv5.Columns[4].Visible = false;
            gv5.Columns[7].Visible = false;

        }
        else if (fase == 48)//FASE DE ALISTAMIENTO
        {
            LD_Encuentro.Items.Insert(0, new ListItem("2. Segunda Jornada", "2. Segunda Jornada"));
            LD_Encuentro.Items.Insert(0, new ListItem("1. Primera Jornada", "1. Primera Jornada"));
            LD_Encuentro.Items.Insert(0, new ListItem("5. Identificar las personas que conformarán espacios de participación tales como el Comité de Impulso y Tejedores y Tejedoras o Referentes de Cuidado.", "5. Identificar las personas que conformarán espacios de participación tales como el Comité de Impulso y Tejedores y Tejedoras o Referentes de Cuidado."));
            LD_Encuentro.Items.Insert(0, new ListItem("4. Presentar la Estrategia Entrelazando como propuesta de reparación desde la medida de rehabilitación.", "4. Presentar la Estrategia Entrelazando como propuesta de reparación desde la medida de rehabilitación."));
            LD_Encuentro.Items.Insert(0, new ListItem("3. Socializar al sujeto de reparación el funcionamiento del programa de reparación colectiva, haciendo énfasis en las acciones que se desarrollan en las cinco fases de la ruta de reparación.", "3. Socializar al sujeto de reparación el funcionamiento del programa de reparación colectiva, haciendo énfasis en las acciones que se desarrollan en las cinco fases de la ruta de reparación."));
            LD_Encuentro.Items.Insert(0, new ListItem("2. Socializar al sujeto de reparación el funcionamiento del programa de reparación colectiva, haciendo énfasis en los criterios de ingreso e inicio del proceso de reparación colectiva", "2. Socializar al sujeto de reparación el funcionamiento del programa de reparación colectiva, haciendo énfasis en los criterios de ingreso e inicio del proceso de reparación colectiva"));
            LD_Encuentro.Items.Insert(0, new ListItem("1. Trabajar junto con el colectivo, conceptos introductorios y relacionados con el derecho a la reparación administrativa.", "1. Trabajar junto con el colectivo, conceptos introductorios y relacionados con el derecho a la reparación administrativa."));
            LD_Encuentro.Items.Insert(0, new ListItem("Seleccione", "0"));

            //m_12.Visible = true;
            ViewState["fase"] = "Ruta";

            gv5.Columns[2].Visible = false;
            gv5.Columns[3].Visible = false;
            gv5.Columns[4].Visible = false;
            gv5.Columns[7].Visible = false;

            //div_implementacion.Visible = false;
        }
        else if (fase == 49)//FASE DE CARACTERIZACIÓN DEL DAÑO
        {
            LD_Encuentro.Items.Insert(0, new ListItem("Caracterización del daño", "Caracterización del daño"));
            LD_Encuentro.Items.Insert(0, new ListItem("Seleccione", "0"));



            ViewState["fase"] = "Ruta";

            gv5.Columns[2].Visible = false;
            gv5.Columns[3].Visible = false;
            gv5.Columns[4].Visible = false;
            gv5.Columns[7].Visible = false;

            //div_implementacion.Visible = true;
        }
        else if (fase == 50)//FASE DE DISEÑO Y FORMULACIÓN
        {
            LD_Encuentro.Items.Insert(0, new ListItem("9. Finalizar fase de diseño, formulación y aprobación de PIRC", "9. Finalizar fase de diseño, formulación y aprobación de PIRC"));
            LD_Encuentro.Items.Insert(0, new ListItem("8. Llevar el Plan Integral de Reparación Colectiva – Documento Técnico al Subcomité Técnico para su aprobación (Solo para organizaciones y grupos)", "8. Llevar el Plan Integral de Reparación Colectiva – Documento Técnico al Subcomité Técnico para su aprobación (Solo para organizaciones y grupos)"));
            LD_Encuentro.Items.Insert(0, new ListItem("7. Llevar el Plan Integral de Reparación Colectiva – Documento Técnico ante el CTJT para su aprobación (Solo para comunidades no étnicas)", "7. Llevar el Plan Integral de Reparación Colectiva – Documento Técnico ante el CTJT para su aprobación (Solo para comunidades no étnicas)"));
            LD_Encuentro.Items.Insert(0, new ListItem("6. Validar el documento PIRC por parte del Colectivo.", "6. Validar el documento PIRC por parte del Colectivo."));
            LD_Encuentro.Items.Insert(0, new ListItem("5. Clasificación de actividades en productos y presentación de la Cadena de Valor", "5. Clasificación de actividades en productos y presentación de la Cadena de Valor"));
            LD_Encuentro.Items.Insert(0, new ListItem("4. ENTRELAZANDO: Construir el Plan de Acción de Entrelazando", "4. ENTRELAZANDO: Construir el Plan de Acción de Entrelazando"));
            LD_Encuentro.Items.Insert(0, new ListItem("3. ENTRELAZANDO: Implementar el guion metodológico de Planeación Participativa", "3. ENTRELAZANDO: Implementar el guion metodológico de Planeación Participativa"));
            LD_Encuentro.Items.Insert(0, new ListItem("2. Identificar con el SRC las actividades que se deben desarrollar para reparar los daños a sus atributos como colectivo.", "2. Identificar con el SRC las actividades que se deben desarrollar para reparar los daños a sus atributos como colectivo."));
            LD_Encuentro.Items.Insert(0, new ListItem("1. Presentar al SRC la metodología de formulación del PIRC, identificar situación actual y deseada", "1. Presentar al SRC la metodología de formulación del PIRC, identificar situación actual y deseada"));

            LD_Encuentro.Items.Insert(0, new ListItem("Seleccione", "0"));


            ViewState["fase"] = "Ruta";

            gv5.Columns[2].Visible = false;
            gv5.Columns[3].Visible = false;
            gv5.Columns[4].Visible = false;
            gv5.Columns[7].Visible = false;

            //div_implementacion.Visible = true;
        }
        else if (fase == 51)//FASE DE DIAGNOSTICO DEL DAÑO
        {
            LD_Encuentro.Items.Insert(0, new ListItem("6. Validar el Documento de Diagnóstico del Daño Colectivo y de la matriz de análisis de involucrados con el SRC", "6. Validar el Documento de Diagnóstico del Daño Colectivo y de la matriz de análisis de involucrados con el SRC"));
            LD_Encuentro.Items.Insert(0, new ListItem("5. Presentar y validar con el SRC la Sistematización de herramientas contenida en la primera versión del documento de diagnóstico del daño colectivo, así como la primera versión de la matriz de análisis de involucrados", "5. Presentar y validar con el SRC la Sistematización de herramientas contenida en la primera versión del documento de diagnóstico del daño colectivo, así como la primera versión de la matriz de análisis de involucrados"));
            LD_Encuentro.Items.Insert(0, new ListItem("4. Encuentro 2 – Día 2 - Línea del tiempo y viñetas (liderado por una persona del Comité de impulso y un referente de cuidado) - aplica solo para comunidades no étnicas", "4. Encuentro 2 – Día 2 - Línea del tiempo y viñetas (liderado por una persona del Comité de impulso y un referente de cuidado) - aplica solo para comunidades no étnicas"));
            LD_Encuentro.Items.Insert(0, new ListItem("3. Encuentro 2 – Día 1 - Línea del tiempo y viñetas (liderado por profesionales)", "3. Encuentro 2 – Día 1 - Línea del tiempo y viñetas (liderado por profesionales)"));
            LD_Encuentro.Items.Insert(0, new ListItem("2. Encuentro 1 – Día 2 - Círculos concéntricos y Mapa de la comunidad (liderado por una persona del Comité de impulso y un referente de cuidado) - aplica solo para comunidades no étnicas", "2. Encuentro 1 – Día 2 - Círculos concéntricos y Mapa de la comunidad (liderado por una persona del Comité de impulso y un referente de cuidado) - aplica solo para comunidades no étnicas"));
            LD_Encuentro.Items.Insert(0, new ListItem("1. Encuentro 1 – Día 1 - Círculos concéntricos y Mapa de la comunidad (liderado por profesionales)", "1. Encuentro 1 – Día 1 - Círculos concéntricos y Mapa de la comunidad (liderado por profesionales)"));
            LD_Encuentro.Items.Insert(0, new ListItem("Seleccione", "0"));


            ViewState["fase"] = "Ruta";

            //div_implementacion.Visible = true;

            gv5.Columns[2].Visible = false;
            gv5.Columns[3].Visible = false;
            gv5.Columns[4].Visible = false;
            gv5.Columns[7].Visible = false;

        }
        else if (fase == 255)//FASE DE IMPLEMENTACIÓN
        {
            LD_Encuentro.Items.Insert(0, new ListItem("Implementación ", "Implementación "));

            LD_Encuentro.Items.Insert(0, new ListItem("Seleccione", "0"));

            //m_12.Visible = true;
            ViewState["fase"] = "Imple";

            //div_implementacion.Visible = true;

            gv5.Columns[2].Visible = true;
            gv5.Columns[3].Visible = true;
            gv5.Columns[4].Visible = true;
            gv5.Columns[7].Visible = true;
        }

    }

    public void L_D_TipoCostos(int fase)
    {

        DataSet ds = new DataSet();

        try
        {
            ds = FachadaPersistencia.getInstancia().LD_Tipo_actividad2(fase, Convert.ToInt32(this.opcion_tipo_detalle_costos.Value));

            LD_TipoCostos.Items.Clear();

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                LD_TipoCostos.DataValueField = "ID_TIPO_COSTO";
                LD_TipoCostos.DataTextField = "TIPO_COSTO";
                LD_TipoCostos.DataSource = ds;
                LD_TipoCostos.DataBind();
                LD_TipoCostos.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
            else
            {
                LD_TipoCostos.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }
        catch
        {
            texto("Error al realizar la consulta de tipoS de costos", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    public void L_D_tipo_medida()
    {

        DataSet ds = new DataSet();

        try
        {
            ds = FachadaPersistencia.getInstancia().consulta_tipo_medida();

            LD_tipo_medida.Items.Clear();

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                LD_tipo_medida.DataValueField = "ID_TIPO_MEDIDA";
                LD_tipo_medida.DataTextField = "TIPO_MEDIDA";
                LD_tipo_medida.DataSource = ds;
                LD_tipo_medida.DataBind();
                LD_tipo_medida.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
            else
            {
                LD_tipo_medida.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }
        catch
        {
            texto("Error al realizar la consulta de tipos de medida", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }


    public void L_D_productos()
    {

        DataSet ds = new DataSet();

        try
        {
            Actividad_dia actividad_dia = new Actividad_dia();
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            ds = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 22);

            //ds = FachadaPersistencia.getInstancia().consulta_tipo_medida();
            LD_productos.Items.Clear();

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                LD_productos.DataValueField = "ID_ACTIVIDAD_PRODUCTO";
                LD_productos.DataTextField = "PRODUCTO";
                LD_productos.DataSource = ds;
                LD_productos.DataBind();
                LD_productos.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
            else
            {
                LD_productos.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }
        catch
        {
            texto("Error al realizar la consulta de productos", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    public void L_D_Estado_dia()
    {
        try
        {
            Actividad_dia actividad_dia = new Actividad_dia();
            DataSet ds = new DataSet();
            int opcion = 0;

            //consulta lista de estados de los dias 10 para implementacion 11 para ruta
            //utilizo el id_actividad_dia para enviar el ultimo estado pra no devolvar estados.
            actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia_estado"]);

            if (Convert.ToInt32(Session["rol"]) == 37 || Convert.ToInt32(Session["rol"]) == 1 || Convert.ToString(Session["rol"]) == "145")
            {
                actividad_dia.P_ID_ACTIVIDAD = 1;
            }
            else if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_territorio.Value))
            {
                actividad_dia.P_ID_ACTIVIDAD = 2;
            }

            if (Convert.ToString(ViewState["fase"]) == "Ruta")
            {
                opcion = 11;
            }
            else
            {
                opcion = 10;
            }

            ds = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, opcion);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {

                LD_Estado_dia.Items.Clear();
                LD_Estado_dia.DataSource = ds;
                LD_Estado_dia.DataTextField = "ACTIVIDAD_DIA_ESTADO";
                LD_Estado_dia.DataValueField = "ID_ACTIVIDAD_DIA_ESTADO";
                LD_Estado_dia.DataBind();
                LD_Estado_dia.Items.Insert(0, new ListItem("Seleccione", "0"));

            }


        }
        catch
        {
            Mensajes("Error al realizar la consulta", 0);
        }
    }



    // lista desplegable de las territoriales
    public void L_D_Territorial()
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Territorial();
        LD_Territorial.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_Territorial.DataValueField = "id_territorio";
            LD_Territorial.DataTextField = "territorio";
            LD_Territorial.DataSource = ds;
            LD_Territorial.DataBind();
            LD_Territorial.Items.Insert(0, new ListItem("Seleccionar la territorial", "0"));
        }
        else
        {
            LD_Territorial.Items.Insert(0, new ListItem("Seleccionar la territorial", "0"));
        }
    }

    // lista deplegable de los municipios por territorial y departamento
    public void L_D_Departamentos(int id_territorial)
    {
        //Tierras tierras = new Tierras();
        DataSet ds = new DataSet();

        ds = FachadaPersistencia.getInstancia().L_D_Departamentos(id_territorial);
        LD_Departamento.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_Departamento.DataValueField = "id_departamento";
            LD_Departamento.DataTextField = "departamento";
            LD_Departamento.DataSource = ds;
            LD_Departamento.DataBind();
            LD_Departamento.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
        else
        {
            LD_Departamento.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
    }

    // lista deplegable de los municipios por territorial y departamento
    public void L_D_Departamentos_2()
    {
        //Tierras tierras = new Tierras();
        DataSet ds = new DataSet();

        ds = FachadaPersistencia.getInstancia().L_D_Departamentos(0);
        LD_Departamento.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_Departamento.DataValueField = "id_departamento";
            LD_Departamento.DataTextField = "departamento";
            LD_Departamento.DataSource = ds;
            LD_Departamento.DataBind();
            LD_Departamento.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
        else
        {
            LD_Departamento.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
    }

    // lista desplegable de los municipios segun territorial y departamento
    public void L_D_Municipio_Dep_territorial(int id_territorial, int id_departamento)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Municipio(id_departamento, 0, 0);

        LD_Municipio.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_Municipio.DataValueField = "id_municipio";
            LD_Municipio.DataTextField = "municipio";
            LD_Municipio.DataSource = ds;
            LD_Municipio.DataBind();
            LD_Municipio.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
        else
        {
            LD_Municipio.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
    }

    // lista deplegable de las entidades por oferta
    public void L_D_alcance(int rol)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_alcance(rol);

        L_D_Alcance.Items.Clear();

        if (ds != null && ds.Tables.Count > 0)
        {
            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                L_D_Alcance.DataValueField = "id_alcance";
                L_D_Alcance.DataTextField = "alcance";
                L_D_Alcance.DataSource = ds;
                L_D_Alcance.DataBind();
                L_D_Alcance.Items.Insert(0, new ListItem("Seleccionar alcance", "0"));
            }
            else
            {
                L_D_Alcance.Items.Insert(0, new ListItem("Seleccionar alcance", "0"));
            }
        }
        else
        {
            /*Controlar el tipo nulo !!!*/
        }
    }

    // Lista desplegable del tipo de sujeto colectivo
    public void L_D_tipo_sujeto()
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_tipo_sujeto();
        LD_Tipo_sujeto.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_Tipo_sujeto.DataValueField = "ID_TIPO_SUJETO_COLECTIVA";//revisar datos de la b.d ak y en el .aspx
            LD_Tipo_sujeto.DataTextField = "TIPO_SUJETO_COLECTIVA";
            LD_Tipo_sujeto.DataSource = ds;
            LD_Tipo_sujeto.DataBind();
            LD_Tipo_sujeto.Items.Insert(0, new ListItem("Seleccionar el tipo de sujeto", "0"));
        }
        else
        {
            LD_Tipo_sujeto.Items.Insert(0, new ListItem("Seleccionar el tipo de sujeto", "0"));
        }
    }


    // Lista desplegable del tipo de sujeto colectivo
    public void L_D_subCategoria()
    {
        try
        {
            DataSet ds = new DataSet();

            Actividad_detalle actividad_detalle = new Actividad_detalle();

            actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(LD_Tipo_sujeto.SelectedValue);
            ds = FachadaPersistencia.getInstancia().Consulta_actividad_detalle(actividad_detalle, Convert.ToInt32(this.opcion_Subcategoria.Value));
            LD_subCategoria.Items.Clear();

            if (!ds.Tables[0].Rows.Count.Equals(0) && Convert.ToInt32(LD_Tipo_sujeto.SelectedValue) != 0)
            {
                LD_subCategoria.DataValueField = "ID_TIPO_SUJETO_COLECTIVA_DET";//revisar datos de la b.d ak y en el .aspx
                LD_subCategoria.DataTextField = "TIPO_SUJETO_COLECTIVA_DET";
                LD_subCategoria.DataSource = ds;
                LD_subCategoria.DataBind();
                LD_subCategoria.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
            else
            {
                LD_subCategoria.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }
        catch (Exception e)
        {

        }

    }



    #region LISTAS DESPLEGABLES - ADMIN ACTIVIDADES

    // lista de los tipos de identificacion de los responsables
    public void L_D_Usuario(int id_dependecia, int opcion)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Usuario(id_dependecia, opcion);
        LD_usuario.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_usuario.DataValueField = "id_usuario";
            LD_usuario.DataTextField = "usuario";
            LD_usuario.DataSource = ds;
            LD_usuario.DataBind();
            LD_usuario.Items.Insert(0, new ListItem("Seleccione el usuario", "0"));
        }
        else
        {
            LD_usuario.Items.Insert(0, new ListItem("Seleccione el usuario", "0"));
        }
    }

    // Permite consultar el tipo de rol de los responsables
    public void LD_Rol_responsable()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = FachadaPersistencia.getInstancia().LD_Rol_responsable();

            ds = FachadaPersistencia.getInstancia().LD_Rol_responsable2(Convert.ToInt32(this.opcion_rol_responsable.Value));

            LD_rol_responsable.Items.Clear();

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                LD_rol_responsable.DataValueField = "id_actividad_rol";
                LD_rol_responsable.DataTextField = "actividad_rol";
                LD_rol_responsable.DataSource = ds;
                LD_rol_responsable.DataBind();
                LD_rol_responsable.Items.Insert(0, new ListItem("Seleccione el rol", "0"));
            }
            else
            {
                LD_rol_responsable.Items.Insert(0, new ListItem("Seleccione el rol", "0"));
            }
        }
        catch
        {
            Mensajes("Error al realizar la consulta de rol de responsables", 0);
        }
    }

    // lista deplegable de los departamentos para la cobertura
    public void LD_departamento()
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Departamento();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {

            LD_DepartamentoDia.DataValueField = "id_departamento";
            LD_DepartamentoDia.DataTextField = "departamento";
            LD_DepartamentoDia.DataSource = ds;
            LD_DepartamentoDia.DataBind();
            LD_DepartamentoDia.Items.Insert(0, new ListItem("Seleccionar el departamento", "0"));

        }
        else
        {
            LD_DepartamentoDia.Items.Insert(0, new ListItem("Seleccionar el departamento", "0"));
        }
    }


    // Lista desplegable del tipo de archivo
    public void LD_Tipo_archivo(int id_proceso, int opcion)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().LD_Tipo_archivo(id_proceso, opcion);
        LD_tipo_archivo.Items.Clear();


        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_tipo_archivo.DataValueField = "ID_TIPO_ACTIVIDAD_ARCHIVO";
            LD_tipo_archivo.DataTextField = "TIPO_ACTIVIDAD_ARCHIVO";
            LD_tipo_archivo.DataSource = ds;
            LD_tipo_archivo.DataBind();
            LD_tipo_archivo.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
        }
        else
        {
            LD_tipo_archivo.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
        }
    }

    // Lista desplegable del nombre de la actividad
    public void LD_Actividad_nombre(int id_dependencia, int opcion)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().LD_Actividad_nombre(id_dependencia, opcion);
        LD_actividad_nombre.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_actividad_nombre.DataValueField = "ID_NOMBRE_ACTIVIDAD";
            LD_actividad_nombre.DataTextField = "NOMBRE_ACTIVIDAD";
            LD_actividad_nombre.DataSource = ds;
            LD_actividad_nombre.DataBind();
            LD_actividad_nombre.Items.Insert(0, new ListItem("Seleccionar la actividad", "0"));
        }
        else
        {
            LD_actividad_nombre.Items.Insert(0, new ListItem("Seleccionar la actividad", "0"));
        }

        LD_actividad_nombre.SelectedValue = "204";
    }


    #endregion
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
                break;
            case 6:
                // permite abrir una ventana adicional como popup
                string popupScript = "<script language='JavaScript'> " + "{ " + " var leftPos = (screen.width-600)/2; " + " var topPos = (screen.height-400)/2; " +
                    " window.open('" + mensaje + "','Info','status=0 , titlebar=0, location=0, scrollbars=1, status=no, resizable=0, menubar=no, top='+ topPos +', left='+ leftPos ); " + "} </script> ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript, false);
                break;
            case 7:
                // permite abrir una ventana adicional como popup
                string popupScript2 = "<script language='JavaScript'> " + "{ " + " var leftPos = (screen.width-750)/2; " + " var topPos = (screen.height-400)/2; " +
                    " window.open('" + mensaje + "','Info','Width=900px, Height=500px, status=0 , titlebar=0, location=0, scrollbars=1, status=yes, resizable=1, menubar=no, top='+ topPos +', left='+ leftPos ); " + "} </script> ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
                break;
            case 8:
                // permite abrir una ventana adicional como popup
                string popupScript3 = "<script language='JavaScript'> " + "{ " + " var leftPos = (screen.width-600)/2; " + " var topPos = (screen.height-400)/2; " +
                    " window.open('" + mensaje + "','Info','Width=800px, Height=400px, status=0 , titlebar=0, location=0, scrollbars=1, status=yes, resizable=1, menubar=no, top='+ topPos +', left='+ leftPos ); " + "} </script> ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript3, false);
                break;
            case 9:
                // permite abrir una ventana adicional como popup
                string popupScript4 = "<script language='JavaScript'> " + "{ " + " var leftPos = (screen.width-960)/2; " + " var topPos = (screen.height-700)/2; " +
                    " window.open('" + mensaje + "','Info','Width=950px, Height=600px, status=0 , titlebar=0, location=0, scrollbars=1, status=yes, resizable=1, menubar=no, top='+ topPos +', left='+ leftPos ); " + "} </script> ";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript4, false);
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
                B_Confirmacion_accion.Visible = false;
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
                B_Confirmacion_accion.Visible = false;

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
                B_Confirmacion_accion.Visible = false;

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
                B_Confirmacion_accion.Visible = true;
                B_Confirmacion_accion.Text = "Continuar";

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
            case 4://Sin icono y sin color
                this.L_mensaje.Text = this.L_mensaje.Text + mensaje;
                break;
        }

    }

    #endregion


    #region METODOS

    // permite cargar los sujetos
    private void CargaGrid(int opcion)
    {
        try
        {
            Session["lista"] = "";
            DataSet ds = new DataSet();
            Sujeto_colectiva sujeto_colectiva = new Sujeto_colectiva();
            sujeto_colectiva.P_ID_SUJETO_COLECTIVA = 0;

            if (Convert.ToInt32(ViewState["ID_RYR_COMUNIDAD"]) != 0)
            {
                sujeto_colectiva.P_ID_SUJETO_COLECTIVA = Convert.ToInt32(ViewState["ID_RYR_COMUNIDAD"]);
            }


            if (Convert.ToInt32(ViewState["id_responsable"]) != 0)
            {
                sujeto_colectiva.P_ID_USUARIO = Convert.ToInt32(ViewState["id_responsable"]);
            }

            if (L_D_Alcance.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_ALCANCE = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_ALCANCE = Convert.ToInt32(L_D_Alcance.SelectedValue);
            }


            if (L_D_zona.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_ZONA = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_ZONA = Convert.ToInt32(L_D_zona.SelectedValue);
            }


            //sujeto_colectiva.P_ID_TERRITORIAL = Convert.ToInt32(L_D_territorial.SelectedValue);
            sujeto_colectiva.P_ID_TERRITORIAL = 0;

            //L_D_Departamento_territorial(0); // carga departamentos por territorial

            if (LD_Territorial.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_TERRITORIAL = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_TERRITORIAL = Convert.ToInt32(LD_Territorial.SelectedValue);
            }


            if (LD_Departamento.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_DEPARTAMENTO = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_DEPARTAMENTO = Convert.ToInt32(LD_Departamento.SelectedValue);
            }

            if (LD_Municipio.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_MUNICIPIO = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_MUNICIPIO = Convert.ToInt32(LD_Municipio.SelectedValue);
            }

            if (LD_subCategoria.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET = Convert.ToInt32(LD_subCategoria.SelectedValue);
            }

            if (LD_Tipo_sujeto.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA = Convert.ToInt32(LD_Tipo_sujeto.SelectedValue);//N
            }

            sujeto_colectiva.P_NIT = TB_Nit.Text.Trim();
            sujeto_colectiva.P_NOMBRE_SUJETO_COLECTIVA = TB_Nombre_sujeto.Text.ToUpper().Trim();

            sujeto_colectiva.P_FASE = LD_estado_sujeto.SelectedValue;

            //ACTUALIZACION 07/02/2020---ROJO ---------------------------------------------------------------------

            if (LD_estado_sujeto_colectivo.SelectedValue == "")
            {

                sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA = 0;

            }
            else
            {
                //CAMBIO ALEJANDRO SESION PARA LD_estado_sujeto_colectivo
                if (Convert.ToString(Session["rol"]) != "1" && Convert.ToString(Session["rol"]) != "37" && Convert.ToString(Session["rol"]) != "145")
                {


                    sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA = 1;
                }
                else
                {
                    sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA = Convert.ToInt32(LD_estado_sujeto_colectivo.SelectedValue);
                }

            }

            sujeto_colectiva.P_TIPO_ACCESO = Convert.ToString(L_D_TipoAcceso.SelectedValue);
            sujeto_colectiva.P_FUD = TB_FUD.Text;
            sujeto_colectiva.P_ESTADO_RUV = Convert.ToString(L_D_estadoruv.SelectedValue);
            //--------------------FIN --------------------------------------------------------------------------

            ds = FachadaPersistencia.getInstancia().Consultar_sujeto(sujeto_colectiva, opcion);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                gv.Visible = true;
                Session["lista"] = ds;
                gv.DataSource = ds;
                gv.DataBind();
                Panel241.Visible = false;
                Panel232.Visible = false;
                D_Sujetos.Visible = true;
                L_Sujetos.Text = Convert.ToString(ds.Tables[0].Rows.Count) + " Comunidades encontradas. ";
            }
            else
            {
                Session["lista"] = null;
                gv.Visible = false;
                Panel241.Visible = false;
                Panel232.Visible = false;
                D_Sujetos.Visible = false;
                if (Convert.ToString(Session["rol"]) != "1" && Convert.ToString(Session["rol"]) != "37" && Convert.ToString(Session["rol"]) != "145")
                {
                    Mensajes("No se encontraron registros de sujetos.", 0);
                }
                else
                {
                    Mensajes("No se encontraron registros de sujetos,  haga click en aceptar para agregarlo", 0);
                    guardar.Visible = true;
                    TB_Nit.Text = "";
                    //TB_Nit.Enabled = false;
                }

            }

            UP_DatosSujetos.Update();
        }
        catch
        {
            Mensajes("Error al realizar la consulta", 0);
        }
    }


    private void AdministraFases(int opcion)
    {
        try
        {
            DataSet ds = new DataSet();
            Actividad actividad = new Actividad();
            int valor = 0;
            actividad.P_ID_SRC = Convert.ToInt32(ViewState["ID_RYR_COMUNIDAD"]);
            actividad.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            actividad.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

            if (opcion == 1) //permite colocar la fase en aprobado
            {
                actividad.P_ID_ACTIVIDAD_ESTADO = 4;
                valor = FachadaPersistencia.getInstancia().Administrar_actividad(actividad, 8);
            }
            else if (opcion == 2) //permite colocar la fase en activo
            {
                actividad.P_ID_ACTIVIDAD_ESTADO = 1;
                valor = FachadaPersistencia.getInstancia().Administrar_actividad(actividad, 8);
            }
            else if (opcion == 3) //permite cambiar estado de la fase             
            {
                actividad.P_ID_ACTIVIDAD_ESTADO = Convert.ToInt32(LD_Estado_actividad.SelectedValue);
                valor = FachadaPersistencia.getInstancia().Administrar_actividad(actividad, 8);
                //CREACION DE ACTIVIDAD DETALLE PARA GUARDAR LA TRAZABILIDAD DEL CAMBIO DEL ESTADO
                //Cambio realizado por alejandro moreno
                int valor_detalle = 0;
                Actividad_detalle actividad_detalle = new Actividad_detalle();
                actividad_detalle.P_ID_ACTIVIDAD_DETALLE = Convert.ToInt32("0");
                actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
                actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE = Convert.ToString(TextBox14.Text);
                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 47)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 896;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 48)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 897;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 49)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 898;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 50)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 899;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 51)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 900;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 255)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 901;
                }
                //actividad_detalle.P_ID_TIPO_ACTIVIDAD = 838;
                actividad_detalle.P_ESTADO_ACTIVIDAD = Convert.ToInt32(4); //estado creado
                actividad_detalle.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
                valor_detalle = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, 1);
                //fin cambio alejandro moreno


            }





            if (valor != 0)
            {
                texto("El estado de la fase fue actualizado correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                ConsultaFases();
            }
            else
            {
                texto("No se pudo actualizar el estado de la fase!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            }


        }
        catch
        {

        }
    }


    private void ConsultaFases()
    {
        try
        {
            DataSet ds = new DataSet();
            Actividad actividad = new Actividad();
            Persona persona = new Persona();

            actividad.P_ID_SRC = Convert.ToInt32(ViewState["ID_RYR_COMUNIDAD"]);
            idComunidad.Value = actividad.P_ID_SRC.ToString();

            if (Convert.ToInt32(ViewState["id_responsable"]) != 0)
            {
                actividad.P_ID_RESPONSABLE = Convert.ToInt32(ViewState["id_responsable"]);
            }

            CargaGrid(11);
            D_Sujetos.Visible = false;

            ds = FachadaPersistencia.getInstancia().Consulta_actividad(actividad, persona, 18);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                gv_actividad.Visible = true;
                ViewState["lista"] = ds;
                gv_actividad.DataSource = ds;
                gv_actividad.DataBind();
                Panel241.Visible = false;
                Panel232.Visible = true;
            }
            else
            {
                ViewState["lista"] = null;
                gv_actividad.Visible = false;
                Panel241.Visible = false;
                Panel232.Visible = false;
                L_mensaje.Text = "";
                texto("No registra fases .", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                ViewState["ID_RYR_COMUNIDAD"] = 0;

            }
            UP_ResultadoBusqueda.Update();
            UP_DatosEvento.Update();
        }
        catch
        {

        }
    }

    private void ConsultaDirectorioSujeto()
    {
        try
        {
            DataSet ds = new DataSet();
            Actividad actividad = new Actividad();
            Persona persona = new Persona();

            actividad.P_ID_SRC = Convert.ToInt32(ViewState["ID_RYR_COMUNIDAD"]);
            //actividad.P_ID_DIRECTORIO = Convert.ToInt32(ViewState["ID_DIRECTORIO"]);

            //if (Convert.ToInt32(ViewState["id_responsable"]) != 0)
            //{
            //    actividad.P_ID_RESPONSABLE = Convert.ToInt32(ViewState["id_responsable"]);
            //}

            //CargaGrid(1);
            //D_Sujetos.Visible = false;

            ds = FachadaPersistencia.getInstancia().Consulta_actividad(actividad, persona, 16);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                //Panel19.Visible = false;
                gv_directorio_sujeto.Visible = true;
                ViewState["lista"] = ds;
                gv_directorio_sujeto.DataSource = ds;
                gv_directorio_sujeto.DataBind();
                //Panel241.Visible = false;
                Panel14.Visible = true;
                Agregar_contacto.Visible = true;
                Panel19.Visible = false;

            }
            else
            {
                ViewState["lista"] = null;
                gv_actividad.Visible = false;
                L_D_Tipo_contacto();
                //gv_directorio_sujeto.DataSource = null;
                //Panel241.Visible = false;
                Panel14.Visible = false;
                L_mensaje.Text = "";
                texto("No registran datos en el Directorio.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                Panel19.Visible = true;
                Agregar_contacto.Visible = true;
                Actualizar_Contacto.Visible = false;
                TB_Entidad.Text = "";
                TB_Nombre.Text = "";
                TB_Cargo.Text = "";
                TB_Telefono.Text = "";
                TB_Mail.Text = "";
                LD_Tipo_contacto.SelectedValue = "0";
                Guardar_contacto.Visible = true;

            }
            UpdatePanelDirectorio.Update();
            //UP_DatosEvento.Update();
        }
        catch
        {

        }
    }

    // permite administrar las entidades
    public bool Crear(int opcion)
    {

        Sujeto_colectiva sujeto_colectiva = new Sujeto_colectiva();
        int valor = 0;

        try
        {
            if ((ViewState["ID_RYR_COMUNIDAD"] != null) || (ViewState["ID_RYR_COMUNIDAD"].ToString() != "0")) // revisar id en la tabla
            {
                sujeto_colectiva.P_ID_SUJETO_COLECTIVA = Convert.ToInt32(ViewState["ID_RYR_COMUNIDAD"].ToString());
            }

            sujeto_colectiva.P_ID_ALCANCE = Convert.ToInt32(L_D_Alcance.SelectedValue);
            sujeto_colectiva.P_ID_ZONA = Convert.ToInt32(L_D_zona.SelectedValue);

            sujeto_colectiva.P_ID_TERRITORIAL = Convert.ToInt32(LD_Territorial.SelectedValue);


            if (LD_Departamento.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_DEPARTAMENTO = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_DEPARTAMENTO = Convert.ToInt32(LD_Departamento.SelectedValue);
            }

            if (LD_Municipio.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_MUNICIPIO = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_MUNICIPIO = Convert.ToInt32(LD_Municipio.SelectedValue);
            }

            if (LD_subCategoria.SelectedValue == "")
            {
                sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET = 0;
            }
            else
            {
                sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA_DET = Convert.ToInt32(LD_subCategoria.SelectedValue);
            }

            //ACTUALIZACION 07/02/2020---ROJO ---------------------------------------------------------------------

            //if (LD_estado_sujeto_colectivo.SelectedValue == "")
            //{
            //    sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA = 0;
            //}
            //else
            //{
            //    sujeto_colectiva.P_ID_ESTADO_SUJETO_COLECTIVA = Convert.ToInt32(LD_estado_sujeto_colectivo.SelectedValue);
            //}

            //sujeto_colectiva.P_TIPO_ACCESO = Convert.ToString(L_D_TipoAcceso.SelectedValue);
            //sujeto_colectiva.P_FUD = TB_FUD.Text;
            //sujeto_colectiva.P_ESTADO_RUV = Convert.ToString(L_D_estadoruv.SelectedValue);
            //--------------------FIN --------------------------------------------------------------------------


            sujeto_colectiva.P_ID_TIPO_SUJETO_COLECTIVA = Convert.ToInt32(LD_Tipo_sujeto.SelectedValue);
            sujeto_colectiva.P_NIT = TB_Nit.Text;
            sujeto_colectiva.P_NOMBRE_SUJETO_COLECTIVA = TB_Nombre_sujeto.Text;
            sujeto_colectiva.P_FASE = LD_estado_sujeto.SelectedValue;
            sujeto_colectiva.P_OBSERVACION_ESTADO_SUJETO = TB_obs_estado_sujeto.Text;

            //Insertar los sujetos
            if (opcion == 1)
            {
                sujeto_colectiva.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);

                valor = FachadaPersistencia.getInstancia().Administrar_sujeto(sujeto_colectiva, opcion);

                if (valor != 0)
                {

                    Mensajes("El sujeto se creo correctamente", 0);
                    valor = FachadaPersistencia.getInstancia().Administrar_sujeto(sujeto_colectiva, 6);
                    if (valor != 0)
                    {

                        Mensajes("Las fases del sujeto se crearon correctamente", 0);
                    }
                    else
                    {
                        Mensajes("El registro que desea ingresar ya se encuentra en la base de datos", 0);
                    }
                }
                else
                {
                    Mensajes("El registro que desea ingresar ya se encuentra en la base de datos", 0);
                }
            }

            //Actualiza el sujeto
            if (opcion == 2)
            {
                sujeto_colectiva.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

                valor = FachadaPersistencia.getInstancia().Administrar_sujeto(sujeto_colectiva, opcion);

                if (valor != 0)
                {
                    Mensajes("El registro se actualizó correctamente", 0);
                }
                else
                {
                    Mensajes("Se genero un error al actualizar", 0);
                }
            }

            //Actualiza LA FASE DEL SUJETO
            if (opcion == 4)
            {
                sujeto_colectiva.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

                sujeto_colectiva.P_FASE = L_V1.Text;
                ViewState["fase_colectiva"] = L_V1.Text;
                valor = FachadaPersistencia.getInstancia().Administrar_sujeto(sujeto_colectiva, 7);

                if (valor != 0)
                {
                    texto("La fase del sujeto fue actualizada correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    CargaGrid(1);
                }
                else
                {
                    texto("La fase del sujeto no fue actualizada, por favor inténtelo más tarde!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }

        }
        catch
        {
            Mensajes("No se encontraron coincidencias con este criterio de busqueda", 0);
        }

        return true;
    }

    // permite actualizar los datos de la entidad
    private void ActualizaGrid(GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Sujeto_colectiva sujeto_colectiva = new Sujeto_colectiva();
            DataSet ds = new DataSet();



            sujeto_colectiva.P_ID_SUJETO_COLECTIVA = Convert.ToInt32(((Label)gvRow.FindControl("ID_RYR_COMUNIDAD")).Text);
            ViewState["ID_RYR_COMUNIDAD"] = sujeto_colectiva.P_ID_SUJETO_COLECTIVA;

            ds = FachadaPersistencia.getInstancia().Consultar_sujeto(sujeto_colectiva, 1);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                //guardar.Visible = false;
                actualizar.Visible = true;


                L_D_Alcance.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_ALCANCE"].ToString());

                if (Convert.ToString(ds.Tables[0].Rows[0]["id_territorial"]) != "")
                {
                    // departamento por territorial
                    LD_Territorial.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["id_territorial"]);
                }
                else
                {
                    LD_Departamento.SelectedValue = "0";
                }


                L_D_Departamentos(Convert.ToInt32(LD_Territorial.SelectedValue));

                if (Convert.ToString(ds.Tables[0].Rows[0]["ID_DEPARTAMENTO"]) != "")
                {
                    // departamento por territorial
                    LD_Departamento.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_DEPARTAMENTO"]);
                }
                else
                {
                    LD_Departamento.SelectedValue = "0";
                }

                // municipio por territorial
                L_D_Municipio_Dep_territorial(0, Convert.ToInt32(LD_Departamento.SelectedValue));

                if (Convert.ToString(ds.Tables[0].Rows[0]["ID_MUNICIPIO"]) != "")
                {
                    LD_Municipio.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_MUNICIPIO"]);
                }
                else
                {
                    LD_Municipio.SelectedValue = "0";
                }
                LD_Tipo_sujeto.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_SUJETO_COLECTIVA"]);
                L_D_subCategoria();
                if (Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_SUJETO_COLECTIVA_DET"]) != "")
                {
                    LD_subCategoria.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_SUJETO_COLECTIVA_DET"]);
                }
                else
                {
                    LD_subCategoria.SelectedValue = "0";
                }


                L_D_estadoruv.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["estado_ruv"]);
                TB_FUD.Text = Convert.ToString(ds.Tables[0].Rows[0]["fud"]);
                L_D_TipoAcceso.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["tipo_acceso"]);
                LD_estado_sujeto_colectivo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_ESTADO_RYR_COMUNIDAD"]);
                //TB_obs_estado_sujeto.Text = Convert.ToString(ds.Tables[0].Rows[0]["OBSERVACION_ESTADO_SUJETO_COLECTIVA"]);


                // permite poner visible este campo cuando el sujeto es tipo etnico
                //if (LD_Tipo_sujeto.SelectedValue == "3")
                //{
                //    LB_detalle.Visible = true;
                //    LD_Tipo_sujeto_detalle.Visible = true;
                //}
                //else
                //{
                //    LB_detalle.Visible = false;
                //    LD_Tipo_sujeto_detalle.Visible = false;
                //}

                //LD_tipo_sujeto_detalle(Convert.ToInt32(ds.Tables[0].Rows[0]["ID_TIPO_SUJETO_COLECTIVA"]));

                //if (Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_SUJETO_COLECTIVA_DET"]) != "")
                //{
                //    LD_Tipo_sujeto_detalle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_SUJETO_COLECTIVA_DET"]);
                //}
                //else
                //{
                //    LD_Tipo_sujeto_detalle.SelectedValue = "0";
                //}

                TB_Nit.Text = ds.Tables[0].Rows[0]["NIT"].ToString();
                TB_Nombre_sujeto.Text = ds.Tables[0].Rows[0]["NOMBRE_RYR_COMUNIDAD"].ToString();
                LD_estado_sujeto.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_ESTADO_RYR_COMUNIDAD"]);
                L_D_zona.SelectedValue = ds.Tables[0].Rows[0]["id_zona"].ToString();

                if (Convert.ToString(ds.Tables[0].Rows[0]["FASE1"]) != "")
                {
                    // departamento por territorial
                    LD_estado_sujeto.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["FASE1"]);
                }
                else
                {
                    LD_estado_sujeto.SelectedValue = "0";
                }

                UpdatePanel.Update();
            }
            else
            {
                Mensajes("No se puede seleccionar el registro", 0);
            }
        }
        catch (System.Exception ex)
        {
        }
    }

    // Permite eliminar una entidad del sistema
    private void EliminaGrid(GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Sujeto_colectiva sujeto_colectiva = new Sujeto_colectiva();
            sujeto_colectiva.P_ID_SUJETO_COLECTIVA = Convert.ToInt32(((Label)gvRow.FindControl("ID_RYR_COMUNIDAD")).Text);

            int valor = FachadaPersistencia.getInstancia().Administrar_sujeto(sujeto_colectiva, 3);

            if (valor == 0)
            {
                Mensajes("El registro seleccionado no puede ser eliminado por que tiene informacion asociada", 0);
                LimpiaFormulario(this);
            }
            else if (valor != 0)
            {
                Mensajes("El registro ha sido eliminado correctamente", 0);
                LimpiaFormulario(this);
            }

            LimpiaFormulario(this);
        }
        catch (System.Exception ex)
        {

        }
    }




    #region Administar actividades

    // permite limpiar el formulario
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
            //TB_Nit.Enabled = true;
            guardar.Visible = false;
        }
        D_Sujetos.Visible = false;

    }



    // permite ver los datos de la actividad
    private void Ver(GridViewCommandEventArgs e)
    {
        try
        {
            Actividad actividad = new Actividad();
            Persona persona = new Persona();
            Actividad_dia actividad_dia = new Actividad_dia();
            GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            //ViewState["id_actividad"] = Convert.ToInt32(gv_actividad.DataKeys[gvRow.RowIndex].Values[0].ToString());
            L_titulo.Text = Convert.ToString(((Label)gvRow.FindControl("fase_actividad")).Text);


            string fase = ((Label)gvRow.FindControl("fase_actividad")).Text;
            //Solo en formulacion se muestran las pestañas de arboles y demás


            actividad.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            Panel241.Visible = true;
            ViewState["estado"] = "3"; //opcion solo consultar
            //CargaGrid_archivo();

            Consulta_actividad_responsable(2);
            LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
            consulta_dias_actividad(1);
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
        }
        catch (System.Exception ex)
        {
        }
    }

    // permite actualizar los datos de la actividad
    private void Actualizar_actividad(int id_actividad)
    {
        try
        {
            Actividad actividad = new Actividad();
            Persona persona = new Persona();
            Actividad_dia actividad_dia = new Actividad_dia();
            ViewState["id_actividad"] = id_actividad;
            actividad.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            Panel241.Visible = true;
            m_2.Visible = true;
            m_4.Visible = true;
            ViewState["estado"] = "2";

            Consulta_actividad_responsable(1);
            LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
            consulta_dias_actividad(1);
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);


            Panel244.Visible = true;
            Panel252.Visible = true;
            Panel242.Visible = true;
            gv12.Columns[14].Visible = true;
            P_GurdarCostos.Visible = true;

            Panel252.Visible = true;
            gv16.Columns[3].Visible = true;
            gv16.Columns[4].Visible = true;

        }
        catch (System.Exception ex)
        {
        }
    }



    #region ACTIVIDAD RESPONSABLE (Pestaña 1 o 2)

    // permite administrar los responsables de las actividades
    private void Crear_responsable(int opcion)
    {
        try
        {
            Actividad_responsable actividad_responsable = new Actividad_responsable();
            DataSet ds = new DataSet();
            int valor = 0;

            if ((ViewState["id_actividad_responsable"] == null) || (ViewState["id_actividad_responsable"].ToString() == ""))
            {
                ViewState["id_actividad_responsable"] = "0";
            }
            else
            {
                actividad_responsable.P_ID_ACTIVIDAD_RESPONSABLE = Convert.ToInt32(ViewState["id_actividad_responsable"].ToString());
            }

            actividad_responsable.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            if (Convert.ToInt32(LD_usuario.SelectedValue) != 0)
            {
                actividad_responsable.P_ID_USUARIO = Convert.ToInt32(LD_usuario.SelectedValue);
            }
            else
            {
                actividad_responsable.P_ID_USUARIO = 0;
            }

            if (Convert.ToInt32(LD_rol_responsable.SelectedValue) != 0)
            {
                actividad_responsable.P_ID_ACTIVIDAD_ROL = Convert.ToInt32(LD_rol_responsable.SelectedValue);
            }
            else
            {
                actividad_responsable.P_ID_ACTIVIDAD_ROL = 0;
            }

            // Inserta la actividad
            if (opcion == 1)
            {
                actividad_responsable.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);

                // permite administrar las actividades
                valor = FachadaPersistencia.getInstancia().Administrar_actividad_responsable(actividad_responsable, opcion);

                if (valor != 0)
                {
                    texto("El registro se inserto correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    Consulta_actividad_responsable(Convert.ToInt32(ViewState["estado"]));

                    LD_usuario.SelectedValue = "0";
                    LD_rol_responsable.SelectedValue = "0";
                }
                else
                {
                    texto("El registro que desea ingresar ya se encuentra en la base de datos", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }
            }

            // Actualiza la actividad
            if (opcion == 2)
            {
                actividad_responsable.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_responsable(actividad_responsable, opcion);

                if (valor != 0)
                {
                    Consulta_actividad_responsable(Convert.ToInt32(ViewState["estado"]));
                    texto("El registro se actualizó correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);

                    LD_usuario.SelectedValue = "0";
                    LD_rol_responsable.SelectedValue = "0";
                }
                else
                {
                    texto("Se genero un error al actualizar", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
        }
        catch
        {
            texto("Error al guardar los datos", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }


    // permite consultar roles de las responsables
    public void Consulta_actividad_responsable(int opcion)
    {
        DataSet ds = new DataSet();
        Actividad_responsable actividad_responsable = new Actividad_responsable();

        try
        {
            actividad_responsable.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            // permite consultar los responsables
            ds = FachadaPersistencia.getInstancia().Consulta_actividad_responsable(actividad_responsable, 3);

            if (opcion == 1) // por actualizar
            {
                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    ViewState["actividad_responsable"] = ds;
                    gv12.DataSource = ds;
                    gv12.DataBind();
                    gv12.Visible = true;
                    L_Responsables.Visible = false;
                }
                else
                {
                    ViewState["actividad_responsable"] = null;
                    gv12.Visible = false;
                    L_Responsables.Visible = true;
                    L_Responsables.Text = "No se han establecido responsables para esta fase.";

                }
            }
            else if (opcion == 2) // por consultar
            {
                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    gv12.Visible = true;
                    ViewState["actividad_responsable"] = ds;
                    gv12.DataSource = ds;
                    gv12.DataBind();
                    L_Responsables.Visible = false;
                }
                else
                {
                    ViewState["actividad_responsable"] = null;
                    gv12.Visible = false;
                    L_Responsables.Visible = true;
                    L_Responsables.Text = "No se han establecido responsables para esta fase.";
                }
            }
        }
        catch
        {
            Mensajes("Error al realizar la consulta de los responsables de la actividad", 0);
        }
    }

    // Permite eliminar un registro de la actividad detalle
    private void Eliminar_actividad_responsable(GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();

        try
        {
            GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            Actividad_responsable actividad_responsable = new Actividad_responsable();

            actividad_responsable.P_ID_ACTIVIDAD_RESPONSABLE = Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_responsable")).Text);

            int valor = FachadaPersistencia.getInstancia().Administrar_actividad_responsable(actividad_responsable, 3);

            if (valor == 0)
            {
                texto("El registro no se eliminó debido a una inconsistencia en el sistema!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            }
            else if (valor != 0)
            {
                texto("El registro ha sido eliminado correctamente", 1);
                Mensajes_2("", this.L_mensaje.Text, 1);
                Consulta_actividad_responsable(2);
            }

        }
        catch (System.Exception ex)
        {
        }
    }

    #endregion


    #region ACTIVIDAD DIA-ACCIONES (Pestaña 4 - OCULTA)


    private void consulta_dias_actividad(int opcion)
    {
        try
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            Actividad_dia actividad_dia = new Actividad_dia();
            int valida = 0;

            guardar_dias.Visible = true;
            B_ActualizarDia.Visible = false;
            B_CancelarDia.Visible = false;

            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            ds = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 20);
            ds2 = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 18);
            ds3 = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 19);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {


                gv5.Visible = true;
                gv5.DataSource = ds;
                gv5.DataBind();
                ViewState["ds_dias_actividad"] = ds;
                ViewState["gv5"] = ds.Tables[0];
                lb_no_seguimiento.Visible = false;

            }
            else
            {
                gv5.Visible = true;
                gv5.DataSource = null;
                gv5.DataBind();
                ViewState["ds_dias_actividad"] = null;
                ViewState["gv5"] = null;
                lb_no_seguimiento.Visible = true;
            }

            if (!ds2.Tables[0].Rows.Count.Equals(0))
            {



                gv_dias_implementados.Visible = true;
                gv_dias_implementados.DataSource = ds2;
                gv_dias_implementados.DataBind();
                ViewState["ds_dias_actividad_implementados"] = ds2;
                ViewState["gv_dias_implementados"] = ds2.Tables[0];
                lb_no_implementadas.Visible = false;



            }
            else
            {
                gv_dias_implementados.Visible = true;
                gv_dias_implementados.DataSource = null;
                gv_dias_implementados.DataBind();
                ViewState["ds_dias_actividad_implementados"] = null;
                ViewState["gv_dias_implementados"] = null;
                lb_no_implementadas.Visible = true;
            }

            if (!ds3.Tables[0].Rows.Count.Equals(0))
            {

                gv_dias_cancelados.Visible = true;
                gv_dias_cancelados.DataSource = ds3;
                gv_dias_cancelados.DataBind();
                ViewState["ds_dias_actividad_cancelados"] = ds3;
                ViewState["gv_dias_cancelados"] = ds3.Tables[0];
                lb_no_suspendidas.Visible = false;

            }
            else
            {
                gv_dias_cancelados.Visible = true;
                gv_dias_cancelados.DataSource = null;
                gv_dias_cancelados.DataBind();
                ViewState["ds_dias_actividad_cancelados"] = null;
                ViewState["gv_dias_cancelados"] = null;
                lb_no_suspendidas.Visible = true;
            }


            if (opcion == 10)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(fila["alerta"]) > 0)
                    {
                        valida++;
                    }

                }
                if (valida == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myScript", "var x = document.getElementsByClassName('alertabell');var i;for (i = 0; i < x.length; i++){x[i].style.visibility = 'hidden';}", true);

                }
            }

            UP_Dias.Update();
        }
        catch
        {
            texto("Error al cargar los datos de los dias", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    private void L_D_Cambiar_accion()
    {
        try
        {
            DataSet ds = new DataSet();

            Actividad_dia actividad_dia = new Actividad_dia();
            int valida = 0;


            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            ds = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 9);


            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                for (int i = 0; i <= gv16.Rows.Count - 1; i++)
                {
                    DropDownList LD_x = new DropDownList();
                    LD_x = (DropDownList)gv16.Rows[i].FindControl("LD_Cambiar_accion");
                    LD_x.DataSource = ds;
                    LD_x.DataTextField = "OBSERVACION_ACTIVIDAD_DIA";
                    LD_x.DataValueField = "ID_ACTIVIDAD_DIA";
                    LD_x.DataBind();
                    LD_x.Items.Insert(0, new ListItem("Seleccione", "0"));
                }


            }

            UP_Archivos.Update();
        }
        catch
        {
            texto("Error al cargar los datos de los dias", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }


    // permite crear los dias de la actividad
    private void Crear_dias_actividad()
    {
        try
        {
            Actividad actividad = new Actividad();
            Actividad_dia actividad_dia = new Actividad_dia();
            DataSet ds = new DataSet();
            int valor = 0;
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            actividad_dia.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
            actividad_dia.P_DIA_ACTIVIDAD = TB_Fecha.Text.Trim();
            actividad_dia.P_LUGAR_ACTIVIDAD = TB_Direccion_lugar.Text;
            actividad_dia.P_HORA_INICIO = Convert.ToString(Convert.ToDateTime(TB_HoraInicio.Text).Hour) + ":" + Convert.ToString(Convert.ToDateTime(TB_HoraInicio.Text).Minute);
            actividad_dia.P_HORA_FIN = Convert.ToString(Convert.ToDateTime(TB_HoraFin.Text).Hour) + ":" + Convert.ToString(Convert.ToDateTime(TB_HoraFin.Text).Minute);
            actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = Convert.ToString(LD_Encuentro.SelectedValue);
            actividad_dia.P_PROYECCION = Convert.ToInt32(TB_Proyeccion.Text);
            actividad_dia.P_GESTION = Convert.ToInt32(TB_Gestion.Text);
            actividad_dia.P_ID_ACTIVIDAD_DETALLE = Convert.ToInt32(ViewState["id_actividad_detalle"]);

            actividad_dia.P_ID_MUNICIPIO = Convert.ToInt32(LD_MunicipioDia.SelectedValue);

            if (!TB_HoraInicio.Text.Equals(TB_HoraFin.Text))
            {
                if (Convert.ToDateTime(TB_HoraInicio.Text).TimeOfDay < Convert.ToDateTime(TB_HoraFin.Text).TimeOfDay)
                {
                    valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 1);

                    if (valor != 0)
                    {
                        texto("Se ha agregado correctamente el día", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                        TB_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        TB_HoraInicio.Text = "08:00 AM";
                        TB_HoraFin.Text = "05:00 PM";
                        TB_Direccion_lugar.Text = "";
                        TB_Proyeccion.Text = "";
                        TB_Gestion.Text = "";
                        guardar_dias.Visible = true;
                        B_ActualizarDia.Visible = false;
                        B_CancelarDia.Visible = false;
                        LD_DepartamentoDia.SelectedValue = "0";
                        LD_Departamento_Dia();
                        consulta_dias_actividad(1);
                        LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                    }
                    else
                    {
                        texto("No se ha agregado el día, tenga en cuenta que no puede agregar dos veces el mismo día.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                    }
                }
                else
                {
                    texto("La hora de inicio no puede ser mayor que la hora fin de la actividad.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            else
            {
                texto("La hora de inicio y fin de la actividad no pueden ser iguales, recuerda que estos datos deben ser acorde a la actividad.", 2); Mensajes_2("", this.L_mensaje.Text, 3);
            }
        }
        catch
        {
            texto("Error al guardar los datos verifique que no exista un dia igual", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    // permite crear los dias de la actividad
    private void Crear_dias_actividad_colectiva()
    {
        try
        {
            Actividad actividad = new Actividad();
            Actividad_producto actividad_producto = new Actividad_producto();
            Actividad_dia actividad_dia = new Actividad_dia();

            DataSet ds = new DataSet();
            int valor = 0;
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            actividad_dia.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
            //actividad_dia.P_DIA_ACTIVIDAD = TB_Fecha.Text.Trim();
            //actividad_dia.P_LUGAR_ACTIVIDAD = TB_Direccion_lugar.Text;
            //actividad_dia.P_HORA_INICIO = Convert.ToString(Convert.ToDateTime(TB_HoraInicio.Text).Hour) + ":" + Convert.ToString(Convert.ToDateTime(TB_HoraInicio.Text).Minute);
            //actividad_dia.P_HORA_FIN = Convert.ToString(Convert.ToDateTime(TB_HoraFin.Text).Hour) + ":" + Convert.ToString(Convert.ToDateTime(TB_HoraFin.Text).Minute);
            actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = TextBox13.Text;
            //actividad_dia.P_PROYECCION = Convert.ToInt32(TB_Proyeccion.Text);
            actividad_dia.P_GESTION = 1;
            //actividad_dia.P_ID_ACTIVIDAD_DETALLE = Convert.ToInt32(ViewState["id_actividad_detalle"]);

            //actividad_dia.P_ID_MUNICIPIO = Convert.ToInt32(LD_MunicipioDia.SelectedValue);

            actividad_producto.P_ID_ACTIVIDAD_NOMBRE = Convert.ToInt32(ViewState["id_nombre_actividad"]);
            actividad_producto.P_ID_TIPO_MEDIDA = Convert.ToInt32(LD_tipo_medida.SelectedValue);
            //actividad_producto.P_ID_TIPO_MEDIDA = 3;
            actividad_producto.P_ID_SUJETO_COLECTIVA = Convert.ToInt32(ViewState["id_sujeto_colectiva"]);
            actividad_producto.P_PRODUCTO = TextBox12.Text;
            actividad_producto.P_DESCRIPCION = TextBox12.Text;
            actividad_producto.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);

            if (Convert.ToInt32(ViewState["id_nombre_actividad"]) != 255)
            {

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 11);

                if (valor != 0)
                {
                    texto("Se ha agregado correctamente el día", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                }
                else
                {
                    texto("No se ha agregado el día", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
                TextBox13.Text = "";

            }
            else
            {
                if (RB_Producto.SelectedValue == "si")
                {
                    valor = FachadaPersistencia.getInstancia().Administrar_actividad_producto(actividad_producto, 7);
                    if (valor != 0)
                    {
                        actividad_dia.P_ID_ACTIVIDAD_DETALLE = valor;
                        valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 11);

                        if (valor != 0)
                        {
                            texto("Se ha agregado correctamente el día", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                        }
                        else
                        {
                            texto("No se ha agregado el día", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                        }

                        TextBox12.Text = "";
                        TextBox13.Text = "";

                        //texto("Se ha agregado correctamente el día", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                        //TB_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        //TB_HoraInicio.Text = "08:00 AM";
                        //TB_HoraFin.Text = "05:00 PM";
                        //TB_Direccion_lugar.Text = "";
                        //TB_Proyeccion.Text = "";
                        //TB_Gestion.Text = "";
                        //guardar_dias.Visible = true;
                        //B_ActualizarDia.Visible = false;
                        //B_CancelarDia.Visible = false;
                        //LD_DepartamentoDia.SelectedValue = "0";
                        //LD_Departamento_Dia();
                        //consulta_dias_actividad(1);
                        //LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                    }
                    else
                    {
                        texto("No se ha agregado el producto", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                    }
                }
                else if (RB_Producto.SelectedValue == "no")
                {

                    actividad_dia.P_ID_ACTIVIDAD_DETALLE = Convert.ToInt32(LD_productos.SelectedValue);
                    valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 11);

                    if (valor != 0)
                    {
                        texto("Se ha agregado correctamente el día", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    }
                    else
                    {
                        texto("No se ha agregado el día", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                    }

                    TextBox12.Text = "";
                    TextBox13.Text = "";

                    //texto("Se ha agregado correctamente el día", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    //TB_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    //TB_HoraInicio.Text = "08:00 AM";
                    //TB_HoraFin.Text = "05:00 PM";
                    //TB_Direccion_lugar.Text = "";
                    //TB_Proyeccion.Text = "";
                    //TB_Gestion.Text = "";
                    //guardar_dias.Visible = true;
                    //B_ActualizarDia.Visible = false;
                    //B_CancelarDia.Visible = false;
                    //LD_DepartamentoDia.SelectedValue = "0";
                    //LD_Departamento_Dia();
                    //consulta_dias_actividad(1);
                    //LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                }
                else
                {
                    texto("No se ha agregado el producto", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }


            }

            LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
            Actualizar_actividad(Convert.ToInt32(ViewState["id_actividad"]));

            //valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 1);        


        }
        catch
        {
            texto("Error al guardar los datos verifique que no exista un dia igual", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    private void Actualiza_dias_actividad(int opcion)
    {
        try
        {
            Actividad actividad = new Actividad();
            Actividad_dia actividad_dia = new Actividad_dia();
            DataSet ds = new DataSet();
            int valor = 0;
            actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            actividad_dia.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            if (opcion == 1)
            {

                actividad_dia.P_DIA_ACTIVIDAD = TB_Fecha.Text.Trim();
                actividad_dia.P_LUGAR_ACTIVIDAD = TB_Direccion_lugar.Text;
                actividad_dia.P_HORA_INICIO = Convert.ToString(Convert.ToDateTime(TB_HoraInicio.Text).Hour) + ":" + Convert.ToString(Convert.ToDateTime(TB_HoraInicio.Text).Minute);
                actividad_dia.P_HORA_FIN = Convert.ToString(Convert.ToDateTime(TB_HoraFin.Text).Hour) + ":" + Convert.ToString(Convert.ToDateTime(TB_HoraFin.Text).Minute);
                actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = Convert.ToString(LD_Encuentro.SelectedItem);
                actividad_dia.P_PROYECCION = Convert.ToInt32(TB_Proyeccion.Text);
                actividad_dia.P_GESTION = Convert.ToInt32(TB_Gestion.Text);
                actividad_dia.P_ID_MUNICIPIO = Convert.ToInt32(LD_MunicipioDia.SelectedValue);

                if (!TB_HoraInicio.Text.Equals(TB_HoraFin.Text))
                {
                    valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 1);

                    if (valor != 0)
                    {
                        texto("Se ha modificado correctamente el día", 1); Mensajes_2("", this.L_mensaje.Text, 1);

                        TB_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        TB_HoraInicio.Text = "08:00 AM";
                        TB_HoraFin.Text = "05:00 PM";
                        TB_Direccion_lugar.Text = "";
                        LD_Encuentro.SelectedValue = "0";
                        TB_Proyeccion.Text = "0";
                        TB_Gestion.Text = "0";
                        guardar_dias.Visible = true;
                        B_ActualizarDia.Visible = false;
                        B_CancelarDia.Visible = false;
                        LD_DepartamentoDia.SelectedValue = "0";
                        LD_Departamento_Dia();
                        consulta_dias_actividad(1);
                    }
                    else
                    {
                        texto("No se ha modificado el día, tenga en cuenta que no puede agregar dos veces el mismo día.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                    }
                }
                else
                {
                    texto("has dejado la misma hora de inicio y fin de la actividad recuerda que estos datos deben ser acorde a la actividad", 2); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            else if (opcion == 2) //aprobado dia
            {
                actividad_dia.P_ID_ACTIVIDAD_DIA_ESTADO = opcion;

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 4);//solo actualiza el estado

                if (valor != 0)
                {
                    texto("El estado del día fue actualizado correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    consulta_dias_actividad(1);
                }
                else
                {
                    texto("No se pudo actualizar el estado del día!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            else if (opcion == 3) //NO aprobado dia
            {
                actividad_dia.P_ID_ACTIVIDAD_DIA_ESTADO = opcion;

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 4);//solo actualiza el estado 

                if (valor != 0)
                {
                    texto("El estado del día fue actualizado correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    consulta_dias_actividad(1);
                }
                else
                {
                    texto("No se pudo actualizar el estado del día!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            else if (opcion == 4) //enviar para aprobar
            {
                actividad_dia.P_ID_ACTIVIDAD_DIA_ESTADO = opcion;

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 4);//solo actualiza el estado 

                if (valor != 0)
                {
                    texto("El estado del día fue actualizado correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    consulta_dias_actividad(1);
                }
                else
                {
                    texto("No se pudo actualizar el estado del día!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }

            if (opcion == 5) // gurda los costos""
            {
                //actividad_dia.P_PROYECCION = Convert.ToInt32(TB_Proyeccion.Text);
                //actividad_dia.P_GESTION = Convert.ToInt32(TB_Gestion.Text);


                //valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 7); //guarda solo los costos de la actividad

                //if (valor != 0)
                //{
                //    texto("Se han guardo correctamente los costos.", 1); Mensajes_2("", this.L_mensaje.Text, 1);

                //}
                //else
                //{
                //    texto("No se han guardado los costos, por favor vuelva a intentar.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                //}
            }

            if (opcion == 6) // gurda los estado de los dias""
            {
                actividad_dia.P_ID_ACTIVIDAD_DIA_ESTADO = Convert.ToInt32(LD_Estado_dia.SelectedValue);


                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 8); //guarda solo los estados de la actividad dia

                if (valor != 0)
                {
                    texto("Se ha guardo correctamente el estado.", 1); Mensajes_2("", this.L_mensaje.Text, 1);

                    /*
                   * DATOS[]
                   * 0-sujeto_colectiva 
                   * 1-id_actividad_dia 
                   * 2-fase 
                   * 3-dia_actividad_estado 
                   * 4-LD_Estado_dia
                   */
                    string[] datos = {
                                         Convert.ToString(ViewState["sujeto_colectiva"]),
                                         Convert.ToString(ViewState["id_actividad_dia"]),
                                         Convert.ToString(ViewState["fase"]),
                                         Convert.ToString(ViewState["dia_actividad_estado"]),
                                         Convert.ToString(LD_Estado_dia.SelectedItem)
                                     };
                    Crear_correo(
                        ((DataSet)ViewState["actividad_responsable"]),          //correos-send
                        "Maariv - Colectiva - Cambio Estado",                   //asunto
                        datos,                                                   //datos
                        2,                                                      //opcion colectica
                        0
                    );

                }
                else
                {
                    texto("No se ha guardado el estado, por favor vuelva a intentar.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }



        }
        catch
        {
            texto("Error, no se han guardado los datos, por favor vuelva a intentar. ", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }


    private Boolean BalidaCambioEstadoDoc(int opcion)
    {
        Boolean result = false;
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        DataSet ds = new DataSet();

        adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);


        if (opcion == 1) //validacion que territorio no tenga documentos "no aprobados"
        {
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 6);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                texto("Ups!!! No se puede solicitar un cambio de estado de esta actividad, ya que hay documentos que están en estado <strong>“no aprobado” </strong>, por favor cambia estos documentos:", 3);

                //recorro los estados de los documentos cargados
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    texto(Convert.ToString(ds.Tables[0].Rows[j]["TIPO_ACTIVIDAD_ARCHIVO"]) + " --> " + Convert.ToString(ds.Tables[0].Rows[j]["ACTIVIDAD_ARCHIVO_ESTADO"]) + ", ", 2);
                }

                Mensajes_2("Documentos sin aprobación.", this.L_mensaje.Text, 2);
            }
            else
            {
                result = true;
            }

        }
        else if (opcion == 2)  //validacion para que nivel nacional no tenga documentos en estado " PENDIENTE VALIDACIÓN , DESCARGADO - VERIFICADOR , DENEGADO - VERIFICADOR"
        {
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 4);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                texto("Ups!!! No se puede cambiar el estado del día, ya que los documentos actualmente cargados estan pendientes por aprobación!.", 3);

                //recorro los estados de los documentos cargados
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    texto(Convert.ToString(ds.Tables[0].Rows[j]["TIPO_ACTIVIDAD_ARCHIVO"]) + " --> " + Convert.ToString(ds.Tables[0].Rows[j]["ACTIVIDAD_ARCHIVO_ESTADO"]) + ", ", 2);
                }

                texto("Puede tramitar las solicitudes de cambio de estado <strong>estableciendo el mismo estado a la actividad</strong>, he informándole al profesional de territorio por que no se ha aprobado.. ", 1);

                Mensajes_2("Documentos sin aprobación.", this.L_mensaje.Text, 2);
            }
            else
            {
                result = true;
            }

        }

        else if (opcion == 3)  //validacion para que nivel nacional no tenga documentos pendientes por validacion " PENDIENTE VALIDACIÓN , DESCARGADO - VERIFICADOR"
        {
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 7);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                texto("Ups!!! No se puede cambiar el estado del día, ya que hay documentos cargados que estan pendientes por validación!.", 3);

                //recorro los estados de los documentos cargados
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    texto(Convert.ToString(ds.Tables[0].Rows[j]["TIPO_ACTIVIDAD_ARCHIVO"]) + " --> " + Convert.ToString(ds.Tables[0].Rows[j]["ACTIVIDAD_ARCHIVO_ESTADO"]) + ", ", 2);
                }

                Mensajes_2("Documentos sin aprobación.", this.L_mensaje.Text, 2);
            }
            else
            {
                result = true;
            }

        }






        return result;
    }





    // permite administrar los detalles de las actividades
    private void Crear_actividad_detalle(int opcion)
    {
        try
        {
            Actividad_detalle actividad_detalle = new Actividad_detalle();
            actividad_dia_costo actividad_dia_costo = new actividad_dia_costo();
            Actividad_dia_bitacora actividad_dia_bitacora = new Actividad_dia_bitacora();
            DataSet ds = new DataSet();
            int valor = 0;

            if ((ViewState["id_actividad_detalle"] == null) || (ViewState["id_actividad_detalle"].ToString() == ""))
            {
                ViewState["id_actividad_detalle"] = "0";
            }
            else
            {
                actividad_detalle.P_ID_ACTIVIDAD_DETALLE = Convert.ToInt32(ViewState["id_actividad_detalle"].ToString());
            }

            //actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            //en este modulo envio el id_actividad_dia y en la bd establesco el is actividad
            actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad_dia"]);
            actividad_dia_costo.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA = actividad_dia_costo.P_ID_ACTIVIDAD_DIA;


            actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE = TB_actividad_detalle.Text.Trim();
            actividad_dia_bitacora.P_DESCRIPCION_BITACORA = TB_actividad_detalle.Text.Trim();

            actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA_BITACORA = Convert.ToInt32(ViewState["ID_ACTIVIDAD_DIA_BITACORA"]);

            //if (Convert.ToInt32(LD_tipo_actividad.SelectedValue) != 0)
            //{
            //    actividad_detalle.P_ID_TIPO_ACTIVIDAD = Convert.ToInt32(LD_tipo_actividad.SelectedValue);
            //}
            //else
            //{
            actividad_detalle.P_ID_TIPO_ACTIVIDAD = 0;
            //}

            //if (Convert.ToInt32(LD_estado_detalle.SelectedValue) != 0)
            //{
            //    actividad_detalle.P_ESTADO_ACTIVIDAD = Convert.ToInt32(LD_estado_detalle.SelectedValue);
            //}
            //else
            //{
            actividad_detalle.P_ESTADO_ACTIVIDAD = 2;
            //}

            // Inserta la actividad
            if (opcion == 1)
            {
                //actividad_detalle.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
                actividad_dia_bitacora.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);

                // permite administrar las actividades

                //valor = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, 4);
                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia_bitacora(actividad_dia_bitacora, 1);

                if (valor != 0)
                {

                    /*
                    * DATOS[]
                    * 0-sujeto_colectiva 
                    * 1-actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE 
                    * 2-usuario 
                    * 3-actividad_detalle.P_ID_ACTIVIDAD 
                    * 4-fase
                    */
                    string[] datos = {
                                         Convert.ToString(ViewState["sujeto_colectiva"]),
                                         actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE,
                                         Convert.ToString(Session["usuario"]),
                                         Convert.ToString(actividad_detalle.P_ID_ACTIVIDAD),
                                         Convert.ToString(ViewState["fase"])
                                     };
                    Crear_correo(
                        ((DataSet)ViewState["actividad_responsable"]),          //correos-send
                        "Maariv - Colectiva - bitácora",                        //asunto
                        datos,                                                   //datos
                        3,                                                      //opcion colectica bitacora
                        0
                    );


                    texto("El registro se inserto correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    TB_actividad_detalle.Text = "";
                    LD_tipo_actividad.SelectedValue = "0";
                    LD_estado_detalle.SelectedValue = "0";
                    TB_actividad_detalle.Enabled = true;

                    Consulta_actividad_detalle(1);
                }
                else
                {
                    TB_actividad_detalle.Text = "";
                    LD_tipo_actividad.SelectedValue = "0";
                    LD_estado_detalle.SelectedValue = "0";
                    TB_actividad_detalle.Enabled = true;
                    texto("El registro que desea ingresar ya se encuentra en la base de datos", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }
            }

            // Actualiza la actividad
            if (opcion == 2)
            {
                //actividad_detalle.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                actividad_dia_bitacora.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

                //valor = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, opcion);
                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia_bitacora(actividad_dia_bitacora, 4);


                //if (valor != 0)
                //{
                //    TB_actividad_detalle.Text = "";
                //    LD_tipo_actividad.SelectedValue = "0";
                //    LD_estado_detalle.SelectedValue = "0";
                //    ViewState["id_actividad_detalle"] = "0";

                //    LD_tipo_actividad.Enabled = true;
                //    TB_actividad_detalle.Enabled = true;
                //    B_actualizar_detalle.Visible = false;
                //    B_guardar_detalle.Visible = true;

                //    Consulta_actividad_detalle(Convert.ToInt32(Session["estado"]));
                //    texto("El registro se actualizó correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                //}
                //else
                //{
                //    TB_actividad_detalle.Text = "";
                //    LD_tipo_actividad.SelectedValue = "0";
                //    LD_estado_detalle.SelectedValue = "0";
                //    ViewState["id_actividad_detalle"] = "0";

                //    LD_tipo_actividad.Enabled = true;
                //    TB_actividad_detalle.Enabled = true;
                //    B_actualizar_detalle.Visible = false;
                //    B_guardar_detalle.Visible = true;

                //    texto("Se genero un error al actualizar", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                //}

                if (valor != 0)
                {

                    /*
                    * DATOS[]
                    * 0-sujeto_colectiva 
                    * 1-actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE 
                    * 2-usuario 
                    * 3-actividad_detalle.P_ID_ACTIVIDAD 
                    * 4-fase
                    */
                    string[] datos = {
                                         Convert.ToString(ViewState["sujeto_colectiva"]),
                                         actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE,
                                         Convert.ToString(Session["usuario"]),
                                         Convert.ToString(actividad_detalle.P_ID_ACTIVIDAD),
                                         Convert.ToString(ViewState["fase"])
                                     };
                    Crear_correo(
                        ((DataSet)ViewState["actividad_responsable"]),          //correos-send
                        "Maariv - Colectiva - bitácora",                        //asunto
                        datos,                                                   //datos
                        3,                                                      //opcion colectica bitacora
                        0
                    );


                    texto("El registro se inserto correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    TB_actividad_detalle.Text = "";
                    LD_tipo_actividad.SelectedValue = "0";
                    LD_estado_detalle.SelectedValue = "0";
                    TB_actividad_detalle.Enabled = true;

                    Consulta_actividad_detalle(1);
                    B_guardar_detalle.Visible = true;
                }
                else
                {
                    TB_actividad_detalle.Text = "";
                    LD_tipo_actividad.SelectedValue = "0";
                    LD_estado_detalle.SelectedValue = "0";
                    TB_actividad_detalle.Enabled = true;
                    texto("El registro que desea ingresar ya se encuentra en la base de datos", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }
            }



            //opcion que gurda los los costos de las actividades y productos jos
            if (opcion == 4)
            {


                //actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE = (TB_Proyeccion.Text + "|" + TB_Gestion.Text).Trim();
                //actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE = TB_Proyeccion.Text;
                //actividad_detalle.P_TIPO_ACTIVIDAD = TB_Gestion.Text;

                actividad_dia_costo.P_COSTO_PROYECTADO = Convert.ToDouble(TB_Proyeccion.Text);
                actividad_dia_costo.P_COSTO_EJECUTADO = Convert.ToDouble(TB_Gestion.Text);

                if (Convert.ToInt32(LD_TipoCostos.SelectedValue) != 0)
                {
                    //actividad_detalle.P_ID_TIPO_ACTIVIDAD = Convert.ToInt32(LD_TipoCostos.SelectedValue);
                    actividad_dia_costo.P_ID_TIPO_COSTO = Convert.ToInt32(LD_TipoCostos.SelectedValue);
                }
                else
                {
                    //actividad_detalle.P_ID_TIPO_ACTIVIDAD = 0;
                    actividad_dia_costo.P_ID_TIPO_COSTO = 0;
                }


                //actividad_detalle.P_ESTADO_ACTIVIDAD = 2;


                //actividad_detalle.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
                actividad_dia_costo.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);

                // permite administrar las actividades
                //valor = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, 5);//ingresa tipo de cosos de colectiva jos
                //valor = FachadaPersistencia.getInstancia().Administrar_actividad_costos(actividad_detalle, 1);//ingresa tipo de coTos de colectiva BRAYAN
                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia_costo(actividad_dia_costo, 1);//ingresa tipo de coTos de colectiva BRAYAN


                if (valor != 0)
                {
                    texto("El registro se inserto correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);

                }
                else
                {
                    texto("El registro que desea ingresar ya se encuentra en la base de datos", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }
            }

            //opcion que gurda las solicitudes de cambio de estado de colectiva
            if (opcion == 5)
            {
                actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE = TB_ObCambio.Text.Trim();

                if (Convert.ToInt32(LD_Estado_dia.SelectedValue) != 0)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = Convert.ToInt32(LD_Estado_dia.SelectedValue);
                }
                else
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 0;
                }


                actividad_detalle.P_ESTADO_ACTIVIDAD = 1;


                actividad_detalle.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);

                // permite administrar las actividades
                valor = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, 6);//ingresa las solicitudes de cambio de estado jos

                if (valor != 0)
                {
                    texto("Se ha solicitado el cambio de estado correctamente, por favor validar en el área de bitácoras.", 1); Mensajes_2("", this.L_mensaje.Text, 1);

                }
                else
                {
                    texto("Error, no se ha podido realizar la solicitud de cambio de estado, por favor inténtelo nuevamente.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }
            }

            if (opcion == 6)
            {


                actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE = TB_ObCambio.Text.Trim();

                if (Convert.ToInt32(LD_Estado_dia.SelectedValue) != 0)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = Convert.ToInt32(LD_Estado_dia.SelectedValue);
                }
                else
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 0;
                }


                actividad_detalle.P_ESTADO_ACTIVIDAD = 2;


                actividad_detalle.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);

                // permite administrar las actividades
                valor = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, 6);//ingresa las solicitudes de cambio de estado jos

                if (valor != 0)
                {
                    texto("Se ha registrado correctamente el cambio de estado , por favor validar en el área de bitácoras.", 1); Mensajes_2("", this.L_mensaje.Text, 1);

                }
                else
                {
                    texto("Error, no se ha podido realizar el registro de cambio de estado, por favor inténtelo nuevamente.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }


                int valida = 0;
                foreach (GridViewRow fila in GV_Solicitudes.Rows)
                {
                    if (((CheckBox)fila.FindControl("C_Solicitud")).Checked)
                    {
                        actividad_detalle.P_ID_ACTIVIDAD_DETALLE = Convert.ToInt32(((Label)fila.FindControl("L_IdActividadDetalle")).Text);
                        actividad_detalle.P_ESTADO_ACTIVIDAD = 2;
                        actividad_detalle.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

                        valor = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, 7);

                        if (valor == 0)
                        {
                            valida = 1;
                        }

                    }

                }

                if (valida != 1)
                {
                    texto("Se han tramitados las solicitudes satisfactoriamente. ", 1);
                }
                else
                {
                    texto("Error, una de las solicitudes no se ha guardado satisfactoria mente, por favor intenta guardar el estado nuevamente.", 2);
                }
            }
            // Actualiza la actividad Colectiva
            if (opcion == 7)
            {
                Actividad_dia actividad_dia = new Actividad_dia();



                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) != 255)
                {
                    actividad_dia.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                    actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = TextBox13.Text;
                    actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);


                }
                else
                {
                    actividad_dia.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                    actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = TextBox13.Text;
                    actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);

                    actividad_dia.P_PROYECCION = Convert.ToInt32(ViewState["ID_ACTIVIDAD_PRODUCTO"]);         // ID_ACTIVIDAD_PRODUCTO
                    actividad_dia.P_LUGAR_ACTIVIDAD = TextBox12.Text;     //DESCRIPCION PRODUCTO 
                }

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia_Colectiva(actividad_dia, 10);

                if (valor != 0)
                {
                    //TB_actividad_detalle.Text = "";
                    //LD_tipo_actividad.SelectedValue = "0";
                    //LD_estado_detalle.SelectedValue = "0";
                    //ViewState["id_actividad_detalle"] = "0";

                    //LD_tipo_actividad.Enabled = true;
                    //TB_actividad_detalle.Enabled = true;
                    //B_actualizar_detalle.Visible = false;
                    //B_guardar_detalle.Visible = true;

                    //Consulta_actividad_detalle(Convert.ToInt32(Session["estado"]));
                    texto("El registro se actualizó correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                    Actualizar_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                }
                else
                {
                    //TB_actividad_detalle.Text = "";
                    //LD_tipo_actividad.SelectedValue = "0";
                    //LD_estado_detalle.SelectedValue = "0";
                    //ViewState["id_actividad_detalle"] = "0";

                    //LD_tipo_actividad.Enabled = true;
                    //TB_actividad_detalle.Enabled = true;
                    //B_actualizar_detalle.Visible = false;
                    //B_guardar_detalle.Visible = true;

                    texto("Se genero un error al actualizar", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }

            if (opcion == 8)
            {
                //actividad_detalle.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
                actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA_BITACORA = Convert.ToInt32(ViewState["ID_ACTIVIDAD_DIA_BITACORA"]);

                // permite administrar las actividades

                //valor = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, 4);
                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia_bitacora(actividad_dia_bitacora, 3);
                if (valor != 0)
                {



                    texto("la Bitacora se elimino correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                    Actualizar_actividad(Convert.ToInt32(ViewState["id_actividad"]));


                    Consulta_actividad_detalle(1);
                }
                else
                {

                    texto("No pudo ser Eliminada", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }
            }

            if (opcion == 9)
            {
                Actividad_dia actividad_dia = new Actividad_dia();



                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) != 255)
                {
                    actividad_dia.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                    actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);


                }
                else
                {
                    actividad_dia.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                    actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
                    actividad_dia.P_PROYECCION = Convert.ToInt32(ViewState["ID_ACTIVIDAD_PRODUCTO"]);         // ID_ACTIVIDAD_PRODUCTO

                }

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_dia_Colectiva(actividad_dia, 12);

                if (valor != 0)
                {
                    //TB_actividad_detalle.Text = "";
                    //LD_tipo_actividad.SelectedValue = "0";
                    //LD_estado_detalle.SelectedValue = "0";
                    //ViewState["id_actividad_detalle"] = "0";

                    //LD_tipo_actividad.Enabled = true;
                    //TB_actividad_detalle.Enabled = true;
                    //B_actualizar_detalle.Visible = false;
                    //B_guardar_detalle.Visible = true;

                    //Consulta_actividad_detalle(Convert.ToInt32(Session["estado"]));
                    texto("El registro se elimino correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                    Actualizar_actividad(Convert.ToInt32(ViewState["id_actividad"]));

                }
                else
                {
                    //TB_actividad_detalle.Text = "";
                    //LD_tipo_actividad.SelectedValue = "0";
                    //LD_estado_detalle.SelectedValue = "0";
                    //ViewState["id_actividad_detalle"] = "0";

                    //LD_tipo_actividad.Enabled = true;
                    //TB_actividad_detalle.Enabled = true;
                    //B_actualizar_detalle.Visible = false;
                    //B_guardar_detalle.Visible = true;

                    texto("El registro se elimino correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                    Actualizar_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                }
            }

        }
        catch
        {
            texto("Error al guardar los detalles", 3); Mensajes_2("", this.L_mensaje.Text, 3);

        }
    }

    // permite consultar los detalle de las actividades
    public void Consulta_actividad_detalle(int opcion)
    {
        DataSet ds = new DataSet();
        Actividad_detalle actividad_detalle = new Actividad_detalle();
        actividad_dia_costo actividad_dia_costo = new actividad_dia_costo();
        Actividad_dia_bitacora actividad_dia_bitacora = new Actividad_dia_bitacora();

        try
        {
            B_CancelaDetalle.Visible = false;
            B_actualizar_detalle.Visible = false;
            //actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            //UTILIZO LA VARIABLE DE ID_ACTIVIDAD COMO ID_ACTIVIDAD_DIA PARA HACER LAS BITACORAS
            actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad_dia"]);
            actividad_dia_costo.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);


            if (opcion == 1 || opcion == 2)
            {
                // permite consultar las actividades
                //ds = FachadaPersistencia.getInstancia().Consulta_actividad_detalle(actividad_detalle, 7);
                ds = FachadaPersistencia.getInstancia().Consultar_actividad_dia_bitacora(actividad_dia_bitacora, 2);

                if (opcion == 1) // por actualizar
                {
                    //LD_estado2.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_ESTADO"]);

                    if (!ds.Tables[0].Rows.Count.Equals(0))
                    {
                        ViewState["actividad_detalle"] = ds;
                        gv11.DataSource = ds;
                        gv11.DataBind();
                        gv11.Visible = true;
                        Panel242.Visible = true;
                        L_Bitacora.Visible = false;
                    }
                    else
                    {
                        ViewState["actividad_detalle"] = null;
                        gv11.Visible = false;
                        L_Bitacora.Visible = true;
                        L_Bitacora.Text = "No hay información de bitácoras. ";


                    }
                }
                else if (opcion == 2) // por consultar
                {
                    if (!ds.Tables[0].Rows.Count.Equals(0))
                    {
                        gv11.Visible = true;
                        ViewState["actividad_detalle"] = ds;
                        gv11.DataSource = ds;
                        gv11.DataBind();
                        L_Bitacora.Visible = false;
                    }
                    else
                    {
                        ViewState["actividad_detalle"] = null;
                        gv11.Visible = false;
                        texto("No se encontraron registros de detalles de la actividad.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                        L_Bitacora.Visible = true;
                        L_Bitacora.Text = "No hay información de bitácoras. ";
                    }
                }

                else
                {
                    ViewState["actividad_detalle"] = null;
                    gv11.Visible = false;
                }
            }
            if (opcion == 3) //consulta los detalles relacionados a lso costos de reparacion colectiva JOS
            {
                int proy = 0;
                int ges = 0;

                //ds = FachadaPersistencia.getInstancia().Consulta_actividad_detalle(actividad_detalle, 14);
                ds = FachadaPersistencia.getInstancia().Consultar_actividad_dia_costo(actividad_dia_costo, 2);


                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        proy = proy + Convert.ToInt32(ds.Tables[0].Rows[j]["COSTO_PROYECTADO"]);
                        ges = ges + Convert.ToInt32(ds.Tables[0].Rows[j]["COSTO_EJECUTADO"]);
                    }

                    TB_Proy.Text = Convert.ToString(proy);
                    TB_Ges.Text = Convert.ToString(ges);
                    ViewState["actividad_detalle_costo"] = ds;
                    gv112.DataSource = ds;
                    gv112.DataBind();
                    gv112.Visible = true;
                    Panel246.Visible = true;
                    L_Costos.Visible = false;
                    //validar(Convert.ToInt32(Session["estado"]));
                }
                else
                {
                    ViewState["actividad_detalle_costo"] = null;
                    gv11.Visible = false;
                    Panel246.Visible = false;
                    L_Costos.Visible = true;
                    L_Costos.Text = "No hay información de costos.";

                }
            }
            if (opcion == 4)
            {

                ds = FachadaPersistencia.getInstancia().Consulta_actividad_detalle(actividad_detalle, 9);//consulta los detalles pendientes por validacion,cambio de estado

                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    ViewState["actividad_detalle_solicitudes"] = ds;
                    GV_Solicitudes.DataSource = ds;
                    GV_Solicitudes.DataBind();
                    GV_Solicitudes.Visible = true;
                    P_Solicitudes.Visible = true;
                    P_Solicitudes.CssClass = "row";
                    L_CambioEstado.Visible = false;
                    //validar(Convert.ToInt32(Session["estado"]));
                }
                else
                {

                    ViewState["actividad_detalle_solicitudes"] = null;
                    GV_Solicitudes.Visible = false;
                    P_Solicitudes.CssClass = "row panel panel-danger panel-heading";
                    L_CambioEstado.Visible = true;
                    //P_Solicitudes.Visible = false;
                }


            }


        }
        catch
        {
            texto("Error al realizar la consulta de los detalles de la actividad", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }



    public Boolean Consulta_archivos_obligatorio()
    {
        Boolean valida = false;
        try
        {
            Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
            Actividad_dia actividad_dia = new Actividad_dia();
            Persona persona = new Persona();
            DataSet ds = new DataSet();


            adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            adjuntar_archivos.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            //validación de documentos obligatorios que faltan
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 3);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                texto("Ups!!! No se puede cambiar ni solicitar un cambio de estado de la actividad, ya que faltan documentos obligatorios:", 3);

                //recorro los documentos faltantes del dia
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    texto(Convert.ToString(ds.Tables[0].Rows[j]["TIPO_ACTIVIDAD_ARCHIVO"]), 2);
                }

                Mensajes_2("Documentos requeridos.", this.L_mensaje.Text, 2);
            }
            else
            {
                valida = true;
            }

        }
        catch
        {
            valida = true;
        }

        return valida;

    }


    #endregion

    #region ARCHIVOS (Pestaña 3 o 5)

    //Permite cargar los archivos adjuntos
    private void CargaGrid_archivo(int Tconsulta)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();

        try
        {


            if (Convert.ToInt32(ViewState["id_actividad"]) != 0 && Tconsulta == 0)
            {
                adjuntar_archivos.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
                adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            }
            else if (Tconsulta == 2) //consulta documentos fase
            {
                adjuntar_archivos.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
            }



            if (Convert.ToInt32(ViewState["id_sujeto_colectiva"]) != 0)
            {
                adjuntar_archivos.P_ID_SRC = Convert.ToInt32(ViewState["id_sujeto_colectiva"]);
            }


            if ((Session["ID_ACTIVIDAD_ARCHIVO"] == null) || (Session["ID_ACTIVIDAD_ARCHIVO"].ToString() == ""))
            {
                Session["ID_ACTIVIDAD_ARCHIVO"] = "0";
            }
            else
            {
                adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(Session["ID_ACTIVIDAD_ARCHIVO"].ToString());
            }

            if (LD_tipo_archivo.SelectedValue == "")
            {
                adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = 0;
            }
            else
            {
                adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_archivo.SelectedValue);
            }

            if (L_D_dia_actividad_documentos.SelectedValue == "0")
            {
                adjuntar_archivos.P_FECHA_EXPEDICION = "";
            }
            else
            {
                //adjuntar_archivos.P_FECHA_EXPEDICION = Convert.ToString(L_D_dia_actividad_documentos.SelectedItem);
                adjuntar_archivos.P_FECHA_EXPEDICION = "";

            }


            //adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            // permite consultar los archivos que tiene la actividad
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                Session["lista_archivos"] = ds;
                ViewState["lista_archivos"] = ds;
                ViewState["gv16"] = ds.Tables[0];
                gv16.Visible = true;
                gv16.DataSource = ds;
                gv16.DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                UP_Archivos.Update();
            }
            else
            {
                Session["lista_archivos"] = null;
                ViewState["lista_archivos"] = null;
                ViewState["gv16"] = null;
                gv16.Visible = false;
                gv16.DataSource = null;
                gv16.DataBind();
                if (Tconsulta == 0 && Convert.ToInt32(ViewState["id_actividad_estado"]) == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                    UP_Archivos.Update();
                }
                else
                {
                    texto("No se encontraron registros de archivos adjuntos!.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }


            }




        }
        catch (Exception e)
        {
            Mensajes("Error al realizar la consulta de los archivos.", 0);
        }
    }

    // permite actualizar los datos adjuntos
    private void ActualizaGrid_archivo(GridViewCommandEventArgs e, int id_actividad_archivo_estado)
    {
        try
        {
            int valor = 0;
            //GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
            DataSet ds = new DataSet();

            adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_archivo")).Text);
            //Session["ID_ACTIVIDAD_ARCHIVO"] = adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO;
            adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO = id_actividad_archivo_estado;
            adjuntar_archivos.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

            //if (id_actividad_archivo_estado == 0) //actualiza la informacion del documento
            //{ 
            //    ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 1);

            //    if (!ds.Tables[0].Rows.Count.Equals(0))
            //    {
            //        guardar_archivo.Visible = false;

            //        LD_tipo_archivo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_ACTIVIDAD_ARCHIVO"]);
            //        //fecha_expedicion.Text = Convert.ToString(ds.Tables[0].Rows[0]["FECHA_EXPEDICION"]);
            //    }
            //    else
            //    {
            //        texto("No se puede seleccionar el registro!.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
            //    }
            //}
            //actualiza el estado del documento            
            //else {}

            valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 5);

            if (valor != 0)
            {
                texto("El estado del documento fue actualizado correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                CargaGrid_archivo(0);
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


    // Permite eliminar un registro de los datos adjuntos
    private void EliminaGrid_archivo(GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
            DataSet ds = new DataSet();

            adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_archivo")).Text);

            // permite consultar la url del archivo
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);

            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["Archivos"] + Convert.ToString(ds.Tables[0].Rows[0]["URL_ARCHIVO"])))
            {
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["Archivos"] + Convert.ToString(ds.Tables[0].Rows[0]["URL_ARCHIVO"]));

                int valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 3);

                if (valor == 0)
                {
                    Mensajes("El registro no se eliminó debido a una inconsistencia en el sistema!.", 0);
                }
                else if (valor != 0)
                {
                    Mensajes("El registro ha sido eliminado correctamente!.", 0);
                }
            }
            else
            {
                Mensajes("El registro no se pudo eliminar, debido a una inconsistencia en el archivo adjunto!.", 0);

            }

            LimpiaFormulario(this);
            Session["ID_ACTIVIDAD_ARCHIVO"] = "";
            StatusLabel.Text = "";
            CargaGrid_archivo(0);
        }
        catch (System.Exception ex)
        {
        }
    }

    // Permite validar un archivo que se desea cargar en la base de datos
    private String validar_archivo(Adjuntar_archivos_act adjuntar_archivos, int opcion)
    {
        string result = "";

        try
        {
            HttpPostedFile ImgFile = f1.PostedFile;
            string nombrearchivo = f1.FileName;
            int tamano = f1.FileBytes.Length;
            string fileName = Server.HtmlEncode(f1.FileName);
            // extension del archivo
            string extension = System.IO.Path.GetExtension(fileName);


            // verificamos que se halla seleccionado un archivo en una ruta especifica
            if ((f1.FileName != "") && (f1.PostedFile != null))
            {
                // valido el tamaño del archivo a cargar
                if (tamano < 10485760)
                {
                    // validamos la extensión del archivo
                    if ((extension == ".doc") || (extension == ".DOC")
                          || (extension == ".docx") || (extension == ".DOCX")
                          || (extension == ".xls") || (extension == ".XLS")
                          || (extension == ".xlsx") || (extension == ".XLSX")
                          || (extension == ".pdf") || (extension == ".PDF")
                          || (extension == ".tif") || (extension == ".TIF")
                          || (extension == ".jpg") || (extension == ".JPG")
                          || (extension == ".jpeg") || (extension == ".JPEG")
                          || (extension == ".rar") || (extension == ".RAR")
                          || (extension == ".zip") || (extension == ".ZIP")
                          || (extension == ".7z") || (extension == ".7Z")
                        )
                    {

                        Session["extension"] = extension;

                        string path = System.Configuration.ConfigurationManager.AppSettings["Archivos"] + this.archivo_filesystem.Value;
                        // TODO: MODIFICAR
                        string FileName = Convert.ToString(adjuntar_archivos.P_ID_ACTIVIDAD) + "_" + Convert.ToInt32(LD_tipo_archivo.SelectedValue) + "_" + (DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss").Replace(" ", "H")) + extension;
                        adjuntar_archivos.P_NOMBRE_ARCHIVO = FileName.Substring(0, FileName.IndexOf("."));

                        //Si el directorio no existe, crearlo
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        string archivo = String.Format("{0}\\{1}", path, FileName);

                        //string url_archivo = "MM\\PSC\\AF\\" + FileName;
                        string url_archivo = this.archivo_filesystem.Value + "\\" + FileName;

                        if (opcion == 1)
                        {
                            // Verificar que el archivo no exista
                            if (File.Exists(archivo))
                            {
                                Mensajes(String.Format("Ya existe un archivo con nombre \"{0}\".", FileName), 0);
                                result = "";
                            }
                            else
                            {
                                f1.SaveAs(archivo);
                                result = url_archivo;
                            }
                        }
                        else if (opcion == 2)
                        {
                            DataSet ds = new DataSet();
                            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);
                            string archivo_ant = System.Configuration.ConfigurationManager.AppSettings["Archivos"] + Convert.ToString(ds.Tables[0].Rows[0]["URL_ARCHIVO"]);

                            // Verificar que el archivo exista
                            if (File.Exists(archivo_ant))
                            {
                                File.Delete(archivo_ant); //Borra el documento anterior
                                f1.SaveAs(archivo);
                                result = url_archivo;
                            }
                            else
                            {
                                Mensajes(String.Format("No existe un archivo con nombre \"{0}\".", Convert.ToString(ds.Tables[0].Rows[0]["NOMBRE_ARCHIVO"]) + ", para reemplazarlo."), 0);
                                result = "";
                            }
                        }
                    }
                    else
                    {
                        Mensajes("El archivo no cumple con las extensiones permitidas!", 0);
                        result = "";
                    }
                }
                else
                {
                    Mensajes("Error al cargar el archivo, por que es mayor al tamaño permitido de 10 MB.", 0);
                    result = "";
                }
            }
            else
            {
                Mensajes("Error no ha seleccionado ningun archivo!.", 0);
                result = "";
            }
        }
        catch
        {
            result = "";
        }

        return result;
    }


    //decodificar y visualizar el archivo adjunto 
    protected bool Crear_archivo(int opcion)
    {
        int valor = 0;
        bool validar = false;
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();

        try
        {
            int tamano = f1.FileBytes.Length;

            adjuntar_archivos.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            if ((Session["ID_ACTIVIDAD_ARCHIVO"] == null) || (Session["ID_ACTIVIDAD_ARCHIVO"].ToString() == ""))
            {
                Session["ID_ACTIVIDAD_ARCHIVO"] = "0";
            }
            else
            {
                adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(Session["ID_ACTIVIDAD_ARCHIVO"]);
            }


            if (LD_MunArchivo.SelectedValue == "")
            {
                adjuntar_archivos.P_ID_MUNICIPIO = 0;
            }
            else
            {
                adjuntar_archivos.P_ID_MUNICIPIO = Convert.ToInt32(LD_MunArchivo.SelectedValue);
            }

            adjuntar_archivos.P_PERSONAS = TB_Personas.Text; // permite validar el archivo

            if (Convert.ToString(ViewState["Tipo_medida"]).Equals("Rehabilitacion"))
            {
                adjuntar_archivos.P_DESCRIPCION = LD_medida.SelectedItem.Text + "|" + LD_medida_2.SelectedItem.Text + "|" + TB_DescripcionArchivo.Text;
            }
            else
            {
                adjuntar_archivos.P_DESCRIPCION = TB_DescripcionArchivo.Text;
            }



            if (opcion == 1) //crear archivo
            {
                adjuntar_archivos.P_URL_ARCHIVO = validar_archivo(adjuntar_archivos, opcion); // permite validar el archivo
                adjuntar_archivos.P_EXTENSION = Convert.ToString(Session["extension"]);
                DateTime fechaExpedicion = Convert.ToDateTime(Convert.ToString(TB_FechaExpedicion.Text));
                DateTime fecha_hoy = DateTime.Now;
                if (fechaExpedicion.Date <= fecha_hoy.Date)
                {
                    if ((adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO == 0) && (adjuntar_archivos.P_URL_ARCHIVO != ""))
                    {
                        adjuntar_archivos.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
                        adjuntar_archivos.P_FECHA_EXPEDICION = Convert.ToString(TB_FechaExpedicion.Text);

                        if (LD_tipo_archivo.SelectedValue == "")
                        {
                            adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = 0;
                        }
                        else
                        {
                            adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_archivo.SelectedValue);
                        }

                        //adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(L_D_dia_actividad_documentos.SelectedValue);
                        adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);


                        //adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO = 1;

                        valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 6); //gurda una perte en actividad_archivo_detalle


                    }

                    if (valor != 0)
                    {
                        texto("El registro se inserto correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                        validar = true;


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
                        string[] datos = {
                                        Convert.ToString(ViewState["sujeto_colectiva"]),
                                        Convert.ToString(adjuntar_archivos.P_ID_ACTIVIDAD_DIA),
                                        Convert.ToString(LD_tipo_archivo.SelectedItem),
                                        adjuntar_archivos.P_FECHA_EXPEDICION,
                                        adjuntar_archivos.P_PERSONAS,
                                        adjuntar_archivos.P_NOMBRE_ARCHIVO,
                                        adjuntar_archivos.P_DESCRIPCION,
                                        Convert.ToString(ViewState["fase"]),
                                        Convert.ToString(Session["usuario"])
                                     };
                        Crear_correo(
                            ((DataSet)ViewState["actividad_responsable"]),          //correos-send
                            "Maariv - Colectiva - Creacion de Documento",           //asunto
                            datos,                                                  //datos
                            4,                                                      //opcion colectica crear archivo
                            0
                        );


                    }
                    else
                    {
                        texto("El registro no se pudo ingresar en la base de datos!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                        validar = false;
                    }
                }
                else
                {
                    texto("La Fecha Ejecución Actividad no puede ser mayor al dia de hoy", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }


            }
            else if (opcion == 2) //Act archivo
            {
                if (tamano != 0)
                {
                    adjuntar_archivos.P_URL_ARCHIVO = validar_archivo(adjuntar_archivos, opcion); // permite validar el archivo
                    adjuntar_archivos.P_EXTENSION = Convert.ToString(Session["extension"]);

                    if ((adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO != 0) && (adjuntar_archivos.P_URL_ARCHIVO != ""))
                    {
                        adjuntar_archivos.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                        adjuntar_archivos.P_FECHA_EXPEDICION = Convert.ToString(L_D_dia_actividad_documentos.SelectedItem);

                        if (LD_tipo_archivo.SelectedValue == "")
                        {
                            adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = 0;
                        }
                        else
                        {
                            adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_archivo.SelectedValue);
                        }

                        valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, opcion);
                    }
                }
                else //Act sin archivo
                {
                    if (adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO != 0)
                    {
                        adjuntar_archivos.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                        adjuntar_archivos.P_FECHA_EXPEDICION = Convert.ToString(L_D_dia_actividad_documentos.SelectedItem);

                        if (LD_tipo_archivo.SelectedValue == "")
                        {
                            adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = 0;
                        }
                        else
                        {
                            adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_archivo.SelectedValue);
                        }

                        valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 4);
                    }
                }

                if (valor != 0)
                {
                    texto("El registro se actualizó correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    validar = true;
                }
                else
                {
                    texto("Se genero un error al actualizar!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                    validar = false;
                }
            }
            LD_tipo_archivo.SelectedValue = "0";
            LD_DepArchivo.SelectedValue = "0";
            // municipio por territorial
            LD_MunArchivo.ClearSelection();
            TB_DescripcionArchivo.Text = "";
            TB_Personas.Text = "";

            guardar_archivo.Visible = true;
            L_D_dia_actividad_documentos.SelectedValue = "0";
            LD_tipo_archivo.SelectedValue = "0";



            //return true;
        }
        catch (Exception ex)
        {
            texto("Ocurrió un error al guardar los datos!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            validar = false;
        }

        return validar;
    }


    // Permite eliminar un registro de los datos adjuntos
    private void EliminaGrid_archivo(string id_actividad_archivo)
    {
        try
        {
            Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
            DataSet ds = new DataSet();

            adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(id_actividad_archivo);

            // permite consultar la url del archivo
            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);

            if (File.Exists(System.Configuration.ConfigurationManager.AppSettings["Archivos"] + Convert.ToString(ds.Tables[0].Rows[0]["URL_ARCHIVO"])))
            {
                File.Delete(System.Configuration.ConfigurationManager.AppSettings["Archivos"] + Convert.ToString(ds.Tables[0].Rows[0]["URL_ARCHIVO"]));

                int valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 3);

                if (valor == 0)
                {
                    texto("El registro no se eliminó debido a una inconsistencia en el sistema!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
                else if (valor != 0)
                {
                    texto("El registro ha sido eliminado correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                }
            }
            else
            {
                texto("El registro no se pudo eliminar, debido a una inconsistencia en el archivo adjunto!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);

            }

            Session["ID_ACTIVIDAD_ARCHIVO"] = "";
            StatusLabel.Text = "";
            CargaGrid_archivo(0);
        }
        catch (System.Exception ex)
        {
        }
    }


    protected void gv16_visual()
    {


        if (gv16.Visible && gv16.Rows.Count > 0 && Panel252.Visible)
        {

            gv16.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            //gv16.HeaderRow.Cells[1].Attributes["data-hide"] = "pc";
            //gv16.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            gv16.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet,pc";
            gv16.HeaderRow.Cells[4].Attributes["data-hide"] = "phone,tablet,pc";
            //gv16.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet,pc";
            //gv16.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet,pc";

            gv16.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet,pc";
            //gv16.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet,pc";
            //gv16.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet,pc";
            //gv16.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet,pc";
            gv16.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet,pc";
            gv16.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet,pc";
            gv16.HeaderRow.Cells[13].Attributes["data-hide"] = "phone,tablet,pc";
            gv16.HeaderRow.Cells[14].Attributes["data-hide"] = "phone,tablet,pc";

            gv16.HeaderRow.TableSection = TableRowSection.TableHeader;
        }


        //TabContainer1.ActiveTabIndex = 3;
    }


    protected void gv_visual()
    {


        if (gv.Visible && gv.Rows.Count > 0)
        {

            //gv.HeaderRow.Cells[0].Attributes["data-hide"] = "phone,tablet";
            //gv.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
            //gv.HeaderRow.Cells[2].Attributes["data-hide"] = "phone,tablet";
            //gv.HeaderRow.Cells[3].Attributes["data-hide"] = "phone,tablet,pc";
            gv.HeaderRow.Cells[4].Attributes["data-class"] = "expand";
            gv.HeaderRow.Cells[5].Attributes["data-hide"] = "phone,tablet,pc";
            gv.HeaderRow.Cells[6].Attributes["data-hide"] = "phone,tablet,pc";

            gv.HeaderRow.Cells[7].Attributes["data-hide"] = "phone,tablet,pc";
            gv.HeaderRow.Cells[8].Attributes["data-hide"] = "phone,tablet,pc";
            //gv.HeaderRow.Cells[9].Attributes["data-hide"] = "phone,tablet,pc";
            //gv.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet,pc";
            //gv.HeaderRow.Cells[11].Attributes["data-hide"] = "phone,tablet,pc";
            //gv.HeaderRow.Cells[12].Attributes["data-hide"] = "phone,tablet,pc";
            //gv.HeaderRow.Cells[13].Attributes["data-hide"] = "phone,tablet,pc";
            //gv.HeaderRow.Cells[14].Attributes["data-hide"] = "phone,tablet,pc";

            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        UP_DatosSujetos.Update();
        //TabContainer1.ActiveTabIndex = 3;
    }
    #endregion

    #endregion

    #endregion


    #region EVENTOS

    protected void LD_Tipo_sujeto_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (LD_Tipo_sujeto.SelectedValue == "3")
        //{
        //    LB_detalle.Visible = true;
        //    LD_Tipo_sujeto_detalle.Visible = true;
        //    LD_tipo_sujeto_detalle(Convert.ToInt32(LD_Tipo_sujeto.SelectedValue));
        //}
        //else
        //{
        //    LB_detalle.Visible = false;
        //    LD_Tipo_sujeto_detalle.Visible = false;
        //}
        L_D_subCategoria();
    }

    protected void buscar_Click(object sender, EventArgs e)
    {
        //Session["ID_SUJETO_COLECTIVA"] = "0";
        ViewState["id_sujeto_colectiva"] = "0";

        CargaGrid(11);
        gv_visual();
    }

    protected void actualizar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalobserEstSuj", "$('#myModalobserEstSuj').modal();", true);
        //Crear(2);
        //CargaGrid(1);
    }

    protected void limpiar_Click(object sender, EventArgs e)
    {
        LimpiaFormulario(this);
        Panel241.Visible = false;
        //guardar.Visible = true;
        actualizar.Visible = false;
    }

    //carga los departamentos dependiendo de la direccion territorial
    protected void LD_Territorial_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LD_Territorial.SelectedValue == "0")
        {
            LD_Departamento.Items.Clear();
            LD_Municipio.Items.Clear();
        }
        else
        {
            LD_Departamento.Enabled = true;
            L_D_Departamentos(Convert.ToInt32(LD_Territorial.SelectedValue));
            LD_Municipio.Items.Clear();
        }
    }

    protected void LD_Departamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_D_Municipio_Dep_territorial(0, Convert.ToInt32(LD_Departamento.SelectedValue));
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            ViewState["ID_RYR_COMUNIDAD"] = Convert.ToInt32(((Label)gvRow.FindControl("ID_RYR_COMUNIDAD")).Text);
            ViewState["NOMBRE_RYR_COMUNIDAD"] = Convert.ToString(((Label)gvRow.FindControl("NOMBRE_RYR_COMUNIDAD")).Text);
            ViewState["fase_colectiva"] = Convert.ToString(((Label)gvRow.FindControl("fase_colectiva")).Text);

            if (e.CommandName == "Actualizar")
            {
                ActualizaGrid(e);
            }
            if (e.CommandName == "Eliminar")
            {
                EliminaGrid(e);
            }

            if (e.CommandName == "fases_colectiva")
            {
                ViewState["ix_gv_sujeto"] = gvRow.RowIndex;
                ConsultaFases();
            }

            if (e.CommandName == "Evidencias")
            {
                CargaGrid_archivo(1);
                ViewState["consulta_archivos"] = "1"; //consulta archivos por src
                L_mensaje.Text = "";
                valida_permisos_rol();
            }
            if (e.CommandName == "Directorio")
            {
                //gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                //Consulta_actividad_detalle(1);
                ConsultaDirectorioSujeto();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal7", "$('#myModal7').modal();", true);
                UP_Detalle.Update();
            }

            gv_visual();
        }
        catch
        {

        }

    }

    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gv.DataSource = Session["lista"];
        gv.DataBind();
        gv_visual();
        UP_DatosSujetos.Update();
    }

    protected void guardar_Click(object sender, EventArgs e)
    {
        Crear(1);
        CargaGrid(1);
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(Session["rol"]) != "1" && Convert.ToString(Session["rol"]) != "37" && Convert.ToString(Session["rol"]) != "145")
            {
                ((LinkButton)e.Row.FindControl("ibtnGActualizar")).Visible = false;
            }
            if (Convert.ToInt32(((Label)e.Row.FindControl("L_alerta")).Text) > 0) //|| false
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = true;
            }

        }


    }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void L_D_Alcance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (L_D_Alcance.SelectedValue != "0")
        {
            if ((L_D_Alcance.SelectedValue == "3") || (L_D_Alcance.SelectedValue == "4"))
            {
                LD_Departamento.Enabled = true;
                LD_Municipio.Enabled = true;
            }
            else
            {
                LD_Departamento.Enabled = false;
                LD_Departamento.SelectedValue = "0";
                LD_Municipio.Enabled = false;
                LD_Municipio.SelectedValue = "0";
            }
        }
    }

    protected void gv_actividad_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = false;
            }

            if (((Label)e.Row.FindControl("id_actividad_estado")).Text == "1")
            {

                ((LinkButton)e.Row.FindControl("actualizar")).Visible = true;

                ((LinkButton)e.Row.FindControl("E_Inactivo")).CssClass = "btn btn-default btn-sm ";
                ((LinkButton)e.Row.FindControl("E_Inactivo")).Visible = false;
                ((LinkButton)e.Row.FindControl("E_Inactivo")).Attributes.Add("Style", "background-color: #e8e8e8; border-color: #eaeaea; color: rgb(156, 151, 151);");
                ((LinkButton)e.Row.FindControl("E_Activo")).CommandName = "F_Inactivo";
                ((LinkButton)e.Row.FindControl("E_Activo")).Attributes.Add("Style", "color:  rgb(177, 12, 12);");
            }
            else if (((Label)e.Row.FindControl("id_actividad_estado")).Text == "4")
            {
                ((LinkButton)e.Row.FindControl("ver")).Visible = true;

                ((LinkButton)e.Row.FindControl("E_Activo")).CssClass = "btn btn-default btn-sm ";
                ((LinkButton)e.Row.FindControl("E_Activo")).Visible = false;
                ((LinkButton)e.Row.FindControl("E_Activo")).Attributes.Add("Style", "background-color: #e8e8e8; border-color: #eaeaea;color: rgb(156, 151, 151);");
                ((LinkButton)e.Row.FindControl("E_Inactivo")).CommandName = "F_Activo";
                ((LinkButton)e.Row.FindControl("E_Inactivo")).Attributes.Add("Style", "color: rgb(28, 158, 20);");

            }

            if (Convert.ToString(ViewState["fase_colectiva"]).ToUpper().Equals("IMPLEMENTACIÓN") &&
                ((Label)e.Row.FindControl("id_nombre_actividad")).Text.Equals("255"))
            {
                ((LinkButton)e.Row.FindControl("LB_FaseActual")).Visible = true;
            }

            else if (Convert.ToString(ViewState["fase_colectiva"]).ToUpper().Equals("DIAGNÓSTICO DEL DAÑO") &&
                ((Label)e.Row.FindControl("id_nombre_actividad")).Text.Equals("51"))
            {
                ((LinkButton)e.Row.FindControl("LB_FaseActual")).Visible = true;
            }
            else if (Convert.ToString(ViewState["fase_colectiva"]).ToUpper().Equals("DISEÑO Y FORMULACIÓN") &&
                           ((Label)e.Row.FindControl("id_nombre_actividad")).Text.Equals("50"))
            {
                ((LinkButton)e.Row.FindControl("LB_FaseActual")).Visible = true;
            }
            else if (Convert.ToString(ViewState["fase_colectiva"]).ToUpper().Equals("CARACTERIZACIÓN DEL DAÑO") &&
            ((Label)e.Row.FindControl("id_nombre_actividad")).Text.Equals("49"))
            {
                ((LinkButton)e.Row.FindControl("LB_FaseActual")).Visible = true;
            }
            else if (Convert.ToString(ViewState["fase_colectiva"]).ToUpper().Equals("ALISTAMIENTO") &&
                ((Label)e.Row.FindControl("id_nombre_actividad")).Text.Equals("48"))
            {
                ((LinkButton)e.Row.FindControl("LB_FaseActual")).Visible = true;
            }
            else if (Convert.ToString(ViewState["fase_colectiva"]).ToUpper().Equals("IDENTIFICACIÓN") &&
                ((Label)e.Row.FindControl("id_nombre_actividad")).Text.Equals("47"))
            {
                ((LinkButton)e.Row.FindControl("LB_FaseActual")).Visible = true;
            }
            else
            {
                ((LinkButton)e.Row.FindControl("LB_CambioFase")).Visible = true;
            }


            if (Convert.ToInt32(Session["rol"]) == 41) //usuario de cunsulta colectiva
            {
                ((LinkButton)e.Row.FindControl("actualizar")).Visible = false;
                ((LinkButton)e.Row.FindControl("ver")).Visible = true;
            }
            if (Convert.ToInt32(Session["rol"]) == 37 || Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == 138 || Convert.ToString(Session["rol"]) == "145") //usuario de cunsulta colectiva
            {
                ((LinkButton)e.Row.FindControl("enviar_comentario")).Visible = true;

            }
            else
            {
                ((LinkButton)e.Row.FindControl("enviar_comentario")).Visible = false;
            }
            //ViewState["fase_colectiva"]  id_nombre_actividad


        }


    }



    protected void gv_actividad_RowComman(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id_actividad = Convert.ToInt32(gv_actividad.DataKeys[gvRow.RowIndex].Values[0].ToString());
            ViewState["id_nombre_actividad"] = Convert.ToInt32(((Label)gvRow.FindControl("id_nombre_actividad")).Text);
            ViewState["id_actividad"] = Convert.ToInt32(gv_actividad.DataKeys[gvRow.RowIndex].Values[0].ToString());
            ViewState["id_actividad_estado"] = Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_estado")).Text);


            if (e.CommandName == "Actualizar")
            {
                L_titulo.Text = Convert.ToString(((Label)gvRow.FindControl("fase_actividad")).Text);

                LD_Dia_actividad(id_actividad);

                int id_nombre_actividad = Convert.ToInt32(((Label)gvRow.FindControl("id_nombre_actividad")).Text);

                L_D_Encuentro(id_nombre_actividad);
                L_D_TipoCostos(id_nombre_actividad);

                Actualizar_actividad(id_actividad);

                string fase = ((Label)gvRow.FindControl("fase_actividad")).Text;


                m_2.Visible = true;//Responsables que ya estaban
                m_4.Visible = true;//Acciones que ya estaban
                Panel10.Visible = true;
                Panel6.Visible = true;

                m_PlanTraslado.Visible = false;
                m_Balance.Visible = false;
                plan_traslado.Visible = false;

                switch (Convert.ToInt32(ViewState["id_nombre_actividad"]))
                {
                    case 301://si es Fase 5 - desarrollo del traslado muestra los desarrollos de Liliana rodriguez
                        m_PlanTraslado.Visible = true;
                        plan_traslado.Visible = true;
                        LlenarCombosDepartamento();
                        LlenarCombosRequeridos();
                        LlenarComboDT();
                        LlenarComboEntidadesRutaComunitaria();
                        GetPlanTraslado();
                        GetCategoria_plan_acción_traslado_Ruta_Comunitaria();
                        lblMensajePersona.Visible = false;
                        Get_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria();
                        Get_Entidades_Plan_Accion_Traslado_Entidad();
                        Get_plan_acción_traslado_balance_traslado_ruta_comunitaria();
                        Get_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria();
                        Get_plan_acción_traslado_profesionales_traslado_ruta_comunitaria();
                        Get_plan_acción_traslado_Inventario_hogar_ruta_comunitaria();
                        Get_Tipo_Evidencia();
                        break;
                    case 304:// si es Fase 8 - cierre / balance del acompañamiento -desarrollo que muestra los desarrollos de Liliana rodriguez
                        m_Balance.Visible = true;
                        PanelPT.Visible = true;
                        break;
                    default:

                        break;
                }
                gv12.Columns[14].Visible = true;
            }
            if (e.CommandName == "Ver")
            {
                L_titulo.Text = Convert.ToString(((Label)gvRow.FindControl("fase_actividad")).Text);

                LD_Dia_actividad(id_actividad);

                int id_nombre_actividad = Convert.ToInt32(((Label)gvRow.FindControl("id_nombre_actividad")).Text);

                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) != 255)
                {
                    Panel10.Visible = false;
                    Panel6.Visible = false;
                }
                else
                {
                    Panel10.Visible = true;
                    Panel6.Visible = true;
                }

                L_D_Encuentro(id_nombre_actividad);
                L_D_TipoCostos(id_nombre_actividad);

                Actualizar_actividad(id_actividad);
                UP_ResultadoBusqueda.Update();
                UP_DatosEvento.Update();
                //gv12.Columns[14].Visible = true;
            }

            if (e.CommandName == "Archivos_fase")
            {
                CargaGrid_archivo(2);
                L_D_Cambiar_accion();
                ViewState["consulta_archivos"] = "2"; //consulta archivos por fase

                if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToString(Session["rol"]) == "37" || Convert.ToString(Session["rol"]) == "145")
                {
                    Panel17.Visible = false;
                    Panel18.Visible = false;
                    div_admin_documentos.Visible = false;
                }

            }

            if (e.CommandName == "enviar_comentario")
            {
                String aux = "";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal13", "$('#myModaEnviarObservaion').modal();", true);

                L_titulo7.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> Solicitud cambio de estado de la fase</span>";
                L_mensaje7.Visible = true;
                L_mensaje7.Text = "Al solicitar el cambio de estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión." +
                " </br> </br>Puede verificar esta solicitud de cambio de estado en el área de bitácoras. ";

                if (Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_estado")).Text) == 1)
                {
                    aux = "ACTIVO";
                }
                else if (Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_estado")).Text) == 3)
                {
                    aux = "REPORTADO";
                }
                else if (Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_estado")).Text) == 4)
                {
                    aux = "APROBADO";
                }


                ViewState["actividad_estado"] = aux;
                Label8.Text = "En este momento el estado de la fase es:    " + aux + "     usted va a cambiar el estado a:";


                if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToString(Session["rol"]) == "37" || Convert.ToString(Session["rol"]) == "145")
                {
                    LD_Estado_actividad.Items.Clear();
                    LD_Estado_actividad.DataBind();

                    LD_Estado_actividad.Items.Insert(0, new ListItem("ACTIVO", "1"));
                    LD_Estado_actividad.Items.Insert(0, new ListItem("APROBADO", "4"));
                    LD_Estado_actividad.Items.Insert(0, new ListItem("Seleccione", "0"));
                }
                else
                {
                    LD_Estado_actividad.Items.Clear();
                    LD_Estado_actividad.DataBind();

                    LD_Estado_actividad.Items.Insert(0, new ListItem("REPORTADO", "3"));
                    LD_Estado_actividad.Items.Insert(0, new ListItem("Seleccione", "0"));
                }

                //CAMBIO ALEJANDRO GRILLA ACTIVIDAD_DETALLE
                DataSet ds_detalle = new DataSet();
                Actividad_detalle actividad_detalle = new Actividad_detalle();
                actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 47)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 896;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 48)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 897;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 49)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 898;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 50)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 899;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 51)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 900;
                }
                else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 255)
                {
                    actividad_detalle.P_ID_TIPO_ACTIVIDAD = 901;
                }
                // permite consultar las actividades
                ds_detalle = FachadaPersistencia.getInstancia().Consulta_actividad_detalle(actividad_detalle, 1);
                if (!ds_detalle.Tables[0].Rows.Count.Equals(0))
                {
                    ViewState["ds_detalle"] = ds_detalle;
                    gv_actividad_detalle.DataSource = ds_detalle;
                    gv_actividad_detalle.DataBind();
                    gv_actividad_detalle.Visible = true;
                }
                else
                {
                    ViewState["ds_detalle"] = null;
                    gv_actividad_detalle.DataSource = null;
                    gv_actividad_detalle.DataBind();
                    gv_actividad_detalle.Visible = true;
                }
                //FIN CAMBIO ALEJANDRO


                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalEnviarObservaion", "$('#myModalEnviarObservaion').modal();", true);
                UpdatePanel6.Update();
                //CargaGrid_archivo(2);
                //L_D_Cambiar_accion();
                //ViewState["consulta_archivos"] = "2"; //consulta archivos por fase

                //if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToString(Session["rol"]) == "37")
                //{
                //    Panel17.Visible = false;
                //    Panel18.Visible = false;
                //    div_admin_documentos.Visible = false;
                //}

            }

            if (e.CommandName == "F_Activo")
            {
                L_Validacion.Text = "Fase_Activa";
                texto("Va a cambiar el estado de la fase a <strong>activo</strong>, esta opción establece la que fase no está completamente culminada por lo cual se habilitan los permisos para que se modifiquen"
                + " las evidencias y se pueda subir nueva información, por favor pase esta fase a aprobada una vez que se cumplan todas las evidencias.  ", 2);
                Mensajes_2("", this.L_mensaje.Text, 4);

            }
            if (e.CommandName == "F_Inactivo")
            {

                if (true)//validar que todos los dias esten en estado in (implementada10 suspendida11 cumplida12)
                {
                    L_Validacion.Text = "Fase_Inactiva";
                    texto("Va a cambiar el estado de la fase a <strong> aprobado</strong>, esta opción confirma que la fase se encuentra con todas las evidencias"
                    + " y que se han cumplido cada una de las actividades. Por favor tener en cuenta que al aprobar esta fases no se podrá subir nueva información.", 2);
                    Mensajes_2("", this.L_mensaje.Text, 4);
                }

            }

            if (e.CommandName == "Cambio_fase")
            {
                L_Validacion.Text = "Cambio_fase";
                L_V1.Text = ((Label)gvRow.FindControl("fase_colectiva")).Text;
                texto("Va a realizar un cambio de <strong> fase</strong>.", 2);
                Mensajes_2("", this.L_mensaje.Text, 4);

            }

            valida_permisos_rol();

        }
        catch
        {
            texto("Error al realizar un evento de la fase, por favor inténtelo más tarde. ", 3);
            Mensajes_2("", this.L_mensaje.Text, 3);
        }

    }


    private void act_desACt_pestañas(object sender, GridViewCommandEventArgs e)
    {
        //if (Convert.ToString(Session[]) == 1)
        //{

        //}
    }



    // paginado de la grilla gv
    protected void gv_actividad_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_actividad.PageIndex = e.NewPageIndex;
        gv_actividad.DataSource = ViewState["lista"];
        gv_actividad.DataBind();
    }

    #region Administar actividades




    #region ACTIVIDAD RESPONSABLE (Pestaña 1 o 2)


    // permite guardar el responsable
    protected void B_guardar_responsable_Click(object sender, EventArgs e)
    {
        Crear_responsable(1);
        TabName.Value = "Responsables";
        UP_Responsable.Update();
    }

    // permite actualizar el responsable
    protected void B_actualizar_responsable_Click(object sender, EventArgs e)
    {
        Crear_responsable(2);
        LD_usuario.SelectedValue = "0";
        LD_rol_responsable.SelectedValue = "0";
    }


    // permite guardar el responsable
    protected void B_per_guardar_responsable_Click(object sender, EventArgs e)
    {
        Crear_responsable(1);
    }

    // permite actualizar el responsable
    protected void B_per_actualizar_responsable_Click(object sender, EventArgs e)
    {
        Crear_responsable(2);

        LD_usuario.SelectedValue = "0";
        LD_rol_responsable.SelectedValue = "0";
    }

    // permite eliminar el detalle
    protected void gv12_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar_actividad_responsable")
        {
            Eliminar_actividad_responsable(e);
        }
    }

    protected void gv12_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToInt32(Session["estado"]) == 3) // por consultar
            {
                e.Row.Cells[11].Visible = false;
            }
            else if (Convert.ToInt32(Session["estado"]) == 2) // por actualizar
            {
                e.Row.Cells[11].Visible = true;
            }
        }
    }

    protected void gv12_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv12.PageIndex = e.NewPageIndex;
        gv12.DataSource = ViewState["actividad_responsable"];
        gv12.DataBind();

    }

    #endregion

    #region ACTIVIDAD DIA-ACCIONES (Pestaña 4 - OCULTA)

    protected void gv5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Actividad_dia actividad_dia = new Actividad_dia();
        DataSet ds = new DataSet();
        GridViewRow gv51;

        try
        {
            if (e.CommandName == "Actualizar_dia")
            {
                gv5.DataSource = ViewState["ds_dias_actividad"]; //setea el color de la grilla a defautl(sin selección)
                gv5.DataBind();

                GridViewRow selectedRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int RowIndexx = Convert.ToInt32(selectedRow.RowIndex);
                gv5.Rows[RowIndexx].CssClass = "select";
                gv51 = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                //// permite consultar los dias de la actividad
                ds = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 9);

                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    TB_Fecha.Text = Convert.ToString(ds.Tables[0].Rows[0]["DIA_ACTIVIDAD"]);
                    TB_HoraInicio.Text = Convert.ToString(ds.Tables[0].Rows[0]["HORA_INICIO"]);
                    TB_HoraFin.Text = Convert.ToString(ds.Tables[0].Rows[0]["HORA_FIN"]);

                    TB_Direccion_lugar.Text = Convert.ToString(ds.Tables[0].Rows[0]["LUGAR_ACTIVIDAD"]);

                    TB_actividad_detalle.Text = Convert.ToString(ds.Tables[0].Rows[0]["DESCRIPCION_ACTIVIDAD_DETALLE"]);

                    // LD_Encuentro.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OBSERVACION_ACTIVIDAD_DIA"]);

                    string valor = (Convert.ToString(ds.Tables[0].Rows[0]["OBSERVACION_ACTIVIDAD_DIA"]));
                    int validar = 0;

                    foreach (ListItem item in LD_Encuentro.Items)
                    {
                        if (item.Text == valor)
                        {
                            //item.Selected = true;
                            LD_Encuentro.SelectedValue = item.Value;
                            validar = 1;
                            break;
                        }
                    }
                    if (validar != 1)
                    {
                        LD_Encuentro.SelectedValue = "0";
                    }

                    LD_tipo_actividad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_ACTIVIDAD"]);

                    //TB_Proyeccion.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROYECCION"]);
                    //TB_Gestion.Text = Convert.ToString(ds.Tables[0].Rows[0]["GESTION"]);
                    LD_DepartamentoDia.SelectedValue = ds.Tables[0].Rows[0]["ID_DEPARTAMENTO"].ToString();
                    LD_Departamento_Dia();
                    LD_MunicipioDia.SelectedValue = ds.Tables[0].Rows[0]["ID_MUNICIPIO"].ToString();

                    guardar_dias.Visible = false;
                    B_ActualizarDia.Visible = true;
                    B_CancelarDia.Visible = true;
                }
                else
                {
                    texto("No se ha podido cargar la información del evento, por favor reporte.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            else if (e.CommandName == "Dia_aprobado")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_V1.Text = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_Validacion.Text = "Aprobar_dia_actividad";
                texto("Al dar visto bueno a este día, en el marco de las actividades que usted desarrolla como profesional, manifiesta que ha verificado la información" +
                    "ingresada en el aplicativo MAARIV, además garantiza que las acciones relacionadas a cada uno de los participantes asistentes a la actividad," +
                    " coinciden con los documentos que se adjuntaron para este día como evidencia. Así mismo que las actividades y evidencias adjuntas dentro del" +
                    " sistema se realizaron teniendo en cuenta los procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión." +
                    "</br></br>Una vez se apruebe la revisión completa de los días, se continua con las fases de Aprobación y Reporte de las actividades y sus participantes" +
                    " a los indicadores de gestión del proceso de Reparación Integral.", 2); Mensajes_2("OBSERVACIÓN", this.L_mensaje.Text, 4);

            }
            else if (e.CommandName == "Dia_denegado")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                Actualiza_dias_actividad(3);
                //CargaGrid_archivo();
                UP_Archivos.Update();
            }
            else if (e.CommandName == "Por_Aprobar")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_Validacion.Text = "Por_Aprobar_dia_actividad";
                L_V1.Text = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                texto("Al seleccionar esta opción para este día, en el marco de las actividades que usted desarrolla como profesional, manifiesta que" +
                    "ha verificado la información ingresada en el aplicativo MAARIV, además garantiza que las acciones relacionadas a cada uno de los participantes" +
                    " asistentes a la actividad, coinciden con los documentos que se adjuntaron para este día como evidencia. Así mismo que las actividades y evidencias" +
                    " adjuntas dentro del sistema se realizaron teniendo en cuenta los procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado" +
                    " de Gestión. </br></br>" +
                    "Una vez se revise este día por el responsable a cargo, el día de esta actividad cambiará ha estado revisado.</br></br>" +
                    "Una vez se apruebe la revisión completa de los días, se continua con las fases de Aprobación y Reporte de las actividades y sus participantes" +
                    " a los indicadores de gestión del proceso de Reparación Integral.", 2); Mensajes_2("OBSERVACIÓN", this.L_mensaje.Text, 4);
            }


            if (e.CommandName == "Evidencias")
            {


                L_mensaje.Text = "";

                ViewState["consulta_archivos"] = "3";

                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value)); //aca
                L_D_Tipo_archivo_obligatorio();

                ViewState["Tipo_medida"] = ((Label)gv51.FindControl("TIPO_MEDIDA_2")).Text;

                //SOLO PARA ALISTAMIENTO - ACTIVIDAD 5
                string ACTIVIDAD_D = ((Label)gv51.FindControl("ACTIVIDAD_D")).Text;



                if (((Label)gv51.FindControl("TIPO_MEDIDA_2")).Text.Equals("Rehabilitación"))
                {
                    ViewState["TIPO_ACTIVIDAD_ENTRELAZANDO"] = ((Label)gv51.FindControl("TIPO_MEDIDA_2")).Text;
                    //////////////////
                    LD_medida.Items.Clear();
                    LD_medida.Items.Insert(0, new ListItem("Selecione medida", "0"));
                    LD_medida.Items.Insert(1, new ListItem("Imaginarios Colectivos", "1"));
                    LD_medida.Items.Insert(2, new ListItem("Prácticas Sociales", "2"));
                    LD_medida.Items.Insert(3, new ListItem("Viviendo La Diferencia O Pedagogía Social", "3"));

                    LD_medida.Items.Insert(4, new ListItem("Duelos Colectivos (Adicional Guía De Memoria)", "4"));
                    LD_medida.Items.Insert(5, new ListItem("Transformación De Escenarios Locales", "5"));
                    LD_medida.Items.Insert(6, new ListItem("Organizaciones - Fortalecimiento Organizativo", "6"));
                    LD_medida.Items.Insert(7, new ListItem("Organizaciones - Incidencia Social", "7"));
                    LD_medida.Items.Insert(8, new ListItem("Organizaciones - Iniciativas Locales de Memoria", "8"));
                    LD_medida.Items.Insert(9, new ListItem("EVALUACION SEGUIMIENTO Y CIERRE", "9"));
                    LD_medida.Items.Insert(10, new ListItem("CIRRE MEDIDA DE REHABILITACION", "10"));
                    /////////

                    div_medida.Visible = false;
                    LD_medida_2.Visible = true;
                    label_medida_2.Visible = true;
                    panel_check_medida.Visible = true;
                    RB_Tipo_actividad.SelectedValue = "Entrelazando";
                    RB_Tipo_actividad_SelectedIndexChanged(sender, e);

                    //Descripcion_archivo_div.Visible = false;

                }
                else if (((Label)gv51.FindControl("ACTIVIDAD_D")).Text.Contains("5."))
                {
                    ViewState["TIPO_ACTIVIDAD_ENTRELAZANDO"] = ((Label)gv51.FindControl("ACTIVIDAD_D")).Text;
                    //////////////////
                    LD_medida.Items.Clear();
                    LD_medida.Items.Insert(0, new ListItem("Selecione medida", "0"));
                    LD_medida.Items.Insert(1, new ListItem("Identificación y profundización de Tejedores y Tejedoras", "11"));
                    LD_medida.Items.Insert(2, new ListItem("Construcción del rol de ser Tejedor y Tejedora 1.", "12"));
                    LD_medida.Items.Insert(3, new ListItem("Fortalecimiento del ser Tejedor y Tejedora 2.", "13"));
                    LD_medida.Items.Insert(4, new ListItem("Acta conformación comité de impulso", "14"));
                    LD_medida.Items.Insert(5, new ListItem("Informe de Cierre", "15"));
                    //LD_medida_2.Items.Clear();
                    /////////

                    LD_medida_2.Visible = false;
                    label_medida_2.Visible = false;
                    panel_check_medida.Visible = false;
                    RB_Tipo_actividad.SelectedValue = "Entrelazando";
                    RB_Tipo_actividad_SelectedIndexChanged(sender, e);
                    div_medida.Visible = true;
                    Descripcion_archivo_div.Visible = false;

                }

                else
                {
                    //check_medida.Checked = false;

                    div_medida.Visible = false;
                    panel_check_medida.Visible = false;
                    Descripcion_archivo_div.Visible = true;
                    CargaGrid_documentos_obligatorios();
                }



                CargaGrid_archivo(0);
                L_D_Cambiar_accion();

                gv16.Columns[3].Visible = false;
                gv16.Columns[4].Visible = false;

                gv16.Columns[10].Visible = true;
                gv16.Columns[11].Visible = true;
                gv16.Columns[12].Visible = true;
                gv16.Columns[13].Visible = true;
                gv16.Columns[14].Visible = true;

                if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToString(Session["rol"]) == "37" || Convert.ToString(Session["rol"]) == "145")
                {
                    Panel17.Visible = true;
                    Panel18.Visible = true;
                    div_admin_documentos.Visible = true;
                }




                //L_D_dia_actividad_documentos.SelectedValue = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                //Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
                //adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);

                //ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);
                ////Panel252.Visible = true;
                //if (!ds.Tables[0].Rows.Count.Equals(0))
                //{
                //    Session["lista_archivos"] = ds;
                //    gv16.Visible = true;
                //    gv16.DataSource = ds;
                //    gv16.DataBind();
                //    gv16_visual();

                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                //    UP_Archivos.Update();

                //}
                //else
                //{
                //    Session["lista_archivos"] = null;
                //    gv16.Visible = false;
                //    gv16.DataSource = null;
                //    gv16.DataBind();
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                //    UP_Archivos.Update();
                //}


                gv16_visual();
            }

            if (e.CommandName == "Encuesta")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                //if (ViewState["id_actividad_dia_estado"].ToString() != "1" && ViewState["id_actividad_dia_estado"].ToString() != "3")
                //{
                //    LB_GuardarInforme.Visible = false;
                //}
                //else
                //{
                //    LB_GuardarInforme.Visible = true;
                //}

                LB_GuardarInforme.Visible = true;

                ConsultaActividadDiaEncuestaPreguntas(gv51);
                Li_diaActividad.Text = String.Format("{0} <small> </small> ", ((Label)gv51.FindControl("ACTIVIDAD_D")).Text);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalEncuesta", "$('#myModalEncuesta').modal({backdrop: 'static', keyboard: false});", true);
                UpdatePanel8.Update();
            }

            if (e.CommandName == "Actualizar")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                RB_Producto.SelectedValue = "si";
                RB_Producto_SelectedIndexChanged(sender, e);

                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) != 255)
                {
                    label_medida_producto.Visible = false;
                    TextBox12.Visible = false;
                    label6.Visible = false;
                    RB_Producto.Visible = false;
                    ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                }
                else
                {
                    label_medida_producto.Visible = true;
                    TextBox12.Visible = true;
                    label6.Visible = false;
                    RB_Producto.Visible = false;
                    ViewState["ID_ACTIVIDAD_PRODUCTO"] = Convert.ToInt32(((Label)gv51.FindControl("ACTIVIDAD_PRODUCTO_ID")).Text);
                    ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                }

                //ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                //Consulta_actividad_detalle(1);
                label_tipo_medida.Visible = false;
                LD_tipo_medida.Visible = false;
                B_guardar_actividad_c.Visible = false;
                B_actualizar_actividad_c.Visible = true;


                TextBox12.Text = Convert.ToString(((Label)gv51.FindControl("PRODUCTO_D")).Text);
                TextBox13.Text = Convert.ToString(((Label)gv51.FindControl("ACTIVIDAD_D")).Text);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal6", "$('#myModal6').modal();", true);
                UpdatePanel5.Update();
                UP_Detalle.Update();
            }

            if (e.CommandName == "Eliminar")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) != 255)
                {
                    label_medida_producto.Visible = false;
                    TextBox12.Visible = false;
                    label6.Visible = false;
                    RB_Producto.Visible = false;
                    ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                }
                else
                {
                    label_medida_producto.Visible = true;
                    TextBox12.Visible = true;
                    label6.Visible = true;
                    RB_Producto.Visible = true;
                    ViewState["ID_ACTIVIDAD_PRODUCTO"] = Convert.ToInt32(((Label)gv51.FindControl("ACTIVIDAD_PRODUCTO_ID")).Text);
                    ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                }

                Crear_actividad_detalle(9);


                //ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                //Consulta_actividad_detalle(1);




            }

            if (e.CommandName == "Bitacora")
            {
                B_guardar_detalle.Visible = true;
                TB_actividad_detalle.Text = "";
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                string dia = Convert.ToString(ViewState["id_actividad_dia"]);
                Consulta_actividad_detalle(1);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal3", "$('#myModal3').modal();", true);
                UP_Detalle.Update();
            }

            if (e.CommandName == "Costos")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                //TB_Proyeccion.Text = ((Label)gv51.FindControl("proyeccion")).Text;
                //TB_Gestion.Text = ((Label)gv51.FindControl("gestion")).Text; 
                TB_Proyeccion.Text = "0";
                TB_Gestion.Text = "0";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal4", "$('#myModal4').modal();", true);
                Consulta_actividad_detalle(3);

                UP_Costos.Update();
            }

            if (e.CommandName == "Estado_dia")
            {
                int verifica_permisos = 0;
                int cant = 0;
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia_estado"] = Convert.ToInt32(((Label)gv51.FindControl("LB_IdEstado_dia")).Text);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                LD_Estado_dia.Enabled = true;
                TB_ObCambio.Text = "";

                L_D_Estado_dia();

                ViewState["dia_actividad_estado"] = ((Literal)gv51.FindControl("LI_Estado_dia")).Text;

                if (Convert.ToInt32(ViewState["id_actividad_estado"]) == 1)
                {
                    if (Consulta_archivos_obligatorio())
                    {

                        cant = GlobalVariables.id_usuario_territorioA.Length;

                        for (int i = 0; i < cant; i++)
                        {
                            if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                            {
                                if (BalidaCambioEstadoDoc(1)) // valida que el territorio no tenga documentos en estado "no aprobado"
                                {

                                    Consulta_actividad_detalle(4);
                                    GV_Solicitudes.Columns[0].Visible = false;
                                    Vari1.Text = "Solicitud_cambio_estado";
                                    L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> Solicitud cambio de estado </span>";
                                    L_mensaje3.Text = "Al solicitar el cambio de estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                    " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                    " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión." +
                                    " </br> </br>Puede verificar esta solicitud de cambio de estado en el área de bitácoras. ";

                                    L_Solicitud.Text = "En este momento el estado es: <strong>" + ViewState["dia_actividad_estado"] + "</strong>, usted va a solicitar el cambio de estado a:";

                                    P_ObEstado.Visible = true;



                                    if (Convert.ToString(ViewState["fase"]) == "Ruta")
                                    {
                                        LD_Estado_dia.Enabled = false;
                                        LD_Estado_dia.SelectedValue = "10";
                                    }

                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                    UpdatePanel2.Update();

                                }
                                verifica_permisos++;
                            }
                        }


                        cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                        for (int i = 0; i < cant; i++)
                        {
                            if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
                            {
                                if (BalidaCambioEstadoDoc(3)) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                                {
                                    Consulta_actividad_detalle(4);

                                    Vari1.Text = "Cambiar_estado";
                                    L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro? Cambio de estado </span>";
                                    L_mensaje3.Text = "Al cambiar el estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                    " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                    " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión.";
                                    P_ObEstado.Visible = true;

                                    L_Solicitud.Text = "En este momento el estado es: <strong>\"" + ViewState["dia_actividad_estado"] + "\"</strong>, usted va a cambiar el estado a:";

                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                    UpdatePanel2.Update();

                                }
                                verifica_permisos++;
                            }
                        }

                        if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == 37 || Convert.ToString(Session["rol"]) == "145")
                        {
                            if (true) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                            //if (BalidaCambioEstadoDoc(3)) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                            {
                                Consulta_actividad_detalle(4);
                                Vari1.Text = "Cambiar_estado";
                                L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro? Cambio de estado </span>";
                                L_mensaje3.Text = "Al cambiar el estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión.";
                                P_ObEstado.Visible = true;

                                L_Solicitud.Text = "En este momento el estado es: <strong>\"" + ViewState["dia_actividad_estado"] + "\"</strong>, usted va a cambiar el estado a:";

                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                UpdatePanel2.Update();

                            }
                            verifica_permisos++;
                        }

                        if (verifica_permisos == 0) //|| false
                        {

                            texto("El rol actual no le permite realizar cambios a los estados.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                        }

                    }
                }
                else
                {
                    texto("La fase se encuentra en estado <strong> aprobado</strong>, por lo cual no se pueden realizar cambios en los estados. ", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }


            }

            valida_permisos_rol();
        }
        catch (Exception ex)
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }


    protected void gv5_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int cant = 0;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String Estado = gv.Rows[0].Cells[4].Text;
            if (Convert.ToString(Session["rol"]) != "1")
            {
                ((LinkButton)e.Row.FindControl("Encuesta")).Visible = false;
            }
            else
            {
                if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 48 || Convert.ToInt32(ViewState["id_nombre_actividad"]) == 255)
                {

                    if (((Label)e.Row.FindControl("ACTIVIDAD_D")).Text == "Gestión de Cierre de Fase" || ((Label)e.Row.FindControl("ACTIVIDAD_D")).Text == "8. Cierre de Fase")
                    {
                        ((LinkButton)e.Row.FindControl("Encuesta")).Visible = true;
                    }
                    else
                    {
                        ((LinkButton)e.Row.FindControl("Encuesta")).Visible = false;
                    }

                }
                else
                {
                    ((LinkButton)e.Row.FindControl("Encuesta")).Visible = false;
                }
            }





            if (Convert.ToString(Session["rol"]) != "1" && Convert.ToString(Session["rol"]) != "37" && Convert.ToString(Session["rol"]) != "145")
            {
                ((LinkButton)e.Row.FindControl("Actualizar")).Visible = false;
                ((LinkButton)e.Row.FindControl("ibtnGEliminar_actividad_dia")).Visible = false;
            }

            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = false;
            }

            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta_bitacora")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_Circle")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_Circle")).Visible = false;
            }

            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta_documentos")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_Circle_documentos")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_Circle_documentos")).Visible = false;
            }

            ((LinkButton)e.Row.FindControl("Costos")).Visible = false;

            //if (Convert.ToInt32(this.id_usuario_2da_instancia.Value) == Convert.ToInt32(Session["rol"]) || 1 == Convert.ToInt32(Session["rol"])) //|| false

            cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

            for (int i = 0; i < cant; i++)
            {
                if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]) || Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == 41 || Convert.ToInt32(Session["rol"]) == 37 || Convert.ToString(Session["rol"]) == "145")
                {
                    ((LinkButton)e.Row.FindControl("Costos")).Visible = true;
                }
            }

            if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "8" || ((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "10")
            {
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block  btn-success disabled";
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CommandName = "disabled";
                e.Row.FindControl("S_EstadoDia").Visible = false;

            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "9")
            {
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block btn-danger disabled";
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CommandName = "disabled";
                e.Row.FindControl("S_EstadoDia").Visible = false;

            }


            if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "1")
            {
                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).Attributes.Add("Style", "opacity: 0.3;");

                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).Attributes.Add("Style", "opacity: 0.3;");

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).Attributes.Add("Style", "opacity: 0.3;");
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                // if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_territorio.Value))


                cant = GlobalVariables.id_usuario_territorioA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                    {

                        ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "Por_Aprobar";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).Attributes.Add("Style", "opacity: 1;");
                    }
                }
            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "2")
            {
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-success disabled";

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";

                ((ImageButton)e.Row.FindControl("actualizar_dia")).Visible = false;
                ((Label)e.Row.FindControl("Val_DiaAprobado")).Visible = true;

                if (Convert.ToInt32(Session["rol"]) == 1)
                {
                    ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default";
                    ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "Dia_denegado";
                }
            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "3")
            {
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-danger disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                // if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))

                cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]) || Convert.ToInt32(Session["rol"]) == 1)
                    {
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";
                    }
                }
                //else if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_territorio.Value))


                cant = GlobalVariables.id_usuario_territorioA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                    {
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";
                    }
                }


            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "4")
            {
                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-warning disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";

                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                ((Label)e.Row.FindControl("Pen_Aprobacion")).Visible = true;
                ((ImageButton)e.Row.FindControl("actualizar_dia")).Visible = false;


                cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
                    {
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "Dia_aprobado";
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default ";

                        ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default ";
                        ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "Dia_denegado";
                    }
                }

                //if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))
                //{

                //}




            }
            else
            {
                e.Row.FindControl("estado_dia").Visible = false;
                ((Label)e.Row.FindControl("LB_EstadoDia")).Text = "indefinido";
                // e.Row.FindControl("LB_EstadoDia").Visible = true;
            }


        }
    }


    protected void TB_HoraInicio_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(TB_HoraInicio.Text).Hour + 4 >= 24)
        {
            TB_HoraFin.Text = "23:59";
        }
    }



    protected void LD_DepartamentoDia_SelectedIndexChanged(object sender, EventArgs e)
    {
        LD_Departamento_Dia();
    }


    protected void B_ActualizarDia_Click(object sender, EventArgs e)
    {
        Actividad_dia actividad_dia = new Actividad_dia();
        Persona persona = new Persona();

        actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

        Actualiza_dias_actividad(1);
        valida_permisos_rol();

        if (B_ActualizarDia.Visible)
        {
            guardar_dias.Visible = false;
        }

        UP_Archivos.Update();
    }


    // permite guardar los dias
    protected void guardar_dias_Click(object sender, EventArgs e)
    {
        Actividad_dia actividad_dia = new Actividad_dia();
        Persona persona = new Persona();

        Crear_actividad_detalle(1);
        Crear_dias_actividad();
        consulta_dias_actividad(1);
        LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
    }

    protected void B_GCostos_Click(object sender, EventArgs e)
    {
        Crear_actividad_detalle(4);
        Consulta_actividad_detalle(3);
    }

    #endregion

    #region ACTIVIDAD ARCHIVO (Pestaña 3 o 5)

    protected void buscar_archivo_Click(object sender, EventArgs e)
    {
        //CargaGrid_archivo();
    }

    protected void guardar_archivo_Click(object sender, EventArgs e)
    {
        Crear_archivo(1);
        Session["ID_ACTIVIDAD_ARCHIVO"] = "";
        StatusLabel.Text = "";
        CargaGrid_archivo(0);
        gv16_visual();
    }

    protected void actualizar_archivo_Click(object sender, EventArgs e)
    {
        Crear_archivo(2);
        Session["ID_ACTIVIDAD_ARCHIVO"] = "";
        StatusLabel.Text = "";
        CargaGrid_archivo(0);
    }


    protected void gv16_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int cant = 0;
        if (e.CommandName == "Eliminar")
        {
            L_Validacion.Text = "EliminaGrid_archivo";

            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            L_V1.Text = Convert.ToString(((Label)gvRow.FindControl("id_actividad_archivo")).Text);

            texto("Confirme la eliminación de este registro", 2); Mensajes_2("", this.L_mensaje.Text, 4);
            Persona persona = new Persona();
            Actividad_dia actividad_dia = new Actividad_dia();

            actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

        }
        if (e.CommandName == "Actualizar")
        {
            GridViewRow gvRow2 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            //TB_actividad_detalle.Text = Convert.ToString(((Label)gvRow.FindControl("descripcion_actividad_detalle")).Text);

            //ViewState["ID_ACTIVIDAD_DIA_BITACORA"] = Convert.ToInt32(((Label)gv51.FindControl("ID_ACTIVIDAD_DIA_BITACORA")).Text);
            //B_guardar_detalle.Visible = false;
            //B_actualizar_detalle.Visible = true
            guardar_archivo.Visible = false;
            actualizar_archivo.Visible = true;

            Session["ID_ACTIVIDAD_ARCHIVO_2"] = Convert.ToString(((Label)gvRow2.FindControl("id_actividad_archivo")).Text);
            Session["ID_ACTIVIDAD_ARCHIVO"] = Convert.ToString(((Label)gvRow2.FindControl("id_actividad_archivo")).Text);
            LD_tipo_archivo.SelectedValue = Convert.ToString(((Label)gvRow2.FindControl("id_tipo_actividad_archivo")).Text);

            TB_FechaExpedicion.Text = ((Label)gvRow2.FindControl("FECHA_EXPEDICION")).Text;
            //LD_MunArchivo.Enabled = false;
            //LD_DepArchivo.Enabled = false;
            //TB_DescripcionArchivo.Enabled = false;
            //TB_Personas.Enabled = false;
            LD_DepArchivo.SelectedValue = Convert.ToString(((Label)gvRow2.FindControl("ID_DEPARTAMENTO")).Text);
            L_D_MunArchivo();
            // municipio por territorial
            LD_MunArchivo.SelectedValue = Convert.ToString(((Label)gvRow2.FindControl("ID_MUNICIPIO")).Text);
            TB_DescripcionArchivo.Text = ((Label)gvRow2.FindControl("DESCRIPCION")).Text;
            TB_Personas.Text = ((Label)gvRow2.FindControl("PERSONAS")).Text;




            //if ((adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO == 0) && (adjuntar_archivos.P_URL_ARCHIVO != ""))
            //{
            //    adjuntar_archivos.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
            //    adjuntar_archivos.P_FECHA_EXPEDICION = Convert.ToString(TB_FechaExpedicion.Text);

            //    if (LD_tipo_archivo.SelectedValue == "")
            //    {
            //        adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = 0;
            //    }
            //    else
            //    {
            //        adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_archivo.SelectedValue);
            //    }

            //    adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(L_D_dia_actividad_documentos.SelectedValue);
            //    adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);


            //    adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO = 1;

            //    valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 6); //gurda una perte en actividad_archivo_detalle
            //}

            //if (valor != 0)
            //{
            //    texto("El registro se inserto correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);
            //    validar = true;


            //    /*
            //    * DATOS[]
            //    * 0-sujeto_colectiva 
            //    * 1-adjuntar_archivos.P_ID_ACTIVIDAD_DIA 
            //    * 2-LD_tipo_archivo.SelectedItem 
            //    * 3-adjuntar_archivos.P_FECHA_EXPEDICION 
            //    * 4-adjuntar_archivos.P_PERSONAS
            //     * 5-adjuntar_archivos.P_NOMBRE_ARCHIVO
            //     * 6-adjuntar_archivos.P_DESCRIPCION
            //     * 7-Convert.ToString(ViewState["fase"])
            //     * 8-Convert.ToString(Session["usuario"])
            //    */
            //    string[] datos = {
            //                            Convert.ToString(ViewState["sujeto_colectiva"]),
            //                            Convert.ToString(adjuntar_archivos.P_ID_ACTIVIDAD_DIA),
            //                            Convert.ToString(LD_tipo_archivo.SelectedItem),
            //                            adjuntar_archivos.P_FECHA_EXPEDICION,
            //                            adjuntar_archivos.P_PERSONAS,
            //                            adjuntar_archivos.P_NOMBRE_ARCHIVO,
            //                            adjuntar_archivos.P_DESCRIPCION,
            //                            Convert.ToString(ViewState["fase"]),
            //                            Convert.ToString(Session["usuario"])
            //                         };
            //    Crear_correo(
            //        ((DataSet)ViewState["actividad_responsable"]),          //correos-send
            //        "Maariv - Colectiva - Creacion de Documento",           //asunto
            //        datos,                                                  //datos
            //        4,                                                      //opcion colectica crear archivo
            //        0
            //    );


            //}
            //else
            //{
            //    texto("El registro no se pudo ingresar en la base de datos!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            //    validar = false;
            //}






            //Crear_archivo(1);
            //Session["ID_ACTIVIDAD_ARCHIVO"] = "";
            //StatusLabel.Text = "";
            //CargaGrid_archivo(0);
            //gv16_visual();
        }
        else if (e.CommandName == "Documento_aprobado")
        {
            ActualizaGrid_archivo(e, 3);
        }
        else if (e.CommandName == "Documento_denegado")
        {
            ActualizaGrid_archivo(e, 4);
        }
        else if (e.CommandName == "Descargar")
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id_actividad_archivo = Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_archivo")).Text);
            int id_actividad_archivo_estado = Convert.ToInt32(((Label)gvRow.FindControl("id_actividad_archivo_estado")).Text);

            Mensajes("Descargar_archivos.aspx?ID_AC=" + Base64Encode(Convert.ToString(id_actividad_archivo)) + "&ID_U2I=" + Base64Encode(this.id_usuario_2da_instancia.Value) + "&ID_U3I=" + Base64Encode(this.id_usuario_3ra_instancia.Value), 9);


            cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

            for (int i = 0; i < cant; i++)
            {
                if (id_actividad_archivo_estado == 1 && GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
                {
                    gvRow.FindControl("estado_doc").Visible = true;
                    gvRow.FindControl("LB_EstadoDoc").Visible = false;
                    ((LinkButton)gvRow.FindControl("Aprobado")).CssClass = "btn btn-default";
                    ((LinkButton)gvRow.FindControl("Denegado")).CssClass = "btn btn-default";
                }
            }


            //if ((id_actividad_archivo_estado == 1) && ((Convert.ToInt32(this.id_usuario_2da_instancia.Value) == Convert.ToInt32(Session["rol"]))
            //    || (Convert.ToInt32(this.id_usuario_3ra_instancia.Value) == Convert.ToInt32(Session["rol"]))))
            //{

            //}

            UP_Archivos.Update();
        }
        else if (e.CommandName == "disabled")
        {
            texto("Acceso no autorizado al código fuente del sistema!.  Por seguridad del aplicativo se cerrara la sesión iniciada.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            Session.Abandon();
            FormsAuthentication.SignOut(); // permite eliminar la cache del usuario
        }

        gv16_visual();

        TabName.Value = "Documentos";
    }

    //codifica strings
    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    // permite manejar el index de la grilla de archivo
    protected void gv16_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv16.PageIndex = e.NewPageIndex;
        gv16.DataSource = Session["lista_archivos"];
        gv16.DataBind();
        valida_permisos_rol();
        gv16_visual();
    }

    // permite visualizar el archivo
    protected void gv16_SelectedIndexChanged(object sender, EventArgs e)
    {
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        DataSet ds = new DataSet();

        adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(((Label)(gv16.SelectedRow.Cells[0].FindControl("id_actividad_archivo"))).Text);
        ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);

        byte[] Contenido;
        string extension = string.Empty;

        try
        {
            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                FileStream Archivo = new FileStream(System.Configuration.ConfigurationManager.AppSettings["Archivos"] + Convert.ToString(ds.Tables[0].Rows[0]["URL_ARCHIVO"]), FileMode.Open, FileAccess.Read);
                extension = (Convert.ToString(ds.Tables[0].Rows[0]["EXTENSION"]));

                Contenido = new byte[Archivo.Length];
                Archivo.Read(Contenido, 0, (int)Archivo.Length);
                Response.ClearContent(); //Borra todo el contenido del buffer
                Response.ClearHeaders(); //Borra todos los encabezados
                Response.Buffer = true;
                Response.ContentType = extension; //Se establece el tipo MIME
                Response.AddHeader("content-disposition", "attachment; filename=" + Convert.ToString(ds.Tables[0].Rows[0]["NOMBRE_ARCHIVO"]) + extension);
                Response.BinaryWrite(Contenido); //Escribe datos binarios en el flujo de salida HTTP y por tanto, se muestra o descarga el archivo
                Archivo.Close();
                Contenido = null;
                Response.End();
            }
            else
            {
                Mensajes("El archivo se encuentra en blanco!.", 0);
            }
        }
        catch
        {
            Mensajes("Error al leer el archivo!.", 0);
        }
    }


    protected void gv16_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String Estado = gv.Rows[0].Cells[4].Text;
            Boolean Edicion = false;

            if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToString(Session["rol"]) == "37" || Convert.ToString(Session["rol"]) == "145")
            {
                Edicion = true;
                btn_guardar_documentos.Visible = true;
                e.Row.FindControl("LD_Cambiar_accion").Visible = true;
                e.Row.FindControl("check_box").Visible = true;
            }

            //validación del estado de la actividad y roles
            //if (Estado == "ACTIVO")
            //{
            //    if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))
            //    {
            //        if (Convert.ToInt32(Session["rol"]) == 1)
            //        {
            //            //e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
            //        }
            //        else
            //        {
            //            e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
            //        }

            //        e.Row.FindControl("estado_doc").Visible = true;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = false;
            //    }
            //    else
            //    {
            //        e.Row.FindControl("estado_doc").Visible = false;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = true;
            //        //e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
            //    }
            //}
            //else
            //{
            //    if (Convert.ToInt32(Session["rol"]) == 1)
            //    {
            //        e.Row.FindControl("estado_doc").Visible = true;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = false;
            //        //e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
            //    }
            //    else
            //    {
            //        e.Row.FindControl("estado_doc").Visible = false;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = true;
            //        e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
            //    }
            //}

            //validación de los estados de los documentos con sus estilos

            if (((Label)e.Row.FindControl("id_actividad_archivo_estado")).Text == "1")
            {
                e.Row.FindControl("estado_doc").Visible = false;
                e.Row.FindControl("LB_EstadoDoc").Visible = true;
                e.Row.FindControl("Docu_pendiente").Visible = true;
                e.Row.FindControl("btn_actualizar_archivo").Visible = true;
                e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
                if (Edicion)
                {
                    e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
                    e.Row.FindControl("btn_actualizar_archivo").Visible = false;
                }

            }
            else if (((Label)e.Row.FindControl("id_actividad_archivo_estado")).Text == "2")
            {


                ((LinkButton)e.Row.FindControl("Aprobado")).CssClass = "btn btn-default";
                ((LinkButton)e.Row.FindControl("Denegado")).CssClass = "btn btn-default";

                e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
                e.Row.FindControl("btn_actualizar_archivo").Visible = false;
                if (Edicion)
                {
                    e.Row.FindControl("estado_doc").Visible = true;
                    e.Row.FindControl("Docu_pendiente").Visible = false;
                }
                else
                {
                    e.Row.FindControl("estado_doc").Visible = false;
                    e.Row.FindControl("Docu_pendiente").Visible = true;
                }


            }
            else if (((Label)e.Row.FindControl("id_actividad_archivo_estado")).Text == "3")
            {
                //e.Row.FindControl("estado_doc").Visible = true;
                ((LinkButton)e.Row.FindControl("Aprobado")).CssClass = "btn btn-success disabled";
                ((LinkButton)e.Row.FindControl("Denegado")).CssClass = "btn btn-default";

                e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
                e.Row.FindControl("btn_actualizar_archivo").Visible = false;

                if (Edicion)
                {
                    e.Row.FindControl("estado_doc").Visible = true;
                }
                else
                {
                    e.Row.FindControl("estado_doc").Visible = false;
                    e.Row.FindControl("Docu_aprobado").Visible = true;
                }

            }
            else if (((Label)e.Row.FindControl("id_actividad_archivo_estado")).Text == "4")
            {
                //e.Row.FindControl("estado_doc").Visible = true;
                ((LinkButton)e.Row.FindControl("Aprobado")).CssClass = "btn btn-default";
                ((LinkButton)e.Row.FindControl("Denegado")).CssClass = "btn btn-danger disabled";


                //e.Row.FindControl("LB_EstadoDoc").Visible = false;

                if (Edicion)
                {
                    e.Row.FindControl("estado_doc").Visible = true;
                }
                else
                {
                    e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
                    e.Row.FindControl("btn_actualizar_archivo").Visible = true;
                    e.Row.FindControl("Docu_NoAprobado").Visible = true;
                }



            }
            else if (((Label)e.Row.FindControl("id_actividad_archivo_estado")).Text == "5")
            {
                e.Row.FindControl("estado_doc").Visible = false;
                //((LinkButton)e.Row.FindControl("Aprobado")).CssClass = "btn btn-success disabled";
                //((LinkButton)e.Row.FindControl("Denegado")).CssClass = "btn btn-default disabled";
                //((LinkButton)e.Row.FindControl("Aprobado")).CommandName = "disabled";
                //((LinkButton)e.Row.FindControl("Denegado")).CommandName = "disabled";
                e.Row.FindControl("LB_EstadoDoc").Visible = true;
                e.Row.FindControl("Docu_aprobado").Visible = true;


                if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToString(Session["rol"]) == "37" || Convert.ToString(Session["rol"]) == "145")
                {
                    e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
                    e.Row.FindControl("btn_actualizar_archivo").Visible = true;
                }
                else
                {
                    e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
                    e.Row.FindControl("btn_actualizar_archivo").Visible = false;
                }

            }
            //else
            //{
            //    e.Row.FindControl("estado_doc").Visible = false;
            //    ((Label)e.Row.FindControl("LB_EstadoDoc")).Text = "indefinido";
            //    e.Row.FindControl("LB_EstadoDoc").Visible = true;
            //}

            //if (((Label)e.Row.FindControl("id_actividad_dia_estado")).Text == "4")
            //{
            //    if (Convert.ToInt32(Session["rol"]) != 1)
            //    {
            //        e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
            //    }
            //}


            ((DropDownList)e.Row.FindControl("LD_Cambiar_accion")).SelectedValue = ((Label)e.Row.FindControl("ID_ACTIVIDAD_DIA")).Text;



        }
    }

    // permite limpiar los campos de captura de los archivos
    protected void limpiar_archivo_Click(object sender, EventArgs e)
    {
        LD_tipo_archivo.SelectedValue = "0";
        L_D_dia_actividad_documentos.SelectedValue = "0";
        gv16.Visible = false;
        gv16.DataSource = null;
        gv16.DataBind();
    }


    protected void LD_tipo_archivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        TabName.Value = "Dias";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
    }


    #endregion

    #region Detalle

    protected void B_guardar_detalle_Click(object sender, EventArgs e)
    {
        Crear_actividad_detalle(1);
        UP_Detalle.Update();
    }

    protected void B_actualizar_detalle_Click(object sender, EventArgs e)
    {
        Crear_actividad_detalle(2);
        B_CancelaDetalle.Visible = false;
        UP_Detalle.Update();
    }

    protected void B_CancelaDetalle_Click(object sender, EventArgs e)
    {

        gv11.DataSource = ViewState["actividad_detalle"];
        gv11.DataBind();

        B_guardar_detalle.Visible = true;
        B_CancelaDetalle.Visible = false;
        B_actualizar_detalle.Visible = false;
        TB_actividad_detalle.Text = "";
        LD_tipo_actividad.SelectedValue = "0";
        LD_tipo_actividad.Enabled = true;
        LD_estado_detalle.SelectedValue = "0";

        UP_Detalle.Update();
    }

    #endregion

    #endregion

    #endregion



    #region BOTONES

    //boton para validar eliminaciones y mensajes informativos
    protected void B_Confirmacion_accion_Click(object sender, EventArgs e)
    {
        try
        {
            if (CB_Valida_accion.Checked == true)
            {
                //colocar las acciones a realizar
                if (L_Validacion.Text == "Elimina_responsable")
                {
                    B_Confirmacion_accion.Visible = false;
                    CB_Valida_accion.Visible = false;
                    TabName.Value = "Responsables";
                    UP_Responsable.Update();
                }
                else if (L_Validacion.Text == "Eliminar_acciones")
                {
                    consulta_dias_actividad(2);
                    UP_Dias.Update();
                }
                else if (L_Validacion.Text == "EliminaGrid_archivo")
                {
                    EliminaGrid_archivo(L_V1.Text);
                    UP_Archivos.Update();
                }

                else if (L_Validacion.Text == "Aprobar_dia_actividad")
                {
                    Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
                    Actividad_dia actividad_dia = new Actividad_dia();
                    Persona persona = new Persona();
                    DataSet ds = new DataSet();

                    adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(L_V1.Text);
                    actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(L_V1.Text);
                    adjuntar_archivos.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

                    //validacion de documentos obligatorios que faltan
                    ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 3);

                    if (!ds.Tables[0].Rows.Count.Equals(0))
                    {
                        texto("Ups!!! No se puede cambiar el estado del día, ya que faltan documentos obligatorios por cargar:", 3);

                        //recorro los documentos faltantes del dia
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            texto(Convert.ToString(ds.Tables[0].Rows[j]["TIPO_ACTIVIDAD_ARCHIVO"]) + " (" + Convert.ToString(ds.Tables[0].Rows[j]["FECHA_EXPEDICION"]) + "), ", 2);
                        }

                        Mensajes_2("Documentos requeridos.", this.L_mensaje.Text, 2);
                    }
                    else
                    {
                        //validacion del estado de los documentos cargados
                        ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 4);

                        if (!ds.Tables[0].Rows.Count.Equals(0))
                        {
                            texto("Ups!!! No se puede cambiar el estado del día, ya que los documentos actualmente cargados estan pendientes por aprobación!.", 3);

                            //recorro los estados de los documentos cargados
                            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                            {
                                texto(Convert.ToString(ds.Tables[0].Rows[j]["TIPO_ACTIVIDAD_ARCHIVO"]) + " --> " + Convert.ToString(ds.Tables[0].Rows[j]["ACTIVIDAD_ARCHIVO_ESTADO"]) + ", ", 2);
                            }

                            Mensajes_2("Documentos sin aprobación.", this.L_mensaje.Text, 2);
                        }
                        else
                        {
                            //valida que el dia tenga como minimo 1 persona asociada con tipo material "asistencia a evento"
                            ds = FachadaPersistencia.getInstancia().consultar_persona_actividad(actividad_dia, persona, 9);

                            if (!ds.Tables[0].Rows.Count.Equals(0))
                            {
                                if (Convert.ToInt32(ds.Tables[0].Rows[0]["ASISTENCIA"]) != Convert.ToInt32(ds.Tables[0].Rows[0]["GESTION"]))
                                {
                                    texto("No se puede cambiar el estado del día, ya que no cumple con la cantidad de personas establecidas en el campo de gestión efectiva: " +
                                                Convert.ToString(ds.Tables[0].Rows[0]["GESTION"]) + " y tiene asociadas con \"Asistencia a evento\": " + Convert.ToString(ds.Tables[0].Rows[0]["ASISTENCIA"]) + ".", 3);
                                    Mensajes_2("Validación de personas asociadas al día.", this.L_mensaje.Text, 2);
                                }
                                else
                                {
                                    Actualiza_dias_actividad(2);
                                    //CargaGrid_archivo();
                                    UP_Archivos.Update();
                                }
                            }
                            else
                            {
                                texto("Error al consultar las personas asociadas al día!.", 3);
                            }
                        }
                    }

                    UP_Dias.Update();
                }
                else if (L_Validacion.Text == "Por_Aprobar_dia_actividad")
                {
                    Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
                    Actividad_dia actividad_dia = new Actividad_dia();
                    Persona persona = new Persona();
                    DataSet ds = new DataSet();

                    adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(L_V1.Text);
                    adjuntar_archivos.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
                    actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(L_V1.Text);
                    actividad_dia.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

                    //validación de documentos obligatorios que faltan
                    ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 3);

                    if (!ds.Tables[0].Rows.Count.Equals(0))
                    {
                        texto("Ups!!! No se puede cambiar el estado del día, ya que faltan documentos obligatorios por cargar:", 3);

                        //recorro los documentos faltantes del dia
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            texto(Convert.ToString(ds.Tables[0].Rows[j]["TIPO_ACTIVIDAD_ARCHIVO"]) + " (" + Convert.ToString(ds.Tables[0].Rows[j]["FECHA_EXPEDICION"]) + "), ", 2);
                        }

                        Mensajes_2("Documentos requeridos.", this.L_mensaje.Text, 2);
                    }
                    else
                    {
                        //valida que el dia tenga como minimo 1 persona asociada con tipo material "asistencia a evento"
                        ds = FachadaPersistencia.getInstancia().consultar_persona_actividad(actividad_dia, persona, 9);

                        if (!ds.Tables[0].Rows.Count.Equals(0))
                        {
                            if (Convert.ToInt32(ds.Tables[0].Rows[0]["ASISTENCIA"]) != Convert.ToInt32(ds.Tables[0].Rows[0]["GESTION"]))
                            {
                                texto("No se puede cambiar el estado del día, ya que no cumple con la cantidad de personas establecidas en el campo de gestión efectiva: " +
                                            Convert.ToString(ds.Tables[0].Rows[0]["GESTION"]) + " y tiene asociadas con \"Asistencia a evento\": " + Convert.ToString(ds.Tables[0].Rows[0]["ASISTENCIA"]) + ".", 3);
                                Mensajes_2("Validación de personas asociadas al día.", this.L_mensaje.Text, 2);
                            }
                            else
                            {
                                Actualiza_dias_actividad(4);
                                LD_Dia_actividad(Convert.ToInt32(ViewState["id_actividad"]));
                                UP_Archivos.Update();
                            }
                        }
                        else
                        {
                            texto("Error al consultar las personas asociadas al día!.", 3);
                        }
                    }
                }

                else if (L_Validacion.Text == "Fase_Activa")
                {
                    AdministraFases(2); //cambia la fase a Activo
                    L_Validacion.Text = "";
                }
                else if (L_Validacion.Text == "Fase_Inactiva")
                {
                    AdministraFases(1); //cambia la fase a aprobado 
                    L_Validacion.Text = "";
                }
                else if (L_Validacion.Text == "Cambio_fase")
                {
                    gv.DataSource = null;
                    gv.DataBind();
                    gv_actividad.DataSource = null;
                    gv_actividad.DataBind();

                    Crear(4); //cambia la fase del sujeto 
                    ConsultaFases();

                    UP_DatosSujetos.Update();
                    UP_ResultadoBusqueda.Update();
                    L_V1.Text = "";
                    L_Validacion.Text = "";
                }


                valida_permisos_rol();
            }
            else
            {
                CB_Valida_accion.Text = "<span class='text-danger'>Por favor valide la acción</span>";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            }

        }
        catch
        {
            texto("Error al confirmar la acción, por favor intente más tarde.", 3);
            Mensajes_2("", this.L_mensaje.Text, 3);
        }

    }



    //----------------------------------------

    protected void valida_permisos_rol()
    {

        int cant = 0;
        int valida = 0;
        ViewState["id_responsable"] = 0;
        gv_actividad.Columns[13].Visible = false;
        gv16.Columns[15].Visible = false;
        gv16.Columns[16].Visible = false;


        cant = GlobalVariables.id_usuario_territorioA.Length;

        for (int i = 0; i < cant; i++)
        {
            if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
            {
                ViewState["id_responsable"] = Convert.ToInt32(Session["id_usuario"]);
                m_2.Visible = false;
                m_PlanTraslado.Visible = false;
                m_Balance.Visible = false;

                Responsables.Visible = false;
                plan_traslado.Visible = false;
                //Responsables.CssClass = "tab-pane";
                //Dias.CssClass = "tab-pane active";
                Dias.Attributes.Add("class", "tab-pane active");
                //this.id_usuario_territorio = 

                this.id_usuario_territorio.Value = Convert.ToString(Session["rol"]);
                Panel252.Visible = true;

                valida++;
            }
        }

        cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

        for (int i = 0; i < cant; i++)
        {
            if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
            {
                ViewState["id_responsable"] = Convert.ToInt32(Session["id_usuario"]);
                m_2.Visible = false;
                m_PlanTraslado.Visible = false;
                m_Balance.Visible = false;
                Responsables.Visible = false;
                plan_traslado.Visible = false;
                //Responsables.CssClass = "tab-pane";
                //Dias.CssClass = "tab-pane active";
                Dias.Attributes.Add("class", "tab-pane active");
                Panel252.Visible = true;
                this.id_usuario_2da_instancia.Value = Convert.ToString(Session["rol"]);
                valida++;
            }
        }

        if (Convert.ToInt32(Session["rol"]) == 41) //usuario de cunsulta colectiva
        {

            Panel244.Visible = false;
            Panel252.Visible = false;
            Panel242.Visible = false;
            gv12.Columns[14].Visible = false;
            //Responsables.CssClass = "tab-pane active";
            valida++;
            P_GurdarCostos.Visible = false;

            Panel252.Visible = false;
            gv16.Columns[3].Visible = true;
            gv16.Columns[4].Visible = true;
            gv16.Columns[10].Visible = false;
            gv16.Columns[11].Visible = false;
            gv16.Columns[12].Visible = false;
            gv16.Columns[13].Visible = false;
            gv16.Columns[14].Visible = false;
            gv11.Columns[6].Visible = false;

            m_2.Visible = false;
            m_PlanTraslado.Visible = false;
            m_Balance.Visible = false;

            if (gv16.Rows.Count > 0)
            {
                foreach (GridViewRow row in gv16.Rows)
                {
                    row.FindControl("ibtnGEliminar_archivo").Visible = false;
                }
            }
        }
        else if (Convert.ToInt32(Session["rol"]) == 37 || Convert.ToString(Session["rol"]) == "145") //usuario administrador colectiva
        {
            //Responsables.CssClass = "tab-pane active";
            Btn_agregar_actividad_colectiva.Visible = true;
            gv_actividad.Columns[13].Visible = true;
            gv16.Columns[15].Visible = true;
            gv16.Columns[16].Visible = true;
            Panel252.Visible = true;
            valida++;
        }
        else if (Convert.ToInt32(Session["rol"]) == 1) //administrador cys
        {
            gv_actividad.Columns[13].Visible = true;
            gv16.Columns[15].Visible = true;
            gv16.Columns[16].Visible = true;
            Panel252.Visible = true;

            Btn_agregar_actividad_colectiva.Visible = true;
            valida++;
        }

        if (valida == 0)
        {
            buscar.Visible = false;
            limpiar.Visible = false;
            texto("El rol actual no tiene permisos para verificar la información de este módulo.", 2); Mensajes_2("", this.L_mensaje.Text, 2);

        }


        if (gv16.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["consulta_archivos"]) == "1" || Convert.ToString(ViewState["consulta_archivos"]) == "2")
            {
                Panel252.Visible = false;
                gv16.Columns[3].Visible = true;
                gv16.Columns[4].Visible = true;
                gv16.Columns[10].Visible = false;
                gv16.Columns[11].Visible = false;
                gv16.Columns[12].Visible = false;
                gv16.Columns[13].Visible = false;
                gv16.Columns[14].Visible = false;
                if (gv16.Rows.Count > 0)
                {
                    foreach (GridViewRow row in gv16.Rows)
                    {
                        row.FindControl("ibtnGEliminar_archivo").Visible = false;

                    }
                }
            }

        }


        if (Convert.ToInt32(ViewState["id_actividad_estado"]) == 4)
        {
            Panel244.Visible = false;
            Panel252.Visible = false;
            Panel242.Visible = false;
            gv12.Columns[14].Visible = false;
            //Responsables.CssClass = "tab-pane active";
            valida++;
            P_GurdarCostos.Visible = false;

            Panel252.Visible = false;
            gv16.Columns[3].Visible = true;
            gv16.Columns[4].Visible = true;
            gv16.Columns[10].Visible = false;
            gv16.Columns[11].Visible = false;
            gv16.Columns[12].Visible = false;
            gv16.Columns[13].Visible = false;
            gv16.Columns[14].Visible = false;
            if (gv16.Rows.Count > 0)
            {
                foreach (GridViewRow row in gv16.Rows)
                {
                    row.FindControl("ibtnGEliminar_archivo").Visible = false;

                }
            }

        }

        gv_visual();
        gv16_visual();
        UP_DatosEvento.Update();
        UP_Responsable.Update();
        Up_plan_traslado.Update();
        UP_Dias.Update();
        UP_Archivos.Update();
        UP_Detalle.Update();
        UP_Costos.Update();
        UP_DatosSujetos.Update();
        UP_ResultadoBusqueda.Update();
        UP_DatosEvento.Update();
    }

    protected void B_CancelarDia_Click(object sender, EventArgs e)
    {
        gv5.DataSource = ViewState["ds_dias_actividad"]; //setea el color de la grilla a defautl(sin selección)
        gv5.DataBind();

        //L_D_Estado_dia();



        for (int i = 0; i < gv5.Rows.Count; i++)
        {
            //((DropDownList)gv5.Rows[i].Cells[0].FindControl("LD_Estado_dia")).SelectedValue = Convert.ToString(((DataSet)ViewState["ds_dias_actividad"]).Tables[0].Rows[i]["ID_ACTIVIDAD_DIA_ESTADO"]);
            //((Literal)gv5.Rows[i].FindControl("LI_Estado_dia")).Text = Convert.ToString(((DataSet)ViewState["ds_dias_actividad"]).Tables[0].Rows[i]["ACTIVIDAD_DIA_ESTADO"]);

        }

        LD_Encuentro.SelectedValue = "0";

        LD_tipo_actividad.SelectedValue = "0";
        TB_actividad_detalle.Text = "";


        TB_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        TB_HoraInicio.Text = "08:00 AM";
        TB_HoraFin.Text = "05:00 PM";
        TB_Direccion_lugar.Text = "";
        TB_Proyeccion.Text = "";
        TB_Gestion.Text = "";
        LD_DepartamentoDia.SelectedValue = "0";
        LD_Departamento_Dia();
        guardar_dias.Visible = true;
        B_ActualizarDia.Visible = false;
        B_CancelarDia.Visible = false;
        LD_Encuentro.SelectedValue = "0";
        TB_Proyeccion.Text = "0";
        TB_Gestion.Text = "0";
    }



    // permite utilizar el evento de eliminar las acciones aplicadas a una persona
    protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar_acciones")
        {
            GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

            L_V2.Text = Convert.ToString(((Label)gvRow.FindControl("id_actividad_material")).Text);
            L_V1.Text = Convert.ToString(((Label)gvRow.FindControl("id_persona")).Text);
            L_Validacion.Text = "Eliminar_acciones";
            texto("Por favor confirme la eliminación de este registro", 2); Mensajes_2("", this.L_mensaje.Text, 4);
        }
    }



    protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((Label)e.Row.FindControl("id_actividad_dia_estado")).Text == "2")
            {
                if (Convert.ToInt32(Session["rol"]) != 1)
                {
                    ((ImageButton)e.Row.FindControl("ibtnGEliminar")).Visible = false;
                    ((Label)e.Row.FindControl("Val_DiaAprobadoP")).Visible = true;
                }
            }
            else if (((Label)e.Row.FindControl("id_actividad_dia_estado")).Text == "4")
            {
                if (Convert.ToInt32(Session["rol"]) != 1)
                {
                    ((ImageButton)e.Row.FindControl("ibtnGEliminar")).Visible = false;
                    ((Label)e.Row.FindControl("MaterialP_Pendiente")).Visible = true;
                }
            }
        }
    }



    protected void B_CambiarEstado_Click(object sender, EventArgs e)
    {
        try
        {
            int valida = 0;

            if (Vari1.Text == "Cambiar_estado")
            {
                if (GV_Solicitudes.Visible)
                {
                    foreach (GridViewRow fila in GV_Solicitudes.Rows)
                    {
                        if (((CheckBox)fila.FindControl("C_Solicitud")).Checked)
                        {
                            valida++;
                        }
                    }
                }
                else
                {
                    valida++;
                }

                if (valida > 0)
                {
                    if (BalidaCambioEstadoDoc(2) || Convert.ToString(ViewState["dia_actividad_estado"]).ToUpper() == Convert.ToString(LD_Estado_dia.SelectedItem).ToUpper()) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                    {
                        this.L_mensaje.Text = "";
                        Crear_actividad_detalle(6);
                        Actualiza_dias_actividad(6);
                        consulta_dias_actividad(10);
                        Vari1.Text = "";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal('hide');", true);
                    }

                }
                else
                {
                    texto("Por favor seleccione las solicitudes validadas al cambiar este estado. ", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                    P_Solicitudes.CssClass = "row panel panel-danger panel-heading";
                }


            }
            else if (Vari1.Text == "Solicitud_cambio_estado")
            {
                //Actualiza_dias_actividad(6);

                if (BalidaCambioEstadoDoc(1)) // valida que el territorio no tenga documentos en estado "no aprobado"
                {
                    Crear_actividad_detalle(5);
                    consulta_dias_actividad(9);
                    Vari1.Text = "";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal('hide');", true);
                }
            }
        }
        catch
        {
            texto("Error al intentar cambiar el estado de las actividades. Por favor intente nuevamente", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }


    }

    protected void LD_DepArchivo_SelectedIndexChanged(object sender, EventArgs e)
    {

        L_D_MunArchivo();

    }



    protected void LD_subCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Solicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ((Label)e.Row.FindControl("L_EstadoActual")).Text = Convert.ToString(ViewState["dia_actividad_estado"]);

        }


    }

    protected void LD_medida_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(LD_medida.SelectedValue) == 0)
        {
            LD_medida_2.Items.Clear();
            LD_tipo_archivo.Items.Clear();

        }
        else if (Convert.ToInt32(LD_medida.SelectedValue) <= 8)
        {
            LD_medida_2.Items.Clear();
            LD_medida_2.Items.Insert(0, new ListItem("Selecione componente"));
            LD_medida_2.Items.Insert(1, new ListItem("Formación del componente"));
            LD_medida_2.Items.Insert(2, new ListItem("Acción con acompañamiento del profesional psicosocial"));
            LD_medida_2.Items.Insert(3, new ListItem("Acción sin el acompañamiento del profesional psicosocial"));
            LD_tipo_archivo.Items.Clear();

        }
        else if (Convert.ToInt32(LD_medida.SelectedValue) == 9)
        {
            LD_medida_2.Items.Clear();
            LD_medida_2.Items.Insert(0, new ListItem("Selecione componente"));
            LD_medida_2.Items.Insert(1, new ListItem("Dialogos con tejedores y tejedoras o referentes de ciudado"));
            LD_medida_2.Items.Insert(2, new ListItem("Dialogos con la comunidad"));
            LD_medida_2.Items.Insert(3, new ListItem("Acto simbólico"));
            LD_tipo_archivo.Items.Clear();
        }
        else if (Convert.ToInt32(LD_medida.SelectedValue) == 10)
        {
            LD_medida_2.Items.Clear();
            LD_medida_2.Items.Insert(0, new ListItem("Selecione componente"));
            LD_medida_2.Items.Insert(1, new ListItem("Informe de cierre"));
            LD_tipo_archivo.Items.Clear();

        }
        else if (Convert.ToInt32(LD_medida.SelectedValue) > 10)
        {
            LD_tipo_archivo.Items.Clear();
            LD_tipo_archivo.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
            LD_tipo_archivo.Items.Insert(1, new ListItem("AL-INFORME DETALLADO", "448"));
            LD_tipo_archivo.Items.Insert(2, new ListItem("AL-LISTADOS DE ASISTENCIA", "451"));
            LD_tipo_archivo.Items.Insert(3, new ListItem("AL-REGISTRO FOTOGRAFICO", "975"));
            if (LD_medida.SelectedValue.Equals("11"))
            {
                LD_tipo_archivo.Items.Insert(4, new ListItem("AL-MATRIZ IDENTIFICACIÓN TYT", "867"));
                LD_tipo_archivo.Items.Insert(5, new ListItem("EN-AL-ACTA DE RECONOCIMIENTO DE TEJEDORES Y TEJEDORAS", "909"));
            }
            if (LD_medida.SelectedValue.Equals("15"))
            {
                LD_tipo_archivo.Items.Clear();
                LD_tipo_archivo.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
                LD_tipo_archivo.Items.Insert(1, new ListItem("AL-INFORME DE CIERRE DE LA FASE", "903"));
            }
        }


    }

    protected void LD_medida_2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if ((Convert.ToInt32(LD_medida.SelectedValue) > 0 && Convert.ToInt32(LD_medida.SelectedValue) < 6))
        //{
        //    if ((Convert.ToInt32(LD_medida_2.SelectedValue) > 0 && Convert.ToInt32(LD_medida_2.SelectedValue) < 3))
        //    {

        //        LD_tipo_archivo.Items.Clear();
        //        LD_tipo_archivo.Items.Insert(0, new ListItem("Selecione medida"));
        //        LD_tipo_archivo.Items.Insert(1, new ListItem("Formación del componente"));
        //        LD_tipo_archivo.Items.Insert(2, new ListItem("Acción con acompañamiento del profesional psicosocial"));
        //        LD_tipo_archivo.Items.Insert(3, new ListItem("Acción sin el acompañamiento del profesional psicosocial"));
        //    }
        //    else
        //    {

        //    }
        //}
        //else
        //{

        //}
        if (RB_Tipo_actividad.SelectedValue == "Entrelazando")
        {
            LD_tipo_archivo.Items.Clear();
            LD_tipo_archivo.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
            LD_tipo_archivo.Items.Insert(1, new ListItem("IM-INFORME DETALLADO", "523"));
            LD_tipo_archivo.Items.Insert(2, new ListItem("IM-REGISTRO FOTOGRAFICO", "869"));
            LD_tipo_archivo.Items.Insert(3, new ListItem("IM-LISTADOS DE ASISTENCIA", "591"));
        }
        if (LD_medida_2.SelectedItem.ToString().Equals("Acción sin el acompañamiento del profesional psicosocial"))
        {
            LD_tipo_archivo.Items.Insert(4, new ListItem("IM-GUIA DE MEMORIA", "977"));
        }
        else if (Convert.ToInt32(LD_medida.SelectedValue) == 10)
        {
            if (LD_medida_2.SelectedItem.ToString().Equals("Informe de cierre"))
            {
                LD_tipo_archivo.Items.Clear();
                LD_tipo_archivo.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
                LD_tipo_archivo.Items.Insert(1, new ListItem("IM-ACTA DE CIERRE PIRC", "583"));
                LD_tipo_archivo.Items.Insert(1, new ListItem("IM-ACTA DE IMPLEMENTACION DE MEDIDAS", "918"));
            }
        }



    }

    protected void repActividadesProd_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ScriptManager scriptMan = ScriptManager.GetCurrent(this);

            TextBox txtAnno1ActProd = (TextBox)e.Item.FindControl("txtAnno1ActProd");
            TextBox txtAnno2ActProd = (TextBox)e.Item.FindControl("txtAnno2ActProd");
            TextBox txtAnno3ActProd = (TextBox)e.Item.FindControl("txtAnno3ActProd");

            scriptMan.RegisterAsyncPostBackControl(txtAnno1ActProd);
            scriptMan.RegisterAsyncPostBackControl(txtAnno2ActProd);
            scriptMan.RegisterAsyncPostBackControl(txtAnno3ActProd);
        }
    }

    protected void repProdsCV_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ScriptManager scriptMan = ScriptManager.GetCurrent(this);

            Repeater repActividadesProd = (Repeater)e.Item.FindControl("repActividadesProd");

            scriptMan.RegisterAsyncPostBackControl(repActividadesProd);
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object ObtenerDatosPDF(int idSujeto)
    {

        DataSet dsED = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "EFECTO DIRECTO");
        DataSet dsEID = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "EFECTO INDIRECTO");
        DataSet dsFD = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "FIN DIRECTO");
        DataSet dsFI = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "FIN INDIRECTO");

        DataSet dsCD = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "CATEGORIA DANO");
        DataSet dsSCD = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "SUBCATEGORIA DANO");
        DataSet dsCI = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "CAUSA INDIRECTA");
        DataSet dsOD = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "OBJETIVO DIRECTO");
        DataSet dsOI = FachadaPersistencia.getInstancia().ListaParametrosPIRC(idSujeto, "OBJETIVO INDIRECTO");

        DataSet dsBene = FachadaPersistencia.getInstancia().ObtenerBeneficiosPIRC(idSujeto);

        DataSet dsCV = FachadaPersistencia.getInstancia().ObtenerDatosAtributosPIRC(idSujeto);

        DataSet dsInvol = FachadaPersistencia.getInstancia().ObtenerInvolucradosPIRC(idSujeto);
        DataSet dsInvolC = FachadaPersistencia.getInstancia().ObtenerInvolucradosConcertacionPIRC(idSujeto);

        DataSet dsRiesgoObj = FachadaPersistencia.getInstancia().ObtenerRiesgosObjGralPIRC(idSujeto);
        DataSet dsRiesgoProd = FachadaPersistencia.getInstancia().ObtenerRiesgosProductosPIRC(idSujeto);
        DataSet dsRiesgoActs = FachadaPersistencia.getInstancia().ObtenerRiesgosActividadesPIRC(idSujeto);

        DataSet dsSeguimientoProds = FachadaPersistencia.getInstancia().ObtenerIndicadoresSeguimientoProductosPIRC(idSujeto);
        DataSet dsSeguimientoActs = FachadaPersistencia.getInstancia().ObtenerIndicadoresSeguimientoActividadesPIRC(idSujeto);

        DataSet dsSeguimientoCrono = FachadaPersistencia.getInstancia().ObtenerCronogramaTareasActividadesPIRC(idSujeto);

        DataSet dsMatrizResumen = FachadaPersistencia.getInstancia().ObtenerResumenProductosPIRC(idSujeto);
        DataSet dsMatrizResumenActs = FachadaPersistencia.getInstancia().ObtenerResumenActividadesPIRC(idSujeto);

        DataSet dsDatosPDFPIRC = FachadaPersistencia.getInstancia().ObtenerDatosPDFPIRC(idSujeto);

        DataSet dsDatosSujeto = FachadaPersistencia.getInstancia().ObtenerDatosSujetoPIRC(idSujeto);

        List<ArbolProblemaED> lstDS = new List<ArbolProblemaED>();
        List<ArbolProblemaFD> lstFD = new List<ArbolProblemaFD>();
        List<ArbolProblemaCD> lstCD = new List<ArbolProblemaCD>();
        List<ArbolProblemaOED> lstOED = new List<ArbolProblemaOED>();

        List<DatosPDFPIRC> lstDatosPDF = new List<DatosPDFPIRC>();
        DatosPDFPoblacion datosPob = new DatosPDFPoblacion();
        List<InstrumentosInvolucrados> lstInvol = new List<InstrumentosInvolucrados>();
        List<InstrumentosCadenaValor> lstCV = new List<InstrumentosCadenaValor>();

        List<InstrumentosRiesgos> lstRiesgoObj = new List<InstrumentosRiesgos>();
        List<InstrumentosRiesgoProductos> lstRiesgoProd = new List<InstrumentosRiesgoProductos>();
        List<InstrumentosRiesgoActividades> lstRiesgoActs = new List<InstrumentosRiesgoActividades>();

        List<InstrumentosBeneficios> lstBeneficios = new List<InstrumentosBeneficios>();

        List<InstrumentosProductoSeguimiento> lstSegProd = new List<InstrumentosProductoSeguimiento>();
        List<InstrumentosActividadesSeguimiento> lstSegActs = new List<InstrumentosActividadesSeguimiento>();

        List<InstrumentosCronogramaAtributos> lstCronograma = new List<InstrumentosCronogramaAtributos>();

        List<InstrumentosResumenAtributos> lstResumen = new List<InstrumentosResumenAtributos>();

        int metaTotalPIRC = 0;

        decimal totalPIRC = decimal.Zero;
        string totPIRC = "";

        string nomSujeto = dsDatosSujeto.Tables[0].Rows[0][0].ToString();
        string tipoSujeto = dsDatosSujeto.Tables[0].Rows[0][1].ToString();
        string territorialSujeto = dsDatosSujeto.Tables[0].Rows[0][2].ToString();
        string deptoSujeto = dsDatosSujeto.Tables[0].Rows[0][3].ToString();
        string mpioSujeto = dsDatosSujeto.Tables[0].Rows[0][4].ToString();

        #region Efectos Directos e Indirectos
        if (dsED.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsED.Tables[0].Rows.Count; i++)
            {
                int idEfectoDirecto = int.Parse(dsED.Tables[0].Rows[i][0].ToString());
                string efectoDirecto = dsED.Tables[0].Rows[i][1].ToString();

                ArbolProblemaED aped = new ArbolProblemaED();
                aped.IdEfectoDirecto = idEfectoDirecto;
                aped.EfectoDirecto = efectoDirecto;

                ArbolProblemaFD aofd = new ArbolProblemaFD();
                aofd.IdEfectoDirecto = idEfectoDirecto;
                aofd.EfectoDirecto = efectoDirecto;

                string tableName = "MGA.FIN_DIRECTO";
                string tableNameMain = "MGA.EFECTO_DIRECTO";

                DataSet dsCausas = FachadaPersistencia.getInstancia().ListaValoresParametroTablaId(tableName, tableNameMain, idEfectoDirecto);

                if (dsCausas.Tables[0].Rows.Count != 0)
                {
                    aofd.IdFinDirecto = int.Parse(dsCausas.Tables[0].Rows[0][0].ToString());
                    aofd.FinDirecto = dsCausas.Tables[0].Rows[0][1].ToString();
                }

                #region Fines y efectos indirectos

                if (dsEID.Tables[0].Rows.Count != 0)
                {
                    for (int j = 0; j < dsEID.Tables[0].Rows.Count; j++)
                    {
                        int idEfectoDirIndir = int.Parse(dsEID.Tables[0].Rows[j][2].ToString());

                        if (idEfectoDirIndir == idEfectoDirecto)
                        {
                            ArbolProblemaEID eid = new ArbolProblemaEID();
                            ArbolProblemaFID aofid = new ArbolProblemaFID();

                            eid.IdEfectoIndirecto = int.Parse(dsEID.Tables[0].Rows[j][0].ToString());
                            eid.EfectoIndirecto = dsEID.Tables[0].Rows[j][1].ToString();

                            //Fin indirecto
                            tableName = "MGA.FIN_INDIRECTO";
                            tableNameMain = "MGA.EFECTO_INDIRECTO";

                            dsCausas = FachadaPersistencia.getInstancia().ListaValoresParametroTablaId(tableName, tableNameMain, eid.IdEfectoIndirecto);

                            if (aofd.FinesIndirectos.Count > 0)
                            {
                                if (aofd.FinesIndirectos.Find(x => x.IdEfectoIndirecto == eid.IdEfectoIndirecto) != null)
                                {
                                    aofid = aofd.FinesIndirectos.Find(x => x.IdEfectoIndirecto == eid.IdEfectoIndirecto);
                                }
                            }

                            if (dsCausas.Tables[0].Rows.Count != 0)
                            {
                                aofid.IdEfectoIndirecto = eid.IdEfectoIndirecto;
                                aofid.IdFinIndirecto = int.Parse(dsCausas.Tables[0].Rows[0][0].ToString());
                                aofid.FinIndirecto = dsCausas.Tables[0].Rows[0][1].ToString();
                            }

                            if (aofid.IdFinIndirecto != 0)
                            {
                                aofd.FinesIndirectos.Remove(aofid);
                                aofd.FinesIndirectos.Add(aofid);
                            }

                            //agregamos los ids de los efectos indirectos seleccionados por efecto directo
                            aped.IdsEID.Add(eid.IdEfectoIndirecto);

                            aped.FfectosIndirectos.Remove(eid);
                            aped.FfectosIndirectos.Add(eid);
                        }
                    }
                }

                #endregion

                if (!string.IsNullOrEmpty(aofd.FinDirecto))
                {
                    lstFD.Add(aofd);
                }

                lstDS.Add(aped);
            }
        }

        #endregion

        #region Categorias de Daño y sucesivos
        if (dsCD.Tables[0].Rows.Count != 0)
        {

            for (int i = 0; i < dsCD.Tables[0].Rows.Count; i++)
            {
                int idCategoriaDano = int.Parse(dsCD.Tables[0].Rows[i][0].ToString());
                string categoriaDano = dsCD.Tables[0].Rows[i][1].ToString();

                ArbolProblemaCD aped = new ArbolProblemaCD();
                aped.IdCategoriaDano = idCategoriaDano;
                aped.CategoriaDano = categoriaDano;

                //buscamos la causa directa (si hay más de una se trae la primera)
                string tableName = "MGA.CAUSA_DIRECTA";
                string tableNameMain = "MGA.CATEGORIA_DANO";

                DataSet dsCausas = FachadaPersistencia.getInstancia().ListaValoresParametroTablaId(tableName, tableNameMain, idCategoriaDano);

                if (dsCausas.Tables[0].Rows.Count != 0)
                {
                    aped.IdCausaDirecta = int.Parse(dsCausas.Tables[0].Rows[0][0].ToString());
                    aped.CausaDirecta = dsCausas.Tables[0].Rows[0][1].ToString();
                }

                lstCD.Add(aped);

                ArbolProblemaOED apoed = new ArbolProblemaOED();
                apoed.IdCausaDirecta = aped.IdCausaDirecta;
                apoed.CausaDirecta = aped.CausaDirecta;

                tableName = "MGA.OBJETIVO_ESPECIFICO_DIRECTO";
                tableNameMain = "MGA.CAUSA_DIRECTA";

                dsCausas = FachadaPersistencia.getInstancia().ListaValoresParametroTablaId(tableName, tableNameMain, apoed.IdCausaDirecta);

                if (dsCausas.Tables[0].Rows.Count != 0)
                {
                    apoed.IdObjetivoDirecto = int.Parse(dsCausas.Tables[0].Rows[0][0].ToString());
                    apoed.ObjetivoDirecto = dsCausas.Tables[0].Rows[0][1].ToString();
                }

                #region Subcategorias daño
                if (dsSCD.Tables[0].Rows.Count != 0)
                {
                    int cInner = -1;

                    for (int j = 0; j < dsSCD.Tables[0].Rows.Count; j++)
                    {
                        int idCatDano = int.Parse(dsSCD.Tables[0].Rows[j][2].ToString());

                        if (idCategoriaDano == idCatDano)
                        {
                            cInner++;

                            int idSubCD = int.Parse(dsSCD.Tables[0].Rows[j][0].ToString());
                            string subCD = dsSCD.Tables[0].Rows[j][1].ToString();

                            ArbolProblemaSCD apscd = new ArbolProblemaSCD();
                            apscd.IdSubcategoriaDano = idSubCD;
                            apscd.SubcategoriaDano = subCD;

                            aped.LstSCD.Add(apscd);

                            #region Causas Indirectas, Objetivos Indirectos
                            if (dsCI.Tables[0].Rows.Count != 0)
                            {
                                for (int k = 0; k < dsCI.Tables[0].Rows.Count; k++)
                                {
                                    int idSubCatD = int.Parse(dsCI.Tables[0].Rows[k][2].ToString());

                                    if (idSubCD == idSubCatD)
                                    {
                                        ArbolProblemaOEID apoeid = new ArbolProblemaOEID();
                                        ArbolProblemaCID apcid = new ArbolProblemaCID();

                                        int idCausaIndirecta = int.Parse(dsCI.Tables[0].Rows[k][0].ToString());

                                        //Fin indirecto
                                        tableName = "MGA.OBJETIVO_ESPECIFICO_INDIRECTO";
                                        tableNameMain = "MGA.CAUSA_INDIRECTA";

                                        dsCausas = FachadaPersistencia.getInstancia().ListaValoresParametroTablaId(tableName, tableNameMain, idCausaIndirecta);

                                        if (apoed.ObjetivosIndirectos.Count > 0)
                                        {
                                            if (apoed.ObjetivosIndirectos.Find(x => x.IdCausaIndirecta == idCausaIndirecta) != null)
                                            {
                                                apoeid = apoed.ObjetivosIndirectos.Find(x => x.IdCausaIndirecta == idCausaIndirecta);
                                            }
                                        }

                                        if (dsCausas.Tables[0].Rows.Count != 0)
                                        {
                                            apoeid.IdCausaIndirecta = idCausaIndirecta;
                                            apoeid.IdObjetivoIndirecto = int.Parse(dsCausas.Tables[0].Rows[0][0].ToString());
                                            apoeid.ObjetivoIndirecto = dsCausas.Tables[0].Rows[0][1].ToString();
                                        }

                                        if (aped.LstSCD[cInner].CausasIndirectas.Count > 0)
                                        {
                                            if (aped.LstSCD[cInner].CausasIndirectas.Find(x => x.IdCausaIndirecta == idCausaIndirecta) != null)
                                            {
                                                apcid = aped.LstSCD[cInner].CausasIndirectas.Find(x => x.IdCausaIndirecta == idCausaIndirecta);
                                            }
                                        }

                                        apcid.IdCausaIndirecta = idCausaIndirecta;
                                        apcid.CausaIndirecta = dsCI.Tables[0].Rows[k][1].ToString();

                                        apoed.ObjetivosIndirectos.Remove(apoeid);
                                        apoed.ObjetivosIndirectos.Add(apoeid);

                                        if (apcid.IdCausaIndirecta != 0)
                                        {
                                            aped.LstSCD[cInner].CausasIndirectas.Remove(apcid);
                                            aped.LstSCD[cInner].CausasIndirectas.Add(apcid);
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }

                #endregion


                if (!string.IsNullOrEmpty(apoed.ObjetivoDirecto))
                {
                    lstOED.Add(apoed);
                }
            }
        }
        #endregion

        #region Analisis Poblacion Afectada y Objetivo
        DataSet dsAP = FachadaPersistencia.getInstancia().ObtenerAnalisisPoblacionPIRC(idSujeto);

        if (!dsAP.Tables[0].Rows.Count.Equals(0))
        {
            datosPob.POB_AFEC_QUIEN = dsAP.Tables[0].Rows[0][2].ToString();
            datosPob.POB_OBJ_QUIEN = dsAP.Tables[0].Rows[0][6].ToString();

            datosPob.POB_AFEC_CARAC = dsAP.Tables[0].Rows[0][3].ToString();
            datosPob.POB_OBJ_CARAC = dsAP.Tables[0].Rows[0][7].ToString();

            datosPob.POB_AFEC_CANT = dsAP.Tables[0].Rows[0][4].ToString();
            datosPob.POB_OBJ_CANT = dsAP.Tables[0].Rows[0][8].ToString();

            string APob1 = dsAP.Tables[0].Rows[0][5].ToString();
            string APob2 = dsAP.Tables[0].Rows[0][9].ToString();

            datosPob.POB_AFEC_UBICA = APob1;
            datosPob.POB_OBJ_UBICA = APob2;

            if (APob1.Contains("|"))
            {
                string[] APobTerrs1 = APob1.Split('|')[0].Split(';');
                string[] APobDeps1 = APob1.Split('|')[1].Split(';');
                string[] APobMuns1 = APob1.Split('|')[2].Split(';');

                string ubica1 = "";

                for (int i = 0; i < APobTerrs1.Length; i++)
                {
                    ubica1 = "";
                    ubica1 = APobTerrs1[i];

                    if (APobDeps1.Length > i)
                    {
                        ubica1 += ", " + APobDeps1[i];
                    }

                    if (APobMuns1.Length > i)
                    {
                        ubica1 += ", " + APobMuns1[i];
                    }

                    ubica1 += Environment.NewLine;
                }

                datosPob.POB_AFEC_UBICA = ubica1;
            }

            if (APob2.Contains("|"))
            {
                string[] APobTerrs2 = APob2.Split('|')[0].Split(';');
                string[] APobDeps2 = APob2.Split('|')[1].Split(';');
                string[] APobMuns2 = APob2.Split('|')[2].Split(';');

                string ubica2 = "";

                for (int i = 0; i < APobTerrs2.Length; i++)
                {
                    ubica2 = "";
                    ubica2 = APobTerrs2[i];

                    if (APobDeps2.Length > i)
                    {
                        ubica2 += ", " + APobDeps2[i];
                    }

                    if (APobMuns2.Length > i)
                    {
                        ubica2 += ", " + APobMuns2[i];
                    }

                    ubica2 += Environment.NewLine;
                }

                datosPob.POB_OBJ_UBICA = ubica2;
            }
        }

        #endregion

        #region Análisis de Involucrados
        if (dsInvol.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsInvol.Tables[0].Rows.Count; i++)
            {
                InstrumentosInvolucrados inv = new InstrumentosInvolucrados();
                inv.ContribucionActor = dsInvol.Tables[0].Rows[i][11].ToString();
                inv.EstrategiaActor = dsInvol.Tables[0].Rows[i][10].ToString();
                inv.IdInfluenciaActor = int.Parse(dsInvol.Tables[0].Rows[i][8].ToString());
                inv.IdRolActor = int.Parse(dsInvol.Tables[0].Rows[i][5].ToString());
                inv.IdTipoActor = int.Parse(dsInvol.Tables[0].Rows[i][2].ToString());
                inv.InfluenciaActor = dsInvol.Tables[0].Rows[i][9].ToString();
                inv.InteresActor = dsInvol.Tables[0].Rows[i][7].ToString();
                inv.NombreActor = dsInvol.Tables[0].Rows[i][4].ToString();
                inv.RolActor = dsInvol.Tables[0].Rows[i][6].ToString();
                inv.TipoActor = dsInvol.Tables[0].Rows[i][3].ToString();

                lstInvol.Add(inv);
            }
        }
        #endregion

        #region Cadena de Valor - Atributos
        //Si ya hay data guardada la pintamos, de resto se muestran los atributos de acuerdo a los obj esp del arbol de objetivos
        if (dsCV.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsCV.Tables[0].Rows.Count; i++)
            {
                int idAttrCV = int.Parse(dsCV.Tables[0].Rows[i][0].ToString());

                int idObjetivo = int.Parse(dsCV.Tables[0].Rows[i][2].ToString());
                string objetivo = dsCV.Tables[0].Rows[i][3].ToString();
                int idAtributo = int.Parse(dsCV.Tables[0].Rows[i][4].ToString());
                string atributo = dsCV.Tables[0].Rows[i][5].ToString();

                InstrumentosCadenaValor attrCV = new InstrumentosCadenaValor();
                attrCV.IdObjetivoEspecifico = idObjetivo;
                attrCV.ObjetivoEspecifico = objetivo;
                attrCV.IdAtributo = idAtributo;
                attrCV.Atributo = atributo;

                List<InstrumentosCVProductos> lstProds = new List<InstrumentosCVProductos>();
                DataSet dsProds = FachadaPersistencia.getInstancia().ObtenerDatosProductosPIRC(idAttrCV);

                if (dsProds.Tables[0].Rows.Count != 0)
                {
                    for (int j = 0; j < dsProds.Tables[0].Rows.Count; j++)
                    {
                        int idProdCV = int.Parse(dsProds.Tables[0].Rows[j][0].ToString());
                        int idProducto = int.Parse(dsProds.Tables[0].Rows[j][2].ToString());
                        string producto = dsProds.Tables[0].Rows[j][5].ToString();
                        string descripcion = dsProds.Tables[0].Rows[j][6].ToString();
                        string indicador = dsProds.Tables[0].Rows[j][7].ToString();
                        string medida = dsProds.Tables[0].Rows[j][8].ToString();
                        string medido = dsProds.Tables[0].Rows[j][9].ToString();

                        string justificacion = dsProds.Tables[0].Rows[j][4].ToString();

                        decimal mTemp = decimal.Parse(dsProds.Tables[0].Rows[j][3].ToString());
                        int meta = Decimal.ToInt32(mTemp);

                        InstrumentosCVProductos prod = new InstrumentosCVProductos();
                        prod.IdAtributo = idAtributo;
                        prod.IdProducto = idProducto;
                        prod.IdProductoCV = idProdCV;
                        prod.Producto = producto;
                        prod.Descripcion = descripcion;
                        prod.Indicador = indicador;
                        prod.Medida = medida;
                        prod.Medido = medido;
                        prod.UnidadMedida = medida;
                        prod.MetaTotal = meta;
                        prod.Justificacion = justificacion;

                        List<InstrumentosActividadesProductos> lstActs = new List<InstrumentosActividadesProductos>();
                        DataSet dsActs = FachadaPersistencia.getInstancia().ObtenerDatosActividadesProductosPIRC(idProdCV);
                        if (dsActs.Tables[0].Rows.Count != 0)
                        {
                            for (int k = 0; k < dsActs.Tables[0].Rows.Count; k++)
                            {
                                int idActCV = int.Parse(dsActs.Tables[0].Rows[k][0].ToString());
                                int idClasificacion = int.Parse(dsActs.Tables[0].Rows[k][2].ToString());
                                int idEtapa = int.Parse(dsActs.Tables[0].Rows[k][3].ToString());
                                string actividades = dsActs.Tables[0].Rows[k][4].ToString();
                                string desActividades = dsActs.Tables[0].Rows[k][5].ToString();
                                bool rutaCritica = dsActs.Tables[0].Rows[k][6].ToString() == "True";

                                decimal c1Temp = decimal.Parse(dsActs.Tables[0].Rows[k][7].ToString());
                                decimal c2Temp = decimal.Parse(dsActs.Tables[0].Rows[k][8].ToString());
                                decimal c3Temp = decimal.Parse(dsActs.Tables[0].Rows[k][9].ToString());
                                decimal ctTemp = decimal.Parse(dsActs.Tables[0].Rows[k][10].ToString());

                                totalPIRC += ctTemp;

                                int costo1 = Decimal.ToInt32(c1Temp);
                                int costo2 = Decimal.ToInt32(c2Temp);
                                int costo3 = Decimal.ToInt32(c3Temp);
                                int costot = Decimal.ToInt32(ctTemp);

                                string clasificacion = dsActs.Tables[0].Rows[k][11].ToString();
                                string etapa = dsActs.Tables[0].Rows[k][12].ToString();

                                InstrumentosActividadesProductos act = new InstrumentosActividadesProductos();
                                act.Actividades = actividades;
                                act.Clasificacion = clasificacion;
                                act.CostoAnno1 = costo1;
                                act.CostoAnno2 = costo2;
                                act.CostoAnno3 = costo3;
                                act.CostoTotal = costot;
                                act.Descripcion = desActividades;
                                act.Etapa = etapa;
                                act.IdActividad = idActCV;
                                act.IdClasificacion = idClasificacion;
                                act.IdEtapa = idEtapa;
                                act.RutaCritica = rutaCritica;

                                lstActs.Add(act);
                            }
                        }

                        prod.Actividades = lstActs;
                        lstProds.Add(prod);
                    }
                }

                attrCV.Productos = lstProds;

                lstCV.Add(attrCV);
            }
        }
        else
        {
            if (dsOD.Tables[0].Rows.Count != 0)
            {


                for (int i = 0; i < dsOD.Tables[0].Rows.Count; i++)
                {
                    int idObjetivo = int.Parse(dsOD.Tables[0].Rows[i][0].ToString());
                    string objetivo = dsOD.Tables[0].Rows[i][1].ToString();

                    InstrumentosCadenaValor attrCV = new InstrumentosCadenaValor();
                    attrCV.IdObjetivoEspecifico = idObjetivo;
                    attrCV.ObjetivoEspecifico = objetivo;

                    string tableName = "MGA.ATRIBUTO";
                    string tableNameMain = "MGA.OBJETIVO_ESPECIFICO_DIRECTO";

                    DataSet dsCausas = FachadaPersistencia.getInstancia().ListaValoresParametroTablaId(tableName, tableNameMain, idObjetivo);

                    if (dsCausas.Tables[0].Rows.Count != 0)
                    {
                        attrCV.IdAtributo = int.Parse(dsCausas.Tables[0].Rows[0][0].ToString());
                        attrCV.Atributo = dsCausas.Tables[0].Rows[0][1].ToString();
                    }

                    lstCV.Add(attrCV);
                }
            }
        }
        #endregion

        #region DatosPDF

        if (dsDatosPDFPIRC.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsDatosPDFPIRC.Tables[0].Rows.Count; i++)
            {
                DatosPDFPIRC d = new DatosPDFPIRC();
                d.IDENT_PROBLEMA = dsDatosPDFPIRC.Tables[0].Rows[i][2].ToString();
                d.IDENT_OBJETIVOS = dsDatosPDFPIRC.Tables[0].Rows[i][3].ToString();
                d.POBLACION_AFECT_OBJ = dsDatosPDFPIRC.Tables[0].Rows[i][4].ToString();
                d.LOCALIZACION = dsDatosPDFPIRC.Tables[0].Rows[i][5].ToString();
                d.ASPECTO_ESTRATEG = dsDatosPDFPIRC.Tables[0].Rows[i][6].ToString();
                d.ASPECTO_TECNICO = dsDatosPDFPIRC.Tables[0].Rows[i][7].ToString();
                d.ASPECTO_FINANCIERO = dsDatosPDFPIRC.Tables[0].Rows[i][8].ToString();
                d.ASPECTO_SOSTENIBILIDAD = dsDatosPDFPIRC.Tables[0].Rows[i][9].ToString();
                d.ASPECTO_POLITICO = dsDatosPDFPIRC.Tables[0].Rows[i][10].ToString();
                d.IMPLICAC_INSTITUCIONALES = dsDatosPDFPIRC.Tables[0].Rows[i][11].ToString();
                d.BENEFICIOS_PIRC = dsDatosPDFPIRC.Tables[0].Rows[i][12].ToString();
                d.PROF_PIRC_RC = dsDatosPDFPIRC.Tables[0].Rows[i][13].ToString();
                d.PROF_PIRC_PSICO = dsDatosPDFPIRC.Tables[0].Rows[i][14].ToString();
                d.PROF_PIRC_SATISF = dsDatosPDFPIRC.Tables[0].Rows[i][15].ToString();
                d.PROF_PIRC_REHAB = dsDatosPDFPIRC.Tables[0].Rows[i][16].ToString();
                d.PROF_PIRC_GARAN = dsDatosPDFPIRC.Tables[0].Rows[i][17].ToString();
                d.PROF_PIRC_RESTIT = dsDatosPDFPIRC.Tables[0].Rows[i][18].ToString();
                d.PROF_REV_TECNICA = dsDatosPDFPIRC.Tables[0].Rows[i][19].ToString();
                d.ASPECTO_SOCIAL = dsDatosPDFPIRC.Tables[0].Rows[i][20].ToString();
                d.ASPECTO_LEGAL = dsDatosPDFPIRC.Tables[0].Rows[i][21].ToString();

                lstDatosPDF.Add(d);
            }
        }

        #endregion

        #region Análisis de Riesgos
        List<InstrumentosRiesgoProductosActividades> lstRiesgoProdActs = new List<InstrumentosRiesgoProductosActividades>();

        #region Análisis de Riesgos - Objetivo General
        if (dsRiesgoObj.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsRiesgoObj.Tables[0].Rows.Count; i++)
            {
                InstrumentosRiesgos riesgo = new InstrumentosRiesgos();
                riesgo.DescripcionRiesgo = dsRiesgoObj.Tables[0].Rows[i][3].ToString();
                riesgo.EfectoRiesgo = dsRiesgoObj.Tables[0].Rows[i][10].ToString();
                riesgo.IdImpactoRiesgo = int.Parse(dsRiesgoObj.Tables[0].Rows[i][8].ToString());
                riesgo.IdProbabilidadRiesgo = int.Parse(dsRiesgoObj.Tables[0].Rows[i][6].ToString());
                riesgo.IdTipoRiesgo = int.Parse(dsRiesgoObj.Tables[0].Rows[i][4].ToString());
                riesgo.ImpactoRiesgo = dsRiesgoObj.Tables[0].Rows[i][9].ToString();
                riesgo.MitigacionRiesgo = dsRiesgoObj.Tables[0].Rows[i][11].ToString();
                riesgo.Nombre = dsRiesgoObj.Tables[0].Rows[i][2].ToString();
                riesgo.ProbabilidadRiesgo = dsRiesgoObj.Tables[0].Rows[i][7].ToString();
                riesgo.TipoRiesgo = dsRiesgoObj.Tables[0].Rows[i][5].ToString();

                lstRiesgoObj.Add(riesgo);
            }
        }
        #endregion

        #region Análisis de Riesgos - Productos
        if (dsRiesgoProd.Tables[0].Rows.Count != 0)
        {
            if (lstCV.Count > 0)
            {
                foreach (var attr in lstCV)
                {
                    foreach (var prod in attr.Productos)
                    {
                        InstrumentosRiesgoProductos rProd = new InstrumentosRiesgoProductos();
                        InstrumentosRiesgoProductosActividades rProdAct = new InstrumentosRiesgoProductosActividades();
                        rProd.Id = prod.IdProductoCV;
                        rProd.Nombre = prod.Producto;

                        rProdAct.Id = prod.IdProductoCV;
                        rProdAct.Nombre = prod.Producto;

                        List<InstrumentosRiesgos> lstRiesgos = new List<InstrumentosRiesgos>();

                        for (int i = 0; i < dsRiesgoProd.Tables[0].Rows.Count; i++)
                        {
                            int idProdu = int.Parse(dsRiesgoProd.Tables[0].Rows[i][2].ToString());

                            if (idProdu == rProd.Id)
                            {
                                InstrumentosRiesgos riesgo = new InstrumentosRiesgos();
                                riesgo.Id = rProd.Id;

                                riesgo.DescripcionRiesgo = dsRiesgoProd.Tables[0].Rows[i][4].ToString();
                                riesgo.EfectoRiesgo = dsRiesgoProd.Tables[0].Rows[i][11].ToString();
                                riesgo.IdImpactoRiesgo = int.Parse(dsRiesgoProd.Tables[0].Rows[i][9].ToString());
                                riesgo.IdProbabilidadRiesgo = int.Parse(dsRiesgoProd.Tables[0].Rows[i][7].ToString());
                                riesgo.IdTipoRiesgo = int.Parse(dsRiesgoProd.Tables[0].Rows[i][5].ToString());
                                riesgo.ImpactoRiesgo = dsRiesgoProd.Tables[0].Rows[i][10].ToString();
                                riesgo.MitigacionRiesgo = dsRiesgoProd.Tables[0].Rows[i][12].ToString();
                                riesgo.Nombre = dsRiesgoProd.Tables[0].Rows[i][3].ToString();
                                riesgo.ProbabilidadRiesgo = dsRiesgoProd.Tables[0].Rows[i][8].ToString();
                                riesgo.TipoRiesgo = dsRiesgoProd.Tables[0].Rows[i][6].ToString();

                                lstRiesgos.Add(riesgo);
                            }
                        }

                        rProd.Riesgos = lstRiesgos;

                        lstRiesgoProd.Add(rProd);
                        lstRiesgoProdActs.Add(rProdAct);
                    }
                }
            }
        }
        #endregion

        #region Análisis de Riesgos - Actividades
        if (dsRiesgoActs.Tables[0].Rows.Count != 0)
        {
            foreach (var item in lstRiesgoProdActs)
            {
                DataSet dsActs = FachadaPersistencia.getInstancia().ObtenerDatosActividadesProductosPIRC(item.Id);

                if (dsActs.Tables[0].Rows.Count != 0)
                {
                    for (int k = 0; k < dsActs.Tables[0].Rows.Count; k++)
                    {
                        int idActCV = int.Parse(dsActs.Tables[0].Rows[k][0].ToString());
                        int idClasificacion = int.Parse(dsActs.Tables[0].Rows[k][2].ToString());
                        int idEtapa = int.Parse(dsActs.Tables[0].Rows[k][3].ToString());
                        string actividades = dsActs.Tables[0].Rows[k][4].ToString();
                        string desActividades = dsActs.Tables[0].Rows[k][5].ToString();
                        bool rutaCritica = dsActs.Tables[0].Rows[k][6].ToString() == "True";

                        if (rutaCritica)
                        {
                            InstrumentosRiesgoActividades rAct = new InstrumentosRiesgoActividades();
                            rAct.Id = idActCV;
                            rAct.IdProducto = item.Id;
                            rAct.Nombre = actividades;

                            List<InstrumentosRiesgos> lstRiesgos = new List<InstrumentosRiesgos>();

                            for (int i = 0; i < dsRiesgoActs.Tables[0].Rows.Count; i++)
                            {
                                int idActi = int.Parse(dsRiesgoActs.Tables[0].Rows[i][2].ToString());

                                if (idActCV == idActi)
                                {
                                    InstrumentosRiesgos riesgo = new InstrumentosRiesgos();
                                    riesgo.Id = rAct.Id;

                                    riesgo.DescripcionRiesgo = dsRiesgoActs.Tables[0].Rows[i][4].ToString();
                                    riesgo.EfectoRiesgo = dsRiesgoActs.Tables[0].Rows[i][11].ToString();
                                    riesgo.IdImpactoRiesgo = int.Parse(dsRiesgoActs.Tables[0].Rows[i][9].ToString());
                                    riesgo.IdProbabilidadRiesgo = int.Parse(dsRiesgoActs.Tables[0].Rows[i][7].ToString());
                                    riesgo.IdTipoRiesgo = int.Parse(dsRiesgoActs.Tables[0].Rows[i][5].ToString());
                                    riesgo.ImpactoRiesgo = dsRiesgoActs.Tables[0].Rows[i][10].ToString();
                                    riesgo.MitigacionRiesgo = dsRiesgoActs.Tables[0].Rows[i][12].ToString();
                                    riesgo.Nombre = dsRiesgoActs.Tables[0].Rows[i][3].ToString();
                                    riesgo.ProbabilidadRiesgo = dsRiesgoActs.Tables[0].Rows[i][8].ToString();
                                    riesgo.TipoRiesgo = dsRiesgoActs.Tables[0].Rows[i][6].ToString();

                                    lstRiesgos.Add(riesgo);
                                }
                            }

                            rAct.Riesgos = lstRiesgos;

                            lstRiesgoActs.Add(rAct);
                        }
                    }
                }

                item.Actividades = lstRiesgoActs;
            }
        }
        #endregion

        #endregion

        #region Análisis de Beneficios
        if (dsBene.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsBene.Tables[0].Rows.Count; i++)
            {
                InstrumentosBeneficios beneficio = new InstrumentosBeneficios();

                string nombre = dsBene.Tables[0].Rows[i][2].ToString();
                string descripcion = dsBene.Tables[0].Rows[i][3].ToString();

                beneficio.NombreBeneficio = nombre;
                beneficio.DescripcionBeneficio = descripcion;

                lstBeneficios.Add(beneficio);
            }
        }

        #endregion

        #region Indicadores de Seguimiento

        #region Indicadores de Productos
        if (dsSeguimientoProds.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsSeguimientoProds.Tables[0].Rows.Count; i++)
            {
                InstrumentosProductoSeguimiento sProd = new InstrumentosProductoSeguimiento();

                sProd.Descripcion = dsSeguimientoProds.Tables[0].Rows[i][7].ToString();
                sProd.Fuente = dsSeguimientoProds.Tables[0].Rows[i][18].ToString();
                sProd.IdProducto = int.Parse(dsSeguimientoProds.Tables[0].Rows[i][2].ToString());
                sProd.IdProductoCV = int.Parse(dsSeguimientoProds.Tables[0].Rows[i][3].ToString());
                sProd.IdTipoFuente = int.Parse(dsSeguimientoProds.Tables[0].Rows[i][16].ToString());
                sProd.Indicador = dsSeguimientoProds.Tables[0].Rows[i][5].ToString();
                sProd.Medida = dsSeguimientoProds.Tables[0].Rows[i][8].ToString();
                sProd.Medido = dsSeguimientoProds.Tables[0].Rows[i][6].ToString();
                sProd.Producto = dsSeguimientoProds.Tables[0].Rows[i][4].ToString();
                sProd.TipoFuente = dsSeguimientoProds.Tables[0].Rows[i][17].ToString();
                sProd.UnidadMedida = dsSeguimientoProds.Tables[0].Rows[i][8].ToString();

                decimal mTemp = decimal.Parse(dsSeguimientoProds.Tables[0].Rows[i][9].ToString());
                sProd.MetaTotal = Decimal.ToInt32(mTemp);

                decimal c1Temp = decimal.Parse(dsSeguimientoProds.Tables[0].Rows[i][10].ToString());
                decimal c2Temp = decimal.Parse(dsSeguimientoProds.Tables[0].Rows[i][11].ToString());
                decimal c3Temp = decimal.Parse(dsSeguimientoProds.Tables[0].Rows[i][12].ToString());
                decimal a1Temp = decimal.Parse(dsSeguimientoProds.Tables[0].Rows[i][13].ToString());
                decimal a2Temp = decimal.Parse(dsSeguimientoProds.Tables[0].Rows[i][14].ToString());
                decimal a3Temp = decimal.Parse(dsSeguimientoProds.Tables[0].Rows[i][15].ToString());

                sProd.CostoAnno1 = Decimal.ToInt32(c1Temp);
                sProd.CostoAnno2 = Decimal.ToInt32(c2Temp);
                sProd.CostoAnno3 = Decimal.ToInt32(c3Temp);
                sProd.Anno1 = Decimal.ToInt32(a1Temp);
                sProd.Anno2 = Decimal.ToInt32(a2Temp);
                sProd.Anno3 = Decimal.ToInt32(a3Temp);

                lstSegProd.Add(sProd);
            }

            if (lstCV.Count > 0)
            {
                foreach (var attr in lstCV)
                {
                    foreach (var prod in attr.Productos)
                    {
                        if (lstSegProd.Find(x => x.IdProductoCV == prod.IdProductoCV) == null)
                        {
                            InstrumentosProductoSeguimiento sProd = new InstrumentosProductoSeguimiento();
                            sProd.Descripcion = prod.Descripcion;
                            sProd.IdProducto = prod.IdProducto;
                            sProd.IdProductoCV = prod.IdProductoCV;
                            sProd.Indicador = prod.Indicador;
                            sProd.Medida = prod.Medida;
                            sProd.Medido = prod.Medido;
                            sProd.MetaTotal = prod.MetaTotal;
                            sProd.Producto = prod.Producto;
                            sProd.UnidadMedida = prod.UnidadMedida;

                            foreach (var act in prod.Actividades)
                            {
                                sProd.CostoAnno1 += act.CostoAnno1;
                                sProd.CostoAnno2 += act.CostoAnno2;
                                sProd.CostoAnno3 += act.CostoAnno3;
                            }

                            lstSegProd.Add(sProd);
                        }
                    }
                }
            }

            metaTotalPIRC = lstSegProd.Count;
        }

        #endregion

        #region Indicadores de Gestión - Actividades
        if (dsSeguimientoActs.Tables[0].Rows.Count != 0)
        {
            for (int i = 0; i < dsSeguimientoActs.Tables[0].Rows.Count; i++)
            {
                InstrumentosActividadesSeguimiento sAct = new InstrumentosActividadesSeguimiento();

                sAct.Descripcion = dsSeguimientoActs.Tables[0].Rows[i][7].ToString();
                sAct.Fuente = dsSeguimientoActs.Tables[0].Rows[i][18].ToString();
                sAct.IdActividadCV = int.Parse(dsSeguimientoActs.Tables[0].Rows[i][2].ToString());
                sAct.IdIndicador = int.Parse(dsSeguimientoActs.Tables[0].Rows[i][4].ToString());
                sAct.IdTipoFuente = int.Parse(dsSeguimientoActs.Tables[0].Rows[i][16].ToString());
                sAct.Indicador = dsSeguimientoActs.Tables[0].Rows[i][5].ToString();
                sAct.Medida = dsSeguimientoActs.Tables[0].Rows[i][8].ToString();
                sAct.Medido = dsSeguimientoActs.Tables[0].Rows[i][6].ToString();
                sAct.Actividad = dsSeguimientoActs.Tables[0].Rows[i][3].ToString();
                sAct.TipoFuente = dsSeguimientoActs.Tables[0].Rows[i][17].ToString();
                sAct.UnidadMedida = dsSeguimientoActs.Tables[0].Rows[i][8].ToString();

                decimal mTemp = decimal.Parse(dsSeguimientoActs.Tables[0].Rows[i][9].ToString());
                sAct.CostoTotal = Decimal.ToInt32(mTemp);

                decimal c1Temp = decimal.Parse(dsSeguimientoActs.Tables[0].Rows[i][10].ToString());
                decimal c2Temp = decimal.Parse(dsSeguimientoActs.Tables[0].Rows[i][11].ToString());
                decimal c3Temp = decimal.Parse(dsSeguimientoActs.Tables[0].Rows[i][12].ToString());
                decimal a1Temp = decimal.Parse(dsSeguimientoActs.Tables[0].Rows[i][13].ToString());
                decimal a2Temp = decimal.Parse(dsSeguimientoActs.Tables[0].Rows[i][14].ToString());
                decimal a3Temp = decimal.Parse(dsSeguimientoActs.Tables[0].Rows[i][15].ToString());

                sAct.CostoAnno1 = Decimal.ToInt32(c1Temp);
                sAct.CostoAnno2 = Decimal.ToInt32(c2Temp);
                sAct.CostoAnno3 = Decimal.ToInt32(c3Temp);
                sAct.Anno1 = Decimal.ToInt32(a1Temp);
                sAct.Anno2 = Decimal.ToInt32(a2Temp);
                sAct.Anno3 = Decimal.ToInt32(a3Temp);

                lstSegActs.Add(sAct);
            }

            if (lstCV.Count > 0)
            {
                foreach (var attr in lstCV)
                {
                    foreach (var prod in attr.Productos)
                    {
                        foreach (var act in prod.Actividades)
                        {
                            if (act.RutaCritica && (lstSegActs.Find(x => x.IdActividadCV == act.IdActividad) == null))
                            {
                                InstrumentosActividadesSeguimiento sAct = new InstrumentosActividadesSeguimiento();
                                sAct.Actividad = act.Actividades;
                                sAct.Descripcion = act.Descripcion;
                                sAct.IdActividadCV = act.IdActividad;
                                sAct.Medida = prod.Medida;
                                sAct.Medido = prod.Medido;
                                sAct.CostoAnno1 = act.CostoAnno1;
                                sAct.CostoAnno2 = act.CostoAnno2;
                                sAct.CostoAnno3 = act.CostoAnno3;
                                sAct.CostoTotal = act.CostoTotal;
                                sAct.UnidadMedida = prod.UnidadMedida;

                                lstSegActs.Add(sAct);
                            }
                        }
                    }
                }
            }

            if (lstCV.Count > 0)
            {
                foreach (var attr in lstCV)
                {
                    foreach (var prod in attr.Productos)
                    {
                        foreach (var act in prod.Actividades)
                        {
                            if (!act.RutaCritica && (lstSegActs.Find(x => x.IdActividadCV == act.IdActividad) != null))
                            {
                                InstrumentosActividadesSeguimiento sAct = lstSegActs.Find(x => x.IdActividadCV == act.IdActividad);
                                lstSegActs.Remove(sAct);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Cronograma
        if (dsSeguimientoCrono.Tables[0].Rows.Count != 0)
        {
            if (lstCV.Count > 0)
            {
                foreach (var attr in lstCV)
                {
                    InstrumentosCronogramaAtributos cAttr = new InstrumentosCronogramaAtributos();
                    cAttr.Atributo = attr.Atributo;
                    cAttr.IdAtributo = attr.IdAtributo;
                    cAttr.IdObjetivoEspecifico = attr.IdObjetivoEspecifico;
                    cAttr.ObjetivoEspecifico = attr.ObjetivoEspecifico;

                    List<InstrumentosCronogramaProductos> cProds = new List<InstrumentosCronogramaProductos>();

                    foreach (var prod in attr.Productos)
                    {
                        InstrumentosCronogramaProductos cProd = new InstrumentosCronogramaProductos();
                        cProd.Descripcion = prod.Descripcion;
                        cProd.IdAtributo = prod.IdAtributo;
                        cProd.IdProducto = prod.IdProducto;
                        cProd.IdProductoCV = prod.IdProductoCV;
                        cProd.Indicador = prod.Indicador;
                        cProd.Medida = prod.Medida;
                        cProd.Medido = prod.Medido;
                        cProd.MetaTotal = prod.MetaTotal;
                        cProd.Producto = prod.Producto;
                        cProd.UnidadMedida = prod.UnidadMedida;

                        List<InstrumentosCronogramaActividadesProductos> cActs = new List<InstrumentosCronogramaActividadesProductos>();

                        foreach (var act in prod.Actividades)
                        {
                            InstrumentosCronogramaActividadesProductos cAct = new InstrumentosCronogramaActividadesProductos();
                            cAct.Actividades = act.Actividades;
                            cAct.Clasificacion = act.Clasificacion;
                            cAct.CostoAnno1 = act.CostoAnno1;
                            cAct.CostoAnno2 = act.CostoAnno2;
                            cAct.CostoAnno3 = act.CostoAnno3;
                            cAct.CostoTotal = act.CostoTotal;
                            cAct.Descripcion = act.Descripcion;
                            cAct.Etapa = act.Etapa;
                            cAct.IdActividad = act.IdActividad;
                            cAct.IdClasificacion = act.IdClasificacion;
                            cAct.IdEtapa = act.IdEtapa;
                            cAct.RutaCritica = act.RutaCritica;

                            List<InstrumentosCronogramaProductosActividadesTareas> cTareas = new List<InstrumentosCronogramaProductosActividadesTareas>();

                            for (int i = 0; i < dsSeguimientoCrono.Tables[0].Rows.Count; i++)
                            {
                                int idAct = int.Parse(dsSeguimientoCrono.Tables[0].Rows[i][2].ToString());

                                if (idAct == act.IdActividad)
                                {
                                    InstrumentosCronogramaProductosActividadesTareas cTarea = new InstrumentosCronogramaProductosActividadesTareas();

                                    cTarea.IdAtributoCV = attr.IdAtributo;
                                    cTarea.IdProductoCV = prod.IdProductoCV;
                                    cTarea.IdActividadCV = int.Parse(dsSeguimientoCrono.Tables[0].Rows[i][2].ToString());
                                    cTarea.Tarea = dsSeguimientoCrono.Tables[0].Rows[i][3].ToString();
                                    cTarea.Responsable = dsSeguimientoCrono.Tables[0].Rows[i][4].ToString();

                                    if (string.IsNullOrEmpty(dsSeguimientoCrono.Tables[0].Rows[i][41].ToString()))
                                    {
                                        cTarea.FechaIni1 = null;
                                    }
                                    else
                                    {
                                        cTarea.FechaIni1 = DateTime.Parse(dsSeguimientoCrono.Tables[0].Rows[i][41].ToString());
                                        cTarea.strFechaIni1 = cTarea.FechaIni1.Value.ToShortDateString();
                                    }

                                    if (string.IsNullOrEmpty(dsSeguimientoCrono.Tables[0].Rows[i][42].ToString()))
                                    {
                                        cTarea.FechaFin1 = null;
                                    }
                                    else
                                    {
                                        cTarea.FechaFin1 = DateTime.Parse(dsSeguimientoCrono.Tables[0].Rows[i][42].ToString());
                                        cTarea.strFechaFin1 = cTarea.FechaFin1.Value.ToShortDateString();
                                    }

                                    if (string.IsNullOrEmpty(dsSeguimientoCrono.Tables[0].Rows[i][43].ToString()))
                                    {
                                        cTarea.FechaIni2 = null;
                                    }
                                    else
                                    {
                                        cTarea.FechaIni2 = DateTime.Parse(dsSeguimientoCrono.Tables[0].Rows[i][43].ToString());
                                        cTarea.strFechaIni2 = cTarea.FechaIni2.Value.ToShortDateString();
                                    }

                                    if (string.IsNullOrEmpty(dsSeguimientoCrono.Tables[0].Rows[i][44].ToString()))
                                    {
                                        cTarea.FechaFin2 = null;
                                    }
                                    else
                                    {
                                        cTarea.FechaFin2 = DateTime.Parse(dsSeguimientoCrono.Tables[0].Rows[i][44].ToString());
                                        cTarea.strFechaFin2 = cTarea.FechaFin2.Value.ToShortDateString();
                                    }

                                    if (string.IsNullOrEmpty(dsSeguimientoCrono.Tables[0].Rows[i][45].ToString()))
                                    {
                                        cTarea.FechaIni3 = null;
                                    }
                                    else
                                    {
                                        cTarea.FechaIni3 = DateTime.Parse(dsSeguimientoCrono.Tables[0].Rows[i][45].ToString());
                                        cTarea.strFechaIni3 = cTarea.FechaIni3.Value.ToShortDateString();
                                    }

                                    if (string.IsNullOrEmpty(dsSeguimientoCrono.Tables[0].Rows[i][46].ToString()))
                                    {
                                        cTarea.FechaFin3 = null;
                                    }
                                    else
                                    {
                                        cTarea.FechaFin3 = DateTime.Parse(dsSeguimientoCrono.Tables[0].Rows[i][46].ToString());
                                        cTarea.strFechaFin3 = cTarea.FechaFin3.Value.ToShortDateString();
                                    }

                                    cTareas.Add(cTarea);
                                }
                            }

                            cAct.Tareas = cTareas;
                            cActs.Add(cAct);
                        }

                        cProd.Actividades = cActs;
                        cProds.Add(cProd);
                    }

                    cAttr.Productos = cProds;
                    lstCronograma.Add(cAttr);
                }
            }
        }
        #endregion

        #region Matriz Resumen
        if (dsMatrizResumen.Tables[0].Rows.Count != 0)
        {
            if (lstDS.Count > 0)
            {
                foreach (var attr in lstCV)
                {
                    InstrumentosResumenAtributos rAttr = new InstrumentosResumenAtributos();
                    rAttr.Atributo = attr.Atributo;
                    rAttr.IdAtributo = attr.IdAtributo;
                    rAttr.IdObjetivoEspecifico = attr.IdObjetivoEspecifico;
                    rAttr.ObjetivoEspecifico = attr.ObjetivoEspecifico;

                    List<InstrumentosResumenProductos> lstResumenProds = new List<InstrumentosResumenProductos>();

                    foreach (var prod in attr.Productos)
                    {
                        InstrumentosResumenProductos rProd = new InstrumentosResumenProductos();
                        InstrumentosProductoSeguimiento sProd = lstSegProd.Find(x => x.IdProductoCV == prod.IdProductoCV);

                        rProd.Descripcion = prod.Descripcion;
                        rProd.IdAtributo = prod.IdAtributo;
                        rProd.IdProducto = prod.IdProducto;
                        rProd.IdProductoCV = prod.IdProductoCV;
                        rProd.Indicador = prod.Indicador;
                        rProd.Medida = prod.Medida;
                        rProd.Medido = prod.Medido;
                        rProd.MetaTotal = prod.MetaTotal;
                        rProd.Producto = prod.Producto;
                        rProd.UnidadMedida = prod.UnidadMedida;

                        rProd.Fuente = sProd.Fuente;
                        rProd.TipoFuente = sProd.TipoFuente;

                        for (int i = 0; i < dsMatrizResumen.Tables[0].Rows.Count; i++)
                        {
                            int idProdMR = int.Parse(dsMatrizResumen.Tables[0].Rows[i][2].ToString());

                            if (idProdMR == rProd.IdProductoCV)
                            {
                                rProd.Supuestos = dsMatrizResumen.Tables[0].Rows[i][3].ToString();
                            }
                        }

                        List<InstrumentosResumenActividadesProductos> lstResumenActs = new List<InstrumentosResumenActividadesProductos>();

                        foreach (var act in prod.Actividades)
                        {
                            if (act.RutaCritica)
                            {
                                InstrumentosResumenActividadesProductos rAct = new InstrumentosResumenActividadesProductos();
                                InstrumentosActividadesSeguimiento sAct = lstSegActs.Find(x => x.IdActividadCV == act.IdActividad);

                                rAct.Actividades = act.Actividades;
                                rAct.Clasificacion = act.Clasificacion;
                                rAct.CostoTotal = act.CostoTotal;
                                rAct.Descripcion = act.Descripcion;
                                rAct.Etapa = act.Etapa;
                                rAct.IdActividad = act.IdActividad;
                                rAct.IdClasificacion = act.IdClasificacion;
                                rAct.RutaCritica = act.RutaCritica;

                                rAct.Medido = sAct != null ? sAct.Medido : "";
                                rAct.Indicador = sAct != null ? sAct.Indicador : "";
                                rAct.Fuente = sAct != null ? sAct.Fuente : "";
                                rAct.TipoFuente = sAct != null ? sAct.TipoFuente : "";

                                for (int i = 0; i < dsMatrizResumenActs.Tables[0].Rows.Count; i++)
                                {
                                    int idActMR = int.Parse(dsMatrizResumenActs.Tables[0].Rows[i][2].ToString());

                                    if (idActMR == rAct.IdActividad)
                                    {
                                        rAct.Supuestos = dsMatrizResumenActs.Tables[0].Rows[i][3].ToString();
                                    }
                                }

                                lstResumenActs.Add(rAct);
                            }
                        }

                        rProd.Actividades = lstResumenActs;
                        lstResumenProds.Add(rProd);
                    }

                    rAttr.Productos = lstResumenProds;
                    lstResumen.Add(rAttr);
                }
            }
        }
        #endregion

        totPIRC = totalPIRC.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));

        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        serializer.MaxJsonLength = 500000000;

        var objeto = new
        {
            apED = lstDS,
            apFD = lstFD,
            apCD = lstCD,
            apOB = lstOED,
            datosPDF = lstDatosPDF,
            pob = datosPob,
            invol = lstInvol,
            CV = lstCV,
            totalPIRC = totPIRC,
            nomSujeto = nomSujeto,
            tipoSujeto = tipoSujeto,
            territorialSujeto = territorialSujeto,
            deptoSujeto = deptoSujeto,
            mpioSujeto = mpioSujeto,
            riesgosObj = lstRiesgoObj,
            riesgosProd = lstRiesgoProd,
            riesgosActs = lstRiesgoActs,
            bene = lstBeneficios,
            indProds = lstSegProd,
            indActs = lstSegActs,
            metaTotalPIRC = metaTotalPIRC,
            crono = lstCronograma,
            resumen = lstResumen
        };

        //return serializer.Serialize(objeto);
        return objeto;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //string popupScript2 = "<script language='JavaScript'> Swal.fire(" +
        //"'Efectos Directos'," +
        //"'Son las consecuencias del problema central y sus causas. Tenga en cuenta que no tiene que relacionar un efecto a cada causa directa a categoría de daño, sino que estas responden a la complejidad del problema. Agregue mínimo cuatro y máximo seis.'," +
        //"'question'" +
        //") </script> ";

        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Efectos Directos</u></strong>',type: 'info',html:'<h5><b>Son las consecuencias del problema central y sus causas. Tenga en cuenta que no tiene que relacionar un efecto a cada causa directa a categoría de daño, sino que estas responden a la complejidad del problema. Agregue mínimo cuatro y máximo seis.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);

        //Mensajes_3("Hola mundo", "Mensaje de ayuda", 0);

        //string popupScript2 = "<script language='JavaScript'> Swal.fire({"+
        //      "title: 'Custom animation with Animate.css',"+
        //      "animation: true,"+
        //      "customClass: 'animated tada'"+
        //        "}) </script> ";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info1_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Identificación de la Situación Actual y Deseada</u></strong>',type: 'info',html:'<h5><b>Corresponde a la elaboración del árbol del problema, el análisis de población y de involucrados y la generación del árbol de objetivos. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info2_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Árbol del Problema</u></strong>',type: 'info',html:'<h5><b>El árbol del problema se construye a partir de las categorías del daño y subcategorías del daño analizadas en el documento de diagnóstico o caracterización del daño. Se deben poder rastrear las categorías y subcategorías acá planteadas, en el documento validado por el sujeto de reparación colectiva. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info3_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Descripción del Problema</u></strong>',type: 'info',html:'<h5><b>Construya dos o tres párrafos mencionando: 1. El problema central identificado, que para todos los sujetos de reparación colectiva es la Persistencia de daños colectivos en el Sujeto Colectivo ocasionados en el marco del conflicto armado (este problema no se debe modificar, en tanto hace parte del marco lógico del PIRC); 2. Ubicación del Sujeto de Reparación Colectiva, para lo cual puede retomar la información de la Ficha de identificación (no profundice acá en esto, pues se requerirá de manera más amplia en el Análisis de la población afectada y población objetivo); 3. Las categorías y subcategorías de daño que se analizaron en la elaboración del documento de diagnóstico o caracterización del daño. El propósito no es transcribir dicho documento, sino hacer una mención general a lo ocurrido. Para este apartado, por favor indique en qué páginas del documento se encuentra la información a la que hace referencia; y 4. Análisis de algunos de los efectos (consecuencias) que esta situación ha podido generar en el Sujeto de Reparación Colectiva, de acuerdo con los elegidos en el árbol de problemas. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info4_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Efectos Indirectos</u></strong>',type: 'info',html:'<h5><b>Se encuentran relacionados con los efectos indirectos. Elija aquellos que resulten coherentes con el efecto directo seleccionado. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info5_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Categorías de Daño</u></strong>',type: 'info',html:'<h5><b>Recuerde que las categorías de daño hacen referencia a los daños a los atributos. En el signo +, agregue las categorías de daño que se analizaron en el documento de diagnóstico o caracterización del daño. Al darle +, se activarán las subcategorías de daño asociadas a ese atributo. Nuevamente, con el signo + podrá agregar las subcategorías de daño analizadas y las causas indirectas relacionadas a esa subcategoría. Recuerde elegir aquellas que se ajustan más a la realidad del colectivo y que se encuentren sustentadas en el documento de diagnóstico o caracterización del daño. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info6_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Descripción localización de la Población</u></strong>',type: 'info',html:'<h5><b>Construya uno o dos párrafos mencionando: 1. El lugar o lugares en donde se va a ejecutar el PIRC (En caso de ser una vereda o corregimiento, indique con qué poblaciones limita, si cuenta con fuentes de agua cercanas y cuáles, así como otros puntos geográficos que puedan ser importantes para localizar al PIRC. Para los casos de Sujetos que se encuentran en varios lugares del territorio nacional, especifique los lugares en los que tiene presencia); y 2. La información que tiene la ficha de correlación con instrumentos de planeación, relacionada con Actividad económica. No se trata de copiar y pegar este apartado de la ficha, sino de describirlo, en relación con los productos más representativos de la zona. Tenga en cuenta si esto aplica o no para el SRC, pues esta ficha solo se elabora para casos territoriales. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void bt_info7_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Características</u></strong>',type: 'info',html:'<h5><b>Construya un párrafo en el que describa de manera general al SRC. Puede empezar diciendo que son una comunidad, grupo u organización.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info8_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Cantidad</u></strong>',type: 'info',html:'<h5><b>Indique el número aproximado de personas que componen el colectivo. Puede remitirse a la ficha de identificación para obtener este dato. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info9_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Localización</u></strong>',type: 'info',html:'<h5><b>Seleccione la Dirección Territorial, el departamento y el o los municipios en el que se encuentra el Sujeto de Reparación Colectiva. En los casos en que se encuentre en todo el territorio nacional, seleccione la opción INCIDENCIA NACIONAL que se encuentra en la lista desplegable de Dirección Territorial.  </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info10_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Análisis de Involucrados</u></strong>',type: 'info',html:'<h5><b>Son los actores que, desde el punto de vista social, institucional, comunitario, entre otros, tienen o tendrán alguna relación con la formulación y la implementación del PIRC. Puede utilizar el mapa de actores de la ficha de identificación, como insumo para este análisis. Recuerde que este análisis lo debió desarrollar en la fase de diagnóstico o caracterización del daño. En el signo +, podrá agregar tantos actores como requiere. No olvide relacionar siempre como actores al sujeto de reparación colectiva y a la Unidad para las Víctimas. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info11_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Tipo de Actor</u></strong>',type: 'info',html:'<h5><b>Elija en el menú desplegable el tipo de actor que corresponda.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info12_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Interés - Expectativa</u></strong>',type: 'info',html:'<h5><b>Describa el interés que puede tener el actor con la formulación o implementación del PIRC. Recuerde que este interés para el caso de oponentes o perjudicados, puede no estar en armonía con los propósitos que persigue el programa, de ahí la necesidad de identificarlo.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info13_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Estrategia</u></strong>',type: 'info',html:'<h5><b>Relacione las acciones que piensa desarrollar de manera conjunta con el sujeto de reparación colectiva, para potenciar el rol de los actores identificados como cooperantes, o mitigar o monitorear el rol de aquellos calificados como perjudicados u oponentes. Estas actividades deben ser acciones realizables que puedan ser monitoreadas a lo largo de la formulación e implementación del PIRC.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info14_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Contribución o Razón del Desacuerdo</u></strong>',type: 'info',html:'<h5><b>Describa la posible contribución que puedan hacer los cooperantes o beneficiarios del PIRC. Trate de no dejar cosas muy generales. Para los actores con roles de oponentes y perjudicados, es necesario describir o argumentar las razones por las cuales manifiestan su desacuerdo frente a la ejecución del PIRC.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info15_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>CONCERTACIÓN ENTRE ACTORES</u></strong>',type: 'info',html:'<h5><b>Escriba un párrafo en el que indique qué tipo de condiciones y relaciones se deben generar entre los actores para lograr avanzar en el cumplimiento de los objetivos del PIRC. Puede mencionar elementos como la articulación o el diálogo entre actores. No olvide relacionar a aquellos calificados como oponentes o perjudicados en el texto.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info16_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Árbol de Objetivos</u></strong>',type: 'info',html:'<h5><b>Se genera automáticamente a partir de la elaboración del árbol del problema.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info17_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Descripción Árbol de Objetivos</u></strong>',type: 'info',html:'<h5><b>Elabore dos o tres párrafos en donde integre: 1. Una mención al objetivo general del PIRC que es Contribuir a la reparación integral de los daños causados en el Sujeto Colectivo (XXXXXXXX) en el marco del conflicto armado. Este objetivo es el mismo para todos los planes, por tanto, no debe ser modificado. Asimismo, mencione los objetivos específicos directos que se generaron a partir de la elaboración del árbol del problema; 2. Mencione cómo piensan lograr los objetivos específicos directos, para lo cual debe tener en cuenta los objetivos específicos indirectos que se generaron en el árbol de objetivos (verifique que la información sea coherente, es decir, que los objetivos específicos indirectos si correspondan con lo que se quiere lograr con el sujeto de reparación colectiva.); y 3. Una descripción de los fines que se desplegaron en el árbol de objetivos y que se encuentran relacionados con cada uno de los efectos elegidos en el árbol del problema. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info18_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Preparación del PIRC</u></strong>',type: 'info',html:'<h5><b>Corresponde a la elaboración de la Cadena de valor (en donde se deben relacionar los productos y actividades del PIRC), el análisis de riesgos y el análisis de beneficios del PIRC. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info19_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Cadena de Valor</u></strong>',type: 'info',html:'<h5><b>Se activa solamente si ya se ha generado el árbol de objetivos. Acá debe relacionar las actividades reparadoras concertadas con el sujeto de reparación colectiva, las cuales deben ir clasificadas en los productos. Estos los puede seleccionar en el signo (+) que se encuentra al lado del objetivo específico. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info20_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Producto</u></strong>',type: 'info',html:'<h5><b>Escoja el que mejor se ajuste a las actividades propuestas como reparadoras por el sujeto de reparación colectiva. Tenga en cuenta que, las actividades deben ser coherentes con la descripción del producto. De lo contrario el producto no será aprobado y lo deberás ajustar.  </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info21_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Justificación del Producto:</u></strong>',type: 'info',html:'<h5><b>Construir un párrafo que relacione: a. Descripción del producto: tomarla literalmente del catálogo de acuerdo con la tipología de Sujeto de Reparación Colectiva que corresponda; b. La pertinencia del producto para reparar los daños colectivos identificados y lograr el objetivo específico directo. Este párrafo debe concluir con la frase: Para el desarrollo de este producto se deben desarrollar las siguientes actividades:</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info22_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Meta Total</u></strong>',type: 'info',html:'<h5><b>Relacione cuántas veces se va a llevar a cabo el producto en el marco de la implementación del PIRC. La meta total NO ES LA SUMA DE ACTIVIDADES. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info23_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Clasificación</u></strong>',type: 'info',html:'<h5><b>Elija el menú desplegable, qué tipo de actividad se va a desarrollar.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info24_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Actividades</u></strong>',type: 'info',html:'<h5><b>En una oración indique la actividad a realizar. Trate de relacionarlas en orden, es decir, como un paso a paso que se debe seguir de manera secuencial. Recuerde que un producto mínimo debe tener dos actividades.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info25_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Descripción</u></strong>',type: 'info',html:'<h5><b>Elabore un párrafo en el que relacione: 1. En qué consiste la actividad; 2. Número aproximado de participantes; 3. A quién está dirigida la actividad; 4. Cuánto tiempo dura (un día, medio día, etc.); 5. El tipo de logística que requiere (si se requiere); 6. Si se necesitan materiales indicar de manera general cuáles; 7. Espacio en el que se desarrollará la actividad (indicando si se debe alquilar, o si es un espacio público, si se requiere tramitar permisos para su uso). Para las actividades de dotación debe realizar una lista lo más detallada posible de los elementos que se entregarán al colectivo. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info26_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Etapa</u></strong>',type: 'info',html:'<h5><b>Elija entre preinversión, inversión y operación, teniendo en cuenta que las actividades de operación son generalmente las últimas que se realizan, en tanto se encargan del mantenimiento o sostenibilidad del bien o servicio que se está generando.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info27_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Ruta Crítica</u></strong>',type: 'info',html:'<h5><b>Seleccione las actividades más importantes, es decir, aquellas sin las cuales no se puede llevar a cabo el producto. Debe elegir mínimo una para poder continuar con el ejercicio. Tenga cuidado en no marcar todas las actividades como ruta crítica, pues si considera que todas cumplen con esa característica, significa que seguramente está dejando actividades por fuera. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info28_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Costo por Año (Pesos $)</u></strong>',type: 'info',html:'<h5><b>Corresponde al costo de las actividades. Recuerde que puede que una actividad la lleve a cabo en un año, pero en el siguiente no. De esta manera, no necesariamente todas las actividades tendrán costo en cada año. Para hacer el costeo, apóyese en los referentes de las medidas de reparación (satisfacción, rehabilitación, garantías de no repetición y restitución) del programa. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info29_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Análisis de Riesgos</u></strong>',type: 'info',html:'<h5><b>Se deben identificar riesgos, en tres niveles: 1. Para el cumplimiento del objetivo general; 2. Para el cumplimiento de los productos; y 3. Para el cumplimiento de las actividades de ruta crítica. Los riesgos representan una situación negativa que puede llegar ocurrir y que puede amenazar el logro de los objetivos, productos y actividades. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info30_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Descripción del Riesgo</u></strong>',type: 'info',html:'<h5><b>Haga una descripción general del riesgo identificado.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info31_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Tipo de Riesgo</u></strong>',type: 'info',html:'<h5><b>De acuerdo con la descripción del riesgo, clasifíquela en la categoría que se encuentre más acorde con el riesgo identificado.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info32_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Probabilidad</u></strong>',type: 'info',html:'<h5><b>Teniendo en cuenta su conocimiento de la realidad del sujeto de reparación colectiva, seleccione qué tan probable es que se materialice ese riesgo. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info33_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Impacto</u></strong>',type: 'info',html:'<h5><b>Elija de la lista qué tipo de impacto se generaría sobre el desarrollo del PIRC en caso de que se materialice el riesgo identificado.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info34_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Efecto</u></strong>',type: 'info',html:'<h5><b>Son las consecuencias que se pueden generar en caso de que el riesgo se materialice. Un riesgo puede tener varios efectos sobre el PIRC. Relacione máximo tres.</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info35_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Medidas de Mitigación</u></strong>',type: 'info',html:'<h5><b>Son acciones concretas para evitar que el riesgo se materialice. Piense en acciones realizables y puntuales. Debe relacionar una por cada efecto identificado. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info36_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Análisis de Beneficios</u></strong>',type: 'info',html:'<h5><b>Son las mejoras en términos de calidad, eficiencia, disminución de costos, entre otros, que experimentará en sujeto de reparación colectiva con la implementación del PIRC. Para identificarlos, analice los FINES del árbol de objetivos. Mínimo relacione dos beneficios para el PIRC. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void btn_info37_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Nombre Beneficio</u></strong>',type: 'info',html:'<h5><b>A partir de la revisión de los fines del árbol de objetivos, otorgue un nombre al beneficio. Puede iniciar con frases como “Aumento en la calidad” “Disminución de costos” “aumento en la eficiencia”, entre otras similares. </b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }
    protected void btn_info38_Click(object sender, ImageClickEventArgs e)
    {
        string popupScript2 = "<script language='JavaScript'> Swal.fire({" +
        "title: '<strong><u>Descripción Beneficio</u></strong>',type: 'info',html:'<h5><b>Elabore un párrafo en donde describa de qué manera se podrá ver reflejado ese beneficio en el sujeto de reparación colectiva. Puede iniciar por ejemplo con frases como “Aumento en” o “Disminución de”</b></h5>', showCloseButton: true, focusConfirm: false, confirmButtonText:'Entendido!', confirmButtonAriaLabel: 'Thumbs up, great!'}" +
         ") </script> ";

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", popupScript2, false);
    }

    protected void gv_dias_cancelados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int cant = 0;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String Estado = gv.Rows[0].Cells[4].Text;


            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = false;
            }

            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta_bitacora")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_Circle")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_Circle")).Visible = false;
            }

            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta_documentos")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_Circle_documentos")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_Circle_documentos")).Visible = false;
            }

            ((LinkButton)e.Row.FindControl("Costos")).Visible = false;

            //if (Convert.ToInt32(this.id_usuario_2da_instancia.Value) == Convert.ToInt32(Session["rol"]) || 1 == Convert.ToInt32(Session["rol"])) //|| false

            cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

            for (int i = 0; i < cant; i++)
            {
                if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]) || Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == 41 || Convert.ToInt32(Session["rol"]) == 37 || Convert.ToString(Session["rol"]) == "145")
                {
                    ((LinkButton)e.Row.FindControl("Costos")).Visible = true;
                }
            }

            if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "8" || ((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "10")
            {
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block  btn-success disabled";
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CommandName = "disabled";
                e.Row.FindControl("S_EstadoDia").Visible = false;

            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "9")
            {
                if (Convert.ToInt32(Session["rol"]) != 1 && Convert.ToInt32(Session["rol"]) != 37 && Convert.ToString(Session["rol"]) != "145")
                {
                    ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block btn-danger disabled";
                    ((LinkButton)e.Row.FindControl("L_Estado_dia")).CommandName = "disabled";
                    e.Row.FindControl("S_EstadoDia").Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block btn-danger";
                }



            }


            if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "1")
            {
                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).Attributes.Add("Style", "opacity: 0.3;");

                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).Attributes.Add("Style", "opacity: 0.3;");

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).Attributes.Add("Style", "opacity: 0.3;");
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                // if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_territorio.Value))


                cant = GlobalVariables.id_usuario_territorioA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                    {

                        ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "Por_Aprobar";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).Attributes.Add("Style", "opacity: 1;");
                    }
                }
            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "2")
            {
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-success disabled";

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";

                ((ImageButton)e.Row.FindControl("actualizar_dia")).Visible = false;
                ((Label)e.Row.FindControl("Val_DiaAprobado")).Visible = true;

                if (Convert.ToInt32(Session["rol"]) == 1)
                {
                    ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default";
                    ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "Dia_denegado";
                }
            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "3")
            {
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-danger disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                // if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))

                cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]) || Convert.ToInt32(Session["rol"]) == 1)
                    {
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";
                    }
                }
                //else if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_territorio.Value))


                cant = GlobalVariables.id_usuario_territorioA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                    {
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";
                    }
                }


            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "4")
            {
                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-warning disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";

                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                ((Label)e.Row.FindControl("Pen_Aprobacion")).Visible = true;
                ((ImageButton)e.Row.FindControl("actualizar_dia")).Visible = false;


                cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
                    {
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "Dia_aprobado";
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default ";

                        ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default ";
                        ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "Dia_denegado";
                    }
                }

                //if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))
                //{

                //}




            }
            else
            {
                e.Row.FindControl("estado_dia").Visible = false;
                ((Label)e.Row.FindControl("LB_EstadoDia")).Text = "indefinido";
                // e.Row.FindControl("LB_EstadoDia").Visible = true;
            }


        }

    }

    protected void gv_dias_cancelados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Actividad_dia actividad_dia = new Actividad_dia();
        DataSet ds = new DataSet();
        GridViewRow gv51;

        try
        {
            if (e.CommandName == "Actualizar_dia")
            {
                gv5.DataSource = ViewState["ds_dias_actividad"]; //setea el color de la grilla a defautl(sin selección)
                gv5.DataBind();

                GridViewRow selectedRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int RowIndexx = Convert.ToInt32(selectedRow.RowIndex);
                gv5.Rows[RowIndexx].CssClass = "select";
                gv51 = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                //// permite consultar los dias de la actividad
                ds = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 9);

                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    TB_Fecha.Text = Convert.ToString(ds.Tables[0].Rows[0]["DIA_ACTIVIDAD"]);
                    TB_HoraInicio.Text = Convert.ToString(ds.Tables[0].Rows[0]["HORA_INICIO"]);
                    TB_HoraFin.Text = Convert.ToString(ds.Tables[0].Rows[0]["HORA_FIN"]);

                    TB_Direccion_lugar.Text = Convert.ToString(ds.Tables[0].Rows[0]["LUGAR_ACTIVIDAD"]);

                    TB_actividad_detalle.Text = Convert.ToString(ds.Tables[0].Rows[0]["DESCRIPCION_ACTIVIDAD_DETALLE"]);

                    // LD_Encuentro.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OBSERVACION_ACTIVIDAD_DIA"]);

                    string valor = (Convert.ToString(ds.Tables[0].Rows[0]["OBSERVACION_ACTIVIDAD_DIA"]));
                    int validar = 0;

                    foreach (ListItem item in LD_Encuentro.Items)
                    {
                        if (item.Text == valor)
                        {
                            //item.Selected = true;
                            LD_Encuentro.SelectedValue = item.Value;
                            validar = 1;
                            break;
                        }
                    }
                    if (validar != 1)
                    {
                        LD_Encuentro.SelectedValue = "0";
                    }

                    LD_tipo_actividad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_ACTIVIDAD"]);

                    //TB_Proyeccion.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROYECCION"]);
                    //TB_Gestion.Text = Convert.ToString(ds.Tables[0].Rows[0]["GESTION"]);
                    LD_DepartamentoDia.SelectedValue = ds.Tables[0].Rows[0]["ID_DEPARTAMENTO"].ToString();
                    LD_Departamento_Dia();
                    LD_MunicipioDia.SelectedValue = ds.Tables[0].Rows[0]["ID_MUNICIPIO"].ToString();

                    guardar_dias.Visible = false;
                    B_ActualizarDia.Visible = true;
                    B_CancelarDia.Visible = true;
                }
                else
                {
                    texto("No se ha podido cargar la información del evento, por favor reporte.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            else if (e.CommandName == "Dia_aprobado")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_V1.Text = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_Validacion.Text = "Aprobar_dia_actividad";
                texto("Al dar visto bueno a este día, en el marco de las actividades que usted desarrolla como profesional, manifiesta que ha verificado la información" +
                    "ingresada en el aplicativo MAARIV, además garantiza que las acciones relacionadas a cada uno de los participantes asistentes a la actividad," +
                    " coinciden con los documentos que se adjuntaron para este día como evidencia. Así mismo que las actividades y evidencias adjuntas dentro del" +
                    " sistema se realizaron teniendo en cuenta los procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión." +
                    "</br></br>Una vez se apruebe la revisión completa de los días, se continua con las fases de Aprobación y Reporte de las actividades y sus participantes" +
                    " a los indicadores de gestión del proceso de Reparación Integral.", 2); Mensajes_2("OBSERVACIÓN", this.L_mensaje.Text, 4);

            }
            else if (e.CommandName == "Dia_denegado")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                Actualiza_dias_actividad(3);
                //CargaGrid_archivo();
                UP_Archivos.Update();
            }
            else if (e.CommandName == "Por_Aprobar")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_Validacion.Text = "Por_Aprobar_dia_actividad";
                L_V1.Text = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                texto("Al seleccionar esta opción para este día, en el marco de las actividades que usted desarrolla como profesional, manifiesta que" +
                    "ha verificado la información ingresada en el aplicativo MAARIV, además garantiza que las acciones relacionadas a cada uno de los participantes" +
                    " asistentes a la actividad, coinciden con los documentos que se adjuntaron para este día como evidencia. Así mismo que las actividades y evidencias" +
                    " adjuntas dentro del sistema se realizaron teniendo en cuenta los procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado" +
                    " de Gestión. </br></br>" +
                    "Una vez se revise este día por el responsable a cargo, el día de esta actividad cambiará ha estado revisado.</br></br>" +
                    "Una vez se apruebe la revisión completa de los días, se continua con las fases de Aprobación y Reporte de las actividades y sus participantes" +
                    " a los indicadores de gestión del proceso de Reparación Integral.", 2); Mensajes_2("OBSERVACIÓN", this.L_mensaje.Text, 4);
            }


            if (e.CommandName == "Evidencias")
            {



                L_mensaje.Text = "";

                ViewState["consulta_archivos"] = "3";

                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value));

                ViewState["Tipo_medida"] = ((Label)gv51.FindControl("TIPO_MEDIDA_2")).Text;

                if (((Label)gv51.FindControl("TIPO_MEDIDA_2")).Text.Equals("Rehabilitacion"))
                {
                    div_medida.Visible = true;
                }
                else
                {
                    div_medida.Visible = false;
                }

                CargaGrid_archivo(0);
                L_D_Cambiar_accion();

                gv16.Columns[3].Visible = false;
                gv16.Columns[4].Visible = false;

                gv16.Columns[10].Visible = true;
                gv16.Columns[11].Visible = true;
                gv16.Columns[12].Visible = true;
                gv16.Columns[13].Visible = true;
                gv16.Columns[14].Visible = true;




                //L_D_dia_actividad_documentos.SelectedValue = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                //Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
                //adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);

                //ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);
                ////Panel252.Visible = true;
                //if (!ds.Tables[0].Rows.Count.Equals(0))
                //{
                //    Session["lista_archivos"] = ds;
                //    gv16.Visible = true;
                //    gv16.DataSource = ds;
                //    gv16.DataBind();
                //    gv16_visual();

                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                //    UP_Archivos.Update();

                //}
                //else
                //{
                //    Session["lista_archivos"] = null;
                //    gv16.Visible = false;
                //    gv16.DataSource = null;
                //    gv16.DataBind();
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                //    UP_Archivos.Update();
                //}


                gv16_visual();
            }


            if (e.CommandName == "Bitacora")
            {
                B_guardar_detalle.Visible = true;
                TB_actividad_detalle.Text = "";
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                Consulta_actividad_detalle(1);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal3", "$('#myModal3').modal();", true);
                UP_Detalle.Update();
            }

            if (e.CommandName == "Costos")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                //TB_Proyeccion.Text = ((Label)gv51.FindControl("proyeccion")).Text;
                //TB_Gestion.Text = ((Label)gv51.FindControl("gestion")).Text; 
                TB_Proyeccion.Text = "0";
                TB_Gestion.Text = "0";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal4", "$('#myModal4').modal();", true);
                Consulta_actividad_detalle(3);

                UP_Costos.Update();
            }

            if (e.CommandName == "Estado_dia")
            {
                int verifica_permisos = 0;
                int cant = 0;
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia_estado"] = Convert.ToInt32(((Label)gv51.FindControl("LB_IdEstado_dia")).Text);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                LD_Estado_dia.Enabled = true;
                TB_ObCambio.Text = "";

                L_D_Estado_dia();

                ViewState["dia_actividad_estado"] = ((Literal)gv51.FindControl("LI_Estado_dia")).Text;

                if (Convert.ToInt32(ViewState["id_actividad_estado"]) == 1)
                {
                    if (Consulta_archivos_obligatorio())
                    {

                        cant = GlobalVariables.id_usuario_territorioA.Length;

                        for (int i = 0; i < cant; i++)
                        {
                            if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                            {
                                if (BalidaCambioEstadoDoc(1)) // valida que el territorio no tenga documentos en estado "no aprobado"
                                {

                                    Consulta_actividad_detalle(4);
                                    GV_Solicitudes.Columns[0].Visible = false;
                                    Vari1.Text = "Solicitud_cambio_estado";
                                    L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> Solicitud cambio de estado </span>";
                                    L_mensaje3.Text = "Al solicitar el cambio de estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                    " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                    " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión." +
                                    " </br> </br>Puede verificar esta solicitud de cambio de estado en el área de bitácoras. ";

                                    L_Solicitud.Text = "En este momento el estado es: <strong>" + ViewState["dia_actividad_estado"] + "</strong>, usted va a solicitar el cambio de estado a:";

                                    P_ObEstado.Visible = true;



                                    if (Convert.ToString(ViewState["fase"]) == "Ruta")
                                    {
                                        LD_Estado_dia.Enabled = false;
                                        LD_Estado_dia.SelectedValue = "10";
                                    }

                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                    UpdatePanel2.Update();

                                }
                                verifica_permisos++;
                            }
                        }


                        cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                        for (int i = 0; i < cant; i++)
                        {
                            if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
                            {
                                if (BalidaCambioEstadoDoc(3)) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                                {

                                    Consulta_actividad_detalle(4);

                                    Vari1.Text = "Cambiar_estado";
                                    L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro? Cambio de estado </span>";
                                    L_mensaje3.Text = "Al cambiar el estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                    " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                    " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión.";
                                    P_ObEstado.Visible = true;

                                    L_Solicitud.Text = "En este momento el estado es: <strong>\"" + ViewState["dia_actividad_estado"] + "\"</strong>, usted va a cambiar el estado a:";

                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                    UpdatePanel2.Update();

                                }
                                verifica_permisos++;
                            }
                        }

                        if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == 37 || Convert.ToString(Session["rol"]) == "145")
                        {
                            if (true) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                            //if (BalidaCambioEstadoDoc(3)) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                            {

                                Consulta_actividad_detalle(4);

                                Vari1.Text = "Cambiar_estado";
                                L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro? Cambio de estado </span>";
                                L_mensaje3.Text = "Al cambiar el estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión.";
                                P_ObEstado.Visible = true;

                                L_Solicitud.Text = "En este momento el estado es: <strong>\"" + ViewState["dia_actividad_estado"] + "\"</strong>, usted va a cambiar el estado a:";

                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                UpdatePanel2.Update();

                            }
                            verifica_permisos++;
                        }

                        if (verifica_permisos == 0) //|| false
                        {

                            texto("El rol actual no le permite realizar cambios a los estados.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                        }

                    }
                }
                else
                {
                    texto("La fase se encuentra en estado <strong> aprobado</strong>, por lo cual no se pueden realizar cambios en los estados. ", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }


            }

            valida_permisos_rol();
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    protected void gv_dias_implementados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Actividad_dia actividad_dia = new Actividad_dia();
        DataSet ds = new DataSet();
        GridViewRow gv51;

        try
        {
            if (e.CommandName == "Actualizar_dia")
            {
                gv5.DataSource = ViewState["ds_dias_actividad"]; //setea el color de la grilla a defautl(sin selección)
                gv5.DataBind();

                GridViewRow selectedRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                int RowIndexx = Convert.ToInt32(selectedRow.RowIndex);
                gv5.Rows[RowIndexx].CssClass = "select";
                gv51 = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                actividad_dia.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                //// permite consultar los dias de la actividad
                ds = FachadaPersistencia.getInstancia().consulta_actividad_dia(actividad_dia, 9);

                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    TB_Fecha.Text = Convert.ToString(ds.Tables[0].Rows[0]["DIA_ACTIVIDAD"]);
                    TB_HoraInicio.Text = Convert.ToString(ds.Tables[0].Rows[0]["HORA_INICIO"]);
                    TB_HoraFin.Text = Convert.ToString(ds.Tables[0].Rows[0]["HORA_FIN"]);

                    TB_Direccion_lugar.Text = Convert.ToString(ds.Tables[0].Rows[0]["LUGAR_ACTIVIDAD"]);

                    TB_actividad_detalle.Text = Convert.ToString(ds.Tables[0].Rows[0]["DESCRIPCION_ACTIVIDAD_DETALLE"]);

                    // LD_Encuentro.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["OBSERVACION_ACTIVIDAD_DIA"]);

                    string valor = (Convert.ToString(ds.Tables[0].Rows[0]["OBSERVACION_ACTIVIDAD_DIA"]));
                    int validar = 0;

                    foreach (ListItem item in LD_Encuentro.Items)
                    {
                        if (item.Text == valor)
                        {
                            //item.Selected = true;
                            LD_Encuentro.SelectedValue = item.Value;
                            validar = 1;
                            break;
                        }
                    }
                    if (validar != 1)
                    {
                        LD_Encuentro.SelectedValue = "0";
                    }

                    LD_tipo_actividad.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ID_TIPO_ACTIVIDAD"]);

                    //TB_Proyeccion.Text = Convert.ToString(ds.Tables[0].Rows[0]["PROYECCION"]);
                    //TB_Gestion.Text = Convert.ToString(ds.Tables[0].Rows[0]["GESTION"]);
                    LD_DepartamentoDia.SelectedValue = ds.Tables[0].Rows[0]["ID_DEPARTAMENTO"].ToString();
                    LD_Departamento_Dia();
                    LD_MunicipioDia.SelectedValue = ds.Tables[0].Rows[0]["ID_MUNICIPIO"].ToString();

                    guardar_dias.Visible = false;
                    B_ActualizarDia.Visible = true;
                    B_CancelarDia.Visible = true;
                }
                else
                {
                    texto("No se ha podido cargar la información del evento, por favor reporte.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                }
            }
            else if (e.CommandName == "Dia_aprobado")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_V1.Text = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_Validacion.Text = "Aprobar_dia_actividad";
                texto("Al dar visto bueno a este día, en el marco de las actividades que usted desarrolla como profesional, manifiesta que ha verificado la información" +
                    "ingresada en el aplicativo MAARIV, además garantiza que las acciones relacionadas a cada uno de los participantes asistentes a la actividad," +
                    " coinciden con los documentos que se adjuntaron para este día como evidencia. Así mismo que las actividades y evidencias adjuntas dentro del" +
                    " sistema se realizaron teniendo en cuenta los procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión." +
                    "</br></br>Una vez se apruebe la revisión completa de los días, se continua con las fases de Aprobación y Reporte de las actividades y sus participantes" +
                    " a los indicadores de gestión del proceso de Reparación Integral.", 2); Mensajes_2("OBSERVACIÓN", this.L_mensaje.Text, 4);

            }
            else if (e.CommandName == "Dia_denegado")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                Actualiza_dias_actividad(3);
                //CargaGrid_archivo();
                UP_Archivos.Update();
            }
            else if (e.CommandName == "Por_Aprobar")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                L_Validacion.Text = "Por_Aprobar_dia_actividad";
                L_V1.Text = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                texto("Al seleccionar esta opción para este día, en el marco de las actividades que usted desarrolla como profesional, manifiesta que" +
                    "ha verificado la información ingresada en el aplicativo MAARIV, además garantiza que las acciones relacionadas a cada uno de los participantes" +
                    " asistentes a la actividad, coinciden con los documentos que se adjuntaron para este día como evidencia. Así mismo que las actividades y evidencias" +
                    " adjuntas dentro del sistema se realizaron teniendo en cuenta los procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado" +
                    " de Gestión. </br></br>" +
                    "Una vez se revise este día por el responsable a cargo, el día de esta actividad cambiará ha estado revisado.</br></br>" +
                    "Una vez se apruebe la revisión completa de los días, se continua con las fases de Aprobación y Reporte de las actividades y sus participantes" +
                    " a los indicadores de gestión del proceso de Reparación Integral.", 2); Mensajes_2("OBSERVACIÓN", this.L_mensaje.Text, 4);
            }


            if (e.CommandName == "Evidencias")
            {



                L_mensaje.Text = "";

                ViewState["consulta_archivos"] = "3";

                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);

                LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value));

                ViewState["Tipo_medida"] = ((Label)gv51.FindControl("TIPO_MEDIDA_2")).Text;

                if (((Label)gv51.FindControl("TIPO_MEDIDA_2")).Text.Equals("Rehabilitacion"))
                {
                    div_medida.Visible = true;
                }
                else
                {
                    div_medida.Visible = false;
                }

                CargaGrid_archivo(0);
                L_D_Cambiar_accion();

                gv16.Columns[3].Visible = false;
                gv16.Columns[4].Visible = false;

                gv16.Columns[10].Visible = true;
                gv16.Columns[11].Visible = true;
                gv16.Columns[12].Visible = true;
                gv16.Columns[13].Visible = true;
                gv16.Columns[14].Visible = true;




                //L_D_dia_actividad_documentos.SelectedValue = Convert.ToString(((Label)gv51.FindControl("id_actividad_dia")).Text);

                //Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
                //adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);

                //ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos(adjuntar_archivos, 5);
                ////Panel252.Visible = true;
                //if (!ds.Tables[0].Rows.Count.Equals(0))
                //{
                //    Session["lista_archivos"] = ds;
                //    gv16.Visible = true;
                //    gv16.DataSource = ds;
                //    gv16.DataBind();
                //    gv16_visual();

                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                //    UP_Archivos.Update();

                //}
                //else
                //{
                //    Session["lista_archivos"] = null;
                //    gv16.Visible = false;
                //    gv16.DataSource = null;
                //    gv16.DataBind();
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                //    UP_Archivos.Update();
                //}


                gv16_visual();
            }


            if (e.CommandName == "Bitacora")
            {
                B_guardar_detalle.Visible = true;
                TB_actividad_detalle.Text = "";
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                Consulta_actividad_detalle(1);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal3", "$('#myModal3').modal();", true);
                UP_Detalle.Update();
            }

            if (e.CommandName == "Costos")
            {
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                //TB_Proyeccion.Text = ((Label)gv51.FindControl("proyeccion")).Text;
                //TB_Gestion.Text = ((Label)gv51.FindControl("gestion")).Text; 
                TB_Proyeccion.Text = "0";
                TB_Gestion.Text = "0";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal4", "$('#myModal4').modal();", true);
                Consulta_actividad_detalle(3);

                UP_Costos.Update();
            }

            if (e.CommandName == "Estado_dia")
            {
                int verifica_permisos = 0;
                int cant = 0;
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["id_actividad_dia_estado"] = Convert.ToInt32(((Label)gv51.FindControl("LB_IdEstado_dia")).Text);
                ViewState["id_actividad_dia"] = Convert.ToInt32(((Label)gv51.FindControl("id_actividad_dia")).Text);
                LD_Estado_dia.Enabled = true;
                TB_ObCambio.Text = "";
                L_D_Estado_dia();

                ViewState["dia_actividad_estado"] = ((Literal)gv51.FindControl("LI_Estado_dia")).Text;

                if (Convert.ToInt32(ViewState["id_actividad_estado"]) == 1)
                {
                    if (Consulta_archivos_obligatorio())
                    {

                        cant = GlobalVariables.id_usuario_territorioA.Length;

                        for (int i = 0; i < cant; i++)
                        {
                            if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                            {
                                if (BalidaCambioEstadoDoc(1)) // valida que el territorio no tenga documentos en estado "no aprobado"
                                {

                                    Consulta_actividad_detalle(4);
                                    GV_Solicitudes.Columns[0].Visible = false;
                                    Vari1.Text = "Solicitud_cambio_estado";
                                    L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> Solicitud cambio de estado </span>";
                                    L_mensaje3.Text = "Al solicitar el cambio de estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                    " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                    " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión." +
                                    " </br> </br>Puede verificar esta solicitud de cambio de estado en el área de bitácoras. ";

                                    L_Solicitud.Text = "En este momento el estado es: <strong>" + ViewState["dia_actividad_estado"] + "</strong>, usted va a solicitar el cambio de estado a:";

                                    P_ObEstado.Visible = true;



                                    if (Convert.ToString(ViewState["fase"]) == "Ruta")
                                    {
                                        LD_Estado_dia.Enabled = false;
                                        LD_Estado_dia.SelectedValue = "10";
                                    }

                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                    UpdatePanel2.Update();

                                }
                                verifica_permisos++;
                            }
                        }


                        cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                        for (int i = 0; i < cant; i++)
                        {
                            if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
                            {
                                if (BalidaCambioEstadoDoc(3)) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                                {

                                    Consulta_actividad_detalle(4);

                                    Vari1.Text = "Cambiar_estado";
                                    L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro? Cambio de estado </span>";
                                    L_mensaje3.Text = "Al cambiar el estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                    " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                    " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión.";
                                    P_ObEstado.Visible = true;

                                    L_Solicitud.Text = "En este momento el estado es: <strong>\"" + ViewState["dia_actividad_estado"] + "\"</strong>, usted va a cambiar el estado a:";

                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                    UpdatePanel2.Update();

                                }
                                verifica_permisos++;
                            }
                        }

                        if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == 37 || Convert.ToString(Session["rol"]) == "145")
                        {
                            if (true) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                            //if (BalidaCambioEstadoDoc(3)) // valida que todos los documentos esten aprobados o que establesca el mismo estado de la actividad()
                            {

                                Consulta_actividad_detalle(4);

                                Vari1.Text = "Cambiar_estado";
                                L_Titulo3.Text = "<span class='text-warning'> <span class=\"glyphicon glyphicon-bullhorn\" aria-hidden=\"true\"></span> ¿Está seguro? Cambio de estado </span>";
                                L_mensaje3.Text = "Al cambiar el estado de este producto / actividad, usted como profesional, manifiesta que ha verificado la información" +
                                " ingresada en el aplicativo MAARIV, además garantiza que las actividades y evidencias adjuntas dentro del sistema se realizaron teniendo" +
                                " en cuenta el procedimiento y formatos estandarizados y formalizados ante el Sistema Integrado de Gestión.";
                                P_ObEstado.Visible = true;

                                L_Solicitud.Text = "En este momento el estado es: <strong>\"" + ViewState["dia_actividad_estado"] + "\"</strong>, usted va a cambiar el estado a:";

                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal5", "$('#myModal5').modal();", true);
                                UpdatePanel2.Update();

                            }
                            verifica_permisos++;
                        }

                        if (verifica_permisos == 0) //|| false
                        {

                            texto("El rol actual no le permite realizar cambios a los estados.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                        }

                    }
                }
                else
                {
                    texto("La fase se encuentra en estado <strong> aprobado</strong>, por lo cual no se pueden realizar cambios en los estados. ", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                }


            }

            valida_permisos_rol();
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    protected void gv_dias_implementados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int cant = 0;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String Estado = gv.Rows[0].Cells[4].Text;


            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_bell")).Visible = false;
            }

            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta_bitacora")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_Circle")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_Circle")).Visible = false;
            }

            if (Convert.ToInt32(((Label)e.Row.FindControl("L_Alerta_documentos")).Text) > 0)
            {
                ((Panel)e.Row.FindControl("D_Circle_documentos")).Visible = true;
            }
            else
            {
                ((Panel)e.Row.FindControl("D_Circle_documentos")).Visible = false;
            }

            ((LinkButton)e.Row.FindControl("Costos")).Visible = false;

            //if (Convert.ToInt32(this.id_usuario_2da_instancia.Value) == Convert.ToInt32(Session["rol"]) || 1 == Convert.ToInt32(Session["rol"])) //|| false

            cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

            for (int i = 0; i < cant; i++)
            {
                if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]) || Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == 41 || Convert.ToInt32(Session["rol"]) == 37 || Convert.ToString(Session["rol"]) == "145")
                {
                    ((LinkButton)e.Row.FindControl("Costos")).Visible = true;
                }
            }

            if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "8" || ((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "10")
            {


                if (Convert.ToString(Session["rol"]) != "1" && Convert.ToString(Session["rol"]) != "37" && Convert.ToString(Session["rol"]) != "145")
                {
                    ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block  btn-success disabled";
                    ((LinkButton)e.Row.FindControl("L_Estado_dia")).CommandName = "disabled";
                    e.Row.FindControl("S_EstadoDia").Visible = false;
                }
                else
                {
                    ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block  btn-success ";
                    e.Row.FindControl("S_EstadoDia").Visible = false;
                }

            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "9")
            {
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CssClass = "btn btn-block btn-danger disabled";
                ((LinkButton)e.Row.FindControl("L_Estado_dia")).CommandName = "disabled";
                e.Row.FindControl("S_EstadoDia").Visible = false;

            }


            if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "1")
            {
                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).Attributes.Add("Style", "opacity: 0.3;");

                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).Attributes.Add("Style", "opacity: 0.3;");

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).Attributes.Add("Style", "opacity: 0.3;");
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                // if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_territorio.Value))


                cant = GlobalVariables.id_usuario_territorioA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                    {

                        ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "Por_Aprobar";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).Attributes.Add("Style", "opacity: 1;");
                    }
                }
            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "2")
            {
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-success disabled";

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";

                ((ImageButton)e.Row.FindControl("actualizar_dia")).Visible = false;
                ((Label)e.Row.FindControl("Val_DiaAprobado")).Visible = true;

                if (Convert.ToInt32(Session["rol"]) == 1)
                {
                    ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default";
                    ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "Dia_denegado";
                }
            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "3")
            {
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-danger disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                // if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))

                cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]) || Convert.ToInt32(Session["rol"]) == 1)
                    {
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-default disabled";
                        ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";
                    }
                }
                //else if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_territorio.Value))


                cant = GlobalVariables.id_usuario_territorioA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_territorioA[i] == Convert.ToInt32(Session["rol"]))
                    {
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";
                    }
                }


            }
            else if (((Label)e.Row.FindControl("LB_Id_Actividad_Dia_Estado")).Text == "4")
            {
                ((LinkButton)e.Row.FindControl("PorAprobar")).CssClass = "btn btn-warning disabled";
                ((LinkButton)e.Row.FindControl("PorAprobar")).CommandName = "disabled";

                ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "disabled";
                ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default disabled";

                ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default disabled";
                ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "disabled";

                ((Label)e.Row.FindControl("Pen_Aprobacion")).Visible = true;
                ((ImageButton)e.Row.FindControl("actualizar_dia")).Visible = false;


                cant = GlobalVariables.id_usuario_2da_instanciaA.Length;

                for (int i = 0; i < cant; i++)
                {
                    if (GlobalVariables.id_usuario_2da_instanciaA[i] == Convert.ToInt32(Session["rol"]))
                    {
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CommandName = "Dia_aprobado";
                        ((LinkButton)e.Row.FindControl("AprobadoDia")).CssClass = "btn btn-default ";

                        ((LinkButton)e.Row.FindControl("DenegadoDia")).CssClass = "btn btn-default ";
                        ((LinkButton)e.Row.FindControl("DenegadoDia")).CommandName = "Dia_denegado";
                    }
                }

                //if (Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))
                //{

                //}




            }
            else
            {
                e.Row.FindControl("estado_dia").Visible = false;
                ((Label)e.Row.FindControl("LB_EstadoDia")).Text = "indefinido";
                // e.Row.FindControl("LB_EstadoDia").Visible = true;
            }


        }
    }

    protected void Btn_agregar_actividad_colectiva_Click(object sender, EventArgs e)
    {
        RB_Producto.SelectedValue = "si";
        RB_Producto_SelectedIndexChanged(sender, e);

        L_D_productos();
        if (Convert.ToInt32(ViewState["id_nombre_actividad"]) != 255)
        {
            label_medida_producto.Visible = false;
            TextBox12.Visible = false;
            label6.Visible = false;
            RB_Producto.Visible = false;
            label_tipo_medida.Visible = false;
            LD_tipo_medida.Visible = false;
            TextBox13.Text = "";
        }
        else
        {
            label_medida_producto.Visible = true;
            TextBox12.Visible = true;
            label6.Visible = true;
            RB_Producto.Visible = true;
            label_tipo_medida.Visible = true;
            LD_tipo_medida.Visible = true;
            L_D_tipo_medida();
            TextBox12.Text = "";
            TextBox13.Text = "";
        }


        B_guardar_actividad_c.Visible = true;
        B_actualizar_actividad_c.Visible = false;
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal6", "$('#myModal6').modal();", true);
        UpdatePanel5.Update();
        UP_Detalle.Update();
    }

    protected void B_guardar_actividad_c_Click(object sender, EventArgs e)
    {

        Crear_dias_actividad_colectiva();
    }

    protected void B_actualizar_actividad_c_Click(object sender, EventArgs e)
    {
        Crear_actividad_detalle(7);

    }




    protected void search_gv5_Click(object sender, EventArgs e)
    {
        string searchTerm = text_search_gv5.Text.ToLower();
        //always check if the viewstate exists before using it
        if (ViewState["gv5"] == null)
            return;
        Buscador bs = new Buscador();
        DataSet ds = new DataSet();
        //cast the viewstate as a datatable
        DataTable dt = (DataTable)ViewState["gv5"];
        //rebind the grid
        /***
         * Parametros
         * return DataTable 
         * string searchTerm, 
         * string id_ViewState, 
         * int colums_search_0, 
         * int colums_search_1, 
         * int colums_search_2
         * */
        gv5.DataSource = bs.Buscar(searchTerm, dt, 9, 10, 16);
        gv5.DataBind();

    }




    protected void reset_gv5_Click(object sender, EventArgs e)
    {
        //always check if the viewstate exists before using it
        if (ViewState["gv5"] == null)
            return;

        //cast the viewstate as a datatable
        DataTable dt = ViewState["gv5"] as DataTable;

        text_search_gv5.Text = "";

        //rebind the grid
        gv5.DataSource = dt;
        gv5.DataBind();
    }
    protected void search_gv_dias_implementados_Click(object sender, EventArgs e)
    {
        string searchTerm = text_search_gv_dias_implementados.Text.ToLower();
        //always check if the viewstate exists before using it
        if (ViewState["gv_dias_implementados"] == null)
            return;
        Buscador bs = new Buscador();
        DataSet ds = new DataSet();
        //cast the viewstate as a datatable
        DataTable dt = (DataTable)ViewState["gv_dias_implementados"];
        //rebind the grid
        /***
         * Parametros
         * return DataTable 
         * string searchTerm, 
         * string id_ViewState, 
         * int colums_search_0, 
         * int colums_search_1, 
         * int colums_search_2
         * */
        gv_dias_implementados.DataSource = bs.Buscar(searchTerm, dt, 9, 10, 16);
        gv_dias_implementados.DataBind();
    }
    protected void reset_gv_dias_implementados_Click(object sender, EventArgs e)
    {
        //always check if the viewstate exists before using it
        if (ViewState["gv_dias_implementados"] == null)
            return;

        //cast the viewstate as a datatable
        DataTable dt = ViewState["gv_dias_implementados"] as DataTable;

        text_search_gv_dias_implementados.Text = "";

        //rebind the grid
        gv_dias_implementados.DataSource = dt;
        gv_dias_implementados.DataBind();
    }
    protected void search_gv_dias_cancelados_Click(object sender, EventArgs e)
    {
        string searchTerm = text_search_gv_dias_cancelados.Text.ToLower();
        //always check if the viewstate exists before using it
        if (ViewState["gv_dias_cancelados"] == null)
            return;
        Buscador bs = new Buscador();
        DataSet ds = new DataSet();
        //cast the viewstate as a datatable
        DataTable dt = (DataTable)ViewState["gv_dias_cancelados"];
        //rebind the grid
        /***
         * Parametros
         * return DataTable 
         * string searchTerm, 
         * string id_ViewState, 
         * int colums_search_0, 
         * int colums_search_1, 
         * int colums_search_2
         * */
        gv_dias_cancelados.DataSource = bs.Buscar(searchTerm, dt, 9, 10, 16);
        gv_dias_cancelados.DataBind();
    }
    protected void reset_gv_dias_cancelados_Click(object sender, EventArgs e)
    {
        //always check if the viewstate exists before using it
        if (ViewState["gv_dias_cancelados"] == null)
            return;

        //cast the viewstate as a datatable
        DataTable dt = ViewState["gv_dias_cancelados"] as DataTable;

        text_search_gv_dias_cancelados.Text = "";

        //rebind the grid
        gv_dias_cancelados.DataSource = dt;
        gv_dias_cancelados.DataBind();

    }

    protected void gv11_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gv51;
        gv51 = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        try
        {
            if (e.CommandName == "Eliminar_bitacora")
            {

                ViewState["ID_ACTIVIDAD_DIA_BITACORA"] = Convert.ToInt32(((Label)gv51.FindControl("ID_ACTIVIDAD_DIA_BITACORA")).Text);
                Crear_actividad_detalle(8);
                UP_Detalle.Update();
                //texto("QUIERE ELIMINAR ESTA BITACORA", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            }
            if (e.CommandName == "Actualizar_bitacora")
            {
                TB_actividad_detalle.Text = Convert.ToString(((Label)gv51.FindControl("descripcion_actividad_detalle")).Text);
                ViewState["ID_ACTIVIDAD_DIA_BITACORA"] = Convert.ToInt32(((Label)gv51.FindControl("ID_ACTIVIDAD_DIA_BITACORA")).Text);
                B_guardar_detalle.Visible = false;
                B_actualizar_detalle.Visible = true;

                //gv51 = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                //ViewState["ID_ACTIVIDAD_DIA_BITACORA"] = Convert.ToInt32(((Label)gv51.FindControl("ID_ACTIVIDAD_DIA_BITACORA")).Text);
                //Crear_actividad_detalle(8);
                //UP_Detalle.Update();
                //texto("QUIERE ELIMINAR ESTA BITACORA", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            }

        }
        catch
        {
            texto("ERROR AL ELIMINAR BITACORA", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    protected void gv11_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (Convert.ToString(Session["rol"]) != "1" && Convert.ToString(Session["rol"]) != "37" && Convert.ToString(Session["rol"]) != "145")
            {
                //((ImageButton)e.Row.FindControl("btn_actualizar_Bitacora")).Visible = false;
                ((ImageButton)e.Row.FindControl("btn_eliminar_Bitacora")).Visible = false;
            }
        }
    }

    protected void btn_agregar_documento_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();

        try
        {

            adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);

            adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_Documento_admin.SelectedValue);

            if (C_B_estado_documento.Checked)
            {
                adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO = 2;
            }
            else
            {
                adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO_ESTADO = 1;
            }

            if (Convert.ToInt32(LD_tipo_Documento_admin.SelectedValue) != 0)
            {
                ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos_obligatorios(adjuntar_archivos, 4);

                LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value));
                L_D_Tipo_archivo_obligatorio();
                CargaGrid_documentos_obligatorios();
            }
            else
            {
                Mensajes("Seleccione un tipo de documento", 0);
            }

        }
        catch
        {
            Mensajes("Error al realizar la consulta de los archivos.", 0);
        }

    }

    protected void gv_documentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        GridViewRow gv51;
        try
        {
            if (e.CommandName == "Eliminar")
            {
                adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
                //adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_Documento_admin.SelectedValue);
                gv51 = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(((Label)gv51.FindControl("ID_ACTIVIDAD_DIA_TIPO_ARCHIVO")).Text);

                ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos_obligatorios(adjuntar_archivos, 3);
                LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value));
                L_D_Tipo_archivo_obligatorio();
                CargaGrid_documentos_obligatorios();

            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    protected void gv_documentos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //String Estado = gv.Rows[0].Cells[4].Text;
            //Boolean Edicion = false;

            if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value))
            {
                //Edicion = true;
            }

            //validación del estado de la actividad y roles
            //if (Estado == "ACTIVO")
            //{
            //    if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_2da_instancia.Value) || Convert.ToInt32(Session["rol"]) == Convert.ToInt32(this.id_usuario_3ra_instancia.Value))
            //    {
            //        if (Convert.ToInt32(Session["rol"]) == 1)
            //        {
            //            //e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
            //        }
            //        else
            //        {
            //            e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
            //        }

            //        e.Row.FindControl("estado_doc").Visible = true;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = false;
            //    }
            //    else
            //    {
            //        e.Row.FindControl("estado_doc").Visible = false;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = true;
            //        //e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
            //    }
            //}
            //else
            //{
            //    if (Convert.ToInt32(Session["rol"]) == 1)
            //    {
            //        e.Row.FindControl("estado_doc").Visible = true;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = false;
            //        //e.Row.FindControl("ibtnGEliminar_archivo").Visible = true;
            //    }
            //    else
            //    {
            //        e.Row.FindControl("estado_doc").Visible = false;
            //        e.Row.FindControl("LB_EstadoDoc").Visible = true;
            //        e.Row.FindControl("ibtnGEliminar_archivo").Visible = false;
            //    }
            //}

            //validación de los estados de los documentos con sus estilos

            if (((Label)e.Row.FindControl("ID_ESTADO")).Text == "2")
            {
                e.Row.FindControl("Docu_aprobado").Visible = true;
                e.Row.FindControl("Docu_NoAprobado").Visible = false;
            }
            else if (((Label)e.Row.FindControl("ID_ESTADO")).Text == "1")
            {
                e.Row.FindControl("Docu_aprobado").Visible = false;
                e.Row.FindControl("Docu_NoAprobado").Visible = true;
            }

        }
    }

    protected void gv_documentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void btn_guardar_documentos_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();




        //recorrer tabla vista 
        string str = "";
        for (int i = 0; i < gv16.Rows.Count; i++)
        {
            if (((CheckBox)gv16.Rows[i].Cells[9].FindControl("check_box")).Checked == true)
            {
                Usuario usuario = new Usuario();
                usuario.F_id_persona = Convert.ToInt32(((Label)gv16.Rows[i].FindControl("id_actividad_archivo")).Text);


                DropDownList LD_X = new DropDownList();
                LD_X = (DropDownList)gv16.Rows[i].FindControl("LD_Cambiar_accion");

                usuario.P_ID_DEPENDENCIA = Convert.ToInt32(LD_X.SelectedValue);
                usuario.F_ID_USUARIO = Convert.ToInt32(Session["id_usuario"]);


                str += " " + Convert.ToInt32(((Label)gv16.Rows[i].Cells[9].FindControl("id_actividad_archivo")).Text) + " " + usuario.P_ID_DEPENDENCIA + "FIN";

                ds = FachadaPersistencia.getInstancia().activacion_usuario_sp(usuario, 2);



                //try
                //{
                //    string returno = "";
                //    foreach (DataRow row in ds.Tables[0].Rows)
                //    {
                //        returno = Convert.ToString(row["VALIDACION"]);
                //    }
                //}
                //catch (InRowChangingEventException error)
                //{
                //    Mensajes("Algo ocurrio en el proceso, vuelve a intentar: " + error, 0);
                //}

            }

        }
        CargaGrid_archivo(2);
        L_D_Cambiar_accion();
        UP_Archivos.Update();
        Mensajes("Los documentos seleccionados se actualizaron correctamente.", 0);


    }

    public void CargaGrid_documentos_obligatorios()
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();


        try
        {


            adjuntar_archivos.P_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);

            ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos_obligatorios(adjuntar_archivos, 2);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {

                ViewState["lista_archivos_obligatorios"] = ds;
                //ViewState["gv16"] = ds.Tables[0];
                gv_documentos.Visible = true;
                gv_documentos.DataSource = ds;
                gv_documentos.DataBind();
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal2", "$('#myModal2').modal();", true);
                //UP_Archivos.Update();
            }
            else
            {
                //Session["lista_archivos"] = null;
                ViewState["lista_archivos"] = null;
                //ViewState["gv16"] = null;
                gv_documentos.Visible = false;
                gv_documentos.DataSource = null;
                gv_documentos.DataBind();

            }

        }
        catch
        {
            Mensajes("Error al realizar la consulta de los archivos.", 0);
        }
    }

    // Lista desplegable del tipo de archivo
    public void L_D_Tipo_archivo_obligatorio()
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        ds = FachadaPersistencia.getInstancia().consultar_actividad_archivos_obligatorios(adjuntar_archivos, 1);
        LD_tipo_Documento_admin.Items.Clear();


        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_tipo_Documento_admin.DataValueField = "ID_TIPO_ACTIVIDAD_ARCHIVO";
            LD_tipo_Documento_admin.DataTextField = "TIPO_ACTIVIDAD_ARCHIVO";
            LD_tipo_Documento_admin.DataSource = ds;
            LD_tipo_Documento_admin.DataBind();
            LD_tipo_Documento_admin.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
        }
        else
        {
            LD_tipo_Documento_admin.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
        }
    }
    #endregion


    #region CONTACTOS

    protected void EXCEL_Click(object sender, EventArgs e)
    {
        ReporteDirectorioSujeto();
    }
    private void Crear_Contactos(int opcion)
    {
        try
        {
            Actividad actividad = new Actividad();
            DataSet ds = new DataSet();
            int valor = 0;

            actividad.P_ENTIDAD = TB_Entidad.Text;
            actividad.P_NOMBRE = TB_Nombre.Text;
            actividad.P_CARGO = TB_Cargo.Text;
            actividad.P_TELEFONO = TB_Telefono.Text;
            actividad.P_EMAIL = TB_Mail.Text;
            actividad.P_ID_TIPO_CONTACTO_COLECTIVA = Convert.ToInt32(LD_Tipo_contacto.SelectedValue);
            actividad.P_ID_SRC = Convert.ToInt32(ViewState["id_sujeto_colectiva"]);



            // Inserta la actividad
            if (opcion == 1)
            {
                actividad.P_USUARIO_CREACION = Convert.ToInt32(Session["id_usuario"]);
                valor = FachadaPersistencia.getInstancia().Administrar_Contactos(actividad, opcion);

                if (valor != 0)
                {

                    texto("El registro se registro correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    ConsultaDirectorioSujeto();
                    TB_Entidad.Text = "";
                    TB_Nombre.Text = "";
                    TB_Cargo.Text = "";
                    TB_Telefono.Text = "";
                    TB_Mail.Text = "";
                    LD_Tipo_contacto.SelectedValue = "0";
                    ViewState["ID_DIRECTORIO"] = "0";
                }
                else
                {
                    texto("Se genero un error al registrar", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                    TB_Entidad.Text = "";
                    TB_Nombre.Text = "";
                    TB_Cargo.Text = "";
                    TB_Telefono.Text = "";
                    TB_Mail.Text = "";
                    LD_Tipo_contacto.SelectedValue = "0";
                }
            }

            // Actualiza la actividad
            if (opcion == 2)
            {
                actividad.P_ID_DIRECTORIO = Convert.ToInt32(ViewState["ID_DIRECTORIO"]);
                actividad.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);

                valor = FachadaPersistencia.getInstancia().Administrar_Contactos(actividad, opcion);

                if (valor != 0)
                {

                    texto("El registro se actualizó correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                    ConsultaDirectorioSujeto();
                    //Panel19.Visible = true;
                    TB_Entidad.Text = "";
                    TB_Nombre.Text = "";
                    TB_Cargo.Text = "";
                    TB_Telefono.Text = "";
                    TB_Mail.Text = "";
                    LD_Tipo_contacto.SelectedValue = "0";
                }
                else
                {
                    texto("Se genero un error al actualizar", 3); Mensajes_2("", this.L_mensaje.Text, 3);
                    TB_Entidad.Text = "";
                    TB_Nombre.Text = "";
                    TB_Cargo.Text = "";
                    TB_Telefono.Text = "";
                    TB_Mail.Text = "";
                    LD_Tipo_contacto.SelectedValue = "0";
                }
            }

        }
        catch
        {
            texto("Error al guardar los datos", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    protected void B_Agregar_Agregar_contacto(object sender, EventArgs e)
    {
        Panel19.Visible = true;
        Agregar_contacto.Visible = false;
        Guardar_contacto.Visible = true;
        L_D_Tipo_contacto();
        TB_Entidad.Text = "";
        TB_Nombre.Text = "";
        TB_Cargo.Text = "";
        TB_Telefono.Text = "";
        TB_Mail.Text = "";
        LD_Tipo_contacto.SelectedValue = "0";
        ViewState["ID_DIRECTORIO"] = "0";
    }

    protected void B_Guardar_contacto(object sender, EventArgs e)
    {
        Crear_Contactos(1);
        Panel19.Visible = false;
        Agregar_contacto.Visible = true;
        Actualizar_Contacto.Visible = false;
        TB_Entidad.Text = "";
        TB_Nombre.Text = "";
        TB_Cargo.Text = "";
        TB_Telefono.Text = "";
        TB_Mail.Text = "";
        LD_Tipo_contacto.SelectedValue = "0";
        ViewState["ID_DIRECTORIO"] = "0";
    }

    protected void B_Actualizar_Contacto(object sender, EventArgs e)
    {
        Crear_Contactos(2);
        Panel19.Visible = false;
        Agregar_contacto.Visible = true;
        Actualizar_Contacto.Visible = false;
        TB_Entidad.Text = "";
        TB_Nombre.Text = "";
        TB_Cargo.Text = "";
        TB_Telefono.Text = "";
        TB_Mail.Text = "";
        LD_Tipo_contacto.SelectedValue = "0";
        ViewState["ID_DIRECTORIO"] = "0";
    }

    protected void gv_directorio_sujeto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Actualizar_Directorio")
            {
                Actividad actividad = new Actividad();
                GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                actividad.P_ID_SRC = Convert.ToInt32(ViewState["id_sujeto_colectiva"]);
                ViewState["ID_DIRECTORIO"] = Convert.ToInt32(((Label)gvRow.FindControl("ID_DIRECTORIO")).Text);
                actividad.P_ID_DIRECTORIO = Convert.ToInt32(ViewState["ID_DIRECTORIO"]);
                Actualizar_Contacto.Visible = true;
                L_D_Tipo_contacto();
                Panel19.Visible = true;
                Agregar_contacto.Visible = false;
                Guardar_contacto.Visible = false;
                TB_Entidad.Text = ((Label)gvRow.FindControl("ENTIDAD")).Text;
                TB_Nombre.Text = ((Label)gvRow.FindControl("NOMBRE")).Text;
                TB_Cargo.Text = ((Label)gvRow.FindControl("CARGO")).Text;
                TB_Telefono.Text = ((Label)gvRow.FindControl("TELEFONO")).Text;
                TB_Mail.Text = ((Label)gvRow.FindControl("EMAIL")).Text;
                LD_Tipo_contacto.SelectedValue = ((Label)gvRow.FindControl("ID_TIPO_CONTACTO_COLECTIVA")).Text;
                ConsultaDirectorioSujeto2();

            }
            if (e.CommandName == "Eliminar_Directorio")
            {
                try
                {
                    Actividad actividad = new Actividad();
                    GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                    ViewState["ID_DIRECTORIO"] = Convert.ToInt32(((Label)gvRow.FindControl("ID_DIRECTORIO")).Text);
                    actividad.P_ID_DIRECTORIO = Convert.ToInt32(ViewState["ID_DIRECTORIO"]);

                    int valor = FachadaPersistencia.getInstancia().Administrar_Contactos(actividad, 3);

                    if (valor == 0)
                    {
                        texto("El registro no se eliminó debido a una inconsistencia en el sistema!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);

                    }
                    else if (valor != 0)
                    {
                        texto("El registro ha sido eliminado correctamente", 1); Mensajes_2("", this.L_mensaje.Text, 1);
                        ViewState["ID_DIRECTORIO"] = "0";
                        Panel19.Visible = false;
                        Agregar_contacto.Visible = true;
                    }

                    ConsultaDirectorioSujeto();
                }
                catch (System.Exception ex)
                {
                }
            }
        }
        catch
        {

        }


    }

    protected void B_Limpiar_contactos(object sender, EventArgs e)
    {
        TB_Entidad.Text = "";
        TB_Nombre.Text = "";
        TB_Cargo.Text = "";
        TB_Telefono.Text = "";
        TB_Mail.Text = "";
        LD_Tipo_contacto.SelectedValue = "0";
    }

    private void ConsultaDirectorioSujeto2()
    {
        try
        {
            DataSet ds = new DataSet();
            Actividad actividad = new Actividad();
            Persona persona = new Persona();

            actividad.P_ID_SRC = Convert.ToInt32(ViewState["id_sujeto_colectiva"]);
            actividad.P_ID_DIRECTORIO = Convert.ToInt32(ViewState["ID_DIRECTORIO"]);

            //if (Convert.ToInt32(ViewState["id_responsable"]) != 0)
            //{
            //    actividad.P_ID_RESPONSABLE = Convert.ToInt32(ViewState["id_responsable"]);
            //}

            //CargaGrid(1);
            //D_Sujetos.Visible = false;

            ds = FachadaPersistencia.getInstancia().Consulta_actividad(actividad, persona, 16);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                //Panel19.Visible = false;
                gv_directorio_sujeto.Visible = true;
                ViewState["lista"] = ds;
                gv_directorio_sujeto.DataSource = ds;
                gv_directorio_sujeto.DataBind();
                //Panel241.Visible = false;
                Panel14.Visible = true;
                Agregar_contacto.Visible = false;

            }
            else
            {
                ViewState["lista"] = null;
                gv_actividad.Visible = false;
                L_D_Tipo_contacto();
                //gv_directorio_sujeto.DataSource = null;
                //Panel241.Visible = false;
                Panel14.Visible = false;
                L_mensaje.Text = "";
                texto("No registran datos en el Directorio.", 2); Mensajes_2("", this.L_mensaje.Text, 2);
                Panel19.Visible = true;
                Agregar_contacto.Visible = true;
                Actualizar_Contacto.Visible = false;
                TB_Entidad.Text = "";
                TB_Nombre.Text = "";
                TB_Cargo.Text = "";
                TB_Telefono.Text = "";
                TB_Mail.Text = "";
                LD_Tipo_contacto.SelectedValue = "0";
                Guardar_contacto.Visible = true;
            }
            UpdatePanelDirectorio.Update();
            //UP_DatosEvento.Update();
        }
        catch
        {

        }
    }

    private void ReporteDirectorioSujeto()
    {
        try
        {
            DataSet ds = new DataSet();
            Actividad actividad = new Actividad();
            Persona persona = new Persona();

            actividad.P_ID_SRC = Convert.ToInt32(ViewState["id_sujeto_colectiva"]);


            ds = FachadaPersistencia.getInstancia().Consulta_actividad(actividad, persona, 17);

            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                Session["dsReportes"] = ds;
                Exportar_Excel2("Reporte_contactos");
            }
            else
            {
                Mensajes("No existen registros para el criterio de busqueda seleccionado", 0);
            }
            UpdatePanelDirectorio.Update();
            //UP_DatosEvento.Update();
        }
        catch
        {

        }
    }

    protected void Exportar_Excel2(string nombre)
    {
        DataSet ds = new DataSet();
        GridView gv1 = new GridView();

        gv1.Caption = "<B> Reporte de contactos </B> <BR> Fecha de impresión: " + (DateTime.Now.ToString().Replace(" ", "H")) + " <BR> <BR>";

        gv1.HeaderStyle.Font.Bold = true;
        gv1.HeaderStyle.ForeColor = System.Drawing.Color.White;
        gv1.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#610B0B");

        gv1.SelectedRowStyle.Font.Bold = true;
        gv1.SelectedRowStyle.ForeColor = System.Drawing.Color.CornflowerBlue;
        gv1.SelectedRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D7D7FF");

        //gv1.ShowFooter = true;
        gv1.FooterStyle.Font.Bold = true;
        gv1.FooterStyle.ForeColor = System.Drawing.Color.Black;
        gv1.FooterStyle.BackColor = System.Drawing.Color.LightSteelBlue;

        gv1.PagerStyle.ForeColor = System.Drawing.Color.White;

        gv1.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D7D7FF"); //System.Drawing.Color.LightBlue;

        // gv1.RowDataBound += new GridViewRowEventHandler(gv_reporte_RowDataBound);
        // gv1.RowCreated += new GridViewRowEventHandler(gv_reporte_RowCreated);

        ds = (DataSet)Session["dsReportes"];
        DataTable myDataTable = ds.Tables[0];
        gv1.DataSource = ds;
        gv1.DataBind();

        //para exportar sin un aspxgridview exporter
        //se debe inicializar varias clases
        try
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gv1.EnableViewState = false;
            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(gv1);

            page.RenderControl(htw);

            //le indicamos a la aplicacion que el archivo a exportar será xls
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            //Le damos el nombre al archivo que queremos que cree
            Response.AddHeader("Content-Disposition", "attachment; filename= " + nombre + "_" + Convert.ToDateTime(DateTime.Now.ToString()) + " .xls");
            Response.Charset = "UTF-8";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

            //y finalmente lo paginamos de nuevo para que quede tal como estaba
            gv1.AllowPaging = true;
            gv1.DataBind();
        }
        catch (Exception exp)
        {
            //en c# web lo mensajes en pantalla hay que realizarlos con javascript, en c# windform son por defecto asi            
            string script = @"<script language = ""JavaScript"">alert('Filtre más la información por que se sobrepaso de los 65.536 registros del excel');</script>";
            ClientScript.RegisterStartupScript(typeof(Page), "Alerta", script);
            return;
        }
    }

    public void L_D_Tipo_contacto()
    {
        //Tierras tierras = new Tierras();
        DataSet ds = new DataSet();

        ds = FachadaPersistencia.getInstancia().L_D_Tipo_Contacto(4);
        LD_Tipo_contacto.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            LD_Tipo_contacto.DataValueField = "ID_TIPO_CONTACTO_COLECTIVA";
            LD_Tipo_contacto.DataTextField = "TIPO_CONTACTO_COLECTIVA";
            LD_Tipo_contacto.DataSource = ds;
            LD_Tipo_contacto.DataBind();
            LD_Tipo_contacto.Items.Insert(0, new ListItem("Seleccione tipo de contacto", "0"));
        }
        else
        {
            LD_Tipo_contacto.Items.Insert(0, new ListItem("Seleccione tipo de contacto", "0"));
        }
    }

    #endregion

    #region Eventos adicionales

    protected void actualizar_archivo_Click1(object sender, EventArgs e)
    {
        int valor = 0;
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();

        try
        {
            int tamano = f1.FileBytes.Length;

            adjuntar_archivos.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            if ((Session["ID_ACTIVIDAD_ARCHIVO_2"] == null) || (Session["ID_ACTIVIDAD_ARCHIVO_2"].ToString() == ""))
            {
                Session["ID_ACTIVIDAD_ARCHIVO_2"] = "0";
            }
            else
            {
                adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO = Convert.ToInt32(Session["ID_ACTIVIDAD_ARCHIVO_2"]);
            }
            if (LD_MunArchivo.SelectedValue == "")
            {
                adjuntar_archivos.P_ID_MUNICIPIO = 0;
            }
            else
            {
                adjuntar_archivos.P_ID_MUNICIPIO = Convert.ToInt32(LD_MunArchivo.SelectedValue);
            }

            adjuntar_archivos.P_PERSONAS = TB_Personas.Text; // permite validar el archivo

            if (Convert.ToString(ViewState["Tipo_medida"]).Equals("Rehabilitacion"))
            {
                adjuntar_archivos.P_DESCRIPCION = LD_medida.SelectedItem.Text + "|" + LD_medida_2.SelectedItem.Text + "|" + TB_DescripcionArchivo.Text;
            }
            else
            {
                adjuntar_archivos.P_DESCRIPCION = TB_DescripcionArchivo.Text;
            }

            if (adjuntar_archivos.P_ID_ACTIVIDAD_ARCHIVO != 0)
            {
                adjuntar_archivos.P_USUARIO_MODIFICA = Convert.ToInt32(Session["id_usuario"]);
                adjuntar_archivos.P_FECHA_EXPEDICION = Convert.ToString(TB_FechaExpedicion.Text);

                if (LD_tipo_archivo.SelectedValue == "")
                {
                    adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = 0;
                }
                else
                {
                    adjuntar_archivos.P_ID_TIPO_ACTIVIDAD_ARCHIVO = Convert.ToInt32(LD_tipo_archivo.SelectedValue);
                }

                valor = FachadaPersistencia.getInstancia().Administrar_actividad_archivos(adjuntar_archivos, 7);
            }
            if (valor != 0)
            {
                texto("El registro se actualizó correctamente!.", 1); Mensajes_2("", this.L_mensaje.Text, 1);

            }
            else
            {
                texto("Se genero un error al actualizar!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);

            }
            LD_MunArchivo.Enabled = true;
            LD_DepArchivo.Enabled = true;
            TB_DescripcionArchivo.Enabled = true;
            TB_Personas.Enabled = true;

            LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value));
            L_D_Tipo_archivo_obligatorio();

            CargaGrid_archivo(0);
            CargaGrid_documentos_obligatorios();
            L_D_Cambiar_accion();

            gv16.Columns[3].Visible = false;
            gv16.Columns[4].Visible = false;

            gv16.Columns[10].Visible = true;
            gv16.Columns[11].Visible = true;
            gv16.Columns[12].Visible = true;
            gv16.Columns[13].Visible = true;
            gv16.Columns[14].Visible = true;

            if (Convert.ToInt32(Session["rol"]) == 1 || Convert.ToString(Session["rol"]) == "37" || Convert.ToString(Session["rol"]) == "145")
            {
                Panel17.Visible = true;
                Panel18.Visible = true;
                div_admin_documentos.Visible = true;
            }
            gv16_visual();
            guardar_archivo.Visible = true;
            actualizar_archivo.Visible = false;
            TB_FechaExpedicion.Text = "";

            LD_tipo_archivo.SelectedValue = "0";
            LD_DepArchivo.SelectedValue = "0";
            // municipio por territorial
            LD_MunArchivo.ClearSelection();
            TB_DescripcionArchivo.Text = "";
            TB_Personas.Text = "";

        }
        catch (Exception ex)
        {
            texto("Ocurrió un error al guardar los datos!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void B_CambiarEstadoActividad_Click(object sender, EventArgs e)
    {

        AdministraFases(3);

        string[] datos = {
                                         Convert.ToString(ViewState["sujeto_colectiva"]),
                                         Convert.ToString(ViewState["id_actividad_dia"]),
                                         Convert.ToString(ViewState["fase"]),
                                         Convert.ToString(ViewState["actividad_estado"]),
                                         Convert.ToString(LD_Estado_actividad.SelectedItem),
                                         Convert.ToString(TextBox14.Text)
                                     };
        try
        {

            //CAMBIO ALEJANDRO GRILLA ACTIVIDAD_DETALLE
            DataSet ds_detalle = new DataSet();
            Actividad_detalle actividad_detalle = new Actividad_detalle();
            actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);

            if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 47)
            {
                actividad_detalle.P_ID_TIPO_ACTIVIDAD = 896;
            }
            else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 48)
            {
                actividad_detalle.P_ID_TIPO_ACTIVIDAD = 897;
            }
            else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 49)
            {
                actividad_detalle.P_ID_TIPO_ACTIVIDAD = 898;
            }
            else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 50)
            {
                actividad_detalle.P_ID_TIPO_ACTIVIDAD = 899;
            }
            else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 51)
            {
                actividad_detalle.P_ID_TIPO_ACTIVIDAD = 900;
            }
            else if (Convert.ToInt32(ViewState["id_nombre_actividad"]) == 255)
            {
                actividad_detalle.P_ID_TIPO_ACTIVIDAD = 901;
            }


            // permite consultar las actividades
            ds_detalle = FachadaPersistencia.getInstancia().Consulta_actividad_detalle(actividad_detalle, 1);
            if (!ds_detalle.Tables[0].Rows.Count.Equals(0))
            {
                ViewState["ds_detalle"] = ds_detalle;
                gv_actividad_detalle.DataSource = ds_detalle;
                gv_actividad_detalle.DataBind();
                gv_actividad_detalle.Visible = true;
            }
            else
            {
                ViewState["ds_detalle"] = null;
                gv_actividad_detalle.DataSource = null;
                gv_actividad_detalle.DataBind();
                gv_actividad_detalle.Visible = true;
            }
            //FIN CAMBIO ALEJANDRO
            UpdatePanel6.Update();

            Crear_correo(
                ((DataSet)ViewState["actividad_responsable"]),          //correos-send
                "Maariv - Colectiva - Cambio Estado fase",                   //asunto
                datos,                                                   //datos
                5,                                                      //opcion colectica
                0
            );

        }
        catch (Exception ex)
        {
            //texto("Correo ok!.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
        TextBox14.Text = "";


    }

    protected void B_actualizar_obserEstSuj_Click(object sender, EventArgs e)
    {
        Crear(2);
        CargaGrid(1);
        gv_visual();
    }

    //protected void check_medida_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (check_medida.Checked == true)
    //    {
    //        div_medida.Visible = true;
    //        Descripcion_archivo_div.Visible = false;
    //        LD_tipo_archivo.Items.Clear();
    //        LD_tipo_archivo.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
    //        LD_tipo_archivo.Items.Insert(1, new ListItem("IM-INFORME DETALLADO", "523"));
    //        LD_tipo_archivo.Items.Insert(2, new ListItem("IM-REGISTRO FOTOGRAFICO", "869"));
    //        LD_tipo_archivo.Items.Insert(3, new ListItem("IM-LISTADOS DE ASISTENCIA", "591"));
    //        //LD_medida_2.Visible = true;
    //    }
    //    else
    //    {
    //        div_medida.Visible = false;
    //        Descripcion_archivo_div.Visible = true;
    //        LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value)); //aca
    //        //LD_medida_2.Visible = false;
    //    }
    //}

    protected void RB_Tipo_actividad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ViewState["TIPO_ACTIVIDAD_ENTRELAZANDO"].ToString().Equals("Rehabilitación"))
        {
            if (RB_Tipo_actividad.SelectedValue == "Rehabilitacion")
            {
                div_medida.Visible = false;
                Descripcion_archivo_div.Visible = true;
                LD_Tipo_archivo(Convert.ToInt32(ViewState["id_actividad_dia"]), Convert.ToInt32(this.opcion_tipo_archivo.Value)); //aca

            }
            else if (RB_Tipo_actividad.SelectedValue == "Entrelazando")
            {
                div_medida.Visible = true;
                Descripcion_archivo_div.Visible = false;
            }

        }
        else if (ViewState["TIPO_ACTIVIDAD_ENTRELAZANDO"].ToString().Contains("5."))
        {
            div_medida.Visible = true;
            Descripcion_archivo_div.Visible = false;


        }
    }

    protected void gv_PreRender(object sender, EventArgs e)
    {
        if (gv.Rows.Count > 0)
        {
            //gv.CssClass = "table table-striped table-bordered gvv0";


            gv.HeaderRow.Cells[0].Attributes["data-priority"] = "1";
            gv.HeaderRow.Cells[1].Attributes["data-priority"] = "2";
            gv.HeaderRow.Cells[2].Attributes["data-priority"] = "2";
            //gv.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet,pc";
            gv.HeaderRow.Cells[3].Attributes["data-priority"] = "1";
            gv.HeaderRow.Cells[4].Attributes["data-priority"] = "2";
            gv.HeaderRow.Cells[5].Attributes["data-priority"] = "3";
            gv.HeaderRow.Cells[6].Attributes["data-priority"] = "3";
            gv.HeaderRow.Cells[7].Attributes["data-priority"] = "3";
            gv.HeaderRow.Cells[8].Attributes["data-priority"] = "3";
            //gv.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet,pc";
            gv.HeaderRow.Cells[9].Attributes["data-priority"] = "3";
            gv.HeaderRow.Cells[10].Attributes["data-priority"] = "3";
            gv.HeaderRow.Cells[11].Attributes["data-priority"] = "1";

            //This replaces <td> with <th> and adds the scope attribute
            gv.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;

            //This adds the <tfoot> element. 
            //Remove if you don't have a footer row
            gv.FooterRow.TableSection = TableRowSection.TableFooter;


        }
        if (gv.Rows.Count == 1)
        {
            //gv.CssClass = "table table-striped table-bordered gvv3";
        }

    }

    protected void gv16_PreRender(object sender, EventArgs e)
    {
        if (gv16.Rows.Count > 0)
        {
            //gv.CssClass = "table table-striped table-bordered gvv0";


            gv16.HeaderRow.Cells[0].Attributes["data-priority"] = "1";
            gv16.HeaderRow.Cells[1].Attributes["data-priority"] = "2";
            gv16.HeaderRow.Cells[2].Attributes["data-priority"] = "2";
            //gv.HeaderRow.Cells[1].Attributes["data-hide"] = "phone,tablet,pc";
            gv16.HeaderRow.Cells[3].Attributes["data-priority"] = "1";
            gv16.HeaderRow.Cells[4].Attributes["data-priority"] = "2";
            gv16.HeaderRow.Cells[5].Attributes["data-priority"] = "3";
            gv16.HeaderRow.Cells[6].Attributes["data-priority"] = "3";
            gv16.HeaderRow.Cells[7].Attributes["data-priority"] = "3";
            gv16.HeaderRow.Cells[8].Attributes["data-priority"] = "1";
            //gv.HeaderRow.Cells[10].Attributes["data-hide"] = "phone,tablet,pc";
            gv16.HeaderRow.Cells[9].Attributes["data-priority"] = "3";
            gv16.HeaderRow.Cells[10].Attributes["data-priority"] = "3";
            gv16.HeaderRow.Cells[11].Attributes["data-priority"] = "3";
            gv16.HeaderRow.Cells[19].Attributes["data-priority"] = "1";
            gv16.HeaderRow.Cells[20].Attributes["data-priority"] = "1";
            //gv16.HeaderRow.Cells[21].Attributes["data-priority"] = "1";

            //This replaces <td> with <th> and adds the scope attribute
            gv16.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            gv16.HeaderRow.TableSection = TableRowSection.TableHeader;

            //This adds the <tfoot> element. 
            //Remove if you don't have a footer row
            gv16.FooterRow.TableSection = TableRowSection.TableFooter;


        }
        if (gv.Rows.Count == 1)
        {
            //gv.CssClass = "table table-striped table-bordered gvv3";
        }

    }

    protected void RB_Producto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RB_Producto.SelectedValue == "si")
        {
            label5.Visible = false;
            LD_productos.Visible = false;
            label_medida_producto.Visible = true;
            TextBox12.Visible = true;

        }
        else if (RB_Producto.SelectedValue == "no")
        {
            label5.Visible = true;
            LD_productos.Visible = true;
            label_medida_producto.Visible = false;
            TextBox12.Visible = false;
        }
    }

    #endregion

    #region ACTIVIDAD_DIA_ENCUESTA


    protected void LV_Informe_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem) // ojo esta modificando solo una vez por lo que esta en header
        {
            try
            {
                string TipoPregunta = ((Label)e.Item.FindControl("L_AdepTipo")).Text;

                if (TipoPregunta == "1" || TipoPregunta == "2")
                {
                    ConsultaRespuesta(Convert.ToInt32(((Label)e.Item.FindControl("L_IdAdep")).Text), e);
                }

                if (((Label)e.Item.FindControl("L_AdepTipo")).Text == "10")
                {
                    string pair = ((Label)e.Item.FindControl("L_pregunta")).Text;
                    int position = pair.IndexOf("|");
                    ((Literal)e.Item.FindControl("Li_Titulo")).Text = String.Format("<h2> {0} <small> {1} </small></h2>", pair.Substring(0, position), pair.Substring(position + 1));
                }

            }
            catch (System.Exception ex)
            {
                texto("Error al cargar la encuesta", 3); Mensajes_2("", this.L_mensaje.Text, 3);
            }
        }
    }

    protected void LB_GuardarInforme_Click(object sender, EventArgs e)
    {
        GuardarEncuestaDia();
    }

    public void ConsultaRespuesta(int id_pregunta, ListViewItemEventArgs e)
    {

        try
        {
            Actividad_dia_encuesta_pregunta ADEP = new Actividad_dia_encuesta_pregunta();
            ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = id_pregunta;
            DataSet ds_encuesta_pregunta_respuesta = new DataSet();
            ds_encuesta_pregunta_respuesta = FachadaPersistencia.getInstancia().actividad_dia_encuesta_pregunta(ADEP, 24); ;

            if (((Label)e.Item.FindControl("L_AdepTipo")).Text.Equals("1"))
            {
                DropDownList LD_Respueta = new DropDownList();
                LD_Respueta = (DropDownList)e.Item.FindControl("LD_Respueta");
                if (!ds_encuesta_pregunta_respuesta.Tables[0].Rows.Count.Equals(0))
                {

                    foreach (DataRow item in ds_encuesta_pregunta_respuesta.Tables[0].Rows)
                    {
                        LD_Respueta.Items.Insert(0, new ListItem(Convert.ToString(item["ACTIVIDAD_DIA_ENCUESTA_RESPUESTA"]), Convert.ToString(item["ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"])));

                    }

                    LD_Respueta.Items.Insert(0, new ListItem("Seleccione", "0"));

                }
                else
                {
                    LD_Respueta.Items.Insert(0, new ListItem("Seleccione", "0"));
                }
            }
            else if (((Label)e.Item.FindControl("L_AdepTipo")).Text.Equals("2"))
            {

                if (!ds_encuesta_pregunta_respuesta.Tables[0].Rows.Count.Equals(0))
                {
                    Label L_IdRespuestaA = new Label();
                    L_IdRespuestaA = (Label)e.Item.FindControl("L_IdRespuestaA");

                    L_IdRespuestaA.Text = ds_encuesta_pregunta_respuesta.Tables[0].Rows[0]["ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].ToString();
                }
            }

            ConsultaSolucion(id_pregunta, e);

        }
        catch (System.Exception ex)
        {
            texto(string.Format("Error al realizar Error al cargar respuesta de la pregunta ({0})", id_pregunta), 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    public void ConsultaActividadDiaEncuestaPreguntas(GridViewRow gv51)
    {
        try
        {
            DataSet ds_encuesta_pregunta_respuesta = new DataSet();
            Actividad_dia_encuesta_pregunta ADEP = new Actividad_dia_encuesta_pregunta();

            //ADEP.F_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]) ;
            //ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO = 100 + Convert.ToInt32(((Label)gv51.FindControl("ObservacionDia")).Text.Replace("Momento_", ""));

            ADEP.F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO = 1000 + Convert.ToInt32(ViewState["id_nombre_actividad"]);


            ds_encuesta_pregunta_respuesta = FachadaPersistencia.getInstancia().actividad_dia_encuesta_pregunta(ADEP, 23);
            if (ds_encuesta_pregunta_respuesta.Tables[0].Rows.Count != 0)
            {
                LV_Informe.DataSource = ds_encuesta_pregunta_respuesta;
                LV_Informe.DataBind();
                LV_Informe.Visible = true;
                ConsultaProgreso();
            }
            else
            {
                LV_Informe.DataSource = null;
                LV_Informe.DataBind();
                LV_Informe.Visible = false;
                LB_GuardarInforme.Visible = false;
            }
        }
        catch (Exception ex)
        {
            texto("Error al consultar las preguntas.", 3);
            Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }

    public void ConsultaSolucion(int id_pregunta, ListViewItemEventArgs e)
    {
        try
        {
            Actividad_dia_encuesta_pregunta ADEP = new Actividad_dia_encuesta_pregunta();
            ADEP.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = id_pregunta;
            ADEP.F_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);
            DataSet ds_solucion = new DataSet();

            DropDownList LD_Respueta = new DropDownList();
            LD_Respueta = (DropDownList)e.Item.FindControl("LD_Respueta");

            TextBox TB_RespuestaAbierta = new TextBox();
            TB_RespuestaAbierta = (TextBox)e.Item.FindControl("TB_RespuestaAbierta");

            Literal L_Respuesta = new Literal();
            L_Respuesta = (Literal)e.Item.FindControl("L_Respuesta");

            ds_solucion = FachadaPersistencia.getInstancia().actividad_dia_encuesta_pregunta(ADEP, 25); ;

            //llena la respuesta
            if (!ds_solucion.Tables[0].Rows.Count.Equals(0))
            {
                if (((Label)e.Item.FindControl("L_AdepTipo")).Text.Equals("1"))
                {
                    LD_Respueta.SelectedValue = ds_solucion.Tables[0].Rows[0]["ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA"].ToString();

                    L_Respuesta.Text = string.Format("<strong>Respuesta: </strong> {0}", LD_Respueta.SelectedItem);

                }
                else if (((Label)e.Item.FindControl("L_AdepTipo")).Text.Equals("2"))
                {
                    TB_RespuestaAbierta.Text = ds_solucion.Tables[0].Rows[0]["ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION"].ToString();
                    L_Respuesta.Text = string.Format("<strong>Respuesta: </strong> {0}", TB_RespuestaAbierta.Text);

                }

                Label L_TieneRespuesta = new Label();
                L_TieneRespuesta = (Label)e.Item.FindControl("L_TieneRespuesta");
                L_TieneRespuesta.Text = "1";
            }

            //si el estado del dia es bloqueado bloqueo las respuestas 
            //if (ViewState["id_actividad_dia_estado"].ToString() != "1" && ViewState["id_actividad_dia_estado"].ToString() != "3")
            //{
            //    LD_Respueta.Visible = false;
            //    TB_RespuestaAbierta.Visible = false;

            //    L_Respuesta.Visible = true;

            //}



        }
        catch (Exception ex)
        {

            texto("Error al cargar la solución", 3); Mensajes_2("", this.L_mensaje.Text, 3);

        }

    }

    public void GuardarEncuestaDia()
    {
        try
        {
            int conteo = 0;
            DataSet ds = new DataSet();


            foreach (ListViewItem item in LV_Informe.Items)
            {
                string id_tipo_pregunta = ((Label)item.FindControl("L_AdepTipo")).Text;

                //id_tipo_pregunta = 1 -> lista desplegable
                //id_tipo_pregunta = 2 -> caja de texto
                //id_tipo_pregunta = 10 -> es un titulo

                DropDownList LD_Respueta = new DropDownList();
                LD_Respueta = (DropDownList)item.FindControl("LD_Respueta");
                TextBox TB_RespuestaAbierta = new TextBox();
                TB_RespuestaAbierta = (TextBox)item.FindControl("TB_RespuestaAbierta");


                if (id_tipo_pregunta.Equals("1") || id_tipo_pregunta.Equals("2"))//para guardar solo lista o caja
                {
                    Actividad_dia_encuesta_solucion ADES = new Actividad_dia_encuesta_solucion();

                    ADES.F_ID_ACTIVIDAD_DIA = Convert.ToInt32(ViewState["id_actividad_dia"]);

                    if (id_tipo_pregunta.Equals("1")) //guardar item de la lista
                    {
                        ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA = Convert.ToInt32(LD_Respueta.SelectedValue);
                        ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION = "";
                    }
                    else if (id_tipo_pregunta.Equals("2")) //guardar item de caja de texto
                    {

                        ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA = Convert.ToInt32(((Label)item.FindControl("L_IdRespuestaA")).Text); //180 id_respuesta para respuesta abierta
                        ADES.F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION = TB_RespuestaAbierta.Text;
                    }

                    ADES.F_USUARIO_INTERACCION = Convert.ToInt32(Session["id_usuario"]);

                    if ((id_tipo_pregunta.Equals("1") && !LD_Respueta.SelectedValue.Equals("0")) ||
                         (id_tipo_pregunta.Equals("2") && !TB_RespuestaAbierta.Text.Equals(""))
                        )
                    {
                        if (((Label)item.FindControl("L_TieneRespuesta")).Text.Equals("1"))
                        {
                            ds = FachadaPersistencia.getInstancia().administrar_acti_dia_encuesta_solucion(ADES, 2); //actualiza
                        }
                        else
                        {
                            ds = FachadaPersistencia.getInstancia().administrar_acti_dia_encuesta_solucion(ADES, 1);//inserta
                        }

                        ((Label)item.FindControl("L_TieneRespuesta")).Text = "1";

                    }

                    conteo++;
                }
            }

            //recargar la pantalla falta

            if (conteo > 0)
            {
                texto("La encuesta se guardó y/o se actualizo correctamente ", 1);
                Mensajes_2("Encuesta", this.L_mensaje.Text, 1);
                ConsultaProgreso();
            }
            else
            {
                texto("No se han realizado actualizaciones .", 2);
                Mensajes_2("Encuesta", this.L_mensaje.Text, 2);
            }

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal3", "$('#myModal3').hide();", true);

        }
        catch (Exception ex)
        {
            texto("Error al guardar la encuesta, por favor inténtelo más tarde o reporte el error. ", 2);
            Mensajes_2("Encuesta", this.L_mensaje.Text, 3);
        }
        finally
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal3", "$('#myModal3').modal('hide');", true);
        }
    }


    public void ConsultaProgreso()
    {
        int preguntas = 0;
        int resObli = 0;
        int progreso = 0;
        foreach (ListViewItem item in LV_Informe.Items)
        {
            if (((Label)item.FindControl("L_PreObli")).Text.Equals("1") && !((Label)item.FindControl("L_AdepTipo")).Text.Equals("10"))
            {
                preguntas++;
            }

            if (((Label)item.FindControl("L_TieneRespuesta")).Text.Equals("1"))
            {
                resObli++;
            }
        }

        progreso = (resObli * 100) / preguntas;

        string clase = progreso <= 50 ? " progress-bar-danger" : progreso <= 90 ? " progress-bar-warning" : " progress-bar-success";

        Li_Prosgress.Text = String.Format("<div class=\"progress \"> <div class=\"progress-bar {0}\" role=\"progressbar\" aria-valuenow=\"{1}\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"min-width: 2em;width: {1}%;\">{1}%</div></div>",
           clase, progreso);

    }
    #endregion


    #region DESARROLLO LILIANA  
    protected void gv_entidades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        try
        {
            if (e.CommandName == "Eliminar")
            {
                EliminarEntidadQueAcompanaElTraslado(e);
            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_entidades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void gv_entidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gv_entidades_caracterizacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        try
        {
            if (e.CommandName == "Eliminar")
            {
                EliminarEntidadCaracterizacion(e);
            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_entidades_caracterizacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void gv_entidades_caracterizacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gv_categoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        try
        {
            if (e.CommandName == "AgregarEntidadesResponsablesCaracterizacion")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["idHogar"] = Convert.ToInt32(gv_inventario_traslado.DataKeys[gvRow.RowIndex].Values[0].ToString());
                int idCaracterizacion = Convert.ToInt32(((Label)gvRow.FindControl("idCaracterizacion")).Text);
                ViewState["idCategoria"] = idCaracterizacion;
                string Caracterizacion = ((Label)gvRow.FindControl("Caracterizacion")).Text;
                lblCaracterizacion.Text =  Caracterizacion;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalEntidadesCaractizacion", "$('#myModalEntidadesCaractizacion').modal();", true);
                UpdatePanelCaracterizacionEntidades.Update();
                Get_Entidades_Plan_Accion_Traslado_Ctegorias_Entidad();
            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_categoria_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtResultado = (TextBox)e.Row.FindControl("RESULTADO");
            DataRow drGV = ((DataRowView)e.Row.DataItem).Row;
            txtResultado.Text = drGV["RESULTADO"].ToString();

            TextBox txtAcciones = (TextBox)e.Row.FindControl("ACCIONES");
            DataRow drGVAcciones = ((DataRowView)e.Row.DataItem).Row;
            txtAcciones.Text = drGVAcciones["ACCIONES"].ToString();

            TextBox txtObservaciones = (TextBox)e.Row.FindControl("OBSERVACIONES");
            DataRow drGVObservaciones = ((DataRowView)e.Row.DataItem).Row;
            txtObservaciones.Text = drGVObservaciones["OBSERVACIONES"].ToString();
        }
    }
    protected void gv_categoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gv_noTrasladar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        try
        {

        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_noTrasladar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void gv_noTrasladar_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gv_balancale_traslado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        try
        {
            if (e.CommandName == "Eliminar")
            {
                EliminarBalanceTraslado(e);
            }
            if (e.CommandName == "Editar")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                txActividad.Text= ((Label)gvRow.FindControl("actividad")).Text;
                txResponsable.Text= ((Label)gvRow.FindControl("responsable")).Text;
                txObservaciones.Text = ((Label)gvRow.FindControl("observaciones")).Text;
                LD_Cumplido.Items.Clear();
                LD_Cumplido.Items.Insert(0, new ListItem("Si", "True"));
                LD_Cumplido.Items.Insert(1, new ListItem("No", "False"));
                LD_Cumplido.SelectedValue = ((Label)gvRow.FindControl("cumplida")).Text;
                ViewState["idBalanceTraslado"] = ((Label)gvRow.FindControl("idbalance")).Text;
            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_balancale_traslado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void gv_balancale_traslado_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }   
    protected void gv_profesionales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        Adjuntar_archivos_act adjuntar_archivos = new Adjuntar_archivos_act();
        try
        {
            if (e.CommandName == "Eliminar")
            {
                EliminarProsional(e);
            }
            if (e.CommandName == "Editar")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                txNombresProfesionalRealiza.Text = ((Label)gvRow.FindControl("profesional")).Text;
                txTelefonoProfesionalRegistra.Text = ((Label)gvRow.FindControl("telefono")).Text;
                txCorreoProfesionalRegistroAlistamiento.Text = ((Label)gvRow.FindControl("correo")).Text;
                LD_EntidadProfesionalRegistra.SelectedValue = ((Label)gvRow.FindControl("idEntidad")).Text;
                ViewState["idProfesionalRegistra"] = ((Label)gvRow.FindControl("id")).Text;
            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_profesionales_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
    protected void gv_profesionales_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gv_inventario_traslado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (e.CommandName == "AgregarEnseres")
            {
                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                ViewState["idHogar"] = Convert.ToInt32(gv_inventario_traslado.DataKeys[gvRow.RowIndex].Values[0].ToString());
                string representante = ((Label)gvRow.FindControl("representante")).Text;
                lblReprentante.Text = representante;
                Get_plan_acción_traslado_Inventario_hogar_enseres_ruta_comunitaria();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalEnseres", "$('#myModalEnseres').modal();", true);
                UpdatePanelInventarioEnseres.Update();
            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_inventario_traslado_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtResultado = (TextBox)e.Row.FindControl("RESULTADO");
            DataRow drGV = ((DataRowView)e.Row.DataItem).Row;

        }
    }
    protected void gv_inventario_traslado_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gv_personas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (e.CommandName == "seleccionar")
            {

                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string numDocumento = ((Label)gvRow.FindControl("DOCUMENTO")).Text;
                bool seTraslada = true;
                bool exitoso = FachadaPersistencia.getInstancia().LD_Modificar_Persona_trasladar_plan_acción_traslado_ruta_comunitaria( numDocumento,  seTraslada);
                if (exitoso) {
                    Get_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria();
                }
                else
                {
                    Mensajes("No se realizo la operación.", 0);
                }                             
            }
        }
        catch
        {
            texto("No se ha podido realizar el evento requerido.", 3); Mensajes_2("", this.L_mensaje.Text, 3);
        }
    }
    protected void gv_personas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }
    protected void gv_personas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }


    public void GetPlanTraslado()
    {
        DataSet dsPT = new DataSet();
        int idComunidad = Convert.ToInt32(TB_Nit.Text);
        dsPT = FachadaPersistencia.getInstancia().GetPlanTrasladoPorComunidad(idComunidad);
        if (!dsPT.Tables[0].Rows.Count.Equals(0))
        {
            txTotalHogares.Text = dsPT.Tables[0].Rows[0]["TOTAL_HOGARES_TRASLADAR"].ToString();
            txTotalPersonas.Text = dsPT.Tables[0].Rows[0]["TOTAL_PERSONAS_TRASLADAR"].ToString();
            txTotalRUV.Text = dsPT.Tables[0].Rows[0]["TOTAL_PERSONAS_TRASLADAR_RUV"].ToString();
            txCorregimiento_Salida.Text = dsPT.Tables[0].Rows[0]["CORREGIMIENTO_SALIDA"].ToString();
            txCorregimiento_Llegada.Text = dsPT.Tables[0].Rows[0]["CORREGIMIENTO_LLEGADA"].ToString();
            LD_Departamento_Salida.SelectedValue = dsPT.Tables[0].Rows[0]["ID_DEPARTAMENTO_SALIDA"].ToString();
            LlenarComboMunicipioSalida(Convert.ToInt32(dsPT.Tables[0].Rows[0]["ID_DEPARTAMENTO_SALIDA"]));
            LD_Municipio_Salida.SelectedValue = dsPT.Tables[0].Rows[0]["ID_MUNICIPIO_SALIDA"].ToString();
            LD_Departamento_Llegada.SelectedValue = dsPT.Tables[0].Rows[0]["ID_DEPARTAMENTO_LLEGADA"].ToString();
            LlenarComboMunicipioLlegada(Convert.ToInt32(dsPT.Tables[0].Rows[0]["ID_DEPARTAMENTO_LLEGADA"]));
            LD_Municipio_Llegada.SelectedValue = dsPT.Tables[0].Rows[0]["ID_MUNICIPIO_LLEGADA"].ToString();

            LD_Entorno_Salida.SelectedValue = dsPT.Tables[0].Rows[0]["ID_ENTORNO_SALIDA"].ToString();
            LD_Entorno_Llegada.SelectedValue = dsPT.Tables[0].Rows[0]["ID_ENTORNO_LLEGADA"].ToString();

            idPlanAccionTraslado.Value = dsPT.Tables[0].Rows[0]["ID_PLAN_ACCION_TRASLADO"].ToString();
            ViewState["idPlanAccionTraslado"] = dsPT.Tables[0].Rows[0]["ID_PLAN_ACCION_TRASLADO"];
        }
    }
    public void Get_Tipo_Evidencia()
    {
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().Get_Tipo_Evidencia();
    }
    public void GetCategoria_plan_acción_traslado_Ruta_Comunitaria()
    {
        int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().Get_Consultar_Categoria_plan_acción_traslado_Ruta_Comunitaria(idPlan);
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            gv_categoria.Visible = true;
            gv_categoria.DataSource = dsPE;
            gv_categoria.DataBind();
        }
        else
        {
            gv_categoria.Visible = false;
            gv_categoria.DataSource = dsPE;
            gv_categoria.DataBind();
        }
    }
    public void Get_plan_acción_traslado_balance_traslado_ruta_comunitaria()
    {
        int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().Get_plan_acción_traslado_balance_traslado_ruta_comunitaria(idPlan);
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            gv_balancale_traslado.Visible = true;
            gv_balancale_traslado.DataSource = dsPE;
            gv_balancale_traslado.DataBind();
        }
        else
        {
            gv_balancale_traslado.Visible = false;
            gv_balancale_traslado.DataSource = dsPE;
            gv_balancale_traslado.DataBind();
        }
    }
    public void Get_plan_acción_traslado_profesionales_traslado_ruta_comunitaria()
    {
        int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().Get_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(idPlan);
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            gv_profesionales.Visible = true;
            gv_profesionales.DataSource = dsPE;
            gv_profesionales.DataBind();
        }
        else
        {
            gv_profesionales.Visible = false;
            gv_profesionales.DataSource = dsPE;
            gv_profesionales.DataBind();
        }
    }
    public void Get_Entidades_Plan_Accion_Traslado_Entidad()
    {
        int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().Get_Entidades_Plan_Accion_Traslado_Entidad(idPlan);
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            gv_entidades.Visible = true;
            gv_entidades.DataSource = dsPE;
            gv_entidades.DataBind();
        }
        else
        {
            gv_entidades.Visible = false;
            gv_entidades.DataSource = dsPE;
            gv_entidades.DataBind();
        }
    }
    public void Get_plan_acción_traslado_Inventario_hogar_ruta_comunitaria()
    {
        DataSet dsPT = new DataSet();
        int idComunidad = Convert.ToInt32(TB_Nit.Text);
        dsPT = FachadaPersistencia.getInstancia().Get_plan_acción_traslado_Inventario_hogar_ruta_comunitaria(idComunidad);
        if (!dsPT.Tables[0].Rows.Count.Equals(0))
        {
            gv_inventario_traslado.Visible = true;
            gv_inventario_traslado.DataSource = dsPT;
            gv_inventario_traslado.DataBind();
        }
    }
    public void Get_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria()
    {
        DataSet dsPT = new DataSet();
        int idComunidad = Convert.ToInt32(TB_Nit.Text);
        int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
        dsPT = FachadaPersistencia.getInstancia().Get_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria(idPlan);
        if (!dsPT.Tables[0].Rows.Count.Equals(0))
        {
            txtFechaRegistro.Text = dsPT.Tables[0].Rows[0]["FECHA_REGISTRO"].ToString();
            txtDireccionRegistro.Text = dsPT.Tables[0].Rows[0]["DIRECCION"].ToString();
            txtProfesionalEncargado.Text = dsPT.Tables[0].Rows[0]["PROFESIONAL_REGISTRO"].ToString();
            txCorreoProfesionalEncargado.Text = dsPT.Tables[0].Rows[0]["CORREO_ELECTRONICO"].ToString();
            LD_DireccionTerritorialProfesionalEncargado.SelectedValue = dsPT.Tables[0].Rows[0]["ID_DIRECCION_TERRITORIAL"].ToString();
            LD_DepartamentoAlistamiento.SelectedValue = dsPT.Tables[0].Rows[0]["DAN_CCOD_DEPARTAMENTO"].ToString();
            LlenarComboMunicipioAlistamiento(Convert.ToInt32(dsPT.Tables[0].Rows[0]["DAN_CCOD_DEPARTAMENTO"]));
            LD_MunicipioAlistamiento.SelectedValue = dsPT.Tables[0].Rows[0]["ID_MUNICIPIO"].ToString();
            LD_EntidadRegistra.SelectedValue = dsPT.Tables[0].Rows[0]["ID_ENTIDAD"].ToString();

        }
    }
    public void Get_plan_acción_traslado_Inventario_hogar_enseres_ruta_comunitaria()
    {
        DataSet dsPT = new DataSet();

        int idHogar = Convert.ToInt32(ViewState["idHogar"]);
        dsPT = FachadaPersistencia.getInstancia().Get_plan_acción_traslado_Inventario_hogar_enseres_ruta_comunitaria(idHogar);
        if (!dsPT.Tables[0].Rows.Count.Equals(0))
        {
            txEstufas.Text = dsPT.Tables[0].Rows[0]["ESTUFAS"].ToString();
            txNeveras.Text = dsPT.Tables[0].Rows[0]["NEVERAS"].ToString();
            txMenaje.Text = dsPT.Tables[0].Rows[0]["UTENCILIOS_COCINA"].ToString();
            txCamas.Text = dsPT.Tables[0].Rows[0]["CAMAS"].ToString();
            txColchones.Text = dsPT.Tables[0].Rows[0]["COLCHONES"].ToString();
            txCobijas.Text = dsPT.Tables[0].Rows[0]["COBIJAS"].ToString();
            txSofas.Text = dsPT.Tables[0].Rows[0]["SOFAS"].ToString();
            txSillas.Text = dsPT.Tables[0].Rows[0]["SILLAS"].ToString();
            txMesas.Text = dsPT.Tables[0].Rows[0]["MESAS"].ToString();
            txEquiposSonido.Text = dsPT.Tables[0].Rows[0]["EQUIPOS_DE_SONIDO"].ToString();
            txJuguetes.Text = dsPT.Tables[0].Rows[0]["JUGUTES_ROPA"].ToString();
            txBicicletas.Text = dsPT.Tables[0].Rows[0]["BICICLETAS"].ToString();
            txMotos.Text = dsPT.Tables[0].Rows[0]["MOTOS"].ToString();
            txTulas.Text = dsPT.Tables[0].Rows[0]["TULAS"].ToString();
            txPeso.Text = dsPT.Tables[0].Rows[0]["PESO"].ToString();
            LD_Rotulacion.Items.Clear();
            LD_Rotulacion.Items.Insert(0, new ListItem("Si", "True"));
            LD_Rotulacion.Items.Insert(1, new ListItem("No", "False"));
            string rotulacion = dsPT.Tables[0].Rows[0]["ROTULACION"].ToString();
            LD_Rotulacion.SelectedValue = rotulacion;
        }
        else
        {
            txEstufas.Text = "";
            txNeveras.Text = "";
            txMenaje.Text = "";
            txCamas.Text = "";
            txColchones.Text = "";
            txCobijas.Text = "";
            txSofas.Text = "";
            txSillas.Text = "";
            txMesas.Text = "";
            txEquiposSonido.Text = "";
            txJuguetes.Text = "";
            txBicicletas.Text = "";
            txMotos.Text = "";
            txTulas.Text = "";
            txPeso.Text = "";

        }

    }
    protected void btn_guardar_plan_Accion_traslado_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            //todos los datos son obligatorios de diligenciamiento pero se validan en el aspx
            int idComuniad = Convert.ToInt32(TB_Nit.Text);
            int totalHogares = Convert.ToInt32(txTotalHogares.Text);
            int totalPersonas = Convert.ToInt32(txTotalPersonas.Text);
            int totalRUV = Convert.ToInt32(txTotalRUV.Text);
            int id_MunSalida = Convert.ToInt32(LD_Municipio_Salida.SelectedValue);
            int idMunLlegada = Convert.ToInt32(LD_Municipio_Llegada.SelectedValue);
            int idEntornoSalida = Convert.ToInt32(LD_Entorno_Salida.SelectedValue);
            int idEntornoLlegada = Convert.ToInt32(LD_Entorno_Llegada.SelectedValue);
            string corregimmientoSalida = txCorregimiento_Salida.Text;
            string corregimientoLlegada = txCorregimiento_Llegada.Text;
            int idPlan = FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_Ruta_Comunitaria(idComuniad, totalHogares, totalPersonas, totalRUV, id_MunSalida, idMunLlegada, idEntornoSalida, idEntornoLlegada, corregimmientoSalida, corregimientoLlegada);
            idPlanAccionTraslado.Value = idPlan.ToString();
            ViewState["idPlanAccionTraslado"] = idPlan.ToString();
        }
        catch (System.Exception ex)
        {
            Mensajes("Error adicionar la entidad." + ex.Message, 0);
        }
    }
    protected void btn_guardar_Categorias_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            int idComunidad = Convert.ToInt32(TB_Nit.Text);
            int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
            if (gv_categoria.Rows.Count > 0)
            {
                for (int i = 0; i < gv_categoria.Rows.Count; i++)
                {
                    int id = Convert.ToInt32(gv_categoria.Rows[i].Cells[0].Text); ;
                    TextBox txtResultado = (TextBox)gv_categoria.Rows[i].Cells[2].FindControl("RESULTADO");
                    string resultado = txtResultado.Text;
                    TextBox txtAcciones = (TextBox)gv_categoria.Rows[i].Cells[3].FindControl("ACCIONES");
                    string acciones = txtAcciones.Text;
                    TextBox txtObservaciones = (TextBox)gv_categoria.Rows[i].Cells[4].FindControl("OBSERVACIONES");
                    string observaciones = txtObservaciones.Text;
                    FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_categoria_ruta_comunitaria(id, idPlan, idComunidad, resultado, acciones, observaciones);
                }
                GetCategoria_plan_acción_traslado_Ruta_Comunitaria();
            }
        }
        catch (System.Exception ex)
        {
            Mensajes("Error adicionar la entidad." + ex.Message, 0);
        }
    }

    protected void btn_agregar_entidad_caracterizacion_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (Convert.ToInt32(LD_EntidadCaracterizacion.SelectedValue) != 0)
            {
                int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
                int idEntidad = Convert.ToInt32(LD_EntidadCaracterizacion.SelectedValue);
                int idCategoria = Convert.ToInt32(ViewState["idCategoria"]);
                bool exitoso = FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_categoria_entidad_Ruta_Comunitaria(idPlan, idEntidad, idCategoria);
                if (exitoso)
                {
                    LD_EntidadCaracterizacion.SelectedValue = "0";
                    Get_Entidades_Plan_Accion_Traslado_Ctegorias_Entidad();
                }
                else
                {
                    Mensajes("No se ingresó la entidad correctamente.", 0);
                }
            }
            else
            {
                Mensajes("Seleccione una entidad", 0);
            }
        }
        catch (System.Exception ex)
        {
            Mensajes("Error adicionar la entidad." + ex.InnerException.Message, 0);
        }
    }
    public void Get_Entidades_Plan_Accion_Traslado_Ctegorias_Entidad()
    {
        int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
        int idCategoria = Convert.ToInt32(ViewState["idCategoria"]);
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().Get_Entidades_Plan_Accion_Traslado_categorias_Entidad(idPlan, idCategoria);
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            gv_entidades_caracterizacion.Visible = true;
            gv_entidades_caracterizacion.DataSource = dsPE;
            gv_entidades_caracterizacion.DataBind();
        }
        else
        {
            gv_entidades_caracterizacion.Visible = false;
            gv_entidades_caracterizacion.DataSource = dsPE;
            gv_entidades_caracterizacion.DataBind();
        }
    }
    public void Get_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria()
    {
        int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().Get_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria(idPlan);
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            gv_noTrasladar.Visible = true;
            gv_noTrasladar.DataSource = dsPE;
            gv_noTrasladar.DataBind();
        }
        else
        {
            gv_noTrasladar.Visible = false;
            gv_noTrasladar.DataSource = dsPE;
            gv_noTrasladar.DataBind();
        }
    }
    protected void btn_agregar_entidad_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            if (Convert.ToInt32(LD_Entidad.SelectedValue) != 0)
            {
                int idComuniad = Convert.ToInt32(TB_Nit.Text);
                int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
                int idEntidad = Convert.ToInt32(LD_Entidad.SelectedValue);
                bool exitoso = FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_entidad_Ruta_Comunitaria(idPlan, idEntidad);
                if (exitoso) {
                    LD_Entidad.SelectedValue = "0";
                    Get_Entidades_Plan_Accion_Traslado_Entidad();
                }
                else
                {
                    Mensajes("No se ingresó la entidad correctamente.", 0);
                }
            }
            else
            {
                Mensajes("Seleccione una entidad", 0);
            }
        }
        catch (System.Exception ex)
        {
            Mensajes("Error adicionar la entidad." + ex.InnerException.Message, 0);
        }
    }
    protected void btn_buscar_persona_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            string numDocumento= txDocumento.Text;
            DataSet dsPE = new DataSet();
            dsPE = FachadaPersistencia.getInstancia().Get_Persona_Plan_Accion_Traslado_por_numero_documento(numDocumento);
            if (!dsPE.Tables[0].Rows.Count.Equals(0))
            {
                gv_personas.Visible = true;
                gv_personas.DataSource = dsPE;
                gv_personas.DataBind();
                lblMensajePersona.Visible = false;
                txDocumento.Text = "";
            }
            else
            {
                gv_personas.Visible = false;
                gv_personas.DataSource = dsPE;
                gv_personas.DataBind();                
                lblMensajePersona.Visible = true;
            }
        }
        catch (System.Exception ex)
        {
            Mensajes("Error al buscar la persona." + ex.InnerException.Message, 0);
        }
    }
    protected void btn_agregar_Actividad_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            int idComunidad = Convert.ToInt32(TB_Nit.Text);
            int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
            int id = 0;
            if (ViewState["idBalanceTraslado"] !=  null) {
                id = Convert.ToInt32(ViewState["idBalanceTraslado"]);
            }
            string actividad = txActividad.Text;
            string responsable = txResponsable.Text;
            bool cumplida = Convert.ToBoolean(LD_Cumplido.SelectedValue);
            string observaciones = txObservaciones.Text;
            bool exitoso = FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_balance_traslado_ruta_comunitaria(id, idPlan, idComunidad, actividad, responsable, cumplida, observaciones);
            Get_plan_acción_traslado_balance_traslado_ruta_comunitaria();
            TB_Nit.Text = "";
            txResponsable.Text = "";
            txActividad.Text = "";
            txObservaciones.Text = "";
            //LD_Cumplido.SelectedValue = "0";
        }
        catch (System.Exception ex)
        {
            Mensajes("Error al agregar la actividad al balance del traslado." + ex, 0);
        }
    }
    protected void btn_agregar_Datos_Alistamiento_Traslado_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            int idComunidad = Convert.ToInt32(TB_Nit.Text);
            int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
            int id = 0;
            //DateTime fechaRegistro = txtFechaRegistro.Text;
            DateTime fechaRegistro = DateTime.Today;
            int idMunicipio = Convert.ToInt32(LD_MunicipioAlistamiento.SelectedValue);
            string direccion = txtDireccionRegistro.Text;
            int idDt = Convert.ToInt32(LD_DireccionTerritorialProfesionalEncargado.SelectedValue);
            int idEntidad = Convert.ToInt32(LD_EntidadRegistra.SelectedValue);
            string profesional = txtProfesionalEncargado.Text;
            string correo = txCorreoProfesionalEncargado.Text;
            bool exitoso = FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_alistamiento_traslado_ruta_comunitaria(id, idPlan, idComunidad, fechaRegistro, idMunicipio, direccion, idDt, idEntidad, profesional, correo);
            Get_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria();
        }
        catch (System.Exception ex)
        {
            Mensajes("Error al guardar información del alistamiento logistico." + ex, 0);
        }
    }
    protected void btn_agregar_profesional_encargado_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            int idComunidad = Convert.ToInt32(TB_Nit.Text);
            int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
            string profesional = txNombresProfesionalRealiza.Text;
            int idEntidad = Convert.ToInt32(LD_EntidadProfesionalRegistra.SelectedValue);
            string telefono = txTelefonoProfesionalRegistra.Text;
            string correo = txCorreoProfesionalRegistroAlistamiento.Text;
            int id = 0;
            if (ViewState["idProfesionalRegistra"] != null)
            {
                id = Convert.ToInt32(ViewState["idProfesionalRegistra"]);
            }
            bool exitoso = FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(id, idPlan, idComunidad, profesional, idEntidad, telefono, correo);
            Get_plan_acción_traslado_profesionales_traslado_ruta_comunitaria();
        }
        catch (System.Exception ex)
        {
            Mensajes("Error al guardar información del profesional encargado." + ex, 0);
        }
    }
    protected void btn_GuardarEnseres(object sender, EventArgs e)
    {
        try
        {
            int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
            int idComunidad = Convert.ToInt32(TB_Nit.Text);
            int idHogar = Convert.ToInt32(ViewState["idHogar"]);
            int estufas = Convert.ToInt32(txEstufas.Text);
            int neveras = Convert.ToInt32(txNeveras.Text);
            int utenciliosCocina = Convert.ToInt32(txMenaje.Text);
            int camas = Convert.ToInt32(txCamas.Text);
            int colchones = Convert.ToInt32(txColchones.Text);
            int cobijas = Convert.ToInt32(txCobijas.Text);
            int sofas = Convert.ToInt32(txSofas.Text);
            int sillas = Convert.ToInt32(txSillas.Text);
            int mesas = Convert.ToInt32(txMesas.Text);
            int equiposSonido = Convert.ToInt32(txEquiposSonido.Text);
            int juguetes = Convert.ToInt32(txJuguetes.Text);
            int bicicletas = Convert.ToInt32(txBicicletas.Text);
            int motos = Convert.ToInt32(txMotos.Text);
            int tulas = Convert.ToInt32(txTulas.Text);
            int peso = Convert.ToInt32(txMotos.Text);
            bool rotulacion = Convert.ToBoolean(LD_Rotulacion.SelectedValue);
            bool exitoso = FachadaPersistencia.getInstancia().LD_Insertar_plan_acción_traslado_inventario_hogar_ruta_comunitaria(0, idPlan, idComunidad, idHogar, estufas, neveras, utenciliosCocina, camas, colchones, cobijas, sofas, sillas, mesas, equiposSonido, juguetes, bicicletas, motos, tulas, peso, rotulacion);
            Get_plan_acción_traslado_Inventario_hogar_ruta_comunitaria();
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void LlenarMunicipiosPlanSalida_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LD_Departamento_Salida.SelectedValue != "")
        {

            int idDepartamento = Convert.ToInt32(LD_Departamento_Salida.SelectedValue);
            LlenarComboMunicipioSalida(idDepartamento);
        }
    }
    protected void LlenarMunicipiosPlanLlegada_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LD_Departamento_Llegada.SelectedValue != "")
        {
            int idDepartamento = Convert.ToInt32(LD_Departamento_Llegada.SelectedValue);
            LlenarComboMunicipioLlegada(idDepartamento);
        }
    }
    protected void LlenarMunicipiosAlistamiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LD_DepartamentoAlistamiento.SelectedValue != "")
        {
            int idDepartamento = Convert.ToInt32(LD_DepartamentoAlistamiento.SelectedValue);
            LlenarComboMunicipioAlistamiento(idDepartamento);
        }
    }
    public void LlenarComboDT()
    {
        DataSet dsTerritorio = new DataSet();
        dsTerritorio = FachadaPersistencia.getInstancia().L_D_Territorial();
        LD_DireccionTerritorialProfesionalEncargado.Items.Clear();
        if (!dsTerritorio.Tables[0].Rows.Count.Equals(0))
        {
            LD_DireccionTerritorialProfesionalEncargado.DataValueField = "Id_territorio";
            LD_DireccionTerritorialProfesionalEncargado.DataTextField = "Territorio";
            LD_DireccionTerritorialProfesionalEncargado.DataSource = dsTerritorio;
            LD_DireccionTerritorialProfesionalEncargado.DataBind();
            LD_DireccionTerritorialProfesionalEncargado.Items.Insert(0, new ListItem("Seleccione la DT", "0"));
        }
    }
    public void LlenarCombosDepartamento()
    {
        DataSet dsDepartamento = new DataSet();

        dsDepartamento = FachadaPersistencia.getInstancia().L_D_Departamentos(0);
        LD_Departamento_Salida.Items.Clear();
        LD_Departamento_Llegada.Items.Clear();
        LD_DepartamentoAlistamiento.Items.Clear();

        if (!dsDepartamento.Tables[0].Rows.Count.Equals(0))
        {
            LD_Departamento_Salida.DataValueField = "id_departamento";
            LD_Departamento_Salida.DataTextField = "departamento";
            LD_Departamento_Salida.DataSource = dsDepartamento;
            LD_Departamento_Salida.DataBind();
            LD_Departamento_Salida.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));

            LD_Departamento_Llegada.DataValueField = "id_departamento";
            LD_Departamento_Llegada.DataTextField = "departamento";
            LD_Departamento_Llegada.DataSource = dsDepartamento;
            LD_Departamento_Llegada.DataBind();
            LD_Departamento_Llegada.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));

            LD_DepartamentoAlistamiento.DataValueField = "id_departamento";
            LD_DepartamentoAlistamiento.DataTextField = "departamento";
            LD_DepartamentoAlistamiento.DataSource = dsDepartamento;
            LD_DepartamentoAlistamiento.DataBind();
            LD_DepartamentoAlistamiento.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
        else
        {
            LD_Departamento_Salida.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
            LD_Departamento_Llegada.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
            LD_DepartamentoAlistamiento.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
    }
    public void LlenarCombosRequeridos()
    {
        LD_Entorno_Salida.Items.Clear();
        LD_Entorno_Salida.Items.Insert(0, new ListItem("Seleccione", "0"));
        LD_Entorno_Salida.Items.Insert(1, new ListItem("Rural", "1"));
        LD_Entorno_Salida.Items.Insert(2, new ListItem("Urbano", "2"));

        LD_Entorno_Llegada.Items.Clear();
        LD_Entorno_Llegada.Items.Insert(0, new ListItem("Seleccione", "0"));
        LD_Entorno_Llegada.Items.Insert(1, new ListItem("Rural", "1"));
        LD_Entorno_Llegada.Items.Insert(2, new ListItem("Urbano", "2"));

        LD_Cumplido.Items.Clear();
        LD_Cumplido.Items.Insert(0, new ListItem("Si", "True"));
        LD_Cumplido.Items.Insert(1, new ListItem("No", "False"));


        LD_Rotulacion.Items.Clear();
        LD_Rotulacion.Items.Insert(0, new ListItem("Si", "True"));
        LD_Rotulacion.Items.Insert(1, new ListItem("No", "False"));
    }
    public void LlenarComboMunicipioSalida(int idDepartamento)
    {
        DataSet dsMunicipios = new DataSet();
        dsMunicipios = FachadaPersistencia.getInstancia().L_D_Municipio(idDepartamento, 0, 0);
        LD_Municipio_Salida.Items.Clear();
        if (!dsMunicipios.Tables[0].Rows.Count.Equals(0))
        {
            LD_Municipio_Salida.DataValueField = "ID_MUNICIPIO";
            LD_Municipio_Salida.DataTextField = "MUNICIPIO";
            LD_Municipio_Salida.DataSource = dsMunicipios;
            LD_Municipio_Salida.DataBind();
            LD_Municipio_Salida.Items.Insert(0, new ListItem("Seleccione el municipio", "0"));
        }
        else
        {
            LD_Municipio_Salida.Items.Insert(0, new ListItem("Seleccione el municipio", "0"));
        }
    }
    public void LlenarComboMunicipioLlegada(int idDepartamento)
    {
        DataSet dsMunicipios = new DataSet();
        dsMunicipios = FachadaPersistencia.getInstancia().L_D_Municipio(idDepartamento, 0, 0);
        LD_Municipio_Llegada.Items.Clear();
        if (!dsMunicipios.Tables[0].Rows.Count.Equals(0))
        {
            LD_Municipio_Llegada.DataValueField = "ID_MUNICIPIO";
            LD_Municipio_Llegada.DataTextField = "MUNICIPIO";
            LD_Municipio_Llegada.DataSource = dsMunicipios;
            LD_Municipio_Llegada.DataBind();
            LD_Municipio_Llegada.Items.Insert(0, new ListItem("Seleccione el municipio", "0"));
        }
        else
        {
            LD_Municipio_Llegada.Items.Insert(0, new ListItem("Seleccione el municipio", "0"));
        }
    }
    public void LlenarComboMunicipioAlistamiento(int idDepartamento)
    {
        DataSet dsMunicipios = new DataSet();
        dsMunicipios = FachadaPersistencia.getInstancia().L_D_Municipio(idDepartamento, 0, 0);
        LD_MunicipioAlistamiento.Items.Clear();
        if (!dsMunicipios.Tables[0].Rows.Count.Equals(0))
        {
            LD_MunicipioAlistamiento.DataValueField = "ID_MUNICIPIO";
            LD_MunicipioAlistamiento.DataTextField = "MUNICIPIO";
            LD_MunicipioAlistamiento.DataSource = dsMunicipios;
            LD_MunicipioAlistamiento.DataBind();
            LD_MunicipioAlistamiento.Items.Insert(0, new ListItem("Seleccione el municipio", "0"));
        }
        else
        {
            LD_MunicipioAlistamiento.Items.Insert(0, new ListItem("Seleccione el municipio", "0"));
        }
    }
    public void LlenarComboEntidadesRutaComunitaria()
    {
        DataSet dsPE = new DataSet();
        dsPE = FachadaPersistencia.getInstancia().GetTodasEntidadesRutaComunitaria();

        LD_Entidad.Items.Clear();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            LD_Entidad.DataValueField = "ID_ENTIDAD";
            LD_Entidad.DataTextField = "NOMBRE_ENTIDAD";
            LD_Entidad.DataSource = dsPE;
            LD_Entidad.DataBind();
            LD_Entidad.Items.Insert(0, new ListItem("Seleccione la entidad", "0"));
        }
        LD_EntidadRegistra.Items.Clear();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            LD_EntidadRegistra.DataValueField = "ID_ENTIDAD";
            LD_EntidadRegistra.DataTextField = "NOMBRE_ENTIDAD";
            LD_EntidadRegistra.DataSource = dsPE;
            LD_EntidadRegistra.DataBind();
            LD_EntidadRegistra.Items.Insert(0, new ListItem("Seleccione la entidad", "0"));
        }

        LD_EntidadProfesionalRegistra.Items.Clear();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            LD_EntidadProfesionalRegistra.DataValueField = "ID_ENTIDAD";
            LD_EntidadProfesionalRegistra.DataTextField = "NOMBRE_ENTIDAD";
            LD_EntidadProfesionalRegistra.DataSource = dsPE;
            LD_EntidadProfesionalRegistra.DataBind();
            LD_EntidadProfesionalRegistra.Items.Insert(0, new ListItem("Seleccione la entidad", "0"));
        }
        LD_EntidadCaracterizacion.Items.Clear();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            LD_EntidadCaracterizacion.DataValueField = "ID_ENTIDAD";
            LD_EntidadCaracterizacion.DataTextField = "NOMBRE_ENTIDAD";
            LD_EntidadCaracterizacion.DataSource = dsPE;
            LD_EntidadCaracterizacion.DataBind();
            LD_EntidadCaracterizacion.Items.Insert(0, new ListItem("Seleccione la entidad", "0"));
        }
        
    }
    private void EliminarEntidadQueAcompanaElTraslado(GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
            int idEntidad = Convert.ToInt32(((Label)gvRow.FindControl("idEntidad")).Text);
                         
            bool exitoso = FachadaPersistencia.getInstancia().LD_Eliminar_plan_acción_traslado_entidad_Ruta_Comunitaria(idPlan, idEntidad);
            if (exitoso) {
                Get_Entidades_Plan_Accion_Traslado_Entidad();
                Mensajes("El registro ha sido eliminado correctamente", 0);
            }
            else
            {
                Mensajes("Se generó un error al borrar el registro", 0);
            }            

        }
        catch (System.Exception ex)
        {

        }
    }
    private void EliminarEntidadCaracterizacion(GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int idPlan = Convert.ToInt32(ViewState["idPlanAccionTraslado"]);
            int idEntidad = Convert.ToInt32(((Label)gvRow.FindControl("idEntidad")).Text);
            int idCategoria = Convert.ToInt32(ViewState["idCategoria"]);
            bool exitoso = FachadaPersistencia.getInstancia().LD_Eliminar_plan_acción_traslado_categoria_entidad_Ruta_Comunitaria(idPlan, idEntidad, idCategoria);
            if (exitoso)
            {
                Get_Entidades_Plan_Accion_Traslado_Ctegorias_Entidad();
                Mensajes("El registro ha sido eliminado correctamente", 0);
            }
            else
            {
                Mensajes("Se generó un error al borrar el registro", 0);
            }

        }
        catch (System.Exception ex)
        {

        }
    }
    private void EliminarBalanceTraslado(GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id = Convert.ToInt32(((Label)gvRow.FindControl("idbalance")).Text);
            bool exitoso = FachadaPersistencia.getInstancia().LD_Eliminar_plan_acción_traslado_balance_traslado_Ruta_Comunitaria(id);
            if (exitoso)
            {
                Get_plan_acción_traslado_balance_traslado_ruta_comunitaria();
                Mensajes("El registro ha sido eliminado correctamente", 0);
            }
            else
            {
                Mensajes("Se generó un error al borrar el registro", 0);
            }
        }
        catch (System.Exception ex)
        {

        }
    }
    private void EliminarProsional(GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id = Convert.ToInt32(((Label)gvRow.FindControl("id")).Text);
            bool exitoso = FachadaPersistencia.getInstancia().LD_Eliminar_plan_acción_traslado_profesionales_traslado_Ruta_Comunitaria(id);
            if (exitoso)
            {
                Get_plan_acción_traslado_profesionales_traslado_ruta_comunitaria();
                Mensajes("El registro ha sido eliminado correctamente", 0);
            }
            else
            {
                Mensajes("Se generó un error al borrar el registro", 0);
            }
        }
        catch (System.Exception ex)
        {

        }
    }
    #endregion

}





