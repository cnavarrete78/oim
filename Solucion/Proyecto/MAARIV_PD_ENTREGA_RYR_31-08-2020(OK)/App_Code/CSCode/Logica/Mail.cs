/*
 *******************************************************************************************
  PROGRAMA				: Enviar_correo.cs
  FECHA DE CREACION	    : Mayo 29 de 2010
  FECHA DE MODIFICACION : Mayo 29 de 2010
  VERSION               : 1.0
  AUTOR                 : Gustavo Adolfo Caicedo Viveros

 *******************************************************************************************

  CLASE			        : Entidad.cs
  RESPONSABILIDAD	    : Se encarga manejar los atributos de la entidad
  COLABORACION		    : 
********************************************************************************************
*/

namespace com.GACV.lgb.modelo.email
{
    // Email   
    public class Mail
    {
        private string FROM;
        private string TO;
        private string USUARIO;
        private string MENSAJE;
        private string ASUNTO;
        private string TO_PASSWORD;
        private string HOST;
        private int PUERTO;

        /// Método constructor de la clase       
        public Mail()
        {
        }

        #region Atributos de enviar correo

        // Property del atributo
        public string F_FROM
        {
            get
            {
                return FROM;
            }
            set
            {
                FROM = value;
            }
        }

        // Property del atributo
        public string F_TO
        {
            get
            {
                return TO;
            }
            set
            {
                TO = value;
            }
        }

        // Property del atributo
        public string F_USUARIO
        {
            get
            {
                return USUARIO;
            }
            set
            {
                USUARIO = value;
            }
        }

        // Property del atributo
        public string F_MENSAJE
        {
            get
            {
                return MENSAJE;
            }
            set
            {
                MENSAJE = value;
            }
        }

        // Property del atributo
        public string F_ASUNTO
        {
            get
            {
                return ASUNTO;
            }
            set
            {
                ASUNTO = value;
            }
        }

        // Property del atributo
        public string F_TO_PASSWORD
        {
            get
            {
                return TO_PASSWORD;
            }
            set
            {
                TO_PASSWORD = value;
            }
        }

        // Property del atributo
        public string F_HOST 
        {
            get
            {
                return HOST;
            }
            set
            {
                HOST = value;
            }
        }

        // Property del atributo
        public int F_PUERTO
        {
            get
            {
                return PUERTO;
            }
            set
            {
                PUERTO = value;
            }
        }

        #endregion

    }
}