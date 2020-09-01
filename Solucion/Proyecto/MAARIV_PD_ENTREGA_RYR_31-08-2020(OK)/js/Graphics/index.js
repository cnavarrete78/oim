var graphic = new Graphic();

function Graphic() {

    var matriz = new Array();
    var data_x = new Array();
    var data_y = new Array();
    var labels = new Array();

    var titulo = "";

    //datasets
    var dataset = new Array();

    var colores = ["#3FBF3F", "#3FBFBF", "#30778e", "#3F7FBF", "#3F3FBF", "#7F3FBF", "#BF3FBF", "#BF3F7F", "#BF3F3F", "#BF7F3F", "#BFBF3F", "#7FBF3F"];

    this.init = function () {
        console.log("Construccion de graficas");
    };

    this.getData = function (id) {

        graphic.limpiar(); ///limpiar los datos
    
        //getMariz
        matriz = graphic.getMatriz(id); 

        //getLabels
        labels = graphic.getLabels(matriz);

        //getData_x
        data_x = graphic.getData_x(id);

        let encabezado = $('#' + id + ' tbody tr').children("th");

        //getData_y
        for (i = 0; i < matriz.length - 1; i++) { //por cada label
            for (j = 1; j < encabezado.length; j++) { //recorro la matriz
                //console.log(matriz[i+1][j].outerText);
                data_y.push(matriz[i + 1][j].outerText);
            }
            dataset.push({
                label: labels[i],
                data: data_y,
                backgroundColor: colores[i],
                borderWidth: 0,
            });
            data_y = new Array();
        }

        console.log(dataset);
        //construccion titulo panel
        titulo = $('#' + id + ' tbody tr').children("th")[0].outerText;
        $('#titulo_chart').html(titulo);
        //imprimir la grafica
        graphic.printChart(dataset, data_x);
        

    };

    this.printChart = function (dataset, data_x) {
        var printChartId = document.getElementById("printChartId");
        var printData = {
            labels: data_x,
            datasets: dataset
        };
        console.log(printData);
        //var chartOptions = {
            
        //};
        var barChart = new Chart(printChartId, {
            type: 'bar',
            data: printData
            //options: chartOptions
        });
    };

    this.getData_x = function (id) {
        let encabezado = $('#' + id + ' tbody tr').children("th");
        console.log("add data_x encabezado");
        for (i = 1; i < encabezado.length; i++) {
            data_x.push(encabezado[i].outerText);
        }
        console.log(data_x);
        return data_x;
    };

    this.getMatriz = function (id) {
        $('#' + id + ' tbody tr').each(function (index) {
            //for (var i = 0; i < array_number_datas.length; i++) {
            //    data_x.push($(this).children("td")[array_number_datas[i]].innerText);
            //}
            matriz.push($(this).children("td"));
        });
        console.log(id);
        console.log(matriz);
        return matriz;
    };

    this.getLabels = function (matriz) {
        console.log("add labels");
        for (i = 1; i < matriz.length; i++) {
            labels.push(matriz[i][0].outerText);
        }
        console.log(labels);
        return labels;
    };


    this.limpiar = function () {
        matriz = new Array();
        data_x = new Array();
        data_y = new Array();
        labels = new Array();
        dataset = new Array();
    };
}