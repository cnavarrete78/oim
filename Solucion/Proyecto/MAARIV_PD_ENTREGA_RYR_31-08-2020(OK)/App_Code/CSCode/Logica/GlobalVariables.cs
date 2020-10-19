using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GlobalVariables
/// </summary>
public class GlobalVariables
{
    public static int[] id_rol_permiso_creacion_persona = { 0, 0, 0, 0, 0 }; //agregar los ID rol (usuarios) que pueden crear personas en asistencia, NO SE DEBE INCLUIR EL ROL ADMIN(1)
    public static int[] id_rol_territorio_colectiva = { 133, 136, 139, 142, 151, 152, 153 };
    public static int[] id_rol_2da_instancia_colectiva = { 132, 138, 146, 144, 152 };


    public static int[] id_roles_permiso
    {
        get { return id_rol_permiso_creacion_persona; }
        set { id_rol_permiso_creacion_persona = value; }
    }

    public static int[] id_usuario_territorioA
    {
        get { return id_rol_territorio_colectiva; }
        set { id_rol_territorio_colectiva = value; }
    }

    public static int[] id_usuario_2da_instanciaA
    {
        get { return id_rol_2da_instancia_colectiva; }
        set { id_rol_2da_instancia_colectiva = value; }
    }
}