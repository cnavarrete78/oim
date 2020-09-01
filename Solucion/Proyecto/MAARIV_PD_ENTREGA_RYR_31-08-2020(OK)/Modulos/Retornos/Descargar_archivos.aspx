<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Descargar_archivos.aspx.cs" Inherits="Descargar_archivos" Title="MAARIV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://maariv.unidadvictimas.gov.co/js/footable.min.js"></script>

    <script src="../../js/bootstrap-timepicker.js"></script>
    <script src="../../js/bootstrap-timepicker.min.js"></script>

    <script type="text/javascript">
        function pageLoad() {
            $(function () {
                $('[id$="TB_HoraFin"]').timepicker();
                $('[id$="TB_HoraInicio"]').timepicker();

            });
            $(function Show() {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "Actividad";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $("#Tabs a").click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });

            $(function Show() {
                $('.footable').footable();
            });

        }
    </script>

    <script>
        function cerrarse() {
            window.close()
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <table>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" Style="margin-top: 27px" Width="573px" HorizontalAlign="Center" Visible="true">
                    <%--<div class="row">--%>
                    <div class="col-md-12">
                        <asp:HiddenField ID="id_actividad_archivo" runat="server" />
                        <asp:HiddenField ID="id_usuario_2da_instancia" runat="server" />
                        <asp:HiddenField ID="id_usuario_3ra_instancia" runat="server" />
                    </div>
                    <%--</div>--%>
                    <asp:Label runat="server" ID="L_mensaje" Text="" Visible="false" />

                    <div class="modal fade" visible="true" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="modal-content">
                                        <asp:Label ID="L_V2" runat="server" Visible="false" Text="0"></asp:Label>

                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                            <h4 class="modal-title">
                                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                                            <%--<asp:Panel ID="iframePanel" runat="server"></asp:Panel>--%>
                                        </div>
                                        <div class="modal-body text-center">
                                            <asp:CheckBox ID="CB_Valida_accion" Visible="false" CssClass="text-warning" runat="server" Text="Aceptar"></asp:CheckBox>
                                            <%--<asp:GridView ID="gv_modal" runat="server" ></asp:GridView>--%>
                                        </div>
                                        <div class="modal-footer">
                                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true" onclick="cerrarse()">cerrar</button>
                                            <asp:Label ID="L_V1" runat="server" Visible="false" Text=""></asp:Label>
                                            <asp:Label ID="L_V3" runat="server" Visible="false" Text=""></asp:Label>
                                            <asp:Label ID="L_Validacion" runat="server" Visible="false" Text=""></asp:Label>
                                            <%--<asp:Button ID="B_Confirmacion_accion" runat="server" CssClass="btn btn-danger" Visible="false" Text="Continuar" OnClick="B_Confirmacion_accion_Click" />--%>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="B_Confirmacion_accion" />
                            </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>

