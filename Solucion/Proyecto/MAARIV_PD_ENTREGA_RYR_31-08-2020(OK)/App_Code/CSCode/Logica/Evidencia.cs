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
    public static string PathConcepto { get; set; }
    public static string UrlArchivo { get; set; }
    public static string NombreArchivo { get; set; }
    public static string ExtArchivo { get; set; }
    public static int Usuario { get; set; }
    public static bool Activo { get; set; }
    public static DataSet Evidencias { get; set; }
    public static DataSet Archivos { get; set; }
    public static string Mensaje { get; set; }
    public Evidencia()
    {
    }

    public static void TraerEvidencia()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_EVIDENCIA", IdEvidencia));
        DataSet ds = FachadaPersistencia.getInstancia().Get_Evidencia(parametros);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            Evidencia.UrlArchivo = row["URL_ARCHIVO"].ToString();
            Evidencia.NombreArchivo = row["NOMBRE_ARCHIVO"].ToString();
            Evidencia.ExtArchivo = row["EXTENSION"].ToString();
        }
    }

    public static DataSet TraerEvidencias()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_CONTROL", IdControl));
        parametros.Add(new SqlParameter("CONCEPTO", Concepto));

        Evidencias =  FachadaPersistencia.getInstancia().Get_Evidencia(parametros);
        return Evidencias;
    }

    public static bool CargarEvidencia(FileUpload FU_MEvidencia)
    {
        bool result = true;
        string[] ext = { "doc", "xls", "pdf", "tif", "jpg", "rar", "zip", "7z", "png" };

        try
        {
            NombreArchivo = FU_MEvidencia.FileName;
            ExtArchivo = System.IO.Path.GetExtension(NombreArchivo);
            if ((FU_MEvidencia.FileName != "") && (FU_MEvidencia.PostedFile != null))
            {
                if (FU_MEvidencia.FileBytes.Length < 10485760)
                {
                    if(Array.FindAll(ext, e => e.Contains(ExtArchivo.Split('.')[1].Substring(0,3).ToLower())).Count()>0)
                    {
                        string path = string.Concat(System.Configuration.ConfigurationManager.AppSettings["Archivos"],PathConcepto);
                        string FileName = Evidencia.Concepto+"_"+Evidencia.IdControl.ToString() + "_" + (DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss").Replace(" ", "H")) + ExtArchivo;

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        UrlArchivo = String.Format("{0}\\{1}", path, FileName);
                        FU_MEvidencia.SaveAs(UrlArchivo);
                        GrabarEvidencia();
                    }
                    else
                    {
                        Mensaje = "El archivo no cumple con las extensiones permitidas!";
                        result = false;
                    }
                }
                else
                {
                    Mensaje = "Error al cargar el archivo, por que es mayor al tamaño permitido de 10 MB.";
                    result = false;
                }
            }
            else
            {
                Mensaje = "Error no ha seleccionado ningun archivo!.";
                result = false;
            }
        }
        catch
        {
            Mensaje = "Error procesando el archivo archivo!.";
            result = false;
        }

        return result;
    }

    public static void GrabarEvidencia()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_TIPO_EVIDENCIA", IdTipoEvidencia));
        parametros.Add(new SqlParameter("ID_CONTROL", IdControl));
        parametros.Add(new SqlParameter("CONCEPTO", Concepto));
        parametros.Add(new SqlParameter("URL_ARCHIVO", UrlArchivo));
        parametros.Add(new SqlParameter("NOMBRE_ARCHIVO", NombreArchivo));
        parametros.Add(new SqlParameter("EXTENSION", ExtArchivo));
        parametros.Add(new SqlParameter("USUARIO", Usuario));

        FachadaPersistencia.getInstancia().Set_Evidencia(parametros);
    }

    public static void EliminiarEvidencia()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_EVIDENCIA", IdEvidencia));

        FachadaPersistencia.getInstancia().Set_Evidencia(parametros);
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

}