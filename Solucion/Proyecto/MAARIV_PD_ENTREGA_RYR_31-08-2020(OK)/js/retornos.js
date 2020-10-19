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

                    for (var i = 0; i < rowsLoc1.length; {
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

                    for (var i = 0; i < rowsLoc2.length; {
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
        //${'#ContentPlaceHolder1_Panel4 > div > div.panel-body > div > div.input-group'}.remove('style');

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
            $('[id$="gv_listado_personas_que_se_acompanan"]').dataTable({
            destroy: true,
                responsive: {
            //details: false
        }
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


    $(document).ready(function () {
        L_D_Territorial();
        });


        function L_D_Territorial() {
            //ID_selector HTML #ContentPlaceHolder1_LD_Territorial
            var dropdownlist = document.getElementById('ContentPlaceHolder1_LD_Territorial');
            $.ajax({
        type: "GET",
                url: "/modulos/javascriptComun.aspx/L_D_Territorial?opcion=1&id_territorial=0&id_departamento=0",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //console.log(response.d);
                    var obj = JSON.parse(response.d.resultado);
                    console.log(obj);
                    //adicionar el seleccionar
                    var option = document.createElement("option");
                    option.text = "seleccione Territorial"; option.value = "0"; dropdownlist.add(option);
                    for (var i = 0; i < obj.length; {
                        //selectObject.add(option, index) añadir una opcion
                        var option = document.createElement("option");
                        option.text = obj[i].Territorio;
                        option.value = obj[i].Id_territorio;
                        dropdownlist.add(option);
                    }
                },
                error: function (xhr) {
        console.log(xhr);
                    alert("Error", "Pregunta no se registro");
                }
            });
        }

        function L_D_Departamentos(id_territorial) {
            //ID_selctor HTML #ContentPlaceHolder1_LD_Departamento
            var dropdownlist = document.getElementById('ContentPlaceHolder1_LD_Departamento');
            $.ajax({
        type: "GET",
                url: "/modulos/javascriptComun.aspx/L_D_Departamentos?id_territorial=" + id_territorial,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //console.log(response.d);
                    var obj = JSON.parse(response.d.resultado);
                    console.log(obj);
                    $('#ContentPlaceHolder1_LD_Departamento').empty();
                    $('#ContentPlaceHolder1_LD_Municipio').empty();
                    //adicionar el seleccionar
                    var option = document.createElement("option");
                    option.text = "seleccione Departamento"; option.value = "0"; dropdownlist.add(option);
                    for (var i = 0; i < obj.length; {
                        var option = document.createElement("option");
                        option.text = obj[i].departamento;
                        option.value = obj[i].id_departamento;
                        dropdownlist.add(option);
                    }
                },
                error: function (xhr) {
        console.log(xhr);
                    alert("Error", "Pregunta no se registro");
                }
            });
        }

        function L_D_Municipios(id_territorial, id_departamento) {
            //ID_selctor HTML #ContentPlaceHolder1_LD_Municipio
            var dropdownlist = document.getElementById('ContentPlaceHolder1_LD_Municipio');
            $.ajax({
        type: "GET",
                url: "/modulos/javascriptComun.aspx/L_D_Municipios?id_territorial=" + id_territorial + "&id_departamento=" + id_departamento,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //console.log(response.d);
                    var obj = JSON.parse(response.d.resultado);
                    console.log(obj);
                    $('#ContentPlaceHolder1_LD_Municipio').empty();
                    //adicionar el seleccionar
                    var option = document.createElement("option");
                    option.text = "seleccione Municipio"; option.value = "0"; dropdownlist.add(option);
                    for (var i = 0; i < obj.length; {
                        var option = document.createElement("option");
                        option.text = obj[i].municipio;
                        option.value = obj[i].id_municipio;
                        dropdownlist.add(option);
                    }
                },
                error: function (xhr) {
        console.log(xhr);
                    alert("Error", "Pregunta no se registro");
                }
            });
        }

   