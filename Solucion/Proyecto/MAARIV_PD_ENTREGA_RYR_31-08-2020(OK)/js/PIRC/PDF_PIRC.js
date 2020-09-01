Number.prototype.format = function (n, x, s, c) {
    var re = '\\d(?=(\\d{' + (x || 3) + '})+' + (n > 0 ? '\\D' : '$') + ')',
        num = this.toFixed(Math.max(0, ~~n));

    return (c ? num.replace('.', c) : num).replace(new RegExp(re, 'g'), '$&' + (s || ','));
};

var getLayoutHeader = function () {
    return {
        hLineWidth: function () {
            return 0.5;
        },
        vLineWidth: function () {
            return 0;
        },
        hLineColor: function () {
            return 'white';
        },
        vLineColor: function () {
            return 'white';
        }
    };
};

var getLayout = function () {
    return {
        hLineWidth: function () {
            return 0;
        },
        vLineWidth: function () {
            return 0;
        },
        hLineColor: function () {
            return 'white';
        },
        vLineColor: function () {
            return 'white';
        }
    };
};

var getLayoutImages = function () {
    return {
        hLineWidth: function () {
            return 0.1;
        },
        vLineWidth: function () {
            return 0.1;
        },
        hLineColor: function () {
            return 'white';
        },
        vLineColor: function () {
            return 'white';
        }
    };
};

