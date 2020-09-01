/*
 *******************************************************************************************
  PROGRAMA				: DAOActividad.cs
  AUTOR                 : GUSTAVO ADOLFO CAICEDO VIVEROS
  FECHA DE CREACION	    : 13-04-2015
  USUARIO MODIFICA      : JOSE MIGUEL IMBACHI
  FECHA DE MODIFICACION : 06-03-2017
  VERSION               : 1.1
 *******************************************************************************************    
  CLASE			        : DAOActividad.cs
  RESPONSABILIDAD	    : Se encarga las consultas en la BD
  COLABORACION		    : 
 ********************************************************************************************
*/

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using com.GACV.lgb.modelo.actividad;
using com.GACV.lgb.modelo.persona;
using com.GACV.lgb.modelo.sujeto_colectiva;
using System;

namespace com.GACV.lgb.persistencia.dao
{
    public class DAOMGA
    {
        private string cliente;
       
        /// Método constructor de la clase       
        public DAOMGA()
        {
            cliente = System.Configuration.ConfigurationManager.AppSettings["IdClient"];
        }

        // Obtener el listado de parámetros
        public DataSet ListaParametros()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_LISTA_PARAMETROS", con);
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

        // Obtener parámetros de acuerdo a la categoría
        public DataSet ListaParametrosById(int idParam)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_LISTA_PARAMETRO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@IdParam", DbType.Int32);
                Command.Parameters["@IdParam"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdParam"].Value = idParam;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return ds;
        }

