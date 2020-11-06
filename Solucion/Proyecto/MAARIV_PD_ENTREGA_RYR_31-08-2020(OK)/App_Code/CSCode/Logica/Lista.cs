using com.GACV.lgb.modelo.actividad_detalle;
using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de Listas
/// </summary>
public class Lista
{
    public Lista()
    {
    }

    public static void LD_Dia_actividad(int id_actividad, ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().LD_Dia_actividad(id_actividad, 1);

        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_actividad_dia";
            control.DataTextField = "dia_actividad";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccione el día", "0"));

        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccione el día", "0"));
        }
    }

    public static void L_D_Municipios(ref DropDownList control,int id_departamento)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Municipio(id_departamento, 0, 0);

        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_municipio";
            control.DataTextField = "municipio";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
    }
    public static void L_D_Entorno(ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().Get_Entorno();

        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "ID_ENTORNO";
            control.DataTextField = "ENTORNO";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccione el entorno", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccione el entorno", "0"));
        }
    }
    public static void L_D_Entidad(ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().GetTodasEntidadesRutaComunitaria();

        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "ID_ENTIDAD";
            control.DataTextField = "NOMBRE_ENTIDAD";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccione la entidad", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccione la entidad", "0"));
        }
    }
    public static void LD_Departamento_Dia(ref DropDownList control)
    {
        DataSet ds_m = new DataSet();

        ds_m = FachadaPersistencia.getInstancia().L_D_Municipio(Convert.ToInt32(control.SelectedValue), 0, 0);

        control.Items.Clear();

        if (!ds_m.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_municipio";
            control.DataTextField = "municipio";
            control.DataSource = ds_m;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
    }
    public static void L_D_Departamentos(ref DropDownList control, int id_territorial=0)
    {
        DataSet ds = new DataSet();

        ds = FachadaPersistencia.getInstancia().L_D_Departamentos(id_territorial);
        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_departamento";
            control.DataTextField = "departamento";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccione el departamento", "0"));
        }
    }

    public static void L_D_MunArchivo(string DepArchivo, ref DropDownList control)
    {
        DataSet ds_m = new DataSet();

        ds_m = FachadaPersistencia.getInstancia().L_D_Municipio(Convert.ToInt32(DepArchivo), 0, 0);

        control.Items.Clear();

        if (!ds_m.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_municipio";
            control.DataTextField = "municipio";
            control.DataSource = ds_m;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar el municipio", "0"));
        }
    }


    public static void L_D_Zona(ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Zona();
        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_zona";
            control.DataTextField = "zona";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar la zona", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar la zona", "0"));
        }
    }

    public static void L_D_Territorial(ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Territorial();
        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_territorio";
            control.DataTextField = "territorio";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar la territorial", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar la territorial", "0"));
        }
    }

    public static void L_D_alcance(ref DropDownList control, int rol)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_alcance(rol);

        control.Items.Clear();

        if (ds != null && ds.Tables.Count > 0)
        {
            if (!ds.Tables[0].Rows.Count.Equals(0))
            {
                control.DataValueField = "id_alcance";
                control.DataTextField = "alcance";
                control.DataSource = ds;
                control.DataBind();
                control.Items.Insert(0, new ListItem("Seleccionar alcance", "0"));
            }
            else
            {
                control.Items.Insert(0, new ListItem("Seleccionar alcance", "0"));
            }
        }
    }

    public static void L_D_tipo_sujeto(ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_tipo_sujeto();
        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "ID_TIPO_SUJETO_COLECTIVA";//revisar datos de la b.d ak y en el .aspx
            control.DataTextField = "TIPO_SUJETO_COLECTIVA";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar el tipo de sujeto", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar el tipo de sujeto", "0"));
        }
    }

    public static void L_D_subCategoria(ref DropDownList control, string LD_Tipo_sujeto, string opcion_Subcategoria)
    {
        try
        {
            DataSet ds = new DataSet();
            Actividad_detalle actividad_detalle = new Actividad_detalle();

            actividad_detalle.P_ID_ACTIVIDAD = Convert.ToInt32(LD_Tipo_sujeto);
            ds = FachadaPersistencia.getInstancia().Consulta_actividad_detalle(actividad_detalle, Convert.ToInt32(opcion_Subcategoria));
            control.Items.Clear();

            if (!ds.Tables[0].Rows.Count.Equals(0) && Convert.ToInt32(LD_Tipo_sujeto) != 0)
            {
                control.DataValueField = "ID_TIPO_SUJETO_COLECTIVA_DET";//revisar datos de la b.d ak y en el .aspx
                control.DataTextField = "TIPO_SUJETO_COLECTIVA_DET";
                control.DataSource = ds;
                control.DataBind();
                control.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
            else
            {
                control.Items.Insert(0, new ListItem("Seleccione", "0"));
            }
        }
        catch 
        {
        }
    }

    public static void L_D_Usuario(ref DropDownList control, int id_dependecia, int opcion)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().L_D_Usuario(id_dependecia, opcion);
        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "id_usuario";
            control.DataTextField = "usuario";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccione el usuario", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccione el usuario", "0"));
        }
    }

    public static void LD_Tipo_archivo(ref DropDownList control, int id_proceso, int opcion)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().LD_Tipo_archivo(id_proceso, opcion);
        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "ID_TIPO_ACTIVIDAD_ARCHIVO";
            control.DataTextField = "TIPO_ACTIVIDAD_ARCHIVO";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar el tipo de archivo", "0"));
        }
    }

    public static void LD_Actividad_nombre(ref DropDownList control, int id_dependencia, int opcion)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().LD_Actividad_nombre(id_dependencia, opcion);
        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "ID_NOMBRE_ACTIVIDAD";
            control.DataTextField = "NOMBRE_ACTIVIDAD";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccionar la actividad", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccionar la actividad", "0"));
        }

        control.SelectedValue = "204";
    }

    public static void L_D_Estado_Plan_RyR(ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().GetEstadosPlanRyR();

        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "ID_ESTADO_PLAN_RYR";
            control.DataTextField = "ESTADO_PLAN_RYR";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccione el Estado", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccione el Estado", "0"));
        }
    }

    public static void L_D_Tipo_Evidencia(ref DropDownList control)
    {
        DataSet ds = new DataSet();
        ds = FachadaPersistencia.getInstancia().Get_Tipo_Evidencia();

        control.Items.Clear();

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            control.DataValueField = "ID_TIPO_EVIDENCIA";
            control.DataTextField = "NOMBRE";
            control.DataSource = ds;
            control.DataBind();
            control.Items.Insert(0, new ListItem("Seleccione el Tipo de Envidencia", "0"));
        }
        else
        {
            control.Items.Insert(0, new ListItem("Seleccione el Tipo de Envidencia", "0"));
        }
    }

}