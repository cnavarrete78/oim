/*
 ****************************************************************************************************************************
  PROGRAMA				: Adjuntar_archivos.cs
  FECHA DE CREACION	    : 01-08-2013
  FECHA DE MODIFICACION : 01-08-2013
  VERSION               : 1.0
  AUTOR                 : Catherine Alvarez Vera
 ****************************************************************************************************************************

  CLASE			        : Adjuntar_archivos.cs
  RESPONSABILIDAD	    : Se encarga de manejar la documentación correspondiente a la oferta 
  COLABORACION		    : Ninguna
 
****************************************************************************************************************************
*/

using System;
//using System.Drawing;

namespace com.GACV.lgb.modelo.adjuntar_archivos
{
    // Descripcion_oferta
    public class Adjuntar_archivos
    {
        private int ID_DEPARTAMENTO = 0;
        private int ID_MUNICIPIO = 0;
        private int ID_OFERTA_ARCHIVOS = 0;
        private int ID_DOCUMENTO = 0;
        private int ID_USUARIO = 0;
        private string USUARIO = "";
        private string NOMBRE_DOCUMENTO = "";
        private int ID_TIPO_DOCUMENTO = 0;
        private string FECHA_EXPEDICION = "";
        private string FECHA_VENCIMIENTO = "";
        private byte[] ARCHIVO;
        private int ID_OFERTA = 0;
        private int USUARIO_CREACION;
        private int USUARIO_MODIFICA;
        private DateTime FECHA_CREACION;
        private DateTime FECHA_MODIFICA;
        private string RUTA_ORFEO = "";
        private long NUMERO_RADICO_ORFEO = 0;
	    private string MENSAJE_RESPUESTA_ORFEO = "";
                       
        // Variables Tierras
        private int ID_RETORNO_ARCHIVOS = 0;
        private int ID_SOLICITUD = 0;
        private int ID_PERSONA = 0;
        private int ID_SEGURIDAD;

        // Variables Colectiva
        private int ID_SUJETO_COLECTIVA = 0;
        private int MOD_NID_ANEXO = 0;

        private int ID_VEREDA_BARRIO;

        // paari
        private int RADICADO;

        //eventos
        private int ID_EVENTOS;

        //SOLICITUDES OAJ
        private int ID_SOLICITUD_OAJ;
        private int ID_SOLICITUD_PERSONA;
        private string EXTENSION;
        private int ID_ESTADO_IMAGEN_OAJ = 0;

        //SOLICITUDES RYR
        private int ID_PARAMETRIZACION_ACOMPANAMIENTO = 0;
        private int ID_ESTADO_ACOMPANAMIENTO = 0;
        private int ID_FUENTE = 0;
        private string URL_ARCHIVO = "";
        private int ID_ESTADO_VICTIMA = 0;

        // Retornos
        private int DIRECCION_TERRITORIAL = 0;
        private int DEPARTAMENTO = 0;
        private int MUNICIPIO = 0;

        //Solicitudes cys
        private int ID_TIKET = 0;     

        /// Método constructor de la clase descripcion oferta
        public Adjuntar_archivos()
        {
        }

        #region Atributos de la descripcion de la oferta

            public int P_ID_DEPARTAMENTO
            {
                get { return ID_DEPARTAMENTO; }
                set { ID_DEPARTAMENTO = value; }
            }

            public int P_ID_MUNICIPIO
            {
                get { return ID_MUNICIPIO; }
                set { ID_MUNICIPIO = value; }
            }

            public int P_ID_OFERTA_ARCHIVOS
            {
                get { return ID_OFERTA_ARCHIVOS; }
                set { ID_OFERTA_ARCHIVOS = value; }
            }  
        
            public int P_ID_DOCUMENTO
            {
                get { return ID_DOCUMENTO; }
                set { ID_DOCUMENTO = value; }
            }
        
            public int P_ID_USUARIO
            {
                get { return ID_USUARIO; }
                set { ID_USUARIO = value; }
            }

            public string P_USUARIO
            {
                get { return USUARIO; }
                set { USUARIO = value; }
            }

            public string P_NOMBRE_DOCUMENTO
            {
                get { return NOMBRE_DOCUMENTO; }
                set { NOMBRE_DOCUMENTO = value; }
            }

            public int P_ID_TIPO_DOCUMENTO
            {
                get { return ID_TIPO_DOCUMENTO; }
                set { ID_TIPO_DOCUMENTO = value; }
            }

            public string P_FECHA_EXPEDICION
            {
                get { return FECHA_EXPEDICION; }
                set { FECHA_EXPEDICION = value; }
            }

            public string P_FECHA_VENCIMIENTO
            {
                get { return FECHA_VENCIMIENTO; }
                set { FECHA_VENCIMIENTO = value; }
            }

            public byte[] P_ARCHIVO
            {
                get { return ARCHIVO; }
                set { ARCHIVO = value; }
            }

            public int P_ID_OFERTA
            {
                get { return ID_OFERTA; }
                set { ID_OFERTA = value; }
            }

            public int P_USUARIO_CREACION
            {
                get { return USUARIO_CREACION; }
                set { USUARIO_CREACION = value; }
            }

