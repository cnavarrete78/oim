/*
 *******************************************************************************************
  PROGRAMA				: DAOListasDesplegables.cs
  FECHA DE CREACION	    : Mayo 29 de 2010
  FECHA DE MODIFICACION : Octubre 25 de 2019
  VERSION               : 1.1
  AUTOR                 : Gustavo Adolfo Caicedo Viveros

 *******************************************************************************************

  CLASE			        : DAOListasDesplegables.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : Emerson Pulido - Gustavo Adolfo Caicedo Viveros
********************************************************************************************
*/

using System;
using System.Data;
using System.Data.Common;
using com.GACV.lgb.modelo.usuario;
using System.Data.SqlClient;
////using com.GACV.lgb.modelo.descripcion_oferta;


namespace com.GACV.lgb.persistencia.dao
{
    public class DAOListasDesplegables
    {
        private string cliente;

        //OracleDataAdapter DataAdapter = new OracleDataAdapter();

        /// Método constructor de la clase       
        public DAOListasDesplegables()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        #region LISTAS DESPLEGABLES

        // Listado de los paises
        public DataSet L_D_Pais()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_PAIS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet L_D_Ciudades(int id_pais)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ciudad_pais", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PAIS", DbType.Int32);
                Command.Parameters["@P_ID_PAIS"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PAIS"].Value = id_pais;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Obtener la lista de los departamentos
        public DataSet L_D_Departamento()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_departamento", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los departamentos segun la territorial
        public DataSet L_D_Departamento_territorial(int id_territorial)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_DEPARTAMENTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_territorial", DbType.Int32);
                Command.Parameters["@p_id_territorial"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_territorial"].Value = id_territorial;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los municipios y departamentos segun la territorial
        public DataSet L_D_Municipio_Dep_territorial(int id_territorial, int id_departamento)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_MUNICIPIO_DEP_TERRITORIAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_territorial", DbType.Int32);
                Command.Parameters["@p_id_territorial"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_territorial"].Value = id_territorial;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = id_departamento;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los municipios
        //public DataSet L_D_Municipio(int id_departamento)
        public DataSet L_D_Municipio(int id_departamento, int id_territorial, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                //SqlCommand Command = new SqlCommand("sp_municipio2", con);
                SqlCommand Command = new SqlCommand("SP_MUNICIPIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                //Command.Parameters.Add("@id_departamento", DbType.Int32);
                //Command.Parameters["@id_departamento"].Direction = ParameterDirection.Input;
                //Command.Parameters["@id_departamento"].Value = id_departamento;

                //NUEVOS
                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = id_departamento;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = id_territorial;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }


        // Obtener la lista de Tipos de vinculacion
        public DataSet L_D_tipo_vinculacion(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                //SqlCommand Command = new SqlCommand("sp_municipio2", con);
                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_USUARIOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                //Command.Parameters.Add("@id_departamento", DbType.Int32);
                //Command.Parameters["@id_departamento"].Direction = ParameterDirection.Input;
                //Command.Parameters["@id_departamento"].Value = id_departamento;

                //NUEVOS

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Obtener la lista de los municipios
        public DataSet L_D_Municipio_oferta(int id_departamento, int id_oferta)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_MUNICIPIO_OFERTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@id_departamento", DbType.Int32);
                Command.Parameters["@id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_departamento"].Value = id_departamento;

                Command.Parameters.Add("@id_oferta", DbType.Int32);
                Command.Parameters["@id_oferta"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_oferta"].Value = id_oferta;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los tipos de piri
        public DataSet L_D_Tipo_piri(int id_tipo_usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_tipo_piri", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_TIPO_USUARIO", DbType.Int32);
                Command.Parameters["@ID_TIPO_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_TIPO_USUARIO"].Value = id_tipo_usuario;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de las categorias
        public DataSet L_D_Lista_categoria(int id_tipo_priri)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_categorias", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@id_tipo_priri", DbType.Int32);
                Command.Parameters["@id_tipo_priri"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_tipo_priri"].Value = id_tipo_priri;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los L_D_Tipo_sub_estados
        public DataSet L_D_Tipo_sub_estados(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_SUB_ESTADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@opcion", DbType.Int32);
                Command.Parameters["@opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los encuestadores
        public DataSet L_D_Encuestador(int id_departamento, int id_municipio, int id_usuario, int id_tipo_usuario)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_consultar_encuestador", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@id_departamento", DbType.Int32);
                Command.Parameters["@id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_departamento"].Value = id_departamento;

                Command.Parameters.Add("@id_municipio", DbType.Int32);
                Command.Parameters["@id_municipio"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_municipio"].Value = id_municipio;

                Command.Parameters.Add("@id_usuario", DbType.Int32);
                Command.Parameters["@id_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_usuario"].Value = id_usuario;

                Command.Parameters.Add("@id_tipo_usuario", DbType.Int32);
                Command.Parameters["@id_tipo_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_tipo_usuario"].Value = id_tipo_usuario;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de las direcciones territoriales
        // TODO: tarea pendiente
        public DataSet LD_territorial_oferta(int id_departamento)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_territorial_oferta", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = id_departamento;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de accion de oferta            
        public DataSet LD_tipo_accion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_tipo_accion", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de entidad oferta
        public DataSet LD_Entidad_oferta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_entidad_oferta", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de label 1 de oferta 
        public DataSet LD_L1_oferta(int id_tipo_oferta)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_entidad_oferta_2", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@id_tipo_entidad", DbType.Int32);
                Command.Parameters["@id_tipo_entidad"].Direction = ParameterDirection.Input;
                Command.Parameters["@id_tipo_entidad"].Value = id_tipo_oferta;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de modalidad programa
        public DataSet LD_modalidad_oferta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_MODALIDAD_OFERTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de perioricidad oferta  
        public DataSet LD_Periodicidad_oferta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_PERIOCIDAD_OFERTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de estado oferta  
        public DataSet LD_Estado_oferta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_estado_oferta", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de genero  
        public DataSet LD_Genero()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de lgbti  
        public DataSet LD_Dirigido_lgbti()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de poblacion oferta  
        public DataSet LD_Poblacion_oferta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de hechos victimizantes 
        public DataSet LD_Hechos_victimizantes()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de bajo el marco
        public DataSet LD_Programa_marco()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de medida de reparacion que cubre el proyecto
        public DataSet LD_Medida_programa()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de medida de restitucion que cubre el proyecto
        public DataSet LD_Componente_restitucion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de pasivos
        public DataSet LD_Pasivos()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo credito
        public DataSet LD_Credito()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo rehabilitacion
        public DataSet LD_rehabilitacion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de componente de satisfaccion
        public DataSet LD_satisfaccion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de componentes que ofrece el programa
        public DataSet LD_Componentes()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_componentes", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de vivienda
        public DataSet LD_Tipo_vivienda()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de componente especifico de vivienda
        public DataSet LD_C_vivienda()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de componente de educacion
        public DataSet LD_C_educacion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de componente descripcion educacion
        public DataSet LD_D_educacion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de componente generacion de ingresos o proyecto productivo
        public DataSet LD_Generacion_ingresos()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de enfoque programa proyecto productivo
        public DataSet LD_Enfoque_programa()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de nivel educativo para ingresar al programa
        public DataSet LD_nivel_educativo()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de nivel educativo requerido
        public DataSet LD_Nivel_requerido()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("pendiente", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de identificacion          
        public DataSet L_D_Tipo_identificacion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_IDENTIFICACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        /// Obtener la lista del estado del  usuario en el sistema
        public DataSet L_D_Estado()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_estado_usuario", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        /// Obtener la lista de los tipos de usuario
        public DataSet L_D_Tipo_usuario()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_USUARIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        /// Obtener los tipos de novedades
        public DataSet L_D_Tipo_novedad()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_NOVEDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        /// alcance
        public DataSet L_D_alcance(int rol)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ALCANCE_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_rol", DbType.Int32);
                Command.Parameters["@p_rol"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_rol"].Value = rol;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        /// Tipo entidad
        public DataSet LD_tipo_entidad()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        /// Entidad
        public DataSet LD_entidad(int id_alcance, int id_departamento, int id_municipio, int rol, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ENTIDAD_LISTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_alcance", DbType.Int32);
                Command.Parameters["@p_id_alcance"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_alcance"].Value = id_alcance;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = id_departamento;

                Command.Parameters.Add("@p_id_municipio", DbType.Int32);
                Command.Parameters["@p_id_municipio"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_municipio"].Value = id_municipio;

                Command.Parameters.Add("@p_id_tipo_usuario", DbType.Int32);
                Command.Parameters["@p_id_tipo_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_usuario"].Value = rol;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        ////public DataSet LD_oferta(Descripcion_oferta descripcion_oferta, int opcion)
        ////{
        ////    DataSet ds = new DataSet();
        ////    try
        ////    {
        ////        SqlConnection con;
        ////        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        ////        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
        ////        con.Open();

        ////        SqlCommand Command = new SqlCommand("SP_CONSULTAR_OFERTA_A_D_M_E", con);
        ////        Command.CommandType = CommandType.StoredProcedure;
        ////        Command.Connection = con;

        ////        Command.Parameters.Add("@p_id_alcance", DbType.Int32);
        ////        Command.Parameters["@p_id_alcance"].Direction = ParameterDirection.Input;
        ////        Command.Parameters["@p_id_alcance"].Value = descripcion_oferta.P_ID_ALCANCE;

        ////        Command.Parameters.Add("@p_id_departamento", DbType.Int32);
        ////        Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
        ////        Command.Parameters["@p_id_departamento"].Value = descripcion_oferta.P_ID_DEPARTAMENTO;

        ////        Command.Parameters.Add("@p_id_municipio", DbType.Int32);
        ////        Command.Parameters["@p_id_municipio"].Direction = ParameterDirection.Input;
        ////        Command.Parameters["@p_id_municipio"].Value = descripcion_oferta.P_ID_MUNICIPIO;

        ////        Command.Parameters.Add("@p_id_entidad", DbType.Int32);
        ////        Command.Parameters["@p_id_entidad"].Direction = ParameterDirection.Input;
        ////        Command.Parameters["@p_id_entidad"].Value = descripcion_oferta.P_ID_ENTIDAD;

        ////        Command.Parameters.Add("@p_id_usuario", DbType.Int32);
        ////        Command.Parameters["@p_id_usuario"].Direction = ParameterDirection.Input;
        ////        Command.Parameters["@p_id_usuario"].Value = descripcion_oferta.P_ID_USUARIO_GESTIONA;

        ////        Command.Parameters.Add("@p_opcion", DbType.Int32);
        ////        Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
        ////        Command.Parameters["@p_opcion"].Value = opcion;

        ////        DataAdapter.SelectCommand = Command;
        ////        DataAdapter.Fill(ds);
        ////        con.Close();
        ////    }
        ////    catch (System.Data.SqlClient.SqlException ex)
        ////    {

        ////    }
        ////    return ds;
        ////}

        /// usuarios
        public DataSet LD_usuarios(int id_departamento, int id_municipio, int rol, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_S_USUARIOS_LISTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = id_departamento;

                Command.Parameters.Add("@p_id_municipio", DbType.Int32);
                Command.Parameters["@p_id_municipio"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_municipio"].Value = id_municipio;

                Command.Parameters.Add("@p_id_tipo_usuario", DbType.Int32);
                Command.Parameters["@p_id_tipo_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_tipo_usuario"].Value = rol;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_genero()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_GENERO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet L_D_Tipo_cobertura()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_COBERTURA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet L_D_Supervisor(Usuario usuario, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_SUPERVISOR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = usuario.P_ID_DEPARTAMENTO;

                Command.Parameters.Add("@p_id_municipio", DbType.Int32);
                Command.Parameters["@p_id_municipio"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_municipio"].Value = usuario.P_ID_MUNICIPIO;

                Command.Parameters.Add("@p_id_usuario", DbType.Int32);
                Command.Parameters["@p_id_usuario"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_usuario"].Value = usuario.F_ID_USUARIO;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        // Carga la categoria
        public DataSet L_D_Categoria()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_CATEGORIAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        // Carga el modulo
        public DataSet L_D_Modulo(int id_categoria)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_MODULOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_categoria", DbType.Int32);
                Command.Parameters["@p_id_categoria"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_categoria"].Value = id_categoria;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        // Obtener la lista de periodicidad del pago
        public DataSet LD_periodicidad_pago()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_PERIOCIDAD_OFERTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista del marco de la oferta
        public DataSet LD_programa_marco()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_MARCO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de ESTADO DE CASO
        public DataSet LD_estado_caso()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ESTADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Carga LA LISTA DESPLEGABLE DE SUB ESTADOS DEPENDIENDO DEL ESTADO
        public DataSet L_D_subestado_caso(int id_proceso)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_SUBESTADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PROCESO", DbType.Int32);
                Command.Parameters["@P_ID_PROCESO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PROCESO"].Value = id_proceso;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        // Obtener la lista de las entidades por departamento y municipio

        public DataSet LD_entidad_x_dep_municipio(int id_departamento, int id_municipio)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_ENTIDAD_X_DEP_MUNICIPIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = id_departamento;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = id_municipio;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        //Obtener la lista de las ofertas por departamento, municipio y entidades
        public DataSet LD_oferta_dep_mun_entidad(int id_departamento, int id_municipio, int id_entidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_OFERTA_D_M_E", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = id_departamento;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = id_municipio;

                Command.Parameters.Add("@P_ID_ENTIDAD", DbType.Int32);
                Command.Parameters["@P_ID_ENTIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ENTIDAD"].Value = id_entidad;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        // Se obtiene la lista desplegable del estado de la oferta
        public DataSet LD_estado_oferta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ESTADO_OFERTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        //Obtener la lista de los tipos de alcance
        public DataSet LD_entidad_alcance()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ENTIDAD_ALCANCE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de medida de reparacion que cubre el proyecto
        public DataSet LD_medida_programa(int id_marco)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_MEDIDA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_MARCO", DbType.Int32);
                Command.Parameters["@P_ID_MARCO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MARCO"].Value = id_marco;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los detalles del componente que cubre la medida del proyecto
        public DataSet LD_detalle_componente(int id_componente)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_DETALLE_COMPONENTE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_COMPONENTE", DbType.Int32);
                Command.Parameters["@P_ID_COMPONENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_COMPONENTE"].Value = id_componente;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de la especificacion de los detalles del componente que cubre la medida del proyecto
        public DataSet LD_Especificaciones(int id_componente)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ESPECIFICACIONES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_COMPONENTE", DbType.Int32);
                Command.Parameters["@P_ID_COMPONENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_COMPONENTE"].Value = id_componente;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de las zona
        public DataSet L_D_Zona()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ZONA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Obtener la lista de las territoriales
        public DataSet L_D_Territorial()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TERRITORIAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los modulos
        public DataSet RBL_Modulos(int id_modulo)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_MODULOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_MODULO", DbType.Int32);
                Command.Parameters["@P_ID_MODULO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MODULO"].Value = id_modulo;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet L_D_Modulo()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_MODULOS_PREGUNTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                //Command.Parameters.Add("@p_id_categoria", DbType.Int32);
                //Command.Parameters["@p_id_categoria"].Direction = ParameterDirection.Input;
                //Command.Parameters["@p_id_categoria"].Value = id_categoria;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        // Carga los tipos de campo
        public DataSet L_D_Campo()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_RCAMPO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet L_D_Sub_estados()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_sub_estado_telefonos", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de los tipos de documento
        public DataSet LD_Tipo_documento()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ARCHIVO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de los tipos de documento
        public DataSet LD_Tipo_documento_ryr(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ARCHIVOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        // Obtener la lista de los modulos
        public DataSet RBL_Modulos_colectiva(int id_modulo)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_MODULOS_COLECTIVA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_MODULO", DbType.Int32);
                Command.Parameters["@P_ID_MODULO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MODULO"].Value = id_modulo;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de los tipos de sujeto colectiva
        public DataSet L_D_tipo_sujeto()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_SUJETO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de los tipos de sujeto colectiva el el detalle
        public DataSet L_D_tipo_sujeto_detalle(int id_tipo_sujeto_colectiva_det)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_SUJETO_DETALLE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_TIPO_SCOLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_TIPO_SCOLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TIPO_SCOLECTIVA"].Value = id_tipo_sujeto_colectiva_det;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de los tipos de contacto del directorio colectiva
        public DataSet L_D_Tipo_contacto()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_CONTACTO_DIRECTORIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet L_D_Tipo_Contacto(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_DIRECTORIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        //lista desplegable del programa remision
        public DataSet LD_Programa_remision()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_PROGRAMA_REMISION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        //lista desplegable de los parametros de la oferta
        public DataSet L_D_parametros_oferta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_PARAMETROS_OFERTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        //lista desplegable de los parametros de la oferta
        public DataSet L_D_Estado_remision()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ESTADO_REMISION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // lista de opcion de tierras choque
        public DataSet L_D_Opcion_tierras_choq(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_OPC_TIERRAS_CHOQUE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        // Obtener la lista de los departamentos
        public DataSet L_D_Consulta_lugar(int opcion, int id_territorial, int id_departamento)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_LUGAR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = opcion;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = id_territorial;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = id_departamento;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //lista desplegable de los parametros del parentesco
        public DataSet LD_Tipo_parentesco()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_PARENTESCO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        //lista desplegable de las posibles etnias
        public DataSet LD_Tipo_etnia()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ETNIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        //lista desplegable de las posibles etnias
        public DataSet LD_Tipo_resguardo()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_RESGUARDO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        /// Obtener la lista de los tipos de usuario para colectiva
        public DataSet L_D_Perfil()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_PERFIL_COLECTIVA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        /// Obtener la lista de los tipos de usuario para colectiva
        public DataSet L_D_Usuarios(int id_perfil, int id_sujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_USUARIOS_SC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PERFIL", DbType.Int32);
                Command.Parameters["@P_ID_PERFIL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PERFIL"].Value = id_perfil;

                Command.Parameters.Add("@P_ID_SUJETO_COLECTIVA", DbType.Int32);
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_SUJETO_COLECTIVA"].Value = id_sujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet L_D_id_tipo_solicitud1()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_SOLICITUD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet L_D_id_area_misional1()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_AREA_MISIONAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet L_D_id_tipo_requerimiento1(int SUB_ID_TIPO_SOLICITUD)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_SOLICITUD_REQUERIMIENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_SUB_ID_TIPO_SOLICITUD", DbType.Int32);
                Command.Parameters["@P_SUB_ID_TIPO_SOLICITUD"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_SUB_ID_TIPO_SOLICITUD"].Value = SUB_ID_TIPO_SOLICITUD;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet LD_TipoPersona()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_GET_TIPO_PERSONA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        //lista desplegable de las posibles eventos
        public DataSet LD_Rol_evento()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("[SP_TIPO_ROL_EVENTO]", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Obtener la lista de las repsuestas del PAARI de reparación
        public DataSet L_D_Respuestas_Paari_Reparacion(Int64 id_Pregunta, string NombrePregunta)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_GET_RESPUESTAS_CONSULTA_PAARI_REPARACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_PREGUNTA", DbType.Int64);
                Command.Parameters["@ID_PREGUNTA"].Value = id_Pregunta;

                Command.Parameters.Add("@NOMBRE_PREGUNTA", DbType.String);
                Command.Parameters["@NOMBRE_PREGUNTA"].Value = NombrePregunta;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }



        // Desactiva la programación de la consulta para el paari de reparación.
        public int Desactiva_Programacion_Consulta_Paari_Reparacion(Int64 intTicket, int intEstado, Int64 intCodigoUsuario)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_SET_ESTADO_CONSULTA_PAARI_REPARACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_TICKET", DbType.Int64);
                Command.Parameters["@ID_TICKET"].Value = intTicket;

                Command.Parameters.Add("@ID_ESTADO", DbType.Int64);
                Command.Parameters["@ID_ESTADO"].Value = intEstado;

                Command.Parameters.Add("@USUARIO_SOLICITA", DbType.Int64);
                Command.Parameters["@USUARIO_SOLICITA"].Value = intCodigoUsuario;

                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                valor = 0;
            }

            return valor;
        }

        // Descarga la programación de la consulta para el paari de reparación.
        public int Descarga_Programacion_Consulta_Paari_Reparacion(Int64 intTicket, Int64 intCodigoUsuario)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_SET_DESCARGA_CONSULTA_PAARI_REPARACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_TICKET", DbType.Int64);
                Command.Parameters["@ID_TICKET"].Value = intTicket;

                Command.Parameters.Add("@USUARIO_SOLICITA", DbType.Int64);
                Command.Parameters["@USUARIO_SOLICITA"].Value = intCodigoUsuario;

                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                valor = 0;
            }

            return valor;
        }

        // ERjecuta la programación de la consulta para el paari de reparación en tiempo real
        public int Ejecuta_Programacion_Consulta_Paari_Reparacion(Int64 intTicket, Int64 intCodigoUsuario)
        {
            int valor = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_EXEC_PROGRAMACION_PAARI_REPARACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_TICKET_IN", DbType.Int64);
                Command.Parameters["@ID_TICKET_IN"].Value = intTicket;

                Command.Parameters.Add("@USER_EJECUTA", DbType.Int64);
                Command.Parameters["@USER_EJECUTA"].Value = intCodigoUsuario;

                Command.CommandTimeout = 0;
                valor = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                valor = 0;
            }

            return valor;
        }

        // Listado de despachos
        public DataSet L_D_Despacho(int id_municipio)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_consultar_despacho", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@P_ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_MUNICIPIO"].Value = id_municipio;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Listado de estado proceso
        public DataSet LD_Estado_proceso()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_estado_proceso_oaj", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Listado de roles
        public DataSet L_D_rol_gv1()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ROL_PROCESO_P_OAJ", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        //Obtener la lista de los tipos de archivos OAJ
        public DataSet LD_Tipo_archivo()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ARCHIVO_OAJ", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de usuarios activos
        public DataSet LD_Resposable()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("[SP_ADMINISTRAR_USUARIOS]", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_opcion", DbType.Int32);
                Command.Parameters["@p_opcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_opcion"].Value = 24;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los listadores
        public DataSet L_D_Listador()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("sp_consultar_listador", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los estados de la imagen
        public DataSet LD_Estado_imagen()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTA_ESTADO_IMAGEN", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Listado de usuarios por rol y area
        public DataSet LD_proceso_usuario(int id_usuario, int id_rol, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_ASIGNACION_PERSONAL_OAJ", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_USUARIO", DbType.Int32);
                Command.Parameters["@P_ID_USUARIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_USUARIO"].Value = id_usuario;

                Command.Parameters.Add("@P_ID_ROL", DbType.Int32);
                Command.Parameters["@P_ID_ROL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ROL"].Value = id_rol;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los estados de RyR
        public DataSet LD_Estado_RyR(int opcion) /////
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_ESTADO_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        // Obtener la lista de los tipos de carta
        public DataSet L_D_tipo_carta()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_TIPO_CARTA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Obtener la lista de los estados del grupo de fondo educación
        public DataSet LD_Estado_Grupo_Fondo_Educacion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_FE_ESTADO_GRUPO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet LD_Estado_Actividad_Fondo_Educacion()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_FE_ESTADO_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet LD_Grupos_Fondo_Educacion(int IdGrupo, int IdUsuario)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_FE_GRUPOS_LISTADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_GRUPO", DbType.Int64);
                Command.Parameters["@ID_GRUPO"].Value = IdGrupo;

                Command.Parameters.Add("@ID_USUARIO", DbType.Int64);
                Command.Parameters["@ID_USUARIO"].Value = IdUsuario;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet LD_Estado_Seguimiento_Actividad()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_FE_ESTADO_SEGUIMIENTO_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet LD_Pregunta_Secreta(int intOpcion, Int32 intIdUsuario, Guid GUID, string strIdentificacion, Int16 intIdPreguntaSecreta, string strRespuestaSecreta)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_USUARIOS_TOKEN", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@OPCION", DbType.Int16);
                Command.Parameters["@OPCION"].Value = intOpcion;

                Command.Parameters.Add("@ID_USUARIO", DbType.Int64);
                Command.Parameters["@ID_USUARIO"].Value = intIdUsuario;

                Command.Parameters.Add("@TOKEN", DbType.Guid);
                Command.Parameters["@TOKEN"].Value = GUID;

                Command.Parameters.Add("@IDENTIFICACION", DbType.String);
                Command.Parameters["@IDENTIFICACION"].Value = strIdentificacion;

                Command.Parameters.Add("@P_ID_PREGUNTA_SEGURIDAD", DbType.Int16);
                Command.Parameters["@P_ID_PREGUNTA_SEGURIDAD"].Value = intIdPreguntaSecreta;

                Command.Parameters.Add("@P_RTA_PREGUNTA_SEGURIDAD", DbType.String);
                Command.Parameters["@P_RTA_PREGUNTA_SEGURIDAD"].Value = strRespuestaSecreta;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Listado de las dependencias
        public DataSet LD_Dependencia(int id_dependencia, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_DEPENDENCIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = id_dependencia;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        //CAMBIO ALEJANDRO MORENO CASTRO 05-12-2018
        // Listado de las dependencias
        public DataSet LD_Supervisor(int id_supervisor, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ADMINISTRAR_USUARIOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Listado de las ferias
        public DataSet LD_Feria()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_FERIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Listado de los departamentos
        public DataSet L_D_Departamentos(int id_territorial)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_DEPARTAMENTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = id_territorial;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // YA NO SE USA DEBIDO AL CAMBIO DE SP A --> SP_MUNICIPIO
        // Listado de los municipios por departamento
        public DataSet L_D_Municipios(int id_territorial, int id_departamento)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_MUNICIPIOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_TERRITORIAL", DbType.Int32);
                Command.Parameters["@P_ID_TERRITORIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_TERRITORIAL"].Value = id_territorial;

                Command.Parameters.Add("@P_ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@P_ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPARTAMENTO"].Value = id_departamento;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Obtener la lista de departamentos con municipios          
        public DataSet L_D_Dep_Mun()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SPR_GET_MUNICIPIO_CON_DEPARTAMENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de orientacion sexual
        public DataSet LD_OSexual()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SPR_GET_OSEXUAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de identidad de genero
        public DataSet LD_IDGenero()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_IDENTIDAD_GENERO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de actividad
        public DataSet LD_Tipo_actividad()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // carga los tipos de detalle para proyecto pruductivo
        public DataSet Tipo_actividad_proye_produ()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ACTIVIDAD_PROYE_PRODU", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet LD_Tipo_actividad2(int id_actividad_nombre, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ACTIVIDAD2", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_ACTIVIDAD_NOMBRE", DbType.Int32);
                Command.Parameters["@P_ID_ACTIVIDAD_NOMBRE"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_ACTIVIDAD_NOMBRE"].Value = id_actividad_nombre;

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

        // Obtener la lista de tipo de rol en la actividad
        public DataSet LD_Rol_responsable()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_ROL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de rol en la actividad, filtrada y parametrizada x opción
        public DataSet LD_Rol_responsable2(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_ROL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        // Obtener la lista de los municipios de la actividad
        public DataSet L_D_Municipio_actividad(int id_departamento, int id_actividad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_MUNICIPIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = id_departamento;

                Command.Parameters.Add("@p_id_actividad", DbType.Int32);
                Command.Parameters["@p_id_actividad"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_actividad"].Value = id_actividad;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Listado de los estados de los conceptos RyR
        public DataSet L_D_Estado_concepto(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_RETORNOS_ESTADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        // Obtener la lista de actividad detalle estado
        public DataSet LD_actividad_detalle_estado()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_DETALLE_ESTADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // consulta los dias de una actividad
        public DataSet LD_Dia_actividad(int id_actividad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_DIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_actividad", DbType.Int32);
                Command.Parameters["@p_id_actividad"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_actividad"].Value = id_actividad;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // consulta los dias de una actividad
        public DataSet LD_Dia_actividad(int id_actividad, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_DIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_actividad", DbType.Int32);
                Command.Parameters["@p_id_actividad"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_actividad"].Value = id_actividad;

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

        //Obtener la lista de los tipos de archivo
        public DataSet LD_Tipo_archivo(int id_proceso, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ARCHIVOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_proceso", DbType.Int32);
                Command.Parameters["@p_id_proceso"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_proceso"].Value = id_proceso;

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

        // Obtener la lista de estado de la actividad
        public DataSet LD_Actividad_estado()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_ESTADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista nombres de la actividad
        public DataSet LD_Actividad_nombre(int id_dependencia, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_NOMBRE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = id_dependencia;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de los usuarios segun la dependencia
        public DataSet L_D_Usuario(int id_dependencia, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_USUARIO_RESPONSABLE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_DEPENDENCIA", DbType.Int32);
                Command.Parameters["@P_ID_DEPENDENCIA"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_DEPENDENCIA"].Value = id_dependencia;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet L_D_Entorno_ryr(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAS_INTENCIONALIDAD_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet L_D_intencion(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAS_INTENCIONALIDAD_RYR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // modulo tierras paari
        public DataSet L_D_Modulo_tierras(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAS_MODULO_TIERRAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de estado del paari
        public DataSet LD_Estado_paari(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ESTADO_PAARI", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                //Command.Parameters.Add("@P_OPCION", DbType.Int32);
                //Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                //Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        //Obtener la lista de los tipos de documento para el modulo cys
        public DataSet LD_Tipo_documento_cys(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ARCHIVOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        // Obtener la lista de los estados de Psicosocial
        public DataSet LD_Estado_Psicosocial(int opcion) /////
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_ESTADO_PSICOSOCIAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        //lista desplegable tipo de solicitud 
        public DataSet LD_Tipo_solicitud_scys()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_SOLICITUD_SCYS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        // Obtener la lista de los productos
        public DataSet L_D_Producto()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_PRODUCTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los sub productos
        public DataSet L_D_Sub_producto(int id_producto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_SUB_PRODUCTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_ID_PRODUCTO", DbType.Int32);
                Command.Parameters["@P_ID_PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_ID_PRODUCTO"].Value = id_producto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los estados de connacionales
        public DataSet LD_Estado_Parametrizacion(int id_parametrizacion, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_CONSULTAR_ESTADO_PARAMETRIZACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_parametrizacion", DbType.Int32);
                Command.Parameters["@p_id_parametrizacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_parametrizacion"].Value = id_parametrizacion;

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

        public DataSet LD_Tipo_actividad_enfoque()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ACTIVIDAD_ENFOQUE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de tipo de rol en la actividad CON ENFOQUE
        public DataSet LD_Rol_responsable_enfoque()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_ROL_ENFOQUE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        // Obtener la lista de los municipios de la actividad segun la territorial
        public DataSet L_D_Municipio_actividad_t(int id_territorial, int id_departamento, int id_actividad, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_MUNICIPIO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@p_id_territorial", DbType.Int32);
                Command.Parameters["@p_id_territorial"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_territorial"].Value = id_territorial;

                Command.Parameters.Add("@p_id_departamento", DbType.Int32);
                Command.Parameters["@p_id_departamento"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_departamento"].Value = id_departamento;

                Command.Parameters.Add("@p_id_actividad", DbType.Int32);
                Command.Parameters["@p_id_actividad"].Direction = ParameterDirection.Input;
                Command.Parameters["@p_id_actividad"].Value = id_actividad;

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

        // carga los tipos de detalle para proyecto pruductivo
        public DataSet LD_Tipo_actividad_linea_vivienda()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_TIPO_ACTIVIDAD_LINEA_VIVIENDA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataSet LD_Actividad_estado_jornadas(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_ACTIVIDAD_ESTADO_JORNADAS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        // Obtener la lista de indicadores          
        public DataSet L_D_Indicador(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("SP_INDICADOR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

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

        //lista desplegables padre
        public DataSet L_D_Padre(int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("ADMINISTRAR_S_PERMISOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@P_OPCION", DbType.Int32);
                Command.Parameters["@P_OPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@P_OPCION"].Value = opcion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }


        #region SIGO

        // Obtener los items de las listas para la consulta en SIGO
        public DataSet L_D_Consulta_items_sigo(int id_medida, int opcion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                //con = new SqlConnection("data source = 172.20.210.68; initial catalog = sigo; user id = sigoconsulta; password = T0l1m4s;");
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString_SIGO"]);
                con.Open();

                SqlCommand Command = new SqlCommand("CONSULTA.SP_GETTABLATIPOBYFILTRO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@TABLA", DbType.Int32);
                Command.Parameters["@TABLA"].Direction = ParameterDirection.Input;
                Command.Parameters["@TABLA"].Value = opcion;

                Command.Parameters.Add("@FILTRO", DbType.Int32);
                Command.Parameters["@FILTRO"].Direction = ParameterDirection.Input;
                Command.Parameters["@FILTRO"].Value = id_medida;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        #endregion

        #endregion

        #region ADMINISTRADOR LISTAS DESPLEGABLES

        ////Validar listas desplegables 
        //public DataSet Validar_L_D(string nombre_tabla, string nombre_id_campo, string nombre_campo_tabla, int id_tabla, string dato_campo, string nombre_sq)
        //{
        //    string query = "";
        //    query = "select " + nombre_id_campo + " as id_campo, " + nombre_campo_tabla + " as nombre_campo  from " + nombre_tabla + " where " + nombre_campo_tabla + " = '" +dato_campo+"'";

        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        Database db = DatabaseFactory.CreateDatabase("cadenaConexion2");
        //        DbCommand dbCommand = db.GetSqlStringCommand(query);
        //        ds = db.ExecuteDataSet(dbCommand);
        //    }
        //    catch (System.Data.OracleClient.OracleException ex)
        //    {
        //        //MsgBox(ex.Message);
        //    }
        //    return ds;
        //}

        //// administrador de contenidos administrador de listas desplegables muestra una lista en particular
        //public DataSet Listas_L_D(string nombre_tabla, string nombre_id_campo, string nombre_campo_tabla)
        //{
        //    string query = "";
        //    query = "select " + nombre_id_campo + " as id_campo, " + nombre_campo_tabla + " as nombre_campo  from " + nombre_tabla + " order by id_campo asc";

        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        Database db = DatabaseFactory.CreateDatabase("cadenaConexion2");
        //        DbCommand dbCommand = db.GetSqlStringCommand(query);
        //        ds = db.ExecuteDataSet(dbCommand);
        //    }
        //    catch (System.Data.OracleClient.OracleException ex)
        //    {
        //        //MsgBox(ex.Message);
        //    }
        //    return ds;
        //}

        ///// administrador de contenidos administrador de listas desplegables muestra una lista en particular
        //public int Listas_L_D_Actualizar(string nombre_tabla, string nombre_id_campo, string nombre_campo_tabla, int id_tabla, string dato_campo)
        //{
        //    string query = "";                

        //    if (nombre_tabla == "WEB_ANO_LECTIVO")
        //    {
        //        query = "update " + nombre_tabla + " SET " + nombre_id_campo + "='" + dato_campo + "', " + nombre_campo_tabla + "='" + dato_campo + "' where " + nombre_id_campo + " = " + id_tabla;
        //    }
        //    else
        //    {
        //        query = "update " + nombre_tabla + " SET " + nombre_campo_tabla + "='" + dato_campo + "' where " + nombre_id_campo + " = " + id_tabla;
        //    }

        //    int valor = 0;

        //    try
        //    {
        //        Database db = DatabaseFactory.CreateDatabase("cadenaConexion2");
        //        DbCommand dbCommand = db.GetSqlStringCommand(query);
        //        valor = db.ExecuteNonQuery(dbCommand);
        //    }
        //    catch (System.Data.OracleClient.OracleException ex)
        //    {
        //        //MsgBox(ex.Message);
        //    }
        //    return valor;
        //}           

        ///// administrador de contenidos administrador de listas desplegables muestra una lista en particular
        //public int Listas_L_D_Insertar(string nombre_tabla, string nombre_id_campo, string nombre_campo_tabla, int id_tabla, string dato_campo, string nombre_sq)
        //{
        //    string query = "";

        //    if (nombre_tabla == "WEB_ANO_LECTIVO")
        //    {
        //        query = "INSERT INTO " + nombre_tabla + " (" + nombre_id_campo + ", " + nombre_campo_tabla + ") VALUES (" + dato_campo + ", '" + dato_campo + "')";
        //    }
        //    else
        //    {
        //        query = "INSERT INTO " + nombre_tabla + " (" + nombre_id_campo + ", " + nombre_campo_tabla + ") VALUES (" + nombre_sq + ".NEXTVAL, '" + dato_campo + "')";
        //    }

        //    int valor = 0;
        //    try
        //    {
        //        Database db = DatabaseFactory.CreateDatabase("cadenaConexion2");
        //        DbCommand dbCommand = db.GetSqlStringCommand(query);
        //        valor = db.ExecuteNonQuery(dbCommand);
        //    }
        //    catch (System.Data.OracleClient.OracleException ex)
        //    {
        //        //MsgBox(ex.Message);
        //    }
        //    return valor;
        //}

        ///// administrador de contenidos administrador de listas desplegables muestra una lista en particular
        //public int Listas_L_D_Eliminar(string nombre_tabla, string nombre_id_campo, string nombre_campo_tabla, int id_tabla, string dato_campo)
        //{
        //    string query = "";
        //    query = "delete from " + nombre_tabla + " where " + nombre_id_campo + " = " + id_tabla;

        //    int valor = 0;
        //    try
        //    {
        //        Database db = DatabaseFactory.CreateDatabase("cadenaConexion2");
        //        DbCommand dbCommand = db.GetSqlStringCommand(query);
        //        valor = db.ExecuteNonQuery(dbCommand);
        //    }
        //    catch (System.Data.OracleClient.OracleException ex)
        //    {
        //        //MsgBox(ex.Message);
        //    }
        //    return valor;
        //}

        #endregion


        #region Desarrollo ruta comunitaria
        public DataSet LD_PlanTrasladoPorComunidad(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_TB_PLAN_ACCION_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_Entidades_Ruta_Comunitaria()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_ENTIDADES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }
        public int LD_Insertar_plan_acción_traslado_Ruta_Comunitaria(int idComunidad, int totalHogares, int totalPersonas, int totalRUV, int id_MunSalida, int idMunLlegada, int idEntornoSalida, int idEntornoLlegada, string corregimmientoSalida, string corregimientoLlegada)
        {
            int idPlanTraslado = 0;
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@TOTAL_HOGARES_TRASLADAR", totalHogares);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);
                SqlParameter oParam2 = new SqlParameter("@TOTAL_PERSONAS_TRASLADAR", totalPersonas);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);
                SqlParameter oParam3 = new SqlParameter("@TOTAL_PERSONAS_TRASLADAR_RUV", totalRUV);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@ID_MUNICIPIO_SALIDA", id_MunSalida);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);
                SqlParameter oParam5 = new SqlParameter("@ID_MUNICIPIO_LLEGADA", idMunLlegada);
                oParam5.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam5);
                SqlParameter oParam6 = new SqlParameter("@ID_ENTORNO_SALIDA", idEntornoSalida);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);
                SqlParameter oParam7 = new SqlParameter("@ID_ENTORNO_LLEGADA", idEntornoLlegada);
                oParam7.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam7);
                SqlParameter oParam8 = new SqlParameter("@CORREGIMIENTO_SALIDA", corregimmientoSalida);
                oParam8.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam8);
                SqlParameter oParam9 = new SqlParameter("@CORREGIMIENTO_LLEGADA", corregimientoLlegada);
                oParam9.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam9);

                SqlParameter OutputParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", SqlDbType.Int);
                OutputParam.Direction = ParameterDirection.Output;
                Command.Parameters.Add(OutputParam);
                Command.ExecuteNonQuery();

                idPlanTraslado = Convert.ToInt32(Command.Parameters["@ID_PLAN_ACCION_TRASLADO"].Value);

                con.Close();
                return idPlanTraslado;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return idPlanTraslado;
        }

        public bool LD_Insertar_plan_acción_traslado_entidad_ruta_comunitaria(int idPlan, int idEntidad)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_TB_PLAN_ACCION_TRASLADO_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);
                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Eliminar_plan_acción_traslado_entidad_ruta_comunitaria(int idPlan, int idEntidad)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);
                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Insertar_plan_acción_traslado_categoria_ruta_comunitaria(int idCategoria, int idPlan, int idComuidad, string resultado, string acciones, string observaciones)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_CATEGORIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam0 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam0.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam0);

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComuidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@RESULTADO", resultado);
                oParam2.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ACCIONES", acciones);
                oParam3.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@OBSERVACIONES", observaciones);
                oParam4.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam4);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Insertar_plan_acción_traslado_Categorizacion_entidad_ruta_comunitaria(int idPlan, int idEntidad, int idCategoria)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_TB_PLAN_ACCION_TRASLADO_CATEGORIA_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Eliminar_plan_acción_traslado_caracterizacion_entidad_ruta_comunitaria(int idPlan, int idEntidad, int idCategoria)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_CATEGORIA_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public DataSet LD_Consultar_plan_acción_traslado_categorias_Entidad_Ruta_Comunitaria(int idPlan, int idCategoria)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_CATEGORIA_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam2 = new SqlParameter("@ID_CATEGORIA", idCategoria);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }



        public bool LD_Insertar_plan_acción_traslado_balance_traslado_ruta_comunitaria(int id, int idPlan, int idComuidad, string actividad, string responsable, bool cumplida, string observaciones)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComuidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ACTIVIDAD", actividad);
                oParam2.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@RESPONSABLE", responsable);
                oParam3.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@CUMPLIDA", cumplida);
                oParam4.SqlDbType = SqlDbType.Bit;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@OBSERVACIONES", observaciones);
                oParam5.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Eliminar_plan_acción_traslado_balance_traslado_Ruta_Comunitaria(int id)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID", id);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Eliminar_plan_acción_traslado_profesionales_traslado_Ruta_Comunitaria(int id)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_ELIMINAR_TB_PLAN_ACCION_TRASLADO_PROFESIONALES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID", id);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Insertar_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(int id, int idPlan, int idComuidad, string profesional, int idEntidad, string telefono, string correo)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_PROFESIONALES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComuidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@PROFESIONAL", profesional);
                oParam2.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@TELEFONO", telefono);
                oParam4.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@CORREO_ELECTRONICO", correo);
                oParam5.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Insertar_plan_acción_traslado_alistamiento_traslado_ruta_comunitaria(int id, int idPlan, int idComunidad, DateTime fechaRegistro, int idMunicipio, string direccion, int idDt, int idEntidad, string profesional, string correo)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_ALISTAMIENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@FECHA_REGISTRO", fechaRegistro);
                oParam2.SqlDbType = SqlDbType.Date;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ID_DIRECCION_TERRITORIAL", idDt);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@ID_MUNICIPIO", idMunicipio);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@DIRECCION", direccion);
                oParam5.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                SqlParameter oParam7 = new SqlParameter("@ID_ENTIDAD", idEntidad);
                oParam7.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam7);

                SqlParameter oParam8 = new SqlParameter("@PROFESIONAL_REGISTRO", profesional);
                oParam8.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam8);

                SqlParameter oParam9 = new SqlParameter("@CORREO_ELECTRONICO", correo);
                oParam9.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam9);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public bool LD_Insertar_plan_acción_traslado_inventario_hogar_ruta_comunitaria(int id, int idPlan, int idComunidad,int idHogar, int estufas, int neveras, int utenciliosCocina,int camas, int colchones,int cobijas,  int sofas, int sillas, int mesas, int equiposSonido, int juguetes, int bicicletas, int motos, int tulas, int peso,  bool rotulacion)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_INVENTARIO_HOGAR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO",idPlan );
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_HOGAR", idHogar);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@ESTUFAS", estufas);
                oParam3.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@NEVERAS", neveras);
                oParam4.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam4);

                SqlParameter oParam5 = new SqlParameter("@UTENCILIOS_COCINA", utenciliosCocina);
                oParam5.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam5);

                SqlParameter oParam6 = new SqlParameter("@ID", id);
                oParam6.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam6);

                SqlParameter oParam7 = new SqlParameter("@CAMAS", camas);
                oParam7.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam7);

                SqlParameter oParam8 = new SqlParameter("@COLCHONES", colchones);
                oParam8.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam8);

                SqlParameter oParam9 = new SqlParameter("@SOFAS",sofas );
                oParam9.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam9);

                SqlParameter oParam10 = new SqlParameter("@SILLAS", sillas );
                oParam10.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam10);

                SqlParameter oParam11 = new SqlParameter("@MESAS", mesas);
                oParam11.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam11);

                SqlParameter oParam12 = new SqlParameter("@EQUIPOS_DE_SONIDO", equiposSonido);
                oParam12.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam12);

                SqlParameter oParam13 = new SqlParameter("@JUGUTES_ROPA",juguetes );
                oParam13.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam13);

                SqlParameter oParam14 = new SqlParameter("@BICICLETAS", bicicletas);
                oParam14.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam14);

                SqlParameter oParam15 = new SqlParameter("@MOTOS", motos);
                oParam15.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam15);

                SqlParameter oParam16 = new SqlParameter("@TULAS", tulas);
                oParam16.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam16);

                SqlParameter oParam17 = new SqlParameter("@PESO", peso );
                oParam17.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam17);

                SqlParameter oParam18 = new SqlParameter("@ROTULACION",rotulacion );
                oParam18.SqlDbType = SqlDbType.Bit;
                Command.Parameters.Add(oParam18);

                SqlParameter oParam19 = new SqlParameter("@COBIJAS", cobijas);
                oParam19.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam19);
                

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }

        public DataSet LD_Consultar_plan_acción_traslado_Ruta_Comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }
        public DataSet LD_Consultar_plan_acción_traslado_Entidad_Ruta_Comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_ENTIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_Consultar_Categoria_plan_acción_traslado_Ruta_Comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_CATEGORIA_TRASLADO_POR_ID_PLAN_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_Consultar_Tipo_Evidencia()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_RYR_GET_TB_TIPO_EVIDENCIA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_plan_acción_traslado_balance_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_BALANCE_TRASLADO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_plan_acción_traslado_profesionales_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_PROFESIONALES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_plan_acción_traslado_Alistamiento_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_ALISTAMIENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_plan_acción_traslado_Inventario_hogar_ruta_comunitaria(int idComunidad)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_INVENTARIO_HOGAR", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet LD_plan_acción_traslado_Inventario_hogar_enseres_ruta_comunitaria(int idHogar)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_TB_PLAN_ACCION_TRASLADO_INVENTARIO_HOGAR_ENSERES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_HOGAR", idHogar);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        public DataSet Get_Persona_Plan_Accion_Traslado_por_numero_documento(string numDocumetno)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_BUSQUEDA_PERSONA_POR_NUMERO_DOCUMENTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@NUMERO_DOCUMENTO", numDocumetno);
                oParam.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam);
        
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }
        public bool LD_Modificar_Persona_trasladar_plan_acción_traslado_ruta_comunitaria(int idPlan,int idComunidad, int idPersona, bool seTraslada, string motivo)
        {
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_INSERTAR_ACTUALIZAR_TB_PLAN_ACCION_TRASLADO_PERSONA_NO_TRASLADA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_COMUNIDAD", idComunidad);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                SqlParameter oParam1 = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam1.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam1);

                SqlParameter oParam2 = new SqlParameter("@ID_PERSONA", idPersona);
                oParam2.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam2);

                SqlParameter oParam3 = new SqlParameter("@MOTIVO", motivo);
                oParam3.SqlDbType = SqlDbType.Text;
                Command.Parameters.Add(oParam3);

                SqlParameter oParam4 = new SqlParameter("@SETRASLADA", seTraslada);
                oParam4.SqlDbType = SqlDbType.Bit;
                Command.Parameters.Add(oParam4);

                Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
                return false;
            }
            return true;
        }
        public DataSet LD_Personas_NO_se_trasladan_plan_acción_traslado_ruta_comunitaria(int idPlan)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("RYR_COMUNITARIO.SP_GET_PERSONAS_NO_SE_TRASLADAN", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                SqlParameter oParam = new SqlParameter("@ID_PLAN_ACCION_TRASLADO", idPlan);
                oParam.SqlDbType = SqlDbType.Int;
                Command.Parameters.Add(oParam);

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MsgBox(ex.Message);
            }
            return ds;
        }

        #endregion
    }

}