var getDatosFormateados = async function (dataPDF) {

    var body = [];
    var fila = [];


    //Pagina 1 Presentación
    fila = [
        {
            text: 'PLAN INTEGRAL DE REPARACIÓN COLECTIVA',
            style: 'titlePIRC0'
        }
    ];

    body.push(fila);

    fila = [
        {
            text: dataPDF.nomSujeto,
            style: 'titlePIRC1'
        }
    ];

    body.push(fila);

    fila = [
        {
            text: dataPDF.tipoSujeto,
            style: 'titlePIRC2'
        }
    ];

    body.push(fila);

    fila = [
        {
            text: 'FECHA DE APROBACIÓN:',
            style: 'titlePIRC2'
        }
    ];

    body.push(fila);

    fila = [
        {
            text: 'Proyecto para contribuir a la reparación integral de los daños causados en el Sujeto Colectivo (' + dataPDF.nomSujeto + ') en el marco del conflicto armado',
            style: 'titlePIRC3'
        }
    ];

    body.push(fila);


    fila = [
        {
            margin: [0, 70, 0, 0],
            table: {
                widths: ['auto', '*'],
                body: [
                    [
                        {
                            text: 'Dirección Territorial o Grupo',
                            style: 'subtitlePIRC0'
                        },
                        {
                            text: dataPDF.territorialSujeto,
                            style: 'subtitlePIRC1'
                        }
                    ],
                    [
                        {
                            text: 'Profesional/es encargados de la formulación',
                            style: 'subtitlePIRC0'
                        },
                        {
                            text: 'Andrés Bonilla Laguna',
                            style: 'subtitlePIRC1'
                        }
                    ],
                    [
                        {
                            text: 'Subdirector/a de Reparación Colectiva',
                            style: 'subtitlePIRC0'
                        },
                        {
                            text: 'Juanita Ibañez Santamaría',
                            style: 'subtitlePIRC1'
                        }
                    ]
                ]
            }
        }
    ];

    body.push(fila);



    //Página 2 - tabla de contenidos
    fila = [
        {
            pageBreak: 'before',
            toc: {
                // id: 'mainToc'  // optional
                title: { text: 'Tabla de Contenido', style: 'headerTOC' },
                numberStyle: { bold: true }
            }
        }
    ];

    body.push(fila);


    //Inicio documento PIRC

    //1 - Arbol Problema 
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '1. IDENTIFICACIÓN DEL PROBLEMA',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    //console.log(dataPDF.datosPDF[0].IDENT_PROBLEMA);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].IDENT_PROBLEMA,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    //Figura Arbol Problema
    var filDat = await paintTree(dataPDF.apED, dataPDF.apCD, dataPDF.nomSujeto);
    
    fila = [
        {
            margin: [0, -10, 0, 0],
            pageBreak: 'before',
            pageOrientation: 'landscape',
            alignment: 'center',
            table: {
                body: filDat
            }
        }
    ];

    body.push(fila);


    //2 - Arbol Objetivos
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '2. IDENTIFICACIÓN DEL OBJETIVO GENERAL Y ESPECÍFICOS',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].IDENT_OBJETIVOS,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);


    //Figura Arbol Objetivos
    filDat = await paintTree2(dataPDF.apFD, dataPDF.apOB, dataPDF.nomSujeto);
    
    fila = [
        {
            margin: [0, -10, 0, 0],
            pageBreak: 'before',
            pageOrientation: 'landscape',
            alignment: 'center',
            table: {
                body: filDat
            }
        }
    ];

    body.push(fila);

    //3 - Análisis poblacion afectada-objetivo
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '3. ANÁLISIS DE LA POBLACIÓN AFECTADA Y POBLACIÓN OBJETIVO',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    //fila = [
    //    {
    //        margin: [0, 10, 0, 0],
    //        text: dataPDF.datosPDF[0].POBLACION_AFECT_OBJ,
    //        style: 'textPIRC1'
    //    }
    //];

    //body.push(fila);

    fila = [
        {
            margin: [0, 20, 0, 0],
            table: {
                widths: ['auto', '*', '*'],
                headerRows: 1,
                body: [
                    [
                        {
                            text: '',
                            style: 'headerTables'
                        },
                        {
                            text: 'Población Afectada',
                            style: 'headerTables'
                        },
                        {
                            text: 'Población Objetivo',
                            style: 'headerTables'
                        }
                    ],
                    [
                        {
                            text: 'Quiénes son',
                            style: 'headerTables'
                        },
                        {
                            text: dataPDF.pob.POB_AFEC_QUIEN,
                            style: 'bodyTables'
                        },
                        {
                            text: dataPDF.pob.POB_OBJ_QUIEN,
                            style: 'bodyTables'
                        }
                    ],
                    [
                        {
                            text: 'Características',
                            style: 'headerTables'
                        },
                        {
                            text: dataPDF.pob.POB_AFEC_CARAC,
                            style: 'bodyTables'
                        },
                        {
                            text: dataPDF.pob.POB_OBJ_CARAC,
                            style: 'bodyTables'
                        }
                    ],
                    [
                        {
                            text: 'Cantidad',
                            style: 'headerTables'
                        },
                        {
                            text: dataPDF.pob.POB_AFEC_CANT,
                            style: 'bodyTables'
                        },
                        {
                            text: dataPDF.pob.POB_OBJ_CANT,
                            style: 'bodyTables'
                        }
                    ],
                    [
                        {
                            text: 'Ubicación',
                            style: 'headerTables'
                        },
                        {
                            text: dataPDF.pob.POB_AFEC_UBICA,
                            style: 'bodyTables'
                        },
                        {
                            text: dataPDF.pob.POB_OBJ_UBICA,
                            style: 'bodyTables'
                        }
                    ]
                ]
            }
        }
    ];

    body.push(fila);


    //3.1 - DESCRIPCIÓN DE LA LOCALIZACIÓN DEL PIRC
    fila = [
        {
            margin: [0, 30, 0, 0],
            //pageBreak: 'before',
            text: '3.1. DESCRIPCIÓN DE LA LOCALIZACIÓN DEL PIRC',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [20, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    //fila = [
    //    {
    //        margin: [0, 10, 0, 0],
    //        text: dataPDF.datosPDF[0].LOCALIZACION,
    //        style: 'textPIRC1'
    //    }
    //];

    //body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].POBLACION_AFECT_OBJ,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);


    //5 -ANÁLISIS DE INVOLUCRADOS
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '4. ANÁLISIS DE INVOLUCRADOS',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    var datInvol = [];

    var filNew = [
        {
            text: 'Tipo de Actor',
            style: 'headerTables'
        },
        {
            text: 'Nombre del Actor',
            style: 'headerTables'
        },
        {
            text: 'Roles',
            style: 'headerTables'
        },
        {
            text: 'Interés - Expectativa',
            style: 'headerTables'
        },
        {
            text: 'Influencia',
            style: 'headerTables'
        },
        {
            text: 'Estrategia',
            style: 'headerTables'
        },
        {
            text: 'Contribución o razón del desacuerdo',
            style: 'headerTables'
        }
    ];

    datInvol.push(filNew);

    for (var i = 0; i < dataPDF.invol.length; i++)
    {
        filNew = [
            {
                text: dataPDF.invol[i].TipoActor,
                style: 'bodyTables'
            },
            {
                text: dataPDF.invol[i].NombreActor,
                style: 'bodyTables'
            },
            {
                text: dataPDF.invol[i].RolActor,
                style: 'bodyTables'
            },
            {
                text: dataPDF.invol[i].InteresActor,
                style: 'bodyTables'
            },
            {
                text: dataPDF.invol[i].InfluenciaActor,
                style: 'bodyTables'
            },
            {
                text: dataPDF.invol[i].EstrategiaActor,
                style: 'bodyTables'
            },
            {
                text: dataPDF.invol[i].ContribucionActor,
                style: 'bodyTables'
            }
        ];

        datInvol.push(filNew);
    }

    //console.log("involuc");
    //console.log(datInvol);

    fila = [
        {
            margin: [0, 20, 0, 0],
            table: {
                headerRows: 1,
                body: datInvol
            }
        }
    ];

    body.push(fila);


    //6 - DESCRIPCIÓN DEL PIRC
    fila = [
        {
            margin: [0, 30, 0, 0],
            //pageBreak: 'before',
            text: '5. DESCRIPCIÓN DEL PIRC',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].BENEFICIOS_PIRC,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);


    //7 - CADENA DE VALOR
    fila = [
        {
            margin: [0, 30, 0, 0],
            //pageBreak: 'before',
            text: '6. CADENA DE VALOR',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: '“La cadena de valor es la relación secuencial y lógica entre insumos, actividades, productos y resultados en la que se añade valor a lo largo del proceso de transformación total. Se puede decir que en una primera etapa de la cadena de valor se toman insumos, que tienen unos costos asociados, y bajo alguna tecnología y procesos (llamados actividades), se transforman en productos (bienes y servicios)”\n\nA continuación se relaciona la cadena de valor a través de identificar los productos, actividades y unidad de medida para cada producto concatenado con los objetivos específicos.Para mayor comprensión, a continuación, se definen cada uno de los productos y sus respectivas actividades, por atributo.',
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    //console.log("CV");
    //console.log(dataPDF.CV);

    var datCV = [];

    for (var i = 0; i < dataPDF.CV.length; i++)
    {
        fila = [
            {
                margin: [0, 10, 0, 0],
                //pageBreak: 'before',
                text: '6.' + (i + 1) + ' Objetivo Específico: ' + dataPDF.CV[i].ObjetivoEspecifico + ' (' + dataPDF.CV[i].Atributo + ')',
                style: 'headerTOCItem',
                tocItem: true,
                tocStyle: 'headerTOCItem2',
                tocMargin: [20, 10, 0, 0],
                pageOrientation: 'portrait'
            }
        ];

        body.push(fila);

        for(var j = 0; j < dataPDF.CV[i].Productos.length; j++)
        {
            fila = [
                {
                    margin: [0, 10, 0, 0],
                    //pageBreak: 'before',
                    text: '6.' + (i + 1) + '.' + (j + 1) + ' Producto: ' + dataPDF.CV[i].Productos[j].Producto,
                    style: 'headerTOCItem',
                    tocItem: true,
                    tocStyle: 'headerTOCItem2',
                    tocMargin: [30, 10, 0, 0],
                    pageOrientation: 'portrait'
                }
            ];

            body.push(fila);

            fila = [
                {
                    margin: [0, 10, 0, 0],
                    text: dataPDF.CV[i].Productos[j].Descripcion,
                    style: 'textPIRC1'
                }
            ];

            body.push(fila);

            fila = [
                {
                    margin: [0, 20, 0, 0],
                    text: dataPDF.CV[i].Productos[j].Justificacion,
                    style: 'textPIRC1'
                }
            ];

            body.push(fila);

            fila = [
                {
                    margin: [0, 20, 0, 0],
                    text: 'Para el desarrollo de este producto se contemplan las siguientes actividades: ',
                    style: 'textPIRC1'
                }
            ];

            body.push(fila);

            for(var k = 0; k < dataPDF.CV[i].Productos[j].Actividades.length; k++)
            {
                fila = [
                    {
                        margin: [0, 10, 0, 0],
                        //pageBreak: 'before',
                        text: '6.' + (i + 1) + '.' + (j + 1) + '.' + (k + 1) + ' Actividad: ' + dataPDF.CV[i].Productos[j].Actividades[k].Actividades,
                        style: 'headerTOCItem',
                        tocItem: true,
                        tocStyle: 'headerTOCItem2',
                        tocMargin: [40, 10, 0, 0],
                        pageOrientation: 'portrait'
                    }
                ];

                body.push(fila);

                fila = [
                {
                    margin: [0, 20, 0, 0],
                    text: dataPDF.CV[i].Productos[j].Actividades[k].Descripcion,
                    style: 'textPIRC1'
                }
                ];

                body.push(fila);
            }


            fila = [
                {
                    margin: [0, 20, 0, 0],
                    text: 'El contenido de este producto al corresponder a una medida de ' + dataPDF.CV[i].Productos[j].Medida + ', ha sido avalado técnicamente por XXXXX',
                    style: 'textPIRC1'
                }
            ];

            body.push(fila);
        }
    }


    //8 - COSTEO DE PIRC
    fila = [
        {
            margin: [0, 30, 0, 0],
            pageBreak: 'before',
            text: '7. COSTEO DE PIRC',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'landscape'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: 'El coste total de este es de ' + dataPDF.totalPIRC + ' millones de pesos para una vigencia de 3 años. Es de aclarar que estos costos pueden variar en la implementación del proyecto. A continuación, se detalla el costo por actividad y año.',
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    //Tabla cadena de valor
    var dataTabCV = [];

    var filTabCV = [
        {
            colSpan: 3,
            text: 'OBJETIVO GENERAL',
            style: 'headerTables'
        }, {}, {},
        {
            colSpan: 4,
            text: 'Contribuir a la reparación integral de los daños causados en el Sujeto Colectivo ' + dataPDF.nomSujeto + ', en el marco del conflicto armado.',
            style: 'bodyTables'
        }, {}, {}, {}
    ];

    dataTabCV.push(filTabCV);

    filTabCV = [
        {
            rowSpan: 2,
            text: 'OBJETIVO ESPECÍFICO',
            style: 'headerTables'
        },
        {
            rowSpan: 2,
            text: 'PRODUCTO',
            style: 'headerTables'
        },
        {
            rowSpan: 2,
            text: 'ACTIVIDAD',
            style: 'headerTables'
        },
        {
            colSpan: 4,
            text: 'COSTO POR AÑO',
            style: 'headerTables'
        }, {}, {}, {}
    ];

    dataTabCV.push(filTabCV);

    filTabCV = [
        {}, {}, {},
        {
            text: 'AÑO 1',
            style: 'headerTables'
        },
        {
            text: 'AÑO 2',
            style: 'headerTables'
        },
        {
            text: 'AÑO 3',
            style: 'headerTables'
        },
        {
            text: 'TOTAL',
            style: 'headerTables'
        }
    ];

    dataTabCV.push(filTabCV);
    var prod = "";

    for (var i = 0; i < dataPDF.CV.length; i++) {
        for (var j = 0; j < dataPDF.CV[i].Productos.length; j++) {
            for (var k = 0; k < dataPDF.CV[i].Productos[j].Actividades.length; k++) {
                if(dataPDF.CV[i].rowSpan == null)
                {
                    dataPDF.CV[i].rowSpan = 0;
                }
                if (dataPDF.CV[i].totalA1 == null) {
                    dataPDF.CV[i].totalA1 = 0;
                }
                if (dataPDF.CV[i].totalA2 == null) {
                    dataPDF.CV[i].totalA2 = 0;
                }
                if (dataPDF.CV[i].totalA3 == null) {
                    dataPDF.CV[i].totalA3 = 0;
                }
                if (dataPDF.CV[i].totalAT == null) {
                    dataPDF.CV[i].totalAT = 0;
                }

                if (dataPDF.CV[i].Productos[j].rowSpan == null)
                {
                    dataPDF.CV[i].Productos[j].rowSpan = 0;
                }
                if (dataPDF.CV[i].Productos[j].totalA1 == null) {
                    dataPDF.CV[i].Productos[j].totalA1 = 0;
                }
                if (dataPDF.CV[i].Productos[j].totalA2 == null) {
                    dataPDF.CV[i].Productos[j].totalA2 = 0;
                }
                if (dataPDF.CV[i].Productos[j].totalA3 == null) {
                    dataPDF.CV[i].Productos[j].totalA3 = 0;
                }
                if (dataPDF.CV[i].Productos[j].totalAT == null) {
                    dataPDF.CV[i].Productos[j].totalAT = 0;
                }

                dataPDF.CV[i].rowSpan++;
                dataPDF.CV[i].Productos[j].rowSpan++;

                dataPDF.CV[i].totalA1 += dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno1;
                dataPDF.CV[i].totalA2 += dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno2;
                dataPDF.CV[i].totalA3 += dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno3;
                dataPDF.CV[i].totalAT += dataPDF.CV[i].Productos[j].Actividades[k].CostoTotal;

                dataPDF.CV[i].Productos[j].totalA1 += dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno1;
                dataPDF.CV[i].Productos[j].totalA2 += dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno2;
                dataPDF.CV[i].Productos[j].totalA3 += dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno3;
                dataPDF.CV[i].Productos[j].totalAT += dataPDF.CV[i].Productos[j].Actividades[k].CostoTotal;
            }
        }
    }

    for (var i = 0; i < dataPDF.CV.length; i++)
    {
        for (var j = 0; j < dataPDF.CV[i].Productos.length; j++)
        {
            for(var k = 0; k < dataPDF.CV[i].Productos[j].Actividades.length; k++)
            {
                filTabCV = [];

                var c1 = {};
                var c2 = {};
                var c3 = {};
                var c4 = {};
                var c5 = {};
                var c6 = {};
                var c7 = {};                

                if (k == 0 || dataPDF.CV[i].ObjetivoEspecifico != prod) {
                    c1 = {
                        rowSpan: dataPDF.CV[i].rowSpan + (dataPDF.CV[i].Productos.length == 1 ? 1 : (1 * dataPDF.CV[i].Productos.length - 1)),
                        text: dataPDF.CV[i].ObjetivoEspecifico,
                        style: 'headerTables'
                    };
                } else {
                    c1 = {};
                }

                //console.log("C1");
                //console.log(c1);

                filTabCV.push(c1);

                if(k == 0)
                {
                    c2 = {
                        rowSpan: dataPDF.CV[i].Productos[j].rowSpan,
                        text: dataPDF.CV[i].Productos[j].Producto,
                        style: 'bodyTables'
                    };
                } else
                {
                    c2 = {};
                }

                filTabCV.push(c2);

                c3 = {
                    text: dataPDF.CV[i].Productos[j].Actividades[k].Actividades,
                    style: 'bodyTables'
                };

                c4 = {
                    text: '$' + Number(dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno1).format(0, 3, '.', ','),
                    style: 'bodyTables'
                };

                c5 = {
                    text: '$' + Number(dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno2).format(0, 3, '.', ','),
                    style: 'bodyTables'
                };

                c6 = {
                    text: '$' + Number(dataPDF.CV[i].Productos[j].Actividades[k].CostoAnno3).format(0, 3, '.', ','),
                    style: 'bodyTables'
                };

                c7 = {
                    text: '$' + Number(dataPDF.CV[i].Productos[j].Actividades[k].CostoTotal).format(0, 3, '.', ','),
                    style: 'bodyTables'
                };

                filTabCV.push(c3);
                filTabCV.push(c4);
                filTabCV.push(c5);
                filTabCV.push(c6);
                filTabCV.push(c7);

                prod = dataPDF.CV[i].ObjetivoEspecifico;

                dataTabCV.push(filTabCV);
            }

            filTabCV = [];

            var c1 = {};
            var c2 = {};
            var c3 = {};
            var c4 = {};
            var c5 = {};
            var c6 = {};
            var c7 = {};

            if (j == 0 || dataPDF.CV[i].Productos[j].rowSpan > dataPDF.CV[i].Productos[j].Actividades.length)
            {
                c1 = {};
                c2 = {
                    colSpan: 2,
                    text: 'TOTAL PRODUCTO',
                    style: 'headerTables',
                    alignment: 'right'
                };
            } else
            {
                c1 = {
                    colSpan: 3,
                    text: 'TOTAL PRODUCTO',
                    style: 'headerTables',
                    alignment: 'right'
                };
                c2 = {};
            }

            c3 = {};

            c4 = {
                text: '$' + Number(dataPDF.CV[i].Productos[j].totalA1).format(0, 3, '.', ','),
                style: 'bodyTables'
            };

            c5 = {
                text: '$' + Number(dataPDF.CV[i].Productos[j].totalA2).format(0, 3, '.', ','),
                style: 'bodyTables'
            };

            c6 = {
                text: '$' + Number(dataPDF.CV[i].Productos[j].totalA3).format(0, 3, '.', ','),
                style: 'bodyTables'
            };

            c7 = {
                text: '$' + Number(dataPDF.CV[i].Productos[j].totalAT).format(0, 3, '.', ','),
                style: 'bodyTables'
            };

            filTabCV.push(c1);
            filTabCV.push(c2);
            filTabCV.push(c3);
            filTabCV.push(c4);
            filTabCV.push(c5);
            filTabCV.push(c6);
            filTabCV.push(c7);

            dataTabCV.push(filTabCV);
        }

        filTabCV = [
                {
                    colSpan: 3,
                    text: 'TOTAL OBJETIVO',
                    style: 'headerTables',
                    alignment: 'right'
                }, {}, {},
                {
                    text: '$' + Number(dataPDF.CV[i].totalA1).format(0, 3, '.', ','),
                    style: 'bodyTables'
                },
                {
                    text: '$' + Number(dataPDF.CV[i].totalA2).format(0, 3, '.', ','),
                    style: 'bodyTables'
                },
                {
                    text: '$' + Number(dataPDF.CV[i].totalA3).format(0, 3, '.', ','),
                    style: 'bodyTables'
                },
                {
                    text: '$' + Number(dataPDF.CV[i].totalAT).format(0, 3, '.', ','),
                    style: 'bodyTables'
                }
        ];

        dataTabCV.push(filTabCV);
    }

    fila = [
        {
            margin: [0, 20, 0, 0],
            //pageBreak: 'before',
            //pageOrientation: 'landscape',
            table: {
                body: dataTabCV
            }
        }
    ];

    body.push(fila);


    //9 - RAZONES POR LAS CUALES EL PIRC DEBE IMPLEMENTARSE
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '8. RAZONES POR LAS CUALES EL PIRC DEBE IMPLEMENTARSE',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            //pageBreak: 'before',
            text: '8.1 Aspectos Estratégicos',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [30, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].ASPECTO_ESTRATEG,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            //pageBreak: 'before',
            text: '8.2 Aspectos Legales',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [30, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].ASPECTO_LEGAL,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            //pageBreak: 'before',
            text: '8.3 Aspectos Técnicos',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [30, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].ASPECTO_TECNICO,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            //pageBreak: 'before',
            text: '8.4 Aspectos Financieros',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [30, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].ASPECTO_FINANCIERO,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            //pageBreak: 'before',
            text: '8.5 Aspectos Sostenibilidad',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [30, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].ASPECTO_SOSTENIBILIDAD,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            //pageBreak: 'before',
            text: '8.6 Aspectos Políticos',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [30, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].ASPECTO_POLITICO,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            //pageBreak: 'before',
            text: '8.7 Aspectos Sociales',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [30, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].ASPECTO_SOCIAL,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);


    //10 - IMPLICACIONES INSTITUCIONALES DE NO IMPLEMENTAR EL PIRC
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '9. IMPLICACIONES INSTITUCIONALES DE NO IMPLEMENTAR EL PIRC',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: dataPDF.datosPDF[0].IMPLICAC_INSTITUCIONALES,
            style: 'textPIRC1'
        }
    ];

    body.push(fila);


    //11 - RIESGOS INICIALES IDENTIFICADOS
    fila = [
        {
            margin: [0, -10, 0, 0],
            pageBreak: 'before',
            text: '10. RIESGOS INICIALES IDENTIFICADOS',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'landscape'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 5, 0, 0],
            text: 'Teniendo claridad de las actividades que se van a desarrollar durante el horizonte del proyecto, los productos que se quieren obtener y el objetivo que se pretende alcanzar, se han identificado los siguientes riesgos para cada uno de los niveles:',
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    //Tabla riesgos
    var dataTabRiesgos = [];

    var filTabRiesgos = [
        {
            text: 'NIVEL DE CLASIFICACIÓN',
            style: 'headerTables'
        },
        {
            text: 'NOMBRE DE LA ACTIVIDAD/PRODUCTO/OBJETIVO',
            style: 'headerTables'
        },
        {
            text: 'DESCRIPCIÓN',
            style: 'headerTables'
        },
        {
            text: 'TIPO DE RIESGO',
            style: 'headerTables'
        },
        {
            text: 'PROBABILIDAD',
            style: 'headerTables'
        },
        {
            text: 'IMPACTOS',
            style: 'headerTables'
        },
        {
            text: 'EFECTO',
            style: 'headerTables'
        },
        {
            text: 'MEDIDAS DE MITIGACIÓN',
            style: 'headerTables'
        }
    ];

    dataTabRiesgos.push(filTabRiesgos);

    filTabRiesgos = [];
    
    //Riesgos obj general
    for (var i = 0; i < dataPDF.riesgosObj.length; i++)
    {
        filTabRiesgos = [];

        var c1 = {};
        var c2 = {};
        var c3 = {};
        var c4 = {};
        var c5 = {};
        var c6 = {};
        var c7 = {};
        var c8 = {};

        if(i == 0)
        {
            c1 = {
                rowSpan: dataPDF.riesgosObj.length,
                text: 'OBJ. GENERAL',
                style: 'headerTables'
            };

            c2 = {
                rowSpan: dataPDF.riesgosObj.length,
                text: 'Contribuir a la reparación integral de los daños causados en el Sujeto Colectivo ' + dataPDF.nomSujeto + ', en el marco del conflicto armado.',
                style: 'bodyTables'
            };
        }
        else {
            c1 = {};
            c2 = {};
        }

        c3 = {
            text: dataPDF.riesgosObj[i].DescripcionRiesgo,
            style: 'bodyTables'
        };

        c4 = {
            text: dataPDF.riesgosObj[i].TipoRiesgo,
            style: 'bodyTables'
        };

        c5 = {
            text: dataPDF.riesgosObj[i].ProbabilidadRiesgo,
            style: 'bodyTables'
        };

        c6 = {
            text: dataPDF.riesgosObj[i].ImpactoRiesgo,
            style: 'bodyTables'
        };

        c7 = {
            text: dataPDF.riesgosObj[i].EfectoRiesgo.replace('|','\n').replace('|','\n'),
            style: 'bodyTables'
        };

        c8 = {
            text: dataPDF.riesgosObj[i].MitigacionRiesgo.replace('|','\n').replace('|','\n'),
            style: 'bodyTables'
        };

        //var efectos = dataPDF.riesgosObj[i].EfectoRiesgo.split('|');

        //var tabEfect = [];
        //var filEfect = [];
        //var efc = "";

        //for (var j = 0; j < efectos.length; j++)
        //{
        //    filEfect = [
        //        {
        //            border: [false, false, false, true],
        //            text: efectos[j],
        //            style: 'bodyTables'
        //        }
        //    ];

        //    tabEfect.push(filEfect);
        //}

        //c7 = {
        //    margin: [0, 0, 0, 0],
        //    table: {
        //        widths: ['auto'],
        //        body: tabEfect
        //    }
        //};


        //var medidas = dataPDF.riesgosObj[i].MitigacionRiesgo.split('|');

        //var tabMedid = [];
        //var filMedid = [];
        //var med = "";

        //for (var j = 0; j < medidas.length; j++) {
        //    filMedid = [
        //        {
        //            border: [false, false, false, true],
        //            text: medidas[j],
        //            style: 'bodyTables'
        //        }
        //    ];

        //    tabMedid.push(filMedid);
        //}

        //c8 = {
        //    margin: [0, 0, 0, 0],
        //    table: {
        //        widths: ['*'],
        //        body: tabMedid
        //    }
        //};

        filTabRiesgos.push(c1);
        filTabRiesgos.push(c2);
        filTabRiesgos.push(c3);
        filTabRiesgos.push(c4);
        filTabRiesgos.push(c5);
        filTabRiesgos.push(c6);
        filTabRiesgos.push(c7);
        filTabRiesgos.push(c8);

        dataTabRiesgos.push(filTabRiesgos);
    }


    //Riesgos Productos
    var rowspanRProd = 0;

    for (var i = 0; i < dataPDF.riesgosProd.length; i++) {
        for (var j = 0; j < dataPDF.riesgosProd[i].Riesgos.length; j++) {
            rowspanRProd++;
        }
    }

    for (var i = 0; i < dataPDF.riesgosProd.length; i++)
    {
        for (var j = 0; j < dataPDF.riesgosProd[i].Riesgos.length; j++)
        {
            filTabRiesgos = [];

            var c1 = {};
            var c2 = {};
            var c3 = {};
            var c4 = {};
            var c5 = {};
            var c6 = {};
            var c7 = {};
            var c8 = {};

            if (i == 0 && j == 0) {
                c1 = {
                    rowSpan: rowspanRProd,
                    text: 'PRODUCTOS',
                    style: 'headerTables'
                };
            }
            else {
                c1 = {};
            }

            if (j == 0)
            {
                if (dataPDF.riesgosProd[i].Riesgos.length == 1)
                {
                    c2 = {
                        text: dataPDF.riesgosProd[i].Nombre,
                        style: 'bodyTables'
                    };

                } else {
                    c2 = {
                        rowSpan: dataPDF.riesgosProd[i].Riesgos.length,
                        text: dataPDF.riesgosProd[i].Nombre,
                        style: 'bodyTables'
                    };
                }
                
            } else
            {
                c2 = {};
            }

            c3 = {
                text: dataPDF.riesgosProd[i].Riesgos[j].DescripcionRiesgo,
                style: 'bodyTables'
            };

            c4 = {
                text: dataPDF.riesgosProd[i].Riesgos[j].TipoRiesgo,
                style: 'bodyTables'
            };

            c5 = {
                text: dataPDF.riesgosProd[i].Riesgos[j].ProbabilidadRiesgo,
                style: 'bodyTables'
            };

            c6 = {
                text: dataPDF.riesgosProd[i].Riesgos[j].ImpactoRiesgo,
                style: 'bodyTables'
            };

            c7 = {
                text: dataPDF.riesgosProd[i].Riesgos[j].EfectoRiesgo.replace('|','\n').replace('|','\n'),
                style: 'bodyTables'
            };

            c8 = {
                text: dataPDF.riesgosProd[i].Riesgos[j].MitigacionRiesgo.replace('|','\n').replace('|','\n'),
                style: 'bodyTables'
            };

            //var efectos = dataPDF.riesgosProd[i].Riesgos[j].EfectoRiesgo.split('|');

            //var tabEfect = [];
            //var filEfect = [];
            //var efc = "";

            //for (var k = 0; k < efectos.length; j++) {
            //    filEfect = [
            //        {
            //            border: [false, false, false, true],
            //            text: efectos[k],
            //            style: 'bodyTables'
            //        }
            //    ];

            //    tabEfect.push(filEfect);
            //}

            //c7 = {
            //    margin: [0, 0, 0, 0],
            //    table: {
            //        widths: ['auto'],
            //        body: tabEfect
            //    }
            //};
            
            //var medidas = dataPDF.riesgosProd[i].Riesgos[j].MitigacionRiesgo.split('|');

            //var tabMedid = [];
            //var filMedid = [];
            //var med = "";

            //for (var k = 0; k < medidas.length; j++) {
            //    filMedid = [
            //        {
            //            border: [false, false, false, true],
            //            text: medidas[k],
            //            style: 'bodyTables'
            //        }
            //    ];

            //    tabMedid.push(filMedid);
            //}

            //c8 = {
            //    margin: [0, 0, 0, 0],
            //    table: {
            //        widths: ['*'],
            //        body: tabMedid
            //    }
            //};

            filTabRiesgos.push(c1);
            filTabRiesgos.push(c2);
            filTabRiesgos.push(c3);
            filTabRiesgos.push(c4);
            filTabRiesgos.push(c5);
            filTabRiesgos.push(c6);
            filTabRiesgos.push(c7);
            filTabRiesgos.push(c8);

            dataTabRiesgos.push(filTabRiesgos);
        }        
    }

    //Riesgos Actividades
    var rowspanRAct = 0;

    for (var i = 0; i < dataPDF.riesgosActs.length; i++) {
        for (var j = 0; j < dataPDF.riesgosActs[i].Riesgos.length; j++) {
            rowspanRAct++;
        }
    }

    for (var i = 0; i < dataPDF.riesgosActs.length; i++) {
        for (var j = 0; j < dataPDF.riesgosActs[i].Riesgos.length; j++) {
            filTabRiesgos = [];

            var c1 = {};
            var c2 = {};
            var c3 = {};
            var c4 = {};
            var c5 = {};
            var c6 = {};
            var c7 = {};
            var c8 = {};

            if (i == 0 && j == 0) {
                c1 = {
                    rowSpan: rowspanRAct,
                    text: 'ACTIVIDADES',
                    style: 'headerTables'
                };
            }
            else {
                c1 = {};
            }

            if (j == 0) {
                if (dataPDF.riesgosActs[i].Riesgos.length == 1) {
                    c2 = {
                        text: dataPDF.riesgosActs[i].Nombre,
                        style: 'bodyTables'
                    };

                } else {
                    c2 = {
                        rowSpan: dataPDF.riesgosActs[i].Riesgos.length,
                        text: dataPDF.riesgosActs[i].Nombre,
                        style: 'bodyTables'
                    };
                }

            } else {
                c2 = {};
            }

            c3 = {
                text: dataPDF.riesgosActs[i].Riesgos[j].DescripcionRiesgo,
                style: 'bodyTables'
            };

            c4 = {
                text: dataPDF.riesgosActs[i].Riesgos[j].TipoRiesgo,
                style: 'bodyTables'
            };

            c5 = {
                text: dataPDF.riesgosActs[i].Riesgos[j].ProbabilidadRiesgo,
                style: 'bodyTables'
            };

            c6 = {
                text: dataPDF.riesgosActs[i].Riesgos[j].ImpactoRiesgo,
                style: 'bodyTables'
            };

            c7 = {
                text: dataPDF.riesgosActs[i].Riesgos[j].EfectoRiesgo.replace('|','\n').replace('|','\n'),
                style: 'bodyTables'
            };

            c8 = {
                text: dataPDF.riesgosActs[i].Riesgos[j].MitigacionRiesgo.replace('|','\n').replace('|','\n'),
                style: 'bodyTables'
            };
            
            filTabRiesgos.push(c1);
            filTabRiesgos.push(c2);
            filTabRiesgos.push(c3);
            filTabRiesgos.push(c4);
            filTabRiesgos.push(c5);
            filTabRiesgos.push(c6);
            filTabRiesgos.push(c7);
            filTabRiesgos.push(c8);

            dataTabRiesgos.push(filTabRiesgos);
        }
    }

    fila = [
        {
            margin: [0, 5, 0, 0],
            table: {
                headerRows: 1,
                body: dataTabRiesgos
            }
        }
    ];

    body.push(fila);


    //12 - BENEFICIOS DEL PIRC
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '11. BENEFICIOS DEL PIRC',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: 'Es la riqueza en el ámbito social, ambiental o económico que obtiene la población objetivo en el momento que se decide ejecutar el PIRC',
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    //Tabla beneficios
    var dataTabBene = [];
    var filTabBene = [];

    filTabBene = [
        {
            text: 'BENEFICIO',
            style: 'headerTables'
        },
        {
            text: 'DESCRIPCIÓN',
            style: 'headerTables'
        }
    ];

    dataTabBene.push(filTabBene);

    for (var i = 0; i < dataPDF.bene.length; i++)
    {
        filTabBene = [
            {
                text: dataPDF.bene[i].NombreBeneficio,
                style: 'bodyTables'
            },
            {
                text: dataPDF.bene[i].DescripcionBeneficio,
                style: 'bodyTables'
            }
        ];

        dataTabBene.push(filTabBene);
    }

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 1,
                body: dataTabBene
            }
        }
    ];

    body.push(fila);



    //13 - INDICADORES DE SEGUIMIENTO
    fila = [
        {
            margin: [0, -10, 0, 0],
            pageBreak: 'before',
            text: '12. INDICADORES DE SEGUIMIENTO',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'landscape'
        }
    ];

    body.push(fila);


    //Tabla indicadores seg 
    var dataTabInd = [];
    var filTabInd = [];

    //Ind resultado
    filTabInd = [
        {
            colSpan: 4,
            text: 'INDICADOR DE RESULTADO',
            style: 'headerTables'
        }, {}, {}, {}
    ];

    dataTabInd.push(filTabInd);

    filTabInd = [
        {
            text: 'DESCRIPCIÓN',
            style: 'headerTables'
        },
        {
            text: 'META TOTAL',
            style: 'headerTables'
        },
        {
            text: 'TIPO DE FUENTE',
            style: 'headerTables'
        },
        {
            text: 'FUENTE',
            style: 'headerTables'
        }
    ];

    dataTabInd.push(filTabInd);

    filTabInd = [
        {
            text: 'Productos del Plan Integral de Reparación Colectiva Implementados',
            style: 'bodyTables'
        },
        {
            text: dataPDF.metaTotalPIRC,
            style: 'bodyTables'
        },
        {
            text: 'Documento Oficial',
            style: 'bodyTables'
        },
        {
            text: 'PIRC ' + dataPDF.nomSujeto,
            style: 'bodyTables'
        }
    ];

    dataTabInd.push(filTabInd);

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 2,
                body: dataTabInd
            }
        }
    ];

    body.push(fila);

    //Ind Producto
    dataTabInd = [];
    filTabInd = [];

    filTabInd = [
        {
            colSpan: 9,
            text: 'INDICADORES DE PRODUCTO',
            style: 'headerTables'
        }, {}, {}, {}, {}, {}, {}, {}, {}
    ];

    dataTabInd.push(filTabInd);

    filTabInd = [
        {
            text: 'PRODUCTO',
            style: 'headerTables'
        },
        {
            text: 'INDICADOR DE PRODUCTO',
            style: 'headerTables'
        },
        {
            text: 'UNIDAD DE MEDIDA',
            style: 'headerTables'
        },
        {
            text: 'META TOTAL',
            style: 'headerTables'
        },
        {
            text: 'AÑO 1',
            style: 'headerTables'
        },
        {
            text: 'AÑO 2',
            style: 'headerTables'
        },
        {
            text: 'AÑO 3',
            style: 'headerTables'
        },
        {
            text: 'TIPO DE FUENTE',
            style: 'headerTables'
        },
        {
            text: 'FUENTE',
            style: 'headerTables'
        }
    ];

    dataTabInd.push(filTabInd);

    for (var i = 0; i < dataPDF.indProds.length; i++)
    {
        filTabInd = [
            {
                text: dataPDF.indProds[i].Producto,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].Indicador,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].UnidadMedida,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].MetaTotal,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].Anno1,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].Anno2,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].Anno3,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].TipoFuente,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indProds[i].Fuente,
                style: 'bodyTables'
            }
        ];

        dataTabInd.push(filTabInd);
    }

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 2,
                body: dataTabInd
            }
        }
    ];

    body.push(fila);


    //Ind Acts
    dataTabInd = [];
    filTabInd = [];

    filTabInd = [
        {
            colSpan: 8,
            text: 'INDICADORES DE GESTIÓN',
            style: 'headerTables'
        }, {}, {}, {}, {}, {}, {}, {}
    ];

    dataTabInd.push(filTabInd);

    filTabInd = [
        {
            text: 'ACTIVIDAD',
            style: 'headerTables'
        },
        {
            text: 'INDICADOR DE GESTIÓN',
            style: 'headerTables'
        },
        {
            text: 'UNIDAD DE MEDIDA',
            style: 'headerTables'
        },
        {
            text: 'AÑO 1',
            style: 'headerTables'
        },
        {
            text: 'AÑO 2',
            style: 'headerTables'
        },
        {
            text: 'AÑO 3',
            style: 'headerTables'
        },
        {
            text: 'TIPO DE FUENTE',
            style: 'headerTables'
        },
        {
            text: 'FUENTE',
            style: 'headerTables'
        }
    ];

    dataTabInd.push(filTabInd);

    for (var i = 0; i < dataPDF.indActs.length; i++)
    {
        filTabInd = [
            {
                text: dataPDF.indActs[i].Actividad,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indActs[i].Indicador,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indActs[i].UnidadMedida,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indActs[i].Anno1,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indActs[i].Anno2,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indActs[i].Anno3,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indActs[i].TipoFuente,
                style: 'bodyTables'
            },
            {
                text: dataPDF.indActs[i].Fuente,
                style: 'bodyTables'
            }
        ];

        dataTabInd.push(filTabInd);
    }

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 2,
                body: dataTabInd
            }
        }
    ];

    body.push(fila);




    //14 - CRONOGRAMA
    fila = [
        {
            margin: [0, -10, 0, 0],
            pageBreak: 'before',
            text: '13. CRONOGRAMA',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'landscape'
        }
    ];

    body.push(fila);

    //tab cronograma
    var tabCrono = [];
    var filCrono = [];

    filCrono = [
        {
            rowSpan: 3,
            text: 'OBJETIVO ESPECÍFICO',
            style: 'headerTables'
        },
        {
            rowSpan: 3,
            text: 'PRODUCTO',
            style: 'headerTables'
        },
        {
            rowSpan: 3,
            text: 'ACTIVIDADES',
            style: 'headerTables'
        },
        {
            rowSpan: 3,
            text: 'TAREAS',
            style: 'headerTables'
        },
        {
            rowSpan: 3,
            text: 'RESPONSABLES',
            style: 'headerTables'
        },
        {
            colSpan: 6,
            text: 'CRONOGRAMA DEL PROYECTO',
            style: 'headerTables'
        }, {}, {}, {}, {}, {}
    ];
    
    tabCrono.push(filCrono);

    filCrono = [
        {
        },
        {
        },
        {
        },
        {
        },
        {
        },
        {
            colSpan: 2,
            text: 'AÑO 1',
            style: 'headerTables'
        }, {},
        {
            colSpan: 2,
            text: 'AÑO 2',
            style: 'headerTables'
        }, {},
        {
            colSpan: 2,
            text: 'AÑO 3',
            style: 'headerTables'
        }, {}
    ];

    tabCrono.push(filCrono);

    filCrono = [
        {
        },
        {
        },
        {
        },
        {
        },
        {
        },
        {
            text: 'Fecha Inicial',
            style: 'headerTables'
        },
        {
            text: 'Fecha Final',
            style: 'headerTables'
        },
        {
            text: 'Fecha Inicial',
            style: 'headerTables'
        },
        {
            text: 'Fecha Final',
            style: 'headerTables'
        },
        {
            text: 'Fecha Inicial',
            style: 'headerTables'
        },
        {
            text: 'Fecha Final',
            style: 'headerTables'
        }
    ];

    tabCrono.push(filCrono);

    var rowsPanObjCrono = 0;

    for (var i = 0; i < dataPDF.crono.length; i++)
    {
        for(var j = 0; j < dataPDF.crono[i].Productos.length; j++)
        {
            for(var k = 0; k < dataPDF.crono[i].Productos[j].Actividades.length; k++)
            {
                for(var l = 0; l < dataPDF.crono[i].Productos[j].Actividades[k].Tareas.length; l++)
                {
                    if (dataPDF.crono[i].rowsPan == null)
                    {
                        dataPDF.crono[i].rowsPan = 0;
                    }

                    if (dataPDF.crono[i].Productos[j].rowSpan == null)
                    {
                        dataPDF.crono[i].Productos[j].rowSpan = 0;
                    }

                    if (dataPDF.crono[i].Productos[j].Actividades[k].rowSpan == null)
                    {
                        dataPDF.crono[i].Productos[j].Actividades[k].rowSpan = 0;
                    }

                    dataPDF.crono[i].rowsPan++;
                    dataPDF.crono[i].Productos[j].rowSpan++;
                    dataPDF.crono[i].Productos[j].Actividades[k].rowSpan++;
                }
            }
        }
    }

    for (var i = 0; i < dataPDF.crono.length; i++) {
        for (var j = 0; j < dataPDF.crono[i].Productos.length; j++) {
            for (var k = 0; k < dataPDF.crono[i].Productos[j].Actividades.length; k++) {
                for (var l = 0; l < dataPDF.crono[i].Productos[j].Actividades[k].Tareas.length; l++) {
                    
                    console.log(dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l]);

                    filCrono = [];

                    var c1 = {};
                    var c2 = {};
                    var c3 = {};
                    var c4 = {};
                    var c5 = {};
                    var c6 = {};
                    var c7 = {};
                    var c8 = {};
                    var c9 = {};
                    var c10 = {};
                    var c11 = {};

                    if (j == 0 && k == 0 && l == 0)
                    {
                        c1 = {
                            rowSpan: dataPDF.crono[i].rowsPan,
                            text: dataPDF.crono[i].ObjetivoEspecifico,
                            style: 'headerTables'
                        };
                    } else
                    {
                        c1 = {};
                    }

                    if (k == 0 && l == 0)
                    {
                        c2 = {
                            rowSpan: dataPDF.crono[i].Productos[j].rowSpan,
                            text: dataPDF.crono[i].Productos[j].Producto,
                            style: 'bodyTables'
                        };
                    } else
                    {
                        c2 = {};
                    }

                    if (l == 0)
                    {
                        c3 = {
                            rowSpan: dataPDF.crono[i].Productos[j].Actividades[k].rowSpan,
                            text: dataPDF.crono[i].Productos[j].Actividades[k].Actividades,
                            style: 'bodyTables'
                        };
                    } else {
                        c3 = {};
                    }

                    c4 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].Tarea,
                        style: 'bodyTables'
                    };

                    c5 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].Responsable,
                        style: 'bodyTables'
                    };

                    c6 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].strFechaIni1,
                        style: 'bodyTables'
                    };

                    c7 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].strFechaFin1,
                        style: 'bodyTables'
                    };

                    c8 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].strFechaIni2,
                        style: 'bodyTables'
                    };

                    c9 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].strFechaFin2,
                        style: 'bodyTables'
                    };

                    c10 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].strFechaIni3,
                        style: 'bodyTables'
                    };

                    c11 = {
                        text: dataPDF.crono[i].Productos[j].Actividades[k].Tareas[l].strFechaFin3,
                        style: 'bodyTables'
                    };

                    filCrono.push(c1);
                    filCrono.push(c2);
                    filCrono.push(c3);
                    filCrono.push(c4);
                    filCrono.push(c5);
                    filCrono.push(c6);
                    filCrono.push(c7);
                    filCrono.push(c8);
                    filCrono.push(c9);
                    filCrono.push(c10);
                    filCrono.push(c11);

                    tabCrono.push(filCrono);
                }
            }
        }
    }

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 3,
                body: tabCrono
            }
        }
    ];

    body.push(fila);



    //15 - MATRIZ DE SEGUIMIENTO
    fila = [
        {
            margin: [0, -10, 0, 0],
            pageBreak: 'before',
            text: '14. MATRIZ DE SEGUIMIENTO',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'landscape'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: 'Como resumen general del PIRC formulado y explicado en este documento, el cuadro que a continuación se presenta muestra de manera sistemática el ¿para qué?, el ¿por qué?, el ¿qué? Y el ¿cómo? se llevará a cabo las iniciativas acordadas con el colectivo, acompañado con sus respectivos indicadores.',
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    //Tab matriz seguim
    var tabSeg = [];
    var filSeg = [];

    //Resumen obj gral
    filSeg = [
        {
            colSpan: 5,
            text: 'TIPO DE COMPONENTE: OBJETIVO GENERAL',
            style: 'headerTables'
        }, {}, {}, {}, {}
    ];

    tabSeg.push(filSeg);

    filSeg = [
        {
            text: 'COMPONENTE',
            style: 'headerTables'
        },
        {
            text: 'INDICADOR',
            style: 'headerTables'
        },
        {
            text: 'META TOTAL',
            style: 'headerTables'
        },
        {
            text: 'TIPO DE FUENTE',
            style: 'headerTables'
        },
        {
            text: 'FUENTE',
            style: 'headerTables'
        }
    ];

    tabSeg.push(filSeg);

    filSeg = [
        {
            text: 'Contribuir a la reparación integral de los daños causados en el Sujeto Colectivo ' + dataPDF.nomSujeto + ', en el marco del conflicto armado.',
            style: 'bodyTables'
        },
        {
            text: 'Cumplimiento del Plan Integral de Reparación Colectiva (PIRC), del Sujeto Colectivo ' + dataPDF.nomSujeto,
            style: 'bodyTables'
        },
        {
            text: dataPDF.metaTotalPIRC,
            style: 'bodyTables'
        },
        {
            text: 'Documento Oficial',
            style: 'bodyTables'
        },
        {
            text: 'PIRC ' + dataPDF.nomSujeto,
            style: 'bodyTables'
        }
    ];

    tabSeg.push(filSeg);

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 2,
                body: tabSeg
            }
        }
    ];

    body.push(fila);


    //Resumen products
    tabSeg = [];
    filSeg = [
        {
            colSpan: 8,
            text: 'TIPO DE COMPONENTE: PRODUCTOS',
            style: 'headerTables'
        }, {}, {}, {}, {}, {}, {}, {}
    ];

    tabSeg.push(filSeg);

    filSeg = [
        {
            text: 'OBJETIVO ESPECÍFICO',
            style: 'headerTables'
        },
        {
            text: 'PRODUCTO',
            style: 'headerTables'
        },
        {
            text: 'INDICADOR',
            style: 'headerTables'
        },
        {
            text: 'UNIDAD DE MEDIDA',
            style: 'headerTables'
        },
        {
            text: 'META TOTAL',
            style: 'headerTables'
        },
        {
            text: 'TIPO DE FUENTE',
            style: 'headerTables'
        },
        {
            text: 'FUENTE',
            style: 'headerTables'
        },
        {
            text: 'SUPUESTOS',
            style: 'headerTables'
        }
    ];

    tabSeg.push(filSeg);

    for (var i = 0; i < dataPDF.resumen.length; i++)
    {
        for(var j = 0; j < dataPDF.resumen[i].Productos.length; j++)
        {
            filSeg = [];

            var c1 = {};
            var c2 = {};
            var c3 = {};
            var c4 = {};
            var c5 = {};
            var c6 = {};
            var c7 = {};
            var c8 = {};

            if (j == 0)
            {
                c1 = {
                    rowSpan: dataPDF.resumen[i].Productos.length,
                    text: dataPDF.resumen[i].ObjetivoEspecifico,
                    style: 'headerTables'
                };
            } else {
                c1 = {};
            }

            c2 = {
                text: dataPDF.resumen[i].Productos[j].Producto,
                style: 'bodyTables'
            };

            c3 = {
                text: dataPDF.resumen[i].Productos[j].Indicador,
                style: 'bodyTables'
            };

            c4 = {
                text: dataPDF.resumen[i].Productos[j].UnidadMedida,
                style: 'bodyTables'
            };

            c5 = {
                text: dataPDF.resumen[i].Productos[j].MetaTotal,
                style: 'bodyTables'
            };

            c6 = {
                text: dataPDF.resumen[i].Productos[j].TipoFuente,
                style: 'bodyTables'
            };

            c7 = {
                text: dataPDF.resumen[i].Productos[j].Fuente,
                style: 'bodyTables'
            };

            c8 = {
                text: dataPDF.resumen[i].Productos[j].Supuestos,
                style: 'bodyTables'
            };

            filSeg.push(c1);
            filSeg.push(c2);
            filSeg.push(c3);
            filSeg.push(c4);
            filSeg.push(c5);
            filSeg.push(c6);
            filSeg.push(c7);
            filSeg.push(c8);

            tabSeg.push(filSeg);
        }
    }

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 2,
                body: tabSeg
            }
        }
    ];

    body.push(fila);


    //Resumen Acts
    tabSeg = [];
    filSeg = [
        {
            colSpan: 9,
            text: 'TIPO DE COMPONENTE: ACTIVIDADES',
            style: 'headerTables'
        }, {}, {}, {}, {}, {}, {}, {}, {}
    ];

    tabSeg.push(filSeg);

    filSeg = [
        {
            text: 'OBJETIVO ESPECÍFICO',
            style: 'headerTables'
        },
        {
            text: 'PRODUCTO',
            style: 'headerTables'
        },
        {
            text: 'ACTIVIDAD',
            style: 'headerTables'
        },
        {
            text: 'INDICADOR',
            style: 'headerTables'
        },
        {
            text: 'UNIDAD DE MEDIDA',
            style: 'headerTables'
        },
        {
            text: 'META TOTAL',
            style: 'headerTables'
        },
        {
            text: 'TIPO DE FUENTE',
            style: 'headerTables'
        },
        {
            text: 'FUENTE',
            style: 'headerTables'
        },
        {
            text: 'SUPUESTOS',
            style: 'headerTables'
        }
    ];

    tabSeg.push(filSeg);

    for (var i = 0; i < dataPDF.resumen.length; i++) {
        for (var j = 0; j < dataPDF.resumen[i].Productos.length; j++) {
            for (var k = 0; k < dataPDF.resumen[i].Productos[j].Actividades.length; k++) {
                if(dataPDF.resumen[i].rowSpan == null)
                {
                    dataPDF.resumen[i].rowSpan = 0;
                }

                dataPDF.resumen[i].rowSpan++;
            }
        }
    }

    for (var i = 0; i < dataPDF.resumen.length; i++) {
        for (var j = 0; j < dataPDF.resumen[i].Productos.length; j++) {
            for (var k = 0; k < dataPDF.resumen[i].Productos[j].Actividades.length; k++) {
                filSeg = [];

                var c1 = {};
                var c2 = {};
                var c3 = {};
                var c4 = {};
                var c5 = {};
                var c6 = {};
                var c7 = {};
                var c8 = {};
                var c9 = {};

                if (j == 0 && k == 0) {
                    c1 = {
                        rowSpan: dataPDF.resumen[i].rowSpan,
                        text: dataPDF.resumen[i].ObjetivoEspecifico,
                        style: 'headerTables'
                    };
                } else {
                    c1 = {};
                }

                if (k == 0)
                {
                    c2 = {
                        rowSpan: dataPDF.resumen[i].Productos[j].Actividades.length,
                        text: dataPDF.resumen[i].Productos[j].Producto,
                        style: 'bodyTables'
                    };
                } else
                {
                    c2 = {};
                }                

                c3 = {
                    text: dataPDF.resumen[i].Productos[j].Actividades[k].Actividades,
                    style: 'bodyTables'
                };

                c4 = {
                    text: dataPDF.resumen[i].Productos[j].Actividades[k].Indicador,
                    style: 'bodyTables'
                };

                c5 = {
                    text: dataPDF.resumen[i].Productos[j].Actividades[k].Medido,
                    style: 'bodyTables'
                };

                c6 = {
                    text: '',
                    style: 'bodyTables'
                };

                c7 = {
                    text: dataPDF.resumen[i].Productos[j].Actividades[k].TipoFuente,
                    style: 'bodyTables'
                };

                c8 = {
                    text: dataPDF.resumen[i].Productos[j].Actividades[k].Fuente,
                    style: 'bodyTables'
                };

                c9 = {
                    text: dataPDF.resumen[i].Productos[j].Actividades[k].Supuestos,
                    style: 'bodyTables'
                };

                filSeg.push(c1);
                filSeg.push(c2);
                filSeg.push(c3);
                filSeg.push(c4);
                filSeg.push(c5);
                filSeg.push(c6);
                filSeg.push(c7);
                filSeg.push(c8);
                filSeg.push(c9);

                tabSeg.push(filSeg);
            }
        }
    }

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                headerRows: 2,
                body: tabSeg
            }
        }
    ];

    body.push(fila);


    //16 - RESPONSABLES
    fila = [
        {
            margin: [0, 0, 0, 0],
            pageBreak: 'before',
            text: '15. RESPONSABLES',
            style: 'headerTOCItem',
            tocItem: true,
            tocStyle: 'headerTOCItem2',
            tocMargin: [0, 10, 0, 0],
            pageOrientation: 'portrait'
        }
    ];

    body.push(fila);

    fila = [
        {
            margin: [0, 10, 0, 0],
            text: 'El presente PIRC es producto del trabajo conjunto realizado entre el Sujeto de Reparación Colectiva ' + dataPDF.nomSujeto + ' y la Unidad para las Víctimas. A continuación, se mencionan las personas que participaron en su formulación desde la entidad:',
            style: 'textPIRC1'
        }
    ];

    body.push(fila);

    //Tabla responsables

    var tabResp = [];
    var filResp = [];

    filResp = [
        {
            text: 'Profesional Reparación Colectiva',
            style: 'headerTables'
        },
        {
            text: dataPDF.datosPDF[0].PROF_PIRC_RC,
            style: 'bodyTables'
        },
        {
            text: 'Profesional Psicosocial',
            style: 'headerTables'
        },
        {
            text: dataPDF.datosPDF[0].PROF_PIRC_PSICO,
            style: 'bodyTables'
        }
    ];

    tabResp.push(filResp);

    filResp = [
        {
            colSpan: 4,
            text: 'Profesionales que avalaron productos correspondientes a las medidas',
            style: 'headerTables'
        },{},{},{}
    ];

    tabResp.push(filResp);

    filResp = [
        {
            text: 'Satisfacción',
            style: 'headerTables'
        },
        {
            colSpan: 3,
            text: dataPDF.datosPDF[0].PROF_PIRC_SATISF,
            style: 'bodyTables'
        },{},{}
    ];

    tabResp.push(filResp);

    filResp = [
        {
            text: 'Rehabilitación',
            style: 'headerTables'
        },
        {
            colSpan: 3,
            text: dataPDF.datosPDF[0].PROF_PIRC_REHAB,
            style: 'bodyTables'
        },{},{}
    ];

    tabResp.push(filResp);

    filResp = [
        {
            text: 'Garantías de no repetición',
            style: 'headerTables'
        },
        {
            colSpan: 3,
            text: dataPDF.datosPDF[0].PROF_PIRC_GARAN,
            style: 'bodyTables'
        },{},{}
    ];

    tabResp.push(filResp);

    filResp = [
        {
            text: 'Restitución',
            style: 'headerTables'
        },
        {
            colSpan: 3,
            text: dataPDF.datosPDF[0].PROF_PIRC_RESTIT,
            style: 'bodyTables'
        },{},{}
    ];

    tabResp.push(filResp);

    fila = [
        {
            margin: [0, 10, 0, 0],
            table: {
                body: tabResp
            },
            alignment: 'center'
        }
    ];

    body.push(fila);

    return body;
}

