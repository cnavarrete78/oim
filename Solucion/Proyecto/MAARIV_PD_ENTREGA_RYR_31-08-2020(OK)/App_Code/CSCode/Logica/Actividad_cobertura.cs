/*
 *******************************************************************************************
  PROGRAMA				: Actividad_cobertura.cs
  FECHA DE CREACION	    : 20-04-2015
  FECHA DE MODIFICACION : 
  VERSION               : 1.0
  AUTOR                 : Gustavo Adolfo Caicedo Viveros
 *******************************************************************************************

  CLASE			        : Actividad_cobertura.cs
  RESPONSABILIDAD	    : Nos muestra la cobertura de la actividad
  COLABORACION		    : Ninguna
 
********************************************************************************************
*/


namespace com.GACV.lgb.modelo.actividad_cobertura
{
    // actividad cobertura
    public class Actividad_cobertura
    {
        private int        ID_ACTIVIDAD_COBERTURA = 0;
        private int        ID_MUNICIPIO= 0;
        private int        ID_DEPARTAMENTO = 0;
        private int        ESTADO_ACTIVIDAD_COBERTURA = 0;        
        private int        USUARIO_CREACION = 0;
        private int        USUARIO_MODIFICA = 0;
        private int        ID_ACTIVIDAD = 0;
     
        /// Método constructor de la clase actividad cobertura
        public Actividad_cobertura()
        {
        }     

        #region Atributos de oferta_cobertua
        
            public int P_ID_ACTIVIDAD_COBERTURA
            {
                get { return ID_ACTIVIDAD_COBERTURA; }
                set { ID_ACTIVIDAD_COBERTURA = value; }
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

            public int P_ESTADO_ACTIVIDAD_COBERTURA
            {
                get { return ESTADO_ACTIVIDAD_COBERTURA; }
                set { ESTADO_ACTIVIDAD_COBERTURA = value; }
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

            public int P_ID_ACTIVIDAD
            {
                get { return ID_ACTIVIDAD; }
                set { ID_ACTIVIDAD = value; }
            }

        #endregion

    }

}