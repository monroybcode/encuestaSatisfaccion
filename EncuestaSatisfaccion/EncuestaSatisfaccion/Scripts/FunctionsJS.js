
/* /
*variables constantes para iconos de  tipo de archivos
*/
var pdf = '<span style="color:#c36a62"><i style="font-size: 18px;" class="fas fa-file-pdf"></i></span>', excel = '<span style="color:green"><i style="font-size: 18px;" class="fas fa-file-excel"></i></span>', rar = '<span style="color:#008aad"><i  style="font-size: 18px;" class="fas fa-file-archive"></i></span>';
function fileimg(ext) {
    if (ext.toUpperCase() == "PDF") {
        return pdf;
    } else if (ext.toUpperCase() == "RAR") {
        return rar;
    } else if (ext.toUpperCase() == "XLSX") {
        return excel;
    } else { return '<span style="color:#c36a62"><i class="fas fa-file"></i></span>' }
}

function ConvEFDate(e, a) { if (e) { e = e.match(/\((.*)\)/), e = parseInt(e[1]); var t = new Date(e), r = function (e) { return (e < 10 ? "0" : "") + e }; return a.replace(/yyyy|MM|dd|HH|mm|ss/g, function (e) { switch (e) { case "yyyy": return r(t.getFullYear()); case "MM": return r(t.getMonth() + 1); case "mm": return r(t.getMinutes()); case "dd": return r(t.getDate()); case "HH": return r(t.getHours()); case "ss": return r(t.getSeconds()) } }) } return "" } function MNotif(e, a) { new PNotify({ title: "Información", text: e, type: a, delay: 2.5e3 }) } var isMobile = { Android: function () { return navigator.userAgent.match(/Android/i) }, BlackBerry: function () { return navigator.userAgent.match(/BlackBerry/i) }, iOS: function () { return navigator.userAgent.match(/iPhone|iPad|iPod/i) }, Opera: function () { return navigator.userAgent.match(/Opera Mini/i) }, Windows: function () { return navigator.userAgent.match(/IEMobile/i) || navigator.userAgent.match(/WPDesktop/i) }, any: function () { return isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows() } }; function UpdateTableRow(e, a, t, r) { var n = $("#" + r).dataTable().fnFindCellRowIndexes(a, 0); if (n) { var i = t.row(n); i.length > 0 ? t.row(i).data(e).draw(!1) : t.row.add(e).draw(!1) } }
function AjaxGenerico(e, a, t) {
    $("#DivLoader").show(); try {
        $.ajax({
            url: a, type: "POST", data: t, success: function (a) { RespuestaAjax(e, a) }, error: function (a, t, r) {
                if (401 == a.status || 403 == a.status) { var n = window.location.protocol + "//" + window.location.host; window.location.href = n, alert("Tu sesión ha finalizado") } else 500 == a.status && ($("#DivLoader").hide(), MNotif("Ocurrió un error al hacer la petición al servidor, f:" + e, "error"))
            }
        })
    } catch (a) { $("#DivLoader").hide(), MNotif("Ocurrió un error al hacer la petición al servidor, f:" + e, "error") }
}
function AjaxGenerico2(e, a, t) {
    $("#DivLoader").show(); try {
        $.ajax({
            url: a, type: "POST", data: t, success: function (a) { RespuestaAjax(e, a) }, error: function (a, t, r) {
                if (401 == a.status || 403 == a.status) { var n = window.location.protocol + "//" + window.location.host; window.location.href = n, alert("Tu sesión ha finalizado") } else 500 == a.status && ($("#DivLoader").hide(), MNotif("Ocurrió un error al hacer la petición al servidor, f:" + e, "error"))
            }
        })
    } catch (a) { $("#DivLoader").hide(), MNotif("Ocurrió un error al hacer la petición al servidor, f:" + e, "error") }
}


