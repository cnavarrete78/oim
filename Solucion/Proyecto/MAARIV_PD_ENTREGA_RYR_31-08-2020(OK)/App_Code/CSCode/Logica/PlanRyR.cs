using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PlanRyR
/// </summary>
public class PlanRyR
{
    public static bool FormularioActivo { get; set; }
    public static int Comunidad { get; set; }
    public static string NombreComunidad { get; set; }
    public static DateTime FechaMedicion { get; set; }
    public static int Territorial { get; set; }
    public static int Departamento { get; set; }
    public static int Municipio { get; set; }
    public static int Entorno { get; set; }
    public static string Direccion { get; set; }
    public static string Profesional { get; set; }
    public static string Correo { get; set; }
    public static DateTime FechaActa { get; set; }
    public static int EstadoPlan { get; set; }
    public static int Usuario { get; set; }
    public static int TotalHogares { get; set; }
    public static int TotalPersonas { get; set; }
    public static int TotalPersonasRUV { get; set; }
    public static DataSet Personas { get; set; }
    public static DataSet Necesidades { get; set; }
    public static int Necesidad { get; set; }
    public static string Acciones { get; set; }
    public static DateTime FechaInicio { get; set; }
    public static DateTime FechaCierre { get; set; }
    public PlanRyR()
    {
    }

    private static void LimpiarComunidad()
    {
        FechaMedicion = new DateTime();
        Territorial = 0;
        Departamento = 0;
        Municipio = 0;
        Entorno = 0;
        Direccion = string.Empty;
        Profesional = string.Empty;
        Correo = string.Empty;
        FechaActa = new DateTime();
        EstadoPlan = 0;
        Usuario = 0;
        TotalHogares = 0;
        TotalPersonas = 0;
        TotalPersonasRUV = 0;
    }
    public static bool TraerComunidad()
    {
        DataSet ds = FachadaPersistencia.getInstancia().Get_Plan_RyR(Comunidad);

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            DataRow comunidad = ds.Tables[0].Rows[0];

            NombreComunidad = comunidad["NOMBRE_RYR_COMUNIDAD"].ToString();
            FechaMedicion = Convert.ToDateTime(comunidad["FECHA_MEDICION"]);
            Territorial = Convert.ToInt32(comunidad["ID_TERRITORIAL"]);
            Departamento = Convert.ToInt32(comunidad["ID_DEPARTAMENTO"]);
            Municipio = Convert.ToInt32(comunidad["ID_MUNICIPIO"]);
            Entorno = Convert.ToInt32(comunidad["ID_ENTORNO"]);
            Direccion = comunidad["DIRECCION"].ToString();
            Profesional = comunidad["PROFESIONAL"].ToString();
            Correo = comunidad["CORREO"].ToString();
            FechaActa = Convert.ToDateTime(comunidad["FECHA_ACTA_CTJT"]);
            EstadoPlan = Convert.ToInt32(comunidad["ID_ESTADO_PLAN_RYR"]);
            TotalHogares = Convert.ToInt32(comunidad["TOTAL_HOGARES"]);
            TotalPersonas = Convert.ToInt32(comunidad["TOTAL_PERSONAS"]);
            TotalPersonasRUV = Convert.ToInt32(comunidad["TOTAL_PERSONASRUV"]);
            return true;
        }
        else
        {
            LimpiarComunidad();
            return false;
        }

    }
    public static void GrabarPlan()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_RYR_COMUNIDAD", Comunidad));
        parametros.Add(new SqlParameter("FECHA_MEDICION", FechaMedicion));
        parametros.Add(new SqlParameter("ID_TERRITORIAL", Territorial));
        parametros.Add(new SqlParameter("ID_DEPARTAMENTO", Departamento));
        parametros.Add(new SqlParameter("ID_MUNICIPIO", Municipio));
        parametros.Add(new SqlParameter("ID_ENTORNO", Entorno));
        parametros.Add(new SqlParameter("DIRECCION", Direccion));
        parametros.Add(new SqlParameter("PROFESIONAL", Profesional));
        parametros.Add(new SqlParameter("CORREO", Correo));
        parametros.Add(new SqlParameter("FECHA_ACTA_CTJT", FechaActa));
        parametros.Add(new SqlParameter("ID_ESTADO_PLAN_RYR", EstadoPlan));
        parametros.Add(new SqlParameter("USUARIO", Usuario));

        FachadaPersistencia.getInstancia().Set_Plan_RyR(parametros);
    }

    public static DataSet TraerPersonasComunidad()
    {
        Personas = FachadaPersistencia.getInstancia().Get_Personas_Comunidad(Comunidad);
        return Personas;
    }

    public static DataSet TraerNecesidadesComunidad()
    {
        Necesidades = FachadaPersistencia.getInstancia().Get_Necesidades_Comunidad(Comunidad);
        return Necesidades;
    }

    public static void GrabarNecesidadPlan()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_RYR_COMUNIDAD", Comunidad));
        parametros.Add(new SqlParameter("ID_NECESIDAD", Necesidad));
        parametros.Add(new SqlParameter("ACCIONES", Acciones));
        parametros.Add(new SqlParameter("FECHA_INICIO_TRAMITE", FechaInicio));
        parametros.Add(new SqlParameter("FECHA_CIERRE_TRAMITE", FechaCierre));

        FachadaPersistencia.getInstancia().Set_Necesidad_Comunidad(parametros);
    }
}