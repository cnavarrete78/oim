<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ruta_RyR_Comunitario.aspx.cs" Inherits="Ruta_RyR_Comunitario" Title="MAARIV" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FUA" Namespace="Subgurim.Controles" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="../../css/retornos.css" rel="stylesheet" />

    <script type="text/javascript" src="../../js/jquery191.min.js"></script>
    <script type="text/javascript" src="../../js/boostrap3335.js"></script>
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" runat="server"></asp:ScriptManager>
    <script type="text/javascript" src="../../js/footable.min.js"></script>
    <script src="../../js/sweetalert.js"></script>
    <script src="../../js/bootstrap-timepicker.js"></script>
    <script src="../../js/bootstrap-timepicker.min.js"></script>
    <script src="../../js/PIRC/go.js"></script>
    <script src="../../js/PIRC/pdfmake.min.js"></script>
    <script src="../../js/PIRC/vfs_fonts.js"></script>
    <script src="../../js/PIRC/PDF_PIRC.js"></script>
    <link href="../../css/fa-all.css" rel="stylesheet" />




    <script type="text/javascript">
        function pageLoad() {
            $(function () {
                $('[id$="TB_HoraFin"]').timepicker();
                $('[id$="TB_HoraInicio"]').timepicker();

            });
            $(function Show() {
                var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "Responsables";
                $('#Tabs a[href="#' + tabName + '"]').tab('show');
                $('[id$="Tabs"]  a[role$="tab"]').click(function () {
                    $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                });
            });

            $(function Show() {
                $('.footable').footable();
            });
        } TB_Nit
        function openModalEID() {
            $('#modalAddEID').modal('show');
        }

        function openModalSCD() {
            $('#modalAddSCD').modal('show');
        }

        function openModalProds() {
            $('#modalAddProdCV').modal('show');
        }

        function openModalCID() {
            $('#modalAddCID').modal('show');
        }

        function doCloseEdModal() {
            $("#modalAddED").modal('hide');
            $('.modal-backdrop')[0].remove();
        }

        function doPDFPIRCPrev() {
            var idSujeto = $('#<%=hidIdSujetoCol.ClientID%>').val();

            doPDFPIRC(idSujeto);
        }

        var rowsLoc1 = [];
        var rowsLoc2 = [];

        function doAddLoc(id) {
            var tbod;
            var trow = "";
            var dt = "";
            var dep = "";
            var mun = "";
            var count = 0;

            switch (id) {
                case 1:
                    tbod = $("#tbodLoc1");
                    dt = $("[id*='lstTerrAPob1'] :selected").text();
                    dep = $("[id*='lstDepAPob1'] :selected").text();
                    mun = $("[id*='lstMunAPob1'] :selected").text();
                    count = $("#tbodLoc1 tr").length;

                    trow = "<tr><td>" + dt + "</td><td>" + dep + "</td><td>" + mun + "</td><td><a class='btn btn-danger' onclick='doDeleteLoc(" + id + "," + count + ")'><i class='fa fa-times-circle'></i> Eliminar</a></td></tr>";

                    rowsLoc1.push(trow);

                    for (var i = 0; i < rowsLoc1.length; i++) {
                        tbod.append(rowsLoc1[i]);
                    }

                    break;
                case 2:
                    tbod = $("#tbodLoc2");
                    dt = $("[id*='lstTerrAPob2'] :selected").text();
                    dep = $("[id*='lstDepAPob2'] :selected").text();
                    mun = $("[id*='lstMunAPob2'] :selected").text();
                    count = $("#tbodLoc2 tr").length;

                    trow = "<tr><td>" + dt + "</td><td>" + dep + "</td><td>" + mun + "</td><td><a class='btn btn-danger' onclick='doDeleteLoc(" + id + "," + count + ")'><i class='fa fa-times-circle'></i> Eliminar</a></td></tr>";

                    rowsLoc2.push(trow);

                    for (var i = 0; i < rowsLoc2.length; i++) {
                        tbod.append(rowsLoc2[i]);
                    }
                    break;
                default:
                    break;
            }
        }

        function doDeleteLoc(id, pos) {
            switch (id) {
                case 1:
                    $("#tbodLoc1 tr:eq(" + pos + ")").remove();
                    rowsLoc1.splice(pos, 1);
                    break;
                case 2:
                    $("#tbodLoc2 tr:eq(" + pos + ")").remove();
                    rowsLoc2.splice(pos, 1);
                    break;
                default:
                    break;
            }
        }
        //${ '#ContentPlaceHolder1_Panel4 > div > div.panel-body > div > div.input-group' }.remove('style');


    </script>

    <script type="text/javascript">
        function pageLoad() {

            $('[id$="gv"]').dataTable({
                destroy: true,
                responsive: {
                    //details: false
                }
            });

            $('[id$="gv16"]').dataTable({
                destroy: true,
                responsive: {
                    //details: false
                }
            });

            $('[id$="gv_PersonasFicha"]').dataTable({
                destroy: true,
                responsive: {
                    //details: false
                }
            });

            $('[id$="gv_PersonasPlanRyR"]').dataTable({
                destroy: true,
                responsive: {
                    //details: false
                }
            });

            $('.mgv_personas_exportar').dataTable({
                destroy: true,
                responsive: {
                    //details: false
                },
                dom: 'Bfrtip',
                buttons: [
                    'pdf',
                    'excel',
                    'csv'
                ]
            });

            //PARA LA TABLA DE personas_que_se_acompanan
            $('[id$="gv_listado_personas_que_se_acompanan"]').dataTable({
                destroy: true,
                responsive: {
                    //details: false
                }
            });
            $('.mGridgv_listado_personas_que_se_acompanan').dataTable({
                destroy: true,
                responsive: {
                    //details: false
                },
                dom: 'Bfrtip',
                buttons: [
                    'pdf',
                    'excel',
                    'csv'
                ]
            });

            $('[id$="LD_Territorial"]').change(function () {
                var id_territorial = $('[id$="LD_Territorial"]').val();
                if (L_D_Territorial != '') {
                    L_D_Departamentos(id_territorial);
                }
                else {
                    $('[id$="LD_Departamento"]').empty();
                }
            });

            $('[id$="LD_Departamento"]').change(function () {
                var id_territorial = $('[id$="LD_Territorial"]').val();
                var id_departamento = $('[id$="LD_Departamento"]').val();
                if (id_departamento != '0') {
                    L_D_Municipios(id_territorial, id_departamento);
                }
                else {
                    $('[id$="LD_Departamento"]').empty();
                    $('[id$="LD_Municipio"]').empty();
                }
            });


        }

    </script>

    <%--campos ocultos--%>
    <div class="row">
        <asp:Label runat="server" ID="L_mensaje" Text="" Visible="false" />
        <asp:HiddenField ID="id_dependencia" runat="server" />
        <%--ID de la dependencia a la cual pertenece la actividad--%>
        <asp:HiddenField ID="id_actividad_nombre" runat="server" />
        <%--Parametriza los metodos y valida la busqueda de las personas en la pestaña CONVOCATORIA segun el tipo y/o grupo de las actividades (focalización), cuando aplique--%>
        <asp:HiddenField ID="id_actividad_responsable_rol" runat="server" />
        <%--ID opción lista desplegable del ROL en la pestaña responsable al crear una actividad(default)--%>
        <asp:HiddenField ID="id_usuario_territorio" runat="server" />
        <%--Puede crear y actualizar sus eventos mientras esten en estado ACTIVO--%>
        <asp:HiddenField ID="id_usuario_2da_instancia" runat="server" />
        <%--Puede actualizar el estado de la actividad a REVISADO--%>
        <asp:HiddenField ID="id_usuario_3ra_instancia" runat="server" />
        <%--Puede actualizar el estado de la actividad a APROBADO--%>
        <asp:HiddenField ID="id_val_pduplicadas_asist" runat="server" />
        <%--Valida si se puede o no duplicar personas en las actividades (1->SI 2->NO)--%>
        <asp:HiddenField ID="id_val_pduplicadas_convo" runat="server" />
        <%--Valida si se puede o no duplicar personas en las actividades (1->SI 2->NO)--%>
        <asp:HiddenField ID="archivo_filesystem" runat="server" />
        <%--Establece la ruta del sistema de archivos donde se guardaran los docs y/o evidencias de este modulo--%>
        <asp:HiddenField ID="opcion_tipo_archivo" runat="server" />
        <%--Valida los tipos de documentos adjuntos para su cargue segun la actividad--%>
        <asp:HiddenField ID="opcion_tipo_detalle" runat="server" />
        <%--Valida las opciones de la lista desplegable de tipo detalle--%>
        <asp:HiddenField ID="opcion_Subcategoria" runat="server" />
        <%--Valida las opciones de las subcategorias--%>
        <asp:HiddenField ID="opcion_rol_responsable" runat="server" />
        <%--Valida las opciones para el rol de los responsables -> 0 para valor dafault(valores estandar) en el SP--%>
        <asp:HiddenField ID="id_val_HV_asist" runat="server" />
        <%--Valida hecho victimizante (0->no visible 1->modifica(obligatorio >=1) 2->modifica(no obligatorio)  3->consulta(HV persona, no modifica))--%>
        <asp:HiddenField ID="id_val_HV_convo" runat="server" />
        <%--Valida hecho victimizante (0->no visible 1->modifica(obligatorio >=1) 2->modifica(no obligatorio)  3->consulta(HV persona, no modifica))--%>
        <asp:HiddenField ID="opcion_lista_usuarios" runat="server" />
        <%--Valida el listado de usuarios para los filtros de busqueda, tanto en actividades como en responsables en el SP--%>
        <asp:HiddenField ID="id_tipo_persona" runat="server" />
        <%--Asigna el ID tipo persona al momento de crear personas nuevas en la tabla TBL_RPERSONA--%>
        <asp:HiddenField ID="id_consultap_focalizados_asis" runat="server" />
        <%--Asigna el ID de la opcion para la consulta de personas en asistencia. 1->consulta tabla tbl_rpersona 2->consulta tabla tbl_rpersona_focalizacion--%>
        <asp:HiddenField ID="id_consultap_focalizados_convo" runat="server" />
        <%--Asigna el ID de la opcion para la consulta de personas en convocatoria. 1->consulta tabla tbl_rpersona 2->consulta tabla tbl_rpersona_focalizacion--%>

        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="opcion_tipo_detalle_costos" runat="server" />
        <%--variable que carga los tipos de costos de un producto o actividad ---""··para colectiva ---""----%>

        <%--Campos ocultos desarrollo Liliana Rodriguez--%>
        <asp:HiddenField ID="idComunidad" runat="server" />
        <asp:HiddenField ID="idPlanAccionTraslado" runat="server" />

    </div>

    <asp:Panel ID="Panel1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <div class="row titulo_tabla">
                    SEGUIMIENTO COMUNIDADES R Y R
                </div>
                <div id="myDiagrarmArbolProb" style="background-color: white; border: solid 1px black; width: 100%; height: 800px; display: none;"></div>
                <div id="myDiagrarmArbolObjet" style="background-color: white; border: solid 1px black; width: 100%; height: 800px; display: none;"></div>
                <div class="row center-block">
                    <%--panel de la izquierda--%>
                    <div class="col-md-3" style="border: 1px solid #eaeaea; min-height: 920px; background-color: #fcfcfc; border-radius: 9px 9px 9px 9px">

                        <div class="row">
                            <asp:Panel ID="Panel_busqueda_1" runat="server" CssClass="titulo_tabla curba" ScrollBars="None" HorizontalAlign="Left" Width="100%">
                                Busqueda de Comunidad R y R   
                            </asp:Panel>
                            <div class="row">
                                <div class="col-md-12">
                                    Tipo de Comunidad
                                        <asp:DropDownList ID="LD_Tipo_sujeto" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="LD_Tipo_sujeto_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvEstado0" runat="server"
                                        ControlToValidate="LD_Tipo_sujeto" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione el tipo de sujeto" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    Subcategoria
                                        <asp:DropDownList ID="LD_subCategoria" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                        ControlToValidate="LD_subCategoria" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>--%>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    Nombre de la comunidad
                                        <asp:TextBox ID="TB_Nombre_sujeto" runat="server" CssClass="form-control"
                                            MaxLength="500" Style="text-transform: uppercase"
                                            TextMode="MultiLine"></asp:TextBox>
                                    <span style="font-weight: normal">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                            ControlToValidate="TB_Nombre_sujeto" CssClass="validador" Display="Dynamic"
                                            ValidationGroup="guardar">El nombre del sujeto es obligatorio</asp:RequiredFieldValidator>
                                    </span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    ID Comunidad
                                    <asp:TextBox ID="TB_Nit" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                    <span style="font-weight: normal"></span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    Zona
                                    <asp:DropDownList ID="L_D_zona" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server"
                                        ControlToValidate="L_D_zona" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione la Zona" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-12">
                                    Dirección territorial
                                   <asp:DropDownList ID="LD_Territorial" runat="server"
                                       CssClass="form-control">
                                   </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server"
                                        ControlToValidate="LD_Territorial" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione la D. Territorial" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    Departamento
                                    <asp:DropDownList ID="LD_Departamento" runat="server"
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server"
                                        ControlToValidate="LD_Departamento" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione el Departamento" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    Municipio
                                    <asp:DropDownList ID="LD_Municipio" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server"
                                        ControlToValidate="LD_Municipio" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione el municipio" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row" runat="server" visible="false">
                                <div class="col-md-12" runat="server" visible="false">
                                    Alcance
                                        <asp:DropDownList ID="L_D_Alcance" runat="server" AutoPostBack="True"
                                            CssClass="form-control" OnSelectedIndexChanged="L_D_Alcance_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvEstado1" runat="server"
                                        ControlToValidate="L_D_Alcance" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione el alcance" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-12" runat="server" visible="false">
                                    Fase Comunidad
                                            <asp:DropDownList ID="LD_estado_sujeto" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0">Seleccionar estado</asp:ListItem>

                                                <asp:ListItem Value="ALISTAMIENTO">ALISTAMIENTO</asp:ListItem>
                                                <asp:ListItem Value="CARACTERIZACIÓN DEL DAÑO">CARACTERIZACIÓN DEL DAÑO</asp:ListItem>
                                                <asp:ListItem Value="DIAGNÓSTICO DEL DAÑO">DIAGNÓSTICO DEL DAÑO</asp:ListItem>
                                                <asp:ListItem Value="DISEÑO Y FORMULACIÓN">DISEÑO Y FORMULACIÓN</asp:ListItem>
                                                <asp:ListItem Value="IDENTIFICACIÓN">IDENTIFICACIÓN</asp:ListItem>
                                                <asp:ListItem Value="IMPLEMENTACIÓN">IMPLEMENTACIÓN</asp:ListItem>
                                                <asp:ListItem Value="IMPLEMENTADO">IMPLEMENTADO</asp:ListItem>

                                            </asp:DropDownList>
                                    <br />
                                    <%--<asp:RequiredFieldValidator ID="rfvEstado" runat="server"
                                        ControlToValidate="LD_estado_sujeto" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione un estado" InitialValue="0" ValidationGroup="guardar"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12" id="LD_estado_sujeto_colectivodiv" runat="server" visible="false">
                                    Estado sujeto
                                    <asp:DropDownList ID="LD_estado_sujeto_colectivo" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">Seleccionar estado</asp:ListItem>
                                        <asp:ListItem Value="1">ACTIVO</asp:ListItem>
                                        <asp:ListItem Value="2">INACTIVO</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12" runat="server" visible="false">
                                    Tipo Acceso
                                            <asp:DropDownList ID="L_D_TipoAcceso" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">Seleccionar tipo</asp:ListItem>

                                                <asp:ListItem Value="OFERTA">OFERTA</asp:ListItem>
                                                <asp:ListItem Value="DEMANDA">DEMANDA</asp:ListItem>

                                            </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server"
                                        ControlToValidate="L_D_TipoAcceso" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione el tipo de acceso" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12" runat="server" visible="false">
                                    FUD
                                    <asp:TextBox ID="TB_FUD" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                    <span style="font-weight: normal">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server"
                                            ControlToValidate="TB_FUD" CssClass="validador" Display="Dynamic"
                                            ValidationGroup="guardar">El FUD es obligatorio</asp:RequiredFieldValidator>
                                    </span>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12" runat="server" visible="false">
                                    Estado RUV
                                        <asp:DropDownList ID="L_D_estadoruv" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="">Seleccionar estado</asp:ListItem>

                                            <asp:ListItem Value="INCLUIDO">INCLUIDO</asp:ListItem>
                                            <asp:ListItem Value="NO INCLUIDO">NO INCLUIDO</asp:ListItem>
                                            <asp:ListItem Value="SIN FUD">SIN FUD</asp:ListItem>
                                            <asp:ListItem Value="EN VALORACION">EN VALORACION</asp:ListItem>

                                        </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server"
                                        ControlToValidate="L_D_estadoruv" CssClass="validador" Display="Dynamic"
                                        ErrorMessage="Seleccione el estado" InitialValue="0"
                                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>



                            <div class="row ">
                                <div class="row">
                                    <asp:Button ID="buscar" runat="server" CssClass="btn-block btn btn-danger" OnClick="buscar_Click" Text="Buscar" />
                                </div>
                                <div class="row">
                                    <asp:Button ID="limpiar" runat="server" CssClass="btn-block btn btn-danger" OnClick="limpiar_Click" Text="Limpiar" />
                                </div>
                                <div class="row">
                                    <asp:Button ID="guardar" runat="server" Visible="false" CssClass="btn-block btn btn-danger" OnClick="guardar_Click" Text="Guardar" ValidationGroup="guardar" />
                                </div>
                                <div class="row">
                                    <asp:Button ID="actualizar" runat="server" CssClass="btn-block btn btn-danger" Visible="false" OnClick="actualizar_Click" Text="Actualizar" ValidationGroup="guardar" />
                                </div>
                                <div class="row" style="display: none;">
                                    <input type="button" class="btn btn-block btn-danger" value="Generar PDF" onclick="doPDFPIRC(1707);" />
                                </div>
                            </div>
                            <div class="row">
                                <%--lista actividad--%>
                                <div class="col-md-12" visible="false">

                                    <asp:DropDownList ID="LD_actividad_nombre" runat="server" CssClass="form-control" Enabled="False" Visible="false">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator548" runat="server"
                                        ControlToValidate="LD_actividad_nombre" CssClass="validador" Display="Dynamic"
                                        InitialValue="0" Style="font-weight: normal" ValidationGroup="agregar">Seleccione la actividad</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--panel derecha--%>
                    <div class="col-md-9" style="border: 1px solid #eaeaea; min-height: 920px; background-color: #fcfcfc; border-radius: 9px 9px 9px 9px">

                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 1041;" id="myModalEncuesta" aria-hidden="true">
                            <div class="modal-dialog " style="width: 80%; max-height: 100vh;" role="document">
                                <div>
                                    <%--style="overflow-y: scroll; max-height: 95%;"--%>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel8" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="modal-content">
                                                <div class="">

                                                    <div class="panel panel-danger" style="margin-bottom: 6px;">

                                                        <div class="panel-heading">

                                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                            <h3>
                                                                <asp:Literal ID="Li_diaActividad" runat="server"></asp:Literal></h3>
                                                        </div>
                                                        <div class="panel-body" style="max-height: 40vh; overflow-y: auto;">

                                                            <div class="container-fluid">
                                                                <div style="margin-top: 9px;">

                                                                    <asp:ListView ID="LV_Informe" runat="server" OnItemDataBound="LV_Informe_ItemDataBound">
                                                                        <ItemTemplate>

                                                                            <asp:Label ID="L_AdepTipo" runat="server" Visible="false" Text='<%# Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO") %>'></asp:Label>
                                                                            <asp:Label ID="L_pregunta" runat="server" Visible="false" Text='<%# Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA") %>'></asp:Label>
                                                                            <asp:Label ID="L_IdAdep" runat="server" Visible="false" Text='<%# Eval("ID_ACTIVIDAD_DIA_ENCUESTA_PREGUNTA") %>'></asp:Label>
                                                                            <asp:Label ID="L_PreObli" runat="server" Visible="false" Text='<%# Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO") %>'></asp:Label>


                                                                            <asp:Label ID="L_IdRespuestaA" runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="L_TieneRespuesta" runat="server" Visible="false"></asp:Label>

                                                                            <div class="col-md-12" style="text-transform: none;" <%#Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO").ToString() == "10"? "":"hidden" %>>
                                                                                <asp:Panel ID="P_Titulo_Encuesta" runat="server" Visible='<%#Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO").ToString() == "10"  %>' class="page-header">
                                                                                    <asp:Literal ID="Li_Titulo" runat="server" />
                                                                                </asp:Panel>
                                                                            </div>


                                                                            <%--<asp:Panel></asp:Panel>--%>
                                                                            <asp:Panel ID="P_ListText" runat="server" Visible='<%#Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO").ToString() != "10" ? true:false %>' class="form-group col-md-6 ">
                                                                                <label class="control-label2">
                                                                                    <asp:Literal runat="server" ID="L_TexPregunt" Text='<%# Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA") %>'></asp:Literal>
                                                                                    <i class="reqjs fas fa-asterisk" <%#Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_OBLIGATORIO").ToString() == "1"? "":"hidden" %>></i>
                                                                                </label>
                                                                                <div>
                                                                                    <asp:DropDownList ID="LD_Respueta" runat="server" CssClass="form-control" Visible='<%#Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO").ToString() == "1" ? true:false %>'>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator545" runat="server" ControlToValidate="LD_Respueta" CssClass="validador" Display="Dynamic" InitialValue="0" ValidationGroup="v_guardar_archivo">El tipo de archivo es obligatorio</asp:RequiredFieldValidator>
                                                                                    <asp:TextBox ID="TB_RespuestaAbierta" runat="server" Visible='<%#Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO").ToString() == "2" ? true:false %>' placeholder="" CssClass="form-control"></asp:TextBox>

                                                                                    <asp:Literal runat="server" Visible="false" Text="N/A" ID="L_Respuesta"></asp:Literal>


                                                                                    <%-- <asp:RadioButtonList ID="RB_informe" runat="server" Visible='<%#Eval("ACTIVIDAD_DIA_ENCUESTA_PREGUNTA_TIPO").ToString() == "12" ? true:false %>'>
                                                                        </asp:RadioButtonList>--%>
                                                                                </div>
                                                                            </asp:Panel>


                                                                        </ItemTemplate>
                                                                    </asp:ListView>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="modal-footer">

                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <asp:Literal ID="Li_Prosgress" runat="server"></asp:Literal>


                                                                </div>
                                                                <div class="col-md-6">
                                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                                                    <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                                                                    <asp:LinkButton ID="LB_GuardarInforme" runat="server" OnClick="LB_GuardarInforme_Click" Visible="false" class="btn btn-primary" Text="Guardar" />

                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="LB_GuardarInforme" />
                                            <%--<asp:AsyncPostBackTrigger ControlID="B_actualizar_detalle" />--%>
                                            <%--<asp:AsyncPostBackTrigger ControlID="B_CancelaDetalle" />--%>
                                            <%--<asp:AsyncPostBackTrigger ControlID="LD_tipo_actividad" />--%>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div class="modal fade" visible="false" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
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
                                            <div class="modal-body text-justify row">
                                                <asp:Label ID="lblModalBody" CssClass="text-justify" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="modal-body text-center">
                                                <asp:CheckBox ID="CB_Valida_accion" Visible="false" CssClass="text-warning" runat="server" Text="Aceptar"></asp:CheckBox>
                                            </div>
                                            <div class="modal-footer">
                                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">cerrar</button>
                                                <asp:Label ID="L_V1" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Label ID="L_V3" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Label ID="L_Validacion" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Button ID="B_Confirmacion_accion" runat="server" CssClass="btn btn-danger" Visible="false" Text="Continuar" OnClick="B_Confirmacion_accion_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_Confirmacion_accion" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="modal fade " tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModal2" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class=" modal-dialog" style="width: 72%" role="document">

                                <asp:UpdatePanel ID="UP_Archivos" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>

                                        <div class="panel panel-danger">
                                            <div class="panel-heading">
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                Documentos y evidencias
                                            </div>
                                            <div class="panel-body">
                                                <div class="container-fluid">

                                                    <div class="panel panel-danger" runat="server" id="div_admin_documentos" visible="false">
                                                        <div class="panel-heading">
                                                            Administracion de Documentos 
                                                        </div>
                                                        <div class="panel-body">
                                                            <asp:Panel ID="Panel17" runat="server" Visible="false" CssClass="container-fluid" Style="margin-left: 9%; margin-right: 9%;">
                                                                <div class="panel panel-default">
                                                                    <div class="panel-body">



                                                                        <div class="row">
                                                                            <div class="col-md-4 col-md-offset-2">
                                                                                <label class="label1 col-sm-2">Tipo de Documento</label>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <asp:DropDownList ID="LD_tipo_Documento_admin" runat="server" CssClass="form-control col-sm-4">
                                                                                </asp:DropDownList>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="LD_usuario" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_responsable">Seleccione el rol</asp:RequiredFieldValidator>--%>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-md-4 col-md-offset-2">
                                                                                <label class="label1">Obligatorio</label>
                                                                            </div>
                                                                            <div class="col-md-4">
                                                                                <asp:CheckBox ID="C_B_estado_documento" runat="server" CssClass="textoIzq" Style="font-weight: normal" />
                                                                            </div>

                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-md-4 col-md-offset-4">
                                                                                <asp:LinkButton ID="btn_agregar_documento" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_agregar_documento_Click" Text="Guardar">
                                                                                            <span class="glyphicon glyphicon glyphicon-plus" aria-hidden="true"></span> Agregar Documento
                                                                                </asp:LinkButton>
                                                                            </div>

                                                                        </div>


                                                                    </div>
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Panel ID="Panel18" runat="server" Visible="false" CssClass="container-fluid">
                                                                <div class="row">
                                                                    <asp:GridView UseAccessibleHeader="true" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                                                        CssClass="footable mGrid " ID="gv_documentos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                        CellPadding="4" OnPageIndexChanging="gv_documentos_PageIndexChanging" OnRowCommand="gv_documentos_RowCommand" PageSize="10"
                                                                        OnRowDataBound="gv_documentos_RowDataBound">
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                        <Columns>

                                                                            <asp:TemplateField HeaderText="ID_ACTIVIDAD_DIA_TIPO_ARCHIVO" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="ID_ACTIVIDAD_DIA_TIPO_ARCHIVO" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_ACTIVIDAD_DIA_TIPO_ARCHIVO") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="ID_ACTIVIDAD_DIA" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="ID_ACTIVIDAD_DIA" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_ACTIVIDAD_DIA") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>


                                                                            <asp:TemplateField HeaderText="ID_TIPO_ACTIVIDAD_ARCHIVO" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="ID_TIPO_ACTIVIDAD_ARCHIVO" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_TIPO_ACTIVIDAD_ARCHIVO") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Tipo archivo">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="TIPO_ACTIVIDAD_ARCHIVO" runat="server" CssClass="textoIzq" Text='<%# Eval("TIPO_ACTIVIDAD_ARCHIVO") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Obligatorio">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="ID_ESTADO" Visible="false" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_ESTADO") %>'></asp:Label>
                                                                                    <asp:Label CssClass="success text-success" ToolTip="Documento aprobado" Font-Size="20px" runat="server" ID="Docu_aprobado" Visible="true">
                                                                                            <span class="glyphicon glyphicon-check" aria-hidden="true"></span>
                                                                                    </asp:Label>
                                                                                    <asp:Label CssClass="success text-danger" ToolTip="Documento NO aprobado" Font-Size="20px" runat="server" ID="Docu_NoAprobado" Visible="true">
                                                                                            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                                                    </asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>


                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="ibtnGEliminar_documento" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                            </asp:TemplateField>


                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>


                                                    <div class="panel panel-danger">
                                                        <div class="panel-heading">
                                                            Documentos y evidencias 
                                                        </div>
                                                        <div class="panel-body">
                                                            <asp:Panel ID="Panel252" runat="server" Style="margin-left: 9%; margin-right: 9%;" CssClass="container-fluid">
                                                                <asp:Panel runat="server" ID="panel_check_medida" Visible="true">
                                                                    <%--<asp:CheckBox CssClass="col-md-1" runat="server" ID="check_medida" AutoPostBack="true" OnCheckedChanged="check_medida_CheckedChanged" />
                                                                    <asp:Label CssClass="col-md-2" runat="server" ID="label_check">
                                                                        Entrelazando?
                                                                    </asp:Label>--%>
                                                                    <div class="row">
                                                                        <label class="col-md-3 label1">Tipo</label>
                                                                        <div class="col-md-3">
                                                                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" ID="RB_Tipo_actividad" AutoPostBack="true" CssClass="radiojose2" OnSelectedIndexChanged="RB_Tipo_actividad_SelectedIndexChanged">

                                                                                <asp:ListItem Value="Entrelazando" Selected="True" Text="Entrelazando"> Entrelazando</asp:ListItem>
                                                                                <asp:ListItem Value="Rehabilitacion" Text="Rehabilitación"> Rehabilitación</asp:ListItem>

                                                                            </asp:RadioButtonList>
                                                                        </div>
                                                                    </div>

                                                                </asp:Panel>
                                                                <div class="col-md-12 form-group " runat="server" id="div_medida" visible="false">
                                                                    <label class="col-md-3 label1 ">PIRC Implementación medida de rehabilitación comunitaria - Entrelazando.</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="LD_medida" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="LD_medida_SelectedIndexChanged">
                                                                            <%--<asp:ListItem Selected="True" Value="0"> Selecione medida </asp:ListItem>
                                                                            <asp:ListItem Value="1"> Imaginarios Colectivos </asp:ListItem>
                                                                            <asp:ListItem Value="2"> Prácticas Sociales </asp:ListItem>
                                                                            <asp:ListItem Value="3"> Viviendo La Diferencia O Pedagogía Social </asp:ListItem>
                                                                            <asp:ListItem Value="4"> Duelos Colectivos (Adicional Guía De Memoria) </asp:ListItem>
                                                                            <asp:ListItem Value="5"> Transformación De Escenarios Locales </asp:ListItem>
                                                                            <asp:ListItem Value="6"> Organizaciones - Fortalecimiento Organizativo </asp:ListItem>
                                                                            <asp:ListItem Value="7"> Organizaciones - Incidencia Social </asp:ListItem>
                                                                            <asp:ListItem Value="8"> Organizaciones - Iniciativas Locales de Memoria </asp:ListItem>
                                                                            <asp:ListItem Value="9"> EVALUACION SEGUIMIENTO Y CIERRE </asp:ListItem>
                                                                            <asp:ListItem Value="10"> CIRRE MEDIDA DE REHABILITACION </asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="LD_DepArchivo" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="v_guardar_archivo">El día es obligatorio</asp:RequiredFieldValidator>

                                                                    </div>

                                                                    <label runat="server" id="label_medida_2" class="col-md-3 label1 ">Componente</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="LD_medida_2" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="LD_medida_2_SelectedIndexChanged">
                                                                            <asp:ListItem Selected="True" Value="0"> Selecione medida </asp:ListItem>
                                                                            <%--<asp:ListItem Value="1"> Formación del componente </asp:ListItem>
                                                                            <asp:ListItem Value="2"> Acción con acompañamiento del profesional psicosocial </asp:ListItem>
                                                                            <asp:ListItem Value="3"> Acción sin el acompañamiento del profesional psicosocial </asp:ListItem>
                                                                            <asp:ListItem Value="4"> Dialogos con tejedores y tejedoras o referentes de ciudado</asp:ListItem>
                                                                            <asp:ListItem Value="5"> Dialogos con la comunidad </asp:ListItem>
                                                                            <asp:ListItem Value="6"> Acto simbólico </asp:ListItem>
                                                                            <asp:ListItem Value="7"> Informe de cierre </asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="LD_DepArchivo" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="v_guardar_archivo">El día es obligatorio</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="form-group  col-md-12">
                                                                    <label class="col-md-3 label1 ">Tipo de documento</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="LD_tipo_archivo" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="LD_tipo_archivo_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator545" runat="server" ControlToValidate="LD_tipo_archivo" CssClass="validador" Display="Dynamic" InitialValue="0" ValidationGroup="v_guardar_archivo">El tipo de archivo es obligatorio</asp:RequiredFieldValidator>
                                                                    </div>
                                                                    <label class="col-md-3 label1  ">Fecha ejecución actividad:</label>
                                                                    <div class="col-md-3">
                                                                        <div class="input-group " id="calendar1">
                                                                            <asp:TextBox ID="TB_FechaExpedicion" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text='<%# Eval("DIA_ACTIVIDAD") %>'></asp:TextBox>
                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                        </div>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendar1" TargetControlID="TB_FechaExpedicion"></ajaxToolkit:CalendarExtender>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_FechaExpedicion" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardar_dias">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TB_FechaExpedicion" CssClass="validador" Display="Dynamic" ValidationGroup="v_guardar_archivo">*</asp:RequiredFieldValidator>
                                                                    </div>

                                                                </div>


                                                                <div class="col-md-12 form-group " runat="server">
                                                                    <label class="col-md-3 label1 ">Departamento:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="LD_DepArchivo" runat="server" CssClass="form-control" OnSelectedIndexChanged="LD_DepArchivo_SelectedIndexChanged" AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="LD_DepArchivo" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="v_guardar_archivo">El día es obligatorio</asp:RequiredFieldValidator>

                                                                    </div>
                                                                    <label class="col-md-3 label1 ">Municipio: </label>
                                                                    <div class="col-md-3">
                                                                        <asp:DropDownList ID="LD_MunArchivo" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="LD_MunArchivo" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="v_guardar_archivo">El día es obligatorio</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>


                                                                <div class="col-md-12 form-group ">
                                                                    <label class="col-md-3  label1 "># de participantes:</label>
                                                                    <div class="col-md-3">
                                                                        <asp:TextBox ID="TB_Personas" runat="server" CssClass="form-control"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TB_Personas" CssClass="validador" Display="Dynamic" ValidationGroup="v_guardar_archivo">*</asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TB_Personas" CssClass="validador"
                                                                            Display="Dynamic" ValidationExpression='[\d]+' ValidationGroup="v_guardar_archivo">
                                                                    Solo números. </asp:RegularExpressionValidator>
                                                                    </div>
                                                                    <label class="col-md-3 label1 ">Adjuntar el documento</label>
                                                                    <div class="col-md-3">
                                                                        <div class="input-group">
                                                                            <asp:FileUpload runat="server" ID="f1" />
                                                                        </div>


                                                                    </div>

                                                                </div>





                                                                <div class="col-md-12 form-group " runat="server" id="Descripcion_archivo_div">
                                                                    <label class="col-md-3 label1 ">Descripción documento:</label>
                                                                    <div class="col-md-9">
                                                                        <asp:TextBox ID="TB_DescripcionArchivo" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="2"></asp:TextBox>

                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TB_DescripcionArchivo" CssClass="validador"
                                                                            Display="Dynamic" ValidationExpression='[\w\s áéíóú,Ññ()_-ÁÉÍÓÚ. ]+' ValidationGroup="v_guardar_archivo">
                                                                    Por favor no incluir caracteres especiales. </asp:RegularExpressionValidator>


                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TB_DescripcionArchivo" CssClass="validador" Display="Dynamic" ValidationGroup="v_guardar_archivo">*</asp:RequiredFieldValidator>

                                                                    </div>

                                                                </div>

                                                                <div class="col-md-12 form-group " runat="server" visible="false">
                                                                    <label class="col-md-3 label1 col-md-offset-1">Fecha de expedición</label>
                                                                    <div class="col-md-6">
                                                                        <asp:DropDownList ID="L_D_dia_actividad_documentos" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="L_D_dia_actividad_documentos" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="v_guardar_archivo">El día es obligatorio</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="row form-group">
                                                                    <asp:Label ID="StatusLabel" runat="server" />
                                                                    <div class="col-md-3 ">
                                                                        <asp:LinkButton ID="buscar_archivo" runat="server" CssClass="btn btn-block btn-danger" Visible="false" OnClick="buscar_archivo_Click">
                                                                                        <span class="glyphicon  glyphicon-search" aria-hidden="true"></span> Buscar archivos
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-md-3 col-md-offset-1">
                                                                        <asp:LinkButton ID="guardar_archivo" runat="server" CssClass="btn btn-block btn-danger" OnClick="guardar_archivo_Click" ValidationGroup="v_guardar_archivo">
                                                                                        <span class="glyphicon  glyphicon-plus" aria-hidden="true"></span> Agregar archivo
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-md-3 col-md-offset-1">
                                                                        <asp:LinkButton ID="limpiar_archivo" Visible="false" runat="server" CssClass="btn btn-block btn-danger" OnClick="limpiar_archivo_Click">
                                                                                        <span class="glyphicon  glyphicon-repeat" aria-hidden="true"></span> Limpiar datos
                                                                        </asp:LinkButton>
                                                                    </div>

                                                                    <div class="col-md-3 col-md-offset-1">
                                                                        <asp:LinkButton ID="actualizar_archivo" Visible="false" runat="server" CssClass="btn btn-block btn-danger" OnClick="actualizar_archivo_Click1">
                                                                                        <span class="glyphicon  glyphicon-repeat" aria-hidden="true"></span> Actualizar Archivo
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>

                                                            </asp:Panel>
                                                            <asp:Panel ID="Panel15" runat="server" CssClass="container-fluid">
                                                                <div class="row">
                                                                    <%--<!--search (buscador)-->
                                                                    <div class="input-group" style="width: 20%;">
                                                                        <asp:TextBox ID="text_search_gv16" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <asp:LinkButton ID="search_gv16" runat="server" OnClick="search_gv16_Click">
                                                                    <span class="fas fa-search" aria-hidden="true" style="position: absolute;top: 0px;z-index: 0;padding: 4%;left: 100%;border: 1px solid #cccccc;color: #95d095;"></span>
                                                                        </asp:LinkButton>
                                                                        <asp:LinkButton ID="reset_gv16" runat="server" OnClick="reset_gv16_Click">
                                                                    <span class="fas fa-window-close" aria-hidden="true" style="position: absolute;top: 0px;left: 117%;border: 1px solid #cccccc;padding: 4%;"></span>
                                                                        </asp:LinkButton>
                                                                        <asp:LinkButton ID="descargar_todo" runat="server" OnClick="descargar_todo_Click">
                                                                    <span class="fas fa-download" aria-hidden="true" style="position: absolute;top: 0px;left: 137%;border: 1px solid #cccccc;padding: 4%;"></span>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-md-12" style="height: 20px;"></div>
                                                                    <!-- fin search-->--%>
                                                                    <div runat="server" style="overflow-x: scroll">
                                                                        <asp:GridView AlternatingRowStyle-CssClass="alt"
                                                                            CssClass="table mGrid " ID="gv16" runat="server" AutoGenerateColumns="False"
                                                                            OnRowCommand="gv16_RowCommand"
                                                                            OnRowDataBound="gv16_RowDataBound"
                                                                            OnPreRender="gv16_PreRender">
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                            <Columns>

                                                                                <asp:TemplateField HeaderText="Fase">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="nombre_archivo" runat="server" CssClass="textoIzq" Text='<%# Eval("NOMBRE_ARCHIVO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Usuario">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Usuario" runat="server" CssClass="textoIzq" Text='<%# Eval("Usuario") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="ID_Acción">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="L_PROYECCION" runat="server" CssClass="textoIzq" Text='<%# Eval("PROYECCION") %>'></asp:Label>
                                                                                        <asp:Label ID="id_actividad_dia" runat="server" Visible="false" CssClass="textoIzq" Text='<%# Eval("ID_ACTIVIDAD_DIA") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Medida">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lugar_actividad" runat="server" CssClass="textoIzq" Text='<%# Eval("TIPO_MEDIDA") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Acción">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="ob_actividad_dia" runat="server" CssClass="textoIzq" Text='<%# Eval("OBSERVACION_ACTIVIDAD_DIA") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="id_actividad_archivo" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="id_actividad_archivo" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_ACTIVIDAD_ARCHIVO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>



                                                                                <asp:TemplateField HeaderText="Tipo archivo">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="tipo_actividad_archivo" runat="server" CssClass="textoIzq" Text='<%# Eval("TIPO_ACTIVIDAD_ARCHIVO") %>'></asp:Label>
                                                                                        <%--TIPO_ACTIVIDAD_ARCHIVO_2--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Fecha Documento">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="fecha_expedicion" runat="server" CssClass="textoIzq" Text='<%# Eval("FECHA_EXPEDICION") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Acciones">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="descarga_archivo" runat="server" CssClass="btn btn-default btn-sm" ToolTip="DESCARGAR" CommandName="Descargar">                                                                                                    
                                                                                                        <span class="glyphicon glyphicon-download-alt" aria-hidden="true"></span>
                                                                                        </asp:LinkButton>

                                                                                        <asp:LinkButton ID="ibtnGEliminar_archivo" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                        </asp:LinkButton>

                                                                                        <asp:LinkButton ID="btn_actualizar_archivo" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ACTUALIZAR" CommandName="Actualizar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                                                        </asp:LinkButton>

                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                </asp:TemplateField>



                                                                                <asp:TemplateField HeaderText="id_estado_doc" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="id_actividad_archivo_estado" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_ACTIVIDAD_ARCHIVO_ESTADO") %>'></asp:Label>
                                                                                        <asp:Label ID="id_actividad_dia_estado" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_ACTIVIDAD_DIA_ESTADO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Estado">
                                                                                    <ItemTemplate>
                                                                                        <div id="estado_doc" runat="server" visible="false" class="btn-group btn-group-md" role="group" aria-label="...">
                                                                                            <asp:LinkButton ID="Aprobado" runat="server" CssClass="btn btn-default" CommandName="Documento_aprobado" ToolTip="APROBADO">
                                                                                                             <span class="glyphicon glyphicon-thumbs-up" aria-hidden="true"></span>
                                                                                            </asp:LinkButton>
                                                                                            <asp:LinkButton ID="Denegado" runat="server" CssClass="btn btn-default" CommandName="Documento_denegado" ToolTip="NO APROBADO">
                                                                                                             <span class="glyphicon glyphicon-thumbs-down" aria-hidden="true"></span>
                                                                                            </asp:LinkButton>
                                                                                        </div>
                                                                                        <asp:Panel ID="LB_EstadoDoc" runat="server" Visible="true">

                                                                                            <asp:Label CssClass="success text-success" ToolTip="Documento aprobado" Font-Size="20px" runat="server" ID="Docu_aprobado" Visible="false">
                                                                                            <span class="glyphicon glyphicon-check" aria-hidden="true"></span>
                                                                                            </asp:Label>
                                                                                            <asp:Label CssClass="success text-warning" ToolTip="Pendiente aprobación" Font-Size="20px" runat="server" ID="Docu_pendiente" Visible="false">
                                                                                            <span class="glyphicon glyphicon-hourglass" aria-hidden="true"></span>
                                                                                            </asp:Label>
                                                                                            <asp:Label CssClass="success text-danger" ToolTip="Documento NO aprobado" Font-Size="20px" runat="server" ID="Docu_NoAprobado" Visible="false">
                                                                                            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                                                            </asp:Label>
                                                                                        </asp:Panel>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                                                                </asp:TemplateField>


                                                                                <asp:BoundField DataField="PERSONAS" HeaderText="PERSONAS" />
                                                                                <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" />
                                                                                <asp:BoundField DataField="MUNICIPIO" HeaderText="MUNICIPIO" />
                                                                                <asp:BoundField DataField="DEPARTAMENTO" HeaderText="DEPARTAMENTO" />

                                                                                <asp:TemplateField HeaderText="ID_DEPARTAMENTO" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="ID_DEPARTAMENTO" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_DEPARTAMENTO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="ID_MUNICIPIO" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="ID_MUNICIPIO" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_MUNICIPIO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DESCRIPCION" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="DESCRIPCION" runat="server" CssClass="textoIzq" Text='<%# Eval("DESCRIPCION") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="PERSONAS" Visible="False">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="PERSONAS" runat="server" CssClass="textoIzq" Text='<%# Eval("PERSONAS") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>



                                                                                <asp:TemplateField HeaderText="Cambia a:">
                                                                                    <ItemTemplate>
                                                                                        <%--<asp:ImageButton ID="ibtnGActualizar" runat="server" CausesValidation="False" CommandName="Actualizar_estado" ImageUrl="~/IMG/checked.png" CssClass="boton_img" ToolTip="Habilitar usuario" />--%>
                                                                                        <asp:DropDownList ID="LD_Cambiar_accion" Visible="false" runat="server" CssClass="form-control" Enabled="true">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator529" runat="server" ControlToValidate="LD_Cambiar_accion"
                                                                                            CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal"
                                                                                            ValidationGroup="guardar_cambio_actividad">Seleccione la actividad</asp:RequiredFieldValidator>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle Font-Size="X-Small" ForeColor="White" />
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Guardar">
                                                                                    <ItemTemplate>
                                                                                        <%--<asp:ImageButton ID="ibtnGActualizar" runat="server" CausesValidation="False" CommandName="Actualizar_estado" ImageUrl="~/IMG/checked.png" CssClass="boton_img" ToolTip="Habilitar usuario" />--%>
                                                                                        <asp:CheckBox ID="check_box" runat="server" Visible="false" OnClientClick="return false;" CssClass="left_check" AutoPostBack="false" />
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle Font-Size="X-Small" ForeColor="White" />
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="Fecha Cargue Documento">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="fecha_creacion" runat="server" CssClass="textoIzq" Text='<%# Eval("FECHA_CREACION") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>

                                                                                <asp:TemplateField HeaderText="ID Tipo archivo" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="id_tipo_actividad_archivo" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_TIPO_ACTIVIDAD_ARCHIVO") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>


                                                                    <div class="col-sm-12">
                                                                        <div class="row">
                                                                            <asp:Button ID="btn_guardar_documentos" runat="server" Visible="false" OnClick="btn_guardar_documentos_Click" Text="Guardar Seleccionados" CssClass="btn-block btn btn-success" AutoPostBack="true" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="guardar_archivo" />
                                        <asp:AsyncPostBackTrigger ControlID="LD_tipo_archivo" />
                                        <asp:AsyncPostBackTrigger ControlID="gv16" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModal3" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">

                                <asp:UpdatePanel runat="server" ID="UP_Detalle" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">

                                                <div class="panel panel-danger">

                                                    <div class="panel-heading">

                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        Bitácora
                                                    </div>
                                                    <div class="panel-body">

                                                        <div class="row">
                                                            <asp:Panel ID="Panel245" runat="server">
                                                                <asp:GridView ID="gv11" CssClass="mGrid  " runat="server" Style="margin-bottom: 4px; margin-top: 4px" OnRowCommand="gv11_RowCommand" OnRowDataBound="gv11_RowDataBound"
                                                                    llowPaging="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center">
                                                                    <%--OnRowCommand="gv11_RowCommand"--%>

                                                                    <AlternatingRowStyle CssClass="alt" />

                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="ID_ACTIVIDAD_DIA_BITACORA" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="ID_ACTIVIDAD_DIA_BITACORA" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_BITACORA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ID_ACTIVIDAD_DIA" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="ID_ACTIVIDAD_DIA" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="id_actividad_detalle_estado" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="id_actividad_detalle_estado" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DETALLE_ESTADO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="id_tipo_actividad" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="id_tipo_actividad" runat="server" Text='<%# Eval("id_tipo_actividad") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Detalles">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="tipo_actividad" runat="server" Text='<%# Eval("tipo_actividad") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Height="27px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Estado" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="actividad_detalle_estado" runat="server" Text='<%# Eval("ACTIVIDAD_DETALLE_ESTADO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Fecha">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Fecha_detalle" runat="server" Text='<%# Eval("FECHA_CREACION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Fecha actualiza">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Fecha_detalle_modifica" runat="server" Text='<%# Eval("FECHA_MODIFICA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Observación del detalle">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="descripcion_actividad_detalle" runat="server" Text='<%# Eval("DESCRIPCION_BITACORA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Usuario">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Usuario_creacion" runat="server" Text='<%# Eval("USUARIO_CREACION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderText="Acciones">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btn_actualizar_Bitacora" runat="server" CausesValidation="False" CommandName="Actualizar_bitacora" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar detalle de la actividad" Width="22px" />
                                                                                <asp:ImageButton ID="btn_eliminar_Bitacora" runat="server" CausesValidation="False" CommandName="Eliminar_bitacora" Width="22px" ImageUrl="~/IMG/Eliminar.png" ToolTip="Eliminar detalle de la actividad" />
                                                                                <%--<ajaxToolkit:ConfirmButtonExtender ID="eliminar_detalle_actividad" runat="server" ConfirmText="Esta seguro(a) de eliminar este registro?" TargetControlID="ibtnGEliminar" />--%>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>
                                                            </asp:Panel>

                                                            <asp:Label ID="L_Bitacora" runat="server" Text="" Visible="false" CssClass="text-warning"></asp:Label>
                                                        </div>


                                                        <asp:Panel ID="Panel242" CssClass="container-fluid" runat="server">
                                                            <div class="panel panel-default">
                                                                <div class="panel-body">

                                                                    <div class="form-group row" runat="server" visible="false">
                                                                        <label class="col-md-2 label1">Detalle</label>
                                                                        <div class="col-md-4">
                                                                            <asp:DropDownList ID="LD_tipo_actividad" runat="server" CssClass="form-control" AutoPostBack="True">
                                                                                <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                                                                <asp:ListItem Value="13">ESTRATEGIA DE RECUPERACIÓN EMOCIONAL A NIVEL GRUPAL</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator529" runat="server" ControlToValidate="LD_tipo_actividad"
                                                                                CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal"
                                                                                ValidationGroup="guardar_detalle">Seleccione el estado</asp:RequiredFieldValidator>
                                                                        </div>
                                                                        <label class="col-md-2 label1">Estado detalle</label>
                                                                        <div class="col-md-4">
                                                                            <asp:DropDownList ID="LD_estado_detalle" runat="server" CssClass="form-control"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator528" runat="server" ControlToValidate="LD_estado_detalle"
                                                                                CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal"
                                                                                ValidationGroup="guardar_detalle">Seleccione el estado</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label class="col-md-3 label1">Observación bitácora</label>

                                                                        <div class="col-md-9">
                                                                            <asp:TextBox ID="TB_actividad_detalle" runat="server" CssClass="form-control" Rows="3" placeholder="Seguimiento de las actividades y productos" MaxLength="300" TextMode="MultiLine"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                                                ControlToValidate="TB_actividad_detalle" CssClass="validador"
                                                                                Display="Dynamic" ValidationGroup="guardar_detalle">Campo obligatorio</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row col-md-4 col-md-offset-4">
                                                                        <asp:LinkButton ID="B_guardar_detalle" runat="server" CssClass="btn btn-danger btn-block" OnClick="B_guardar_detalle_Click" Text="Guardar" ValidationGroup="guardar_detalle">
                                                                                <span class="glyphicon  glyphicon-plus" aria-hidden="true"></span> Agregar 
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-md-12">

                                                                        <div class="col-md-3 col-md-offset-1">
                                                                            <asp:LinkButton ID="B_actualizar_detalle" Visible="false" runat="server" CssClass="btn btn-block btn-danger " OnClick="B_actualizar_detalle_Click" ValidationGroup="guardar_detalle">
                                                                                <span class="fas fa-edit"></span>&nbsp;Actualizar 
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-md-3 col-md-offset-3">
                                                                            <asp:LinkButton ID="B_CancelaDetalle" Visible="false" runat="server" CssClass="btn btn-block btn-warning " OnClick="B_CancelaDetalle_Click">
                                                                                <span class="glyphicon glyphicon glyphicon-remove-circle"></span>&nbsp;cancelar
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_guardar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_actualizar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_CancelaDetalle" />
                                        <asp:AsyncPostBackTrigger ControlID="LD_tipo_actividad" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                        <div class="modal fade" visible="false" id="myModalEnviarObservaion" role="dialog" aria-labelledby="myModalLabel" style="z-index: 150;" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;">
                            </div>
                            <div class="modal-dialog" style="width: 72%">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <asp:Label ID="Label4" runat="server" Visible="false" Text="0"></asp:Label>

                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title">
                                                    <asp:Label ID="L_titulo7" runat="server" Text=""></asp:Label></h4>
                                            </div>
                                            <div class="modal-body text-justify row">
                                                <asp:Label ID="L_mensaje7" CssClass="text-justify" runat="server" Text=""></asp:Label>

                                                <asp:Panel ID="Panel20" runat="server" CssClass="row">

                                                    <asp:GridView ID="GridView1" CssClass="footable mGrid" OnRowDataBound="GV_Solicitudes_RowDataBound" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Aprobar">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="C_Solicitud" runat="server" />
                                                                    <asp:Label ID="L_IdActividadDetalle" runat="server" Visible="false" Text='<%# Eval("ID_ACTIVIDAD_DETALLE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Estado Actual">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="L_EstadoActual" runat="server" Font-Size="11"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <%--<asp:BoundField DataField="" HeaderText="Estado Actual" />--%>
                                                            <asp:BoundField DataField="TIPO_ACTIVIDAD" HeaderText="Solicitud" />
                                                            <asp:BoundField DataField="DESCRIPCION_ACTIVIDAD_DETALLE" HeaderText="Descripción " />
                                                            <asp:BoundField DataField="FECHA_CREACION" HeaderText="Fecha solicitud" />
                                                            <asp:BoundField DataField="USUARIO_CREACION" HeaderText="Usuario " />
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>

                                                <asp:Label runat="server" ID="Label8" CssClass="text-danger"></asp:Label>


                                            </div>
                                            <div class="text-center">

                                                <div class="form-group row">
                                                    <label class=" col-md-2 col-md-offset-1 label1">Estado:</label>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="LD_Estado_actividad" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="LD_Estado_dia" CssClass="validador" Display="Dynamic"
                                                            InitialValue="0" Style="font-weight: normal" ValidationGroup="Confirmacion">Seleccione el nuevo estado</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <asp:Panel ID="Panel21" runat="server" Visible="true" class="form-group row">
                                                    <label class=" col-md-2 col-md-offset-1 label1">Observación:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox14" runat="server" Rows="9" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ControlToValidate="TB_ObCambio"
                                                            CssClass="validador" Display="Dynamic" ValidationGroup="Confirmacion">*</asp:RequiredFieldValidator>
                                                    </div>

                                                </asp:Panel>


                                                <asp:GridView ID="gv_actividad_detalle" CssClass="footable mGrid" runat="server" Style="margin-bottom: 4px; margin-top: 4px"
                                                    llowPaging="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center">
                                                    <AlternatingRowStyle CssClass="alt" />
                                                    <Columns>
                                                        <asp:BoundField DataField="DESCRIPCION_ACTIVIDAD_DETALLE" ItemStyle-HorizontalAlign="Center" HeaderText="Observación" />
                                                        <asp:TemplateField HeaderText="Estado Actual">
                                                            <ItemTemplate>
                                                                <asp:Label ID="L_usuario_creacion" runat="server" Text='<%# Eval("USUARIO_CREACION") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FECHA_CREACION" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha creación" />
                                                    </Columns>
                                                    <PagerStyle CssClass="pgr" />
                                                </asp:GridView>




                                                <%--<asp:CheckBox ID="CheckBox1" Visible="false" CssClass="text-warning" runat="server" Text="Aceptar"></asp:CheckBox>--%>
                                            </div>
                                            <div class="modal-footer">
                                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">cerrar</button>
                                                <asp:Label ID="Label9" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Label ID="Label10" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Label ID="Label11" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Button ID="B_CambiarEstadoActividad" runat="server" CssClass="btn btn-danger" Visible="true" Text="Continuar" ValidationGroup="Confirmacion" OnClick="B_CambiarEstadoActividad_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_Confirmacion_accion" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModal4" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">

                                <asp:UpdatePanel runat="server" ID="UP_Costos" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">

                                                <div class="panel panel-danger">

                                                    <div class="panel-heading">

                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        Costos
                                                    </div>
                                                    <div class="panel-body">

                                                        <div class="row">
                                                            <asp:Panel ID="Panel246" runat="server">
                                                                <asp:GridView ID="gv112" CssClass="mGrid  " runat="server" Style="margin-bottom: 4px; margin-top: 4px"
                                                                    llowPaging="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center">
                                                                    <%--OnRowCommand="gv11_RowCommand"--%>

                                                                    <AlternatingRowStyle CssClass="alt" />

                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="id_actividad_detalle" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="id_actividad_detalle" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_COSTO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="id_actividad" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="id_actividad_detalle2" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="id_actividad_detalle_estado" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="id_actividad_detalle_estado" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DETALLE_ESTADO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="id_tipo_actividad" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="id_tipo_actividad" runat="server" Text='<%# Eval("ID_TIPO_COSTO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Costo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Costo" runat="server" Text='<%# Eval("TIPO_COSTO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Height="27px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Proyección costo producto">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="L_Proyeccion" runat="server" Text='<%# Eval("COSTO_PROYECTADO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Costo Gestión producto">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="L_Gestion" runat="server" Text='<%# Eval("COSTO_EJECUTADO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <%--<asp:TemplateField HeaderText="Estado" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="actividad_detalle_estado" runat="server" Text='<%# Eval("ACTIVIDAD_DETALLE_ESTADO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Fecha">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Fecha_detalle" runat="server" Text='<%# Eval("FECHA_CREACION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <%--<asp:TemplateField HeaderText="Observación del detalle" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="descripcion_actividad_detalle" runat="server" Text='<%# Eval("descripcion_actividad_detalle") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>

                                                                        <asp:TemplateField HeaderText="Usuario">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Usuario_creacion" runat="server" Text='<%# Eval("USUARIO_CREACION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderText="Acciones" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="actualizar_detalle" runat="server" CausesValidation="False" CommandName="Actualizar_actividad_detalle" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar detalle de la actividad" Width="22px" />
                                                                                <asp:ImageButton ID="ibtnGEliminar" runat="server" CausesValidation="False" CommandName="Eliminar_actividad_detalle" Width="22px" ImageUrl="~/IMG/Eliminar.png" ToolTip="Eliminar detalle de la actividad" />
                                                                                <%--<ajaxToolkit:ConfirmButtonExtender ID="eliminar_detalle_actividad" runat="server" ConfirmText="Esta seguro(a) de eliminar este registro?" TargetControlID="ibtnGEliminar" />--%>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>


                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <div class="col-md-4 col-md-offset-1">
                                                                            <div class="form-group">
                                                                                <label class="sr-only" for="proye">Amount (in dollars)</label>
                                                                                <div class="input-group">
                                                                                    <div class="input-group-addon">Total proyección</div>
                                                                                    <div class="input-group-addon">$</div>
                                                                                    <asp:TextBox type="text" CssClass="form-control" ID="TB_Proy" runat="server" Enabled="false" Style="margin-left: 0px" placeholder="0"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-4 col-md-offset-1">
                                                                            <div class="form-group">
                                                                                <label class="sr-only" for="ges">Amount (in dollars)</label>
                                                                                <div class="input-group">
                                                                                    <div class="input-group-addon">Total gestion</div>
                                                                                    <div class="input-group-addon">$</div>
                                                                                    <asp:TextBox CssClass="form-control" ID="TB_Ges" Enabled="false" runat="server" Style="margin-left: 0px" placeholder="0"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>



                                                            </asp:Panel>


                                                            <asp:Label ID="L_Costos" runat="server" Text="" Visible="false" CssClass="text-warning"></asp:Label>
                                                        </div>

                                                        <asp:Panel ID="P_GurdarCostos" runat="server" class="panel panel-default">



                                                            <div class="row">
                                                                <div class="col-md-3 col-md-offset-3">
                                                                    <p class="">Tipo de costo</p>
                                                                </div>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="LD_TipoCostos" runat="server" CssClass="form-control">
                                                                        <%--<asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                                        <asp:ListItem Value="Logístico">Logístico</asp:ListItem>
                                                                        <asp:ListItem Value="Plan de adquisiciones">Plan de adquisiciones</asp:ListItem>
                                                                        <asp:ListItem Value="Viáticos y comisiones">Viáticos y comisiones</asp:ListItem>
                                                                        <asp:ListItem Value="Otros">Otros</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LD_TipoCostos" CssClass="validador" Display="Dynamic"
                                                                        InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_costos">Seleccione</asp:RequiredFieldValidator>



                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-3 col-md-offset-3">
                                                                    <p class="">Proyección costo producto </p>
                                                                </div>
                                                                <div class="col-md-3">

                                                                    <div class="input-group">
                                                                        <span class="input-group-addon">$</span>
                                                                        <asp:TextBox ID="TB_Proyeccion" runat="server" Text="0" Style="margin-left: 0px;" CssClass="form-control">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TB_Proyeccion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_costos">*</asp:RequiredFieldValidator>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TB_Proyeccion" ValidChars="0123456789" Enabled="True" />
                                                                </div>


                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-3 col-md-offset-3">
                                                                    <p class="">Costo Gestión producto</p>
                                                                </div>
                                                                <div class="col-md-3">

                                                                    <div class="input-group">
                                                                        <span class="input-group-addon">$</span>
                                                                        <asp:TextBox ID="TB_Gestion" runat="server" Style="margin-left: 0px;" CssClass="form-control">
                                                                        </asp:TextBox>
                                                                    </div>

                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator170" runat="server" Text="0" ControlToValidate="TB_Gestion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_costos">*</asp:RequiredFieldValidator>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server" TargetControlID="TB_Gestion"
                                                                        ValidChars="0123456789" Enabled="True" />
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="row col-md-4 col-md-offset-4">
                                                                    <asp:LinkButton ID="B_GCostos" runat="server" CssClass="btn btn-danger btn-block" OnClick="B_GCostos_Click" Text="Guardar" ValidationGroup="guardar_costos">
                                                                                <span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span> Guardar 
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </div>



                                                        </asp:Panel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                        <div class="modal fade" visible="false" id="myModal5" role="dialog" aria-labelledby="myModalLabel" style="z-index: 150;" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog" style="width: 72%">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <asp:Label ID="Label1" runat="server" Visible="false" Text="0"></asp:Label>

                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title">
                                                    <asp:Label ID="L_Titulo3" runat="server" Text=""></asp:Label></h4>
                                            </div>
                                            <div class="modal-body text-justify row">
                                                <asp:Label ID="L_mensaje3" CssClass="text-justify" runat="server" Text=""></asp:Label>

                                                <asp:Panel ID="P_Solicitudes" runat="server" CssClass="row">

                                                    <asp:Label ID="L_CambioEstado" runat="server" CssClass="text-danger" Text="No hay solicitudes de cambio de estados pendientes por validación."></asp:Label>


                                                    <asp:GridView ID="GV_Solicitudes" CssClass="footable mGrid" OnRowDataBound="GV_Solicitudes_RowDataBound" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Aprobar">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="C_Solicitud" runat="server" />
                                                                    <asp:Label ID="L_IdActividadDetalle" runat="server" Visible="false" Text='<%# Eval("ID_ACTIVIDAD_DETALLE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Estado Actual">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="L_EstadoActual" runat="server" Font-Size="11"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <%--<asp:BoundField DataField="" HeaderText="Estado Actual" />--%>
                                                            <asp:BoundField DataField="TIPO_ACTIVIDAD" HeaderText="Solicitud" />
                                                            <asp:BoundField DataField="DESCRIPCION_ACTIVIDAD_DETALLE" HeaderText="Descripción " />
                                                            <asp:BoundField DataField="FECHA_CREACION" HeaderText="Fecha solicitud" />
                                                            <asp:BoundField DataField="USUARIO_CREACION" HeaderText="Usuario " />
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>

                                                <asp:Label runat="server" ID="L_Solicitud" CssClass="text-danger"></asp:Label>


                                            </div>
                                            <div class="text-center">

                                                <div class="form-group row">
                                                    <label class=" col-md-2 col-md-offset-1 label1">Estado:</label>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="LD_Estado_dia" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LD_Estado_dia" CssClass="validador" Display="Dynamic"
                                                            InitialValue="0" Style="font-weight: normal" ValidationGroup="Confirmacion">Seleccione el nuevo estado</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <asp:Panel ID="P_ObEstado" runat="server" Visible="false" class="form-group row">
                                                    <label class=" col-md-2 col-md-offset-1 label1">Observación:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TB_ObCambio" runat="server" Rows="9" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_ObCambio"
                                                            CssClass="validador" Display="Dynamic" ValidationGroup="Confirmacion">*</asp:RequiredFieldValidator>
                                                    </div>

                                                </asp:Panel>


                                                <%--<asp:CheckBox ID="CheckBox1" Visible="false" CssClass="text-warning" runat="server" Text="Aceptar"></asp:CheckBox>--%>
                                            </div>
                                            <div class="modal-footer">
                                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">cerrar</button>
                                                <asp:Label ID="Vari1" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Label ID="Vari2" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Label ID="Vari3" runat="server" Visible="false" Text=""></asp:Label>
                                                <asp:Button ID="B_CambiarEstado" runat="server" CssClass="btn btn-danger" Visible="true" Text="Continuar" ValidationGroup="Confirmacion" OnClick="B_CambiarEstado_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_Confirmacion_accion" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModal7" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">

                                <asp:UpdatePanel runat="server" ID="UpdatePanelDirectorio" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">

                                                <div class="panel panel-danger">

                                                    <div class="panel-heading">

                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        Directorio Sujeto
                                                    </div>
                                                    <div class="panel-body">

                                                        <div class="row">
                                                            <asp:Panel ID="Panel14" runat="server">
                                                                <asp:GridView ID="gv_directorio_sujeto" CssClass="mGrid  " runat="server" Style="margin-bottom: 4px; margin-top: 4px"
                                                                    llowPaging="True" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Center" OnRowCommand="gv_directorio_sujeto_RowCommand">


                                                                    <AlternatingRowStyle CssClass="alt" />

                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="id_directorio" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="ID_DIRECTORIO" runat="server" Text='<%# Eval("ID_DIRECTORIO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="id_sujeto_colectiva" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="ID_SUJETO_COLECTIVA" runat="server" Text='<%# Eval("ID_SUJETO_COLECTIVA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Entidad" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="ENTIDAD" runat="server" Text='<%# Eval("ENTIDAD") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Tipo de contacto" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="TIPO_CONTACTO_COLECTIVA" runat="server" Text='<%# Eval("TIPO_CONTACTO_COLECTIVA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ID Tipo de contacto" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="ID_TIPO_CONTACTO_COLECTIVA" runat="server" Text='<%# Eval("ID_TIPO_CONTACTO_COLECTIVA") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Nombre" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="NOMBRE" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cargo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="CARGO" runat="server" Text='<%# Eval("CARGO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Height="27px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Email" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="email" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Telefono" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="TELEFONO" runat="server" Text='<%# Eval("TELEFONO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Fecha" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="FECHA_CREACION" runat="server" Text='<%# Eval("FECHA_CREACION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Estado Directirio" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="ESTADO_DIRECTORIO" runat="server" Text='<%# Eval("ESTADO_DIRECTORIO") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Usuario" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="USUARIO_CREACION" runat="server" Text='<%# Eval("USUARIO_CREACION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>



                                                                        <asp:TemplateField HeaderText="Acciones" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="actualizar_detalle" runat="server" CausesValidation="False" CommandName="Actualizar_Directorio" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar Directorio" Width="22px" />
                                                                                <asp:ImageButton ID="ibtnGEliminar" runat="server" CausesValidation="False" CommandName="Eliminar_Directorio" Width="22px" ImageUrl="~/IMG/Eliminar.png" ToolTip="Eliminar Directorio" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="pgr" />
                                                                </asp:GridView>


                                                                <div class="row">
                                                                    <asp:LinkButton ID="Agregar_contacto" runat="server" CssClass="btn-block btn btn-danger"
                                                                        OnClick="B_Agregar_Agregar_contacto">
                                                                    <span class="fas fa-plus" aria-hidden="true"></span> Agregar contacto 
                                                                    </asp:LinkButton>
                                                                </div>
                                                                <div class="row">
                                                                    <asp:Button ID="EXCEL" runat="server" CssClass="btn-block btn btn-success" OnClick="EXCEL_Click" Text="Excel" Visible="true" />
                                                                </div>

                                                            </asp:Panel>
                                                            <asp:Panel ID="Panel19" runat="server" Visible="false">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Entidad 
                                                                <asp:TextBox ID="TB_Entidad" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="TB_Entidad"
                                                                            ValidChars="0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ ,.()" Enabled="True" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="TB_Entidad" CssClass="validador" Display="Dynamic" ValidationGroup="agregar">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Nombre 
                                                                <asp:TextBox ID="TB_Nombre" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="TB_Nombre"
                                                                            ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ " Enabled="True" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="TB_Nombre" CssClass="validador" Display="Dynamic" ValidationGroup="agregar">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Cargo
                                                               <asp:TextBox ID="TB_Cargo" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="TB_Nombre"
                                                                            ValidChars="0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ_-(),. " Enabled="True" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server" ControlToValidate="TB_Cargo" CssClass="validador" Display="Dynamic" ValidationGroup="agregar">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Numero de telefono
                                                               <asp:TextBox ID="TB_Telefono" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="TB_Telefono" ValidChars="0123456789- " Enabled="True" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ControlToValidate="TB_Telefono" CssClass="validador" Display="Dynamic" ValidationGroup="agregar">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Email
                                                               <asp:TextBox ID="TB_Mail" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TB_Mail" CssClass="validador" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Formato de E-Mail incorrecto</asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Tipo de contacto
                                                                    <asp:DropDownList ID="LD_Tipo_contacto" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" InitialValue="0" ControlToValidate="LD_Tipo_contacto" CssClass="validador" Display="Dynamic" ValidationGroup="agregar">El campo es obligatorio</asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <asp:LinkButton ID="Guardar_contacto" runat="server" CssClass="btn-block btn btn-danger"
                                                                        OnClick="B_Guardar_contacto" ValidationGroup="agregar">
                                                                    <span class="fas fa-plus" aria-hidden="true"></span> Guardar contacto 
                                                                    </asp:LinkButton>
                                                                </div>

                                                                <div class="row">
                                                                    <asp:LinkButton ID="Actualizar_Contacto" runat="server" Visible="false" CssClass="btn-block btn btn-danger"
                                                                        OnClick="B_Actualizar_Contacto" ValidationGroup="agregar">
                                                                    <span class="fas fa-plus" aria-hidden="true"></span> Actualizar contacto 
                                                                    </asp:LinkButton>
                                                                </div>

                                                                <div class="row">
                                                                    <asp:LinkButton ID="B_Limpiar_Contactos" runat="server" CssClass="btn-block btn btn-danger"
                                                                        OnClick="B_Limpiar_contactos">
                                                                    <span class="fas fa-plus" aria-hidden="true"></span> Limpiar datos 
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Label ID="Label2" runat="server" Text="" Visible="false" CssClass="text-warning"></asp:Label>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_guardar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_actualizar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_CancelaDetalle" />
                                        <asp:AsyncPostBackTrigger ControlID="LD_tipo_actividad" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModal6" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">

                                <asp:UpdatePanel runat="server" ID="UpdatePanel5" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">

                                                <div class="panel panel-danger">

                                                    <div class="panel-heading">

                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        Actividad - Medida/Producto
                                                    </div>
                                                    <div class="panel-body">


                                                        <asp:Panel ID="Panel16" CssClass="container-fluid" runat="server">
                                                            <div class="panel panel-default">
                                                                <div class="panel-body">

                                                                    <div class="form-group row">
                                                                        <label class=" col-md-2 col-md-offset-1 label1" runat="server" visible="false" id="label_tipo_medida">Medida:</label>
                                                                        <div class="col-md-4">
                                                                            <asp:DropDownList ID="LD_tipo_medida" runat="server" Visible="false" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="LD_tipo_medida" CssClass="validador" Display="Dynamic"
                                                                                InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_detalle2">Seleccione el tipo de medida</asp:RequiredFieldValidator>--%>
                                                                        </div>
                                                                    </div>

                                                                    <div class="form-group row">
                                                                        <label class="col-md-3 label1" runat="server" visible="false" id="label6">Nuevo producto?</label>

                                                                        <div class="col-md-9">
                                                                            <div class="row">
                                                                                <asp:RadioButtonList runat="server" Visible="false" RepeatDirection="Horizontal" RepeatLayout="Flow" ID="RB_Producto" AutoPostBack="true" CssClass="radiojose2" OnSelectedIndexChanged="RB_Producto_SelectedIndexChanged">

                                                                                    <asp:ListItem Value="si" Selected="True" Text="Si"> Si</asp:ListItem>
                                                                                    <asp:ListItem Value="no" Text="No"> No</asp:ListItem>

                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                    <div class="form-group row">
                                                                        <label class="col-md-3 label1" runat="server" id="label5" visible="false">Producto</label>

                                                                        <div class="col-md-9">
                                                                            <asp:DropDownList ID="LD_productos" runat="server" Visible="false" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </div>

                                                                    </div>

                                                                    <div class="form-group row">
                                                                        <label class="col-md-3 label1" runat="server" id="label_medida_producto">Producto</label>

                                                                        <div class="col-md-9">
                                                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control" Rows="3" placeholder="Descripcion de la medida / producto" MaxLength="300" TextMode="MultiLine"></asp:TextBox>
                                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server"
                                                                                ControlToValidate="TextBox12" CssClass="validador"
                                                                                Display="Dynamic" ValidationGroup="guardar_detalle2">Campo obligatorio</asp:RequiredFieldValidator>--%>
                                                                        </div>

                                                                    </div>
                                                                    <div class="form-group row">
                                                                        <label class="col-md-3 label1">Actividades</label>
                                                                        <div class="col-md-9">
                                                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control" Rows="3" placeholder="Descripcion de la actividad" MaxLength="300" TextMode="MultiLine"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                                                ControlToValidate="TextBox13" CssClass="validador"
                                                                                Display="Dynamic" ValidationGroup="guardar_detalle2">Campo obligatorio</asp:RequiredFieldValidator>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row col-md-4 col-md-offset-4">
                                                                        <asp:LinkButton ID="B_guardar_actividad_c" runat="server" CssClass="btn btn-danger btn-block" OnClick="B_guardar_actividad_c_Click" Text="Guardar" ValidationGroup="guardar_detalle2">
                                                                                <span class="glyphicon  glyphicon-plus" aria-hidden="true"></span> Agregar 
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                    <div class="col-md-12">

                                                                        <div class="col-md-3 col-md-offset-1">
                                                                            <asp:LinkButton ID="B_actualizar_actividad_c" Visible="false" runat="server" CssClass="btn btn-block btn-danger " OnClick="B_actualizar_actividad_c_Click" ValidationGroup="guardar_detalle2">
                                                                                <span class="fas fa-edit"></span>&nbsp;Actualizar 
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                        <div class="col-md-3 col-md-offset-3">
                                                                            <asp:LinkButton ID="B_cancelar_actividad_c" Visible="false" runat="server" CssClass="btn btn-block btn-warning " OnClick="B_CancelaDetalle_Click">
                                                                                <span class="glyphicon glyphicon glyphicon-remove-circle"></span>&nbsp;cancelar
                                                                            </asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_guardar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_actualizar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_CancelaDetalle" />
                                        <asp:AsyncPostBackTrigger ControlID="LD_tipo_actividad" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalobserEstSuj" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">

                                <asp:UpdatePanel runat="server" ID="UpdatePanel7" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">

                                                <div class="panel panel-danger">

                                                    <div class="panel-heading">

                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        Observación estado sujeto
                                                    </div>
                                                    <div class="panel-body">


                                                        <asp:Panel ID="Panel23" CssClass="container-fluid" runat="server">
                                                            <div class="panel panel-default">
                                                                <div class="panel-body">


                                                                    <div class="form-group row">
                                                                        <label class="col-md-3 label1">Observación estado sujeto</label>

                                                                        <div class="col-md-9">
                                                                            <asp:TextBox ID="TB_obs_estado_sujeto" runat="server" CssClass="form-control" Rows="3" placeholder="Seguimiento a los sujetos" MaxLength="600" TextMode="MultiLine"></asp:TextBox>

                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-12">

                                                                        <div class="col-md-3 col-md-offset-1">
                                                                            <asp:LinkButton ID="B_actualizar_obserEstSuj" Visible="true" runat="server" CssClass="btn btn-block btn-danger " OnClick="B_actualizar_obserEstSuj_Click">
                                                                                <span class="fas fa-edit"></span>&nbsp;Actualizar 
                                                                            </asp:LinkButton>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="B_guardar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_actualizar_detalle" />
                                        <asp:AsyncPostBackTrigger ControlID="B_CancelaDetalle" />
                                        <asp:AsyncPostBackTrigger ControlID="LD_tipo_actividad" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>


                        <%--modulo administrar sujeto colectivo--%>
                        <asp:UpdatePanel ID="UP_DatosSujetos" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="row center-block text-center" runat="server" visible="false" id="D_Sujetos">
                                        <h4>
                                            <asp:Label ID="L_Sujetos" runat="server" CssClass="label label-default" Text="" />
                                        </h4>
                                    </div>

                                    <asp:GridView UseAccessibleHeader="true" CssClass="table mGrid" ID="gv"
                                        runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_RowDataBound"
                                        OnRowCommand="gv_RowCommand" OnPreRender="gv_PreRender" AlternatingRowStyle-CssClass="alt">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Puntaje" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_PUNTAJE_PRIO" runat="server" CssClass="textoIzq" Text='<%# Eval("PUNTAJE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="id_src" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_RYR_COMUNIDAD" runat="server" CssClass="textoIzq" Text='<%# Eval("ID_RYR_COMUNIDAD") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Alcance" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_ALCANCE" runat="server" CssClass="textoIzq" Text='<%# Eval("ALCANCE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Zona" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="zona" runat="server" CssClass="textoIzq" Text='<%# Eval("zona") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="NIT" runat="server" CssClass="textoIzq" Text='<%# Eval("NIT") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="ESTADO_RUV" HeaderText="Estado ruv" Visible="false" />

                                            <asp:TemplateField HeaderText="DT" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_DT" runat="server" CssClass="textoIzq" Text='<%# Eval("TERRITORIO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Departamento" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_DEPARTAMENTO" runat="server" CssClass="textoIzq" Text='<%# Eval("DEPARTAMENTO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Municipio" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_MUNICIPIO" runat="server" CssClass="textoIzq" Text='<%# Eval("MUNICIPIO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tipo de Comunidad">
                                                <ItemTemplate>
                                                    <asp:Label ID="TIPO_RYR_COMUNIDAD" runat="server" CssClass="textoIzq" Text='<%# Eval("TIPO_RYR_COMUNIDAD") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="207px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comunidad R y R">
                                                <ItemTemplate>
                                                    <asp:Label ID="NOMBRE_RYR_COMUNIDAD" runat="server" CssClass="textoIzq" Text='<%# Eval("NOMBRE_RYR_COMUNIDAD") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estado" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="ESTADO_RYR_COMUNIDAD" runat="server" CssClass="textoIzq" Text='<%# Eval("ESTADO_RYR_COMUNIDAD") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fase" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="fase_colectiva" runat="server" CssClass="textoIzq" Text='<%# Eval("fase") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="126px" />
                                            </asp:TemplateField>

                                            <%--<asp:BoundField  DataField="avance" HeaderText="Avance fase actual"  ItemStyle-Width="76px" />--%>


                                            <%--<asp:TemplateField HeaderText="Avance fase actual">
                                                <ItemTemplate>
                                                    <asp:Label ID="sc_avance" runat="server" CssClass="textoIzq" Text='<%# Eval("avance") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="75px" HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>




                                            <asp:TemplateField HeaderText="Asignación" Visible="false">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibtnGAsignacion" runat="server" CausesValidation="False" CommandName="Asignacion" ImageUrl="~/IMG/user-group-new.PNG" Width="20px" ToolTip="Asignación a usuarios" />
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="AsignacionP" ImageUrl="~/IMG/personas_a.PNG" Width="20px" ToolTip="Individuos" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Acciones">
                                                <ItemTemplate>

                                                    <asp:Label ID="L_alerta" Visible="false" runat="server" Text='<%# Eval("alerta") %>'> </asp:Label>
                                                    <center>
                                                
                                                
                                                <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px;padding-top: 6px;">

                                                    <asp:LinkButton ID="B_fases_colectiva" runat="server" CssClass="btn btn-default  " CausesValidation="False" Style="color: cadetblue; font-size:1px" CommandName="fases_colectiva" ToolTip="Fases Comunidad" >
                                                   <%--<span class="glyphicon glyphicon-retweet" aria-hidden="true"></span>--%><%--<span class="badge">4</span>--%>
                                                        <span class="glyphicon" aria-hidden="true" style="padding-right: 5%;">Fases</span>
                                                        <span class="glyphicon glyphicon-tasks" aria-hidden="true"></span>
                                                        <%--<span class="glyphicon glyphicon-sort-by-attributes-alt" aria-hidden="true"></span>
                                                        <span class="fa fa-cubes" aria-hidden="true"></span>--%>

                                                    </asp:LinkButton>
                                                    
                                                    <asp:Panel id="D_bell" runat="server" Visible="false" CssClass="alertabell"
                                                        style=" color:red ; font-size:18px;position: absolute;left: -7px;z-index: 10;animation-name: mover;animation-duration: 5s;animation-iteration-count: infinite; " >
                                                    <span class="fas fa-bell" aria-hidden="true">
                                                    </asp:Panel>

                                                    
                                                    <asp:LinkButton ID="ibtnGActualizar" runat="server" CssClass="btn btn-default " CausesValidation="False" Style="color: cadetblue; font-size:19px" CommandName="Actualizar" ToolTip="Actualizar">
                                                   <span class="fas fa-edit" aria-hidden="true"><%--<span class="glyphicon glyphicon-pencil" aria-hidden="true">--%><%--</span><span class="badge">4</span>--%>
                                                    </asp:LinkButton>

                                                      <asp:LinkButton ID="ibtnDirectorio" runat="server" CssClass="btn btn-default " CausesValidation="False" Style="color: cadetblue; font-size:19px" CommandName="Directorio" ToolTip="Directorio">
                                                   <span class="fas fa-phone" aria-hidden="true"><%--<span class="glyphicon glyphicon-pencil" aria-hidden="true">--%><%--</span><span class="badge">4</span>--%>
                                                    </asp:LinkButton>


                                                    <asp:LinkButton ID="Evidencias" runat="server"  CssClass="btn btn-default " CausesValidation="False" Style="color: cadetblue" CommandName="Evidencias" ToolTip="Evidencias" Visible="false">
                                                   <span class="far fa-folder-open" aria-hidden="true"></span><%--<span class="badge">4</span>--%>
                                                    </asp:LinkButton>
                                                        
                                                </div>
                                            </center>

                                                    <%--<asp:ImageButton ID="B_fases_colectiva" runat="server" CausesValidation="False" CommandName="fases_colectiva" ImageUrl="~/Img/ciclos.png" Width="25px" ToolTip="Fases colectiva" />--%>
                                                    <%--<asp:ImageButton ID="ibtnGActualizar" runat="server" CausesValidation="False" CommandName="Actualizar" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar" Width="22px" />--%>
                                                    <%--<asp:ImageButton ID="Evidencias" runat="server" CausesValidation="False" CommandName="Evidencias" ImageUrl="~/IMG/documentacion.png" ToolTip="Evidencias" Width="22px"></asp:ImageButton>--%>
                                                </ItemTemplate>
                                                <ItemStyle Width="180px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pgr" />
                                    </asp:GridView>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                        <%--modulo administrar actividades--%>
                        <asp:UpdatePanel ID="UP_ResultadoBusqueda" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row">
                                    <asp:Panel ID="Panel232" runat="server" ScrollBars="Auto" Visible="False">

                                        <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" ID="gv_actividad"
                                            runat="server" AutoGenerateColumns="False" DataKeyNames="ID_ACTIVIDAD"
                                            OnRowCommand="gv_actividad_RowComman" OnRowDataBound="gv_actividad_RowDataBound"
                                            AllowPaging="True" OnPageIndexChanging="gv_actividad_PageIndexChanging">

                                            <Columns>
                                                <asp:BoundField DataField="ID_ACTIVIDAD" HeaderText="Id plan" Visible="false" />
                                                <asp:BoundField DataField="DESCRIPCION_ACTIVIDAD" HeaderText="Nombre" />
                                                <asp:BoundField DataField="NOMBRE_ACTIVIDAD" HeaderText="Nombre actividad" />
                                                <asp:BoundField DataField="FECHA_CREACION" HeaderText="Fecha creación" Visible="false" />
                                                <asp:BoundField DataField="ACTIVIDAD_ESTADO" HeaderText="Estado" Visible="false" />
                                                <asp:BoundField DataField="TOTAL PERSONA" HeaderText="Total personas" Visible="false" />
                                                <asp:BoundField DataField="LISTADOS DE ASISTENCIA" HeaderText="Total listas de asistencia" Visible="false" />
                                                <asp:BoundField DataField="TIPO_LISTA" HeaderText="Tipo listas" Visible="false" />
                                                <asp:BoundField DataField="RESPONSABLES" HeaderText="Responsables" Visible="false" />
                                                <asp:BoundField DataField="DIAS" HeaderText="Total días" Visible="false" />
                                                <asp:BoundField DataField="ARCHIVO ACTIVIDAD" HeaderText="Total de Archivos" />
                                                <asp:TemplateField HeaderText="Avance" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="avance" runat="server" Text='<%# Eval("LIMITE_PERSONAS") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Acciones">
                                                    <ItemTemplate>
                                                        <%--<asp:ImageButton ID="ver" runat="server" Visible="true" CausesValidation="False" CommandName="Ver" ImageUrl="~/IMG/consultar.PNG" ToolTip="Consultar" Width="22px" />--%>


                                                        <div class="btn-group" role="group" aria-label="...">

                                                            <asp:LinkButton ID="actualizar" runat="server" Visible="false" CssClass="btn btn-default" CausesValidation="False" Style="color: cadetblue" CommandName="Actualizar">
                                                                    <span class="fas fa-edit" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="ver" runat="server" Visible="false" CssClass="btn btn-default" CausesValidation="False" Style="color: darkgreen" CommandName="Ver">
                                                                    <span class="fas fa-search" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="Archivos_fase" runat="server" Visible="true" CssClass="btn btn-default" CausesValidation="False" Style="color: rgb(1, 70, 144)" CommandName="Archivos_fase" ToolTip="Archivos fase">
                                                                    <span class="glyphicon glyphicon-folder-open" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="enviar_comentario" runat="server" Visible="true" CssClass="btn btn-default" CausesValidation="False" Style="color: rgb(1, 70, 144)" CommandName="enviar_comentario" ToolTip="cambio fase">
                                                                    <span class="glyphicon glyphicon-envelope" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                            </asp:LinkButton>

                                                            <asp:Label ID="L_Alerta" runat="server" Text='<%# Eval("alerta") %>' Visible="false"> </asp:Label>
                                                            <asp:Panel ID="D_bell" runat="server" CssClass="alertabell"
                                                                Style="color: red; font-size: 18px; position: absolute; left: -7px; top: 1px; z-index: 10; animation-name: mover; animation-duration: 5s; animation-iteration-count: infinite;">
                                                                <span class="fas fa-bell" aria-hidden="true">
                                                            </asp:Panel>

                                                        </div>



                                                        <%--<asp:ImageButton ID="actualizar" runat="server" Visible="true" CausesValidation="False" CommandName="Actualizar" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar actividad" Width="22px" />--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Estado">
                                                    <ItemTemplate>

                                                        <div class="btn-group btn-sm" role="group" aria-label="...">
                                                            <asp:LinkButton ID="E_Activo" runat="server" Visible="true" CssClass="btn btn-default  btn-sm" CausesValidation="False" CommandName="F_Activo" Style="color: rgb(156, 151, 151)" ToolTip="Activo">
                                                                    <span class="fa fa-lock-open" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                            </asp:LinkButton>

                                                            <asp:LinkButton ID="E_Inactivo" runat="server" Visible="true" CssClass="btn btn-default btn-sm" CausesValidation="False" CommandName="F_Inactivo" Style="color: rgb(156, 151, 151)" ToolTip="Aprobado">
                                                                    <span class="fa fa-lock" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                            </asp:LinkButton>

                                                        </div>

                                                        <asp:LinkButton ID="LB_CambioFase" runat="server" Visible="false" CssClass="btn btn-link" CausesValidation="False" CommandName="Cambio_fase" ToolTip="Cambio fase" Style="color: black">
                                                                    <span class="far fa-star" aria-hidden="true"><%--</span><span class="badge">4</span>--%>

                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LB_FaseActual" runat="server" Visible="false" CssClass="btn btn-link" CausesValidation="False" Style="color: yellowgreen" ToolTip="Fase actual">
                                                                    <span class="fas fa-star" aria-hidden="true"><%--</span><span class="badge">4</span>--%>

                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="138px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="id_nombre_actividad" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="id_actividad" runat="server" Text='<%# Eval("id_actividad") %>'> </asp:Label>
                                                        <asp:Label ID="id_nombre_actividad" runat="server" Text='<%# Eval("ID_NOMBRE_ACTIVIDAD") %>'> </asp:Label>
                                                        <asp:Label ID="fase_actividad" runat="server" Text='<%# Eval("NOMBRE_ACTIVIDAD") %>'> </asp:Label>
                                                        <asp:Label ID="fase_colectiva" runat="server" Text='<%# Eval("DESCRIPCION_ACTIVIDAD_NOMBRE") %>'> </asp:Label>
                                                        <asp:Label ID="id_actividad_estado" runat="server" Text='<%# Eval("id_actividad_estado") %>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <%--<asp:PostBackTrigger ControlID="gv" />--%>
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:HiddenField ID="hf_id_nombre_actividad" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <asp:UpdatePanel ID="UP_DatosEvento" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel241" runat="server" Visible="False">
                                        <div class="panel panel-default" style="">


                                            <div class="panel-heading" style="background-color: rgb(253,170,41)">
                                                <asp:Literal runat="server" ID="L_titulo"> </asp:Literal>
                                            </div>
                                            <div class="panel-body">
                                                <div id="Tabs" role="tabpanel">
                                                    <!-- Nav tabs -->
                                                    <%--------------------------------------------------------%>
                                                    <%--aqui se deben agregar los nuevos tabs da desarrollar--%>
                                                    <%--------------------------------------------------------%>
                                                    <ul class="nav2 nav2-tabs pestana" role="tablist">
                                                        <li id="m_2" runat="server"><a href="#ContentPlaceHolder1_Responsables" aria-controls="Responsables" role="tab" data-toggle="tab">Responsables</a></li>
                                                        <li id="m_4" runat="server"><a href="#ContentPlaceHolder1_Dias" aria-controls="Dias" role="tab" data-toggle="tab">Acciones </a></li>
                                                        <li id="m_Ficha" runat="server" class="active"><a href="#ContentPlaceHolder1_ficha" aria-controls="ficha" role="tab" data-toggle="tab">Ficha de Caracterización</a></li>
                                                        <li id="m_PlanTraslado" runat="server" class="active"><a href="#ContentPlaceHolder1_plan_traslado" aria-controls="plan_traslado" role="tab" data-toggle="tab">Plan de acción del traslado </a></li>
                                                        <li id="m_PlanRyR" runat="server" class="active"><a href="#ContentPlaceHolder1_plan_ryr" aria-controls="ficha" role="tab" data-toggle="tab">Plan de Retorno y Reubicación</a></li>
                                                        <li id="m_Balance" runat="server"><a href="#ContentPlaceHolder1_balance" aria-controls="balance" role="tab" data-toggle="tab">Balance </a></li>
                                                    </ul>
                                                    <!-- Tab panes -->
                                                    <div class="tab-content" style="padding-top: 20px">

                                                        <asp:HiddenField ID="hidIdSujetoCol" runat="server" />
                                                        <%--primer tab de responsables--%>
                                                        <div role="tabpanel" class="tab-pane" id="Responsables" runat="server">
                                                            <asp:UpdatePanel runat="server" ID="UP_Responsable" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="Panel243" CssClass="container-fluid" runat="server">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Grupo de trabajo
                                                                            </div>
                                                                            <div class="panel-body">

                                                                                <div class="row">
                                                                                    <asp:GridView ID="gv12" CssClass="footable mGrid " Style="margin-bottom: 4px; margin-top: 4px" runat="server" AllowPaging="false"
                                                                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" HorizontalAlign="Center" OnRowCommand="gv12_RowCommand" OnRowDataBound="gv12_RowDataBound">
                                                                                        <AlternatingRowStyle BackColor="White" CssClass="alt" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="id_actividad_responsable" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="id_actividad_responsable" runat="server" Text='<%# Eval("id_actividad_responsable") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_actividad" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="id_actividad" runat="server" Text='<%# Eval("id_actividad") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Identificación" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="identificacion_responsable" runat="server" Text='<%# Eval("identificacion") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_tipo_identificacion" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="id_tipo_identificacion" runat="server" Text='<%# Eval("id_tipo_identificacion") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Tipo identificación" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="tipo_identificacion" runat="server" Text='<%# Eval("tipo_identificacion") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Nombre">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="nombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Apellido">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="apellido" runat="server" Text='<%# Eval("apellidos") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_actividad_rol" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="id_actividad_rol" runat="server" Text='<%# Eval("id_actividad_rol") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Email" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="email_responsable" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Teléfono" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="telefono_movil" runat="server" Text='<%# Eval("telefono_movil") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Rol">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="actividad_rol" runat="server" Text='<%# Eval("actividad_rol") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Dirección Territorial" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="D_territorial" runat="server" Text='<%# Eval("TER_CTERRITORIO") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Fecha de inicio de acompañamiento " Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="f_acompanamiento" runat="server" Text='<%# Eval("FECHA_CREACION") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Tipo de vinculación" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="vinculacion" runat="server" Text='<%# Eval("TIPO_VINCULACION") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ibtnGEliminar" CausesValidation="true" runat="server" CommandName="Eliminar_actividad_responsable" Width="22px" ImageUrl="~/IMG/Eliminar.png" ToolTip="Eliminar" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <PagerStyle CssClass="pgr" />
                                                                                    </asp:GridView>

                                                                                    <asp:Label ID="L_Responsables" runat="server" Text="" Visible="false" CssClass="text-warning"></asp:Label>
                                                                                </div>


                                                                                <asp:Panel ID="Panel244" runat="server" CssClass="row">
                                                                                    <div class="panel panel-default">
                                                                                        <div class="panel-body">

                                                                                            <div class="form-group row">
                                                                                                <label class=" col-md-2 label1">Usuario</label>
                                                                                                <div class="col-md-4">
                                                                                                    <asp:DropDownList ID="LD_usuario" runat="server" CssClass="form-control">
                                                                                                    </asp:DropDownList>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="LD_usuario" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_responsable">Seleccione el rol</asp:RequiredFieldValidator>

                                                                                                </div>
                                                                                                <label class="col-md-2 label1">Rol</label>
                                                                                                <div class="col-md-4">
                                                                                                    <asp:DropDownList ID="LD_rol_responsable" runat="server" CssClass="form-control">
                                                                                                    </asp:DropDownList>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator537" runat="server" ControlToValidate="LD_rol_responsable" CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_responsable">Seleccione el rol</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="row col-md-4 col-md-offset-4">
                                                                                                    <asp:LinkButton ID="B_guardar_responsable" runat="server" CssClass="btn btn-danger btn-block" OnClick="B_guardar_responsable_Click" Text="Guardar" ValidationGroup="guardar_responsable">
                                                                                            <span class="glyphicon glyphicon glyphicon-plus" aria-hidden="true"></span> Agregar responsable 
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    |
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="B_guardar_responsable" />
                                                                    <asp:AsyncPostBackTrigger ControlID="gv12" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <%--tab de acciones--%>
                                                        <div role="tabpanel" class="tab-pane" id="Dias" runat="server">
                                                            <asp:UpdatePanel runat="server" ID="UP_Dias" UpdateMode="Conditional">
                                                                <ContentTemplate>

                                                                    <asp:Panel ID="Panel4" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Seguimiento 
                                                                            </div>
                                                                            <div class="panel-body">

                                                                                <asp:Label runat="server" ID="lb_no_seguimiento" Text="No hay medidas en Seguimiento"></asp:Label>


                                                                                <div class="row">


                                                                                    <!--search (buscador)-->
                                                                                    <div class="input-group" runat="server" style="width: 20%;">
                                                                                        <asp:TextBox ID="text_search_gv5" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                        <asp:LinkButton ID="search_gv5" runat="server" OnClick="search_gv5_Click">
                                                                                            <span class="fas fa-search" aria-hidden="true" style="position: absolute;top: 0px;z-index: 0;padding: 4%;left: 100%;border: 1px solid #cccccc;color: #95d095;"></span>
                                                                                        </asp:LinkButton>
                                                                                        <asp:LinkButton ID="reset_gv5" runat="server" OnClick="reset_gv5_Click">
                                                                                            <span class="fas fa-window-close" aria-hidden="true" style="position: absolute;top: 0px;left: 117%;border: 1px solid #cccccc;padding: 4%;"></span>
                                                                                        </asp:LinkButton>
                                                                                    </div>

                                                                                    <!-- fin search-->

                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv5"
                                                                                        runat="server" AutoGenerateColumns="False" OnRowCommand="gv5_RowCommand" OnRowDataBound="gv5_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />

                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="id_actividad_responsable" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="proyeccion" runat="server" Text='<%# Eval("PROYECCION") %>'></asp:Label>
                                                                                                    <asp:Label ID="gestion" runat="server" Text='<%# Eval("GESTION") %>'></asp:Label>
                                                                                                    <asp:Label ID="id_actividad_dia" runat="server" Text='<%# Eval("id_actividad_dia") %>'></asp:Label>
                                                                                                    <asp:Label ID="archivos" runat="server" Text='<%# Eval("archivos") %>'></asp:Label>

                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" Visible="false" />
                                                                                            <%--<asp:BoundField DataField="LUGAR_ACTIVIDAD" HeaderText="Medida" />--%>

                                                                                            <asp:BoundField DataField="TIPO_MEDIDA" HeaderText="Tipo de medida" />
                                                                                            <asp:BoundField DataField="ID_ACTIVIDAD_PRODUCTO" HeaderText="ID Producto / Id Medida" />
                                                                                            <asp:BoundField DataField="PRODUCTO" HeaderText="Medida / Producto " />
                                                                                            <asp:BoundField DataField="HORA_INICIO" HeaderText="Inicio" Visible="false" />
                                                                                            <asp:BoundField DataField="HORA_FIN" HeaderText="Fin" Visible="false" />

                                                                                            <asp:BoundField DataField="proyeccion" HeaderText="ID Acción / Id Actividad" />
                                                                                            <%--<asp:BoundField DataField="DIA_ACTIVIDAD" HeaderText="Día" Visible="false" />--%>
                                                                                            <%--<asp:BoundField DataField="LUGAR_ACTIVIDAD" HeaderText="Actividades " />--%>
                                                                                            <asp:BoundField DataField="OBSERVACION_ACTIVIDAD_DIA" HeaderText="Actividades " />
                                                                                            <asp:BoundField DataField="BITACORA" HeaderText="Bitácoras" Visible="false" />

                                                                                            <asp:BoundField DataField="PROYECCION" HeaderText="Proyección costo" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                                                            <asp:BoundField DataField="GESTION" HeaderText="Gestión costo" ItemStyle-HorizontalAlign="Center" Visible="false" />

                                                                                            <asp:TemplateField HeaderText="Estado">
                                                                                                <ItemTemplate>
                                                                                                    <div id="estado_dia" runat="server" visible="false" class="btn-group btn-group-md" role="group" aria-label="...">
                                                                                                        <asp:LinkButton ID="PorAprobar" runat="server" CssClass="btn btn-default" CommandName="Por_Aprobar" ToolTip="ENVIAR PARA APROBACIÓN">
                                                                                                    <span class="glyphicon glyphicon-ok " aria-hidden="true"></span>        
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="AprobadoDia" runat="server" CssClass="btn btn-default" CommandName="Dia_aprobado" ToolTip="APROBADO">
                                                                                                    <span class="glyphicon glyphicon-thumbs-up " aria-hidden="true"></span>     
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="DenegadoDia" runat="server" CssClass="btn btn-default" CommandName="Dia_denegado" ToolTip="NO APROBADO">
                                                                                                    <span class="glyphicon glyphicon-thumbs-down " aria-hidden="true"></span>        
                                                                                                        </asp:LinkButton>
                                                                                                    </div>


                                                                                                    <div class="input-group " style="display: block;">
                                                                                                        <asp:LinkButton ID="L_Estado_dia" runat="server" CssClass="btn btn-block btn-default " CommandName="Estado_dia" ToolTip="Estado">
                                                                                                            <%--Style=" width:160px "--%>
                                                                                                            <span class="fas fa-edit" id="S_EstadoDia" runat="server" aria-hidden="true"></span>
                                                                                                            <asp:Literal runat="server" ID="LI_Estado_dia" Text='<%# " "+Eval("ACTIVIDAD_DIA_ESTADO") %>'></asp:Literal>
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:Label ID="L_Alerta" runat="server" Text='<%# Eval("alerta") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_bell" runat="server" CssClass="alertabell"
                                                                                                            Style="color: red; font-size: 18px; position: absolute; left: -7px; top: 1px; z-index: 10; animation-name: mover; animation-duration: 5s; animation-iteration-count: infinite;">
                                                                                                            <span class="fas fa-bell" aria-hidden="true">
                                                                                                        </asp:Panel>
                                                                                                    </div>
                                                                                                    </div>

                                                                                                    <asp:Label ID="LB_IdEstado_dia" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_ESTADO") %>' Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="LB_EstadoDia" runat="server" Text='<%# Eval("ACTIVIDAD_DIA_ESTADO") %>' Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="130px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Opciones">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label CssClass="success text-success" ToolTip="Día aprobado" Font-Size="20px" runat="server" ID="Val_DiaAprobado" Visible="false">
                                                                                            <span class="glyphicon glyphicon-check" aria-hidden="true"></span>
                                                                                                    </asp:Label>
                                                                                                    <asp:Label CssClass="success text-warning" ToolTip="Pendiente aprobación" Font-Size="20px" runat="server" ID="Pen_Aprobacion" Visible="false">
                                                                                            <span class="glyphicon glyphicon-hourglass" aria-hidden="true"></span>
                                                                                                    </asp:Label>
                                                                                                    <asp:ImageButton ID="actualizar_dia" runat="server" CausesValidation="False" Visible="false" CommandName="Actualizar_dia" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar actividad" Width="22px"></asp:ImageButton>


                                                                                                    <%--<asp:ImageButton ID="Evidencias" runat="server" CausesValidation="False" CommandName="Evidencias" ImageUrl="~/IMG/documentacion.png" ToolTip="Evidencias" Width="22px"></asp:ImageButton>--%>
                                                                                                    <div class="btn-group" role="group" aria-label="...">



                                                                                                        <asp:LinkButton ID="Evidencias" runat="server" CssClass="btn btn-default" CausesValidation="False" Style="color: #b10c0c" CommandName="Evidencias" ToolTip="Evidencias">
                                                                                                        <span class=" far fa-file " aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Bitacora" runat="server" CausesValidation="False" CssClass="btn btn-default" CommandName="Bitacora" ToolTip="Bitacora">
                                                                                                        <span class="far fa-comment-dots" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Costos" runat="server" CausesValidation="False" CommandName="Costos" Style="color: green" ToolTip="Costos" CssClass="btn btn-default">
                                                                                                        <span class="glyphicon glyphicon-usd" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Encuesta" runat="server" CssClass="btn btn-default" CausesValidation="False" Style="color: #b10c0c" CommandName="Encuesta" ToolTip="Encuesta">
                                                                                                        <span class="far fa-clipboard" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Actualizar" runat="server" Visible="true" CssClass="btn btn-default" CausesValidation="False" Style="color: #b10c0c" CommandName="Actualizar" ToolTip="Actualizar">
                                                                                                                <span class="fas fa-edit" aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="ibtnGEliminar_actividad_dia" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>



                                                                                                        <asp:Label ID="L_Alerta_bitacora" runat="server" Text='<%# Eval("alertaBitacora") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_Circle" runat="server"
                                                                                                            Style="color: white; font-size: 10px; position: absolute; left: 63px; top: 2px; z-index: 10;">

                                                                                                            <%--Style="color: green; font-size: 5px; position: absolute; left: 60px; top: 2px; z-index: 10;"><span class="fas fa-circle" aria-hidden="true">--%>


                                                                                                            <span style="background-color: green; border-radius: 100%; padding-left: 2px; padding-right: 2px;" aria-hidden="true">
                                                                                                                <asp:Label runat="server" ID="lb_bitacora_m" Text='<%# Eval("alertaBitacora") %>'></asp:Label></span>


                                                                                                        </asp:Panel>

                                                                                                        <asp:Label ID="L_Alerta_documentos" runat="server" Text='<%# Eval("archivos") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_Circle_documentos" runat="server"
                                                                                                            Style="color: white; font-size: 10px; position: absolute; left: 24px; top: 2px; z-index: 10;">

                                                                                                            <%--Style="color: green; font-size: 5px; position: absolute; left: 60px; top: 2px; z-index: 10;"><span class="fas fa-circle" aria-hidden="true">--%>

                                                                                                            <span style="background-color: green; border-radius: 100%; padding-left: 2px; padding-right: 2px;" aria-hidden="true">
                                                                                                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("archivos") %>'></asp:Label></span>


                                                                                                        </asp:Panel>

                                                                                                    </div>

                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="LB_Id_Actividad_Dia_Estado" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_ESTADO") %>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="TIPO_MEDIDA_2" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="TIPO_MEDIDA_2" runat="server" Text='<%# Eval("TIPO_MEDIDA") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="PRODUCTO_D" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="PRODUCTO_D" runat="server" Text='<%# Eval("PRODUCTO") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="ACTIVIDAD_D" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="ACTIVIDAD_D" runat="server" Text='<%# Eval("OBSERVACION_ACTIVIDAD_DIA") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ACTIVIDAD_PRODUCTO_ID" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="ACTIVIDAD_PRODUCTO_ID" runat="server" Text='<%# Eval("ID_ACTIVIDAD_PRODUCTO") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>

                                                                                <asp:Panel ID="Agregar_dias" runat="server" Visible="false">
                                                                                    <div class="container-fluid">
                                                                                        <div class="panel panel-default">
                                                                                            <div class="panel-body">

                                                                                                <div class="row" runat="server" visible="false">
                                                                                                    <div class="col-md-1">
                                                                                                        <p class="text-center">Día </p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <div class="input-group">
                                                                                                            <asp:TextBox ID="TB_Fecha" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" aria-describedby="basic-addon2"></asp:TextBox>
                                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" id="basic-addon2" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                                        </div>
                                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="basic-addon2" TargetControlID="TB_Fecha"></ajaxToolkit:CalendarExtender>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TB_Fecha" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardar_dias">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TB_Fecha" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <p class="text-center">Hora inicio:</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class="input-group bootstrap-timepicker timepicker">
                                                                                                            <asp:TextBox ID="TB_HoraInicio" runat="server" OnTextChanged="TB_HoraInicio_TextChanged" CssClass="form-control input-small"></asp:TextBox>
                                                                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                                                                                                        </div>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TB_HoraInicio" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>

                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <p class="text-center">Hora fin:</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class="input-group bootstrap-timepicker timepicker">
                                                                                                            <asp:TextBox ID="TB_HoraFin" runat="server" CssClass="form-control input-small"></asp:TextBox>
                                                                                                            <span class="input-group-addon disabled"><i class="glyphicon glyphicon-time"></i></span>
                                                                                                        </div>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TB_HoraFin" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Departamento</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="LD_DepartamentoDia" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="LD_DepartamentoDia_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="LD_DepartamentoDia" CssClass="validador"
                                                                                                            Display="Dynamic" InitialValue="0" ValidationGroup="guardar_dias">El departamento es obligatorio</asp:RequiredFieldValidator>

                                                                                                    </div>
                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Municipio</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="LD_MunicipioDia" runat="server" CssClass="form-control">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="LD_MunicipioDia" CssClass="validador"
                                                                                                            Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_dias">El municipio es obligatorio</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                </div>

                                                                                                <div class="row">

                                                                                                    <%--<label class="col-md-3 label1">Actividad</label>--%>
                                                                                                    <%--<div class="col-md-3">
                                                                                                        <p class="text-center">Actividad</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="LD_tipo_actividad" runat="server" CssClass="form-control">
                                                                                                           
                                                                                                            <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator529" runat="server" ControlToValidate="LD_tipo_actividad"
                                                                                                            CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal"
                                                                                                            ValidationGroup="guardar_dias">Seleccione</asp:RequiredFieldValidator>
                                                                                                    </div>--%>



                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Producto</p>
                                                                                                        <%--Observación día--%>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="LD_Encuentro" runat="server" CssClass="form-control" Enabled="true">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="LD_Encuentro"
                                                                                                            CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>

                                                                                                </div>
                                                                                                <div runat="server" id="div_implementacion" visible="true">
                                                                                                    <div class="row">

                                                                                                        <div class="col-md-3">
                                                                                                            <p class="text-center">Acción / Medida</p>
                                                                                                        </div>
                                                                                                        <div class="col-md-3">
                                                                                                            <asp:TextBox ID="TB_Direccion_lugar" runat="server" Rows="3" CssClass="form-control" Text='<%# Eval("LUGAR_ACTIVIDAD") %>' TextMode="MultiLine"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TB_Direccion_lugar"
                                                                                                                CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>

                                                                                                        </div>


                                                                                                        <%--    <div class="col-md-3">
                                                                                                            <p class="text-center">Bitácora de Avance </p>  
                                                                                                        </div>
                                                                                                        <div class="col-md-3">

                                                                                                            <asp:TextBox ID="TB_actividad_detalle" runat="server" CssClass="form-control" Rows="3" ReadOnly="false"
                                                                                                                placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                                                                                ControlToValidate="TB_actividad_detalle" CssClass="validador"
                                                                                                                Display="Dynamic" ValidationGroup="guardar_dias">Campo obligatorio</asp:RequiredFieldValidator>

                                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="TB_actividad_detalle"
                                                                                                                ValidChars="0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ ,." Enabled="True" />

                                                                                                            
                                                                                                        </div>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class=" panel-default panel">
                                                                                                    <asp:Panel ID="Panel_costos" runat="server" CssClass=" panel-heading collapsed" ScrollBars="None" HorizontalAlign="Left">
                                                                                                        <asp:Image ID="image3" runat="server" ImageUrl="~/Img/flecha_abajo.png" Width="20px" />
                                                                                                        Habilitar costos 
                                                                                                    </asp:Panel>
                                                                                                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" Collapsed="true"
                                                                                                        CollapseControlID="Panel_costos" CollapsedImage="../../Img/flecha_abajo.png" CollapsedText="Mostrar ..." Enabled="True"
                                                                                                        ExpandControlID="Panel_costos" ExpandedImage="../../Img/flecha_arriba.png" ExpandedText="Ocultar ... "
                                                                                                        ImageControlID="image1" SuppressPostBack="True" TargetControlID="Panel_hcostos">
                                                                                                    </ajaxToolkit:CollapsiblePanelExtender>

                                                                                                    <asp:Panel runat="server" ID="Panel_hcostos" ScrollBars="None">
                                                                                                        <br />
                                                                                                        <div class=" container-fluid">
                                                                                                            <%-- <div class="col-md-3">
                                                                                                                <p class="text-center">Proyección costo Actividad</p>
                                                                                                            </div>
                                                                                                            <div class="col-md-3">
                                                                                                                <asp:TextBox ID="TB_Proyeccion" runat="server" Text="0" CssClass="form-control">
                                                                                                                </asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TB_Proyeccion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TB_Proyeccion" ValidChars="0123456789" Enabled="True" />
                                                                                                            </div>
                                                                                                            <div class="col-md-3">
                                                                                                                <p class="text-center">Costo Gestión Actividad</p>
                                                                                                            </div>
                                                                                                            <div class="col-md-3">

                                                                                                                <asp:TextBox ID="TB_Gestion" runat="server" CssClass="form-control">
                                                                                                                </asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator170" runat="server" Text="0" ControlToValidate="TB_Gestion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server" TargetControlID="TB_Gestion"
                                                                                                                    ValidChars="0123456789" Enabled="True" />
                                                                                                            </div>--%>
                                                                                                        </div>
                                                                                                        <br />

                                                                                                    </asp:Panel>
                                                                                                </div>

                                                                                                <div class="row col-md-4 col-md-offset-4 ">
                                                                                                    <asp:LinkButton ID="guardar_dias" runat="server" CssClass="btn btn-block btn-danger " OnClick="guardar_dias_Click" ValidationGroup="guardar_dias">
                                                                                        <span class="glyphicon glyphicon glyphicon-plus"></span>&nbsp;Agregar día 
                                                                                                    </asp:LinkButton>
                                                                                                </div>

                                                                                                <div class="col-md-3 col-md-offset-1">
                                                                                                    <asp:LinkButton ID="B_ActualizarDia" Visible="false" runat="server" CssClass="btn btn-block btn-danger " OnClick="B_ActualizarDia_Click" ValidationGroup="guardar_dias">
                                                                                        <span class="fas fa-edit"></span>&nbsp;Actualizar día 
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                                <div class="col-md-3 col-md-offset-3">
                                                                                                    <asp:LinkButton ID="B_CancelarDia" Visible="false" runat="server" CssClass="btn btn-block btn-warning " OnClick="B_CancelarDia_Click">
                                                                                        <span class="glyphicon glyphicon glyphicon-remove-circle"></span>&nbsp;cancelar
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>

                                                                    <asp:Panel ID="Panel6" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Implementadas
                                                                            </div>
                                                                            <div class="panel-body">

                                                                                <asp:Label runat="server" ID="lb_no_implementadas" Text="No hay medidas Implementadas"></asp:Label>

                                                                                <div class="row">
                                                                                    <!--search (buscador)-->
                                                                                    <div class="input-group">
                                                                                        <asp:TextBox ID="text_search_gv_dias_implementados" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                        <asp:LinkButton ID="search_gv_dias_implementados" runat="server" OnClick="search_gv_dias_implementados_Click">
                                                                                            <span class="fas fa-search" aria-hidden="true" style="position: absolute;top: 0px;z-index: 0;padding: 4%;left: 100%;border: 1px solid #cccccc;color: #95d095;"></span>
                                                                                        </asp:LinkButton>
                                                                                        <asp:LinkButton ID="reset_gv_dias_implementados" runat="server" OnClick="reset_gv_dias_implementados_Click">
                                                                                            <span class="fas fa-window-close" aria-hidden="true" style="position: absolute;top: 0px;left: 117%;border: 1px solid #cccccc;padding: 4%;"></span>
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                    <div class="col-md-12" style="height: 20px;"></div>
                                                                                    <!-- fin search-->
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_dias_implementados"
                                                                                        runat="server" AutoGenerateColumns="False" OnRowCommand="gv_dias_implementados_RowCommand" OnRowDataBound="gv_dias_implementados_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />

                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="id_actividad_responsable" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="proyeccion" runat="server" Text='<%# Eval("PROYECCION") %>'></asp:Label>
                                                                                                    <asp:Label ID="gestion" runat="server" Text='<%# Eval("GESTION") %>'></asp:Label>
                                                                                                    <asp:Label ID="id_actividad_dia" runat="server" Text='<%# Eval("id_actividad_dia") %>'></asp:Label>
                                                                                                    <asp:Label ID="archivos" runat="server" Text='<%# Eval("archivos") %>'></asp:Label>

                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" Visible="false" />
                                                                                            <%--<asp:BoundField DataField="LUGAR_ACTIVIDAD" HeaderText="Medida" />--%>

                                                                                            <asp:BoundField DataField="TIPO_MEDIDA" HeaderText="Tipo de medida" />
                                                                                            <asp:BoundField DataField="ID_ACTIVIDAD_PRODUCTO" HeaderText="ID Producto / Id Medida" />
                                                                                            <asp:BoundField DataField="PRODUCTO" HeaderText="Medida / Producto " />
                                                                                            <asp:BoundField DataField="HORA_INICIO" HeaderText="Inicio" Visible="false" />
                                                                                            <asp:BoundField DataField="HORA_FIN" HeaderText="Fin" Visible="false" />

                                                                                            <asp:BoundField DataField="proyeccion" HeaderText="ID Acción / Id Actividad" />
                                                                                            <%--<asp:BoundField DataField="DIA_ACTIVIDAD" HeaderText="Día" Visible="false" />--%>
                                                                                            <%--<asp:BoundField DataField="LUGAR_ACTIVIDAD" HeaderText="Actividades " />--%>
                                                                                            <asp:BoundField DataField="OBSERVACION_ACTIVIDAD_DIA" HeaderText="Actividades " />
                                                                                            <asp:BoundField DataField="BITACORA" HeaderText="Bitácoras" Visible="false" />

                                                                                            <asp:BoundField DataField="PROYECCION" HeaderText="Proyección costo" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                                                            <asp:BoundField DataField="GESTION" HeaderText="Gestión costo" ItemStyle-HorizontalAlign="Center" Visible="false" />

                                                                                            <asp:TemplateField HeaderText="Estado">
                                                                                                <ItemTemplate>
                                                                                                    <div id="estado_dia" runat="server" visible="false" class="btn-group btn-group-md" role="group" aria-label="...">

                                                                                                        <asp:LinkButton ID="PorAprobar" runat="server" CssClass="btn btn-default" CommandName="Por_Aprobar" ToolTip="ENVIAR PARA APROBACIÓN">
                                                                                                    <span class="glyphicon glyphicon-ok " aria-hidden="true"></span>        
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="AprobadoDia" runat="server" CssClass="btn btn-default" CommandName="Dia_aprobado" ToolTip="APROBADO">
                                                                                                    <span class="glyphicon glyphicon-thumbs-up " aria-hidden="true"></span>     
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="DenegadoDia" runat="server" CssClass="btn btn-default" CommandName="Dia_denegado" ToolTip="NO APROBADO">
                                                                                                    <span class="glyphicon glyphicon-thumbs-down " aria-hidden="true"></span>        
                                                                                                        </asp:LinkButton>
                                                                                                    </div>


                                                                                                    <div class="input-group " style="display: block;">

                                                                                                        <asp:LinkButton ID="L_Estado_dia" runat="server" CssClass="btn btn-block btn-default " Style="width: auto !important;" CommandName="Estado_dia" ToolTip="Estado">
                                                                                                            <%--Style=" width:160px "--%>
                                                                                                            <span class="fas fa-edit" id="S_EstadoDia" runat="server" aria-hidden="true"></span>
                                                                                                            <asp:Literal runat="server" ID="LI_Estado_dia" Text='<%# " "+Eval("ACTIVIDAD_DIA_ESTADO") %>'></asp:Literal>
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:Label ID="L_Alerta" runat="server" Text='<%# Eval("alerta") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_bell" runat="server" CssClass="alertabell"
                                                                                                            Style="color: red; font-size: 18px; position: absolute; left: -7px; top: 1px; z-index: 10; animation-name: mover; animation-duration: 5s; animation-iteration-count: infinite;">
                                                                                                            <span class="fas fa-bell" aria-hidden="true">
                                                                                                        </asp:Panel>
                                                                                                    </div>
                                                                                                    </div>

                                                                                                    <asp:Label ID="LB_IdEstado_dia" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_ESTADO") %>' Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="LB_EstadoDia" runat="server" Text='<%# Eval("ACTIVIDAD_DIA_ESTADO") %>' Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="130px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Opciones">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label CssClass="success text-success" ToolTip="Día aprobado" Font-Size="20px" runat="server" ID="Val_DiaAprobado" Visible="false">
                                                                                            <span class="glyphicon glyphicon-check" aria-hidden="true"></span>
                                                                                                    </asp:Label>
                                                                                                    <asp:Label CssClass="success text-warning" ToolTip="Pendiente aprobación" Font-Size="20px" runat="server" ID="Pen_Aprobacion" Visible="false">
                                                                                            <span class="glyphicon glyphicon-hourglass" aria-hidden="true"></span>
                                                                                                    </asp:Label>
                                                                                                    <asp:ImageButton ID="actualizar_dia" runat="server" CausesValidation="False" Visible="false" CommandName="Actualizar_dia" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar actividad" Width="22px"></asp:ImageButton>


                                                                                                    <%--<asp:ImageButton ID="Evidencias" runat="server" CausesValidation="False" CommandName="Evidencias" ImageUrl="~/IMG/documentacion.png" ToolTip="Evidencias" Width="22px"></asp:ImageButton>--%>
                                                                                                    <div class="btn-group" role="group" aria-label="...">

                                                                                                        <asp:LinkButton ID="Evidencias" runat="server" CssClass="btn btn-default" CausesValidation="False" Style="color: #b10c0c" CommandName="Evidencias" ToolTip="Evidencias">
                                                                                                        <span class=" far fa-file " aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Bitacora" runat="server" CausesValidation="False" CssClass="btn btn-default" CommandName="Bitacora" ToolTip="Bitacora">
                                                                                                        <span class="far fa-comment-dots" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Costos" runat="server" CausesValidation="False" CommandName="Costos" Style="color: green" ToolTip="Costos" CssClass="btn btn-default">
                                                                                                        <span class="glyphicon glyphicon-usd" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:Label ID="L_Alerta_bitacora" runat="server" Text='<%# Eval("alertaBitacora") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_Circle" runat="server" Style="color: white; font-size: 10px; position: absolute; left: 63px; top: 2px; z-index: 10;">

                                                                                                            <%--Style="color: green; font-size: 5px; position: absolute; left: 60px; top: 2px; z-index: 10;"><span class="fas fa-circle" aria-hidden="true">--%>


                                                                                                            <span style="background-color: green; border-radius: 100%; padding-left: 2px; padding-right: 2px;" aria-hidden="true">
                                                                                                                <asp:Label runat="server" ID="lb_bitacora_m" Text='<%# Eval("alertaBitacora") %>'></asp:Label></span>

                                                                                                        </asp:Panel>
                                                                                                        </asp:Panel>

                                                                                                        <asp:Label ID="L_Alerta_documentos" runat="server" Text='<%# Eval("archivos") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_Circle_documentos" runat="server"
                                                                                                            Style="color: white; font-size: 10px; position: absolute; left: 24px; top: 2px; z-index: 10;">

                                                                                                            <%--Style="color: green; font-size: 5px; position: absolute; left: 60px; top: 2px; z-index: 10;"><span class="fas fa-circle" aria-hidden="true">--%>

                                                                                                            <span style="background-color: green; border-radius: 100%; padding-left: 2px; padding-right: 2px;" aria-hidden="true">
                                                                                                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("archivos") %>'></asp:Label></span>


                                                                                                        </asp:Panel>
                                                                                                    </div>

                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="144px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="LB_Id_Actividad_Dia_Estado" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_ESTADO") %>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="TIPO_MEDIDA_2" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="TIPO_MEDIDA_2" runat="server" Text='<%# Eval("TIPO_MEDIDA") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>

                                                                                <asp:Panel ID="Panel7" runat="server" Visible="false">
                                                                                    <div class="container-fluid">
                                                                                        <div class="panel panel-default">
                                                                                            <div class="panel-body">

                                                                                                <div class="row" runat="server" visible="false">
                                                                                                    <div class="col-md-1">
                                                                                                        <p class="text-center">Día </p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <div class="input-group">
                                                                                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" aria-describedby="basic-addon2"></asp:TextBox>
                                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" id="basic-addon2" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                                        </div>
                                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="basic-addon2" TargetControlID="TB_Fecha"></ajaxToolkit:CalendarExtender>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TB_Fecha" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardar_dias">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="TB_Fecha" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <p class="text-center">Hora inicio:</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class="input-group bootstrap-timepicker timepicker">
                                                                                                            <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TB_HoraInicio_TextChanged" CssClass="form-control input-small"></asp:TextBox>
                                                                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                                                                                                        </div>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="TB_HoraInicio" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>

                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <p class="text-center">Hora fin:</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class="input-group bootstrap-timepicker timepicker">
                                                                                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control input-small"></asp:TextBox>
                                                                                                            <span class="input-group-addon disabled"><i class="glyphicon glyphicon-time"></i></span>
                                                                                                        </div>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="TB_HoraFin" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Departamento</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="LD_DepartamentoDia_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="LD_DepartamentoDia" CssClass="validador"
                                                                                                            Display="Dynamic" InitialValue="0" ValidationGroup="guardar_dias">El departamento es obligatorio</asp:RequiredFieldValidator>

                                                                                                    </div>
                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Municipio</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="LD_MunicipioDia" CssClass="validador"
                                                                                                            Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_dias">El municipio es obligatorio</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                </div>

                                                                                                <div class="row">

                                                                                                    <%--<label class="col-md-3 label1">Actividad</label>--%>
                                                                                                    <%--<div class="col-md-3">
                                                                                                        <p class="text-center">Actividad</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="LD_tipo_actividad" runat="server" CssClass="form-control">
                                                                                                           
                                                                                                            <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator529" runat="server" ControlToValidate="LD_tipo_actividad"
                                                                                                            CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal"
                                                                                                            ValidationGroup="guardar_dias">Seleccione</asp:RequiredFieldValidator>
                                                                                                    </div>--%>



                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Producto</p>
                                                                                                        <%--Observación día--%>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" Enabled="true">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="LD_Encuentro"
                                                                                                            CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>

                                                                                                </div>
                                                                                                <div runat="server" id="div1" visible="true">
                                                                                                    <div class="row">

                                                                                                        <div class="col-md-3">
                                                                                                            <p class="text-center">Acción / Medida</p>
                                                                                                        </div>
                                                                                                        <div class="col-md-3">
                                                                                                            <asp:TextBox ID="TextBox7" runat="server" Rows="3" CssClass="form-control" Text='<%# Eval("LUGAR_ACTIVIDAD") %>' TextMode="MultiLine"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="TB_Direccion_lugar"
                                                                                                                CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>

                                                                                                        </div>


                                                                                                        <%--    <div class="col-md-3">
                                                                                                            <p class="text-center">Bitácora de Avance </p>  
                                                                                                        </div>
                                                                                                        <div class="col-md-3">

                                                                                                            <asp:TextBox ID="TB_actividad_detalle" runat="server" CssClass="form-control" Rows="3" ReadOnly="false"
                                                                                                                placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                                                                                ControlToValidate="TB_actividad_detalle" CssClass="validador"
                                                                                                                Display="Dynamic" ValidationGroup="guardar_dias">Campo obligatorio</asp:RequiredFieldValidator>

                                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="TB_actividad_detalle"
                                                                                                                ValidChars="0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ ,." Enabled="True" />

                                                                                                            
                                                                                                        </div>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class=" panel-default panel">
                                                                                                    <asp:Panel ID="Panel8" runat="server" CssClass=" panel-heading collapsed" ScrollBars="None" HorizontalAlign="Left">
                                                                                                        <asp:Image ID="image1" runat="server" ImageUrl="~/Img/flecha_abajo.png" Width="20px" />
                                                                                                        Habilitar costos 
                                                                                                    </asp:Panel>
                                                                                                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" Collapsed="true"
                                                                                                        CollapseControlID="Panel_costos" CollapsedImage="../../Img/flecha_abajo.png" CollapsedText="Mostrar ..." Enabled="True"
                                                                                                        ExpandControlID="Panel_costos" ExpandedImage="../../Img/flecha_arriba.png" ExpandedText="Ocultar ... "
                                                                                                        ImageControlID="image1" SuppressPostBack="True" TargetControlID="Panel_hcostos">
                                                                                                    </ajaxToolkit:CollapsiblePanelExtender>

                                                                                                    <asp:Panel runat="server" ID="Panel9" ScrollBars="None">
                                                                                                        <br />
                                                                                                        <div class=" container-fluid">
                                                                                                            <%-- <div class="col-md-3">
                                                                                                                <p class="text-center">Proyección costo Actividad</p>
                                                                                                            </div>
                                                                                                            <div class="col-md-3">
                                                                                                                <asp:TextBox ID="TB_Proyeccion" runat="server" Text="0" CssClass="form-control">
                                                                                                                </asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TB_Proyeccion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TB_Proyeccion" ValidChars="0123456789" Enabled="True" />
                                                                                                            </div>
                                                                                                            <div class="col-md-3">
                                                                                                                <p class="text-center">Costo Gestión Actividad</p>
                                                                                                            </div>
                                                                                                            <div class="col-md-3">

                                                                                                                <asp:TextBox ID="TB_Gestion" runat="server" CssClass="form-control">
                                                                                                                </asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator170" runat="server" Text="0" ControlToValidate="TB_Gestion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server" TargetControlID="TB_Gestion"
                                                                                                                    ValidChars="0123456789" Enabled="True" />
                                                                                                            </div>--%>
                                                                                                        </div>
                                                                                                        <br />

                                                                                                    </asp:Panel>
                                                                                                </div>

                                                                                                <div class="row col-md-4 col-md-offset-4 ">
                                                                                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-block btn-danger " OnClick="guardar_dias_Click" ValidationGroup="guardar_dias">
                                                                                        <span class="glyphicon glyphicon glyphicon-plus"></span>&nbsp;Agregar día 
                                                                                                    </asp:LinkButton>
                                                                                                </div>

                                                                                                <div class="col-md-3 col-md-offset-1">
                                                                                                    <asp:LinkButton ID="LinkButton2" Visible="false" runat="server" CssClass="btn btn-block btn-danger " OnClick="B_ActualizarDia_Click" ValidationGroup="guardar_dias">
                                                                                        <span class="fas fa-edit"></span>&nbsp;Actualizar día 
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                                <div class="col-md-3 col-md-offset-3">
                                                                                                    <asp:LinkButton ID="LinkButton3" Visible="false" runat="server" CssClass="btn btn-block btn-warning " OnClick="B_CancelarDia_Click">
                                                                                        <span class="glyphicon glyphicon glyphicon-remove-circle"></span>&nbsp;cancelar
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>

                                                                    <asp:Panel ID="Panel10" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Suspendidas 
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <asp:Label runat="server" ID="lb_no_suspendidas" Text="No hay medidas Suspendidas"></asp:Label>
                                                                                <div class="row">
                                                                                    <!--search (buscador)-->
                                                                                    <div class="input-group">
                                                                                        <asp:TextBox ID="text_search_gv_dias_cancelados" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                        <asp:LinkButton ID="search_gv_dias_cancelados" runat="server" OnClick="search_gv_dias_cancelados_Click">
                                                                                            <span class="fas fa-search" aria-hidden="true" style="position: absolute;top: 0px;z-index: 0;padding: 4%;left: 100%;border: 1px solid #cccccc;color: #95d095;"></span>
                                                                                        </asp:LinkButton>
                                                                                        <asp:LinkButton ID="reset_gv_dias_cancelados" runat="server" OnClick="reset_gv_dias_cancelados_Click">
                                                                                            <span class="fas fa-window-close" aria-hidden="true" style="position: absolute;top: 0px;left: 117%;border: 1px solid #cccccc;padding: 4%;"></span>
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                    <div class="col-md-12" style="height: 20px;"></div>
                                                                                    <!-- fin search-->
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_dias_cancelados"
                                                                                        runat="server" AutoGenerateColumns="False" OnRowCommand="gv_dias_cancelados_RowCommand" OnRowDataBound="gv_dias_cancelados_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />

                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="id_actividad_responsable" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="proyeccion" runat="server" Text='<%# Eval("PROYECCION") %>'></asp:Label>
                                                                                                    <asp:Label ID="gestion" runat="server" Text='<%# Eval("GESTION") %>'></asp:Label>
                                                                                                    <asp:Label ID="id_actividad_dia" runat="server" Text='<%# Eval("id_actividad_dia") %>'></asp:Label>
                                                                                                    <asp:Label ID="archivos" runat="server" Text='<%# Eval("archivos") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" Visible="false" />
                                                                                            <%--<asp:BoundField DataField="LUGAR_ACTIVIDAD" HeaderText="Medida" />--%>

                                                                                            <asp:BoundField DataField="TIPO_MEDIDA" HeaderText="Tipo de medida" />
                                                                                            <asp:BoundField DataField="ID_ACTIVIDAD_PRODUCTO" HeaderText="ID Producto / Id Medida" />
                                                                                            <asp:BoundField DataField="PRODUCTO" HeaderText="Medida / Producto " />
                                                                                            <asp:BoundField DataField="HORA_INICIO" HeaderText="Inicio" Visible="false" />
                                                                                            <asp:BoundField DataField="HORA_FIN" HeaderText="Fin" Visible="false" />

                                                                                            <asp:BoundField DataField="proyeccion" HeaderText="ID Acción / Id Actividad" />
                                                                                            <%--<asp:BoundField DataField="DIA_ACTIVIDAD" HeaderText="Día" Visible="false" />--%>
                                                                                            <%--<asp:BoundField DataField="LUGAR_ACTIVIDAD" HeaderText="Actividades " />--%>
                                                                                            <asp:BoundField DataField="OBSERVACION_ACTIVIDAD_DIA" HeaderText="Actividades " />
                                                                                            <asp:BoundField DataField="BITACORA" HeaderText="Bitácoras" Visible="false" />

                                                                                            <asp:BoundField DataField="PROYECCION" HeaderText="Proyección costo" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                                                            <asp:BoundField DataField="GESTION" HeaderText="Gestión costo" ItemStyle-HorizontalAlign="Center" Visible="false" />

                                                                                            <asp:TemplateField HeaderText="Estado">
                                                                                                <ItemTemplate>
                                                                                                    <div id="estado_dia" runat="server" visible="false" class="btn-group btn-group-md" role="group" aria-label="...">
                                                                                                        <asp:LinkButton ID="PorAprobar" runat="server" CssClass="btn btn-default" CommandName="Por_Aprobar" ToolTip="ENVIAR PARA APROBACIÓN">
                                                                                                    <span class="glyphicon glyphicon-ok " aria-hidden="true"></span>        
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="AprobadoDia" runat="server" CssClass="btn btn-default" CommandName="Dia_aprobado" ToolTip="APROBADO">
                                                                                                    <span class="glyphicon glyphicon-thumbs-up " aria-hidden="true"></span>     
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="DenegadoDia" runat="server" CssClass="btn btn-default" CommandName="Dia_denegado" ToolTip="NO APROBADO">
                                                                                                    <span class="glyphicon glyphicon-thumbs-down " aria-hidden="true"></span>        
                                                                                                        </asp:LinkButton>
                                                                                                    </div>


                                                                                                    <div class="input-group " style="display: block;">
                                                                                                        <asp:LinkButton ID="L_Estado_dia" runat="server" CssClass="btn btn-block btn-default " CommandName="Estado_dia" ToolTip="Estado">
                                                                                                            <%--Style=" width:160px "--%>
                                                                                                            <span class="fas fa-edit" id="S_EstadoDia" runat="server" aria-hidden="true"></span>
                                                                                                            <asp:Literal runat="server" ID="LI_Estado_dia" Text='<%# " "+Eval("ACTIVIDAD_DIA_ESTADO") %>'></asp:Literal>
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:Label ID="L_Alerta" runat="server" Text='<%# Eval("alerta") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_bell" runat="server" CssClass="alertabell"
                                                                                                            Style="color: red; font-size: 18px; position: absolute; left: -7px; top: 1px; z-index: 10; animation-name: mover; animation-duration: 5s; animation-iteration-count: infinite;">
                                                                                                            <span class="fas fa-bell" aria-hidden="true">
                                                                                                        </asp:Panel>
                                                                                                    </div>
                                                                                                    </div>

                                                                                                    <asp:Label ID="LB_IdEstado_dia" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_ESTADO") %>' Visible="false"></asp:Label>
                                                                                                    <asp:Label ID="LB_EstadoDia" runat="server" Text='<%# Eval("ACTIVIDAD_DIA_ESTADO") %>' Visible="false"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="130px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Opciones">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label CssClass="success text-success" ToolTip="Día aprobado" Font-Size="20px" runat="server" ID="Val_DiaAprobado" Visible="false">
                                                                                            <span class="glyphicon glyphicon-check" aria-hidden="true"></span>
                                                                                                    </asp:Label>
                                                                                                    <asp:Label CssClass="success text-warning" ToolTip="Pendiente aprobación" Font-Size="20px" runat="server" ID="Pen_Aprobacion" Visible="false">
                                                                                            <span class="glyphicon glyphicon-hourglass" aria-hidden="true"></span>
                                                                                                    </asp:Label>
                                                                                                    <asp:ImageButton ID="actualizar_dia" runat="server" CausesValidation="False" Visible="false" CommandName="Actualizar_dia" ImageUrl="~/IMG/lapiz.png" ToolTip="Actualizar actividad" Width="22px"></asp:ImageButton>


                                                                                                    <%--<asp:ImageButton ID="Evidencias" runat="server" CausesValidation="False" CommandName="Evidencias" ImageUrl="~/IMG/documentacion.png" ToolTip="Evidencias" Width="22px"></asp:ImageButton>--%>
                                                                                                    <div class="btn-group" role="group" aria-label="...">
                                                                                                        <asp:LinkButton ID="Evidencias" runat="server" CssClass="btn btn-default" CausesValidation="False" Style="color: #b10c0c" CommandName="Evidencias" ToolTip="Evidencias">
                                                                                                        <span class=" far fa-file " aria-hidden="true"><%--</span><span class="badge">4</span>--%>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Bitacora" runat="server" CausesValidation="False" CssClass="btn btn-default" CommandName="Bitacora" ToolTip="Bitacora">
                                                                                                        <span class="far fa-comment-dots" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:LinkButton ID="Costos" runat="server" CausesValidation="False" CommandName="Costos" Style="color: green" ToolTip="Costos" CssClass="btn btn-default">
                                                                                                        <span class="glyphicon glyphicon-usd" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>

                                                                                                        <asp:Label ID="L_Alerta_bitacora" runat="server" Text='<%# Eval("alertaBitacora") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_Circle" runat="server"
                                                                                                            Style="color: white; font-size: 10px; position: absolute; left: 63px; top: 2px; z-index: 10;">

                                                                                                            <%--Style="color: green; font-size: 5px; position: absolute; left: 60px; top: 2px; z-index: 10;"><span class="fas fa-circle" aria-hidden="true">--%>


                                                                                                            <span style="background-color: green; border-radius: 100%; padding-left: 2px; padding-right: 2px;" aria-hidden="true">
                                                                                                                <asp:Label runat="server" ID="lb_bitacora_m" Text='<%# Eval("alertaBitacora") %>'></asp:Label></span>
                                                                                                        </asp:Panel>

                                                                                                        </asp:Panel>

                                                                                                        <asp:Label ID="L_Alerta_documentos" runat="server" Text='<%# Eval("archivos") %>' Visible="false"> </asp:Label>

                                                                                                        <asp:Panel ID="D_Circle_documentos" runat="server"
                                                                                                            Style="color: white; font-size: 10px; position: absolute; left: 24px; top: 2px; z-index: 10;">

                                                                                                            <%--Style="color: green; font-size: 5px; position: absolute; left: 60px; top: 2px; z-index: 10;"><span class="fas fa-circle" aria-hidden="true">--%>

                                                                                                            <span style="background-color: green; border-radius: 100%; padding-left: 2px; padding-right: 2px;" aria-hidden="true">
                                                                                                                <asp:Label runat="server" ID="Label3" Text='<%# Eval("archivos") %>'></asp:Label></span>


                                                                                                        </asp:Panel>
                                                                                                    </div>

                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="144px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="LB_Id_Actividad_Dia_Estado" runat="server" Text='<%# Eval("ID_ACTIVIDAD_DIA_ESTADO") %>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="TIPO_MEDIDA_2" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="TIPO_MEDIDA_2" runat="server" Text='<%# Eval("TIPO_MEDIDA") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>

                                                                                <asp:Panel ID="Panel11" runat="server" Visible="false">
                                                                                    <div class="container-fluid">
                                                                                        <div class="panel panel-default">
                                                                                            <div class="panel-body">

                                                                                                <div class="row" runat="server" visible="false">
                                                                                                    <div class="col-md-1">
                                                                                                        <p class="text-center">Día </p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <div class="input-group">
                                                                                                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" placeholder="dd/MM/yyyy" aria-describedby="basic-addon2"></asp:TextBox>
                                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" id="basic-addon2" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                                        </div>
                                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="basic-addon2" TargetControlID="TB_Fecha"></ajaxToolkit:CalendarExtender>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TB_Fecha" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardar_dias">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="TB_Fecha" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <p class="text-center">Hora inicio:</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class="input-group bootstrap-timepicker timepicker">
                                                                                                            <asp:TextBox ID="TextBox9" runat="server" OnTextChanged="TB_HoraInicio_TextChanged" CssClass="form-control input-small"></asp:TextBox>
                                                                                                            <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                                                                                                        </div>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="TB_HoraInicio" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>

                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <p class="text-center">Hora fin:</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class="input-group bootstrap-timepicker timepicker">
                                                                                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control input-small"></asp:TextBox>
                                                                                                            <span class="input-group-addon disabled"><i class="glyphicon glyphicon-time"></i></span>
                                                                                                        </div>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="TB_HoraFin" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Departamento</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="LD_DepartamentoDia_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ControlToValidate="LD_DepartamentoDia" CssClass="validador"
                                                                                                            Display="Dynamic" InitialValue="0" ValidationGroup="guardar_dias">El departamento es obligatorio</asp:RequiredFieldValidator>

                                                                                                    </div>
                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Municipio</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="LD_MunicipioDia" CssClass="validador"
                                                                                                            Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_dias">El municipio es obligatorio</asp:RequiredFieldValidator>
                                                                                                    </div>
                                                                                                </div>

                                                                                                <div class="row">

                                                                                                    <%--<label class="col-md-3 label1">Actividad</label>--%>
                                                                                                    <%--<div class="col-md-3">
                                                                                                        <p class="text-center">Actividad</p>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="LD_tipo_actividad" runat="server" CssClass="form-control">
                                                                                                           
                                                                                                            <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator529" runat="server" ControlToValidate="LD_tipo_actividad"
                                                                                                            CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal"
                                                                                                            ValidationGroup="guardar_dias">Seleccione</asp:RequiredFieldValidator>
                                                                                                    </div>--%>



                                                                                                    <div class="col-md-3">

                                                                                                        <p class="text-center">Producto</p>
                                                                                                        <%--Observación día--%>
                                                                                                    </div>
                                                                                                    <div class="col-md-3">
                                                                                                        <asp:DropDownList ID="DropDownList6" runat="server" CssClass="form-control" Enabled="true">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ControlToValidate="LD_Encuentro"
                                                                                                            CssClass="validador" Display="Dynamic" InitialValue="0" Style="font-weight: normal" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                    </div>

                                                                                                </div>
                                                                                                <div runat="server" id="div2" visible="true">
                                                                                                    <div class="row">

                                                                                                        <div class="col-md-3">
                                                                                                            <p class="text-center">Acción / Medida</p>
                                                                                                        </div>
                                                                                                        <div class="col-md-3">
                                                                                                            <asp:TextBox ID="TextBox11" runat="server" Rows="3" CssClass="form-control" Text='<%# Eval("LUGAR_ACTIVIDAD") %>' TextMode="MultiLine"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ControlToValidate="TB_Direccion_lugar"
                                                                                                                CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>

                                                                                                        </div>


                                                                                                        <%--    <div class="col-md-3">
                                                                                                            <p class="text-center">Bitácora de Avance </p>  
                                                                                                        </div>
                                                                                                        <div class="col-md-3">

                                                                                                            <asp:TextBox ID="TB_actividad_detalle" runat="server" CssClass="form-control" Rows="3" ReadOnly="false"
                                                                                                                placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                                                                                                ControlToValidate="TB_actividad_detalle" CssClass="validador"
                                                                                                                Display="Dynamic" ValidationGroup="guardar_dias">Campo obligatorio</asp:RequiredFieldValidator>

                                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="TB_actividad_detalle"
                                                                                                                ValidChars="0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ ,." Enabled="True" />

                                                                                                            
                                                                                                        </div>--%>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class=" panel-default panel">
                                                                                                    <asp:Panel ID="Panel12" runat="server" CssClass=" panel-heading collapsed" ScrollBars="None" HorizontalAlign="Left">
                                                                                                        <asp:Image ID="image2" runat="server" ImageUrl="~/Img/flecha_abajo.png" Width="20px" />
                                                                                                        Habilitar costos 
                                                                                                    </asp:Panel>
                                                                                                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" Collapsed="true"
                                                                                                        CollapseControlID="Panel_costos" CollapsedImage="../../Img/flecha_abajo.png" CollapsedText="Mostrar ..." Enabled="True"
                                                                                                        ExpandControlID="Panel_costos" ExpandedImage="../../Img/flecha_arriba.png" ExpandedText="Ocultar ... "
                                                                                                        ImageControlID="image1" SuppressPostBack="True" TargetControlID="Panel_hcostos">
                                                                                                    </ajaxToolkit:CollapsiblePanelExtender>

                                                                                                    <asp:Panel runat="server" ID="Panel13" ScrollBars="None">
                                                                                                        <br />
                                                                                                        <div class=" container-fluid">
                                                                                                            <%-- <div class="col-md-3">
                                                                                                                <p class="text-center">Proyección costo Actividad</p>
                                                                                                            </div>
                                                                                                            <div class="col-md-3">
                                                                                                                <asp:TextBox ID="TB_Proyeccion" runat="server" Text="0" CssClass="form-control">
                                                                                                                </asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TB_Proyeccion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TB_Proyeccion" ValidChars="0123456789" Enabled="True" />
                                                                                                            </div>
                                                                                                            <div class="col-md-3">
                                                                                                                <p class="text-center">Costo Gestión Actividad</p>
                                                                                                            </div>
                                                                                                            <div class="col-md-3">

                                                                                                                <asp:TextBox ID="TB_Gestion" runat="server" CssClass="form-control">
                                                                                                                </asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator170" runat="server" Text="0" ControlToValidate="TB_Gestion" CssClass="validador" Display="Dynamic" ValidationGroup="guardar_dias">*</asp:RequiredFieldValidator>
                                                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender60" runat="server" TargetControlID="TB_Gestion"
                                                                                                                    ValidChars="0123456789" Enabled="True" />
                                                                                                            </div>--%>
                                                                                                        </div>
                                                                                                        <br />

                                                                                                    </asp:Panel>
                                                                                                </div>

                                                                                                <div class="row col-md-4 col-md-offset-4 ">
                                                                                                    <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btn btn-block btn-danger " OnClick="guardar_dias_Click" ValidationGroup="guardar_dias">
                                                                                        <span class="glyphicon glyphicon glyphicon-plus"></span>&nbsp;Agregar día 
                                                                                                    </asp:LinkButton>
                                                                                                </div>

                                                                                                <div class="col-md-3 col-md-offset-1">
                                                                                                    <asp:LinkButton ID="LinkButton5" Visible="false" runat="server" CssClass="btn btn-block btn-danger " OnClick="B_ActualizarDia_Click" ValidationGroup="guardar_dias">
                                                                                        <span class="fas fa-edit"></span>&nbsp;Actualizar día 
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                                <div class="col-md-3 col-md-offset-3">
                                                                                                    <asp:LinkButton ID="LinkButton6" Visible="false" runat="server" CssClass="btn btn-block btn-warning " OnClick="B_CancelarDia_Click">
                                                                                        <span class="glyphicon glyphicon glyphicon-remove-circle"></span>&nbsp;cancelar
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>

                                                                    <asp:Button ID="Btn_agregar_actividad_colectiva" Visible="false" runat="server" CssClass="btn-block btn btn-danger" OnClick="Btn_agregar_actividad_colectiva_Click" Text="Agregar Actividad" />

                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="guardar_dias" />
                                                                    <asp:AsyncPostBackTrigger ControlID="gv5" />
                                                                    <asp:AsyncPostBackTrigger ControlID="TB_HoraInicio" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <%-- tab de FichaCaracterizacion --%>
                                                        <div role="tabpanel" class="tab-pane active" id="ficha" runat="server">
                                                            <asp:UpdatePanel runat="server" ID="Up_ficha" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <%--PANEL IDENTIFICACION POBLACIONAL RR--%>
                                                                    <asp:Panel ID="pFicha" runat="server" CssClass="container-fluid">
                                                                        <%--Fecha y Lugar de la Caracterización--%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Fecha y Lugar de la Caracterización
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-4">
                                                                                        <label class="label1 col-sm-12">Fecha de la Caracterización</label>
                                                                                        <div class="input-group " id="calendarFechaCaracterizacion" style="padding-right: 40px;">
                                                                                            <asp:TextBox ID="txFechaCaracterizacion" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                        </div>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaCaracterizacion" TargetControlID="txFechaCaracterizacion"></ajaxToolkit:CalendarExtender>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txFechaCaracterizacion" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardarFicha">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="txFechaCaracterizacion" CssClass="validador" Display="Dynamic" ValidationGroup="guardarFicha">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-4">
                                                                                        <label class="label1 col-sm-12">Departamento</label>
                                                                                        <asp:DropDownList ID="LD_Departamento_Ficha" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LlenarMunicipiosFicha_SelectedIndexChanged"
                                                                                            CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator100" runat="server"
                                                                                            ControlToValidate="LD_Departamento_Ficha" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarFicha"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-4">
                                                                                        <label class="label1 col-sm-12">Municipio</label>
                                                                                        <asp:DropDownList ID="LD_Municipio_Ficha" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server"
                                                                                            ControlToValidate="LD_Municipio_Ficha" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarFicha"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Datos de la Entidad que realiza la Caracterización--%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Datos de la Entidad que realiza la Caracterización
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-2">
                                                                                        <label class="label1 col-sm-12">Entidad</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:DropDownList ID="LD_Entidad_Ficha" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server"
                                                                                            ControlToValidate="LD_Entidad_Ficha" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="Seleccione la Entidad" InitialValue="0"
                                                                                            ValidationGroup="guardarFicha"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <label class="label1 col-sm-12">Hogares</label>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <asp:TextBox ID="txtTotalHogaresFicha" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-2">
                                                                                        <label class="label1 col-sm-12">Profesional</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtProfesionalFicha" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server"
                                                                                                ControlToValidate="txtProfesionalFicha" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="guardarFicha">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <label class="label1 col-sm-12">Personas</label>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <asp:TextBox ID="txtTotalPersonasFicha" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-2">
                                                                                        <label class="label1 col-sm-12">Correo</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtCorreoProfesionalFicha" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server"
                                                                                                ControlToValidate="txtCorreoProfesionalFicha" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="guardarFicha">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <label class="label1 col-sm-12">Personas RUV</label>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <asp:TextBox ID="txtTotalPersonasRUV" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-2">
                                                                                        <label class="label1 col-sm-12">Dirección Territorial</label>
                                                                                    </div>
                                                                                    <div class="col-md-10">
                                                                                        <asp:DropDownList ID="LD_Territorial_Ficha" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton17" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_guardar_caracterizacion_Click" Text="Guardar Caracterización" ValidationGroup="guardarFicha" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Datos de la Comunidad--%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Comunidad
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-10">
                                                                                        <label class="label1 col-sm-12">No. de Hogares que manifestaron su interés en el proceso de reunificación Familiar</label>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <asp:TextBox ID="txtHogaresReunificacionFamiliar" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly="true"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-10">
                                                                                        <label class="label1 col-sm-12">No. de Personas interesadas en recibir atención psicosocial</label>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <asp:TextBox ID="txtPersonasAtencionPsicosocial" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly="true"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:UpdatePanel ID="Up_ficha_personas" runat="server" UpdateMode="Conditional">
                                                                                        <ContentTemplate>
                                                                                            <div class="row">
                                                                                                <div runat="server" style="overflow-x: scroll">
                                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="mgv_PersonasFicha footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_PersonasFicha"
                                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="GV_PersonasFicha_RowCommand" OnRowDataBound="GV_PersonasFicha_RowDataBound" OnPreRender="GV_PersonasFicha_PreRender" DataKeyNames="ID_PERSONA">
                                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" Visible="false" />
                                                                                                            <asp:BoundField DataField="ID_PERSONA_RUV" HeaderText="ID_PERSONA_RUV" Visible="false" />
                                                                                                            <asp:BoundField DataField="ID_HOGAR" HeaderText="No. Familia" Visible="true" />
                                                                                                            <asp:BoundField DataField="ID_HOGAR_PERSONA" HeaderText="No. Persona" Visible="false" />
                                                                                                            <asp:BoundField DataField="PRIMER_NOMBRE" HeaderText="Primer Nombre" Visible="true" />
                                                                                                            <asp:BoundField DataField="PRIMER_APELLIDO" HeaderText="Primer Apellido" Visible="true" />
                                                                                                            <asp:BoundField DataField="TIPO_DOCUMENTO" HeaderText="Tipo Documento" Visible="true" />
                                                                                                            <asp:BoundField DataField="NUMERO_DOCUMENTO" HeaderText="Número Documento" Visible="true" />
                                                                                                            <asp:TemplateField HeaderText="Reunificación Familiar">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:CheckBox ID="REUNIFICACION_FAMILIAR" runat="server" Checked='<%# Eval("REUNIFICACION_FAMILIAR_CARACTERIZACION") %>' ViewStateMode="Disabled" />
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Atención Psicosocial">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:CheckBox ID="ATENCION_PSICOSOCIAL" runat="server" Checked='<%# Eval("ATENCION_PSICOSOCIAL_CARACTERIZACION") %>' ViewStateMode="Disabled" />
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                                <ItemTemplate>
                                                                                                                    <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                                        <asp:LinkButton ID="btn_ver_persona" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Ver Detalle" CommandName="VerDetallePoblacionCaracterizacion" Visible="true">
                                                                                                                            <span class="glyphicon glyphicon-zoom-in" aria-hidden="true"></span>
                                                                                                                        </asp:LinkButton>
                                                                                                                    </div>
                                                                                                                </ItemTemplate>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                        <PagerStyle CssClass="pgr" />
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col-md-6">
                                                                                                    <asp:LinkButton ID="LinkButton18" runat="server" CssClass="btn btn-danger btn-block"  OnClick="btn_actualizar_comunidad_Click" Text="Guardar Caracterización" />
                                                                                                </div>
                                                                                                <div class="col-md-6">
                                                                                                    <asp:LinkButton ID="LinkButton24" runat="server" CssClass="btn btn-danger btn-block"  OnClick="btn_exportar_comunidad_Click" Text="Exportar Población" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Intencionalidad --%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Intencionalidad
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Razones que los llevan a tomar la decisión de solicitar el acompañamiento para retornarse, reubicarse o integrarse localmente</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:TextBox ID="txtIntencionalidadRazones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                                                                                    </div>
                                                                                </div>
                                                                                 <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Manifestación por parte de los miembros de la comunidad de compartir un mismo territorio</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:TextBox ID="txtIntencionalidadManifestacion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton19" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_guardar_caracterizacion_Click" Text="Actualizar Intencionalidad" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Condiciones Actuales de Vida de la Comunidad --%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Condiciones Actuales de Vida de la Comunidad
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Características del espacio que habitan</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:TextBox ID="txtCondicionesActualesCaracteristicas" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                                                                                    </div>
                                                                                </div>
                                                                                 <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Actividades económicas que desarrollan</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:TextBox ID="txtCondicionesActualesActividades" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton20" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_guardar_caracterizacion_Click" Text="Actualizar Condiciones Actuales" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Estado de la Comunidad --%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Estado de la Comunidad
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">No. de Mujeres en estado de embarazo</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtMujeresEmbarazo" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">No. de Personas con enfermedad ruinosa, catastrófica o de alto costo o huérfanas</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtPersonasEnfermedadRuinosa" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton21" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_guardar_caracterizacion_Click" Text="Actualizar Estado Comunidad" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <%-- tab de PlanRyR --%>
                                                        <div role="tabpanel" class="tab-pane active" id="plan_ryr" runat="server">
                                                            <asp:UpdatePanel runat="server" ID="Up_plan_ryr" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Panel ID="pPlanRyR" runat="server" CssClass="container-fluid">
                                                                         <%--Principio de Seguridad--%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Principio de Seguridad
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Fecha del Acta del CTJT en donde se validó el principio</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <div class="input-group " id="calendarFechaActaPlanRyR" style="padding-right: 40px;">
                                                                                            <asp:TextBox ID="txtFechaActaPlanRyR" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                        </div>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaActaPlanRyR" TargetControlID="txtFechaActaPlanRyR"></ajaxToolkit:CalendarExtender>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtFechaActaPlanRyR" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardarFicha">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="txtFechaActaPlanRyR" CssClass="validador" Display="Dynamic" ValidationGroup="guardarPlanRyR">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Estado</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:DropDownList ID="LD_Estado_PlanRyR" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server"
                                                                                            ControlToValidate="LD_Estado_PlanRyR" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanRyR"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Identificación Comunidad--%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Identificación Comunidad
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Nombre de la Comunidad</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtNombreComunidadPlanRyR" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Total hogares a acompañar</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtHogaresPlanRyR" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Total personas a acompañar</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtPersonasPlanRyR" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Total personas a acompañar incluidas en el RUV por desplazamiento Forzado</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtPersonasRUVPlanRyR" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Departamento</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:DropDownList ID="LD_Departamento_PlanRyR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LlenarMunicipiosPlanRyR_SelectedIndexChanged"
                                                                                            CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator107" runat="server"
                                                                                            ControlToValidate="LD_Departamento_PlanRyR" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanRyR"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Municipio</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:DropDownList ID="LD_Municipio_PlanRyR" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator108" runat="server"
                                                                                            ControlToValidate="LD_Municipio_PlanRyR" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanRyR"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Entorno Rural / Urbano</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                         <asp:DropDownList ID="LD_Entorno_PlanRyR" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator109" runat="server"
                                                                                            ControlToValidate="LD_Entorno_PlanRyR" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanRyR"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Corregimiento / Vereda / Barrio / Localidad</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtDireccionPlanRyR" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Dirección territorial de la Unidad para las Victimas</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:DropDownList ID="LD_Territorial_PlanRyR" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator110" runat="server"
                                                                                            ControlToValidate="LD_Territorial_PlanRyR" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanRyR"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Profesional encargado de elaborar el listado</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtProfesionalPlanRyR" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Correo electrónico</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:TextBox ID="txtCorreoPlanRyR" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Fecha de medición de SSV</label>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <div class="input-group " id="calendarFechaMedicionSSVPlanRyR" style="padding-right: 40px;">
                                                                                            <asp:TextBox ID="txtFechaMedicionSSVPlanRyR" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                        </div>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaMedicionSSVPlanRyR" TargetControlID="txtFechaMedicionSSVPlanRyR"></ajaxToolkit:CalendarExtender>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtFechaMedicionSSVPlanRyR" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardarFicha">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="txtFechaMedicionSSVPlanRyR" CssClass="validador" Display="Dynamic" ValidationGroup="guardarPlanRyR">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton22" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_guardar_plan_ryr_Click" Text="Guardar Plan RyR" ValidationGroup="guardarPlanRyR" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Datos de la población--%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Población
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <asp:UpdatePanel ID="Up_plan_ryr_personas" runat="server" UpdateMode="Conditional">
                                                                                        <ContentTemplate>
                                                                                            <div class="row">
                                                                                                <div runat="server" style="overflow-x: scroll">
                                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="mgv_PersonasPlanRyR footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_PersonasPlanRyR"
                                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="GV_PersonasPlanRyR_RowCommand" OnRowDataBound="GV_PersonasPlanRyR_RowDataBound" OnPreRender="GV_PersonasPlanRyR_PreRender" DataKeyNames="ID_PERSONA">
                                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" Visible="false" />
                                                                                                            <asp:BoundField DataField="ID_PERSONA_RUV" HeaderText="ID_PERSONA_RUV" Visible="false" />
                                                                                                            <asp:BoundField DataField="ID_HOGAR" HeaderText="No. Familia" Visible="true" />
                                                                                                            <asp:BoundField DataField="ID_HOGAR_PERSONA" HeaderText="No. Persona" Visible="false" />
                                                                                                            <asp:BoundField DataField="PRIMER_NOMBRE" HeaderText="Primer Nombre" Visible="true" />
                                                                                                            <asp:BoundField DataField="PRIMER_APELLIDO" HeaderText="Primer Apellido" Visible="true" />
                                                                                                            <asp:BoundField DataField="TIPO_DOCUMENTO" HeaderText="Tipo Documento" Visible="true" />
                                                                                                            <asp:BoundField DataField="NUMERO_DOCUMENTO" HeaderText="Número Documento" Visible="true" />
                                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                                <ItemTemplate>
                                                                                                                    <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                                        <asp:LinkButton ID="btn_ver_persona" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Ver Detalle" CommandName="VerDetallePoblacionPlanRyR" Visible="true">
                                                                                                                            <span class="glyphicon glyphicon-zoom-in" aria-hidden="true"></span>
                                                                                                                        </asp:LinkButton>
                                                                                                                    </div>
                                                                                                                </ItemTemplate>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                        <PagerStyle CssClass="pgr" />
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col-md-12">
                                                                                                    <asp:LinkButton ID="LinkButton26" runat="server" CssClass="btn btn-danger btn-block"  OnClick="btn_exportar_comunidad_plan_Click" Text="Exportar Población" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--Contribución SSV--%>
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Contribución a la superación de la situación de vulnerabilidad
                                                                            </div>
                                                                            <div class="panel-body" style="overflow-x:auto; overflow-y:auto; width:100%;height:80%;">
                                                                                <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_plan_ryr_necesidad"
                                                                                    runat="server" AutoGenerateColumns="false" DataKeyNames="ID_NECESIDAD" OnRowCommand="gv_plan_ryr_necesidad_RowCommand">
                                                                                    <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="ID_NECESIDAD" HeaderText="ID_NECESIDAD" Visible="false" />
                                                                                        <asp:BoundField DataField="ID_PLAN_RYR_NECESIDAD" HeaderText="Id" Visible="true" />
                                                                                        <asp:BoundField DataField="DERECHO" HeaderText="Derecho" Visible="true" HeaderStyle-Width="15%" ItemStyle-Width="15%" FooterStyle-Width="15%"/>
                                                                                        <asp:BoundField DataField="NECESIDAD" HeaderText="Necesidad" Visible="true" HeaderStyle-Width="25%" ItemStyle-Width="25%" FooterStyle-Width="25%"/>
                                                                                        <asp:BoundField DataField="NUM_PERSONAS_PENDIENTES_SUPERAR" HeaderText="Número de Personas Pendientes por superar el Derecho" Visible="true" />
                                                                                        <asp:BoundField DataField="FECHA_INICIO_TRAMITE" HeaderText="Fecha de inicio del trámite" DataFormatString="{0:dd/MM/yyyy}" Visible="true" />
                                                                                        <asp:BoundField DataField="FECHA_CIERRE_TRAMITE" HeaderText="Fecha de cierre del trámite" DataFormatString="{0:dd/MM/yyyy}" Visible="true" />
                                                                                        <asp:TemplateField HeaderText="Acciones">
                                                                                            <ItemTemplate>
                                                                                                <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                    <asp:LinkButton ID="btn_editar_necesidad" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Editar Detalle" CommandName="EditarDetalleNecesidadPlanRyR" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                                <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                    <asp:LinkButton ID="LinkButton27" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Cargar Evidencias" CommandName="CargarEvidenciaNecesidadPlanRyR" Visible='<%# !string.IsNullOrEmpty(Eval("ID_PLAN_RYR_NECESIDAD").ToString()) %>'>
                                                                                                        <span class="glyphicon glyphicon-open-file" aria-hidden="true"></span>
                                                                                                    </asp:LinkButton>
                                                                                                </div>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="guardar_dias" />
                                                                    <asp:AsyncPostBackTrigger ControlID="gv5" />
                                                                    <asp:AsyncPostBackTrigger ControlID="TB_HoraInicio" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <%--tab de PlanTraslado--%>
                                                        <div role="tabpanel" class="tab-pane active" id="plan_traslado" runat="server">
                                                            <asp:UpdatePanel runat="server" ID="Up_plan_traslado" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <%--PANEL INICIAL DE DATOS DEL TRASLASO--%>
                                                                    <asp:Panel ID="PanelPT" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                <asp:Label ID="tituloComunidad" runat="server" Visible="true" CssClass="text-warning"></asp:Label>
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Total hogares a trasladar</label>
                                                                                        <asp:TextBox ID="txTotalHogares" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Total personas a trasladar</label>
                                                                                        <asp:TextBox ID="txTotalPersonas" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Total personas a trasladar  incluidas en el RUV por desplazamiento forzado</label>
                                                                                        <asp:TextBox ID="txTotalRUV" runat="server" CssClass="form-control" ForeColor="Black" ReadOnly='true'></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Fecha de inicio del traslado</label>
                                                                                        <div class="input-group " id="calendarFechaInicioTraslado" style="padding-right: 40px;">
                                                                                            <asp:TextBox ID="txFechaInicioTraslado" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                        </div>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaInicioTraslado" TargetControlID="txFechaInicioTraslado"></ajaxToolkit:CalendarExtender>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txFechaInicioTraslado" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardar_dias">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="txFechaInicioTraslado" CssClass="validador" Display="Dynamic" ValidationGroup="guardarPlanTraslado">*</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Fecha de Llegada</label>
                                                                                        <div class="input-group " id="calendarFechaLlefada" style="padding-right: 40px;">
                                                                                            <asp:TextBox ID="txFechaLlegada" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                        </div>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaLlefada" TargetControlID="txFechaLlegada"></ajaxToolkit:CalendarExtender>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txFechaLlegada" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardar_dias">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="txFechaLlegada" CssClass="validador" Display="Dynamic" ValidationGroup="guardarPlanTraslado">*</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <%--DATOS DE SALIDA--%>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Departamento de salida</label>
                                                                                        <asp:DropDownList ID="LD_Departamento_Salida" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LlenarMunicipiosPlanSalida_SelectedIndexChanged"
                                                                                            CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                                                            ControlToValidate="LD_Departamento_Salida" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanTraslado"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Municipio de salida</label>
                                                                                        <asp:DropDownList ID="LD_Municipio_Salida" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                                                            ControlToValidate="LD_Municipio_Salida" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanTraslado"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Entorno urbano/rural de salida</label>
                                                                                        <asp:DropDownList ID="LD_Entorno_Salida" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                                                            ControlToValidate="LD_Entorno_Salida" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanTraslado"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Corregimiento/vereda/barrio de salida</label>
                                                                                        <asp:TextBox ID="txCorregimiento_Salida" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server"
                                                                                                ControlToValidate="txCorregimiento_Salida" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="guardarPlanTraslado">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <%--DATOS DE LLEGADA--%>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Departamento de llegada</label>
                                                                                        <asp:DropDownList ID="LD_Departamento_Llegada" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LlenarMunicipiosPlanLlegada_SelectedIndexChanged"
                                                                                            CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                                                            ControlToValidate="LD_Departamento_Llegada" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanTraslado"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Municipio de llegada</label>
                                                                                        <asp:DropDownList ID="LD_Municipio_Llegada" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server"
                                                                                            ControlToValidate="LD_Municipio_Llegada" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanTraslado"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Entorno urbano/rural de llegada</label>
                                                                                        <asp:DropDownList ID="LD_Entorno_Llegada" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"
                                                                                            ControlToValidate="LD_Entorno_Llegada" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="guardarPlanTraslado"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Corregimiento/vereda/barrio de llegada</label>
                                                                                        <asp:TextBox ID="txCorregimiento_Llegada" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server"
                                                                                                ControlToValidate="txCorregimiento_Llegada" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="guardarPlanTraslado">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="guardarPlanTraslado" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_guardar_plan_Accion_traslado_Click" Text="Guardar Plan de Acción de Traslado" ValidationGroup="guardarPlanTraslado">
                                                                                            Guardar Plan de Acción de Traslado
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--PERSONAS QUE NO SE VAN A TRASLADAR--%>
                                                                    <asp:Panel ID="Panel2" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Personas que NO se van a trasladar  
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-4">
                                                                                        <label class="label1 col-sm-">Documento de identidad:</label>
                                                                                    </div>
                                                                                    <div class="col-md-4">
                                                                                        <asp:TextBox ID="txDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" TargetControlID="txDocumento"
                                                                                            ValidChars="0123456789" Enabled="True" />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txDocumento" CssClass="validador" Display="Dynamic" ValidationGroup="buscarDocumento">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-4">
                                                                                        <asp:LinkButton ID="LinkButton9" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_buscar_persona_Click" Text="Buscar" ValidationGroup="buscarDocumento">
                                                                                            Buscar
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <label class="label1 col-sm-12" style="color: red" runat="server" id="lblMensajePersona">No se encontraron registros para la busqueda!!</label>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_personas"
                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="gv_personas_RowCommand" OnRowDataBound="gv_personas_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="HOGAR" HeaderText="HOGAR" Visible="true" />
                                                                                            <asp:BoundField DataField="PERSONA" HeaderText="PERSONA" Visible="true" />
                                                                                            <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" Visible="true" />
                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                        <asp:LinkButton ID="btn_eliminar_balance" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Seleccionar persona" CommandName="Seleccionar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ID_PERSONA" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="ID_PERSONA" runat="server" Text='<%# Eval("ID_PERSONA") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                                <div class="row" runat="server" id="dvMotivo">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Motivo por el cual no se trasalda la persona:</label>
                                                                                        <asp:TextBox ID="txMotivoNoTraslado" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12" runat="server" id="lblListadoPersonasNoTrasladan">LISTADO DE PERSONAS QUE NO SE TRASLADAN</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_noTrasladar"
                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="gv_noTrasladar_RowCommand" OnRowDataBound="gv_noTrasladar_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="HOGAR" HeaderText="HOGAR" Visible="true" />
                                                                                            <asp:BoundField DataField="PERSONA" HeaderText="PERSONA" Visible="true" />
                                                                                            <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" Visible="true" />
                                                                                            <asp:BoundField DataField="MOTIVO" HeaderText="MOTIVO" Visible="true" />
                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton ID="ibtnGEliminar_documento" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                                    </asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ID_PERSONA" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="ID_PERSONASI" runat="server" Text='<%# Eval("ID_PERSONA") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--ENTIDADES QUE ACOMPAÑAN EL TRASLADO--%>
                                                                    <asp:Panel ID="Panel3" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Entidades que acompañan el traslado (lugar de salida y lugar de llegada)  
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-1">
                                                                                        <label class="label1 col-sm-">Entidad:</label>
                                                                                    </div>
                                                                                    <div class="col-md-7">
                                                                                        <asp:DropDownList ID="LD_Entidad" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server"
                                                                                            ControlToValidate="LD_Municipio" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="Seleccione el municipio" InitialValue="0"
                                                                                            ValidationGroup="guardar"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-4">
                                                                                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_agregar_entidad_Click" Text="Agregar">
                                                                                            <span class="glyphicon glyphicon glyphicon-plus" aria-hidden="true"></span> Agregar Entidad
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_entidades"
                                                                                        runat="server" AutoGenerateColumns="false " OnRowCommand="gv_entidades_RowCommand" OnRowDataBound="gv_entidades_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ID_ENTIDAD" HeaderText="ID_ENTIDAD" Visible="false" />
                                                                                            <asp:BoundField DataField="NOMBRE_ENTIDAD" HeaderText="NOMBRE  DE LA ENTIDAD" />
                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                        <asp:LinkButton ID="ibtnGEliminar_documento" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_entidad" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="idEntidad" runat="server" Text='<%# Eval("ID_ENTIDAD") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <PagerStyle CssClass="pgr" />
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--CATEGORIAS--%>
                                                                    <asp:Panel ID="Panel22" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Categorias  
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_categoria"
                                                                                        runat="server" AutoGenerateColumns="false " OnRowCommand="gv_categoria_RowCommand" OnRowDataBound="gv_categoria_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="N°" HeaderText="N°" />
                                                                                            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                                                                                            <asp:TemplateField HeaderText="RESULTADO" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="RESULTADO" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ACCIONES" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="ACCIONES" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="OBSERVACIONES" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="OBSERVACIONES" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ENTIDADES RESPOINSABLES">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group" role="group" aria-label="...">
                                                                                                        <asp:LinkButton ID="AgregarEntidadesResponsablesCaracterizacion" runat="server" Visible="true" CssClass="btn btn-default" CausesValidation="False" Style="color: cadetblue" CommandName="AgregarEntidadesResponsablesCaracterizacion">
                                                                                                                <span class="fas fa-edit" aria-hidden="true">
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_nombre_actividad" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="idCaracterizacion" runat="server" Text='<%# Eval("N°") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id_nombre_actividad" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Caracterizacion" runat="server" Text='<%# Eval("NOMBRE") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton7" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_guardar_Categorias_Click" Text="Categorias">
                                                                                             Guardar Categorias
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--BALANCE DEL PROCESO DEL TRASLADO--%>
                                                                    <asp:Panel ID="Panel5" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Balance Del Proceso Del Traslado Y Llegada De Las Personas Al Lugar De Destino
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Actividad</label>
                                                                                        <asp:TextBox ID="txActividad" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server"
                                                                                                ControlToValidate="txActividad" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarActividad">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Responsable</label>
                                                                                        <asp:TextBox ID="txResponsable" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server"
                                                                                                ControlToValidate="txResponsable" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarActividad">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Cumplido</label>
                                                                                        <asp:DropDownList ID="LD_Cumplido" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server"
                                                                                                ControlToValidate="LD_Cumplido" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarActividad">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">Observaciones</label>
                                                                                        <asp:TextBox ID="txObservaciones" runat="server" CssClass="form-control" ForeColor="Black" TextMode="MultiLine"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server"
                                                                                                ControlToValidate="txObservaciones" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarActividad">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <%-- <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-">Evidencia:</label>                                                                                    
                                                                                        <asp:DropDownList ID="LD_evidencia" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server"
                                                                                            ControlToValidate="LD_evidencia" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="Seleccione el tipo de evidencia" InitialValue="0"
                                                                                            ValidationGroup="agregarActividad"></asp:RequiredFieldValidator>
                                                                                    </div>                                                                                   
                                                                                </div>--%>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton10" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_agregar_Actividad_Click" Text="Agregar Actividad" ValidationGroup="agregarActividad">
                                                                                            <span class="glyphicon glyphicon glyphicon-plus" aria-hidden="true"></span> Agregar Actividad
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_balancale_traslado"
                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="gv_balancale_traslado_RowCommand" OnRowDataBound="gv_balancale_traslado_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="id" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="idbalance" runat="server" Text='<%# Eval("ID") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ACTIVIDAD" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="actividad" runat="server" Text='<%# Eval("ACTIVIDAD") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="RESPONSABLE" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="responsable" runat="server" Text='<%# Eval("RESPONSABLE") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="OBSERVACIONES" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="observaciones" runat="server" Text='<%# Eval("OBSERVACIONES") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="CUMPLIDA" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="cumplida" runat="server" Text='<%# Eval("CUMPLIDA") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="CUMPLIDA">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="CUMPLIDA2" runat="server" Checked='<%# Eval("CUMPLIDA") %>' ViewStateMode="Disabled" />
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                        <asp:LinkButton ID="btn_eliminar_balance" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="btn_actualizar_balance" runat="server" CssClass="btn btn-default btn-sm" ToolTip="EDITAR" CommandName="Editar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="btn_evidencias_balance" runat="server" CssClass="btn btn-default btn-sm" ToolTip="EVIDENCIA" CommandName="Evidencia" Visible="true">
                                                                                                        <span class="far fa-file" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--Alistamiento Logístico De Enseres De Las Personas Que Se Trasladarán--%>
                                                                    <asp:Panel ID="Panel24" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Alistamiento Logístico De Enseres De Las Personas Que Se Trasladarán
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">FECHA Y LUGAR DEL REGISTRO DE ENSERES</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Fecha del Registro</label>
                                                                                        <div class="input-group " id="calendarFechaRegistroTraslado" style="padding-right: 40px;">
                                                                                            <asp:TextBox ID="txtFechaRegistro" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                            <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                        </div>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaRegistroTraslado" TargetControlID="txtFechaRegistro"></ajaxToolkit:CalendarExtender>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtFechaRegistro" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardar_dias">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtFechaRegistro" CssClass="validador" Display="Dynamic" ValidationGroup="agregarRegistroAlistamiento">*</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Departamento</label>
                                                                                        <asp:DropDownList ID="LD_DepartamentoAlistamiento" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="LlenarMunicipiosAlistamiento_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server"
                                                                                            ControlToValidate="LD_DepartamentoAlistamiento" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="agregarRegistroAlistamiento"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Municipio</label>
                                                                                        <asp:DropDownList ID="LD_MunicipioAlistamiento" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server"
                                                                                            ControlToValidate="LD_MunicipioAlistamiento" CssClass="validador" Display="Dynamic"
                                                                                            ErrorMessage="* Campo obligatorio" InitialValue="0"
                                                                                            ValidationGroup="agregarRegistroAlistamiento"></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Dirección:</label>
                                                                                        <asp:TextBox ID="txtDireccionRegistro" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server"
                                                                                                ControlToValidate="txtDireccionRegistro" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarRegistroAlistamiento">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12">DATOS DE LA ENTIDAD QUE REALIZA EL REGISTRO</label>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Entidad que realiza el registro</label>
                                                                                        <asp:DropDownList ID="LD_EntidadRegistra" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server"
                                                                                                ControlToValidate="LD_EntidadRegistra" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarRegistroAlistamiento">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>

                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Dirección territorial</label>
                                                                                        <asp:DropDownList ID="LD_DireccionTerritorialProfesionalEncargado" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server"
                                                                                                ControlToValidate="LD_DireccionTerritorialProfesionalEncargado" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarRegistroAlistamiento">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Profesional encargado de realizar el registro</label>
                                                                                        <asp:TextBox ID="txtProfesionalEncargado" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server"
                                                                                                ControlToValidate="txtProfesionalEncargado" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarRegistroAlistamiento">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Correo electrónico</label>
                                                                                        <asp:TextBox ID="txCorreoProfesionalEncargado" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton11" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_agregar_Datos_Alistamiento_Traslado_Click" Text="Guardar" ValidationGroup="agregarRegistroAlistamiento">
                                                                                             Guardar
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--Datos de los profesionales que realizan el Alistamiento Logístico De Enseres De Las Personas Que Se Trasladarán--%>
                                                                    <asp:Panel ID="Panel25" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                Profesionales que realizan el Alistamiento Logístico
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Nombres y apellidos</label>
                                                                                        <asp:TextBox ID="txNombresProfesionalRealiza" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server"
                                                                                                ControlToValidate="txNombresProfesionalRealiza" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarProfesionalRegistroAlistamiento">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Entidad que realiza el registro</label>
                                                                                        <asp:DropDownList ID="LD_EntidadProfesionalRegistra" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server"
                                                                                                ControlToValidate="LD_EntidadProfesionalRegistra" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarProfesionalRegistroAlistamiento">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Teléfono:</label>
                                                                                        <asp:TextBox ID="txTelefonoProfesionalRegistra" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" TargetControlID="txTelefonoProfesionalRegistra"
                                                                                            ValidChars="0123456789" Enabled="True" />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txTelefonoProfesionalRegistra" CssClass="validador" Display="Dynamic" ValidationGroup="agregarProfesionalRegistroAlistamiento">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Correo electrónico</label>
                                                                                        <asp:TextBox ID="txCorreoProfesionalRegistroAlistamiento" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <asp:LinkButton ID="LinkButton12" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_agregar_profesional_encargado_Click" Text="Agregar" ValidationGroup="agregarProfesionalRegistroAlistamiento">
                                                                                            <span class="glyphicon glyphicon glyphicon-plus" aria-hidden="true"></span> Agregar
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_profesionales"
                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="gv_profesionales_RowCommand" OnRowDataBound="gv_profesionales_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                                                            <asp:BoundField DataField="ID_ENTIDAD" HeaderText="ID_ENTIDAD" Visible="false" />
                                                                                            <asp:BoundField DataField="PROFESIONAL" HeaderText="PROFESIONAL" />
                                                                                            <asp:BoundField DataField="NOMBRE_ENTIDAD" HeaderText="NOMBRE DE LA ENTIDAD" />
                                                                                            <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" />
                                                                                            <asp:BoundField DataField="CORREO_ELECTRONICO" HeaderText="CORREO ELECTRONICO" />

                                                                                            <asp:TemplateField HeaderText="Acciones">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                                        <asp:LinkButton ID="btn_eliminar_balance" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>
                                                                                                        <asp:LinkButton ID="btn_actualizar_balance" runat="server" CssClass="btn btn-default btn-sm" ToolTip="EDITAR" CommandName="Editar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="id" runat="server" Text='<%# Eval("ID") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="profesional" runat="server" Text='<%# Eval("PROFESIONAL") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="idEntidad" runat="server" Text='<%# Eval("ID_ENTIDAD") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="telefono" runat="server" Text='<%# Eval("TELEFONO") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="id" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="correo" runat="server" Text='<%# Eval("CORREO_ELECTRONICO") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--INVENTARIO DE ELEMENTOS DE TRASTEO DEL HOGAR --%>
                                                                    <asp:Panel ID="Panel26" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                INVENTARIO DE ELEMENTOS DE TRASTEO DEL HOGAR 
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_inventario_traslado" DataKeyNames="HOGAR"
                                                                                        runat="server" AutoGenerateColumns="false " AllowPaging="true" OnRowCommand="gv_inventario_traslado_RowCommand" OnRowDataBound="gv_inventario_traslado_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="HOGAR" HeaderText="N Hogar" />
                                                                                            <asp:BoundField DataField="REPRESENTANTE_HOGAR" HeaderText="REPRESENTANTE HOGAR" />
                                                                                            <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" />
                                                                                            <asp:TemplateField HeaderText="ENSERES y MEDIOS DE TRANSPORTE">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group" role="group" aria-label="...">
                                                                                                        <asp:LinkButton ID="AgregarEnseres" runat="server" Visible="true" CssClass="btn btn-default" CausesValidation="False" Style="color: cadetblue" CommandName="AgregarEnseres">
                                                                                                                <span class="fas fa-edit" aria-hidden="true">
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <%--                                                                                            <asp:BoundField DataField="TULAS" HeaderText="TULAS" />
                                                                                            <asp:BoundField DataField="PESO" HeaderText="PESO" />                                                                                         
                                                                                            <asp:TemplateField HeaderText="ROTULACION">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="check_box" runat="server" Visible="true" OnClientClick="return false;" CssClass="left_check" AutoPostBack="false"  Checked="<%# Eval("ROTULACION") %>" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>--%>


                                                                                            <asp:TemplateField HeaderText="id_nombre_actividad" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="representante" runat="server" Text='<%# Eval("REPRESENTANTE_HOGAR") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="guardar_dias" />
                                                                    <asp:AsyncPostBackTrigger ControlID="gv5" />
                                                                    <asp:AsyncPostBackTrigger ControlID="TB_HoraInicio" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <%--tab de balance--%>
                                                        <div role="tabpanel" class="tab-pane active" id="balance_ryr" runat="server">
                                                            <asp:UpdatePanel runat="server" ID="Up_balance" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <%--informacion del balance no editable--%>
                                                                    <asp:Panel ID="Panel30" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                <asp:Label ID="lbl_nombre_comuniad_balance" runat="server" Visible="true" CssClass="text-warning"></asp:Label>
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9 ">Total hogares a trasladar</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_TotalHogares"></label>
                                                                                    </div>
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9">Total personas a trasladar</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_TotalPersonas"></label>
                                                                                    </div>
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9">Total personas a trasladar  incluidas en el RUV por desplazamiento forzado</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_TotalRUV"></label>
                                                                                    </div>
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9">Fecha de la medición de SSV de balance</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="lblMedicionSSV"></label>
                                                                                    </div>
                                                                                </div>
                                                                                <br />
                                                                                <%--datos de salida--%>
                                                                                <asp:Panel ID="Panel36" runat="server" CssClass="container-fluid">
                                                                                    <div class="panel panel-danger">
                                                                                        <div class="panel-heading">
                                                                                            LUGAR DE SALIDA 
                                                                                        </div>
                                                                                        <div class="panel-body">
                                                                                            <div class="row">
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Departamento</label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Departamento_Salida"></label>
                                                                                                </div>
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Municipio</label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Municipio_Salida"></label>
                                                                                                </div>
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Entorno</label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Entorno_Salida"></label>
                                                                                                </div>
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Corregimiento/vereda/barrio</label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Corregimiento_Salida"></label>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </asp:Panel>
                                                                                <br />
                                                                                <%--datos de llegada--%>
                                                                                <asp:Panel ID="Panel37" runat="server" CssClass="container-fluid">
                                                                                    <div class="panel panel-danger">
                                                                                        <div class="panel-heading">
                                                                                            LUGAR DE LLEGADA 
                                                                                        </div>
                                                                                        <div class="panel-body">
                                                                                            <div class="row">
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Departamento</label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Departamento_Llegada"></label>
                                                                                                </div>
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Municipio </label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Municipio_Llegada"></label>
                                                                                                </div>
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Entorno</label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Entorno_Llegada"></label>
                                                                                                </div>
                                                                                                <div class="col-md-12">
                                                                                                    <label class="label1 col-sm-9">Corregimiento/vereda/barrio</label>
                                                                                                    <label class="label1 col-sm-3 label-informacion" runat="server" id="lbl_Corregimiento_Llegada"></label>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </asp:Panel>

                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Dirección territorial</label>
                                                                                        <asp:DropDownList ID="LD_DireccionTerritorialProfesionalListadoBalance" runat="server" CssClass="form-control">
                                                                                        </asp:DropDownList>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator96" runat="server"
                                                                                                ControlToValidate="LD_DireccionTerritorialProfesionalListadoBalance" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarDatosListadoBalance">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Profesional encargado de elaborar el listado</label>
                                                                                        <asp:TextBox ID="txProfesionalListadoBalance" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator97" runat="server"
                                                                                                ControlToValidate="txProfesionalListadoBalance" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarDatosListadoBalance">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <label class="label1 col-sm-12">Correo electrónico</label>
                                                                                        <asp:TextBox ID="txcorreoProcesionalListadoBalance" runat="server" CssClass="form-control" ForeColor="Black"></asp:TextBox>
                                                                                        <span style="font-weight: normal">
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator98" runat="server"
                                                                                                ControlToValidate="txcorreoProcesionalListadoBalance" CssClass="validador" Display="Dynamic"
                                                                                                ValidationGroup="agregarDatosListadoBalance">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                        </span>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:LinkButton ID="LinkButton14" runat="server" CssClass="btn btn-danger btn-block" ValidationGroup="agregarDatosListadoBalance" OnClick="btn_guardar_datosProfesionalListado_balance_Click" Text="Guardar">
                                                                                             Guardar
                                                                                    </asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--1.Identificacion Poblacional RR--%>
                                                                    <asp:Panel ID="Panel31" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                1.Identificacion Poblacional RR  
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <asp:UpdatePanel ID="UP_DatosSujetos2" runat="server" UpdateMode="Conditional">
                                                                                        <ContentTemplate>
                                                                                            <div class="row">
                                                                                                <div runat="server" style="overflow-x: scroll">
                                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="mGridgv_listado_personas_que_se_acompanan" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_listado_personas_que_se_acompanan"
                                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="gv_listado_personas_que_se_acompanan_RowCommand" OnRowDataBound="gv_listado_personas_que_se_acompanan_RowDataBound" OnPreRender="gv_listado_personas_que_se_acompanan_PreRender">
                                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="ID_PERSONA" HeaderText="ID_PERSONA" Visible="false" />
                                                                                                            <asp:BoundField DataField="ID_PERSONA_RUV" HeaderText="ID_PERSONA_RUV" Visible="false" />
                                                                                                            <asp:BoundField DataField="HOGAR" HeaderText="HOGAR" Visible="true" />
                                                                                                            <asp:BoundField DataField="PERSONA" HeaderText="PERSONA" Visible="true" />
                                                                                                            <asp:BoundField DataField="FECHA_NACIMIENTO" HeaderText="FECHA DE NACIMIENTO" Visible="true" />
                                                                                                            <asp:BoundField DataField="SEXO" HeaderText="SEXO" Visible="true" />
                                                                                                            <asp:BoundField DataField="PARENTESCO" HeaderText="PARENTESCO" Visible="true" />
                                                                                                            <asp:BoundField DataField="UBICACION" HeaderText="UBICACION" Visible="true" />
                                                                                                            <asp:BoundField DataField="HECHO_VICTIMIZANTE" HeaderText="HECHO VICTIMIZANTE" Visible="true" />
                                                                                                            <asp:BoundField DataField="DANE_MUNICIPIO_OCURRENCIA_HECHO" HeaderText="MUNICIPIO OCURRENCIA HECHO" Visible="true" />
                                                                                                            <asp:BoundField DataField="IDENTIFICACION" HeaderText="IDENTIFICACION" Visible="true" />
                                                                                                            <asp:BoundField DataField="SALUD" HeaderText="SALUD" Visible="true" />
                                                                                                            <asp:BoundField DataField="ATENCION_PSICOSOCIAL" HeaderText="ATENCION PSICOSOCIAL" Visible="true" />
                                                                                                            <asp:BoundField DataField="EDUCACION" HeaderText="EDUCACION" Visible="true" />
                                                                                                            <asp:BoundField DataField="ALIMENTACION" HeaderText="ALIMENTACION" Visible="true" />
                                                                                                            <asp:BoundField DataField="VIVIENDA" HeaderText="VIVIENDA" Visible="true" />
                                                                                                            <asp:BoundField DataField="REUNIFICACION_FAMILIAR" HeaderText="REUNIFICACION FAMILIAR" Visible="true" />
                                                                                                            <asp:BoundField DataField="GENERACION_INGRESOS" HeaderText="GENERACION INGRESOS" Visible="true" />
                                                                                                            <asp:BoundField DataField="FECHA_MEDICION" HeaderText="FECHA MEDICION" Visible="true" />
                                                                                                        </Columns>
                                                                                                        <PagerStyle CssClass="pgr" />
                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </div>
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--2. BALANCE DE LA SUPERACIÓN DE LA SITUACIÓN DE VULNERABILIDAD (SIN GENERACIÓN DE INGRESOS)--%>
                                                                    <asp:Panel ID="Panel34" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                2. BALANCE DE LA SUPERACIÓN DE LA SITUACIÓN DE VULNERABILIDAD (SIN GENERACIÓN DE INGRESOS)  
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9 ">TOTAL PERSONAS QUE SUPERARON LA SSV CON EL ACOMPAÑAMIENTO:</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="lblTotalPersonasSuperaron"></label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-12" runat="server" id="lblFechaBalanceDerecho">f</label>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_balance_ssv"
                                                                                        runat="server" AutoGenerateColumns="false" OnRowCommand="gv_balance_ssv_RowCommand" OnRowDataBound="gv_balance_ssv_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="ID_NECESIDAD" HeaderText="ID_NECESIDAD" Visible="false" />
                                                                                            <asp:BoundField DataField="DERECHO" HeaderText="DERECHO" Visible="true" />
                                                                                            <asp:BoundField DataField="NECESIDAD" HeaderText="NECESIDAD" Visible="true" />
                                                                                            <asp:BoundField DataField="NUM_PERSONAS_PENDIENTES_SUPERAR" HeaderText="NÚMERO DE PERSONAS PENDIENTES POR SUPERAR EL DERECHO" Visible="true" />
                                                                                            <asp:BoundField DataField="NUM_PERSONAS_SUPERON" HeaderText="NÚMERO DE PERSONAS QUE SUPERARON EL DERECHO" Visible="true" />
                                                                                            <asp:BoundField DataField="FECHA_SISTEMA" HeaderText="FECHA_SISTEMA" Visible="false" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <asp:LinkButton ID="LinkButton15" runat="server" CssClass="btn btn-danger btn-block" ValidationGroup="agregarDatosListadoBalance" OnClick="btn_guardar_balance_ssv_Click" Text="Guardar">
                                                                                             Guardar Informacion de SSV
                                                                                    </asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <%--3. BALANCE DERECHO A LA GENERACIÓN DE INGRESOS--%>
                                                                    <asp:Panel ID="Panel33" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                3. BALANCE DERECHO A LA GENERACIÓN DE INGRESOS  
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9 ">TOTAL PERSONAS QUE NO SUPERABAN EL DERECHO A GENERACIÓN DE INGRESOS AL INICIO DEL PLAN:</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="lblTotalSuperacionGI"></label>
                                                                                    </div>
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9 ">TOTAL PERSONAS QUE SUPERARON EL DERECHO A GENERACIÓN DE INGRESOS AL BALANCE DEL PLAN:</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="lblTotalSuperacionGIBalance"></label>
                                                                                    </div>
                                                                                </div>
                                                                                <div runat="server" style="overflow-x: scroll">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_GI"
                                                                                        runat="server" AutoGenerateColumns="false " OnRowCommand="gv_GI_RowCommand" OnRowDataBound="gv_GI_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="BIEN_SERVICIO" HeaderText="Bien Servicio" />
                                                                                            <asp:BoundField DataField="META" HeaderText="Meta total" />
                                                                                            <asp:TemplateField HeaderText="Total víctimas acompañadas beneficiadas directamente" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="VICTIMAS_ACOMPANADAS_DIRECTAMENTE" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Total víctimas acompañadas beneficiadas indirectamente" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="VICTIMAS_ACOMPANADAS_INDIRECTAMENTE" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Total víctimas beneficiadas con el bien o servicio" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="VICTIMAS_ACOMPANADAS" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Responsable" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="RESPONSABLE" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Costo Total" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="COSTO_TOTAL" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Evidencias">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group" role="group" aria-label="...">
                                                                                                        <asp:LinkButton ID="AgregarEvidenciaMeta" runat="server" Visible="true" CssClass="btn btn-default" CausesValidation="False" Style="color: cadetblue" CommandName="AgregarEvidenciaMeta">
                                                                                                                <span class="fas fa-edit" aria-hidden="true">
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="ID_PLAN_RYR_BIEN_SERVICIO" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="ID_PLAN_RYR_BIEN_SERVICIO" runat="server" Text='<%# Eval("ID_PLAN_RYR_BIEN_SERVICIO") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <PagerStyle CssClass="pgr" />
                                                                                    </asp:GridView>
                                                                                </div>

                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9 ">COSTO TOTAL INVERTIDO EN LOS BIENES O SERVICIOS DIRIGIDOS AL DERECHO A LA GENERACIÓN DE INGRESOS:</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="Label12"></label>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <div>
                                                                        <br />
                                                                    </div>
                                                                    <asp:Panel ID="Panel35" runat="server" CssClass="container-fluid">
                                                                        <div class="panel panel-danger">
                                                                            <div class="panel-heading">
                                                                                4. BALANCE DEL AVANCE EN EL PROCESO DE INTEGRACIÓN COMUNITARIA Y ARRAIGO TERRITORIAL  
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div runat="server" style="overflow-x: scroll">
                                                                                    <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_ICYAT"
                                                                                        runat="server" AutoGenerateColumns="false " OnRowCommand="gv_ICYAT_RowCommand" OnRowDataBound="gv_ICYAT_RowDataBound">
                                                                                        <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="BIEN_SERVICIO" HeaderText="Bien Servicio" />
                                                                                            <asp:BoundField DataField="META" HeaderText="Meta Total" />
                                                                                            <asp:TemplateField HeaderText="Total víctimas acompañadas beneficiadas directamente" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="VICTIMAS_ACOMPANADAS_DIRECTAMENTE" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Total víctimas acompañadas beneficiadas indirectamente" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="VICTIMAS_ACOMPANADAS_INDIRECTAMENTE" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Total víctimas beneficiadas con el bien o servicio" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="VICTIMAS_ACOMPANADAS" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>




                                                                                            <asp:TemplateField HeaderText="Total personas no víctimas beneficiadas con el bien o servicio" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="PERSONAS_NO_VICTIMAS_BENEFICIADAS" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Total personas beneficiadas con el bien o servicio" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="PERSONAS_BENEFICIADAS" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <%--falta una--%>


                                                                                            <asp:TemplateField HeaderText="Responsable" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="RESPONSABLE" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Costo Total" Visible="true">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="COSTO_TOTAL" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Evidencias">
                                                                                                <ItemTemplate>
                                                                                                    <div class="btn-group" role="group" aria-label="...">
                                                                                                        <asp:LinkButton ID="AgregarEvidenciaMeta" runat="server" Visible="true" CssClass="btn btn-default" CausesValidation="False" Style="color: cadetblue" CommandName="AgregarEvidenciaMeta">
                                                                                                                <span class="fas fa-edit" aria-hidden="true">
                                                                                                        </asp:LinkButton>
                                                                                                    </div>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="ID_PLAN_RYR_BIEN_SERVICIO" Visible="false">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="ID_PLAN_RYR_BIEN_SERVICIO" runat="server" Text='<%# Eval("ID_PLAN_RYR_BIEN_SERVICIO") %>'> </asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <PagerStyle CssClass="pgr" />
                                                                                    </asp:GridView>
                                                                                </div>

                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <label class="label1 col-sm-9 ">COSTO TOTAL INVERTIDO EN LOS BIENES O SERVICIOS DIRIGIDOS AL AVANCE EN EL PROCESO DE INTEGRACIÓN COMUNITARIA Y ARRAIGO TERRITORIAL:</label>
                                                                                        <label class="label1 col-sm-3 label-informacion" runat="server" id="Label13"></label>
                                                                                    </div>
                                                                                </div>


                                                                                <div class="row">
                                                                                    <div class="col-md-6">
                                                                                        <asp:LinkButton ID="LinkButton16" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_generar_balance_doc_Click" Text="Generar documento">
                                                                                             Generar balance en .doc
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                    <div class="col-md-6">
                                                                                        <asp:LinkButton ID="LinkButton23" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_generar_balance_pdf_Click" Text="Generar documento">
                                                                                             Generar balance en .pdf
                                                                                        </asp:LinkButton>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="guardar_dias" />
                                                                    <asp:AsyncPostBackTrigger ControlID="gv5" />
                                                                    <asp:AsyncPostBackTrigger ControlID="TB_HoraInicio" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:HiddenField ID="TabName" runat="server" />
                        </div>

                        <%--modal detalle población caracterizacion--%>
                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalPoblacionCaractizacion" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelDetallePersona" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">
                                                <div class="panel panel-danger">
                                                    <div class="panel-heading">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        <asp:Label ID="Label17" runat="server" Visible="true" CssClass="text-warning">Detalle persona</asp:Label>
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="row">
                                                            <asp:Panel ID="pDetallePersona" runat="server">
                                                                <div class="panel-body">
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <asp:Label ID="Label18" runat="server" Visible="true" CssClass="text-warning">Control</asp:Label>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label class="label1 col-sm-">No.Familia:</label>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <asp:Label ID="ID_HOGAR" runat="server" Visible="true" />
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <label class="label1 col-sm-">No.Persona:</label>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <asp:Label ID="ID_HOGAR_PERSONA" runat="server" Visible="true" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="panel panel-danger">
                                                                    <div class="panel-heading">
                                                                        <asp:Label ID="Label14" runat="server" Visible="true" CssClass="text-warning">Identificación de la Persona</asp:Label>
                                                                    </div>
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Tipo Documento:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="TIPO_DOCUMENTO" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">No.Documento:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="NUMERO_DOCUMENTO" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Primer Nombre:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="PRIMER_NOMBRE" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Primer Apellido:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="PRIMER_APELLIDO" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Segundo Nombre:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="SEGUNDO_NOMBRE" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Segundo Apellido:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="SEGUNDO_APELLIDO" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Fecha de Nacimiento:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="FECHA_NACIMIENTO" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Sexo:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="SEXO" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Relación o parentesco:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="PARENTESCO" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Teléfono Fijo:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="TELEFONO_FIJO" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <label class="label1 col-sm-"></label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Teléfono Celular:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="TELEFONO_CELULAR" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="panel panel-danger">
                                                                    <div class="panel-heading">
                                                                        <asp:Label ID="Label15" runat="server" Visible="true" CssClass="text-warning">Lugar Actual Residencia</asp:Label>
                                                                    </div>
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Departamento:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="DEPARTAMENTO_RESIDENCIA" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Municipio:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="MUNICIPIO_RESIDENCIA" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Vereda:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="VEREDA_RESIDENCIA" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Corregimiento:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="CORREGIMIENTO_RESIDENCIA" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Barrio | Localidad:</label>
                                                                            </div>
                                                                            <div class="col-md-9">
                                                                                <asp:Label ID="BARRIO_LOCALIDAD_RESIDENCIA" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Dirección Residencia:</label>
                                                                            </div>
                                                                            <div class="col-md-9">
                                                                                <asp:Label ID="DIRECCION_RESIDENCIA" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="panel panel-danger">
                                                                    <div class="panel-heading">
                                                                        <asp:Label ID="Label16" runat="server" Visible="true" CssClass="text-warning">Lugar al que desea retornar</asp:Label>
                                                                    </div>
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Departamento:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="DEPARTAMENTO_INTENCION" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Municipio:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="MUNICIPIO_INTENCION" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Vereda:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="VEREDA_INTENCION" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Corregimiento:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="CORREGIMIENTO_INTENCION" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Barrio | Localidad:</label>
                                                                            </div>
                                                                            <div class="col-md-9">
                                                                                <asp:Label ID="BARRIO_LOCALIDAD_INTENCION" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Tipo de Solución duradera:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="TIPO_SOLUCION" runat="server" Visible="true" />
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <label class="label1 col-sm-">Estado en el RUV:</label>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <asp:Label ID="ESTADO_RUV" runat="server" Visible="true" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--modal exportar población caracterizacion--%>
                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalExportarPoblacion" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">
                                <asp:UpdatePanel runat="server" ID="Up_personas_exportar" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="panel panel-danger">
                                                <div class="panel-heading">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <asp:Label ID="Label19" runat="server" Visible="true" CssClass="text-warning">Listado persona</asp:Label>
                                                </div>
                                                <div class="panel-body" style="overflow-x:auto;width:100%;height:80%;">
                                                    <asp:GridView UseAccessibleHeader="true" CssClass="mgv_personas_exportar footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_personas_exportar" runat="server" AutoGenerateColumns="true"
                                                        OnRowCommand="gv_personas_exportar_RowCommand" OnRowDataBound="gv_personas_exportar_RowDataBound" OnPreRender="gv_personas_exportar_PreRender">
                                                        <PagerStyle CssClass="pgr" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--modal detalle necesidades plan RyR--%>
                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalNecesidadesPlanRyR" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelNecesidadPlanRyR" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">
                                                <div class="panel panel-danger">
                                                    <div class="panel-heading">
                                                         <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        <asp:Label ID="Label20" runat="server" Visible="true" CssClass="text-warning">Detalle Necesidad</asp:Label>
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="row">
                                                            <asp:Panel ID="pDetalleNecesidad" runat="server">
                                                                <div class="panel-body">
                                                                    <div class="row">
                                                                         <div class="col-md-2">
                                                                            <label class="label1 col-sm-">Derecho:</label>
                                                                        </div>
                                                                        <div class="col-md-10">
                                                                            <asp:Label ID="DERECHO" runat="server" Visible="true"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-2">
                                                                            <label class="label1 col-sm-">Necesidad:</label>
                                                                        </div>
                                                                        <div class="col-md-10">
                                                                            <asp:Label ID="ID_NECESIDAD" runat="server" Visible="false"></asp:Label>
                                                                            <asp:Label ID="NECESIDAD" runat="server" Visible="true"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-10">
                                                                            <label class="label1 col-sm-">Número de Personas pendientes por superar el Derecho:</label>
                                                                            <asp:Label ID="NUM_PERSONAS_PENDIENTES_SUPERAR" runat="server" Visible="true"></asp:Label>
                                                                        </div>
                                                                        <div class="col-md-2"></div>
                                                                    </div>
                                                                    <div class="panel panel-danger">
                                                                        <div class="panel-heading">
                                                                            <label class="label1 col-sm-">Acciones por Adelantar</label>
                                                                        </div>
                                                                        <div class="panel-body">
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    <asp:TextBox ID="ACCIONES" runat="server" ForeColor="Black" TextMode="MultiLine" Width="100%" Rows="5"></asp:TextBox>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="panel panel-danger">
                                                                        <div class="panel-heading">
                                                                            <label class="label1 col-sm-">Fechas del Trámite</label>
                                                                        </div>
                                                                        <div class="panel-body">
                                                                            <div class="row">
                                                                                <div class="col-md-2">
                                                                                    <label class="label1 col-sm-">Inicio</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <div class="input-group " id="calendarFechaInicioNecesidadPlanRyR" style="padding-right: 40px;">
                                                                                        <asp:TextBox ID="FECHA_INICIO_TRAMITE" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                        <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                    </div>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaInicioNecesidadPlanRyR" TargetControlID="FECHA_INICIO_TRAMITE"></ajaxToolkit:CalendarExtender>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="FECHA_INICIO_TRAMITE" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardarFicha">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator112" runat="server" ControlToValidate="FECHA_INICIO_TRAMITE" CssClass="validador" Display="Dynamic" ValidationGroup="guardarNecesidadPlanRyR">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <label class="label1 col-sm-">Cierre</label>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                     <div class="input-group " id="calendarFechaCierreNecesidadPlanRyR" style="padding-right: 40px;">
                                                                                        <asp:TextBox ID="FECHA_CIERRE_TRAMITE" runat="server" CssClass="form-control " placeholder="dd/MM/yyyy" Text=''></asp:TextBox>
                                                                                        <span class="input-group-addon glyphicon glyphicon-calendar" style="border-radius: 0px 4px 4px 0px"></span>
                                                                                    </div>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="calendarFechaCierreNecesidadPlanRyR" TargetControlID="FECHA_CIERRE_TRAMITE"></ajaxToolkit:CalendarExtender>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="FECHA_CIERRE_TRAMITE" CssClass="validador" Display="Dynamic" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" ValidationGroup="guardarFicha">Formato de fecha incorrecto</asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator113" runat="server" ControlToValidate="FECHA_CIERRE_TRAMITE" CssClass="validador" Display="Dynamic" ValidationGroup="guardarNecesidadPlanRyR">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-12">
                                                                            <asp:LinkButton ID="LinkButton25" runat="server" CssClass="btn btn-danger btn-block"  OnClick="btn_grabar_necesidades_Click" Text="Guardar Necesidades" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--modales de inventario--%>
                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalEnseres" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-sm" role="document">

                                <asp:UpdatePanel runat="server" ID="UpdatePanelInventarioEnseres" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">

                                                <div class="panel panel-danger">

                                                    <div class="panel-heading">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        <asp:Label ID="lblReprentante" runat="server" Visible="true" CssClass="text-warning"></asp:Label>
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="row">
                                                            <asp:Panel ID="DetalleEnseres" runat="server" Visible="true">
                                                                <%--  ENSERES COCINA--%>
                                                                <asp:Panel ID="Panel27" runat="server" CssClass="container-fluid">
                                                                    <div class="panel panel-danger">
                                                                        <div class="panel-heading">
                                                                            ENSERES COCINA
                                                                        </div>
                                                                        <div class="panel-body">
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Estufas 
                                                                <asp:TextBox ID="txEstufas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txEstufas"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="txEstufas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Neveras 
                                                                <asp:TextBox ID="txNeveras" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txNeveras"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="txNeveras" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Menaje o utencilios de cocina (loza, ollas, etc.)
                                                               <asp:TextBox ID="txMenaje" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txMenaje"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator79" runat="server" ControlToValidate="txMenaje" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>

                                                                <%-- ENSERES HABITACION--%>
                                                                <asp:Panel ID="Panel28" runat="server" CssClass="container-fluid">
                                                                    <div class="panel panel-danger">
                                                                        <div class="panel-heading">
                                                                            ENSERES HABITACION
                                                                        </div>
                                                                        <div class="panel-body">
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Camas
                                                               <asp:TextBox ID="txCamas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txCamas"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator80" runat="server" ControlToValidate="txCamas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Colchones
                                                               <asp:TextBox ID="txColchones" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txColchones"
                                                                                        ValidChars="0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ_-(),. " Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator81" runat="server" ControlToValidate="txColchones" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Cobijas
                                                               <asp:TextBox ID="txCobijas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txCobijas"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator82" runat="server" ControlToValidate="txCobijas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Sofas
                                                               <asp:TextBox ID="txSofas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txSofas"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator83" runat="server" ControlToValidate="txSofas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Sillas
                                                               <asp:TextBox ID="txSillas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txSillas"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator84" runat="server" ControlToValidate="txSillas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Mesas
                                                               <asp:TextBox ID="txMesas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txMesas"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator85" runat="server" ControlToValidate="txMesas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Equipos de sonido
                                                               <asp:TextBox ID="txEquiposSonido" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txEquiposSonido"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator86" runat="server" ControlToValidate="txEquiposSonido" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Juguetes, Ropa
                                                               <asp:TextBox ID="txJuguetes" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="txJuguetes"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ControlToValidate="txJuguetes" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>

                                                                <%--MEDIOS DE TRANSPORTE--%>
                                                                <asp:Panel ID="Panel29" runat="server" CssClass="container-fluid">
                                                                    <div class="panel panel-danger">
                                                                        <div class="panel-heading">
                                                                            MEDIOS DE TRANSPORTE
                                                                        </div>
                                                                        <div class="panel-body">

                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Bicicletas
                                                               <asp:TextBox ID="txBicicletas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" TargetControlID="txBicicletas"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="txBicicletas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-12">
                                                                                    Motos
                                                               <asp:TextBox ID="txMotos" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" TargetControlID="txMotos"
                                                                                        ValidChars="0123456789" Enabled="True" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" ControlToValidate="txMotos" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>

                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Tulas
                                                               <asp:TextBox ID="txTulas" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" TargetControlID="txTulas"
                                                                            ValidChars="0123456789" Enabled="True" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ControlToValidate="txTulas" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        Peso
                                                               <asp:TextBox ID="txPeso" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" TargetControlID="txPeso"
                                                                            ValidChars="0123456789" Enabled="True" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txPeso" CssClass="validador" Display="Dynamic" ValidationGroup="guardarEnseres">El campo es obligatorio</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                        <label class="label1 col-sm-12">Rotulación Tulas y Enseres</label>
                                                                        <asp:DropDownList ID="LD_Rotulacion" runat="server" CssClass="form-control">
                                                                        </asp:DropDownList>
                                                                        <span style="font-weight: normal">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server"
                                                                                ControlToValidate="LD_Rotulacion" CssClass="validador" Display="Dynamic"
                                                                                ValidationGroup="guardarEnseres">* Campo obligatorio</asp:RequiredFieldValidator>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </asp:Panel>
                                                            <asp:Label ID="Label7" runat="server" Text="" Visible="false" CssClass="text-warning"></asp:Label>
                                                            <div class="row">
                                                                <asp:LinkButton ID="btnGuardarEnseres" runat="server" Visible="true" CssClass="btn-block btn btn-danger"
                                                                    OnClick="btn_GuardarEnseres" ValidationGroup="guardarEnseres">Guardar 
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_GuardarEnseres" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <%--modales de entidades de las entidades de la caracterizacion--%>
                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalEntidadesCaractizacion" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelCaracterizacionEntidades" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">
                                                <div class="panel panel-danger">
                                                    <div class="panel-heading">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        <asp:Label ID="lblCaracterizacion" runat="server" Visible="true" CssClass="text-warning">Tema:</asp:Label>
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="row">
                                                            <div class="col-md-1">
                                                                <label class="label1 col-sm-">Entidad:</label>
                                                            </div>
                                                            <div class="col-md-7">
                                                                <asp:DropDownList ID="LD_EntidadCaracterizacion" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                                                    ControlToValidate="LD_EntidadCaracterizacion" CssClass="validador" Display="Dynamic"
                                                                    ErrorMessage="Seleccione la entidad" InitialValue="0"
                                                                    ValidationGroup="guardarCaracterizacionEntidad"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:LinkButton ID="LinkButton13" runat="server" CssClass="btn btn-danger btn-block" OnClick="btn_agregar_entidad_caracterizacion_Click" Text="Agregar">
                                                                                            <span class="glyphicon glyphicon glyphicon-plus" aria-hidden="true"></span> Agregar Entidad
                                                                </asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_entidades_caracterizacion"
                                                                runat="server" AutoGenerateColumns="false " OnRowCommand="gv_entidades_caracterizacion_RowCommand" OnRowDataBound="gv_entidades_caracterizacion_RowDataBound">
                                                                <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="ID_ENTIDAD" HeaderText="ID_ENTIDAD" Visible="false" />
                                                                    <asp:BoundField DataField="NOMBRE_ENTIDAD" HeaderText="NOMBRE  DE LA ENTIDAD" />
                                                                    <asp:TemplateField HeaderText="Acciones">
                                                                        <ItemTemplate>
                                                                            <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                <asp:LinkButton ID="ibtnGEliminar_documento" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="id_entidad" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="idEntidad" runat="server" Text='<%# Eval("ID_ENTIDAD") %>'> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_GuardarEnseres" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <%--modal para las evidencias del BALANCE DEL PROCESO DEL TRASLADO Y LLEGADA DE LAS PERSONAS AL LUGAR DE DESTINO --%>
                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalEvidenciasBalance" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelEvidenciasBalance" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">
                                                <div class="panel panel-danger">
                                                    <div class="panel-heading">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        Documentos y evidencias 
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:Panel ID="Panel32" runat="server" Style="margin-left: 9%; margin-right: 9%;" CssClass="container-fluid">
                                                            <div class="form-group  col-md-12">
                                                                <label class="col-md-3 label1 ">Tipo de evidencia</label>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="LD_TipoEvidencia" runat="server" AutoPostBack="false" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator95" runat="server" ControlToValidate="LD_TipoEvidencia" CssClass="validador" Display="Dynamic" InitialValue="0" ValidationGroup="v_guardar_archivo_evidencia">El tipo de archivo es obligatorio</asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="form-group  col-md-12">
                                                                <label class="col-md-3 label1 ">Adjuntar el documento</label>
                                                                <div class="col-md-3">
                                                                    <div class="input-group">
                                                                        <asp:FileUpload runat="server" ID="FileUploadEvidencia" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row form-group">
                                                                <asp:Label ID="StatusLabelEvidencia" runat="server" />
                                                                <div class="col-md-12">
                                                                    <asp:LinkButton ID="guardar_archivo_evidencia" runat="server" CssClass="btn btn-block btn-danger" OnClick="guardar_evidencia_Click" ValidationGroup="v_guardar_archivo_evidencia">
                                                            <span class="glyphicon  glyphicon-plus" aria-hidden="true"></span> Agregar archivo de evidencia
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>

                                                        <%--tabla de las evidencias cargadas--%>
                                                        <div class="row">
                                                            <asp:GridView UseAccessibleHeader="true" CssClass="footable mGrid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ID="gv_evidencias_traslado"
                                                                runat="server" AutoGenerateColumns="false " OnRowCommand="gv_evidencias_traslado_RowCommand" OnRowDataBound="gv_evidencias_traslado_RowDataBound">
                                                                <SelectedRowStyle BackColor="Red" VerticalAlign="Top" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                                                    <asp:BoundField DataField="ID_RELACION" HeaderText="ID" Visible="false" />
                                                                    <asp:BoundField DataField="ID_TIPO_EVIDENCIA" HeaderText="ID_TIPO_EVIDENCIA" Visible="false" />
                                                                    <asp:BoundField DataField="TIPO_EVIDENCIA" HeaderText="TIPO_EVIDENCIA" />
                                                                    <asp:BoundField DataField="URL_ARCHIVO" HeaderText="URL_ARCHIVO" />
                                                                    <asp:BoundField DataField="EXTENSION" HeaderText="EXTENSION" />
                                                                    <asp:TemplateField HeaderText="Acciones">
                                                                        <ItemTemplate>
                                                                            <div class="btn-group " role="group" aria-label="..." style="padding-bottom: 6px; padding-top: 6px;">
                                                                                <asp:LinkButton ID="descarga_archivo_evidencia" runat="server" CssClass="btn btn-default btn-sm" ToolTip="DESCARGAR" CommandName="Descargar">                                                                                                    
                                                                                                        <span class="glyphicon glyphicon-download-alt" aria-hidden="true"></span>
                                                                                </asp:LinkButton>
                                                                                <asp:LinkButton ID="ibtnGEliminar_documento" runat="server" CssClass="btn btn-default btn-sm" ToolTip="ELIMINAR" CommandName="Eliminar" Visible="true">
                                                                                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                                                                </asp:LinkButton>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="ID_EVIDENCIA" runat="server" Text='<%# Eval("ID") %>'> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="ID_RELACION" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="ID_RELACION" runat="server" Text='<%# Eval("ID_RELACION") %>'> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="URL_ARCHIVO" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="URL_ARCHIVO" runat="server" Text='<%# Eval("URL_ARCHIVO") %>'> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="EXTENSION" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="EXTENSION" runat="server" Text='<%# Eval("EXTENSION") %>'> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="NOMBRE_ARCHIVO" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="NOMBRE_ARCHIVO" runat="server" Text='<%# Eval("NOMBRE_ARCHIVO") %>'> </asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <%--<asp:AsyncPostBackTrigger ControlID="btn_GuardarEnseres" />--%>
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <%--modal gestión evidencias --%>
                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" visible="false" style="z-index: 150;" id="myModalEvidencias" aria-hidden="true">
                            <div style="background: black; width: 100%; height: 100%; position: absolute; top: 0px; left: 0px; opacity: 0.5; z-index: 1040;"></div>
                            <div class="modal-dialog modal-lg" role="document">
                                <asp:UpdatePanel runat="server" ID="UpdatePanelEvidencias" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="modal-content">
                                            <div class="">
                                                <div class="panel panel-danger">
                                                    <div class="panel-heading">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                        Documentos y evidencias 
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:Panel ID="Panel38" runat="server" Style="margin-left: 9%; margin-right: 9%;" CssClass="container-fluid">
                                                            <div class="form-group  col-md-12">
                                                                <label class="col-md-3 label1 ">Tipo de evidencia</label>
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="LD_MTipoEvidencia" runat="server" AutoPostBack="false" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator114" runat="server" ControlToValidate="LD_MTipoEvidencia" CssClass="validador" Display="Dynamic" InitialValue="0" ValidationGroup="v_guardar_modal_evidencia">El tipo de archivo es obligatorio</asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="form-group  col-md-12">
                                                                <label class="col-md-3 label1 ">Adjuntar el documento</label>
                                                                <div class="col-md-3">
                                                                    <div class="input-group">
                                                                        <asp:FileUpload runat="server" ID="FU_Evidencia"/>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row form-group">
                                                                <asp:Label ID="Label21" runat="server" />
                                                                <div class="col-md-12">
                                                                    <asp:LinkButton ID="btn_guardar_evidencia" runat="server" CssClass="btn btn-block btn-danger" OnClick="btn_guardar_evidencia_Click" ValidationGroup="v_guardar_modal_evidencia">
                                                            <span class="glyphicon  glyphicon-plus" aria-hidden="true"></span> Agregar archivo de evidencia
                                                                    </asp:LinkButton>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btn_guardar_evidencia" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                    </div>
                </div>
                </center>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
            <ProgressTemplate>
                <div class="overlay2" style="display: block;">
                    <asp:Image ID="imgUp1" runat="server" CssClass="centrado" ImageUrl="~/Img/loading2.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>

</asp:Content>

