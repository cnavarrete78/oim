
namespace com.GACV.lgb.modelo
{

    /// <summary>
    /// Summary description for Permiso
    /// </summary>
    public class Permiso
    {
        private string id_permiso;
        private string url_permiso;
        private string id_padre;
        private string nombre_permiso;
        private string descripcion_permiso;
        private string icono;
        private bool estado;

        /// <summary>
        /// Método constructor de la clase
        /// </summary>
        public Permiso()
        {

        }

        /// <summary>
        /// Property del atributo id_permiso
        /// </summary>
        public string Id_permiso
        {
            get
            {
                return id_permiso;
            }
            set
            {
                id_permiso = value;
            }
        }

        /// <summary>
        /// Property del atributo url_permiso
        /// </summary>
        public string Url_permiso
        {
            get
            {
                return url_permiso;
            }
            set
            {
                url_permiso = value;
            }
        }

        /// <summary>
        /// Property del atributo id_padre
        /// </summary>
        public string Id_padre
        {
            get
            {
                return id_padre;
            }
            set
            {
                id_padre = value;
            }
        }

        /// <summary>
        /// Property del atributo nombre_permiso
        /// </summary>
        public string Nombre_permiso
        {
            get
            {
                return nombre_permiso;
            }
            set
            {
                nombre_permiso = value;
            }
        }

        /// <summary>
        /// Property del atributo descripcion_permiso
        /// </summary>
        public string Descripcion_permiso
        {
            get
            {
                return descripcion_permiso;
            }
            set
            {
                descripcion_permiso = value;
            }
        }

        /// <summary>
        /// Property del atributo icono
        /// </summary>
        public string Icono
        {
            get
            {
                return icono;
            }
            set
            {
                icono = value;
            }
        }

        /// <summary>
        /// Property del atributo estado
        /// </summary>
        public bool Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }
    }
}