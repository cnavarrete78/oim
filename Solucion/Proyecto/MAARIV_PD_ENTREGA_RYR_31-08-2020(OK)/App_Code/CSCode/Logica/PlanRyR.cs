using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    public static DateTime FechaInicioPlanRyR { get; set; }
    public static DateTime FechaDialogoPlanRyR { get; set; }
    public static int Territorial { get; set; }
    public static string NombreTerritorial { get; set; }
    public static int Departamento { get; set; }
    public static string NombreDepartamento { get; set; }
    public static int Municipio { get; set; }
    public static string NombreMunicipio { get; set; }
    public static int Entorno { get; set; }
    public static string NombreEntorno { get; set; }
    public static string Direccion { get; set; }
    public static string Profesional { get; set; }
    public static string Correo { get; set; }
    public static DateTime FechaActa { get; set; }
    public static int EstadoPlan { get; set; }
    public static int Usuario { get; set; }
    public static int TotalNoSuperanGI { get; set; }
    public static int TotalHogares { get; set; }
    public static int TotalPersonas { get; set; }
    public static int TotalPersonasRUV { get; set; }
    public static DataSet Personas { get; set; }
    public static DataSet PersonasDetalle { get; set; }
    public static DataSet Necesidades { get; set; }

    public static int Necesidad { get; set; }
    public static string Acciones { get; set; }
    public static DateTime FechaInicio { get; set; }
    public static DateTime FechaCierre { get; set; }

    public static int BienServicioId { get; set; }
    public static string BienServicioNombre { get; set; }
    public static int BienServicioMeta { get; set; }
    public static int BienServicioVictimasDirectas { get; set; }
    public static int BienServicioVictimasIndirectas { get; set; }
    public static int BienServicioVictimasBeneficiadas { get; set; }
    public static int BienServicioIdComponente { get; set; }
    public static int BienServicioPersonasNoVictimasBeneficiadas { get; set; }
    public static int BienServicioPersonasBeneficiadas { get; set; }
    public static long BienServicioIniciativaPDET { get; set; }
    public static DataSet BienesServiciosGI { get; set; }
    public static DataSet BienesServiciosIC { get; set; }

    public static int ActividadId { get; set; }
    public static int ActividadClasificacionId { get; set; }
    public static string ActividadNombre { get; set; }
    public static bool ActividadCumplida { get; set; }
    public static DateTime ActividadFecha { get; set; }
    public static string ActividadResponsable { get; set; }
    public static decimal ActividadCosto { get; set; }
    public static bool ActividadActivo { get; set; }

    public static DataSet Actividades { get; set; }

    public PlanRyR()
    {
    }

    private static void LimpiarComunidad()
    {
        FechaMedicion = new DateTime();
        FechaInicioPlanRyR = new DateTime();
        FechaDialogoPlanRyR = new DateTime();
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
        TotalNoSuperanGI = 0;
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
            DateTime fecha;

            NombreComunidad = comunidad["NOMBRE_RYR_COMUNIDAD"].ToString();
            FechaMedicion = DateTime.TryParse(comunidad["FECHA_MEDICION"].ToString(), out fecha) ? fecha : new DateTime();
            FechaInicioPlanRyR = DateTime.TryParse(comunidad["FECHA_INICIO"].ToString(), out fecha) ? fecha : new DateTime();
            FechaDialogoPlanRyR = DateTime.TryParse(comunidad["FECHA_DIALOGO"].ToString(), out fecha) ? fecha : new DateTime();
            Territorial = Convert.ToInt32(comunidad["ID_TERRITORIAL"]);
            NombreTerritorial = comunidad["NOMBRE_ENTIDAD"].ToString();
            Departamento = Convert.ToInt32(comunidad["ID_DEPARTAMENTO"]);
            NombreDepartamento = comunidad["DEPARTAMENTO"].ToString();
            Municipio = Convert.ToInt32(comunidad["ID_MUNICIPIO"]);
            NombreMunicipio = comunidad["MUNICIPIO"].ToString();
            Entorno = Convert.ToInt32(comunidad["ID_ENTORNO"]);
            NombreEntorno = comunidad["ENTORNO"].ToString();
            Direccion = comunidad["DIRECCION"].ToString();
            Profesional = comunidad["PROFESIONAL"].ToString();
            Correo = comunidad["CORREO"].ToString();
            FechaActa = DateTime.TryParse(comunidad["FECHA_ACTA_CTJT"].ToString(), out fecha) ? fecha : new DateTime(); 
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
        parametros.Add(new SqlParameter("TOTAL_NO_SUPERAN_GI", TotalNoSuperanGI));
        parametros.Add(new SqlParameter("FECHA_INICIO", FechaInicioPlanRyR));
        parametros.Add(new SqlParameter("FECHA_DIALOGO", FechaDialogoPlanRyR));
        parametros.Add(new SqlParameter("USUARIO", Usuario));

        FachadaPersistencia.getInstancia().Set_Plan_RyR(parametros);
    }

    public static DataSet TraerPersonasComunidad()
    {
        Personas = FachadaPersistencia.getInstancia().Get_Personas_Comunidad_Plan_RyR(Comunidad);
        return Personas;
    }
    public static DataSet TraerPersonasDetalleComunidad()
    {
        PersonasDetalle = FachadaPersistencia.getInstancia().Get_Personas_Detalle_Comunidad_Plan_RyR(Comunidad);
        return PersonasDetalle;
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

    public static DataSet TraerBienesServicios(int idComponente)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_RYR_COMUNIDAD", Comunidad));
        parametros.Add(new SqlParameter("ID_COMPONENTE", idComponente));
        return FachadaPersistencia.getInstancia().Get_BienesServicios_Comunidad(parametros);
    }
    public static void GrabarBienesServiciosPlan()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_PLAN_RYR_BIEN_SERVICIO", BienServicioId));
        parametros.Add(new SqlParameter("ID_RYR_COMUNIDAD", Comunidad));
        parametros.Add(new SqlParameter("BIEN_SERVICIO", BienServicioNombre));
        parametros.Add(new SqlParameter("META", BienServicioMeta));
        parametros.Add(new SqlParameter("VICTIMAS_ACOMPANADAS_DIRECTAMENTE", BienServicioVictimasDirectas));
        parametros.Add(new SqlParameter("VICTIMAS_ACOMPANADAS_INDIRECTAMENTE", BienServicioVictimasIndirectas));
        parametros.Add(new SqlParameter("ID_COMPONENTE", BienServicioIdComponente));
        parametros.Add(new SqlParameter("PERSONAS_NO_VICTIMAS_BENEFICIADAS", BienServicioPersonasNoVictimasBeneficiadas));
        parametros.Add(new SqlParameter("PERSONAS_BENEFICIADAS", BienServicioPersonasBeneficiadas));
        parametros.Add(new SqlParameter("INICIATIVAPDET", BienServicioIniciativaPDET));

        FachadaPersistencia.getInstancia().Set_BienesServicios_Comunidad(parametros);
        LimpiarBienesServicios();
    }

    public static void EliminarBienesServiciosPlan()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_PLAN_RYR_BIEN_SERVICIO", BienServicioId));
        parametros.Add(new SqlParameter("ACTIVO", false));

        FachadaPersistencia.getInstancia().Set_BienesServicios_Comunidad(parametros);
    }

    public static void LimpiarBienesServicios()
    {
        BienServicioId = 0;
        BienServicioNombre = "";
        BienServicioMeta = 0;
        BienServicioVictimasDirectas = 0;
        BienServicioVictimasIndirectas = 0;
        BienServicioVictimasBeneficiadas = 0;
        BienServicioIdComponente = 0;
        BienServicioPersonasNoVictimasBeneficiadas = 0;
        BienServicioPersonasBeneficiadas = 0;
        BienServicioIniciativaPDET = 0;
    }

    public static DataSet TraerActividadBienesServicios()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_PLAN_RYR_BIEN_SERVICIO", BienServicioId));
        return FachadaPersistencia.getInstancia().Get_ActividadBienesServicios_Comunidad(parametros);
    }
    public static void GrabarActividadBienesServiciosPlan()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_PLAN_RYR_BIEN_SERVICIO_ACTIVIDAD", ActividadId));
        parametros.Add(new SqlParameter("ID_PLAN_RYR_BIEN_SERVICIO", BienServicioId));
        parametros.Add(new SqlParameter("ID_CLASIFICACION_ACTIVIDAD", ActividadClasificacionId));
        parametros.Add(new SqlParameter("ACTIVIDAD", ActividadNombre));
        parametros.Add(new SqlParameter("CUMPLIDA", ActividadCumplida));
        parametros.Add(new SqlParameter("FECHA_ACTIVIDAD", ActividadFecha));
        parametros.Add(new SqlParameter("RESPONSABLE", ActividadResponsable));
        parametros.Add(new SqlParameter("COSTO", ActividadCosto));
        parametros.Add(new SqlParameter("ACTIVO", ActividadActivo));

        FachadaPersistencia.getInstancia().Set_ActividadBienesServicios_Comunidad(parametros);
        LimpiarActividadBienesServicios();
    }

    public static void EliminarActividadBienesServiciosPlan()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_PLAN_RYR_BIEN_SERVICIO_ACTIVIDAD", ActividadId));
        parametros.Add(new SqlParameter("ACTIVO", false));

        FachadaPersistencia.getInstancia().Set_ActividadBienesServicios_Comunidad(parametros);
    }

    public static void LimpiarActividadBienesServicios()
    {
        ActividadId = 0;
        ActividadClasificacionId = 0;
        ActividadNombre = "";
        ActividadCumplida = false;
        ActividadFecha = new DateTime();
        ActividadResponsable = "";
        ActividadCosto = 0;
        ActividadActivo = false;
    }
}