/*
 *******************************************************************************************
  PROGRAMA				: Persona.cs
  FECHA DE CREACION	    : 27-04-2015
  FECHA DE MODIFICACION : 20-05-2020
  VERSION               : 1.1
  AUTOR                 : Gustavo Adolfo caicedo Viveros

 *******************************************************************************************

  CLASE			        : Persona.cs
  RESPONSABILIDAD	    : Se encarga de manejar los datos de las personas
  COLABORACION		    : Julian A. Bocanegra M.
********************************************************************************************
*/

namespace com.GACV.lgb.modelo.persona
{
    // Persona
    public class Persona
    {
        private int ID_PERSONA = 0;
        private string PER_CEDULA = "";
        private int TDO_NID = 0;
        private string PER_CNOMBRE1 = "";
        private string PER_CNOMBRE2 = "";
        private string PER_CAPELLIDO1 = "";
        private string PER_CAPELLIDO2 = "";
        private int DAN_NID_RESIDENCIA = 0;
        private int ID_DEPARTAMENTO = 0;
        private int DAN_NID_GIRO = 0;
        private int DAN_NID_HECHO = 0;
        private int ETN_NID = 0;
        private int RGD_NID = 0;
        private bool PER_OESTADO;
        private int SEXO = 0;
        private string FECHA_NACIMIENTO = "";
        private string DIRECCION_CORRESPONDENCIA = "";
        private string BARRIO = "";
        private int USUARIO_CREACION = 0;
        private int USUARIO_MODIFICA = 0;
        private string RADICADO = "";
        private int ID_RADICADO_PERSONA = 0;

        private int ID_ROL = 0;
        private int ID_PROCESO = 0;
        private int ID_PROCESO_PERSONA = 0;
        private int ID_TIPO_PERSONA = 0;
        private int ID_SUJETO_COLECTIVA = 0;
        private int TIPO_DISCAPACIDAD = 0;
        private int ID_ORIENTACION_SEXUAL_PERSONA = 0;
        private int ID_IDENTIDAD_GENERO = 0;
        private int ID_DISCAPACIDAD = 0;
        private int ID_ENFERMEDAD = 0;
        private string TELEFONO = "";
        private string EMAIL = "";

        private int ID_HECHO_VICTIMIZANTE = 0;
        private int ID_ESTADO_CARTA = 0;

        private int ID_USUARIO = 0;
        private int ID_ECIVIL = 0;
        private int ID_PAIS = 0;
        private int ID_CIUDAD = 0;
        private int? IDTIPODOCUMENTO = null;

        private string ESTADO_RUV = "";


        /// Método constructor de la clase       
        public Persona()
        {
        }

        #region Atributos de las personas

        public int P_ID_PERSONA
        {
            get { return ID_PERSONA; }
            set { ID_PERSONA = value; }
        }
        public string P_PER_CEDULA
        {
            get { return PER_CEDULA; }
            set { PER_CEDULA = value; }
        }

