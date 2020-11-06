using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de Evidencia
/// </summary>
public class Evidencia
{
    public static int IdEvidencia {get;set;}
    public static int IdTipoEvidencia { get; set; }
    public static int IdControl { get; set; }
    public static string Concepto { get; set; }
    public static string UrlArchivo { get; set; }
    public static string NombreArchivo { get; set; }
    public static string ExtArchivo { get; set; }
    public static int Usuario { get; set; }
    public static bool Activo { get; set; }
    public static DataSet Archivos { get; set; }
    public Evidencia()
    {
    }

    public static void TraerEvidencia()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_CONTROL", IdControl));
        parametros.Add(new SqlParameter("CONCEPTO", Concepto));

        Archivos = FachadaPersistencia.getInstancia().Get_Evidencia(parametros);
    }

    public static bool CargarEvidencia(FileUpload FU_MEvidencia)
    {
        return true;
    }

}