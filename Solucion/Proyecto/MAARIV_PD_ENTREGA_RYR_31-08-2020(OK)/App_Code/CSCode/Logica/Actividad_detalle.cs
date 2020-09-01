/*
 *******************************************************************************************
  PROGRAMA				: Actividad_detalle.cs
  FECHA DE CREACION	    : 13-04-2015
  FECHA DE MODIFICACION : 
  VERSION               : 1.0
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
 *******************************************************************************************

  CLASE			        : Actividad_detalle.cs
  RESPONSABILIDAD	    : 
  COLABORACION		    : 
 
********************************************************************************************
*/

namespace com.GACV.lgb.modelo.actividad_detalle
{
    // logica para actividad detalle
    public class Actividad_detalle
    {
        private int ID_ACTIVIDAD_DETALLE = 0;
        private int ID_ACTIVIDAD = 0;
        private string DESCRIPCION_ACTIVIDAD_DETALLE = "";
        private int ESTADO_ACTIVIDAD = 0;
        private int ID_TIPO_ACTIVIDAD = 0;

        private int ID_ACTIVIDAD_NOMBRE = 0;
        private string TIPO_ACTIVIDAD = "";
       
        private int USUARIO_CREACION= 0;
        private int USUARIO_MODIFICA = 0;
              
      
        #region Atributos 

            public int P_ID_ACTIVIDAD_DETALLE
            {
                get { return ID_ACTIVIDAD_DETALLE; }
                set { ID_ACTIVIDAD_DETALLE = value; }
            }

            public int P_ID_ACTIVIDAD
            {
                get { return ID_ACTIVIDAD; }
                set { ID_ACTIVIDAD = value; }
            }

            public string P_DESCRIPCION_ACTIVIDAD_DETALLE
            {
                get { return DESCRIPCION_ACTIVIDAD_DETALLE; }
                set { DESCRIPCION_ACTIVIDAD_DETALLE = value; }
            }

            public int P_ESTADO_ACTIVIDAD
            {
                get { return ESTADO_ACTIVIDAD; }
                set { ESTADO_ACTIVIDAD = value; }
            }

            public int P_ID_TIPO_ACTIVIDAD
            {
                get { return ID_TIPO_ACTIVIDAD; }
                set { ID_TIPO_ACTIVIDAD = value; }
            }

            public int P_ID_ACTIVIDAD_NOMBRE
            {
                get { return ID_ACTIVIDAD_NOMBRE; }
                set { ID_ACTIVIDAD_NOMBRE = value; }
            }

            public string P_TIPO_ACTIVIDAD
            {
                get { return TIPO_ACTIVIDAD; }
                set { TIPO_ACTIVIDAD = value; }
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
              
        #endregion

    }

}