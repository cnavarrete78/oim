using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de Ficha
/// </summary>
public class Ficha
{
    public static bool FormularioActivo { get; set; }
    public static int Comunidad { get; set; }
    public static DateTime Fecha { get; set; }
    public static int Entidad { get; set; }
    public static int Territorial { get; set; }
    public static int Departamento { get; set; }
    public static int Municipio { get; set; }
    public static string Profesional { get; set; }
    public static string Correo { get; set; }
    public static string IntencionalidadRazones { get; set; }
    public static string IntencionalidadManifestacion { get; set; }
    public static string CondicionesActualesCaracteristicas { get; set; }
    public static string CondicionesActualesActividades { get; set; }
    public static int MujeresEmbarazo { get; set; }
    public static int PersonasEnfermedadRuinosa { get; set; }
    public static int TotalHogares { get; set; }
    public static int TotalPersonas { get; set; }
    public static int TotalPersonasRUV { get; set; }
    public static int HogaresReunificacionFamiliar { get; set; }
    public static int PersonasAtencionPsicosocial { get; set; }
    public static int Estado { get; set; }
    public static int Usuario { get; set; }
    public static DataSet Personas { get; set; }

    public Ficha()
    {
    }

    private static void LimpiarComunidad()
    {
        Fecha = new DateTime();
        Entidad = 0;
        Territorial = 0;
        Departamento = 0;
        Municipio = 0;
        Profesional = string.Empty;
        Correo = string.Empty;
        IntencionalidadRazones = string.Empty;
        IntencionalidadManifestacion = string.Empty;
        CondicionesActualesCaracteristicas = string.Empty;
        CondicionesActualesActividades = string.Empty;
        MujeresEmbarazo = 0;
        PersonasEnfermedadRuinosa = 0;
        TotalHogares = 0;
        TotalPersonas = 0;
        TotalPersonasRUV = 0;
        HogaresReunificacionFamiliar = 0;
        PersonasAtencionPsicosocial = 0;
    }
    public static bool TraerComunidad()
    {
        DataSet ds = FachadaPersistencia.getInstancia().Get_Comunidad(Comunidad);

        if (!ds.Tables[0].Rows.Count.Equals(0))
        {
            DataRow comunidad = ds.Tables[0].Rows[0];
            Fecha = Convert.ToDateTime(comunidad["FECHA"]);
            Entidad = Convert.ToInt32(comunidad["ID_ENTIDAD"]);
            Territorial = Convert.ToInt32(comunidad["ID_TERRITORIAL"]);
            Departamento = Convert.ToInt32(comunidad["ID_DEPARTAMENTO"]);
            Municipio = Convert.ToInt32(comunidad["ID_MUNICIPIO"]);
            Profesional = comunidad["PROFESIONAL"].ToString();
            Correo = comunidad["CORREO"].ToString();
            IntencionalidadRazones = comunidad["INTENCIONALIDAD_RAZONES"].ToString();
            IntencionalidadManifestacion = comunidad["INTENCIONALIDAD_MANIFESTACION"].ToString();
            CondicionesActualesCaracteristicas = comunidad["CONDICIONES_ACTUALES_CARACTERISTICAS"].ToString();
            CondicionesActualesActividades = comunidad["CONDICIONES_ACTUALES_ACTIVIDADES"].ToString();
            MujeresEmbarazo = Convert.ToInt32(comunidad["MUJERES_ESTADO_EMBARAZO"]);
            PersonasEnfermedadRuinosa = Convert.ToInt32(comunidad["PERSONAS_SITUACION_ENFERMEDAD_RUINOSA"]);
            TotalHogares = Convert.ToInt32(comunidad["TOTAL_HOGARES"]);
            TotalPersonas = Convert.ToInt32(comunidad["TOTAL_PERSONAS"]);
            TotalPersonasRUV = Convert.ToInt32(comunidad["TOTAL_PERSONASRUV"]);
            HogaresReunificacionFamiliar = Convert.ToInt32(comunidad["HOGARES_REUNIFICACION_FAMILIAR"]);
            PersonasAtencionPsicosocial = Convert.ToInt32(comunidad["PERSONAS_ATENCION_PSICOSOCIAL"]);
            return true;
        }
        else
        {
            LimpiarComunidad();
            return false;
        }

    }
    public static DataSet TraerPersonasComunidad()
    {
        Personas = FachadaPersistencia.getInstancia().Get_Personas_Comunidad(Comunidad);
        return Personas;
    }
    public static void GrabarComunidad()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_RYR_COMUNIDAD", Ficha.Comunidad));
        parametros.Add(new SqlParameter("FECHA", Ficha.Fecha));
        parametros.Add(new SqlParameter("ID_ENTIDAD", Ficha.Entidad));
        parametros.Add(new SqlParameter("ID_TERRITORIAL", Ficha.Territorial));
        parametros.Add(new SqlParameter("ID_DEPARTAMENTO", Ficha.Departamento));
        parametros.Add(new SqlParameter("ID_MUNICIPIO", Ficha.Municipio));
        parametros.Add(new SqlParameter("PROFESIONAL", Ficha.Profesional));
        parametros.Add(new SqlParameter("CORREO", Ficha.Correo));
        parametros.Add(new SqlParameter("INTENCIONALIDAD_RAZONES", Ficha.IntencionalidadRazones));
        parametros.Add(new SqlParameter("INTENCIONALIDAD_MANIFESTACION", Ficha.IntencionalidadManifestacion));
        parametros.Add(new SqlParameter("CONDICIONES_ACTUALES_CARACTERISTICAS", Ficha.CondicionesActualesCaracteristicas));
        parametros.Add(new SqlParameter("CONDICIONES_ACTUALES_ACTIVIDADES", Ficha.CondicionesActualesActividades));
        parametros.Add(new SqlParameter("MUJERES_ESTADO_EMBARAZO", Ficha.MujeresEmbarazo));
        parametros.Add(new SqlParameter("PERSONAS_SITUACION_ENFERMEDAD_RUINOSA", Ficha.PersonasEnfermedadRuinosa));
        parametros.Add(new SqlParameter("USUARIO", Ficha.Usuario));

        FachadaPersistencia.getInstancia().Set_Comunidad(parametros);
    }

    public static void ActualizarPersona(int idPersona, bool reunificacionFamiliar, bool atencionPsicosocial)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("ID_PERSONA", idPersona));
        parametros.Add(new SqlParameter("REUNIFICACION_FAMILIAR", reunificacionFamiliar));
        parametros.Add(new SqlParameter("ATENCION_PSICOSOCIAL", atencionPsicosocial));

        FachadaPersistencia.getInstancia().Set_Personas_Comunidad(parametros);
    }

}