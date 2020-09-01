<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="JavascriptComun.aspx.cs" Inherits="JavascriptComun" Title="MAARIV" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://maariv.unidadvictimas.gov.co/js/footable.min.js"></script>

    <script src="../../js/bootstrap-timepicker.js"></script>
    <script src="../../js/bootstrap-timepicker.min.js"></script>

    <div onclick="L_D_Territorial()">L_D_Territorial</div>
    <div onclick="L_D_Departamentos()">L_D_Departamentos</div>

    Territorial
    <asp:DropDownList ID="LD_Territorial" runat="server" 
        CssClass="form-control" >
    </asp:DropDownList>
    Departamento
    <asp:DropDownList ID="LD_Departamento" runat="server" 
        CssClass="form-control" >
    </asp:DropDownList>
    Municipios
    <asp:DropDownList ID="LD_Municipio" runat="server" 
        CssClass="form-control">
    </asp:DropDownList>


    <input type="file" id="file" />
    <div onclick="subir();">subir</div>
    

    <script>

        $('#ContentPlaceHolder1_LD_Territorial').change(function () {
            var id_territorial = $('#ContentPlaceHolder1_LD_Territorial').val();
            L_D_Departamentos(id_territorial);
        });

        $('#ContentPlaceHolder1_LD_Departamento').change(function () {
            var id_territorial = $('#ContentPlaceHolder1_LD_Territorial').val();
            var id_departamento = $('#ContentPlaceHolder1_LD_Departamento').val();
            L_D_Municipios(id_territorial, id_departamento);
        });

        function subir() { 
            var inputFileImage = $("#file").get();

            var formdata = new FormData();
            formdata.append("file", inputFileImage);
            console.log(inputFileImage[0].files[0]);
            $.ajax({
                type: "GET",
                data: formdata,
                url: "/modulos/javascriptComun.aspx/SubirArchivo",
                contentType: false,
                processData: false,
                async: false,
                success: function (response) {
                    console.log(response.d);
                    //var obj = JSON.parse(response.d.resultado);
                    //console.log(obj);
                },
                error: function (xhr) {
                    console.log(xhr);
                    alert("Error", "Pregunta no se registro");
                }
            });
        }

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
                    for (var i = 0; i < obj.length; i++) {
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
                    for (var i = 0; i < obj.length; i++) {
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
                    for (var i = 0; i < obj.length; i++) {
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
        
    </script>


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


</asp:Content>

