/*
 *******************************************************************************************
  PROGRAMA				: Buscador.cs
  FECHA DE CREACION	    : 03-09-2019
  FECHA DE MODIFICACION : 
  VERSION               : 1.1
  AUTOR                 : Alejandro Moreno
 *******************************************************************************************

  CLASE			        : Buscador.cs
  RESPONSABILIDAD	    : 
  COLABORACION		    : Brayan Herreño
 
********************************************************************************************
*/


namespace com.logica.Buscador
{


    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Descripción breve de Buscador
    /// </summary>
    public class Buscador
    {
        public Buscador()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public DataTable Buscar(string searchTerm, DataTable dt, int colums_search_0, int colums_search_1, int colums_search_2)
        {
            //check if the search input is at least 3 chars
            if (searchTerm.Length >= 1)
            {
                if (dt != null)
                {
                    // Do what you need to do with the data table.
                    //make a clone of the datatable
                    DataTable dtNew = dt.Clone();

                    //search the datatable for the correct fields
                    foreach (DataRow row in dt.Rows)
                    {
                        //add your own columns to be searched here
                        if (row[colums_search_0].ToString().ToLower().Contains(searchTerm) ||
                            row[colums_search_1].ToString().ToLower().Contains(searchTerm) ||
                            row[colums_search_2].ToString().ToLower().Contains(searchTerm))
                        {
                            //when found copy the row to the cloned table
                            dtNew.Rows.Add(row.ItemArray);
                        }
                    }
                    return dtNew;
                }
            }
            return dt;
        }

        public DataTable Buscar2(string searchTerm, DataTable dt, int colums_search_0, int colums_search_1, int colums_search_2, int colums_search_3)
        {
            //check if the search input is at least 3 chars
            if (searchTerm.Length >= 1)
            {
                if (dt != null)
                {
                    // Do what you need to do with the data table.
                    //make a clone of the datatable
                    DataTable dtNew = dt.Clone();

                    //search the datatable for the correct fields
                    foreach (DataRow row in dt.Rows)
                    {
                        //add your own columns to be searched here
                        if (row[colums_search_0].ToString().ToLower().Contains(searchTerm) ||
                            row[colums_search_1].ToString().ToLower().Contains(searchTerm) ||
                            row[colums_search_2].ToString().ToLower().Contains(searchTerm) ||
                            row[colums_search_3].ToString().ToLower().Contains(searchTerm))
                        {
                            //when found copy the row to the cloned table
                            dtNew.Rows.Add(row.ItemArray);
                        }
                    }
                    return dtNew;
                }
            }
            return dt;
        }
    }
}