function AsignarDatosI(e) { $.each(e, function (e, a) { if ($("#" + e).length > 0) { var t = $("#" + e)[0].type; if ("text" == t || "textarea" == t) $("#" + e).val(a), $("#Lbl" + e).length > 0 && $("#Lbl" + e).addClass("active"); else if ("select-one" == t) $("#" + e).val(a).trigger("change"); else if ("date" == t) "dateFechaNac" == e ? $("#" + e).val(a) : a ? $("#" + e).val(a, "yyyy-MM-dd") : $("#" + e).val(""); else if ("checkbox" == t) 1 == a ? $("#" + e).prop("checked", !0) : $("#" + e).prop("checked", !1); else if ("time" == t) if (a) { var r = ("0" + a.Hours).slice(-2) + ":" + ("0" + a.Minutes).slice(-2) + ":" + ("0" + a.Seconds).slice(-2); $("#" + e).val(r) } else $("#" + e).val("") } }) } function AsignarDatosL(e) { $.each(e, function (e, a) { $("#" + e).length > 0 && ("FechaIngreso" == e || "FechaEgreso" == e ? $("#" + e).text(ConvEFDate(a, "dd/MM/yyyy")) : $("#" + e).text(a)) }) } function LimpiarInputDiv(e) { var a = $("#" + e).find(":input"); for (i = 0; i < a.length; i++) { var t = a[i].type; if ($(a[i]).hasClass("is-invalid") && $(a[i]).removeClass("is-invalid"), $("#InputInvalid" + $(a[i]).attr("id")).length > 0 && $("#InputInvalid" + $(a[i]).attr("id")).remove(), "text" == t || "date" == t || "password" == t || "textarea" == t || "time" == t || "file" == t) { $(a[i]).val(""); var r = $(a[i]).attr("id"); $("#Lbl" + r).length > 0 && $("#Lbl" + r).removeClass("active") } else if ("select-one" == t || "select-multiple" == t) { var n = $(a[i]).parent().children(), o = $(n[1]).children().children(); $(o).css("border", ""), $(a[i]).val("").trigger("change") } else "checkbox" == t ? $(a[i]).prop("checked", !1) : "number" == t && $(a[i]).val(0) } } function LimpiarInputDiv2(e) { var a = $("#" + e).find(":input"); for (i = 0; i < a.length; i++) { var t = a[i].type; "text" != t && "textarea" != t || "null" == $(a[i]).val() && $(a[i]).val("") } } function LimpiarInputDiv3(e) { var a = $("#" + e).find(":input"); for (i = 0; i < a.length; i++) { var t = a[i].type; if ($(a[i]).hasClass("is-invalid") && $(a[i]).removeClass("is-invalid"), $("#InputInvalid" + $(a[i]).attr("id")).length > 0 && $("#InputInvalid" + $(a[i]).attr("id")).remove(), "text" == t || "password" == t || "textarea" == t || "time" == t || "file" == t) { $(a[i]).val(""); var r = $(a[i]).attr("id"); $("#Lbl" + r).length > 0 && $("#Lbl" + r).removeClass("active") } else "checkbox" == t ? $(a[i]).prop("checked", !1) : "number" == t && $(a[i]).val(0) } } function RFechaClient(e) { var a = ""; e && (a = ("0" + (e = e.split("-"))[2]).slice(-2) + "/" + ("0" + e[1]).slice(-2) + "/" + e[0]); return a }


/* For Export Buttons available inside jquery-datatable "server side processing" - Start
- due to "server side processing" jquery datatble doesn't support all data to be exported
- below function makes the datatable to export all records when "server side processing" is on */

function newexportaction(e, dt, button, config) {
    var self = this;
    var oldStart = dt.settings()[0]._iDisplayStart;
    dt.one('preXhr', function (e, s, data) {
        // Just this once, load all data from the server...
        data.start = 0;
        data.length = 2147483647;
        dt.one('preDraw', function (e, settings) {
            // Call the original action function
            if (button[0].className.indexOf('buttons-copy') >= 0) {
                $.fn.dataTable.ext.buttons.copyHtml5.action.call(self, e, dt, button, config);
            } else if (button[0].className.indexOf('buttons-excel') >= 0) {
                $.fn.dataTable.ext.buttons.excelHtml5.available(dt, config) ?
                    $.fn.dataTable.ext.buttons.excelHtml5.action.call(self, e, dt, button, config) :
                    $.fn.dataTable.ext.buttons.excelFlash.action.call(self, e, dt, button, config);
            } else if (button[0].className.indexOf('buttons-csv') >= 0) {
                $.fn.dataTable.ext.buttons.csvHtml5.available(dt, config) ?
                    $.fn.dataTable.ext.buttons.csvHtml5.action.call(self, e, dt, button, config) :
                    $.fn.dataTable.ext.buttons.csvFlash.action.call(self, e, dt, button, config);
            } else if (button[0].className.indexOf('buttons-pdf') >= 0) {
                $.fn.dataTable.ext.buttons.pdfHtml5.available(dt, config) ?
                    $.fn.dataTable.ext.buttons.pdfHtml5.action.call(self, e, dt, button, config) :
                    $.fn.dataTable.ext.buttons.pdfFlash.action.call(self, e, dt, button, config);
            } else if (button[0].className.indexOf('buttons-print') >= 0) {
                $.fn.dataTable.ext.buttons.print.action(e, dt, button, config);
            }
            dt.one('preXhr', function (e, s, data) {
                // DataTables thinks the first item displayed is index 0, but we're not drawing that.
                // Set the property to what it was before exporting.
                settings._iDisplayStart = oldStart;
                data.start = oldStart;
            });
            // Reload the grid with the original page. Otherwise, API functions like table.cell(this) don't work properly.
            setTimeout(dt.ajax.reload, 0);
            // Prevent rendering of the full data to the DOM
            return false;
        });
    });
    // Requery the server with the new one-time export settings
    dt.ajax.reload();
};


