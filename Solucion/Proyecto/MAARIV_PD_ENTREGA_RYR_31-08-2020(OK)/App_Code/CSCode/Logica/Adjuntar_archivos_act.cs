/*
 ****************************************************************************************************************************
  PROGRAMA				: Adjuntar_archivos_act.cs
  FECHA DE CREACION	    : 11-05-2015
  FECHA DE MODIFICACION : 09-08-2017
  VERSION               : 1.0
  AUTOR                 : Julian A. Bocanegra M.
 ****************************************************************************************************************************

  CLASE			        : Adjuntar_archivos_act.cs
  RESPONSABILIDAD	    : Se encarga de administrar la documentación correspondiente al modulo maestro de actividades
  COLABORACION		    : Gustavo Adolfo Caicedo Viveros
 
****************************************************************************************************************************
 * FECHA DE MODIFICACION : 09-08-2017
 * VERSION               : 1.1
 * AUTOR                 : Jose M Acosta.
 * DESCRIPCION           : Se agrega variables de actividad archivo detalle
 * 
*/


namespace com.GACV.lgb.modelo.adjuntar_archivos_act
{
    // Modulo maestro - Actividades
    public class Adjuntar_archivos_act
    {
        private int ID_ACTIVIDAD = 0;
        private int ID_ACTIVIDAD_ARCHIVO = 0;
        private string NOMBRE_ARCHIVO = "";
        private int ID_TIPO_ACTIVIDAD_ARCHIVO = 0;
        private string FECHA_EXPEDICION = "";
        private string FECHA_VENCIMIENTO = "";
        private string URL_ARCHIVO = "";
        private string EXTENSION = "";
        private int USUARIO_CREACION = 0;
        private int USUARIO_MODIFICA = 0;
        private int ID_ACTIVIDAD_DIA = 0;
        private int ID_ACTIVIDAD_ARCHIVO_ESTADO = 0;


        //ACTIVIDAD ARCHIVO DETALLE 
        private int ID_ACTIVIDAD_ARCHIVO_DETALLE = 0;
        private string PERSONAS = "";
        private int ID_MUNICIPIO = 0;
        private string DESCRIPCION = "";
        private int ID_SRC = 0;



        /// Método constructor de la clase descripcion oferta
        public Adjuntar_archivos_act()
        {
        }

        #region MM_ACTIVIDADES

            public int P_ID_ACTIVIDAD
            {
                get { return ID_ACTIVIDAD; }
                set { ID_ACTIVIDAD = value; }
            }

            public int P_ID_ACTIVIDAD_ARCHIVO
            {
                get { return ID_ACTIVIDAD_ARCHIVO; }
                set { ID_ACTIVIDAD_ARCHIVO = value; }
            }

            public string P_NOMBRE_ARCHIVO
            {
                get { return NOMBRE_ARCHIVO; }
                set { NOMBRE_ARCHIVO = value; }
            }

            public int P_ID_TIPO_ACTIVIDAD_ARCHIVO
            {
                get { return ID_TIPO_ACTIVIDAD_ARCHIVO; }
                set { ID_TIPO_ACTIVIDAD_ARCHIVO = value; }
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

            public string P_URL_ARCHIVO
            {
                get { return URL_ARCHIVO; }
                set { URL_ARCHIVO = value; }
            }

            public string P_EXTENSION
            {
                get { return EXTENSION; }
                set { EXTENSION = value; }
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

            public int P_ID_ACTIVIDAD_DIA
            {
                get { return ID_ACTIVIDAD_DIA; }
                set { ID_ACTIVIDAD_DIA = value; }
            }

            public int P_ID_ACTIVIDAD_ARCHIVO_ESTADO
            {
                get { return ID_ACTIVIDAD_ARCHIVO_ESTADO; }
                set { ID_ACTIVIDAD_ARCHIVO_ESTADO = value; }
            }


        //ACTIVIDAD ARCHIVO DETALLE

            public int P_ID_ACTIVIDAD_ARCHIVO_DETALLE
            {
                get { return ID_ACTIVIDAD_ARCHIVO_DETALLE; }
                set { ID_ACTIVIDAD_ARCHIVO_DETALLE = value; }
            }



            public string P_PERSONAS
            {
                get { return PERSONAS; }
                set { PERSONAS = value; }
            }

            public int P_ID_MUNICIPIO
            {
                get { return ID_MUNICIPIO; }
                set { ID_MUNICIPIO = value; }
            }

            public string P_DESCRIPCION
            {
                get { return DESCRIPCION; }
                set { DESCRIPCION = value; }
            }

            public int P_ID_SRC
            {
                get { return ID_SRC; }
                set { ID_SRC = value; }
            }

        #endregion
    }

}


