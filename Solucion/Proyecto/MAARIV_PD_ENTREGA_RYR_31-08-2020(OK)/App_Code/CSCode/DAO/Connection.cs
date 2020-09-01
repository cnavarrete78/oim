using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace conexion
{

    /// <summary>
    /// Summary description for Connection
    /// </summary>
    public class Connection
    {
        /** Conexion con la BD */
        private SqlConnection ObjConexion;
        /** Enlace con la DB */
        private SqlDataAdapter ObjAdapter;
        /** CommandBuilder para encapsular enlace a DB */
        private SqlCommandBuilder SqlBuider;

        public Connection()
        {
            //Inicilizar componentes
            ObjConexion = new SqlConnection();
            //Adaptador
            ObjAdapter = new SqlDataAdapter();
            //Sql
            SqlBuider = new SqlCommandBuilder(ObjAdapter);
        }

        public void Connectar(bool NTUSER = false)
        {
            //Conexion
            if (NTUSER == false)
            {
                ObjConexion.ConnectionString = ConfigurationManager.AppSettings["DbConnecitionString"];
            }
            else
            {
                ObjConexion.ConnectionString = ConfigurationManager.AppSettings["DbConnecitionStringNTUSER"];

            }
        }

        public DataTable ExecuteSql(string SQLSENTENCE, bool NTUSER = false)
        {
            //Declaración de variables requeridas
            SqlCommand SQLcmd = new SqlCommand();
            DataTable dttTemp = new DataTable();

            // obtener la cadena de conexion con el servidor BD
            if (NTUSER == false)
            {
                Connectar();
            }
            else
            {
                Connectar(NTUSER);
            }

            //Asignación de propiedades
            SQLcmd.Connection = ObjConexion;
            SQLcmd.CommandType = CommandType.Text;
            // Llamar sql - SPR_XXXXX
            SQLcmd.CommandText = SQLSENTENCE;

            // Ejecutar la consulta
            ObjAdapter.SelectCommand = SQLcmd;

            //Intento de llenado de datos hacia la variable dt DataTable
            try
            {
                // rellenar la tabla con los datos de la consulta
                ObjAdapter.Fill(dttTemp);
            }
            catch (SqlException ex)
            {
                // mostrar error
                //MessageBox.Show(ex.Message);
                dttTemp = null;
            }
            catch (Exception ex)
            {
                // mostrar error
                //MessageBox.Show(ex.Message);
                dttTemp = null;
            }

            ObjConexion.Close();

            return dttTemp;
        }
    }

}