function ValidaDivInputs(e) {
    var a = 0, t = $("#" + e).find(":input");
    var inp = [];
    for (i = 0; i < t.length; i++) {
        var xxx = $(t[i]).prop('disabled');
        var r = t[i].type; if (1 == t[i].required)
            if ("text" == r || "date" == r || "time" == r || "file" == r || "textarea" == r)
                if ("" != $(t[i]).val() && $(t[i]).val() || $(t[i]).prop('disabled'))
                    $(t[i]).hasClass("is-invalid") && $(t[i]).removeClass("is-invalid"), $("#InputInvalid" + $(t[i]).attr("id")).length > 0 && $("#InputInvalid" + $(t[i]).attr("id")).remove();
                else {
                    var n = $(t[i]).parent(); $(t[i]).hasClass("is-invalid") || $(t[i]).addClass("is-invalid"), 0 == $("#InputInvalid" + $(t[i]).attr("id")).length && n.append('<div class="invalid-feedback" id="InputInvalid' + $(t[i]).attr("id") + '">* Campo requerido</div>'), 0 == a && $(t[i]).focus(), a++, inp.push(t[i])
                }
            else if ("select-multiple" == r || "select-one" == r)
                if ($(t[i]).val() != "" && $(t[i]).val() && $(t[i]).val() != "0" || $(t[i]).prop('disabled')) {
                    o = (n = $(t[i]).parent()).children(), s = $(o[2]).children().children(); $(s).css("border", ""), $("#InputInvalid" + $(t[i]).attr("id")).length > 0 && $("#InputInvalid" + $(t[i]).attr("id")).remove()
                }
                else {
                    var o = (n = $(t[i]).parent()).children(), s = $(o[2]).children().children(); $(s).css("border", "1px solid #f86c6b"), 0 == $("#InputInvalid" + $(t[i]).attr("id")).length && n.append('<div class="invalid-feedback" id="InputInvalid' + $(t[i]).attr("id") + '">* Campo requerido</div>'), 0 == a && $(t[i]).focus(), a++, inp.push(t[i])
                } else "dfile" == r && alert("here")
    } return { a, inp }
} function OCEst(e) { switch (e) { case 1: return "#346094"; case 2: return "#9ad058"; case 3: return "#FF3300"; case 4: return "#666666"; default: return "#FFFFFF" } } function ObtenerPorcen(e) { try { return (e = parseFloat(e)).toFixed(2) } catch (e) { return 0 } } function LlenarSelect(e, a) { var t = $("#" + a); t.empty(), $.each(e, function (a) { t.append($("<option />").val(e[a].Id).text(e[a].Valor)) }) } function LlenarSelectName(e, a, t) { var r = $("#" + a); r.empty(), "" != t && r.append($("<option />").val(0).text(t)), $.each(e, function (a) { r.append($("<option />").val(e[a].Id).text(e[a].Name)) }) } function LlenarSelectOE(e, a, t) { var r = $("#" + a); r.empty(), r.append($("<option />").val(t[0].Id).text(t[0].Valor)), $.each(e, function (a) { r.append($("<option />").val(e[a].Id).text(e[a].Valor)) }) } function LlenarSelectN(e, a) { var t = $("#" + a); t.empty(), $.each(e, function (a) { t.append($("<option />").val(e[a].Valor).text(e[a].Valor)) }) } function ObtenerDiferencia(e) { e = ConvEFDate(e, "yyyy-MM-dd HH:mm:ss"); var a = Math.abs(new Date(e) - new Date) / 1e3, t = Math.floor(a / 86400); a -= 86400 * t; var r = Math.floor(a / 3600) % 24; a -= 3600 * r; var n = Math.floor(a / 60) % 60, i = (a -= 60 * n, ""); return t > 0 && (i += t + " dias "), r > 0 && (i += r + " horas "), n > 0 && (i += n + " minutos "), i ? i = "Hace " + i : i += "Hace un momento", i }

function ConvertSeconds(e) {
    try {
        var a = parseInt(e, 10);
        if ($.isNumeric(a) && a > 0) {
            var t = Math.floor(a / 86400);
            a -= 86400 * t;//* 24;
            var r = Math.floor(a / 3600);
            a -= 3600 * r;
            var n = Math.floor(a / 60);
            a -= 60 * n;
            var i = "";
            return t > 0 && (i += t + " Dias, "), r > 0 && (i += r + " Hrs, "), i + n + " Min"
        } return ""
    } catch (e) { return "" }
}

function DatatableInitializeES(e, a, t, r) {
    if (!$.fn.DataTable.isDataTable(e))
        return $(e).DataTable({
            language: {
                sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados",
                sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)",
                sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...",
                oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" },
                oAria: {
                    sSortAscending: ": Activar para ordenar la columna de manera ascendente",
                    sSortDescending: ": Activar para ordenar la columna de manera descendente"
                }
            }, buttons: [], columnDefs: a, scrollY: t, autoWidth: !1, scrollX: r, dom: "<'ui grid'<'row'<'col-6'l><'col-5'f><'col-1'B>><'row dt-table'<'col-12'tr>><'row'<'col-6'i><'col-6'p>>>"
        })
}
function DatatableInitialize(e, a, t) {
    if (!$.fn.DataTable.isDataTable(e))
        var r = $(e).DataTable({
            scrollCollapse: true,
            initComplete: function () {
                $(this.api().table().container()).find('input[type="search"]').parent().wrap('<form>').parent().attr('autocomplete', 'off').css('overflow', 'hidden').css('margin', 'auto');
            },
            language: {
                sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros",
                sZeroRecords: "No se encontraron resultados",
                sEmptyTable: "Ningún dato disponible en esta tabla",
                sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros",
                sInfoFiltered: "(filtrado de un total de _MAX_ registros)",
                sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",",
                sLoadingRecords: "Cargando...",
                oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" },
                responsive: !0,
                oAria: {
                    sSortAscending: ": Activar para ordenar la columna de manera ascendente",
                    sSortDescending: ": Activar para ordenar la columna de manera descendente"
                }
            },
            columnDefs: a, scrollY: t, autoWidth: !0, scrollX: !0
        },


        );

    return r
}

