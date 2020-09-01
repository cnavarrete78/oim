/*
 *******************************************************************************************
  PROGRAMA				: crear_mensajes.cs
  FECHA DE CREACION	    : abril 14 de 2015
  FECHA DE MODIFICACION : abril 14 de 2015
  VERSION               : 1.0
  AUTOR                 : Emerson Pulido

 *******************************************************************************************

  CLASE			        : crear_mensajes.cs
  RESPONSABILIDAD	    : 
  COLABORACION		    : -
********************************************************************************************
*/

namespace com.GACV.lgb.modelo.crear_mensajes
{
    // Persona
    public class creacion_mensajes
    {

        private string MENSAJE = "";
        private string DEPENDENCIA = "";
        private int USUARIO = 0;
        private string FECHA_DE_INGRESO = "";
        private int ID_MENSAJES = 0;
        private string CALIFICACION = "0";
        private int ID_TIPO_MENSAJE;
        private string TIPO_MENSAJE;
        private string URL_IMAGEN;
        private string CALIFICACION_TEXT;




        /// Método constructor de la clase       
        public creacion_mensajes()
        {
        }
        #region Atributos de las cartas que se entregan


        public string P_CALIFICACION
        {
            get { return CALIFICACION; }
            set { CALIFICACION = value; }
        }
        public string P_CALIFICACION_TEXT
        {
            get { return CALIFICACION_TEXT; }
            set { CALIFICACION_TEXT = value; }
        }
        public int P_ID_MENSAJES
        {
            get { return ID_MENSAJES; }
            set { ID_MENSAJES = value; }
        }

        public string P_MENSAJE
        {
            get { return MENSAJE; }
            set { MENSAJE = value; }
        }

        public string P_DEPENDENCIA
        {
            get { return DEPENDENCIA; }
            set { DEPENDENCIA = value; }
        }
        public int P_USUARIO
        {
            get { return USUARIO; }
            set { USUARIO = value; }
        }
        public string P_FECHA_DE_INGRESO
        {
            get { return FECHA_DE_INGRESO; }
            set { FECHA_DE_INGRESO = value; }
        }

        public int P_ID_TIPO_MENSAJE
        {
            get { return ID_TIPO_MENSAJE; }
            set { ID_TIPO_MENSAJE = value; }
        }

        public string P_TIPO_MENSAJE
        {
            get { return TIPO_MENSAJE; }
            set { TIPO_MENSAJE = value; }
        }
        public string P_URL_IMAGEN
        {
            get { return URL_IMAGEN; }
            set { URL_IMAGEN = value; }
        }


        #endregion

    }
}