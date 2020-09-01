/*
 *******************************************************************************************
  PROGRAMA				: Sujeto_colectiva.cs
  FECHA DE CREACION	    : 02-03-2013
  FECHA DE MODIFICACION : 02-03-2013
  VERSION               : 1.0
  AUTOR                 : Julian Bocanegra

 *******************************************************************************************

  CLASE			        : Sujeto_colectiva.cs
  RESPONSABILIDAD	    : Se encarga de manejar los datos de los sujetos colectivos 
  COLABORACION		    : Ninguna
********************************************************************************************
*/

namespace com.GACV.lgb.modelo.sujeto_colectiva
{
    // sujeto_colectiva
    public class Sujeto_colectiva
    {

        private int ID_SUJETO_COLECTIVA = 0;
        private int ID_ALCANCE = 0;
        private int ID_TIPO_SUJETO_COLECTIVA = 0;
        private int ID_TIPO_SUJETO_COLECTIVA_DET = 0;
        private int ID_DEPARTAMENTO = 0;
        private int ID_MUNICIPIO = 0;
        private string NIT = "";
        private string NOMBRE_SUJETO_COLECTIVA = "";
        private int ID_ESTADO_SUJETO_COLECTIVA = 0;
        private int USUARIO_CREACION = 0;
        private int USUARIO_MODIFICA = 0;

        //--------07-02-2020----  ROJO-----
                
        private string FUD = "";
        private string TIPO_ACCESO = "";
        private string ESTADO_RUV = "";
        //----------------FIN ---------------

        private int ID_DIRECTORIO = 0;
        private int ID_TIPO_CONTACTO_COLECTIVA = 0;
        private string ENTIDAD = "";
        private string NOMBRE = "";
        private string CARGO = "";
        private string EMAIL = "";
        private string TELEFONO = "";
        private int ESTADO_DIRECTORIO = 0;

        private int ID_USUARIO = 0;

        private int ID_ASIGNACION_SUJETOS = 0;
        private int ID_ROL = 0;
        private int ID_ESTADO_ASIGNACION_SUJETO = 0;
        private int ID_ZONA = 0;
        private int ID_TERRITORIAL = 0;

        private string IDENTIFICACION = "";
        private string PER_CNOMBRE1 = "";
        private string PER_CNOMBRE2 = "";
        private string PER_CAPELLIDO1 = "";
        private string PER_CAPELLIDO2 = "";
        private string FASE = "";
        private string OBSERVACION_ESTADO_SUJETO = "";


        /// Método constructor de la clase       
        public Sujeto_colectiva()
        {
        }

        #region Atributos de las personas

        public int P_ID_SUJETO_COLECTIVA
        {
            get { return ID_SUJETO_COLECTIVA; }
            set { ID_SUJETO_COLECTIVA = value; }
        }

        public int P_ID_ALCANCE
        {
            get { return ID_ALCANCE; }
            set { ID_ALCANCE = value; }
        }

        public int P_ID_TIPO_SUJETO_COLECTIVA
        {
            get { return ID_TIPO_SUJETO_COLECTIVA; }
            set { ID_TIPO_SUJETO_COLECTIVA = value; }
        }

        public int P_ID_TIPO_SUJETO_COLECTIVA_DET
        {
            get { return ID_TIPO_SUJETO_COLECTIVA_DET; }
            set { ID_TIPO_SUJETO_COLECTIVA_DET = value; }
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

        public string P_NIT
        {
            get { return NIT; }
            set { NIT = value; }
        }

        public string P_NOMBRE_SUJETO_COLECTIVA
        {
            get { return NOMBRE_SUJETO_COLECTIVA; }
            set { NOMBRE_SUJETO_COLECTIVA = value; }
        }

        public int P_ID_ESTADO_SUJETO_COLECTIVA
        {
            get { return ID_ESTADO_SUJETO_COLECTIVA; }
            set { ID_ESTADO_SUJETO_COLECTIVA = value; }
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

        public int P_ID_DIRECTORIO
        {
            get { return ID_DIRECTORIO; }
            set { ID_DIRECTORIO = value; }
        }

        public int P_ID_TIPO_CONTACTO_COLECTIVA
        {
            get { return ID_TIPO_CONTACTO_COLECTIVA; }
            set { ID_TIPO_CONTACTO_COLECTIVA = value; }
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

        public string P_CARGO
        {
            get { return CARGO; }
            set { CARGO = value; }
        }

        public string P_EMAIL
        {
            get { return EMAIL; }
            set { EMAIL = value; }
        }

        public string P_TELEFONO
        {
            get { return TELEFONO; }
            set { TELEFONO = value; }
        }

        public int P_ESTADO_DIRECTORIO
        {
            get { return ESTADO_DIRECTORIO; }
            set { ESTADO_DIRECTORIO = value; }
        }

        public int P_ID_USUARIO
        {
            get { return ID_USUARIO; }
            set { ID_USUARIO = value; }
        }

        public int P_ID_ROL
        {
            get { return ID_ROL; }
            set { ID_ROL = value; }
        }

        public int P_ID_ESTADO_ASIGNACION_SUJETO
        {
            get { return ID_ESTADO_ASIGNACION_SUJETO; }
            set { ID_ESTADO_ASIGNACION_SUJETO = value; }
        }

        public int P_ID_ASIGNACION_SUJETOS
        {
            get { return ID_ASIGNACION_SUJETOS; }
            set { ID_ASIGNACION_SUJETOS = value; }
        }

        public int P_ID_ZONA
        {
            get { return ID_ZONA; }
            set { ID_ZONA = value; }
        }

        public int P_ID_TERRITORIAL
        {
            get { return ID_TERRITORIAL; }
            set { ID_TERRITORIAL = value; }
        }

        public string P_IDENTIFICACION
        {
            get { return IDENTIFICACION; }
            set { IDENTIFICACION = value; }
        }

        public string P_PER_CNOMBRE1
        {
            get { return PER_CNOMBRE1; }
            set { PER_CNOMBRE1 = value; }
        }

        public string P_PER_CNOMBRE2
        {
            get { return PER_CNOMBRE2; }
            set { PER_CNOMBRE2 = value; }
        }

        public string P_PER_CAPELLIDO1
        {
            get { return PER_CAPELLIDO1; }
            set { PER_CAPELLIDO1 = value; }
        }

        public string P_PER_CAPELLIDO2
        {
            get { return PER_CAPELLIDO2; }
            set { PER_CAPELLIDO2 = value; }
        }


        public string P_FASE
        {
            get { return FASE; }
            set { FASE = value; }
        }

        public string P_FUD
        {
            get { return FUD; }
            set { FUD = value; }
        }
        public string P_TIPO_ACCESO 
        {
            get { return TIPO_ACCESO; }
            set { TIPO_ACCESO = value; }
        }
        public string P_ESTADO_RUV
        {
            get { return ESTADO_RUV; }
            set { ESTADO_RUV = value; }
        }

        public string P_OBSERVACION_ESTADO_SUJETO
        {
            get { return OBSERVACION_ESTADO_SUJETO; }
            set { OBSERVACION_ESTADO_SUJETO = value; }
        }
        

        #endregion

    }
}