function DatatableInitialize3(e, a, t) { if (!$.fn.DataTable.isDataTable(e)) var r = $(e).DataTable({ language: { sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados", sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros", sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)", sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...", oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" }, oAria: { sSortAscending: ": Activar para ordenar la columna de manera ascendente", sSortDescending: ": Activar para ordenar la columna de manera descendente" } }, columnDefs: a, responsive: !0, scrollY: t, autoWidth: !1, scrollX: !0, bFilter: !1, bInfo: !1, scrollCollapse: !0 }); return r } function OnlyTableInitialize(e, a, t) { if (!$.fn.DataTable.isDataTable(e)) var r = $(e).DataTable({ language: { sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados", sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros", sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)", sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...", oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" }, oAria: { sSortAscending: ": Activar para ordenar la columna de manera ascendente", sSortDescending: ": Activar para ordenar la columna de manera descendente" } }, columnDefs: a, scrollY: t, autoWidth: !1, scrollX: !0, dom: "t" }); return r } function filename(e) { return ((e = e.substring(e.lastIndexOf("/") + 1)).match(/[^.]+(\.[^?#]+)?/) || [])[0] } function ReAcomodarF1(e, a, t) { if (e) { var r = new Date(e + " 00:00:00"), n = r.getDate(), i = r.getMonth() + 1, o = r.getFullYear(); return ("0" + n).slice(-2) + t + ("0" + i).slice(-2) + t + o } return "" } function ReAcomodarF2(e, a) { var t = e.getDate(), r = e.getMonth() + 1; return e.getFullYear() + a + ("0" + r).slice(-2) + a + ("0" + t).slice(-2) } function ReAcomodarF3(e, a) { var t = e.getDate(), r = e.getMonth() + 1, n = e.getFullYear(); return ("0" + t).slice(-2) + a + ("0" + r).slice(-2) + a + n } function addDays(e, a) { return new Date(e.getFullYear(), e.getMonth(), e.getDate() + a, e.getHours(), e.getMinutes(), e.getSeconds()) } function convertHoras(e, a) { return e < 10 && (e = "0" + e), a < 10 && (a = "0" + a), e + ":" + a }

function DatatableInitializeCB(ITable, ColumnD, HE) {
    if (!$.fn.DataTable.isDataTable(ITable)) {
        var NewDatatable = $(ITable).DataTable({
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ ",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando solicitudes del _START_ al _END_ de un total de _TOTAL_ ",
                "sInfoEmpty": "Mostrando solicitudes del 0 al 0 de un total de 0 ",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                responsive: true,
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                },
            },
            "columnDefs": ColumnD,
            //"select": { "style": "os", "selector": 'td:first-child' },
            scrollY: HE, "autoWidth": true, "scrollX": true,


        });
    }

    return NewDatatable;
}
function EmailValido(e) {
    return new RegExp(/^[^<>()[\]\\,;:\%#^\s@\"$&!@]+@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z0-9]+\.)+[a-zA-Z]{2,}))$/).test(e)
} function getAge(e) { var a = new Date, t = new Date(e), r = a.getFullYear() - t.getFullYear(), n = a.getMonth() - t.getMonth(); return (n < 0 || 0 === n && a.getDate() < t.getDate()) && r--, r } function FunKeyDown(e, a) { var t; t = e.key; var r = e.keyCode; if (37 != r && 39 != r && 38 != r && 40 != r && 9 != r && 17 != r && 18 != r && 20 != r && 16 != r && 8 != r && 46 != r && 219 != r) { var n = "", i = ""; switch (a) { case 0: n = "^[a-zA-Z,.\\s]*$", i = /^[\u00C0-\u00FF]+$/; break; case 1: n = "^[a-zA-Z.\\s]*$", i = /^[\u00C0-\u00FF]+$/; break; case 2: n = "^[a-zA-Z.,?¡¿!1-9\\s[]]*$", i = /^[\u00C0-\u00FF]+$/; break; case 3: n = "^[a-zA-Z1-9\\s]*$", i = /^[\u00C0-\u00FF]+$/; break; case 4: n = "^[a-zA-Z0-9\\s _]*$", i = /^[\u00C0-\u00FF]+$/; break; case 5: n = "^[a-zA-Z]*$", i = /^[\u00C0-\u00FF]+$/ }return !(!t.match(i) && !t.match(n)) } return !0 } function FunKeyUp(e, a) { var t = ""; switch (a) { case 0: t = /[&\/\\#+()$~%'":*?<>{}'""0-9-´´@☺^]/g; break; case 1: t = /[<>]/g; break; case 2: t = /^(.)(.*)(.@.*)$/; case 3: t = /[&\/\\#+()$~%'":*?<>{}'""'@¬\^`~´´.,-]/g }if (0 == a) { var r = $(e).val().replace(/[^a-zA-Z áéíóúÁÉÍÓÚ]/g, ""); $(e).val(r) } var n = $(e).val(); n = n.replace(t, ""), 0 == a || 1 == a ? $(e).val(MayuscFL(n)) : 3 == a ? $(e).val(n.toUpperCase()) : $(e).val(n.toLowerCase()) } function MayuscFL(e) { return e.charAt(0).toUpperCase() + e.slice(1) } function AMPM(e) { var a = e.split(":"), t = a[0] + a[1], r = t[0] + t[1], n = t[2] + t[3]; return r < 12 ? r + ":" + n + " AM" : (r = (r -= 12).length < 10 ? "0" + r : r) + ":" + n + " PM" } function TableAdjust(e) { setTimeout(function () { e.columns.adjust().responsive.recalc() }, 230) } function Load(e) { 0 == e ? $("#DivLoader").show() : $("#DivLoader").hide() } function formatMoney(e, a, t, r) { a = isNaN(a = Math.abs(a)) ? 2 : a, t = null == t ? "." : t, r = null == r ? "," : r; var n = e < 0 ? "-" : "", i = String(parseInt(e = Math.abs(Number(e) || 0).toFixed(a))), o = (o = i.length) > 3 ? o % 3 : 0; return n + (o ? i.substr(0, o) + r : "") + i.substr(o).replace(/(\d{3})(?=\d)/g, "$1" + r) + (a ? t + Math.abs(e - i).toFixed(a).slice(2) : "") } function MoneyFor(e) { return e = parseFloat(e), isNaN(e) ? 0 : e.toFixed(2).toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,") } function ReordenarFechaMex(e) { var a = ""; e && (a = ("0" + (e = e.split("-"))[0]).slice(-2) + "/" + ("0" + e[1]).slice(-2) + "/" + e[2]); return a } function DatatableInitialize2(e, a, t) { if (!$.fn.DataTable.isDataTable(e)) var r = $(e).DataTable({ language: { sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados", sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros", sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)", sInfoPostFix: "", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando..." }, columnDefs: a, responsive: !0, scrollY: t, autoWidth: !1, scrollX: !0, searching: !1, paging: !1, info: !1 }); return r }
function DatatableInitialize3(e, a, t) {
    if (!$.fn.DataTable.isDataTable(e))
        var r = $(e).DataTable({
            language: {
                sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados",
                sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)", sInfoPostFix: "",
                sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...", oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" },
                oAria: { sSortAscending: ": Activar para ordenar la columna de manera ascendente", sSortDescending: ": Activar para ordenar la columna de manera descendente" }
            }, columnDefs: a, responsive: !0, scrollY: t, autoWidth: !1, scrollX: !0, searching: !0, paging: !1, info: !1, scrollCollapse: !0
        }); return r
}
function rfcValido(e, a = !0) {
    var t = e.match(/^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$/);
    if (!t) return !1; const r = t.pop(), n = t.slice(1).join(""), i = n.length, o = i + 1; var s, l; s = 12 == i ? 0 : 481; for (var d = 0; d < i; d++)s += "0123456789ABCDEFGHIJKLMN&OPQRSTUVWXYZ Ñ".indexOf(n.charAt(d)) * (o - d); return 11 == (l = 11 - s % 11) ? l = 0 : 10 == l && (l = "A"), !!(r == l || a && n + r == "XAXX010101000") && (!(!a && n + r == "XEXX010101000") && n + r)
}
function validarInputRFC(e) {
    try { return rfcValido(e.trim().toUpperCase()) ? 1 : 0 } catch (e) { alert("Ocurrió un error al verificar el EFC") }
}
$(document).on("input", ".OnlyNumbers", function () {
    this.value = this.value.replace(/[^0-9]/g, "")
});


function DatatableInitializePrint(e, a, t) {
    if (!$.fn.DataTable.isDataTable(e))
        var r = $(e).DataTable({
            language: {
                sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados",
                sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)",
                sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...",
                oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" },
                oAria: {
                    sSortAscending: ": Activar para ordenar la columna de manera ascendente",
                    sSortDescending: ": Activar para ordenar la columna de manera descendente"
                }
            },
            //rowGroup: {
            //    dataSrc: function (row) {
            //        return row[0];
            //    }
            //},
            columnDefs: a,
            scrollY: t,
            dom: "<'ui grid'<'row'<'col-6'l><'col-5'f><'col-1'B>><'row dt-table'<'col-12'tr>><'row'<'col-6'i><'col-6'p>>>",
            buttons: [
                {
                    extend: 'print',
                    text: ' <i class="nav-icon fas fa-print"></i>',
                    titleAttr: 'Imprimir',
                    footer: true,
                    customize: function (win) {
                        var last = null;
                        var current = null;
                        var bod = [];
                        var css = '@page {size: Letter landscape; }  body{  writing-mode: rl; -webkit-print-color-adjust: exact; } .th{  background-color:#C2BBBB;}',
                            head = win.document.head || win.document.getElementsByTagName('head')[0],
                            body = win.document.body || win.document.getElementsByTagName('body')[0],
                            style = win.document.createElement('style');
                        style.type = 'text/css';
                        style.media = 'print';

                        if (style.styleSheet) {
                            style.styleSheet.cssText = css;
                        }
                        else {
                            style.appendChild(win.document.createTextNode(css));
                        }
                        head.appendChild(style);
                        var img = document.createElement("img");
                        img.src = "~/../../Images/logo-small.png";

                        body.prepend(img);

                    },

                }, {
                    extend: 'excel',
                    text: ' <i  class="nav-icon fas fa-file-excel"></i>',
                    titleAttr: 'Exportar a excel',

                }
            ],
        })
    return r;
}



function DatatableInitializeGroup(e, a, t) {
    if (!$.fn.DataTable.isDataTable(e))
        var r = $(e).DataTable({
            language: {
                sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados",
                sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)",
                sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...",
                oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" },
                oAria: {
                    sSortAscending: ": Activar para ordenar la columna de manera ascendente",
                    sSortDescending: ": Activar para ordenar la columna de manera descendente"
                }
            },
            rowGroup: {
                dataSrc: function (row) {
                    return row[0];
                }
            },
            columnDefs: a,
            scrollY: t,
            dom: "<'ui grid'<'row'<'col-6'l><'col-5'f><'col-1'B>><'row dt-table'<'col-12'tr>><'row'<'col-6'i><'col-6'p>>>",
            buttons: [
                {
                    extend: 'print',
                    text: ' <i class="nav-icon fas fa-print"></i>',
                    titleAttr: 'Imprimir',
                    footer: true,
                    customize: function (win) {
                        var last = null;
                        var current = null;
                        var bod = [];
                        var css = '@page {size: Letter landscape; }',
                            head = win.document.head || win.document.getElementsByTagName('head')[0],
                            body = win.document.body || win.document.getElementsByTagName('body')[0],
                            style = win.document.createElement('style');
                        style.type = 'text/css';
                        style.media = 'print';

                        if (style.styleSheet) {
                            style.styleSheet.cssText = css;
                        }
                        else {
                            style.appendChild(win.document.createTextNode(css));
                        }
                        head.appendChild(style);
                        var img = document.createElement("img");
                        img.src = "~/images/logo-small.png";

                        body.prepend(img);

                    },

                }, {
                    extend: 'excel',
                    text: ' <i  class="nav-icon fas fa-file-excel"></i>',
                    titleAttr: 'Exportar a excel',

                }
            ],
        })
    return r;
}


function DatatableInitializeGroup2(e, a, t) {
    if (!$.fn.DataTable.isDataTable(e))
        var r = $(e).DataTable({
            language: {
                sProcessing: "Procesando...", sLengthMenu: "Mostrar _MENU_ registros", sZeroRecords: "No se encontraron resultados",
                sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)",
                sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...",
                oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" },
                oAria: {
                    sSortAscending: ": Activar para ordenar la columna de manera ascendente",
                    sSortDescending: ": Activar para ordenar la columna de manera descendente"
                }
            },
            rowGroup: {
                dataSrc: function (row) {
                    return row[0];
                }
            },
            columnDefs: a,
            scrollY: t,
            dom: "<'ui grid'<'row'<'col-6'l><'col-5'f><'col-1'B>><'row dt-table'<'col-12'tr>><'row'<'col-6'i><'col-6'p>>>",
            buttons: [
                {
                    extend: 'print',
                    text: ' <i class="nav-icon fas fa-print"></i>',
                    titleAttr: 'Imprimir',
                    footer: true,
                    customize: function (win) {
                        var last = null;
                        var current = null;
                        var bod = [];
                        var css = '@page {size: Letter landscape; }',
                            head = win.document.head || win.document.getElementsByTagName('head')[0],
                            body = win.document.body || win.document.getElementsByTagName('body')[0],
                            style = win.document.createElement('style');
                        style.type = 'text/css';
                        style.media = 'print';

                        if (style.styleSheet) {
                            style.styleSheet.cssText = css;
                        }
                        else {
                            style.appendChild(win.document.createTextNode(css));
                        }
                        head.appendChild(style);
                        var img = document.createElement("img");
                        img.src = "~/images/logo-small.png";

                        body.prepend(img);

                    },

                }, {
                    extend: 'excel',
                    text: ' <i  class="nav-icon fas fa-file-excel"></i>',
                    titleAttr: 'Exportar a excel',

                }
            ],
        })
    return r;
}


(function ($) {
    try {

        $.fn.dataTable.render.GeneraCheck = function () {
            return function (d, type, row) {
                if (d) {
                    return '<input type="checkbox" class="checkG checkN"   id="checkm' + d + '" />';
                } else {
                    return '';
                }

            };
        }
        $.fn.dataTable.render.GeneraPrio = function () {
            return function (d, type, row) {
                if (row.Pri) {
                    return '<div  style="background-color: ' + (row.Pri == 1 ? "green" : "red") + ';height: 20px; margin-left: 35% !important;width: 20px; text-align:center; vertical-align: middle;  display: table;  border-radius: 30px;"><label style="align-items: center;vertical-align: middle;display: table-cell; !important;"></label></div>';
                } else {
                    return '';
                }

            };
        }

        $.fn.dataTable.render.Generaradio = function () {
            return function (d, type, row) {
                if (d) {
                    return '<input type="radio" class="checkR checkN" name="checkm"  id="checkm' + d + '" />';
                } else {
                    return '';
                }

            };
        }
        $.fn.dataTable.render.Meses = function () {
            return function (d, type, row) {
                return GeneraCell(d, row.CheckS, 1);
            };
        }

        $.fn.dataTable.render.RDia = function () {
            return function (d, type, row) {
                return GeneraCell(d, row.CheckS, 2);
            };
        }
        $.fn.dataTable.render.TEvento = function () {
            return function (d, type, row) {
                return GeneraCell(d, row.TEvento, 3);
            };
        }

        $.fn.dataTable.render.buttonsx = function (tp) {
            return function (d, type, row) {
                if (d) {
                    return "<button type='button' class='btn btn-primary btn-sm' title='Agregar' onclick='addContacto(" + d + "," + tp + ")'><i class='fas fa-user-check'></i></button>";
                } else {
                    return "";
                }

            };
        }
        $.fn.dataTable.render.ellipsis = function (cutoff, wordbreak, escapeHtml) {
            var esc = function (t) {
                return t
                    .replace(/&/g, '&amp;')
                    .replace(/</g, '&lt;')
                    .replace(/>/g, '&gt;')
                    .replace(/"/g, '&quot;');
            };

            return function (d, type, row) {
                if (d) {
                    //var capac = 0;
                    //if (Widthscr <= 1000) {
                    //    capac = cutoff;
                    //} else if (Widthscr >= 1001 && Widthscr <= 1366) {
                    //    capac = cutoff + 5;
                    //} else if (Widthscr >= 1367 && Widthscr <= 1600) {
                    //    capac = cutoff + 10;
                    //} else if (Widthscr >= 1601 && Widthscr <= 2000) {
                    //    capac = cutoff + 20;
                    //} else {
                    //    capac = cutoff + 70;
                    //}

                    //var asd = "";
                    //var shortened
                    //if (d.length >= capac) {
                    //    asd = "...";
                    //    shortened = d.substr(0, capac - 2);
                    //} else {
                    //    shortened = d;
                    //}



                    //// Find the last white space character in the string
                    //if (wordbreak) {
                    //    shortened = shortened.replace(/\s([^\s]*)$/, '');
                    //}

                    //// Protect against uncontrolled HTML input
                    //if (escapeHtml) {
                    //    shortened = esc(shortened);
                    //}



                    return '<span  title="' + esc(d) + '">' + d + '</span>';
                } else {
                    return '<span class="ellipsis" title=""></span>';
                }

            };
        };


        $.fn.serializeFormJSON = function () {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name]) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    var hc = $("#" + this.name).hasClass("money");
                    if (!hc)
                        hc = $("#" + this.name).hasClass("percent");

                    var t = $("#" + this.name)[0].type;
                    if (t == "text" || t == "date" || t == "select-one" || t == "textarea")
                        if (!hc)
                            o[this.name] = this.value || '';
                        else
                            o[this.name] = this.value.replace("%", "").replace(/,/g, '') || '';
                    else if (t == "checkbox")
                        o[this.name] = $("#" + this.name).is(":checked")
                }
            });
            return o;
        };
    } catch (e) {
        console.log(e);
    }

})(jQuery);


