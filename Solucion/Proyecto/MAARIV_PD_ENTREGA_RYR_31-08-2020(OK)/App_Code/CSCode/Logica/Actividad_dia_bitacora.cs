using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Actividad_dia_bitacora
/// </summary>
/// 

namespace com.GACV.lgb.modelo.Actividad_dia_bitacora
{
    public class Actividad_dia_bitacora
    {

        private int ID_ACTIVIDAD_DIA_BITACORA = 0;
        private int ID_ACTIVIDAD_DIA = 0;
        private string DESCRIPCION_BITACORA = "";
        private int USUARIO_CREACION = 0;
        private int USUARIO_MODIFICA = 0;

        public Actividad_dia_bitacora()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public int P_ID_ACTIVIDAD_DIA_BITACORA
        {
            get
            {
                return ID_ACTIVIDAD_DIA_BITACORA;
            }
            set
            {
                ID_ACTIVIDAD_DIA_BITACORA = value;
            }
        }

        public int P_ID_ACTIVIDAD_DIA
        {
            get
            {
                return ID_ACTIVIDAD_DIA;
            }
            set
            {
                ID_ACTIVIDAD_DIA = value;
            }
        }

        public string P_DESCRIPCION_BITACORA
        {
            get
            {
                return DESCRIPCION_BITACORA;
            }
            set
            {
                DESCRIPCION_BITACORA = value;
            }
        }

        public int P_USUARIO_CREACION
        {
            get
            {
                return USUARIO_CREACION;
            }
            set
            {
                USUARIO_CREACION = value;
            }
        }

        public int P_USUARIO_MODIFICA
        {
            get
            {
                return USUARIO_MODIFICA;
            }
            set
            {
                USUARIO_MODIFICA = value;
            }
        }
    }
}

    