        public DataRow DatosParametro(int idParam)
        {
            DataSet ds = new DataSet();
            DataRow dr = ds.Tables.Add().Rows.Add();

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_DATOS_PARAMETRO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@IdParam", DbType.Int32);
                Command.Parameters["@IdParam"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdParam"].Value = idParam;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();

                dr = ds.Tables[1].Rows[0];
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return dr;
        }
        

        public DataSet ListaValoresParametroTabla(string tableName)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_DEPENDIENTE", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@NombreTabla", DbType.String);
                Command.Parameters["@NombreTabla"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTabla"].Value = tableName;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ListaValoresParametroTablaSujeto(string tableName, int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_DEPENDIENTE_SUJETO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@NombreTabla", DbType.String);
                Command.Parameters["@NombreTabla"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTabla"].Value = tableName;

                Command.Parameters.Add("@IdSujeto", DbType.Int32);
                Command.Parameters["@IdSujeto"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdSujeto"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ListaValoresParametroTablaId(string tableName, string tableMain, int idMain)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_DEPENDIENTE_ID", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@NombreTabla", DbType.String);
                Command.Parameters["@NombreTabla"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTabla"].Value = tableName;

                Command.Parameters.Add("@NombreTablaPrincipal", DbType.String);
                Command.Parameters["@NombreTablaPrincipal"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTablaPrincipal"].Value = tableMain;

                Command.Parameters.Add("@IdPrincipal", DbType.Int32);
                Command.Parameters["@IdPrincipal"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdPrincipal"].Value = idMain;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int InsertarValorParametro(string tabla, string valor, bool activo, bool depen, int idDepen, bool sujeto, int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_PARAMETRO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@NombreTabla", DbType.String);
                Command.Parameters["@NombreTabla"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTabla"].Value = tabla;

                Command.Parameters.Add("@Valor", DbType.String);
                Command.Parameters["@Valor"].Direction = ParameterDirection.Input;
                Command.Parameters["@Valor"].Value = valor;

                Command.Parameters.Add("@Activo", DbType.Boolean);
                Command.Parameters["@Activo"].Direction = ParameterDirection.Input;
                Command.Parameters["@Activo"].Value = activo;

                Command.Parameters.Add("@Depen", DbType.Boolean);
                Command.Parameters["@Depen"].Direction = ParameterDirection.Input;
                Command.Parameters["@Depen"].Value = depen;

                Command.Parameters.Add("@IdDep", DbType.Int32);
                Command.Parameters["@IdDep"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdDep"].Value = idDepen;

                Command.Parameters.Add("@Sujeto", DbType.Boolean);
                Command.Parameters["@Sujeto"].Direction = ParameterDirection.Input;
                Command.Parameters["@Sujeto"].Value = sujeto;

                Command.Parameters.Add("@IdTipoSujeto", DbType.Int32);
                Command.Parameters["@IdTipoSujeto"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdTipoSujeto"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                if(!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }                
            }

            return val;
        }

        public int InsertarValorParametroProducto(int idValor, string valor, bool activo, int idDepen, string descripcion, string medido, string indicador, string medida)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_PARAMETRO_PRODUCTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@IdProducto", DbType.Int32);
                Command.Parameters["@IdProducto"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdProducto"].Value = idValor;

                Command.Parameters.Add("@Valor", DbType.String);
                Command.Parameters["@Valor"].Direction = ParameterDirection.Input;
                Command.Parameters["@Valor"].Value = valor;

                Command.Parameters.Add("@Activo", DbType.Boolean);
                Command.Parameters["@Activo"].Direction = ParameterDirection.Input;
                Command.Parameters["@Activo"].Value = activo;
                
                Command.Parameters.Add("@IdDep", DbType.Int32);
                Command.Parameters["@IdDep"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdDep"].Value = idDepen;

                Command.Parameters.Add("@Descripcion", DbType.String);
                Command.Parameters["@Descripcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@Descripcion"].Value = descripcion;

                Command.Parameters.Add("@Medido", DbType.String);
                Command.Parameters["@Medido"].Direction = ParameterDirection.Input;
                Command.Parameters["@Medido"].Value = medido;

                Command.Parameters.Add("@Indicador", DbType.String);
                Command.Parameters["@Indicador"].Direction = ParameterDirection.Input;
                Command.Parameters["@Indicador"].Value = indicador;

                Command.Parameters.Add("@Medida", DbType.String);
                Command.Parameters["@Medida"].Direction = ParameterDirection.Input;
                Command.Parameters["@Medida"].Value = medida;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int ActualizarValorParametro(string tabla, string tablaDep, int idValor, string valor, bool activo, bool depen, int idDepen, bool sujeto, int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ACTUALIZAR_PARAMETRO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@NombreTabla", DbType.String);
                Command.Parameters["@NombreTabla"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTabla"].Value = tabla;

                Command.Parameters.Add("@NombreTablaDep", DbType.String);
                Command.Parameters["@NombreTablaDep"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTablaDep"].Value = tablaDep;

                Command.Parameters.Add("@IdParam", DbType.Int32);
                Command.Parameters["@IdParam"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdParam"].Value = idValor;

                Command.Parameters.Add("@Valor", DbType.String);
                Command.Parameters["@Valor"].Direction = ParameterDirection.Input;
                Command.Parameters["@Valor"].Value = valor;

                Command.Parameters.Add("@Activo", DbType.Boolean);
                Command.Parameters["@Activo"].Direction = ParameterDirection.Input;
                Command.Parameters["@Activo"].Value = activo;

                Command.Parameters.Add("@Depen", DbType.Boolean);
                Command.Parameters["@Depen"].Direction = ParameterDirection.Input;
                Command.Parameters["@Depen"].Value = depen;

                Command.Parameters.Add("@IdDep", DbType.Int32);
                Command.Parameters["@IdDep"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdDep"].Value = idDepen;

                Command.Parameters.Add("@Sujeto", DbType.Boolean);
                Command.Parameters["@Sujeto"].Direction = ParameterDirection.Input;
                Command.Parameters["@Sujeto"].Value = sujeto;

                Command.Parameters.Add("@IdTipoSujeto", DbType.Int32);
                Command.Parameters["@IdTipoSujeto"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdTipoSujeto"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int EliminarValorParametro(string tabla, int idValor)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_VALOR_PARAMETRO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@NombreTabla", DbType.String);
                Command.Parameters["@NombreTabla"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreTabla"].Value = tabla;
                
                Command.Parameters.Add("@IdParam", DbType.Int32);
                Command.Parameters["@IdParam"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdParam"].Value = idValor;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public int EliminarParametrosPIRC(int idSujeto, string param)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_PARAMETROS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;
                
                Command.Parameters.Add("@PARAM", DbType.String);
                Command.Parameters["@PARAM"].Direction = ParameterDirection.Input;
                Command.Parameters["@PARAM"].Value = param;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public int InsertarParametrosPIRC(int idSujeto, int idParam, string param)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_PARAMETROS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;
                
                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;
                
                Command.Parameters.Add("@ID_PARAM", DbType.Int32);
                Command.Parameters["@ID_PARAM"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PARAM"].Value = idParam;

                Command.Parameters.Add("@PARAM", DbType.String);
                Command.Parameters["@PARAM"].Direction = ParameterDirection.Input;
                Command.Parameters["@PARAM"].Value = param;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int InsertarDatosBasicosPIRC(int idSujeto, int idTipoSujeto, string nombreSujeto, string nit, int idDT, int idDept, int idMun, DateTime? fecha)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_DATOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_TIPO_SUJETO", DbType.Int32);
                Command.Parameters["@ID_TIPO_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_TIPO_SUJETO"].Value = idTipoSujeto;

                Command.Parameters.Add("@NOMBRE_SUJETO", DbType.String);
                Command.Parameters["@NOMBRE_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@NOMBRE_SUJETO"].Value = nombreSujeto;

                Command.Parameters.Add("@NIT", DbType.String);
                Command.Parameters["@NIT"].Direction = ParameterDirection.Input;
                Command.Parameters["@NIT"].Value = nit;

                Command.Parameters.Add("@ID_DT", DbType.Int32);
                Command.Parameters["@ID_DT"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_DT"].Value = idDT;

                Command.Parameters.Add("@ID_DEPARTAMENTO", DbType.Int32);
                Command.Parameters["@ID_DEPARTAMENTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_DEPARTAMENTO"].Value = idDept;

                Command.Parameters.Add("@ID_MUNICIPIO", DbType.Int32);
                Command.Parameters["@ID_MUNICIPIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_MUNICIPIO"].Value = idMun;

                Command.Parameters.Add("@FECHA_FASE_CARACTERIZACION", DbType.DateTime);
                Command.Parameters["@FECHA_FASE_CARACTERIZACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHA_FASE_CARACTERIZACION"].Value = fecha;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public DataSet ListaParametrosPIRC(int idSujeto, string param)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_PARAMETROS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@PARAM", DbType.String);
                Command.Parameters["@PARAM"].Direction = ParameterDirection.Input;
                Command.Parameters["@PARAM"].Value = param;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerAnalisisPoblacionPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_ANALISIS_POBLACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;
                
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }


        public int InsertarAnalisisPoblacionPIRC(int idSujeto, string pobAfecQuienes, string pobAfecCarac, int pobAfecCantidad, string pobAfectUbica
            , string pobObjQuienes, string pobObjCarac, int pobObjCantidad, string pobObjtUbica)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_ANALISIS_POBLACION", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;
                
                Command.Parameters.Add("@POBLACION_AFECTADA_QUIENES", DbType.String);
                Command.Parameters["@POBLACION_AFECTADA_QUIENES"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_AFECTADA_QUIENES"].Value = pobAfecQuienes;

                Command.Parameters.Add("@POBLACION_AFECTADA_CARAC", DbType.String);
                Command.Parameters["@POBLACION_AFECTADA_CARAC"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_AFECTADA_CARAC"].Value = pobAfecCarac;

                Command.Parameters.Add("@POBLACION_AFECTADA_CANT", DbType.Int32);
                Command.Parameters["@POBLACION_AFECTADA_CANT"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_AFECTADA_CANT"].Value = pobAfecCantidad;

                Command.Parameters.Add("@POBLACION_AFECTADA_UBICA", DbType.String);
                Command.Parameters["@POBLACION_AFECTADA_UBICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_AFECTADA_UBICA"].Value = pobAfectUbica;

                Command.Parameters.Add("@POBLACION_OBJETIVO_QUIENES", DbType.String);
                Command.Parameters["@POBLACION_OBJETIVO_QUIENES"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_OBJETIVO_QUIENES"].Value = pobObjQuienes;

                Command.Parameters.Add("@POBLACION_OBJETIVO_CARAC", DbType.String);
                Command.Parameters["@POBLACION_OBJETIVO_CARAC"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_OBJETIVO_CARAC"].Value = pobObjCarac;

                Command.Parameters.Add("@POBLACION_OBJETIVO_CANT", DbType.Int32);
                Command.Parameters["@POBLACION_OBJETIVO_CANT"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_OBJETIVO_CANT"].Value = pobObjCantidad;

                Command.Parameters.Add("@POBLACION_OBJETIVO_UBICA", DbType.String);
                Command.Parameters["@POBLACION_OBJETIVO_UBICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_OBJETIVO_UBICA"].Value = pobObjtUbica;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int InsertarBeneficiosPIRC(int idSujeto, string nombreBene, string descripcionBene)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_BENEFICIOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;
                
                Command.Parameters.Add("@NOMBRE_BENEFICIO", DbType.String);
                Command.Parameters["@NOMBRE_BENEFICIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@NOMBRE_BENEFICIO"].Value = nombreBene;

                Command.Parameters.Add("@DESCRIPCION_BENEFICIO", DbType.String);
                Command.Parameters["@DESCRIPCION_BENEFICIO"].Direction = ParameterDirection.Input;
                Command.Parameters["@DESCRIPCION_BENEFICIO"].Value = descripcionBene;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public DataSet ObtenerBeneficiosPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_BENEFICIOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int EliminarBeneficiosPIRC(int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_BENEFICIOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public DataSet ObtenerDatosProducto(int idProducto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_DATOS_PRODUCTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_PRODUCTO", DbType.Int32);
                Command.Parameters["@ID_PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PRODUCTO"].Value = idProducto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerDatosActividadesProductosPIRC(int idProducto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_ACTIVIDADES_PRODUCTOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_PRODUCTO_CV", DbType.Int32);
                Command.Parameters["@ID_PRODUCTO_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PRODUCTO_CV"].Value = idProducto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerDatosProductosPIRC(int idAtributo)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_PRODUCTOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_ATRIBUTO_CV", DbType.Int32);
                Command.Parameters["@ID_ATRIBUTO_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_ATRIBUTO_CV"].Value = idAtributo;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerDatosAtributosPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_ATRIBUTOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet InsertarActividadesProductoPIRC(int idActividad, int idProducto, int idClasificacion, int idEtapa, string actividades, string descripcion, bool ruta
            ,decimal costo1, decimal costo2, decimal costo3, decimal costot)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_CV_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@IdActividad", DbType.Int32);
                Command.Parameters["@IdActividad"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdActividad"].Value = idActividad;

                Command.Parameters.Add("@IdCVProducto", DbType.Int32);
                Command.Parameters["@IdCVProducto"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdCVProducto"].Value = idProducto;

                Command.Parameters.Add("@IdClasificacion", DbType.Int32);
                Command.Parameters["@IdClasificacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdClasificacion"].Value = idClasificacion;

                Command.Parameters.Add("@IdEtapa", DbType.Int32);
                Command.Parameters["@IdEtapa"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdEtapa"].Value = idEtapa;
                
                Command.Parameters.Add("@Actividades", DbType.String);
                Command.Parameters["@Actividades"].Direction = ParameterDirection.Input;
                Command.Parameters["@Actividades"].Value = actividades;

                Command.Parameters.Add("@Descripcion", DbType.String);
                Command.Parameters["@Descripcion"].Direction = ParameterDirection.Input;
                Command.Parameters["@Descripcion"].Value = descripcion;

                Command.Parameters.Add("@Ruta", DbType.Boolean);
                Command.Parameters["@Ruta"].Direction = ParameterDirection.Input;
                Command.Parameters["@Ruta"].Value = ruta;

                Command.Parameters.Add("@Costo1", DbType.Decimal);
                Command.Parameters["@Costo1"].Direction = ParameterDirection.Input;
                Command.Parameters["@Costo1"].Value = costo1;

                Command.Parameters.Add("@Costo2", DbType.Decimal);
                Command.Parameters["@Costo2"].Direction = ParameterDirection.Input;
                Command.Parameters["@Costo2"].Value = costo2;

                Command.Parameters.Add("@Costo3", DbType.Decimal);
                Command.Parameters["@Costo3"].Direction = ParameterDirection.Input;
                Command.Parameters["@Costo3"].Value = costo3;

                Command.Parameters.Add("@CostoT", DbType.Decimal);
                Command.Parameters["@CostoT"].Direction = ParameterDirection.Input;
                Command.Parameters["@CostoT"].Value = costot;


                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet InsertarProductoAtributoPIRC(int idAtributo, int idProducto, decimal meta, string justificacion)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_CV_PRODUCTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@IdCVAttr", DbType.Int32);
                Command.Parameters["@IdCVAttr"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdCVAttr"].Value = idAtributo;

                Command.Parameters.Add("@IdProducto", DbType.Int32);
                Command.Parameters["@IdProducto"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdProducto"].Value = idProducto;

                Command.Parameters.Add("@MetaTotal", DbType.Decimal);
                Command.Parameters["@MetaTotal"].Direction = ParameterDirection.Input;
                Command.Parameters["@MetaTotal"].Value = meta;

                Command.Parameters.Add("@Justificacion", DbType.String);
                Command.Parameters["@Justificacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@Justificacion"].Value = justificacion;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet InsertarAtributoPIRC(int idSujeto, int idObjetivo, string objetivo, string atributo, int idAtributo)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_CV_ATRIBUTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@IdSujeto", DbType.Int32);
                Command.Parameters["@IdSujeto"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdSujeto"].Value = idSujeto;

                Command.Parameters.Add("@IdObjetivo", DbType.Int32);
                Command.Parameters["@IdObjetivo"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdObjetivo"].Value = idObjetivo;

                Command.Parameters.Add("@Objetivo", DbType.String);
                Command.Parameters["@Objetivo"].Direction = ParameterDirection.Input;
                Command.Parameters["@Objetivo"].Value = objetivo;

                Command.Parameters.Add("@IdAtributo", DbType.Int32);
                Command.Parameters["@IdAtributo"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdAtributo"].Value = idAtributo;

                Command.Parameters.Add("@Atributo", DbType.String);
                Command.Parameters["@Atributo"].Direction = ParameterDirection.Input;
                Command.Parameters["@Atributo"].Value = atributo;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int EliminarActividadesPIRC(int idActividad)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_ACTIVIDADES_PRODUCTOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_CV_ACT", DbType.Int32);
                Command.Parameters["@ID_CV_ACT"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_CV_ACT"].Value = idActividad;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public int EliminarProductosPIRC(int idProducto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_PRODUCTOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_PRODUCTO_CV", DbType.Int32);
                Command.Parameters["@ID_PRODUCTO_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PRODUCTO_CV"].Value = idProducto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public int EliminarInvolucradosPIRC(int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_INVOLUCRADOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public int InsertarInvolucradoPIRC(int idSujeto, int idTipoActor, string tipoActor, string nombreActor, int idRolActor, string rolActor, string interesActor, int idInfluencia, string influencia
            ,string estrategia, string contribucion)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_INVOLUCRADO_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@IdTipoActor", DbType.Int32);
                Command.Parameters["@IdTipoActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdTipoActor"].Value = idTipoActor;

                Command.Parameters.Add("@TipoActor", DbType.String);
                Command.Parameters["@TipoActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@TipoActor"].Value = tipoActor;

                Command.Parameters.Add("@NombreActor", DbType.String);
                Command.Parameters["@NombreActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@NombreActor"].Value = nombreActor;

                Command.Parameters.Add("@IdRolActor", DbType.Int32);
                Command.Parameters["@IdRolActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdRolActor"].Value = idRolActor;

                Command.Parameters.Add("@RolActor", DbType.String);
                Command.Parameters["@RolActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@RolActor"].Value = rolActor;

                Command.Parameters.Add("@InteresActor", DbType.String);
                Command.Parameters["@InteresActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@InteresActor"].Value = interesActor;

                Command.Parameters.Add("@IdInfluencia", DbType.Int32);
                Command.Parameters["@IdInfluencia"].Direction = ParameterDirection.Input;
                Command.Parameters["@IdInfluencia"].Value = idInfluencia;

                Command.Parameters.Add("@Influencia", DbType.String);
                Command.Parameters["@Influencia"].Direction = ParameterDirection.Input;
                Command.Parameters["@Influencia"].Value = influencia;

                Command.Parameters.Add("@EstrategiaActor", DbType.String);
                Command.Parameters["@EstrategiaActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@EstrategiaActor"].Value = estrategia;

                Command.Parameters.Add("@ContribucionActor", DbType.String);
                Command.Parameters["@ContribucionActor"].Direction = ParameterDirection.Input;
                Command.Parameters["@ContribucionActor"].Value = contribucion;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public DataSet ObtenerInvolucradosPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_INVOLUCRADOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int InsertarInvolucradoConcertacionPIRC(int idSujeto, string concertacion)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_INVOLUCRADO_CONCERTACION_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;
                
                Command.Parameters.Add("@Concertacion", DbType.String);
                Command.Parameters["@Concertacion"].Direction = ParameterDirection.Input;
                Command.Parameters["@Concertacion"].Value = concertacion;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public DataSet ObtenerInvolucradosConcertacionPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_INVOLUCRADO_CONCERTACION_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int EliminarRiesgosObjetivoGeneralPIRC(int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_RIESGOS_OBJ_GRAL_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public int EliminarRiesgosProductosPIRC(int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_RIESGOS_PRODUCTOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public int EliminarRiesgosActividadesPIRC(int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_RIESGOS_ACTIVIDADES_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public DataSet ObtenerRiesgosActividadesPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_RIESGOS_ACTIVIDADES_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerRiesgosProductosPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_RIESGOS_PRODUCTOS_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerRiesgosObjGralPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_RIESGOS_OBJ_GRAL_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int InsertarRiesgoActividadPIRC(int idSujeto, int idActividadCV, string actividadCV, string descripcion, int idTipoRiesgo, string tipoRiesgo, int idProbabilidad, string probabilidad
            ,int idImpacto, string impacto, string efecto, string medidas)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_RIESGO_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_ACTIVIDAD_CV", DbType.Int32);
                Command.Parameters["@ID_ACTIVIDAD_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_ACTIVIDAD_CV"].Value = idActividadCV;

                Command.Parameters.Add("@ACTIVIDAD", DbType.String);
                Command.Parameters["@ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@ACTIVIDAD"].Value = actividadCV;

                Command.Parameters.Add("@DESCRIPCION_RIESGO", DbType.String);
                Command.Parameters["@DESCRIPCION_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@DESCRIPCION_RIESGO"].Value = descripcion;

                Command.Parameters.Add("@ID_TIPO_RIESGO", DbType.Int32);
                Command.Parameters["@ID_TIPO_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_TIPO_RIESGO"].Value = idTipoRiesgo;

                Command.Parameters.Add("@TIPO_RIESGO", DbType.String);
                Command.Parameters["@TIPO_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@TIPO_RIESGO"].Value = tipoRiesgo;

                Command.Parameters.Add("@ID_PROBABILIDAD", DbType.Int32);
                Command.Parameters["@ID_PROBABILIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PROBABILIDAD"].Value = idProbabilidad;

                Command.Parameters.Add("@PROBABILIDAD", DbType.String);
                Command.Parameters["@PROBABILIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROBABILIDAD"].Value = probabilidad;

                Command.Parameters.Add("@ID_IMPACTO", DbType.Int32);
                Command.Parameters["@ID_IMPACTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_IMPACTO"].Value = idImpacto;

                Command.Parameters.Add("@IMPACTO", DbType.String);
                Command.Parameters["@IMPACTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@IMPACTO"].Value = impacto;

                Command.Parameters.Add("@EFECTO", DbType.String);
                Command.Parameters["@EFECTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@EFECTO"].Value = efecto;

                Command.Parameters.Add("@MEDIDAS", DbType.String);
                Command.Parameters["@MEDIDAS"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDAS"].Value = medidas;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int InsertarRiesgoProductoPIRC(int idSujeto, int idProductoCV, string productoCV, string descripcion, int idTipoRiesgo, string tipoRiesgo, int idProbabilidad, string probabilidad
            ,int idImpacto, string impacto, string efecto, string medidas)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_RIESGO_PRODUCTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_PRODUCTO_CV", DbType.Int32);
                Command.Parameters["@ID_PRODUCTO_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PRODUCTO_CV"].Value = idProductoCV;

                Command.Parameters.Add("@PRODUCTO", DbType.String);
                Command.Parameters["@PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@PRODUCTO"].Value = productoCV;

                Command.Parameters.Add("@DESCRIPCION_RIESGO", DbType.String);
                Command.Parameters["@DESCRIPCION_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@DESCRIPCION_RIESGO"].Value = descripcion;

                Command.Parameters.Add("@ID_TIPO_RIESGO", DbType.Int32);
                Command.Parameters["@ID_TIPO_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_TIPO_RIESGO"].Value = idTipoRiesgo;

                Command.Parameters.Add("@TIPO_RIESGO", DbType.String);
                Command.Parameters["@TIPO_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@TIPO_RIESGO"].Value = tipoRiesgo;

                Command.Parameters.Add("@ID_PROBABILIDAD", DbType.Int32);
                Command.Parameters["@ID_PROBABILIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PROBABILIDAD"].Value = idProbabilidad;

                Command.Parameters.Add("@PROBABILIDAD", DbType.String);
                Command.Parameters["@PROBABILIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROBABILIDAD"].Value = probabilidad;

                Command.Parameters.Add("@ID_IMPACTO", DbType.Int32);
                Command.Parameters["@ID_IMPACTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_IMPACTO"].Value = idImpacto;

                Command.Parameters.Add("@IMPACTO", DbType.String);
                Command.Parameters["@IMPACTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@IMPACTO"].Value = impacto;

                Command.Parameters.Add("@EFECTO", DbType.String);
                Command.Parameters["@EFECTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@EFECTO"].Value = efecto;

                Command.Parameters.Add("@MEDIDAS", DbType.String);
                Command.Parameters["@MEDIDAS"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDAS"].Value = medidas;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int InsertarRiesgoObjGralPIRC(int idSujeto, string objetivoGral, string descripcion, int idTipoRiesgo, string tipoRiesgo, int idProbabilidad, string probabilidad
            ,int idImpacto, string impacto, string efecto, string medidas)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_RIESGO_OBJ_GRAL", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;
                
                Command.Parameters.Add("@OBJETIVO_GENERAL", DbType.String);
                Command.Parameters["@OBJETIVO_GENERAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@OBJETIVO_GENERAL"].Value = objetivoGral;

                Command.Parameters.Add("@DESCRIPCION_RIESGO", DbType.String);
                Command.Parameters["@DESCRIPCION_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@DESCRIPCION_RIESGO"].Value = descripcion;

                Command.Parameters.Add("@ID_TIPO_RIESGO", DbType.Int32);
                Command.Parameters["@ID_TIPO_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_TIPO_RIESGO"].Value = idTipoRiesgo;

                Command.Parameters.Add("@TIPO_RIESGO", DbType.String);
                Command.Parameters["@TIPO_RIESGO"].Direction = ParameterDirection.Input;
                Command.Parameters["@TIPO_RIESGO"].Value = tipoRiesgo;

                Command.Parameters.Add("@ID_PROBABILIDAD", DbType.Int32);
                Command.Parameters["@ID_PROBABILIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PROBABILIDAD"].Value = idProbabilidad;

                Command.Parameters.Add("@PROBABILIDAD", DbType.String);
                Command.Parameters["@PROBABILIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROBABILIDAD"].Value = probabilidad;

                Command.Parameters.Add("@ID_IMPACTO", DbType.Int32);
                Command.Parameters["@ID_IMPACTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_IMPACTO"].Value = idImpacto;

                Command.Parameters.Add("@IMPACTO", DbType.String);
                Command.Parameters["@IMPACTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@IMPACTO"].Value = impacto;

                Command.Parameters.Add("@EFECTO", DbType.String);
                Command.Parameters["@EFECTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@EFECTO"].Value = efecto;

                Command.Parameters.Add("@MEDIDAS", DbType.String);
                Command.Parameters["@MEDIDAS"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDAS"].Value = medidas;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public DataSet ObtenerIndicadoresSeguimientoProductosPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_IND_SEG_PRODUCTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }
           
        public DataSet ObtenerIndicadoresSeguimientoActividadesPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_IND_SEG_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int InsertarIndicadorSeguimientoActividadPIRC(int idSujeto, int idActividadCV, string actividad, int idIndicador, string indicador, string medido, string descripcion
            ,string medida, decimal costoTotal, decimal costo1, decimal costo2, decimal costo3, decimal anno1, decimal anno2, decimal anno3, int idTipoFuente, string tipoFuente, string fuente)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_IND_SEG_ACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_ACTIVIDAD_CV", DbType.Int32);
                Command.Parameters["@ID_ACTIVIDAD_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_ACTIVIDAD_CV"].Value = idActividadCV;

                Command.Parameters.Add("@ACTIVIDAD", DbType.String);
                Command.Parameters["@ACTIVIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@ACTIVIDAD"].Value = actividad;

                Command.Parameters.Add("@ID_INDICADOR", DbType.Int32);
                Command.Parameters["@ID_INDICADOR"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_INDICADOR"].Value = idIndicador;

                Command.Parameters.Add("@INDICADOR", DbType.String);
                Command.Parameters["@INDICADOR"].Direction = ParameterDirection.Input;
                Command.Parameters["@INDICADOR"].Value = indicador;

                Command.Parameters.Add("@MEDIDO", DbType.String);
                Command.Parameters["@MEDIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDO"].Value = medido;

                Command.Parameters.Add("@DESCRIPCION", DbType.String);
                Command.Parameters["@DESCRIPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@DESCRIPCION"].Value = descripcion;

                Command.Parameters.Add("@MEDIDA", DbType.String);
                Command.Parameters["@MEDIDA"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDA"].Value = medida;

                Command.Parameters.Add("@COSTO_TOTAL", DbType.Decimal);
                Command.Parameters["@COSTO_TOTAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@COSTO_TOTAL"].Value = costoTotal;

                Command.Parameters.Add("@COSTO1", DbType.Decimal);
                Command.Parameters["@COSTO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@COSTO1"].Value = costo1;

                Command.Parameters.Add("@COSTO2", DbType.Decimal);
                Command.Parameters["@COSTO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@COSTO2"].Value = costo2;

                Command.Parameters.Add("@COSTO3", DbType.Decimal);
                Command.Parameters["@COSTO3"].Direction = ParameterDirection.Input;
                Command.Parameters["@COSTO3"].Value = costo3;

                Command.Parameters.Add("@ANNO1", DbType.Decimal);
                Command.Parameters["@ANNO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@ANNO1"].Value = anno1;

                Command.Parameters.Add("@ANNO2", DbType.Decimal);
                Command.Parameters["@ANNO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@ANNO2"].Value = anno2;

                Command.Parameters.Add("@ANNO3", DbType.Decimal);
                Command.Parameters["@ANNO3"].Direction = ParameterDirection.Input;
                Command.Parameters["@ANNO3"].Value = anno3;
                
                Command.Parameters.Add("@ID_TIPO_FUENTE", DbType.Int32);
                Command.Parameters["@ID_TIPO_FUENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_TIPO_FUENTE"].Value = idTipoFuente;

                Command.Parameters.Add("@TIPO_FUENTE", DbType.String);
                Command.Parameters["@TIPO_FUENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@TIPO_FUENTE"].Value = tipoFuente;

                Command.Parameters.Add("@FUENTE", DbType.String);
                Command.Parameters["@FUENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@FUENTE"].Value = fuente;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int InsertarIndicadorSeguimientoProductoPIRC(int idSujeto, int idProductoCV, int idProducto, string producto, string indicador, string medido, string descripcion
            , string medida, decimal metaTotal, decimal costo1, decimal costo2, decimal costo3, decimal anno1, decimal anno2, decimal anno3, int idTipoFuente, string tipoFuente, string fuente)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_IND_SEG_PRODUCTO", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_PRODUCTO", DbType.Int32);
                Command.Parameters["@ID_PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PRODUCTO"].Value = idProducto;

                Command.Parameters.Add("@ID_PRODUCTO_CV", DbType.Int32);
                Command.Parameters["@ID_PRODUCTO_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PRODUCTO_CV"].Value = idProductoCV;

                Command.Parameters.Add("@PRODUCTO", DbType.String);
                Command.Parameters["@PRODUCTO"].Direction = ParameterDirection.Input;
                Command.Parameters["@PRODUCTO"].Value = producto;

                Command.Parameters.Add("@INDICADOR", DbType.String);
                Command.Parameters["@INDICADOR"].Direction = ParameterDirection.Input;
                Command.Parameters["@INDICADOR"].Value = indicador;

                Command.Parameters.Add("@MEDIDO", DbType.String);
                Command.Parameters["@MEDIDO"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDO"].Value = medido;

                Command.Parameters.Add("@DESCRIPCION", DbType.String);
                Command.Parameters["@DESCRIPCION"].Direction = ParameterDirection.Input;
                Command.Parameters["@DESCRIPCION"].Value = descripcion;

                Command.Parameters.Add("@MEDIDA", DbType.String);
                Command.Parameters["@MEDIDA"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDA"].Value = medida;

                Command.Parameters.Add("@META_TOTAL", DbType.Decimal);
                Command.Parameters["@META_TOTAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@META_TOTAL"].Value = metaTotal;

                Command.Parameters.Add("@COSTO1", DbType.Decimal);
                Command.Parameters["@COSTO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@COSTO1"].Value = costo1;

                Command.Parameters.Add("@COSTO2", DbType.Decimal);
                Command.Parameters["@COSTO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@COSTO2"].Value = costo2;

                Command.Parameters.Add("@COSTO3", DbType.Decimal);
                Command.Parameters["@COSTO3"].Direction = ParameterDirection.Input;
                Command.Parameters["@COSTO3"].Value = costo3;

                Command.Parameters.Add("@ANNO1", DbType.Decimal);
                Command.Parameters["@ANNO1"].Direction = ParameterDirection.Input;
                Command.Parameters["@ANNO1"].Value = anno1;

                Command.Parameters.Add("@ANNO2", DbType.Decimal);
                Command.Parameters["@ANNO2"].Direction = ParameterDirection.Input;
                Command.Parameters["@ANNO2"].Value = anno2;

                Command.Parameters.Add("@ANNO3", DbType.Decimal);
                Command.Parameters["@ANNO3"].Direction = ParameterDirection.Input;
                Command.Parameters["@ANNO3"].Value = anno3;

                Command.Parameters.Add("@ID_TIPO_FUENTE", DbType.Int32);
                Command.Parameters["@ID_TIPO_FUENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_TIPO_FUENTE"].Value = idTipoFuente;

                Command.Parameters.Add("@TIPO_FUENTE", DbType.String);
                Command.Parameters["@TIPO_FUENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@TIPO_FUENTE"].Value = tipoFuente;

                Command.Parameters.Add("@FUENTE", DbType.String);
                Command.Parameters["@FUENTE"].Direction = ParameterDirection.Input;
                Command.Parameters["@FUENTE"].Value = fuente;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int EliminarCronogramaTareasActividadesPIRC(int idSujeto)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_ELIMINAR_CRONOGRAMA_TAREAS_ACT", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return val;
        }

        public DataSet ObtenerCronogramaTareasActividadesPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_CRONOGRAMA_TAREAS_ACT", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int InsertarCronogramaTareasActividadesPIRC(int idSujeto, int idActividadCV, string tarea, string responsable
            , bool E1, bool F1, bool M1, bool A1, bool MY1, bool J1, bool JL1, bool AG1, bool S1, bool O1, bool N1, bool D1
            , bool E2, bool F2, bool M2, bool A2, bool MY2, bool J2, bool JL2, bool AG2, bool S2, bool O2, bool N2, bool D2
            , bool E3, bool F3, bool M3, bool A3, bool MY3, bool J3, bool JL3, bool AG3, bool S3, bool O3, bool N3, bool D3
            , DateTime? fechaIni1, DateTime? fechaFin1, DateTime? fechaIni2, DateTime? fechaFin2, DateTime? fechaIni3, DateTime? fechaFin3)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_CRONOGRAMA_TAREA_ACT", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_ACTIVIDAD_CV", DbType.Int32);
                Command.Parameters["@ID_ACTIVIDAD_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_ACTIVIDAD_CV"].Value = idActividadCV;
                
                Command.Parameters.Add("@TAREA", DbType.String);
                Command.Parameters["@TAREA"].Direction = ParameterDirection.Input;
                Command.Parameters["@TAREA"].Value = tarea;

                Command.Parameters.Add("@RESPONSABLE", DbType.String);
                Command.Parameters["@RESPONSABLE"].Direction = ParameterDirection.Input;
                Command.Parameters["@RESPONSABLE"].Value = responsable;

                Command.Parameters.Add("@E1", DbType.Boolean);
                Command.Parameters["@E1"].Direction = ParameterDirection.Input;
                Command.Parameters["@E1"].Value = E1;

                Command.Parameters.Add("@F1", DbType.Boolean);
                Command.Parameters["@F1"].Direction = ParameterDirection.Input;
                Command.Parameters["@F1"].Value = F1;

                Command.Parameters.Add("@M1", DbType.Boolean);
                Command.Parameters["@M1"].Direction = ParameterDirection.Input;
                Command.Parameters["@M1"].Value = M1;

                Command.Parameters.Add("@A1", DbType.Boolean);
                Command.Parameters["@A1"].Direction = ParameterDirection.Input;
                Command.Parameters["@A1"].Value = A1;

                Command.Parameters.Add("@MY1", DbType.Boolean);
                Command.Parameters["@MY1"].Direction = ParameterDirection.Input;
                Command.Parameters["@MY1"].Value = MY1;

                Command.Parameters.Add("@J1", DbType.Boolean);
                Command.Parameters["@J1"].Direction = ParameterDirection.Input;
                Command.Parameters["@J1"].Value = J1;

                Command.Parameters.Add("@JL1", DbType.Boolean);
                Command.Parameters["@JL1"].Direction = ParameterDirection.Input;
                Command.Parameters["@JL1"].Value = JL1;

                Command.Parameters.Add("@AG1", DbType.Boolean);
                Command.Parameters["@AG1"].Direction = ParameterDirection.Input;
                Command.Parameters["@AG1"].Value = AG1;

                Command.Parameters.Add("@S1", DbType.Boolean);
                Command.Parameters["@S1"].Direction = ParameterDirection.Input;
                Command.Parameters["@S1"].Value = S1;

                Command.Parameters.Add("@O1", DbType.Boolean);
                Command.Parameters["@O1"].Direction = ParameterDirection.Input;
                Command.Parameters["@O1"].Value = O1;

                Command.Parameters.Add("@N1", DbType.Boolean);
                Command.Parameters["@N1"].Direction = ParameterDirection.Input;
                Command.Parameters["@N1"].Value = N1;

                Command.Parameters.Add("@D1", DbType.Boolean);
                Command.Parameters["@D1"].Direction = ParameterDirection.Input;
                Command.Parameters["@D1"].Value = D1;

                Command.Parameters.Add("@E2", DbType.Boolean);
                Command.Parameters["@E2"].Direction = ParameterDirection.Input;
                Command.Parameters["@E2"].Value = E2;

                Command.Parameters.Add("@F2", DbType.Boolean);
                Command.Parameters["@F2"].Direction = ParameterDirection.Input;
                Command.Parameters["@F2"].Value = F2;

                Command.Parameters.Add("@M2", DbType.Boolean);
                Command.Parameters["@M2"].Direction = ParameterDirection.Input;
                Command.Parameters["@M2"].Value = M2;

                Command.Parameters.Add("@A2", DbType.Boolean);
                Command.Parameters["@A2"].Direction = ParameterDirection.Input;
                Command.Parameters["@A2"].Value = A2;

                Command.Parameters.Add("@MY2", DbType.Boolean);
                Command.Parameters["@MY2"].Direction = ParameterDirection.Input;
                Command.Parameters["@MY2"].Value = MY2;

                Command.Parameters.Add("@J2", DbType.Boolean);
                Command.Parameters["@J2"].Direction = ParameterDirection.Input;
                Command.Parameters["@J2"].Value = J2;

                Command.Parameters.Add("@JL2", DbType.Boolean);
                Command.Parameters["@JL2"].Direction = ParameterDirection.Input;
                Command.Parameters["@JL2"].Value = JL2;

                Command.Parameters.Add("@AG2", DbType.Boolean);
                Command.Parameters["@AG2"].Direction = ParameterDirection.Input;
                Command.Parameters["@AG2"].Value = AG2;

                Command.Parameters.Add("@S2", DbType.Boolean);
                Command.Parameters["@S2"].Direction = ParameterDirection.Input;
                Command.Parameters["@S2"].Value = S2;

                Command.Parameters.Add("@O2", DbType.Boolean);
                Command.Parameters["@O2"].Direction = ParameterDirection.Input;
                Command.Parameters["@O2"].Value = O2;

                Command.Parameters.Add("@N2", DbType.Boolean);
                Command.Parameters["@N2"].Direction = ParameterDirection.Input;
                Command.Parameters["@N2"].Value = N2;

                Command.Parameters.Add("@D2", DbType.Boolean);
                Command.Parameters["@D2"].Direction = ParameterDirection.Input;
                Command.Parameters["@D2"].Value = D2;

                Command.Parameters.Add("@E3", DbType.Boolean);
                Command.Parameters["@E3"].Direction = ParameterDirection.Input;
                Command.Parameters["@E3"].Value = E3;

                Command.Parameters.Add("@F3", DbType.Boolean);
                Command.Parameters["@F3"].Direction = ParameterDirection.Input;
                Command.Parameters["@F3"].Value = F3;

                Command.Parameters.Add("@M3", DbType.Boolean);
                Command.Parameters["@M3"].Direction = ParameterDirection.Input;
                Command.Parameters["@M3"].Value = M3;

                Command.Parameters.Add("@A3", DbType.Boolean);
                Command.Parameters["@A3"].Direction = ParameterDirection.Input;
                Command.Parameters["@A3"].Value = A3;

                Command.Parameters.Add("@MY3", DbType.Boolean);
                Command.Parameters["@MY3"].Direction = ParameterDirection.Input;
                Command.Parameters["@MY3"].Value = MY3;

                Command.Parameters.Add("@J3", DbType.Boolean);
                Command.Parameters["@J3"].Direction = ParameterDirection.Input;
                Command.Parameters["@J3"].Value = J3;

                Command.Parameters.Add("@JL3", DbType.Boolean);
                Command.Parameters["@JL3"].Direction = ParameterDirection.Input;
                Command.Parameters["@JL3"].Value = JL3;

                Command.Parameters.Add("@AG3", DbType.Boolean);
                Command.Parameters["@AG3"].Direction = ParameterDirection.Input;
                Command.Parameters["@AG3"].Value = AG3;

                Command.Parameters.Add("@S3", DbType.Boolean);
                Command.Parameters["@S3"].Direction = ParameterDirection.Input;
                Command.Parameters["@S3"].Value = S3;

                Command.Parameters.Add("@O3", DbType.Boolean);
                Command.Parameters["@O3"].Direction = ParameterDirection.Input;
                Command.Parameters["@O3"].Value = O3;

                Command.Parameters.Add("@N3", DbType.Boolean);
                Command.Parameters["@N3"].Direction = ParameterDirection.Input;
                Command.Parameters["@N3"].Value = N3;

                Command.Parameters.Add("@D3", DbType.Boolean);
                Command.Parameters["@D3"].Direction = ParameterDirection.Input;
                Command.Parameters["@D3"].Value = D3;

                Command.Parameters.Add("@FECHAINI1", DbType.Date);
                Command.Parameters["@FECHAINI1"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHAINI1"].Value = fechaIni1;

                Command.Parameters.Add("@FECHAFIN1", DbType.Date);
                Command.Parameters["@FECHAFIN1"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHAFIN1"].Value = fechaFin1;

                Command.Parameters.Add("@FECHAINI2", DbType.Date);
                Command.Parameters["@FECHAINI2"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHAINI2"].Value = fechaIni2;

                Command.Parameters.Add("@FECHAFIN2", DbType.Date);
                Command.Parameters["@FECHAFIN2"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHAFIN2"].Value = fechaFin2;

                Command.Parameters.Add("@FECHAINI3", DbType.Date);
                Command.Parameters["@FECHAINI3"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHAINI3"].Value = fechaIni3;

                Command.Parameters.Add("@FECHAFIN3", DbType.Date);
                Command.Parameters["@FECHAFIN3"].Direction = ParameterDirection.Input;
                Command.Parameters["@FECHAFIN3"].Value = fechaFin3;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int InsertarResumenActividadPIRC(int idSujeto, int idActividadCV, string supuestos)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_RESUMEN_ACTIVIDADES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_ACTIVIDAD_CV", DbType.Int32);
                Command.Parameters["@ID_ACTIVIDAD_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_ACTIVIDAD_CV"].Value = idActividadCV;

                Command.Parameters.Add("@SUPUESTOS", DbType.String);
                Command.Parameters["@SUPUESTOS"].Direction = ParameterDirection.Input;
                Command.Parameters["@SUPUESTOS"].Value = supuestos;
                
                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public int InsertarResumenProductoPIRC(int idSujeto, int idProductoCV, string supuestos)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_INSERTAR_RESUMEN_PRODUCTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@ID_PRODUCTO_CV", DbType.Int32);
                Command.Parameters["@ID_PRODUCTO_CV"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_PRODUCTO_CV"].Value = idProductoCV;

                Command.Parameters.Add("@SUPUESTOS", DbType.String);
                Command.Parameters["@SUPUESTOS"].Direction = ParameterDirection.Input;
                Command.Parameters["@SUPUESTOS"].Value = supuestos;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public DataSet ObtenerResumenActividadesPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_RESUMEN_ACTIVIDADES", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerResumenProductosPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_RESUMEN_PRODUCTOS", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public int InsertarDatosPDFPIRC(int idSujeto, string problema, string objetivo, string poblacion, string localizacion, string aspEstrategico, string aspTecnico
            , string aspFinan, string aspSost, string aspPol, string implicaciones, string beneficios, string profRC, string profPsico, string profSatis, string profRehab
            , string profGaran, string profRestit, string profRevTecnica, string aspSoc, string aspLegal)
        {
            int val = 0;

            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.INSERTAR_DATOS_PDF_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                Command.Parameters.Add("@IDENT_PROBLEMA", DbType.String);
                Command.Parameters["@IDENT_PROBLEMA"].Direction = ParameterDirection.Input;
                Command.Parameters["@IDENT_PROBLEMA"].Value = problema;

                Command.Parameters.Add("@IDENT_OBJETIVOS", DbType.String);
                Command.Parameters["@IDENT_OBJETIVOS"].Direction = ParameterDirection.Input;
                Command.Parameters["@IDENT_OBJETIVOS"].Value = objetivo;

                Command.Parameters.Add("@POBLACION_AFECT_OBJ", DbType.String);
                Command.Parameters["@POBLACION_AFECT_OBJ"].Direction = ParameterDirection.Input;
                Command.Parameters["@POBLACION_AFECT_OBJ"].Value = poblacion;

                Command.Parameters.Add("@LOCALIZACION", DbType.String);
                Command.Parameters["@LOCALIZACION"].Direction = ParameterDirection.Input;
                Command.Parameters["@LOCALIZACION"].Value = localizacion;

                Command.Parameters.Add("@ASPECTO_ESTRATEG", DbType.String);
                Command.Parameters["@ASPECTO_ESTRATEG"].Direction = ParameterDirection.Input;
                Command.Parameters["@ASPECTO_ESTRATEG"].Value = aspEstrategico;

                Command.Parameters.Add("@ASPECTO_TECNICO", DbType.String);
                Command.Parameters["@ASPECTO_TECNICO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ASPECTO_TECNICO"].Value = aspTecnico;

                Command.Parameters.Add("@ASPECTO_FINANCIERO", DbType.String);
                Command.Parameters["@ASPECTO_FINANCIERO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ASPECTO_FINANCIERO"].Value = aspFinan;

                Command.Parameters.Add("@ASPECTO_SOSTENIBILIDAD", DbType.String);
                Command.Parameters["@ASPECTO_SOSTENIBILIDAD"].Direction = ParameterDirection.Input;
                Command.Parameters["@ASPECTO_SOSTENIBILIDAD"].Value = aspSost;

                Command.Parameters.Add("@ASPECTO_POLITICO", DbType.String);
                Command.Parameters["@ASPECTO_POLITICO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ASPECTO_POLITICO"].Value = aspPol;

                Command.Parameters.Add("@IMPLICAC_INSTITUCIONALES", DbType.String);
                Command.Parameters["@IMPLICAC_INSTITUCIONALES"].Direction = ParameterDirection.Input;
                Command.Parameters["@IMPLICAC_INSTITUCIONALES"].Value = implicaciones;

                Command.Parameters.Add("@BENEFICIOS_PIRC", DbType.String);
                Command.Parameters["@BENEFICIOS_PIRC"].Direction = ParameterDirection.Input;
                Command.Parameters["@BENEFICIOS_PIRC"].Value = beneficios;

                Command.Parameters.Add("@PROF_PIRC_RC", DbType.String);
                Command.Parameters["@PROF_PIRC_RC"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROF_PIRC_RC"].Value = profRC;

                Command.Parameters.Add("@PROF_PIRC_PSICO", DbType.String);
                Command.Parameters["@PROF_PIRC_PSICO"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROF_PIRC_PSICO"].Value = profPsico;

                Command.Parameters.Add("@PROF_PIRC_SATISF", DbType.String);
                Command.Parameters["@PROF_PIRC_SATISF"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROF_PIRC_SATISF"].Value = profSatis;

                Command.Parameters.Add("@PROF_PIRC_REHAB", DbType.String);
                Command.Parameters["@PROF_PIRC_REHAB"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROF_PIRC_REHAB"].Value = profRehab;

                Command.Parameters.Add("@PROF_PIRC_GARAN", DbType.String);
                Command.Parameters["@PROF_PIRC_GARAN"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROF_PIRC_GARAN"].Value = profGaran;

                Command.Parameters.Add("@PROF_PIRC_RESTIT", DbType.String);
                Command.Parameters["@PROF_PIRC_RESTIT"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROF_PIRC_RESTIT"].Value = profRestit;

                Command.Parameters.Add("@PROF_REV_TECNICA", DbType.String);
                Command.Parameters["@PROF_REV_TECNICA"].Direction = ParameterDirection.Input;
                Command.Parameters["@PROF_REV_TECNICA"].Value = profRevTecnica;

                Command.Parameters.Add("@ASPECTO_SOCIAL", DbType.String);
                Command.Parameters["@ASPECTO_SOCIAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@ASPECTO_SOCIAL"].Value = aspSoc;

                Command.Parameters.Add("@ASPECTO_LEGAL", DbType.String);
                Command.Parameters["@ASPECTO_LEGAL"].Direction = ParameterDirection.Input;
                Command.Parameters["@ASPECTO_LEGAL"].Value = aspLegal;

                val = Command.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.Message.ToLower().Contains("unique"))
                    {
                        val = 3;
                    }
                }
            }

            return val;
        }

        public DataSet ObtenerDatosPDFPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.OBTENER_DATOS_PDF_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerDatosSujetoPIRC(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.OBTENER_DATOS_SUJETO_PIRC", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }


        // Reportes
        public DataSet ListaMedidasProductos()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_OBTENER_MEDIDASPRODUCTOS", con);
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

        public DataSet ObtenerDatosReporteProductosMedida(string medida, int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_REPORTE_PRODUCTOSMEDIDA", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@MEDIDA", DbType.String);
                Command.Parameters["@MEDIDA"].Direction = ParameterDirection.Input;
                Command.Parameters["@MEDIDA"].Value = medida;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }

        public DataSet ObtenerDatosReporteCostoTipoActividad(int idSujeto)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;
                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["DbConnecitionString"]);
                con.Open();

                SqlCommand Command = new SqlCommand("MGA.SP_REPORTE_COSTOTIPOACTIVIDAD", con);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = con;

                Command.Parameters.Add("@ID_SUJETO", DbType.Int32);
                Command.Parameters["@ID_SUJETO"].Direction = ParameterDirection.Input;
                Command.Parameters["@ID_SUJETO"].Value = idSujeto;

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                con.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
            }

            return ds;
        }
    }
}