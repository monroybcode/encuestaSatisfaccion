
var RVisiblesI = 0, RVIsiblesF = 0, RowsCensoP = [];
function RecArr() {
    $("#DivLoader").show();
    $("#ContenedorRC").empty();

    //$("#ContPag").empty()
    $("#NombreResp").text($("#ResponsableID").find("option:selected").text())

    if (data.length > 0) {
        var HTMLRow = "";
        for (i = Des; i <= Hast; i++) {
            try {
                if (i < data.length) {

                } else {
                    break;
                }
                //BuscarRespon(epi)
            } catch (err) {
                $("#ContenedorRC").append(HTMLRow)
            }
        }
    }


}

function RecSolic(RVisiblesI, RVIsiblesF, clickClass) {
    $("#ContenedorRC").empty()
    for (x = RVisiblesI; x <= RVIsiblesF; x++) {
        try {
            if (x < ArrSolic.length) {
                GHTMLTI(ArrSolic[x]["Id_Solicitud"], ArrSolic[x]["Episodio"], ArrSolic[x]["Id_SolEst"], ArrSolic[x]["Nombre"], ArrSolic[x]["NombrePac"], ArrSolic[x]["Hospital"], ArrSolic[x]["Numero_Medico"], ArrSolic[x]["NomMed"], ArrSolic[x]["Importe"], ArrSolic[x]["FechaSolicitud"], ArrSolic[x]["Porcentaje"], ArrSolic[x]["Color"], clickClass);
            } else {
                break;
            }
        } catch (e) {
            console.log(e);
        }
    }
}

function GHTMLTI(SolicId, epi, est, nomest, pac, hos, nomed, med, monc, fi, Porcen, col, clickClass) {

    var HTMLRow = "";
    HTMLRow += '<div id="Row' + SolicId + '" CE="' + SolicId + '" tabindex="-1" style="cursor:pointer;border-top:1px solid grey;border-bottom:1px solid grey;width:100%;padding-top:5px;" class="' + clickClass + '">' +
        '<div class="row">' +
        '<div class="col-2 LabelBlack" style="padding-left:0px">' + epi + '</div>' +
        '<div class="col-9 offset-1"><div class="Labelcabecero PreventBW LabelBlack">PACIENTE: ' + pac + '</div></div>' +

        '</div>' +
        '<div class="row">' +
        '<div class="col-3 LabelStatusRow' + SolicId + '" style="padding-left:0px"><div style="background-color:#' + col + ';width: 100%; color: #FFF; letter-spacing: 2px;" class="LabelStatus PreventBW" title="' + nomest.toUpperCase() + '">' + nomest.toUpperCase() + '</div></div>' +
        '<div class="col-5"><div class="Labelcabecero PreventBW" title="' + hos + '">' + hos + '</div></div>' +
        '<div class="col-2" style="text-align:right">Saldo</div>' +
        '<div class="col-2" style="text-align:right" id="Monto' + SolicId + '">$ ' + MoneyFor(monc) + '</div>' +
        '</div>' +
        '<div class="row DivSec">' +
        '<div class="col-2 Labelcabecero" style="padding-left:0px"><span class="class="Labelcabecero">No. médico</span><br /></div>' +
        '<div class="col-5 offset-1 Labelcabecero"><span class="class="Labelcabecero">Médico</span></div>' +
        '<div class="col-3 Labelcabecero"><span class="class="Labelcabecero">Fecha solicitud</span><br /></div>' +
        '<div class="col-2" style="padding-left:0px"><div class="class="PreventBW Labelcabecero">' + nomed + '</div></div>' +
        '<div class="col-5 offset-1"><div class="class="PreventBW Labelcabecero">' + med + '</div></div>' +
        '<div class="col-3 LabelBlack"><label class="class=" Labelcabecero">' + ConvEFDate(fi, "dd/MM/yyyy") + '</label></div>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '<div class="Separador" style="margin-bottom:8px;"></div>'


    $("#ContenedorRC").append(HTMLRow)
}



function RevisarM(Am) {
    Am = Am + "";
    var pc = Am.charAt(0);
    if (pc == ",") {
        Am = pc.substring(1, substring.length)
    }
    return Am;
}





