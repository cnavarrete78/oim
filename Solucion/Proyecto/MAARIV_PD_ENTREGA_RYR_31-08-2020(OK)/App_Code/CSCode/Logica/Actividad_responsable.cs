/*
 *******************************************************************************************
  PROGRAMA				: Actividad_responsable.cs
  FECHA DE CREACION	    : 13-04-2015
  FECHA DE MODIFICACION : 
  VERSION               : 1.0
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
 *******************************************************************************************

  CLASE			        : Actividad_responsable.cs
  RESPONSABILIDAD	    : 
  COLABORACION		    : 
 
********************************************************************************************
*/

namespace com.GACV.lgb.modelo.actividad_responsable
{
    // logica para los responsables de la actividad
    public class Actividad_responsable
    {
        private int ID_ACTIVIDAD_RESPONSABLE = 0;
        private int ID_ACTIVIDAD = 0;
        private int ID_USUARIO = 0;      
        private int ID_ACTIVIDAD_ROL = 0;

        private int USUARIO_CREACION= 0;
        private int USUARIO_MODIFICA = 0;

      
        #region Atributos 

            public int P_ID_ACTIVIDAD_RESPONSABLE
            {
                get { return ID_ACTIVIDAD_RESPONSABLE; }
                set { ID_ACTIVIDAD_RESPONSABLE = value; }
            }

            public int P_ID_ACTIVIDAD
            {
                get { return ID_ACTIVIDAD; }
                set { ID_ACTIVIDAD = value; }
            }

            public int P_ID_USUARIO
            {
                get { return ID_USUARIO; }
                set { ID_USUARIO = value; }
            }
           
            public int P_ID_ACTIVIDAD_ROL
            {
                get { return ID_ACTIVIDAD_ROL; }
                set { ID_ACTIVIDAD_ROL = value; }
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