        public int P_TDO_NID
        {
            get { return TDO_NID; }
            set { TDO_NID = value; }
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
        public int P_DAN_NID_RESIDENCIA
        {
            get { return DAN_NID_RESIDENCIA; }
            set { DAN_NID_RESIDENCIA = value; }
        }
        public int P_DAN_NID_GIRO
        {
            get { return DAN_NID_GIRO; }
            set { DAN_NID_GIRO = value; }
        }
        public int P_DAN_NID_HECHO
        {
            get { return DAN_NID_HECHO; }
            set { DAN_NID_HECHO = value; }
        }
        public int P_ETN_NID
        {
            get { return ETN_NID; }
            set { ETN_NID = value; }
        }
        public int P_RGD_NID
        {
            get { return RGD_NID; }
            set { RGD_NID = value; }
        }
        public bool P_PER_OESTADO
        {
            get { return PER_OESTADO; }
            set { PER_OESTADO = value; }
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
        public int P_SEXO
        {
            get { return SEXO; }
            set { SEXO = value; }
        }
        public string P_FECHA_NACIMIENTO
        {
            get { return FECHA_NACIMIENTO; }
            set { FECHA_NACIMIENTO = value; }
        }

        public int P_ID_DEPARTAMENTO
        {
            get { return ID_DEPARTAMENTO; }
            set { ID_DEPARTAMENTO = value; }
        }

        public string P_DIRECCION_CORRESPONDENCIA
        {
            get { return DIRECCION_CORRESPONDENCIA; }
            set { DIRECCION_CORRESPONDENCIA = value; }
        }

        public string P_BARRIO
        {
            get { return BARRIO; }
            set { BARRIO = value; }
        }

        public int P_ID_ROL
        {
            get { return ID_ROL; }
            set { ID_ROL = value; }
        }

        public int P_ID_PROCESO
        {
            get { return ID_PROCESO; }
            set { ID_PROCESO = value; }
        }

        public int P_ID_PROCESO_PERSONA
        {
            get { return ID_PROCESO_PERSONA; }
            set { ID_PROCESO_PERSONA = value; }
        }

        public string P_RADICADO
        {
            get { return RADICADO; }
            set { RADICADO = value; }
        }

        public int P_ID_RADICADO_PERSONA
        {
            get { return ID_RADICADO_PERSONA; }
            set { ID_RADICADO_PERSONA = value; }
        }

        public int P_ID_TIPO_PERSONA
        {
            get { return ID_TIPO_PERSONA; }
            set { ID_TIPO_PERSONA = value; }
        }

        public int P_ID_SUJETO_COLECTIVA
        {
            get { return ID_SUJETO_COLECTIVA; }
            set { ID_SUJETO_COLECTIVA = value; }
        }

        public int P_TIPO_DISCAPACIDAD
        {
            get { return TIPO_DISCAPACIDAD; }
            set { TIPO_DISCAPACIDAD = value; }
        }

        public int P_ID_ORIENTACION_SEXUAL_PERSONA
        {
            get { return ID_ORIENTACION_SEXUAL_PERSONA; }
            set { ID_ORIENTACION_SEXUAL_PERSONA = value; }
        }

        public string P_TELEFONO
        {
            get { return TELEFONO; }
            set { TELEFONO = value; }
        }

        public string P_EMAIL
        {
            get { return EMAIL; }
            set { EMAIL = value; }
        }

        public int P_ID_IDENTIDAD_GENERO
        {
            get { return ID_IDENTIDAD_GENERO; }
            set { ID_IDENTIDAD_GENERO = value; }
        }

        public int P_ID_DISCAPACIDAD
        {
            get { return ID_DISCAPACIDAD; }
            set { ID_DISCAPACIDAD = value; }
        }

        public int P_ID_ENFERMEDAD
        {
            get { return ID_ENFERMEDAD; }
            set { ID_ENFERMEDAD = value; }
        }

        public int P_ID_HECHO_VICTIMIZANTE
        {
            get { return ID_HECHO_VICTIMIZANTE; }
            set { ID_HECHO_VICTIMIZANTE = value; }
        }

        public int P_ID_USUARIO
        {
            get { return ID_USUARIO; }
            set { ID_USUARIO = value; }
        }

        public int P_ID_ECIVIL
        {
            get { return ID_ECIVIL; }
            set { ID_ECIVIL = value; }
        }

        public int P_ID_ESTADO_CARTA
        {
            get { return ID_ESTADO_CARTA; }
            set { ID_ESTADO_CARTA = value; }
        }
           
        public int P_ID_PAIS
        {
            get { return ID_PAIS; }
            set { ID_PAIS = value; }
        }
        public int P_ID_CIUDAD
        {
            get { return ID_CIUDAD; }
            set { ID_CIUDAD = value; }
        }

        public int? P_IDTIPODOCUMENTO
        {
            get { return IDTIPODOCUMENTO; }
            set { IDTIPODOCUMENTO = value; }
        }

        public string P_ESTADO_RUV
        {
            get { return ESTADO_RUV; }
            set { ESTADO_RUV = value; }
        }

        #endregion

    }
}