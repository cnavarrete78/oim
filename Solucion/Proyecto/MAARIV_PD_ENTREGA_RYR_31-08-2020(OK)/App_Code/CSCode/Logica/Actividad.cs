/*
 *******************************************************************************************
  PROGRAMA				: Actividad.cs
  FECHA DE CREACION	    : 13-04-2015
  FECHA DE MODIFICACION : 16-08-2018
  VERSION               : 1.1
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
 *******************************************************************************************

  CLASE			        : Actividad.cs
  RESPONSABILIDAD	    : 
  COLABORACION		    : JULIAN A. BOCANEGRA M.
 
********************************************************************************************
*/


namespace com.GACV.lgb.modelo.actividad
{
    // logica para actividad
    public class Actividad
    {
        private int ID_ACTIVIDAD = 0;
        private int ID_FERIA = 0;
        private int ID_NOMBRE_ACTIVIDAD = 0;
        private string DESCRIPCION_ACTIVIDAD = "";
        private int ID_DEPENDENCIA = 0;
        private int TIENE_LIMITE_PERSONAS = 0;
        private int LIMITE_PERSONAS = 0;
        private int NUMERO_RESPONSABLES = 0;
        private int NUMERO_DIA_ACTIVIDAD = 0;
        private int ID_TIPO_ACTIVIDAD = 0;
        private int ID_ACTIVIDAD_ESTADO = 0;
        private string CORREGIMIENTO = "";

        private int USUARIO_CREACION= 0;
        private int USUARIO_MODIFICA = 0;

        private int ID_TERRITORIAL = 0;
        private int ID_DEPARTAMENTO = 0;
        private int ID_MUNICIPIO = 0;
        private int ID_RESPONSABLE = 0;
        private int ID_SRC = 0;

        private string FECHA_1 = "";
        private string FECHA_2 = "";

        private int ID_ACTIVIDAD_DIA_ESTADO = 0;

        private int ID_TABLEROS = 0;
        private string URL_REPORTE = "";

        private string FECHA_INICIO = "";
        private string FECHA_FIN = "";

        private int ID_TIPO_CONTACTO_COLECTIVA = 0;
        private int ID_DIRECTORIO = 0;
        private string ENTIDAD = "";
        private string NOMBRE = "";
        private string CARGO = "";
        private string EMAIL = "";
        private string TELEFONO = "";
        
              
      
        #region Atributos 

            public int P_ID_ACTIVIDAD
            {
                get { return ID_ACTIVIDAD; }
                set { ID_ACTIVIDAD = value; }
            }

            public int P_ID_SRC
            {
                get { return ID_SRC; }
                set { ID_SRC = value; }
            }

            public int P_ID_FERIA
            {
                get { return ID_FERIA; }
                set { ID_FERIA = value; }
            }

            public int P_ID_NOMBRE_ACTIVIDAD
            {
                get { return ID_NOMBRE_ACTIVIDAD; }
                set { ID_NOMBRE_ACTIVIDAD = value; }
            }

            public string P_DESCRIPCION_ACTIVIDAD
            {
                get { return DESCRIPCION_ACTIVIDAD; }
                set { DESCRIPCION_ACTIVIDAD = value; }
            }

            public int P_ID_DEPENDENCIA
            {
                get { return ID_DEPENDENCIA; }
                set { ID_DEPENDENCIA = value; }
            }

            public int P_TIENE_LIMITE_PERSONAS
            {
                get { return TIENE_LIMITE_PERSONAS; }
                set { TIENE_LIMITE_PERSONAS = value; }
            }

            public int P_LIMITE_PERSONAS
            {
                get { return LIMITE_PERSONAS; }
                set { LIMITE_PERSONAS = value; }
            }

            public int P_NUMERO_RESPONSABLES
            {
                get { return NUMERO_RESPONSABLES; }
                set { NUMERO_RESPONSABLES = value; }
            }

            public int P_NUMERO_DIA_ACTIVIDAD
            {
                get { return NUMERO_DIA_ACTIVIDAD; }
                set { NUMERO_DIA_ACTIVIDAD = value; }
            }

            public int P_ID_TIPO_ACTIVIDAD
            {
                get { return ID_TIPO_ACTIVIDAD; }
                set { ID_TIPO_ACTIVIDAD = value; }
            }

            public int P_ID_ACTIVIDAD_ESTADO
            {
                get { return ID_ACTIVIDAD_ESTADO; }
                set { ID_ACTIVIDAD_ESTADO = value; }
            }

            public string P_CORREGIMIENTO
            {
                get { return CORREGIMIENTO; }
                set { CORREGIMIENTO = value; }
            }

            public int P_ID_TERRITORIAL
            {
                get { return ID_TERRITORIAL; }
                set { ID_TERRITORIAL = value; }
            }

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

            public int P_ID_RESPONSABLE
            {
                get { return ID_RESPONSABLE; }
                set { ID_RESPONSABLE = value; }
            }

            public string P_FECHA_1
            {
                get { return FECHA_1; }
                set { FECHA_1 = value; }
            }

            public string P_FECHA_2
            {
                get { return FECHA_2; }
                set { FECHA_2 = value; }
            }

            public int P_ID_ACTIVIDAD_DIA_ESTADO
            {
                get { return ID_ACTIVIDAD_DIA_ESTADO; }
                set { ID_ACTIVIDAD_DIA_ESTADO = value; }
            }

            public int P_ID_TABLERO
            {
                get { return ID_TABLEROS; }
                set { ID_TABLEROS = value; }
            }

            public string P_URL_REPORTE
            {
                get { return URL_REPORTE; }
                set { URL_REPORTE = value; }
            }

            public string P_FECHA_INICIO
            {
                get { return FECHA_INICIO; }
                set { FECHA_INICIO = value; }
            }

            public string P_FECHA_FIN
            {
                get { return FECHA_FIN; }
                set { FECHA_FIN = value; }
            }


            public string P_ENTIDAD
            {
                get { return ENTIDAD; }
                set { ENTIDAD = value; }
            }

            public string P_NOMBRE
            {
                get { return NOMBRE; }
                set { NOMBRE = value; }
            }

            public string P_EMAIL
            {
                get { return EMAIL; }
                set { EMAIL = value; }
            }

            public string P_CARGO
            {
                get { return CARGO; }
                set { CARGO = value; }
            }

            public string P_TELEFONO
            {
                get { return TELEFONO; }
                set { TELEFONO = value; }
            }

            public int P_ID_TIPO_CONTACTO_COLECTIVA
            {
                get { return ID_TIPO_CONTACTO_COLECTIVA; }
                set { ID_TIPO_CONTACTO_COLECTIVA = value; }
            }

            public int P_ID_DIRECTORIO
            {
                get { return ID_DIRECTORIO; }
                set { ID_DIRECTORIO = value; }
            }
        
        
              
        #endregion

    }

}