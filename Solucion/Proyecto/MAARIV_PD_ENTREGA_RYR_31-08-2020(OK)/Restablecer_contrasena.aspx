<%@ Page Language="C#" MasterPageFile="~/MasterPagePortal.master" AutoEventWireup="true" CodeFile="Restablecer_contrasena.aspx.cs" Inherits="Restablecer_contrasena" Title="MAARIV" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div >
        <asp:ScriptManager ID="ScriptManager1"
            runat="server">
        </asp:ScriptManager>

        <asp:Panel ID="Panel0" runat="server">

            <%--<asp:Panel ID="Panel3" runat="server" Visible="true">
                <br />
                <br />
                <br />
            </asp:Panel>
            <table align="center" 
                class="Menu_ingreso">
                <tr class="centrado">
                    <h4 style ="color:#c23636">Restablecer contraseña</h4>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: 20px">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Presentacion.aspx">Volver al inicio</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px; width: 100px;" class="textoIzq">Identificación</td>
                    <td class="textoIzq">
                        <asp:TextBox ID="TextBoxUsuario" runat="server" Width="150px" CssClass="form-control" Height="22px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px; width: 100px;" class="textoIzq">Email</td>
                    <td style="width: 142px;" class="textoIzq">
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="151px" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: 40px;">
                        <br />
                        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar"
                            Height="26px" CssClass="boton" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar"
            Height="25px" CssClass="boton" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; height: 30px">
                        <asp:Label ID="LabelMensaje" runat="server" Style="color: #FF0000"></asp:Label>
                    </td>
                </tr>
            </table>--%> 


                <div class="panel-heading">
                    <strong>Restablecer contraseña</strong>
                </div>
                <div class="panel-body">
                    <div class="col-sm-12">
                        <span class="input-group-label icon i-user"></span>
                        <asp:TextBox ID="TextBoxUsuario" runat="server" class="form-control"  placeholder="Número identificación"></asp:TextBox>
                    </div>

                    <div class="col-sm-12">
                        <span class="input-group-label icon i-mail"></span>
                        <asp:TextBox ID="TextBoxEmail" runat="server"
                             class="form-control" placeholder="Email registro"></asp:TextBox>
                    </div>
                    <div class="col-md-12"><br /></div>
                    <div class="col-sm-12" >
                        <asp:Button ID="btnAceptar" Style="margin-right:10px;width:200px;"  runat="server" class="btn btn-success" OnClick="btnAceptar_Click" Text="Aceptar" ValidationGroup="Restablecer_pswd"/>
                   </div>
                    <div class="col-sm-12" >
                        <asp:Button ID="btnCancelar" Style="margin-right:10px;width:200px;" runat="server" class="btn btn-warning" OnClick="btnCancelar_Click" Text="Cancelar" />
                    </div>
                    <br />
                    <br />
                       
                    <div class="col-sm-12" style="margin-top: 9%;">
                        <asp:RequiredFieldValidator ID="ValidatorUsu" runat="server" ControlToValidate="TextBoxUsuario" CssClass="validador" Display="Dynamic" Font-Bold="False" Style="font-family: Arial" ValidationGroup="Restablecer_pswd">
                            <div class="alert alert-info alert-dismissible" role="alert">
                                <strong>Digite el número de identificación</strong>
                            </div>
                        </asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="LabelMensaje" runat="server" Style="color: #FF0000"></asp:Label>
                </div>

        </asp:Panel>
        <br />
    </div>
</asp:Content>