function Checkrgx(inp) {
    var nv = $(inp).val().replace(/[^a-zA-Z0-9 -]/g, "");
    $(inp).val(nv);
}


function destroyfill() {
    try {
        localStorage.removeItem("filoc");
    } catch (e) {
        alert(e);
    }
}


function ConvertSeconds(Sec) {
    try {
        var seconds = parseInt(Sec, 10);

        if ($.isNumeric(seconds) && seconds > 0) {

            var days = Math.floor(seconds / (3600 * 24));
            seconds -= days * 3600 * 24;
            var hrs = Math.floor(seconds / 3600);
            seconds -= hrs * 3600;
            var mnts = Math.floor(seconds / 60);
            seconds -= mnts * 60;
            //var secnds = Math.floor(seconds / 60);
            //seconds -= secnds * 60;

            var Resultado = "";
            if (days > 0) {
                Resultado += days + " Dias, ";
            }
            if (hrs > 0) {
                Resultado += hrs + " Hrs, "
            }
            return Resultado + mnts + " Min " + seconds + " sec";
        } else {
            return '';
        }

    } catch (err) {
        return '';
    }

}



function dttmdt(date) {

    if (date) {
        date = date.split(" ");
        date = date[0].split("/");
        date = date[2] + "-" + date[1] + "-" + date[0];

        var d = new Date(date + " 00:00:00"), month = '' + (d.getMonth() + 1), day = '' + d.getDate(), year = d.getFullYear();
        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [day, month, year].join('/');
    } else {
        return "";
    }
}

