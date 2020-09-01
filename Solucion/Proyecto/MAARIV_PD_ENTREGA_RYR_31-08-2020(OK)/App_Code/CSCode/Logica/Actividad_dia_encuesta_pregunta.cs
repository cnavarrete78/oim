using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Actividad_dia_encuesta_pregunta
/// </summary>
/// 
namespace com.GACV.lgb.modelo.ADEP
{
    public class Actividad_dia_encuesta_pregunta
    {
        private int ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = 0;
        private int ID_ACTIVIDAD_DIA = 0;
        private string ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = "";
        private int ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO = 0;
        private int ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO = 0;
        private int ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO = 0;
        private int USUARIO_CREACION = 0;
        private DateTime FECHA_CREACION = DateTime.Now;
        private int USUARIO_MODIFICACION = 0;
        private DateTime FECHA_MODIFICACION = DateTime.Now;

        //actividad dia pregunta solucion
        private int ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL = 0;
        private int ID_M_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = 0;
        private string ACTIVIDAD_DIA_ENCUESTA_TITULO = "";
        private string ACTIVIDAD_DIA_ENCUESTA_PARRAFO1 = "";
        private string ACTIVIDAD_DIA_ENCUESTA_PARRAFO2 = "";
        private string URL_ARCHIVO = "";

        //actividad dia resuesta
        private int ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA = 0;
        private string ACTIVIDAD_DIA_ENCUESTA_RESPUESTA = "";
        private int ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO = 0;

        //actividad dia encuesta pregunta respuesta
        private int ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO = 0;

        public Actividad_dia_encuesta_pregunta()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public int F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO
        {
            get
            {
                return ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO;
            }
            set
            {
                ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_RESPUESTA_ESTADO = value;
            }
        }

        public int F_ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA
        {
            get
            {
                return ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA;
            }
            set
            {
                ID_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA = value;
            }
        }
        public string F_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_RESPUESTA;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_RESPUESTA = value;
            }
        }
        public int F_ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_RESPUESTA_ESTADO = value;
            }
        }

        public int F_ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL
        {
            get
            {
                return ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL;
            }
            set
            {
                ID_ACTIVIDAD_DIA_ENCUESTA_MATERIAL = value;
            }
        }
        public int F_M_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA
        {
            get
            {
                return ID_M_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA;
            }
            set
            {
                ID_M_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = value;
            }
        }
        public string F_ACTIVIDAD_DIA_ENCUESTA_TITULO
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_TITULO;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_TITULO = value;
            }
        }
        public string F_ACTIVIDAD_DIA_ENCUESTA_PARRAFO1
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_PARRAFO1;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_PARRAFO1 = value;
            }
        }
        public string F_ACTIVIDAD_DIA_ENCUESTA_PARRAFO2
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_PARRAFO2;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_PARRAFO2 = value;
            }
        }
        public string F_URL_ARCHIVO
        {
            get
            {
                return URL_ARCHIVO;
            }
            set
            {
                URL_ARCHIVO = value;
            }
        }


        public int F_ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA
        {
            get
            {
                return ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA;
            }
            set
            {
                ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = value;
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
        public string F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_PREGUNTA;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_PREGUNTA = value;
            }
        }
        public int F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO = value;
            }
        }
        public int F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO = value;
            }
        }
        public int F_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO
        {
            get
            {
                return ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO;
            }
            set
            {
                ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_ESTADO = value;
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
    }
}
