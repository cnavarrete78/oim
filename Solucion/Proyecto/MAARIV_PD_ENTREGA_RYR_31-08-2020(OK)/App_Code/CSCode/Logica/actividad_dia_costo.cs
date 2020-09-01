using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de actividad_dia_costo
/// </summary>
/// 

namespace com.GACV.lgb.modelo.actividad_dia_costo
{
    public class actividad_dia_costo
    {
        private int ID_ACTIVIDAD_DIA_COSTO = 0;
        private int ID_ACTIVIDAD_DIA = 0;
        private int ID_TIPO_COSTO = 0;
        private double COSTO_PROYECTADO = 0;
        private double COSTO_EJECUTADO = 0;
        private int USUARIO_CREACION = 0;
        private int USUARIO_MODIFICA = 0;

        public actividad_dia_costo()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public int P_ID_ACTIVIDAD_DIA_COSTO
        {
            get
            {
                return ID_ACTIVIDAD_DIA_COSTO;
            }
            set
            {
                ID_ACTIVIDAD_DIA_COSTO = value;
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

        public int P_ID_TIPO_COSTO
        {
            get
            {
                return ID_TIPO_COSTO;
            }
            set
            {
                ID_TIPO_COSTO = value;
            }
        }

        public double P_COSTO_PROYECTADO
        {
            get
            {
                return COSTO_PROYECTADO;
            }
            set
            {
                COSTO_PROYECTADO = value;
            }
        }

        public double P_COSTO_EJECUTADO
        {
            get
            {
                return COSTO_EJECUTADO;
            }
            set
            {
                COSTO_EJECUTADO = value;
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
    