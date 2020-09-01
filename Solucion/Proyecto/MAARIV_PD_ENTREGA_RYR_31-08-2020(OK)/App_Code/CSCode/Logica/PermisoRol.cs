using System.Collections.Generic;

namespace com.GACV.lgb.modelo
{
    /// <summary>
    /// Summary description for PermisoRol
    /// </summary>
    public class PermisoRol
    {
        private List<Permiso> permisos;
        private string id_rol;

        /// <summary>
        /// Método constructor de la clase
        /// </summary>
        public PermisoRol()
        {
            permisos = new List<Permiso>();
        }

        /// <summary>
        /// Property del atributo permisos
        /// </summary>
        public List<Permiso> Permisos
        {
            get
            {
                return permisos;
            }
            set
            {
                permisos = value;
            }
        }

        /// <summary>
        /// Property del atributo id_rol
        /// </summary>
        public string Id_rol
        {
            get
            {
                return id_rol;
            }
            set
            {
                id_rol = value;
            }
        }

        /// <summary>
        /// Adicionar un nuevo permiso a lista de permisos
        /// </summary>
        /// <param name="perm">permiso a adicionar</param>
        public void adicionarPermiso(Permiso perm)
        {
            permisos.Add(perm);
        }

        /// <summary>
        /// Buscar un permiso dado su identificador
        /// </summary>
        /// <param name="id_permiso">Identificador del permiso buscado</param>
        /// <returns>El permiso con ese identificador o null si no existe</returns>
        public Permiso buscarPermiso(string id_permiso)
        {
            Permiso permiso = null;
            Permiso permiso_final = null;

            for (int i = 0; i < permisos.Count; i++)
            {
                permiso = permisos[i];
                if (permiso.Id_permiso.Equals(id_permiso))
                    permiso_final = permiso;
            }

            return permiso_final;
        }

        /// <summary>
        /// Activar el estado de un permiso
        /// </summary>
        /// <param name="id_permiso">identificador del permiso a activar</param>
        public void cambiarEstadoPermiso(string id_permiso, bool activo)
        {
            for (int i = 0; i < permisos.Count; i++)
            {
                if (permisos[i].Id_permiso.Equals(id_permiso))
                    permisos[i].Estado = activo;
            }
        }

        /// <summary>
        /// Obtener los hijos de un permiso dado el identificador del padre
        /// </summary>
        /// <param name="id_permiso">Identificador del padre</param>
        /// <returns>Lista de Permisos hijos</returns>
        public List<Permiso> obtenerHijos(string id_permiso)
        {
            List<Permiso> hijos = new List<Permiso>();
            Permiso permHijo = null;

            for (int i = 0; i < permisos.Count; i++)
            {
                permHijo = permisos[i];

                if (permHijo.Id_padre.Equals(id_permiso))
                {
                    hijos.Add(permHijo);
                }
            }

            return hijos;
        }

    }
}