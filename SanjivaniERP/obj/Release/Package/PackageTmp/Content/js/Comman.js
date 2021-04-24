
$('input:checkbox').click(function () {
    $('input:checkbox').not(this).prop('checked', false);
});

function ShowDialog(dialogName, title) {
    $("#" + dialogName).dialog({
        autoOpen: false,
        title: title,
        width: 800,
        modal: true,
        open: function (type, data) {
            $(this).parent().appendTo("form");
        }

    });
    $("#" + dialogName).dialog("open");
    return false;
}
function CloseDialog(dialogName) {

    $("#" + dialogName).dialog("close");
    return false;
}

function loadData(url, data) {
    var d = '';
    $("div#divLoading").addClass('show');
    $.ajax({
        type: "GET",
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        async: false,
        success: function (response) {
            d = response;
        },
        failure: function (response) {

        },
        error: function (response) {
            alert('Something went wrong please try again');
        }
    });
   
    return d;
}

function insertUpdateDelete(url, data) {
    var result = '';
    $.ajax({
        type: 'get',
        dataType: 'json',
        data: data,
        async: false,
        url: url,
        success: function (data) {
            result = data;
        },
        error: function (response) {
            result = data;
        }
    });
    return result;
}
function postData(url, data) {
    var result = '';
    $.ajax({
        type: 'Post',
        dataType: 'json',
        data: data,
        async: false,
        url: url,
        success: function (data) {
            result = data;
        },
        error: function (response) {
            result = data;
        }
    });
    return result;
}

function getJsonResult(Url, data) {
    var r = '';
    $.ajax({
        url: Url,
        dataType: 'json',
        async: false,
        data: data,
        success: function (data) {
            r = data;
        }
    });
    return r;

}
function getFormatedDate() {
    var hoy = new Date(),
        d = hoy.getDate(),
        m = hoy.getMonth() + 1,
        y = hoy.getFullYear(),
        data;

    if (d < 10) {
        d = "0" + d;
    };
    if (m < 10) {
        m = "0" + m;
    };
    return d + "-" + m + "-" + y;
};
function getdate(data) {
    var now = data;
    var day = ("0" + data.getDate()).slice(-2);
    var month = ("0" + (data.getMonth() + 1)).slice(-2);
    var today = data.getFullYear() + "-" + (month) + "-" + (day);
    return today;
}

var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,',
        template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>',
        base64 = function (s) {
            return window.btoa(unescape(encodeURIComponent(s)))
        }, format = function (s, c) {
            return s.replace(/{(\w+)}/g, function (m, p) {
                return c[p];
            })
        }
    return function (table, name, filename) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = {
            worksheet: name || 'Worksheet',
            table: table.innerHTML
        }

        document.getElementById("dlink").href = uri + base64(format(template, ctx));
        document.getElementById("dlink").download = filename;
        document.getElementById("dlink").traget = "_blank";
        document.getElementById("dlink").click();

    }
})();



function dateRange(date) {

    var date1 = $.datepicker.parseDate("yy, mm , dd", $("#checkinDate").text());
    var date2 = $.datepicker.parseDate("yy, mm , dd", $("#checkoutDate").text());
    var isHighlight = date1 && ((date.getTime() == date1.getTime()) || (date2 && date >= date1 && date <= date2));
    $(document).ready(function () {
        // $("td.dp-highlight").text("Y");

    });
    return [true, isHighlight ? "dp-highlight" : ""];
}

function DRonSelect(dateText, inst) {
    var date1 = $.datepicker.parseDate("yy, mm , dd", $("#checkinDate").text());
    var date2 = $.datepicker.parseDate("yy, mm , dd", $("#checkoutDate").text());
    var data;
    if (!date1 || date2) {
        $("#checkinDate").text(dateText);
        $("#checkoutDate").text("");
        $("#Datepicker").datepicker();
    }
    else {
        var fd = '';
        var td = '';
        if ($.datepicker.parseDate("yy, mm , dd", $("#checkinDate").text()) >=
            $.datepicker.parseDate("yy, mm , dd", dateText)) {
            $("#checkinDate").text(dateText);
            $("#checkoutDate").text("");
            $("#Datepicker").datepicker();
        }
        else {
            $("#checkoutDate").text(dateText);
            $("#Datepicker").datepicker();
        }
        var fd = $("#checkinDate").text();
        var td = $("#checkoutDate").text();

        if (td != '') {
            var data = { FromDate: fd, ToDate: td };
        }
    }
    return data;
}