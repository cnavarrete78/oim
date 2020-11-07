using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de Consulta
/// </summary>
public class Consulta
{
    public Consulta()
    {
    }
    public static void GV_PersonasFicha(GridView control)
    {
        DataSet dsPE = new DataSet();
        dsPE = Ficha.TraerPersonasComunidad();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            control.Visible = true;
            control.DataSource = dsPE;
            control.DataBind();
        }
        else
        {
            control.Visible = false;
            control.DataSource = dsPE;
            control.DataBind();
        }

        control.UseAccessibleHeader = true;
        control.HeaderRow.TableSection = TableRowSection.TableHeader;
        control.FooterRow.TableSection = TableRowSection.TableFooter;
        control.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public static void GV_PersonasPlanRyR(GridView control)
    {
        DataSet dsPE = new DataSet();
        dsPE = PlanRyR.TraerPersonasComunidad();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            control.Visible = true;
            control.DataSource = dsPE;
            control.DataBind();
        }
        else
        {
            control.Visible = false;
            control.DataSource = dsPE;
            control.DataBind();
        }

        control.UseAccessibleHeader = true;
        control.HeaderRow.TableSection = TableRowSection.TableHeader;
        control.FooterRow.TableSection = TableRowSection.TableFooter;
        control.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public static void GV_NecesidadesPlanRyR(GridView control)
    {
        DataSet dsPE = new DataSet();
        dsPE = PlanRyR.TraerNecesidadesComunidad();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            control.Visible = true;
            control.DataSource = dsPE;
            control.DataBind();
        }
        else
        {
            control.Visible = false;
            control.DataSource = dsPE;
            control.DataBind();
        }

        control.UseAccessibleHeader = true;
        control.HeaderRow.TableSection = TableRowSection.TableHeader;
        control.FooterRow.TableSection = TableRowSection.TableFooter;
        control.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public static void GV_Evidencias(GridView control)
    {
        DataSet dsPE = new DataSet();
        dsPE = Evidencia.TraerEvidencias();
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            control.Visible = true;
            control.DataSource = dsPE;
            control.DataBind();
        }
        else
        {
            control.Visible = false;
            control.DataSource = dsPE;
            control.DataBind();
        }
    }

    public static void GV_BienesServicios(GridView control,int idComponente)
    {
        DataSet dsPE = new DataSet();
        dsPE = PlanRyR.TraerBienesServicios(idComponente);
        if (!dsPE.Tables[0].Rows.Count.Equals(0))
        {
            control.Visible = true;
            control.DataSource = dsPE;
            control.DataBind();
        }
        else
        {
            control.Visible = false;
            control.DataSource = dsPE;
            control.DataBind();
        }
    }
}