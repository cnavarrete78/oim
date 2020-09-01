<%@ Page Title="MAARIV" Language="C#" MasterPageFile="~/MasterPagePortal.master" AutoEventWireup="true" CodeFile="Presentacion.aspx.cs" Inherits="Presentacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Panel ID="Panel_formulario" runat="server">
        <asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="server">
            
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
   

                <asp:Panel ID="Panel0" runat="server">
                     

                    <div class="panel-heading">
                        <strong>Inicio de sesión</strong>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:TextBox ID="TextBoxUsuario" runat="server" class="form-control" placeholder="Nombre de usuario" OnTextChanged="TextBoxUsuario_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-sm-12">
                                <asp:TextBox ID="TextBoxPassword" runat="server"
                                    class="form-control" type="password" placeholder="Contraseña"></asp:TextBox>
                            </div>
                            <div class="col-sm-12">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Restablecer_contrasena.aspx">¿Olvido su contraseña?</asp:HyperLink>
                            </div>
                            <div class="col-sm-12" >
                                <asp:Button ID="Ingreso" runat="server" class="btn btn-success" Style="margin-right:10px;width:200px;" Text="Iniciar sesión" OnClick="Button2_Click" ValidationGroup="LoginGroup" />
                            </div>
                            <!--div class="colsm-12">
                                <div style="margin-right:10px;width:200px;margin-left:15px;" class="btn btn-info">
                                    <a href="/Modulos/Cys/basic/index.html" target="_blank" style="color:white;">Capacitación</a>
                                </div>
                            </div-->
                            <div class="col-sm-12" style="margin-top: 9%;">
                                <asp:RequiredFieldValidator ID="ValidatorUsu" runat="server" ControlToValidate="TextBoxUsuario" CssClass="validador" Display="Dynamic" Font-Bold="False" Style="font-family: Arial" ValidationGroup="LoginGroup">
                                    <div class="alert alert-info alert-dismissible" role="alert">
                                    <strong>Digite el usario</strong>
                                </div></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="ValidatorPass" runat="server" ControlToValidate="TextBoxPassword" CssClass="validador" Display="Dynamic" Font-Bold="False" Style="font-family: Arial" ValidationGroup="LoginGroup">
                                    <div class="alert alert-info alert-dismissible" role="alert">
                                    <strong>Digite la contraseña.</strong>
                                </div></asp:RequiredFieldValidator>
                                     
                            </div>
                            
                        </div>
                    </div>
                    <div class="panel-footer" style="background: white;">
                        <span>V 41.0 - 20200831PD.NI</span> <br><span class="glyphicon glyphicon-envelope" style="color:#6b82eb"></span> controlseguimientodr@unidadvictimas.gov.co
                    </div>

                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Visible="False" >

                    <div class="panel-heading">
                        <strong>Seleccione un perfil</strong>
                    </div>
                    <div class="input-box" >
                        <div style="overflow-y:scroll;height:200px;">
                            <asp:RadioButtonList ID="RadioButtonList1" RepeatLayout="Flow" Font-Size="Small" runat="server" CssClass="radio">
                            </asp:RadioButtonList>
                        </div>
                        
                        <br />
                        <br />
                        <div class="col-sm-12" >
                            <asp:Button ID="Ingreso_continuar" class="btn btn-success" Style="margin-right:10px;width:200px;" runat="server" OnClick="Continuar_Click" Text="Continuar" />
                        </div>
                        <div class="col-sm-12" >
                            <asp:Button ID="Cancelar" class="btn btn-warning" runat="server" Style="margin-right:10px;width:200px;" OnClick="Cancelar_Click" Text="Cancelar" />
                        </div>

                        
                        <br />
                    </div>
                </asp:Panel>
                <style>
                    .input-box{
                        background: #e1ecfc;
                    }
                    .checkbox input[type=checkbox], .checkbox-inline input[type=checkbox], .radio input[type=radio], .radio-inline input[type=radio]{
                        margin-left: 0px !important;
                    }
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(2),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(4),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(6),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(8),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(10),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(12),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(14),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(16),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(18),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(20),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(22),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(24),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(26),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(28),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(30),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(32),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(34),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(36),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(38),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(40),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(42),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(46),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(48),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(50),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(52),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(54),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(56),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(58),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(60),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(62),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(64),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(66),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(68),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(70),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(72),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(74),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(78),
                    #ContentPlaceHolder1_RadioButtonList1 > label:nth-child(80){
                        background:white;
                        color:black;
                    }
                    .modal-body {
                        margin: 10px;
                    }
                </style>
                <div id="cerrar">
                    <div class="modal fade" visible="false" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div style="background:black;width:100%;height:100%;position:absolute;top:0px;left:0px;opacity:0.5"></div>
                    <div class="modal-dialog">
                        <%--<asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                                <div class="modal-content" style="margin:10px;">
                                    <asp:Label ID="L_V2" runat="server" Visible="false" Text="0"></asp:Label>

                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                    <div class="modal-body text-justify row">
                                        <asp:Label ID="lblModalBody" CssClass="text-justify" runat="server" Text=""></asp:Label>
                                        <%--<asp:Panel ID="iframePanel" runat="server"></asp:Panel>--%>
                                    </div>
                                    <div class="modal-body text-center">
                                        <asp:CheckBox ID="CB_Valida_accion" Visible="false" CssClass="text-warning" runat="server" Text="Aceptar"></asp:CheckBox>
                                        <asp:GridView ID="gv_modal" runat="server" ></asp:GridView>
                                        <asp:TextBox ID="TextBoxCorreoAlternativo" runat="server" CssClass="texto" Visible ="false" onkeypress="myfuncion(event)" ></asp:TextBox>
                                        <script>
                                            function myfuncion(e){
                                                if (e.keyCode == 13) {
                                                    e.preventDefault();
                                                    return false;
                                                }
                                            }
                                        </script>
                                        <br /><center><br><asp:Label ID="error_segunda" Visible="false" runat="server" CssClass="error_seg">Codigo Incorrecto</asp:Label></center>
                                                    <style>
                                                        .error_seg {
                                                            color: red;
                                                            font-size: 20px;
                                                        }
                                                        .texto, .form-control {
                                                            width: 80%;
                                                        }

                                                        .texto {
                                                            border-radius: 10px 10px 10px 10px;
                                                            -moz-border-radius: 10px 10px 10px 10px;
                                                            -webkit-border-radius: 10px 10px 10px 10px;
                                                            border: 1px solid #5bc0de;
                                                            padding: 10px;
                                                        }

                                                            .texto:focus, .texto:hover {
                                                                border: 1px solid #30778e;
                                                                -webkit-box-shadow: 0px 0px 5px 0px rgba(48,119,142,1);
                                                                -moz-box-shadow: 0px 0px 5px 0px rgba(48,119,142,1);
                                                                box-shadow: 0px 0px 5px 0px rgba(48,119,142,1);
                                                            }
                                                            .header-box a{
                                                                    width: 31%;
                                                            }
                                                            .modal-dialog {
                                                                    width: 68%;
                                                            }
                                                            
                                        </style>
                                    </div>
                                    <div class="modal-footer">
                                        <div id="cerrar_modal" runat="server" onclick="cerrar_modal()" class="btn btn-info" data-dismiss="modal" aria-hidden="true">cerrar</div>
                                        <asp:Label ID="L_V1" runat="server" Visible="false" Text=""></asp:Label>
                                        
                                        <asp:Label ID="L_V3" runat="server" Visible="false" Text=""></asp:Label>
                                        <asp:Label ID="L_Validacion" runat="server" Visible="false" Text=""></asp:Label>
                                        <asp:Button ID="B_12" runat="server" CssClass="btn btn-success" Visible="false" Text="Continuar"  AutoPostBack="true"/>
                                        <asp:Button ID="B_13" runat="server" CssClass="btn btn-info" Visible="false" Text="Validar Codigo" AutoPostBack="true" OnClick="B_13_Click"/>
                                    </div>
                                </div>
                           <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
                </div>



                
                

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="L_mensaje" Text="" Visible="false" />


    </asp:Panel>
</asp:Content>