var paintTree = async function (dataAP, dataCD, nomSujeto)
{
    var $ = go.GraphObject.make;  // for conciseness in defining templates in this function

    myDiagram =
      $(go.Diagram, "myDiagrarmArbolProb",  // must be the ID or reference to div
        { initialContentAlignment: go.Spot.Center });

    // define all of the gradient brushes
    var graygrad = $(go.Brush, "Linear", { 0: "#F5F5F5", 1: "#F1F1F1" });
    var bluegrad = $(go.Brush, "Linear", { 0: "#CDDAF0", 1: "#91ADDD" });
    var yellowgrad = $(go.Brush, "Linear", { 0: "#FEC901", 1: "#FEA200" });
    var lavgrad = $(go.Brush, "Linear", { 0: "#EF9EFA", 1: "#A570AD" });
    var greengrad = $(go.Brush, "Linear", { 0: "#00FF00", 1: "#7CFC00" });

    var body = [];
    var fila = [];
    var filaData = [];

    var treeModel = [];
    var treeNode = {};

    treeNode = { name: "Persistencia de daños Colectivos en el Sujeto Colectivo " + nomSujeto + " ocasionados en el marco del conflicto armado.", key: "Root", color: greengrad, nodeWidth: 650 };

    treeModel.push(treeNode);

    //Efectos directos e indirectos
    for (var i = 0; i < dataAP.length; i++)
    {
        var ED = dataAP[i];

        treeNode = { name: ED.EfectoDirecto, key: "ED" + (ED.IdEfectoDirecto.toString()), parent: "Root", dir: "top", color: bluegrad, nodeWidth: 200 };
        treeModel.push(treeNode);

        for(var j = 0; j < ED.FfectosIndirectos.length; j++)
        {
            var EID = ED.FfectosIndirectos[j];

            treeNode = { name: EID.EfectoIndirecto, key: "EI" + (EID.IdEfectoIndirecto.toString()), parent: "ED" + (ED.IdEfectoDirecto.toString()), color: graygrad, nodeWidth: 100 };

            treeModel.push(treeNode);
        }
    }

    //Categorias de daño, causas directas, subcategorias de daño, causas indirectas
    for (var i = 0; i < dataCD.length; i++)
    {
        var CD = dataCD[i];

        treeNode = { name: CD.CategoriaDano, key: "CD" + (CD.IdCategoriaDano.toString()), parent: "Root", dir: "bottom", color: bluegrad, nodeWidth: 200 };
        treeModel.push(treeNode);

        treeNode = { name: CD.CausaDirecta, key: "Cu" + (CD.IdCausaDirecta.toString()) + "D" + (CD.IdCategoriaDano.toString()), parent: "CD" + (CD.IdCategoriaDano.toString()), dir: "bottom", color: yellowgrad, nodeWidth: 200 };
        treeModel.push(treeNode);

        //Subcd
        for(var j = 0; j < CD.LstSCD.length; j++)
        {
            var SCD = CD.LstSCD[j];            
            
            treeNode = { name: SCD.SubcategoriaDano, parent: "Cu" + (CD.IdCausaDirecta.toString()) + "D" + (CD.IdCategoriaDano.toString()), key: "SCD" + (SCD.IdSubcategoriaDano.toString()) + "Cu" + (CD.IdCausaDirecta.toString()) + "D" + (CD.IdCategoriaDano.toString()), color: lavgrad, nodeWidth: 150 };
            treeModel.push(treeNode);

            //causas indirec
            for(var k = 0; k < SCD.CausasIndirectas.length; k++)
            {
                var CuID = SCD.CausasIndirectas[k];

                treeNode = { name: CuID.CausaIndirecta, parent: "SCD" + (SCD.IdSubcategoriaDano.toString()) + "Cu" + (CD.IdCausaDirecta.toString()) + "D" + (CD.IdCategoriaDano.toString()), key: "CuI" + (CuID.IdCausaIndirecta.toString()) + "SCD" + (SCD.IdSubcategoriaDano.toString()) + "Cu" + (CD.IdCausaDirecta.toString()) + "D" + (CD.IdCategoriaDano.toString()), color: graygrad, nodeWidth: 100 };
                treeModel.push(treeNode);
            }            
        }
    }
    
    // define the Node template for non-terminal nodes
    myDiagram.nodeTemplate =
      $(go.Node, "Auto",
        { isShadowed: false },
        // define the node's outer shape
        $(go.Shape, "RoundedRectangle",
          { fill: graygrad, stroke: "#D8D8D8" },
          new go.Binding("fill", "color")),
        // define the node's text
        $(go.TextBlock,
          { margin: 5, font: "9px Arial", width: 50 },
          //new go.Binding("text", "key"),
		  new go.Binding("text", "name"),
		  new go.Binding("width", "nodeWidth"))
      );

    // define the Link template
    myDiagram.linkTemplate =
      $(go.Link,  // the whole link panel
        { selectable: false },
        $(go.Shape));  // the link shape

    // create the model for the double tree
    myDiagram.model = new go.TreeModel(treeModel);
    //myDiagram.model = new go.TreeModel([
    //    // these node data are indented but not nested according to the depth in the tree
    //    { name: "Persistencia de daños Colectivos en el Sujeto Colectivo COMUNIDAD AFRO DE BOJAYA ocasionados en el marco del conflicto armado.", key: "Root", color: greengrad, nodeWidth: 650 },

    //      { name: "Perdida de la autonomía del colectivo", key: "ED1", parent: "Root", dir: "top", color: bluegrad, nodeWidth: 200 },

	//		{ name: "Aislamiento del colectivo", key: "EI11", parent: "ED1", color: graygrad, nodeWidth: 100 },
    //        { name: "Baja participación de los integrantes del colectivo en las actividades", key: "EI21", parent: "ED1", color: graygrad, nodeWidth: 100 },

	//	  { name: "Resctricciones para el ejercicio del debate alrededor de los derechos humanos en la sociedad", key: "ED2", parent: "Root", dir: "top", color: bluegrad, nodeWidth: 200 },

	//		{ name: "Daño/Transformación de la estructura del colectivo", key: "EI12", parent: "ED2", color: graygrad, nodeWidth: 100 },
	//		{ name: "Deforestación y contaminación de sitios sagrados", key: "EI22", parent: "ED2", color: graygrad, nodeWidth: 100 },

	//	  { name: "Bajas posibilidades para la democratización de la sociedad", key: "ED3", parent: "Root", dir: "top", color: bluegrad, nodeWidth: 200 },

	//		{ name: "Aislamiento del colectivo", parent: "ED3", key: "EI13", color: graygrad, nodeWidth: 100 },
	//		{ name: "Baja participación de los integrantes del colectivo en las actividades", parent: "ED3", color: graygrad, key: "EI23", nodeWidth: 100 },
	//		{ name: "Bajas posibilidades para la democratización de la sociedad", parent: "ED3", color: graygrad, key: "EI33", nodeWidth: 100 },
	//		{ name: "Daño/Transformación de la estructura del colectivo", parent: "ED3", color: graygrad, key: "EI43", nodeWidth: 100 },
	//		{ name: "Deforestación y contaminación de sitios sagrados", parent: "ED3", color: graygrad, key: "EI53", nodeWidth: 100 },

    //      { name: "Daño al proyecto colectivo", key: "CD1", parent: "Root", dir: "bottom", color: bluegrad, nodeWidth: 200 },
	//		{ name: "Debilitamiento del proyecto colectivo de la comunidad o pueblo étnico", key: "Cu1D1", parent: "CD1", dir: "bottom", color: yellowgrad, nodeWidth: 200 },
	//			{ name: "Desestructuración del plan de vida o Plan de etnodesarrollo o Plan del largo y buen camino", parent: "Cu1D1", key: "SCD1Cu1D1", color: lavgrad, nodeWidth: 150 },
	//				{ name: "Pérdida del plan de vida o Plan de etnodesarrollo o Plan del largo y buen camino debido a los impactos del conflicto", parent: "SCD1Cu1D1", key: "CuI1SCD1Cu1D1", color: graygrad, nodeWidth: 100 },
	//				{ name: "Debilitamiento del plan de vida o Plan de etnodesarrollo o Plan del largo y buen camino debido a los impactos del conflicto", parent: "SCD1Cu1D1", key: "CuI2SCD1Cu1D1", color: graygrad, nodeWidth: 100 },

	//	  { name: "Daño al autorreconocimiento y reconocimiento por terceros", key: "CD2", parent: "Root", dir: "bottom", color: bluegrad, nodeWidth: 200 },
	//		{ name: "Pérdida de las formas de autorreconocimiento y reconocimiento del colectivo, de acuerdo con los usos y costumbres del colectivo", key: "Cu1D2", parent: "CD2", dir: "bottom", color: yellowgrad, nodeWidth: 200 },

	//			{ name: "Pérdida de identidad y sentido de pertenencia", parent: "Cu1D2", key: "SCD1Cu1D2", color: lavgrad, nodeWidth: 150 },
	//				{ name: "Pérdida/debilitamiento de la identidad colectiva y el sentido de pertenencia del sujeto colectivo", parent: "SCD1Cu1D2", key: "CuI1SCD1Cu1D2", color: graygrad, nodeWidth: 100 },
	//				{ name: "Pérdida/debilitamiento de la confianza al interior del colectivo", parent: "SCD1Cu1D2", key: "CuI2SCD1Cu1D2", color: graygrad, nodeWidth: 100 },

	//			{ name: "Estigmatización a las comunidades y autoridades étnico territoriales", parent: "Cu1D2", key: "SCD2Cu1D2", color: lavgrad, nodeWidth: 150 },
	//				{ name: "Estigmatización a las comunidades y autoridades étnico territoriales", parent: "SCD2Cu1D2", key: "CuI1SCD2Cu1D2", color: graygrad, nodeWidth: 100 },

	//			{ name: "Prevalencia de esquemas de discriminación racial y exclusión del entorno hacia el sujeto colectivo", parent: "Cu1D2", key: "SCD3Cu1D2", color: lavgrad, nodeWidth: 150 },
	//				{ name: "Prevalencia de esquemas de discriminación racial y exclusión del entorno hacia el sujeto colectivo", parent: "SCD3Cu1D2", key: "CuI1SCD3Cu1D2", color: graygrad, nodeWidth: 100 }
    //]);

    doubleTreeLayout(myDiagram);

    //document.getElementById("myDiagramDivImg").appendChild(
	//myDiagram.makeImage({
	//    scale: 1
    //}));

    var div = myDiagram.div;
    div.style.width = '100%';

    myDiagram.requestUpdate();

    var imgBase64 = myDiagram.makeImageData({
        scale: 1,
        maxSize: new go.Size(Infinity, NaN)
    });

    //console.log("img orig");
    //console.log(imgBase64);

    //var newImgBase64 = "";

    //var img = new Image;

    ////img.onload = function () {
    ////    var newDataUri = imageToDataUri(this, 900, 460);

    ////    newImgBase64 = newDataUri;
    ////};

    //img.src = imgBase64;

    //var newDataUri = imageToDataUri(img, 900, 460);

    //newImgBase64 = newDataUri;

    //newImgBase64 = await resizedataURL(imgBase64,900,400);
    
    fila = [
        {
            image: imgBase64,
            alignment: 'center',
            width: 900,
            border: [false, false, false, false]
        }
    ];

    //fila.push(filaData);

    body.push(fila);

    return body;
}