function FormatDatex(d) {
    if (d) {
        var month = '' + (d.getMonth() + 1), day = '' + d.getDate(), year = d.getFullYear();
        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [day, month, year].join('/');
    } else {
        return "";
    }
}


function bytesToSize(bytes) {
    var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
    if (bytes == 0) return 'n/a';
    var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
    if (i == 0) return bytes + ' ' + sizes[i];
    return (bytes / Math.pow(1024, i)).toFixed(1) + ' ' + sizes[i];
};

function Checkerr(xhr) {
    $(".indCarga").prop("disabled", false);
    if (xhr.status == 403) {
        var Login = window.location.protocol + "//" + window.location.host;
        window.location.href = Login;
        alert("Tu sesión ha finalizado")
    } else if (xhr.status == 500) {
        $("#DivLoader").hide();
        MNotif("Ocurrió un error al hacer la petición al servidor, f:fu", "error")
    }
    else {
        MNotif("Ocurrió un error al hacer la petición al servidor, f:fu", "error")
    }
    $("#DivLoader").hide();
}


function diff_years(dt1) {
    var ageDifMs = Date.now() - dt1;
    var ageDate = new Date(ageDifMs); // miliseconds from epoch
    return Math.abs(ageDate.getUTCFullYear() - 1970);
}



