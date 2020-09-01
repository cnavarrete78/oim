<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inicio_perfil.aspx.cs" Inherits="Inicio_Perfil_Usuario" Title="MAARIV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    

    <div class="row">
        <div ID="Panel_principal" runat="server"></div>
        <button type="button" id="boton_actualizar" style="display:none;" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#actualizacionModal">
          Actualización de Datos
        </button>
        <asp:Panel Visible="true" runat="server" ID="actualizacion_usuario">
        
            <!-- Modal -->
            <div class="modal fade" id="actualizacionModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div style="position:absolute;top:0px;left:0px; background:black;width:100%;height:800px;opacity:0.8;"></div>
              <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    
                    <h4 class="modal-title" id="myModalLabel">Información Obligatoria</h4>
                  </div>
                  <div class="modal-body">
                    <iframe style="width:100%;height:300px" src="Modulos/Seguridad/Datos_usuarios_ext.aspx"></iframe>
                  </div>
                  <div class="modal-footer">
                  <p id="mensaje_datos" runat="server"></p>
                      <a href="Inicio_perfil.aspx" class="btn btn-success">Confirmar</a>
                  </div>
                </div>
              </div>
            </div>
                    
        </asp:Panel>
    </div>


        <center>
        
                <div class="footer">
                </div>
                <!-- The overlay and the box -->
            <!--cambio ALEJANDRO 30-agosto-2018-->
            <asp:Panel ID="tooltips" runat="server" Visible="true" >
                <div class="overlay1" id="overlay1" style="display: block;"></div>
                <div class="box" id="box" style="top: 2%" runat="server" visible="true" >
                   
                    <asp:DropDownList ID="Ususario_Crea" runat="server" CssClass="form-control" Enabled="False" Visible="False">
                        
                    </asp:DropDownList>
                                        
                    <asp:GridView UseAccessibleHeader="true" GridLines="None" AlternatingRowStyle-CssClass="alt"
                        CssClass="mGrid_bienvenida" PagerStyle-CssClass="pgr" ID="gv" OnRowDataBound="gv_RowDataBound" OnRowCommand="gv_actividad_RowComman" runat="server" AutoGenerateColumns="False" CellPadding="4" style="text-align: left; color: #ffffff;"
                        BorderColor="White" ForeColor="Maroon" ShowHeader="False">
                        <alternatingrowstyle backcolor="White" />
                        
                        <columns>

                            <asp:TemplateField HeaderText="" Visible ="False">
                               <ItemTemplate>
                                   <asp:Label ID="ID_MENSAJES" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_MENSAJES") %>'></asp:Label>
                                   <asp:Label ID="ID_TIPO_MENSAJE" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_TIPO_MENSAJE") %>'></asp:Label>
                               </ItemTemplate>

                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Territorial">                           
                               <ItemTemplate>
                                   <asp:Label ID="Territorial" runat="server" CssClass="textoIzq" Text='<%# Eval("MENSAJE") %>'></asp:Label><br /><br />
                                   <asp:Label ID="URL_IMAGEN" runat="server" Visible="false" Text='<%#  Eval("URL_IMAGEN") %>'></asp:Label>
                                   <asp:Image runat="server" ID="URL" Width="100%"  />

                                   <asp:Panel ID="Panel_aceptar" runat="server" Visible="false">
                                       <br /><span style="                                                     top: 0px;
                                                     position: relative;" class="texto_sentencia">Leí a conformidad el artículo anterior.</span><hr /><asp:ImageButton ID="Calificacion_6" runat="server" CausesValidation="False" CommandName="calificacion_6" ImageUrl="https://image.flaticon.com/icons/png/512/907/907779.png" Visible="true" ToolTip="Calificacion 6" Width="50px" CssClass="boton1" />
                                        <hr /> <%--<asp:Button runat="server" CssClass="btn btn-success pos_rigth" OnClick="Cerrar_modal" Text="Aceptar"/> --%>
                                   </asp:Panel>
                                   <asp:Panel runat="server" ID="Panel_calificacion" Visible="false">
                                       <asp:label runat="server" ID="Enunciado" Visible="true" CssClass="texto_sentencia">En una calificación de 1 a 5, donde 5 significa un nivel "muy alto" y 1 un nivel "muy bajo", con respecto a los procesos que están en el apartado anterior.</asp:label><hr />
                                        <asp:ImageButton ID="Calificacion_1" runat="server" CausesValidation="False" CommandName="calificacion_1" ImageUrl="/IMG/star1.png" Visible="true" ToolTip="Calificacion 1" Width="50px" CssClass="boton1" />
                                        <asp:ImageButton ID="Calificacion_2" runat="server" CausesValidation="False" CommandName="calificacion_2" ImageUrl="/IMG/star2.png" Visible="true" ToolTip="Calificacion 2" Width="50px" CssClass="boton2" />
                                        <asp:ImageButton ID="Calificacion_3" runat="server" CausesValidation="False" CommandName="calificacion_3" ImageUrl="/IMG/star3.png" Visible="true" ToolTip="Calificacion 3" Width="50px" CssClass="boton3" />
                                        <asp:ImageButton ID="Calificacion_4" runat="server" CausesValidation="False" CommandName="calificacion_4" ImageUrl="/IMG/star4.png" Visible="true" ToolTip="Calificacion 4" Width="50px" CssClass="boton4" />                                                                
                                        <asp:ImageButton ID="Calificacion_5" runat="server" CausesValidation="False" CommandName="calificacion_5" ImageUrl="/IMG/star5.png" Visible="true" ToolTip="Calificacion 5" Width="50px" CssClass="boton5" /><hr />
                                    </asp:Panel>
                                   <asp:Panel ID="Panel_si_no" runat="server" Visible="false">
                                       <br /><span style="top:0px;position:relative;" class="texto_sentencia">Responde SI o NO según la pregunta anterior.</span><hr />
                                            <asp:ImageButton ID="Calificacion_7" runat="server" CausesValidation="False" CommandName="calificacion_7" ImageUrl="http://www.lombricescalifornianas.cl/assets/img/si-alimento-lombrices.png" Visible="true" ToolTip="Si" Width="50px" CssClass="boton1" />
                                            <asp:ImageButton ID="Calificacion_8" runat="server" CausesValidation="False" CommandName="calificacion_8" ImageUrl="https://cybra.com/wp-content/uploads/2015/04/678069-sign-error-512.png" Visible="true" ToolTip="No" Width="50px" CssClass="boton1" />
                                        <hr /> 
                                   </asp:Panel>
                                   <asp:Panel ID="Panel_abierto" runat="server" Visible="false">
                                       <br /><span style="top:0px;position:relative;" class="texto_sentencia">Respuesta abierta según la pregunta anterior (100 caracteres máximo).</span><hr />
                                            <asp:TextBox CssClass="form-control" ID="Respuesta_9" runat="server" MaxLength="110" Text="Escriba la respuesta Aquí"></asp:TextBox><br />
                                            <asp:ImageButton ID="Calificacion_9" runat="server" CausesValidation="False" CommandName="calificacion_9" ImageUrl="https://image.flaticon.com/icons/svg/941/941565.svg" Visible="true" ToolTip="Enviar respuesta" Width="50px" CssClass="boton1" />
                                        <hr /> 
                                   </asp:Panel>
                                   
                               </ItemTemplate>
                           </asp:TemplateField>
                       </columns>

                    </asp:GridView>
                </div>
            </asp:Panel>

            <style>
                .boton1{
                    animation: movimientos 1s infinite;
                }
                .boton2{
                    animation: movimientos 2s infinite;
                }
                .boton3{
                    animation: movimientos 3s infinite;
                }
                .boton4{
                    animation: movimientos 4s infinite;
                }
                .boton5{
                    animation: movimientos 5s infinite;
                }
                input:hover{
                    animation: movimientos_hover 5s infinite;
                }

                #actualizacionModal > div.modal-dialog{
                        width: 100%;
                }
                @keyframes movimientos{
                    0%   { opacity: 0.7; }
                    100% { opacity: 1; }
                }
                 @keyframes movimientos_hover{
                    0%   { top: 5px; }
                    100% { top: 0px; }
                }
               .box h1{
                    width:100%;
                    margin:0px !important;
                    border: 0px solid !important;
                     margin-bottom: 5% !important;
                     background-color: white !important;
                     color:white !important;
                     box-shadow: 0px 3px 5px -2px rgba(0,0,0,0.75);
                     background-image: url(/img/color-bar.png);
                }
                .texto_sentencia{
                    font-size:10px;
                }
                .pos_rigth{
                    width: 100%;
                }
                .mGrid_bienvenida{
                    width: 1000px;
                    background-color: white;
                    -webkit-box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.75);
                    -moz-box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.75);
                    box-shadow: 0px 0px 14px 0px rgba(0,0,0,0.75);
                }
                td{
                    border:1px solid black;
                }
                #ContentPlaceHolder1_box {
                    overflow-y: scroll;
                    left: 1%;
                    width: 98%;
                    height: 530px;
                }
                .mGrid_bienvenida td{
                    padding:5%;
                    color:black;
                }
                ::-webkit-scrollbar {
                    width: 5px;
                }

                /* Track */
                ::-webkit-scrollbar-track {
                    box-shadow: inset 0 0 5px grey; 
                    border-radius: 0px;
                }
 
                /* Handle */
                ::-webkit-scrollbar-thumb {
                    background: #5e9ca0; 
                    border-radius: 0px;
                }

                /* Handle on hover */
                ::-webkit-scrollbar-thumb:hover {
                    background: #3b4249; 
                }
                .box {
                    border-radius: 0px 0px 0px 0px !important;
                }
            </style>
            <!-- FIN cambio ALEJANDRO 30-agosto-2018 -->


    </center>
        
    <br />
    <br />
    <br />
       
</asp:Content>


