/*
 *******************************************************************************************
  PROGRAMA				: Usuario.cs
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
  FECHA DE CREACION	    : 13-04-2015
  USUARIO MODIFICA      : GUSTAVO ADOLFO CAICEDO VIVEROS
  FECHA DE MODIFICACION : 06-04-2016
  VERSION               : 1.1  
 ******************************************************************************************* 
  CLASE			        : Usuario.cs
  RESPONSABILIDAD	    : 
  COLABORACION		    :             
********************************************************************************************
*/

namespace com.GACV.lgb.modelo.usuario
{

    /// <summary>
    /// Summary description for user
    /// </summary>
    public class Usuario
    {
        private int ID_USUARIO = 0;
        private string nombre = "";
        private string PRIMER_NOMBRE = "";
        private string SEGUNDO_NOMBRE = "";
        private string PRIMER_APELLIDO = "";
        private string SEGUNDO_APELLIDO = "";
        private string apellidos = "";
        private string identificacion ;
        private int id_tipo_identificacion = 0;        
        private string email = "";
        private int TIPO_USUARIO;
        private string login = "";
        private string password = "";       
        private int entidad = 0;       
        private int id_persona = 0;
        private int id_estado_usuario = 0;
        private string usuario_creacion = "";
        private string usuario_modifica = "";
        private string TELEFONO_FIJO = "";
        private string TELEFONO_MOVIL = "";
        private int ROL = 0;
        private int ID_TIPO_NOVEDAD = 0;
        private string FECHA_INGRESO;
        private string FECHA_RETIRO;
        private string OBSERVACION = "";
        private int ID_USUARIOS_TIPO_USUARIO = 0;
        private int ID_ANO = 0;
        private int ID_DEPARTAMENTO = 0;
        private int ID_MUNICIPIO = 0;
        private int ID_SUPERVISOR = 0;
        private int ID_USUARIO_SUPERVISOR = 0;
        private int ID_DEPENDENCIA = 0;
        private int ID_TERRITORIAL = 0;
        private int ID_JEFE_AREA = 0;
        private string ID_AUDITORIA = "";
        private int ID_TIPO_VINCULACION = 0;
        private int ID_JEFE_DEPENDENCIA = 0;

        /// <summary>
        /// Método constructor de un objeto Usuario
        /// </summary>
        public Usuario()
        {
            
        }

        /// <summary>
        /// Property del atributo entidad
        /// </summary>
        public int Entidad
        {
            get
            {
                return entidad;
            }
            set
            {
                entidad = value;
            }
        }
   
        /// <summary>
        /// Property del atributo id_participante
        /// </summary>
        public int F_ID_USUARIO
        {
            get
            {
                return ID_USUARIO;
            }
            set
            {
                ID_USUARIO = value;
            }
        }

        /// <summary>
        /// Property del atributo primer_nombre
        /// </summary>
        public string F_Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        /// <summary>
        /// Property del atributo primer_nombre
        /// </summary>
        public string P_PRIMER_NOMBRE
        {
            get
            {
                return PRIMER_NOMBRE;
            }
            set
            {
                PRIMER_NOMBRE = value;
            }
        }

        /// <summary>
        /// Property del atributo segundo_nombre
        /// </summary>
        public string P_SEGUNDO_NOMBRE
        {
            get
            {
                return SEGUNDO_NOMBRE;
            }
            set
            {
                SEGUNDO_NOMBRE = value;
            }
        }

        /// <summary>
        /// Property del atributo primer_apellido
        /// </summary>
        public string P_PRIMER_APELLIDO
        {
            get
            {
                return PRIMER_APELLIDO;
            }
            set
            {
                PRIMER_APELLIDO = value;
            }
        }

        /// <summary>
        /// Property del atributo segundo_apellido
        /// </summary>
        public string P_SEGUNDO_APELLIDO
        {
            get
            {
                return SEGUNDO_APELLIDO;
            }
            set
            {
                SEGUNDO_APELLIDO = value;
            }
        }

        /// <summary>
        /// Property del atributo apellidos
        /// </summary>
        public string Apellidos
        {
            get
            {
                return apellidos;
            }
            set
            {
                apellidos = value;
            }
        }

        /// <summary>
        /// Property del atributo identificación
        /// </summary>
        public string Identificacion
        {
            get
            {
                return identificacion;
            }
            set
            {
                identificacion = value;
            }
        }

        /// <summary>
        /// Property del atributo tipo_identificacion
        /// </summary>
        public int P_tipo_identificación
        {
            get
            {
                return id_tipo_identificacion;
            }
            set
            {
                id_tipo_identificacion = value;
            }
        }
                