var paintTree2 = async function (dataAF, dataOB, nomSujeto)
{
    var $ = go.GraphObject.make;  // for conciseness in defining templates in this function

    myDiagram =
      $(go.Diagram, "myDiagrarmArbolObjet",  // must be the ID or reference to div
        { initialContentAlignment: go.Spot.Center });

    // define all of the gradient brushes
    var graygrad = $(go.Brush, "Linear", { 0: "#F5F5F5", 1: "#F1F1F1" });
    var bluegrad = $(go.Brush, "Linear", { 0: "#CDDAF0", 1: "#91ADDD" });
    var yellowgrad = $(go.Brush, "Linear", { 0: "#FEC901", 1: "#FEA200" });
    var lavgrad = $(go.Brush, "Linear", { 0: "#EF9EFA", 1: "#A570AD" });
    var greengrad = $(go.Brush, "Linear", { 0: "#00FF00", 1: "#7CFC00" });

    var body = [];
    var fila = [];
    var filaData = [];

    var treeModel = [];
    var treeNode = {};

    treeNode = { name: "Contribuir a la reparación integral de los daños causados en el Sujeto Colectivo " + nomSujeto + " en el marco del conflicto armado.", key: "Root", color: greengrad, nodeWidth: 650 };

    treeModel.push(treeNode);

    //Fines directos e indirectos
    for (var i = 0; i < dataAF.length; i++)
    {
        var ED = dataAF[i];

        treeNode = { name: ED.FinDirecto, key: "FD" + (ED.IdFinDirecto.toString()), parent: "Root", dir: "top", color: bluegrad, nodeWidth: 200 };
        treeModel.push(treeNode);

        for(var j = 0; j < ED.FinesIndirectos.length; j++)
        {
            var EID = ED.FinesIndirectos[j];

            treeNode = { name: EID.FinIndirecto, key: "FI" + (EID.IdFinIndirecto.toString()), parent: "FD" + (ED.IdFinDirecto.toString()), color: graygrad, nodeWidth: 100 };

            treeModel.push(treeNode);
        }
    }

    //Objetivos Directos e indirectos
    for (var i = 0; i < dataOB.length; i++)
    {
        var CD = dataOB[i];

        treeNode = { name: CD.ObjetivoDirecto, key: "OED" + (CD.IdObjetivoDirecto.toString()), parent: "Root", dir: "bottom", color: bluegrad, nodeWidth: 200 };
        treeModel.push(treeNode);
        
        //Subcd
        for(var j = 0; j < CD.ObjetivosIndirectos.length; j++)
        {
            var SCD = CD.ObjetivosIndirectos[j];

            treeNode = { name: SCD.ObjetivoIndirecto, key: "OEI" + (SCD.IdObjetivoIndirecto.toString()), parent: "OED" + (CD.IdObjetivoDirecto.toString()), dir: "bottom", color: graygrad, nodeWidth: 100 };
            treeModel.push(treeNode);
        }
    }
    
    // define the Node template for non-terminal nodes
    myDiagram.nodeTemplate =
      $(go.Node, "Auto",
        { isShadowed: false },
        // define the node's outer shape
        $(go.Shape, "RoundedRectangle",
          { fill: graygrad, stroke: "#D8D8D8" },
          new go.Binding("fill", "color")),
        // define the node's text
        $(go.TextBlock,
          { margin: 5, font: "9px Arial", width: 50 },
          //new go.Binding("text", "key"),
		  new go.Binding("text", "name"),
		  new go.Binding("width", "nodeWidth"))
      );

    // define the Link template
    myDiagram.linkTemplate =
      $(go.Link,  // the whole link panel
        { selectable: false },
        $(go.Shape));  // the link shape

    // create the model for the double tree
    myDiagram.model = new go.TreeModel(treeModel);

    doubleTreeLayout(myDiagram);

    var div = myDiagram.div;
    div.style.width = '100%';

    myDiagram.requestUpdate();

    var imgBase64 = myDiagram.makeImageData({
        scale: 1,
        maxSize: new go.Size(Infinity, NaN)
    });

    //console.log("img orig");
    //console.log(imgBase64);

    fila = [
        {
            image: imgBase64,
            alignment: 'center',
            width: 900,
            border: [false, false, false, false]
        }
    ];

    body.push(fila);

    return body;
}

