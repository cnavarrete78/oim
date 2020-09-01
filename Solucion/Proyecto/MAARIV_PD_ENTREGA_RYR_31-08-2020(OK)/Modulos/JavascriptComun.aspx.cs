/*
 *************************************************************************************************
  PROGRAMA				: JavascriptComun.cs
  AUTOR                 : aLEJANDRO MORENO 
  FECHA DE CREACION	    : 14-04-2020
  USUARIO MODIFICACION  : 
  FECHA MODIFICACION    : 
  VERSION               : 1.0
 *************************************************************************************************
  CLASE			        : JavascriptComun.cs
  RESPONSABILIDAD	    : Se encargara de realizar las peticiones GET o POST que sean llamados por 
                          javascript con el fin de no saturar el servidor, teniendo que renderizar.
*****/


using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.modelo.actividad;
using com.GACV.lgb.modelo.persona;
using com.GACV.lgb.modelo.actividad_detalle;
using com.GACV.lgb.modelo.actividad_responsable;
using com.GACV.lgb.modelo.actividad_dia;
using com.GACV.lgb.modelo.ADEP;
using System.IO;

public partial class JavascriptComun : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    #region METODOS ESTATICOS

    //Convierte un datatable en un JSON string (Esta se debe usar para todas las respuestas, con el fin de que la peticion sea en formato json)
    private static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);
            }
            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

    #endregion

    #region FUNCIONES 

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object SubirArchivo(HttpPostedFileBase file)
    {
        try
        {
            

            DataSet ds = new DataSet();
            //ds = FachadaPersistencia.getInstancia().L_D_Consulta_lugar(1, 0, 0);

            //return serializer.Serialize(objeto);
            //var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
            return file.FileName;

        }
        catch (Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object L_D_Territorial(int opcion, int id_territorial, int id_departamento)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = FachadaPersistencia.getInstancia().L_D_Consulta_lugar(1, 0, 0);

            //return serializer.Serialize(objeto);
            var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
            return objeto;

        }
        catch (Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }

    }
    
    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object L_D_Departamentos(int id_territorial)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = FachadaPersistencia.getInstancia().L_D_Departamentos(id_territorial);

            var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
            return objeto;
        }
        catch(Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }
        
        
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object L_D_Municipios(int id_territorial, int id_departamento)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = FachadaPersistencia.getInstancia().L_D_Municipio(id_departamento, id_territorial, 1);

            var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
            return objeto;
        }
        catch(Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }
        
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object AgregarResponsable(int opcion,int id_actividad)
    {
        try
        {
            Actividad_responsable actividad_responsable = new Actividad_responsable();
            int valor_responsable = 0;
            actividad_responsable.P_ID_ACTIVIDAD_RESPONSABLE = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_ACTIVIDAD_RESPONSABLE"]);
            actividad_responsable.P_ID_ACTIVIDAD = id_actividad;
            actividad_responsable.P_ID_USUARIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
            actividad_responsable.P_ID_ACTIVIDAD_ROL = Convert.ToInt32(HttpContext.Current.Request.QueryString["ACTIVIDAD_ROL"]); //produccion usuario_creacion
            actividad_responsable.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
            valor_responsable = FachadaPersistencia.getInstancia().Administrar_actividad_responsable(actividad_responsable, opcion);

            var obj = new
            {
                ACTIVIDAD_RESPONSABLE = actividad_responsable
            };
            return obj;
        }
        catch (Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object AgregarDia(int opcion, int id_actividad)
    {
        try {
            Actividad_dia actividad_dia = new Actividad_dia();
            int valor_dias = 0;
            actividad_dia.P_ID_ACTIVIDAD = id_actividad;
            actividad_dia.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
            actividad_dia.P_DIA_ACTIVIDAD = Convert.ToString(HttpContext.Current.Request.QueryString["DIA_FECHA"]);
            actividad_dia.P_LUGAR_ACTIVIDAD = Convert.ToString(HttpContext.Current.Request.QueryString["LUGAR_ACTIVIDAD"]);
            actividad_dia.P_HORA_INICIO = Convert.ToString(HttpContext.Current.Request.QueryString["HORA_INICIO"]);
            actividad_dia.P_HORA_FIN = Convert.ToString(HttpContext.Current.Request.QueryString["HORA_FIN"]);
            actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = Convert.ToString(HttpContext.Current.Request.QueryString["OBSERVACION_ACTIVIDAD_DIA"]);
            //actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = Convert.ToString(TB_Observarcion.Text);
            actividad_dia.P_PROYECCION = Convert.ToInt32(HttpContext.Current.Request.QueryString["PROYECCION"]);//1;
                                                                                                                //actividad_dia.P_GESTION = Convert.ToInt32(TB_Gestion.Text);
            actividad_dia.P_GESTION = Convert.ToInt32(HttpContext.Current.Request.QueryString["GESTION"]);//0;
            actividad_dia.P_ID_MUNICIPIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_MUNICIPIO"]);
            valor_dias = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 1);


            var obj = new
            {
                ACTIVIDAD_DIA = actividad_dia
            };
            return obj;
        }
        catch (Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet =true, ResponseFormat = ResponseFormat.Json)]
    public static object Actividad(int opcion)
    {
        string error = "";
        try
        {
            
            Persona persona = new Persona();
            DataSet ds = new DataSet();
            DataSet ds_cant_veces = new DataSet();
            Actividad actividad_cant_veces = new Actividad();

            Actividad actividad = new Actividad();
            Actividad_detalle actividad_detalle = new Actividad_detalle();
            Actividad_responsable actividad_responsable = new Actividad_responsable();
            Actividad_dia actividad_dia = new Actividad_dia();

            int valor = 0;
            int id_actividad = 0;
            int valor_detalle = 0;
            int valor_responsable = 0;
            int valor_dias = 0;

            actividad.P_ID_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_ACTIVIDAD"]);
            actividad_cant_veces.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
            actividad_cant_veces.P_ID_NOMBRE_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_NOMBRE_ACTIVIDAD"]);
            actividad.P_ID_NOMBRE_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_NOMBRE_ACTIVIDAD"]);
            actividad.P_TIENE_LIMITE_PERSONAS = Convert.ToInt32(HttpContext.Current.Request.QueryString["TIENE_LIMITE_PERSONAS"]); //1
            actividad.P_LIMITE_PERSONAS = Convert.ToInt32(HttpContext.Current.Request.QueryString["LIMITE_PERSONAS"]); //20
            actividad.P_ID_ACTIVIDAD_ESTADO = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_ACTIVIDAD_ESTADO"]);

            ds_cant_veces = FachadaPersistencia.getInstancia().Consulta_actividad(actividad_cant_veces, persona, 11);//cantidad de veces y nombre usuario
            string NOMBRE_USUARIO = "";
            if (ds_cant_veces.Tables[0].Rows.Count != 0)
            {
                NOMBRE_USUARIO = Convert.ToString(ds_cant_veces.Tables[0].Rows[0]["NOMBRES"]);
            }
            else
            {
                NOMBRE_USUARIO = Convert.ToString(HttpContext.Current.Request.QueryString["NOMBRES"]);
            }
            //string nombre_actividad = "CAPACITACION_" + Convert.ToString(LD_MunicipioDia.SelectedItem.ToString()).Replace(' ', '_') + "_" + Convert.ToString(NOMBRE_USUARIO).Replace(' ', '_') + "_" + (ds_cant_veces.Tables[0].Rows.Count + 1);
            string nombre_actividad = Convert.ToString(HttpContext.Current.Request.QueryString["NOMBRE_ACTIVIDAD_USUARIO"]);
            actividad.P_DESCRIPCION_ACTIVIDAD = nombre_actividad.Trim().ToUpper();
            actividad.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
           
            id_actividad = FachadaPersistencia.getInstancia().Administrar_actividad(actividad, opcion);
            actividad.P_ID_ACTIVIDAD = id_actividad;

            if ((id_actividad != 0) && (id_actividad != null))
            {
                
                actividad_detalle.P_ID_ACTIVIDAD_DETALLE = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_ACTIVIDAD_DETALLE"]);
                //actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(ViewState["id_actividad"]);
                actividad_detalle.P_ID_ACTIVIDAD = id_actividad;
                actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE = Convert.ToString(HttpContext.Current.Request.QueryString["DESCRIPCION_ACTIVIDAD_DETALLE"]);
                actividad_detalle.P_ID_TIPO_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["P_ID_TIPO_ACTIVIDAD"]); //630
                actividad_detalle.P_ESTADO_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["ESTADO_ACTIVIDAD"]);
                actividad_detalle.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
                valor_detalle = FachadaPersistencia.getInstancia().Administrar_actividad_detalle(actividad_detalle, opcion);
                
                actividad_responsable.P_ID_ACTIVIDAD_RESPONSABLE = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_ACTIVIDAD_RESPONSABLE"]);
                actividad_responsable.P_ID_ACTIVIDAD = id_actividad;
                actividad_responsable.P_ID_USUARIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
                actividad_responsable.P_ID_ACTIVIDAD_ROL = Convert.ToInt32(HttpContext.Current.Request.QueryString["ACTIVIDAD_ROL"]); //produccion usuario_creacion
                actividad_responsable.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
                valor_responsable = FachadaPersistencia.getInstancia().Administrar_actividad_responsable(actividad_responsable, opcion);
                
                actividad_dia.P_ID_ACTIVIDAD = id_actividad;
                actividad_dia.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["USUARIO_CREACION"]);
                actividad_dia.P_DIA_ACTIVIDAD = Convert.ToString(HttpContext.Current.Request.QueryString["DIA_FECHA"]);
                actividad_dia.P_LUGAR_ACTIVIDAD = Convert.ToString(HttpContext.Current.Request.QueryString["LUGAR_ACTIVIDAD"]);
                actividad_dia.P_HORA_INICIO = Convert.ToString(Convert.ToDateTime(HttpContext.Current.Request.QueryString["HORA_INICIO"]).Hour);
                actividad_dia.P_HORA_FIN = Convert.ToString(Convert.ToDateTime(HttpContext.Current.Request.QueryString["HORA_FIN"]).Hour);
                actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = Convert.ToString(HttpContext.Current.Request.QueryString["OBSERVACION_ACTIVIDAD_DIA"]);
                //actividad_dia.P_OBSERVACION_ACTIVIDAD_DIA = Convert.ToString(TB_Observarcion.Text);
                actividad_dia.P_PROYECCION = Convert.ToInt32(HttpContext.Current.Request.QueryString["PROYECCION"]);//1;
                //actividad_dia.P_GESTION = Convert.ToInt32(TB_Gestion.Text);
                actividad_dia.P_GESTION = Convert.ToInt32(HttpContext.Current.Request.QueryString["GESTION"]);//0;
                actividad_dia.P_ID_MUNICIPIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["ID_MUNICIPIO"]);
                valor_dias = FachadaPersistencia.getInstancia().Administrar_actividad_dia(actividad_dia, 1);

            }
            else
            {
                error += "Ocurrio un problema al registrar los datos -> ID_ACTIVIDAD IS NULL";
            }

            if ((id_actividad != 0) /*&& (valor_detalle != 0)*/ && (valor_responsable != 0))
            {

                //esta bien 
                var obj = new
                {
                    ACTIVIDAD = actividad,
                    ACTIVIDAD_DETALLE = actividad_detalle,
                    ACTIVIDAD_RESPONSABLE = actividad_responsable,
                    ACTIVIDAD_DIA = actividad_dia
                };
                return obj;

            }
            else
            {
                error += "Los registros no se pudieron ingresar en la base de datos, debido a una excepción en el sistema!.";
            }

            var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
            return objeto;

        }
        catch (Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }
        
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object Usuarios(int opcion)
    {
        try
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            Usuario usuario = new Usuario();

            usuario.F_ID_USUARIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["Id"]);
            usuario.Identificacion = Convert.ToString(HttpContext.Current.Request.QueryString["Identificacion"]);
            usuario.P_ROL = Convert.ToInt32(HttpContext.Current.Request.QueryString["Rol"]);
            usuario.P_PRIMER_NOMBRE = Convert.ToString(HttpContext.Current.Request.QueryString["PrimerNombre"]);
            usuario.P_SEGUNDO_NOMBRE = Convert.ToString(HttpContext.Current.Request.QueryString["SegundoNombre"]);
            usuario.P_PRIMER_APELLIDO = Convert.ToString(HttpContext.Current.Request.QueryString["PrimerApellido"]);
            usuario.P_SEGUNDO_APELLIDO = Convert.ToString(HttpContext.Current.Request.QueryString["SegundoApellido"]);
            usuario.P_tipo_identificación = Convert.ToInt32(HttpContext.Current.Request.QueryString["TipoIdentificacion"]);
            usuario.P_ID_TERRITORIAL = Convert.ToInt32(HttpContext.Current.Request.QueryString["Territorial"]);
            usuario.P_ID_DEPARTAMENTO = Convert.ToInt32(HttpContext.Current.Request.QueryString["Departamento"]);
            usuario.P_ID_MUNICIPIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["Municipio"]);
            usuario.P_id_estado_usuario = Convert.ToInt32(HttpContext.Current.Request.QueryString["EstadoUsuario"]);

            ds1 = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, opcion); //23

            //buscar actividades relacionadas 
            Actividad_dia_encuesta_pregunta ADEM = new Actividad_dia_encuesta_pregunta();

            ADEM.F_USUARIO_CREACION = Convert.ToInt32(ds1.Tables[0].Rows[0]["ID_USUARIO"]);
            ds = FachadaPersistencia.getInstancia().actividad_dia_encuesta_respuesta_ultima(ADEM, 17);


            //return serializer.Serialize(objeto);
            var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]), usuario = DataTableToJSONWithJavaScriptSerializer(ds1.Tables[0]) };
            return objeto;

        }
        catch (Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }

    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object Usuarios_1(int opcion)
    {
        try
        {
            DataSet ds = new DataSet();
            Usuario usuario = new Usuario();

            usuario.Identificacion = Convert.ToString(HttpContext.Current.Request.QueryString["Identificacion"]);
            usuario.F_ID_USUARIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_usuario"]);
            usuario.P_ROL = Convert.ToInt32(HttpContext.Current.Request.QueryString["Rol"]);
            usuario.P_PRIMER_NOMBRE = Convert.ToString(HttpContext.Current.Request.QueryString["PrimerNombre"]);
            usuario.P_SEGUNDO_NOMBRE = Convert.ToString(HttpContext.Current.Request.QueryString["SegundoNombre"]);
            usuario.P_PRIMER_APELLIDO = Convert.ToString(HttpContext.Current.Request.QueryString["PrimerApellido"]);
            usuario.P_SEGUNDO_APELLIDO = Convert.ToString(HttpContext.Current.Request.QueryString["SegundoApellido"]);
            usuario.P_tipo_identificación = Convert.ToInt32(HttpContext.Current.Request.QueryString["TipoIdentificacion"]);
            usuario.P_ID_TERRITORIAL = Convert.ToInt32(HttpContext.Current.Request.QueryString["Territorial"]);
            usuario.P_ID_DEPARTAMENTO = Convert.ToInt32(HttpContext.Current.Request.QueryString["Departamento"]);
            usuario.P_ID_MUNICIPIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["Municipio"]);
            usuario.P_id_estado_usuario = Convert.ToInt32(HttpContext.Current.Request.QueryString["EstadoUsuario"]);

            ds = FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, opcion); //23

            
            //return serializer.Serialize(objeto);
            var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
            return objeto;

        }
        catch (Exception ex)
        {
            var objeto = new { resultado = ex };
            return objeto;
        }

    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object Consulta_actividad(int opcion)
    {
        DataSet ds = new DataSet();
        Actividad actividad = new Actividad();
        Persona persona = new Persona();

        try
        {
            if (opcion == 1) // por actualizar
            {
                actividad.P_ID_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_actividad"]); 

                ds = FachadaPersistencia.getInstancia().Consulta_actividad(actividad, persona, 5);

                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    //return serializer.Serialize(objeto);
                    var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
                    return objeto;
                }
            }
            else if (opcion == 2) // por consultar
            {
                actividad.P_ID_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_actividad"]);

                ds = FachadaPersistencia.getInstancia().Consulta_actividad(actividad, persona, 5);
               

                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    //return serializer.Serialize(objeto);
                    var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
                    return objeto;
                }
            }
            else
            {
                #region filtros de busqueda actividad

                actividad.P_ID_NOMBRE_ACTIVIDAD = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_actividad_nombre"]); 
                actividad.P_ID_DEPENDENCIA = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_dependencia"]); 
                actividad.P_ID_TERRITORIAL = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_territorial"]); 
                actividad.P_ID_DEPARTAMENTO = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_departamento"]);
                actividad.P_ID_MUNICIPIO = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_municipio"]); 
                actividad.P_ID_ACTIVIDAD_ESTADO = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_actividad_estado"]);
                actividad.P_ID_RESPONSABLE = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_responsable"]);
                actividad.P_USUARIO_CREACION = Convert.ToInt32(HttpContext.Current.Request.QueryString["id_usuario"]); // rol del participante (Tipo de particiapante)

                #endregion


                // permite consultar las actividades
                ds = FachadaPersistencia.getInstancia().Consulta_actividad(actividad, persona, 5);

                if (!ds.Tables[0].Rows.Count.Equals(0))
                {
                    //return serializer.Serialize(objeto);
                    var objeto = new { resultado = DataTableToJSONWithJavaScriptSerializer(ds.Tables[0]) };
                    return objeto;
                }
            }
            var objeto1 = new { resultado = "Error al realizar la consulta de las actividades" };
            return objeto1;
        }
        catch (System.Exception ex)
        {
            //"Error al realizar la consulta de las actividades"
            var objeto = new { resultado = ex };
            return objeto; 
        }
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static object UploadFile()
    {
        /*var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
        if (httpPostedFile != null)
        {
            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

            // Save the uploaded file to "UploadedFiles" folder
            httpPostedFile.SaveAs(fileSavePath);

            
        }*/
        var objeto = new { resultado = "TRUE" };
        return objeto;
    }

    #endregion
}