var Pag = 0;
var TC = 0;
var PaAc = 0;
function GPag(TRow) {
    try {
        var RVisiblesI2 = RVisiblesI - 1;
        var RVIsiblesF2 = RVIsiblesF - 1;
        
        if (TRow > 0) {
            //var Ccount = JSON.parse(CC);
            $("#NExpMo").text(TRow);
            Pag = TRow / $("#ResPag").val();
            
            if (Pag % 1 === 0) {
                Pag = parseInt(Pag);
            } else {
                Pag = parseInt(Pag) + 1;
            }
            console.log(Pag)
            TC = TRow;
            var HTMLPag = "";
            for (i = 0; i < Pag; i++) {
                var ActN = "";
                if (i == 0) {
                    ActN = "active";
                }
                var PagVisible = "";

                if (i >= RVisiblesI2 && i <= RVIsiblesF2)
                    PagVisible = "style='display:block'"
                else
                    PagVisible = "style='display:none'"

                HTMLPag += '<li class="PNumber page-item ' + ActN + '" NPag="' + (i + 1) + '" id="LId' + i + 1 + '" ' + PagVisible + '><a class="page-link">' + (i + 1) + '<span class="sr-only">(current)</span></a></li>'
            }
            var SigOc = ""
            if (Pag < 10) {
                SigOc = 'style="display:none"'
            }
            var PAVis = "";
            if (RVisiblesI > 1) {
                PAVis = "block"
            } else {
                PAVis = "none"
            }
            $("#ContPag").append('<nav id="PagCen">' +
                '<ul class="pagination justify-content-end">' +
                '<li class="page-item PagAnt" style="display:' + PAVis + '">' +
                '<a class="page-link" tabindex="-1">' +
                '<span aria-hidden="true">...</span>' +
                '<span class="sr-only">Previous</span>' +
                '</a>' +
                '</li>' + HTMLPag +
                '<li class="page-item PagSig" ' + SigOc + '>' +
                '<a class="page-link">' +
                '<span aria-hidden="true">...</span>' +
                '<span class="sr-only">Next</span>' +
                '</a>' +
                '</li>' +
                '</ul>' +
                '</nav>')
        }


    } catch (err) {
        MNotif("Ocurrió un error al generar el paginado", "error")
    }

    $(document).on("click", ".PNumber", function () {
        var LiAc = $("nav#PagCen li.Active");
        var NPLA = LiAc.attr("NPag");
        if (LiAc.attr("NPag") != $(this).attr("NPag")) {
            $("nav#PagCen li").removeClass("active");
            $(this).addClass("active");
            var Desde = (($(this).attr("NPag") - 1) * $("#ResPag").val())
            var Hasta = ($(this).attr("NPag") * $("#ResPag").val())
            PaAc = $(this).attr("NPag") - 1;

            GHTMLTI(RowsCensoP, Desde, Hasta)
        }
    });
}



function fillTabl(data) {
    if (data) {
        var doc = JSON.parse(data);
        var rows = [];

        for (x = 0; x < doc.length; x++) {
            var inf = doc[x];
            if (x == 0) {
                var table = '<table id="TblGen" class="table table-striped2 dataTables_scrollHeadInner2"><thead class="LTT12B"><tr>';
                var headers = '<th style="display:none;">0</th>'
                $.each(inf, function (index, value) {
                    headers += "<th>" + value + "</th>"
                })
                table += headers + "</tr></thead><tbody class='LBT12'></tbody></table>"
                $("#DivTblGen").append(table);
                $("#ModalFile1").modal("show");
                var ColumExcel = [{ "targets": [0], "type": "num","visible": false }]
                TablaDoc09 = DatatableInitializeExcel("#TblGen", ColumExcel, "45vh");

            } else {
                var row = [];
                row.push(x +"&nbsp&nbsp")
                $.each(inf, function (index, value) {
                    row.push(value + "&nbsp&nbsp");
                })
                rows.push(row);
            }
        }
        TablaDoc09.rows.add(rows).draw();


        setTimeout(function () { TablaDoc09.columns.adjust().draw(); }, 250);
    }
}


function setFiltrosC(){
    try {
        localStorage.setItem("cc", $("#cc").val())
        localStorage.setItem("FUniMed", $("#FUniMed").val())
        localStorage.setItem("nConvenio", $("#nConvenio").val())
        localStorage.setItem("sta", $("#sta").val())
        localStorage.setItem("fIni", $("#fIni").val())
        localStorage.setItem("fFin", $("#fFin").val())
        localStorage.setItem("aseg", $("#aseg").val())
        localStorage.setItem("ncorto", $("#ncorto").val())
        localStorage.setItem("rfc", $("#rfc").val())
        localStorage.setItem("tipoC", $("#tipoC").val())
        localStorage.setItem("desc", $("#desc").val())
        localStorage.setItem("dsUrgen", $("#dsUrgen").val())
        localStorage.setItem("dsAmb", $("#dsAmb").val())
        localStorage.setItem("dsImg", $("#dsImg").val())
        localStorage.setItem("ResPag", $("#ResPag").val())
    } catch (e) {

    }
}


function ClearFiltrosC() {
    try {
        localStorage.removeItem("cc")
        localStorage.removeItem("FUniMed")
        localStorage.removeItem("nConvenio")
        localStorage.removeItem("sta")
        localStorage.removeItem("fIni")
        localStorage.removeItem("fFin")
        localStorage.removeItem("aseg")
        localStorage.removeItem("ncorto")
        localStorage.removeItem("rfc")
        localStorage.removeItem("tipoC")
        localStorage.removeItem("desc")
        localStorage.removeItem("dsUrgen")
        localStorage.removeItem("dsAmb")
        localStorage.removeItem("dsImg")
        localStorage.removeItem("ResPag")
        localStorage.removeItem("poscol");
    } catch (e) {

    }
}