/*
 *******************************************************************************************
  PROGRAMA				: DAOActividad_detalle.cs
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
  FECHA DE CREACION	    : 13-04-2015
  USUARIO MODIFICA      : EMERSON PULIDO
  FECHA DE MODIFICACION : 14/10/2015
  VERSION               : 1.1
 *******************************************************************************************
  CLASE			        : DAOActividad_detalle.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : 
 ********************************************************************************************
*/

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.actividad_detalle;
using com.GACV.lgb.modelo.Actividad_dia_bitacora;
using com.GACV.lgb.modelo.actividad_dia_costo;
using com.GACV.lgb.modelo.persona;
using com.GACV.lgb.modelo.actividad;
using System;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOActividad_detalle
    {
        private string cliente;
       
        /// Método constructor de la clase       
        public DAOActividad_detalle()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        public int Administrar_actividad_detalle(Actividad_detalle actividad_detalle, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_DETALLE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DETALLE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Value = actividad_detalle.P_ID_ACTIVIDAD_DETALLE;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_detalle.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ESTADO_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ESTADO_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ESTADO_ACTIVIDAD"].Value = actividad_detalle.P_ESTADO_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_TIPO_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Value = actividad_detalle.P_ID_TIPO_ACTIVIDAD;

                Command.Parameters.Add("@P_DESCRIPCION_ACTIVIDAD_DETALLE", DbType.String);
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD_DETALLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_ACTIVIDAD_DETALLE"].Value = actividad_detalle.P_DESCRIPCION_ACTIVIDAD_DETALLE;
           
                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_detalle.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_detalle.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                //valor = Command.ExecuteNonQuery();

                if (opcion == 4)
                {
                    valor =   Convert.ToInt32(Command.ExecuteScalar());
                }
                else
                {
                    valor = Command.ExecuteNonQuery();
                }


                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }
        
        // permite consultar la actividad detalle
        public DataSet Consulta_actividad_detalle(Actividad_detalle actividad_detalle, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDAD_DETALLE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DETALLE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Value = actividad_detalle.P_ID_ACTIVIDAD_DETALLE;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad_detalle.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_TIPO_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Value = actividad_detalle.P_ID_TIPO_ACTIVIDAD;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // permite administrar los costos de una actividad dia
        public int Administrar_actividad_dia_costo(actividad_dia_costo actividad_dia_costo, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_COSTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_COSTO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_COSTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_COSTO"].Value = actividad_dia_costo.P_ID_ACTIVIDAD_DIA_COSTO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia_costo.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_TIPO_COSTO", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_COSTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_COSTO"].Value = actividad_dia_costo.P_ID_TIPO_COSTO;

                Command.Parameters.Add("@P_COSTO_PROYECTADO", DbType.Double);
                Command.Parameters["@P_COSTO_PROYECTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_COSTO_PROYECTADO"].Value = actividad_dia_costo.P_COSTO_PROYECTADO;

                Command.Parameters.Add("@P_COSTO_EJECUTADO", DbType.Double);
                Command.Parameters["@P_COSTO_EJECUTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_COSTO_EJECUTADO"].Value = actividad_dia_costo.P_COSTO_EJECUTADO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia_costo.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_dia_costo.P_USUARIO_MODIFICA;


                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }

        // permite consultar los costos de una actividad dia
        public DataSet Consultar_actividad_dia_costo(actividad_dia_costo actividad_dia_costo, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_COSTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_COSTO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_COSTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_COSTO"].Value = actividad_dia_costo.P_ID_ACTIVIDAD_DIA_COSTO;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia_costo.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_ID_TIPO_COSTO", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_COSTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_COSTO"].Value = actividad_dia_costo.P_ID_TIPO_COSTO;

                Command.Parameters.Add("@P_COSTO_PROYECTADO", DbType.Double);
                Command.Parameters["@P_COSTO_PROYECTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_COSTO_PROYECTADO"].Value = actividad_dia_costo.P_COSTO_PROYECTADO;

                Command.Parameters.Add("@P_COSTO_EJECUTADO", DbType.Double);
                Command.Parameters["@P_COSTO_EJECUTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_COSTO_EJECUTADO"].Value = actividad_dia_costo.P_COSTO_EJECUTADO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia_costo.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_dia_costo.P_USUARIO_MODIFICA;


                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // permite administrar las bitacoras de una actividad dia
        public int Administrar_actividad_dia_bitacora(Actividad_dia_bitacora actividad_dia_bitacora, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_BITACORA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_BITACORA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_BITACORA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_BITACORA"].Value = actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA_BITACORA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_DESCRIPCION_BITACORA", DbType.Int32);
                Command.Parameters["@P_DESCRIPCION_BITACORA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_BITACORA"].Value = actividad_dia_bitacora.P_DESCRIPCION_BITACORA;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia_bitacora.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_dia_bitacora.P_USUARIO_MODIFICA;


                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }

        // permite consultar las bitacoras de una actividad dia
        public DataSet Consultar_actividad_dia_bitacora(Actividad_dia_bitacora actividad_dia_bitacora, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_ACTIVIDAD_BITACORA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA_BITACORA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_BITACORA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA_BITACORA"].Value = actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA_BITACORA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DIA", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DIA"].Value = actividad_dia_bitacora.P_ID_ACTIVIDAD_DIA;

                Command.Parameters.Add("@P_DESCRIPCION_BITACORA", DbType.Int32);
                Command.Parameters["@P_DESCRIPCION_BITACORA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_DESCRIPCION_BITACORA"].Value = actividad_dia_bitacora.P_DESCRIPCION_BITACORA;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_dia_bitacora.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_dia_bitacora.P_USUARIO_MODIFICA;


                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet Consulta_actividad_detalle2(Actividad actividad, Persona persona, Actividad_detalle actividad_detalle, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ACTIVIDAD_DETALLE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_DETALLE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_DETALLE"].Value = actividad_detalle.P_ID_ACTIVIDAD_DETALLE;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                Command.Parameters.Add("@P_ID_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD"].Value = actividad.P_ID_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_FERIA", DbType.Int32);
                Command.Parameters["@P_ID_FERIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_FERIA"].Value = actividad.P_ID_FERIA;

                Command.Parameters.Add("@P_ID_NOMBRE_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_NOMBRE_ACTIVIDAD"].Value = actividad.P_ID_NOMBRE_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = actividad.P_ID_DEPENDENCIA;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_ESTADO", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_ESTADO"].Value = actividad.P_ID_ACTIVIDAD_ESTADO;

                Command.Parameters.Add("@P_CORREGIMIENTO", DbType.String);
                Command.Parameters["@P_CORREGIMIENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_CORREGIMIENTO"].Value = actividad.P_CORREGIMIENTO;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = actividad.P_ID_TERRITORIAL;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = actividad.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = actividad.P_ID_MUNICIPIO;

                Command.Parameters.Add("@P_IDENTIFICACION", DbType.String);
                Command.Parameters["@P_IDENTIFICACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_IDENTIFICACION"].Value = persona.P_PER_CEDULA;

                Command.Parameters.Add("@P_PRIMER_NOMBRE", DbType.String);
                Command.Parameters["@P_PRIMER_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_NOMBRE"].Value = persona.P_PER_CNOMBRE1;

                Command.Parameters.Add("@P_SEGUNDO_NOMBRE", DbType.String);
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_NOMBRE"].Value = persona.P_PER_CNOMBRE2;

                Command.Parameters.Add("@P_PRIMER_APELLIDO", DbType.String);
                Command.Parameters["@P_PRIMER_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_PRIMER_APELLIDO"].Value = persona.P_PER_CAPELLIDO1;

                Command.Parameters.Add("@P_SEGUNDO_APELLIDO", DbType.String);
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SEGUNDO_APELLIDO"].Value = persona.P_PER_CAPELLIDO2;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // permite administrar la tipo_actividad
        public int Administrar_tipo_actividad(Actividad_detalle actividad_detalle, int opcion)
        {
            int valor = 0;
            DataSet ds = new DataSet();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_TIPO_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_TIPO_ACTIVIDAD", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_ACTIVIDAD"].Value = actividad_detalle.P_ID_TIPO_ACTIVIDAD;

                Command.Parameters.Add("@P_TIPO_ACTIVIDAD", DbType.String);
                Command.Parameters["@P_TIPO_ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_TIPO_ACTIVIDAD"].Value = actividad_detalle.P_TIPO_ACTIVIDAD;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_NOMBRE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_NOMBRE"].Value = actividad_detalle.P_ID_ACTIVIDAD_NOMBRE;

                Command.Parameters.Add("@P_USUARIO_CREACION", DbType.Int32);
                Command.Parameters["@P_USUARIO_CREACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_CREACION"].Value = actividad_detalle.P_USUARIO_CREACION;

                Command.Parameters.Add("@P_USUARIO_MODIFICA", DbType.Int32);
                Command.Parameters["@P_USUARIO_MODIFICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_USUARIO_MODIFICA"].Value = actividad_detalle.P_USUARIO_MODIFICA;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return valor;
        }


    }

}