// Takes a data URI and returns the Data URI corresponding to the resized image at the wanted size.
function resizedataURL(datas, wantedWidth, wantedHeight){
    return new Promise(async function(resolve,reject){

        // We create an image to receive the Data URI
        var img = document.createElement('img');

        // When the event "onload" is triggered we can resize the image.
        img.onload = function()
        {        
            // We create a canvas and get its context.
            var canvas = document.createElement('canvas');
            var ctx = canvas.getContext('2d');

            // We set the dimensions at the wanted size.
            canvas.width = wantedWidth;
            canvas.height = wantedHeight;

            // We resize the image with the canvas method drawImage();
            ctx.drawImage(this, 0, 0, wantedWidth, wantedHeight);

            var dataURI = canvas.toDataURL();

            // This is the return of the Promise
            resolve(dataURI);
        };

        // We put the Data URI in the image's src attribute
        img.src = datas;

    });
}// Use it like : var newDataURI = await resizedataURL('yourDataURIHere', 50, 50);

function imageToDataUri(img, width, height) {

    // create an off-screen canvas
    var canvas = document.createElement('canvas'),
        ctx = canvas.getContext('2d');

    // set its dimension to target size
    canvas.width = width;
    canvas.height = height;

    // draw source image into the off-screen canvas:
    ctx.drawImage(img, 0, 0, width, height);

    // encode image to data-uri with base64 version of compressed image
    return canvas.toDataURL();
}