        /// <summary>
        /// Property del atributo email
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        /// <summary>
        /// Property del atributo tipo_participante
        /// </summary>
        public int F_TIPO_USUARIO
        {
            get
            {
                return TIPO_USUARIO;
            }
            set
            {
                TIPO_USUARIO = value;
            }
        }

        /// <summary>
        /// Property del atributo login
        /// </summary>
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        /// <summary>
        /// Property del atributo password
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string P_usuario_creacion
        {
            get
            {
                return usuario_creacion;
            }
            set
            {
                usuario_creacion = value;
            }
        }

        public string P_usuario_modifica
        {
            get
            {
                return usuario_modifica;
            }
            set
            {
                usuario_modifica = value;
            }
        }     

        public int P_id_estado_usuario
        {
            get
            {
                return id_estado_usuario;
            }
            set
            {
                id_estado_usuario = value;
            }
        }

        public int F_id_persona
        {
            get
            {
                return id_persona;
            }
            set
            {
                id_persona = value;
            }
        }
        
        public string P_telefono_fijo
        {
            get
            {
                return TELEFONO_FIJO;
            }
            set
            {
                TELEFONO_FIJO = value;
            }
        }

        public string P_telefono_movil
        {
            get
            {
                return TELEFONO_MOVIL;
            }
            set
            {
                TELEFONO_MOVIL = value;
            }
        }

        /// <summary>
        /// Property del atributo rol
        /// </summary>
        public int P_ROL
        {
            get
            {
                return ROL;
            }
            set
            {
                ROL = value;
            }
        }

        /// <summary>
        /// Property del atributo ID_TIPO_NOVEDAD
        /// </summary>
        public int F_ID_TIPO_NOVEDAD
        {
            get
            {
                return ID_TIPO_NOVEDAD;
            }
            set
            {
                ID_TIPO_NOVEDAD = value;
            }
        }

        /// <summary>
        /// Property del atributo FECHA_INGRESO
        /// </summary>
        public string F_FECHA_INGRESO
        {
            get
            {
                return FECHA_INGRESO;
            }
            set
            {
                FECHA_INGRESO = value;
            }
        }

        /// <summary>
        /// Property del atributo FECHA_RETIRO
        /// </summary>
        public string F_FECHA_RETIRO
        {
            get
            {
                return FECHA_RETIRO;
            }
            set
            {
                FECHA_RETIRO = value;
            }
        }

        public string P_OBSERVACION
        {
            get
            {
                return OBSERVACION;
            }
            set
            {
                OBSERVACION = value;
            }
        }

        public int P_ID_USUARIOS_TIPO_USUARIO
        {
            get
            {
                return ID_USUARIOS_TIPO_USUARIO;
            }
            set
            {
                ID_USUARIOS_TIPO_USUARIO = value;
            }
        }

        public int P_ID_ANO
        {
            get
            {
                return ID_ANO;
            }
            set
            {
                ID_ANO = value;
            }
        }

        public int P_ID_DEPARTAMENTO
        {
            get
            {
                return ID_DEPARTAMENTO;
            }
            set
            {
                ID_DEPARTAMENTO = value;
            }
        }

        public int P_ID_MUNICIPIO
        {
            get
            {
                return ID_MUNICIPIO;
            }
            set
            {
                ID_MUNICIPIO = value;
            }
        }

        public int P_ID_SUPERVISOR
        {
            get
            {
                return ID_SUPERVISOR;
            }
            set
            {
                ID_SUPERVISOR = value;
            }
        }

        public int P_ID_USUARIO_SUPERVISOR
        {
            get
            {
                return ID_USUARIO_SUPERVISOR;
            }
            set
            {
                ID_USUARIO_SUPERVISOR = value;
            }
        }

        public int P_ID_DEPENDENCIA
        {
            get
            {
                return ID_DEPENDENCIA;
            }
            set
            {
                ID_DEPENDENCIA = value;
            }
        }

        public int P_ID_TERRITORIAL
        {
            get
            {
                return ID_TERRITORIAL;
            }
            set
            {
                ID_TERRITORIAL = value;
            }
        }

        public int P_ID_TIPO_VINCULACION
        {
            get
            {
                return ID_TIPO_VINCULACION;
            }
            set
            {
                ID_TIPO_VINCULACION = value;
            }
        }

        public int P_ID_JEFE_AREA
        {
            get
            {
                return ID_JEFE_AREA;
            }
            set
            {
                ID_JEFE_AREA = value;
            }
        }

        public string P_ID_AUDITORIA
        {
            get
            {
                return ID_AUDITORIA;
            }
            set
            {
                ID_AUDITORIA = value;
            }
        }

        public int P_ID_JEFE_DEPENDENCIA
        {
            get
            {
                return ID_JEFE_DEPENDENCIA;
            }
            set
            {
                ID_JEFE_DEPENDENCIA = value;
            }
        }


    }
}