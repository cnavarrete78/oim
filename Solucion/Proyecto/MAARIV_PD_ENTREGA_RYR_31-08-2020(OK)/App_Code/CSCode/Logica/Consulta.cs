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
    public static void GV_PersonasFicha(GridView control, int idComunidad)
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
}