function doubleTreeLayout(diagram) {
    // Within this function override the definition of '$' from jQuery:
    var $ = go.GraphObject.make;  // for conciseness in defining templates
    diagram.startTransaction("Double Tree Layout");

    // split the nodes and links into two Sets, depending on direction
    var leftParts = new go.Set(go.Part);
    var rightParts = new go.Set(go.Part);
    separatePartsByLayout(diagram, leftParts, rightParts);
    // but the ROOT node will be in both collections

    // create and perform two TreeLayouts, one in each direction,
    // without moving the ROOT node, on the different subsets of nodes and links
    var layout1 =
      $(go.TreeLayout,
        {
            angle: 270,
            arrangement: go.TreeLayout.ArrangementVertical,
            setsPortSpot: false,
            layerSpacing: 15,
            nodeSpacing: 5
        });

    var layout2 =
      $(go.TreeLayout,
        {
            angle: 90,
            arrangement: go.TreeLayout.ArrangementFixedRoots,
            setsPortSpot: false,
            layerSpacing: 15,
            nodeSpacing: 5
        });

    layout1.doLayout(leftParts);
    layout2.doLayout(rightParts);

    diagram.commitTransaction("Double Tree Layout");
}

function separatePartsByLayout(diagram, leftParts, rightParts) {
    var root = diagram.findNodeForKey("Root");
    if (root === null) return;
    // the ROOT node is shared by both subtrees!
    leftParts.add(root);
    rightParts.add(root);
    // look at all of the immediate children of the ROOT node
    root.findTreeChildrenNodes().each(function (child) {
        // in what direction is this child growing?
        var dir = child.data.dir;
        var coll = (dir === "top") ? leftParts : rightParts;
        // add the whole subtree starting with this child node
        coll.addAll(child.findTreeParts());
        // and also add the link from the ROOT node to this child node
        coll.add(child.findTreeParentLink());
    });
}