            public int P_USUARIO_MODIFICA
            {
                get { return USUARIO_MODIFICA; }
                set { USUARIO_MODIFICA = value; }
            }

            public DateTime P_FECHA_CREACION
            {
                get { return FECHA_CREACION; }
                set { FECHA_CREACION = value; }
            }

            public DateTime P_FECHA_MODIFICA
            {
                get { return FECHA_MODIFICA; }
                set { FECHA_MODIFICA = value; }
            }

            public string P_RUTA_ORFEO
            {
                get { return RUTA_ORFEO;  }
                set { RUTA_ORFEO = value;  }
            }

            public long P_NUMERO_RADICO_ORFEO	
            {
                get{ return NUMERO_RADICO_ORFEO;  }
                set{ NUMERO_RADICO_ORFEO = value; }
            }

            public string P_MENSAJE_RESPUESTA_ORFEO
            {
                get { return MENSAJE_RESPUESTA_ORFEO; }
                set { MENSAJE_RESPUESTA_ORFEO = value; }
            }

        #endregion

        #region Retorno y reubicaciones

            public int P_ID_RETORNO_ARCHIVOS
            {
                get { return ID_RETORNO_ARCHIVOS; }
                set { ID_RETORNO_ARCHIVOS = value; }
            }

            public int P_ID_SOLICITUD
            {
                get { return ID_SOLICITUD; }
                set { ID_SOLICITUD = value; }
            }

            public int P_ID_PERSONA
            {
                get { return ID_PERSONA; }
                set { ID_PERSONA = value; }
            }

            public int P_DIRECCION_TERRITORIAL
            {
                get { return DIRECCION_TERRITORIAL; }
                set { DIRECCION_TERRITORIAL = value; }
            }

            public int P_DEPARTAMENTO
            {
                get { return DEPARTAMENTO; }
                set { DEPARTAMENTO = value; }
            }

            public int P_MUNICIPIO
            {
                get { return MUNICIPIO; }
                set { MUNICIPIO = value; }
            }

            public string P_URL_ARCHIVO
            {
                get { return URL_ARCHIVO; }
                set { URL_ARCHIVO = value; }
            }

            public int P_ID_ESTADO_VICTIMA
            {
                get { return ID_ESTADO_VICTIMA; }
                set { ID_ESTADO_VICTIMA = value; }
            }

        #endregion

        #region Colectiva

            public int P_ID_SUJETO_COLECTIVA
            {
                get { return ID_SUJETO_COLECTIVA; }
                set { ID_SUJETO_COLECTIVA = value; }
            }

            public int P_MOD_NID_ANEXO
            {
                get { return MOD_NID_ANEXO; }
                set { MOD_NID_ANEXO = value; }
            }

        #endregion

        #region Tierras choque

            public int P_ID_VEREDA_BARRIO
            {
                get { return ID_VEREDA_BARRIO; }
                set { ID_VEREDA_BARRIO = value; }
            }            

        #endregion 

        #region SEGURIDAD

        public int P_ID_SEGURIDAD
        {
            get { return ID_SEGURIDAD; }
            set { ID_SEGURIDAD = value; }
        }

        #endregion

        #region PAARI

            public int P_RADICADO
            {
                get { return RADICADO; }
                set { RADICADO = value; }
            }

        #endregion
            
        #region EVENTOS

            public int P_ID_EVENTOS
            {
                get { return ID_EVENTOS; }
                set { ID_EVENTOS = value; }
            }

            #endregion

        #region SOLICITUDES OAJ

            public int P_ID_SOLICITUD_OAJ
            {
                get { return ID_SOLICITUD_OAJ; }
                set { ID_SOLICITUD_OAJ = value; }
            }

            public int P_ID_SOLICITUD_PERSONA
            {
                get { return ID_SOLICITUD_PERSONA; }
                set { ID_SOLICITUD_PERSONA = value; }
            }

            public string P_EXTENSION
            {
                get { return EXTENSION; }
                set { EXTENSION = value; }
            }

            public int P_ID_ESTADO_IMAGEN_OAJ
            {
                get { return ID_ESTADO_IMAGEN_OAJ; }
                set { ID_ESTADO_IMAGEN_OAJ = value; }
            }
           
        #endregion

        #region SOLICITUDES RYR

            public int P_ID_PARAMETRIZACION_ACOMPANAMIENTO
            {
                get { return ID_PARAMETRIZACION_ACOMPANAMIENTO; }
                set { ID_PARAMETRIZACION_ACOMPANAMIENTO = value; }
            }

            public int P_ID_ESTADO_ACOMPANAMIENTO
            {
                get { return ID_ESTADO_ACOMPANAMIENTO; }
                set { ID_ESTADO_ACOMPANAMIENTO = value; }
            }

            public int P_ID_FUENTE
            {
                get { return ID_FUENTE; }
                set { ID_FUENTE = value; }
            }            

        #endregion
        
        #region SOLICITUDES CYS

            public int P_ID_TIKET
            {
                get { return ID_TIKET; }
                set { ID_TIKET = value; }
            }

        #endregion

    }

}


