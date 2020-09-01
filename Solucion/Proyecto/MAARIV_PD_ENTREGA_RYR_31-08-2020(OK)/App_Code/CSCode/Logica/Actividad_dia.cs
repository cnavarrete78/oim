/*
 *******************************************************************************************
  PROGRAMA				: Actividad_dia.cs
  FECHA DE CREACION	    : 13-04-2015
  FECHA DE MODIFICACION : 19-02-2018
  VERSION               : 1.1
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
 *******************************************************************************************

  CLASE			        : Actividad_dia.cs
  RESPONSABILIDAD	    : 
  COLABORACION		    : EMERSON PULIDO NOY
 
********************************************************************************************
*/


namespace com.GACV.lgb.modelo.actividad_dia
{
    // logica para actividad dia
    public class Actividad_dia
    {
        private int ID_ACTIVIDAD_DIA = 0;
        private int ID_ACTIVIDAD = 0;
        private string DIA_ACTIVIDAD = "";
        private string LUGAR_ACTIVIDAD = "";
        private string HORA_INICIO = "";
        private string HORA_FIN = "";
        private string OBSERVACION_ACTIVIDAD_DIA = "";

        private int PROYECCION = 0;
        private int GESTION = 0;

        private int ID_TIPO_MATERIAL = 0;
        private int ID_ACTIVIDAD_MATERIAL = 0;

        private int ID_ACTIVIDAD_DETALLE = 0;
      
        private int USUARIO_CREACION= 0;
        private int USUARIO_MODIFICA = 0;
        private int ID_MUNICIPIO = 0;

        private int ID_ACTIVIDAD_DIA_ESTADO = 0;

        private long GESTION1 = 0;
      
        #region Atributos 

            public int P_ID_ACTIVIDAD
            {
                get { return ID_ACTIVIDAD; }
                set { ID_ACTIVIDAD = value; }
            }

            public int P_ID_ACTIVIDAD_DIA
            {
                get { return ID_ACTIVIDAD_DIA; }
                set { ID_ACTIVIDAD_DIA = value; }
            }

            public string P_DIA_ACTIVIDAD
            {
                get { return DIA_ACTIVIDAD; }
                set { DIA_ACTIVIDAD = value; }
            }

            public string P_LUGAR_ACTIVIDAD
            {
                get { return LUGAR_ACTIVIDAD; }
                set { LUGAR_ACTIVIDAD = value; }
            }

            public string P_HORA_INICIO
            {
                get { return HORA_INICIO; }
                set { HORA_INICIO = value; }
            }

            public string P_HORA_FIN
            {
                get { return HORA_FIN; }
                set { HORA_FIN = value; }
            }

            public string P_OBSERVACION_ACTIVIDAD_DIA
            {
                get { return OBSERVACION_ACTIVIDAD_DIA; }
                set { OBSERVACION_ACTIVIDAD_DIA = value; }
            }

            public int P_PROYECCION
            {
                get { return PROYECCION; }
                set { PROYECCION = value; }
            }

            public int P_GESTION
            {
                get { return GESTION; }
                set { GESTION = value; }
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

            public int P_ID_TIPO_MATERIAL
            {
                get { return ID_TIPO_MATERIAL; }
                set { ID_TIPO_MATERIAL = value; }
            }

            public int P_ID_ACTIVIDAD_MATERIAL
            {
                get { return ID_ACTIVIDAD_MATERIAL; }
                set { ID_ACTIVIDAD_MATERIAL = value; }
            }

            public int P_ID_ACTIVIDAD_DETALLE
            {
                get { return ID_ACTIVIDAD_DETALLE; }
                set { ID_ACTIVIDAD_DETALLE = value; }
            }

            public int P_ID_MUNICIPIO
            {
                get { return ID_MUNICIPIO; }
                set { ID_MUNICIPIO = value; }
            }

            public int P_ID_ACTIVIDAD_DIA_ESTADO
            {
                get { return ID_ACTIVIDAD_DIA_ESTADO; }
                set { ID_ACTIVIDAD_DIA_ESTADO = value; }
            }

            public long P_GESTION1
            {
                get { return GESTION1; }
                set { GESTION1 = value; }
            }
              
        #endregion

    }

}