function DatatableInitializex2(e, a, t) {
    if (!$.fn.DataTable.isDataTable(e))
        var r = $(e).DataTable({
            "lengthChange": false,
            bFilter: false,
            "bPaginate": false,
            language: {
                sProcessing: "Procesando...",
                sLengthMenu: "Mostrar _MENU_ registros",
                sZeroRecords: "No se encontraron resultados", sEmptyTable: "Ningún dato disponible en esta tabla", sInfo: "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros", sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros", sInfoFiltered: "(filtrado de un total de _MAX_ registros)", sInfoPostFix: "", sSearch: "Buscar:", sUrl: "", sInfoThousands: ",", sLoadingRecords: "Cargando...", oPaginate: { sFirst: "Primero", sLast: "Último", sNext: "Siguiente", sPrevious: "Anterior" }, responsive: !0, oAria: { sSortAscending: ": Activar para ordenar la columna de manera ascendente", sSortDescending: ": Activar para ordenar la columna de manera descendente" }
            }, columnDefs: a, scrollY: t, autoWidth: !0, scrollX: !0, scrollCollapse: true
            //, "rowCallback": function (row, data, dataIndex) {
            //    $(row).removeClass("rowError");
            //    if (data[5]) {
            //        $(row).addClass("rowError");
            //    }
            //}
        }); return r
}

