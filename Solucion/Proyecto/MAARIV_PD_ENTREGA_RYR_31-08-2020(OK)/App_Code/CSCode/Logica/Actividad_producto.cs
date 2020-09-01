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


namespace com.GACV.lgb.modelo.actividad_producto
{
    // logica para actividad dia
    public class Actividad_producto
    {
        private int ID_ACTIVIDAD_PRODUCTO = 0;
        private int ID_ACTIVIDAD_NOMBRE = 0;
        private int ID_SUJETO_COLECTIVA = 0;
        private int USUARIO_MODIFICA = 0;
        private int USUARIO_CREACION = 0;
        private string DESCRIPCION = "";
        private string PRODUCTO = "";
        private int ID_TIPO_MEDIDA = 0;

        
      
        #region Atributos 

        public int P_ID_ACTIVIDAD_PRODUCTO
        {
            get { return ID_ACTIVIDAD_PRODUCTO; }
            set { ID_ACTIVIDAD_PRODUCTO = value; }
        }
        public int P_ID_ACTIVIDAD_NOMBRE
        {
            get { return ID_ACTIVIDAD_NOMBRE; }
            set { ID_ACTIVIDAD_NOMBRE = value; }
        }
        public int P_ID_SUJETO_COLECTIVA
        {
            get { return ID_SUJETO_COLECTIVA; }
            set { ID_SUJETO_COLECTIVA = value; }
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

        public string P_DESCRIPCION
        {
            get { return DESCRIPCION; }
            set { DESCRIPCION = value; }
        }

        public string P_PRODUCTO
        {
            get { return PRODUCTO; }
            set { PRODUCTO = value; }
        }

        public int P_ID_TIPO_MEDIDA
        {
            get { return ID_TIPO_MEDIDA; }
            set { ID_TIPO_MEDIDA = value; }
        }

        #endregion

    }

}