function doPDFPIRC(idSujeto)
{
    $.ajax({
        type: "GET",
        url: "/modulos/Colectiva/Planes_RC_Integrado.aspx/ObtenerDatosPDF?idSujeto=" + idSujeto,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            generatePDFPIRC(response.d);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}

async function generatePDFPIRC(dat)
{
    //console.log("return from codeb");
    //console.log(dat)

    try
    {
        
        var data = await getDatosFormateados(dat);

        //console.log("data ready");
        //console.log(data);

        var docDefinition = {
            pageSize: 'LEGAL',
            pageOrientation: 'portrait',
            pageMargins: [30, 120, 30, 50],
            header: function (currentPage, pageCount) {
                return {
                    stack: [
                        {
                            margin: [30, 40, 40, 0],
                            columns: [
                                {
                                    table: {
                                        widths: ['auto', '*', '*', '*', '*'],
                                        body: [
                                            [
                                                {
                                                    image: 'logoUnidadGob',
                                                    width: 200,
                                                    alignment: 'center',
                                                    rowSpan: 4,
                                                    margin: [0, 15, 0, 0]
                                                },
                                                {
                                                    text: 'PLAN INTEGRAL DE REPARACIÓN COLECTIVA - DOCUMENTO TÉCNICO',
                                                    colSpan: 4,
                                                    style: 'headerPIRC1'
                                                }, {}, {}, {}
                                            ],
                                            [
                                                {},
                                                {
                                                    text: 'PROCEDIMIENTO: DISEÑO, FORMULACIÓN Y APROBACIÓN DEL PLAN INTEGRAL DE REPARACIÓN COLECTIVA PARA SUJETOS NO ÉTNICOS',
                                                    colSpan: 4,
                                                    style: 'headerPIRC2'
                                                }, {}, {}, {}
                                            ],
                                            [
                                                {},
                                                {
                                                    text: 'PROCESO: REPARACIÓN INTEGRAL',
                                                    colSpan: 4,
                                                    style: 'headerPIRC2'
                                                }, {}, {}, {}
                                            ],
                                            [
                                                {},
                                                {
                                                    text: 'Código: 430.08.15-22',
                                                    style: 'headerPIRC3'
                                                },
                                                {
                                                    text: 'Versión: 02',
                                                    style: 'headerPIRC3'
                                                },
                                                {
                                                    text: 'Fecha: 09/10/2018',
                                                    style: 'headerPIRC3'
                                                },
                                                {
                                                    text: 'Página: ' + currentPage.toString() + ' de ' + pageCount.toString(),
                                                    style: 'headerPIRC3'
                                                }
                                            ]
                                        ]
                                    }
                                }
                            ]
                        }
                    ]
                };
            },
            footer: function (currentPage, pageCount) {
                return {
                    stack: [
                        {
                            fontSize: 7,
                            columns: [
                                { text: "710.14.15-21    V1", alignment: 'right', margin: [0, 0, 30, 0], bold: true }
                            ]
                        }]

                };
            },
            //content: [
            //    {
            //        table: {
            //            widths: ['auto'],
            //            body: data
            //        },
            //        layout: getLayout()
            //    }
            //],
            watermark: {text: 'BORRADOR   ', color: '#A50021', opacity: 0.2, bold: true, italics: false},
            content: data,
            styles: {
                header: {
                    bold: true,
                    fontSize: 15
                },
                headerTOC: {
                    bold: true,
                    fontSize: 10,
                    alignment: 'center'
                },
                headerTOCItem: {
                    bold: true,
                    fontSize: 10,
                    alignment: 'left'
                },
                headerTOCItem2: {
                    bold: true,
                    fontSize: 10,
                    alignment: 'left'
                },
                'titlePIRC0': {
                    bold: true,
                    fontSize: 14,
                    alignment: 'center',
                    margin: [0, 220, 0, 0]
                },
                'titlePIRC1': {
                    bold: true,
                    fontSize: 14,
                    alignment: 'center',
                    margin: [0, 5, 0, 5]
                },
                'titlePIRC2': {
                    bold: true,
                    fontSize: 10,
                    alignment: 'center',
                    margin: [0, 10, 0, 0]
                },
                'titlePIRC3': {
                    fontSize: 10,
                    alignment: 'center',
                    margin: [0, 20, 0, 0]
                },
                'subtitlePIRC0': {
                    fontSize: 10,
                    alignment: 'left',
                    fillColor: '#BFBFBF',
                    color: 'black'
                },
                'subtitlePIRC1': {
                    fontSize: 10,
                    alignment: 'center'
                },
                'tableHeader4': {
                    bold: true,
                    fontSize: 10,
                    color: '#63002D',
                    alignment: 'center',
                    margin: [50, 0, 50, 0]
                },
                'headerPIRC1': {
                    bold: true,
                    fontSize: 9,
                    color: 'white',
                    alignment: 'center',
                    fillColor: '#A50021'
                },
                'headerPIRC2': {
                    fontSize: 9,
                    color: 'black'
                },
                'headerPIRC3': {
                    bold: true,
                    fontSize: 7,
                    color: 'black',
                    alignment: 'center',
                },
                'textPIRC1': {
                    fontSize: 9,
                    color: 'black',
                    alignment: 'justify'
                },
                'headerTables': {
                    bold: true,
                    fontSize: 9,
                    color: 'white',
                    alignment: 'center',
                    fillColor: '#A50021'
                },
                'bodyTables': {
                    bold: false,
                    fontSize: 9,
                    color: 'black',
                    alignment: 'justify'
                }
            },
            images: {
                logoUnidadGob: 'data:image/jpeg;base64,/9j/4QlQaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzE0MCA3OS4xNjA0NTEsIDIwMTcvMDUvMDYtMDE6MDg6MjEgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiLz4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA8P3hwYWNrZXQgZW5kPSJ3Ij8+/+0ALFBob3Rvc2hvcCAzLjAAOEJJTQQlAAAAAAAQ1B2M2Y8AsgTpgAmY7PhCfv/bAIQAAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQICAgICAgICAgICAwMDAwMDAwMDAwEBAQEBAQECAQECAgIBAgIDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMD/90ABAA//+4ADkFkb2JlAGTAAAAAAf/AABEIAEsB9AMAEQABEQECEQH/xAC4AAEAAgMBAQEBAQAAAAAAAAAABwgGCQoFBAMCCwEBAAICAwEBAAAAAAAAAAAAAAUGBAcDCAkCARAAAAcAAgICAQIFAgUDBQEAAQIDBAUGBwAIERIJExQV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'
            }
        }

        pdfMake.createPdf(docDefinition).download('docPIRC.pdf');
    } catch(err)
    {
        alert("Ocurrió un error generando el PDF del PIRC, por favor intente nuevamente.")
        console.log(err);
        console.log(err.message);
    }

}

//,
//{
//text: '\n\nUnordered list with longer lines',
//    style: 'header',
//pageBreak: 'before',
//pageOrientation: 'landscape'
//},
//{
//    ol: [
//        'item 1',
//        'Lorem ipsum dolor sit amet, consectetur ..',
//        'item 3',
//    ]
//},
//{
//text: '\n\nNested lists',
//    style: 'header',
//pageBreak: 'before',
//pageOrientation: 'portrait'
//},
//{
//    ol: [
//        'item 1',
//        'Lorem ipsum dolor sit amet, consectetur ..',
//        {
//            ol: [
//                'subitem 1',
//                'subitem 2',
//                'subitem 3 - Lorem ipsum dolor sit ame...',
//                'subitem 4',
//                'subitem 5',
//            ]
//        },
//        'item 3\nsecond line of item3',
//    ]
//},