function GetMes(x) { switch (x) { case 1: return "Enero"; case 2: return "Febrero"; case 3: return "Marzo"; case 4: return "Abril"; case 5: return "Mayo"; case 6: return "Junio"; case 7: return "Julio"; case 8: return "Agosto"; case 9: return "Septiembre"; case 10: return "Octubre"; case 11: return "Noviembre"; case 12: return "Diciembre"; } }

function GetMesCorto(x) { switch (x) { case 1: return "Ene"; case 2: return "Feb"; case 3: return "Mar"; case 4: return "Abr"; case 5: return "May"; case 6: return "Jun"; case 7: return "Jul"; case 8: return "Ago"; case 9: return "Sep"; case 10: return "Oct"; case 11: return "Nov"; case 12: return "Dic"; } }

function GeneraCell(d, id, Op) {
    if (d) {
        var sdata = d.split("|");
        var styleex = "", oncl = "", NomEq = sdata[0];
        if (Op == 1) {
            if (sdata[3] == 1 || sdata[3] == 3) {
                styleex = "cursor:pointer;"
                oncl = "onclick='OnGeneraAg(" + id + ", " + sdata[4] + ")'";
            } else if (sdata[3] == 2) {
                styleex = "cursor:pointer;"
                oncl = "onclick='GetPro(" + id + ", " + sdata[4] + ")'";
            }
        } else if (Op == 2) {
            if (sdata[3] == 1 || sdata[3] == 2) {
                styleex = "cursor:pointer;"
                oncl = "onclick='OnGeneraAg(" + id + ", " + sdata[7] + "," + sdata[3] + ")'";
                if (sdata[4] == "False" && sdata[3] == 1) {
                    var splitf1 = sdata[5].split(".");
                    var splitf2 = sdata[6].split(".");
                    NomEq = splitf1[0].substring(0, 5) + " - " + splitf2[0].substring(0, 5);
                }
            }
        }

        return '<div ' + oncl + ' style="height: 100%;width: 100%;background-color: ' + sdata[1] + ';text-align: center;vertical-align: middle;display: table;"><label style="align-items: center;vertical-align: middle;display: table-cell;color: ' + sdata[2] + ' !important;' + styleex + '">' + NomEq + '</label></div>';
    } else {
        return '<div style="height: 100%;width: 100%;background-color: white;text-align: center;vertical-align: middle;display: table;"><label style="align-items: center;vertical-align: middle;display: table-cell;"></label></div>';;
    }
}


Date.prototype.yyyymmdd = function () {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return [this.getFullYear(),
    (mm > 9 ? '' : '0') + mm,
    (dd > 9 ? '' : '0') + dd
    ].join('-');
};

function UpdateTableRow2(e, a, t, r) {
    var n = $("#" + r).dataTable().fnFindCellRowIndexes(a, 1);
    if (n) { var i = t.row(n); i.length > 0 ? t.row(i).data(e).draw(!1) : t.row.add(e).draw(!1) }
}

function calculardiferencia(h1, h2) {
    var hora_inicio = h1;
    var hora_final = h2;

    var formatohora = /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/;

    if (!(hora_inicio.match(formatohora)
        && hora_final.match(formatohora))) {
        return;
    }

    var minutos_inicio = hora_inicio.split(':')
        .reduce((p, c) => parseInt(p) * 60 + parseInt(c));
    var minutos_final = hora_final.split(':')
        .reduce((p, c) => parseInt(p) * 60 + parseInt(c));

    if (minutos_final < minutos_inicio) return;

    var diferencia = minutos_final - minutos_inicio;

    var horas = Math.floor(diferencia / 60);
    var minutos = diferencia % 60;

    if (horas == 0 && minutos < 30) {
        return 1
    } else { return 0; }
}


$.fn.dataTableExt.ofnSearch['string'] = function (data) {
    return !data ?
        '' :
        typeof data === 'string' ?
            data
                .replace(/\n/g, ' ')
                .replace(/á/g, 'a')
                .replace(/é/g, 'e')
                .replace(/í/g, 'i')
                .replace(/ó/g, 'o')
                .replace(/ú/g, 'u')
                .replace(/ê/g, 'e')
                .replace(/î/g, 'i')
                .replace(/ô/g, 'o')
                .replace(/è/g, 'e')
                .replace(/ï/g, 'i')
                .replace(/ü/g, 'u')
                .replace(/ç/g, 'c') :
            data;
};