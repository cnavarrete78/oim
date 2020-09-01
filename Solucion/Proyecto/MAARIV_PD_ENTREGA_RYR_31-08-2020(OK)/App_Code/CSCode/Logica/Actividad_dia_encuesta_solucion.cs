using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Actividad_dia_encuesta_solucion
/// </summary>
/// 
namespace com.GACV.lgb.modelo.ADES
{
    public class Actividad_dia_encuesta_solucion
    {

        private int ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION = 0;
        private int ID_ACTIVIDAD_DIA = 0;
        private int ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA = 0;
        private string ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION = "";
        private int USUARIO_CREACION = 0;
        private DateTime FECHA_CREACION = DateTime.Now;
        private int USUARIO_MODIFICACION = 0;
        private DateTime FECHA_MODIFICACION = DateTime.Now;

        private int USUARIO_INTERACCION = 0;

        public Actividad_dia_encuesta_solucion()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public int F_ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION
        {
            get
            {
                return ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION;
            }
            set
            {
                ID_ACTIVIDAD_DIA_ENCUESTA_SOLUCION = value;
            }
        }
        public int F_ID_ACTIVIDAD_DIA
        {
            get
            {
                return ID_ACTIVIDAD_DIA;
            }
            set
            {
                ID_ACTIVIDAD_DIA = value;
            }
        }
        public int F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA
        {
            get
            {
                return ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA;
            }
            set
            {
                ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA = value;
            }
        }
        public string F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION
        {
            get
            {
                return ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION;
            }
            set
            {
                ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_OBSERVACION = value;
            }
        }
        public int F_USUARIO_CREACION
        {
            get
            {
                return USUARIO_CREACION;
            }
            set
            {
                USUARIO_CREACION = value;
            }
        }
        public DateTime F_FECHA_CREACION
        {
            get
            {
                return FECHA_CREACION;
            }
            set
            {
                FECHA_CREACION = value;
            }
        }
        public int F_USUARIO_MODIFICACION
        {
            get
            {
                return USUARIO_MODIFICACION;
            }
            set
            {
                USUARIO_MODIFICACION = value;
            }
        }
        public DateTime F_FECHA_MODIFICACION
        {
            get
            {
                return FECHA_MODIFICACION;
            }
            set
            {
                FECHA_MODIFICACION = value;
            }
        }

        public int F_USUARIO_INTERACCION
        {
            get
            {
                return USUARIO_INTERACCION;
            }
            set
            {
                USUARIO_INTERACCION = value;
            }
        }
    }
}
