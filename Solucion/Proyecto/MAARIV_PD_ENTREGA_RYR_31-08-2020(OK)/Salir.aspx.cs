using com.GACV.lgb.modelo.usuario;
using com.GACV.lgb.persistencia.fachada;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();
        DataSet ds = null;
        usuario.P_usuario_creacion = Convert.ToString(Session["id_usuario"]);
        usuario.F_Nombre = ip_mac();
        usuario.F_TIPO_USUARIO = Convert.ToInt32(Session["rol"]);
        usuario.P_ID_AUDITORIA = Convert.ToString(Session["ID_AUDITORIA"]);

        // permite realizar el seguimiento de cuando entra un usuario a la aplicacion
        FachadaPersistencia.getInstancia().administrar_usuario_ds(usuario, 19);

        usuario.Apellidos = "Exitoso";
        usuario.Email = "Salida Correcta";
        usuario.F_id_persona = 1; //id_estado
        usuario.F_TIPO_USUARIO = 1;  //id_tipo_bloqueo
        usuario.Login = Convert.ToString(Session["login"]);
        FachadaPersistencia.getInstancia().administrar_sesiones(usuario, 1); //registrar error sesion 

        Session.Abandon();
        FormsAuthentication.SignOut(); // permite eliminar la cache del usuario

        Response.Redirect("~/Presentacion.aspx");
    }

    public string ip_mac()
    {
        // ManagementClass objMC;
        // ManagementObjectCollection objMOC;
        /* string[] ipaddresses;   // direccion ip
         string[] subnets;       // mascara
         string[] gateways;      // puerta de enlace
         string[] dns;           // dns
         string hostname;        // nombre del host
         string mac_address;     // direccion mac*/
        string ip;
        // int i = 0;

        //  objMC = new ManagementClass("Win32_NetworkAdapterConfiguration"); 
        //  objMOC = objMC.GetInstances();

        ip = Request.ServerVariables.Get("REMOTE_ADDR");
        /* ip = Request.UserHostAddress;
           
         foreach(ManagementObject objMO in objMOC) 
         {
             if (!(bool)objMO["ipEnabled"])
             {
                 continue;
             }
             else
             {
                 i = i + 1; // i = nº de NICs                
                 ipaddresses = (string[])objMO["IPAddress"];
                 subnets = (string[])objMO["IPSubnet"];
                 gateways = (string[])objMO["DefaultIPGateway"];
                 dns = (string[])objMO["DNSServerSearchOrder"];
                 hostname = (String)objMO["DNSHostName"];
                 mac_address = (string)objMO["MacAddress"];
             }
         }       
            
         */
        return ip;
    }
}