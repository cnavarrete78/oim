/*
 **********************************************************************************************
  PROGRAMA				: MasterPagePortal.cs
  FECHA DE CREACION	    : Mayo 29 de 2010
  FECHA DE MODIFICACION : Mayo 29 de 2010
  VERSION               : 1.0
  AUTOR                 : Gustavo Adolfo Caicedo Viveros

 ***********************************************************************************************

  CLASE			        : MasterPagePortal
  RESPONSABILIDAD	    : Se encarga de colocar un formato de presentacion a la aplicacion
  COLABORACION		    : 
************************************************************************************************
*/

using System;

public partial class MasterPagePortal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Presentacion.aspx");
    }
}
