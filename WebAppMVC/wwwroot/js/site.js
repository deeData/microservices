// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//billing charge section
var amount = null;
var remark = null;
$('#amounts li').on('click', function () {
    _amount = 0;

    remark = $(this).find('span.violation').text();
    _amount = $(this).find('span.fine').text();
    var display = remark + " $" + _amount;
    //set charge field display
    $('#amt').val(display);
   
    amount = parseFloat(_amount);
    //console.log(amount1);

    var purchase = {
        items: [{ id: "item", amount: amount }]
    };

});


var jsonItem = {};
function postCharge() {

    if (amount != null) {
        jsonItem.remarks = remark;
        jsonItem.debit = amount *-1;
        //console.log(JSON.stringify(jsonItem));
        //console.log(jsonItem.debit);

        $.ajax({
            type: "POST",
            //data being sent to API should be a JSON string
            data: JSON.stringify(jsonItem),
            //expected reponse from API is json
            dataType: "json",
            //type sent to server
            contentType: 'application/json; charset=utf-8',
            //api request to
            url: "https://localhost:44372/api/payment/charge",
            //if response is successful
            success: function (result) {
                jsonData.push(result);
                var $table = $('#dataTable')
                $table.bootstrapTable('load', jsonData);
                generalMessage("Charge of $" + result['debit']*-1 + " for " + result['remarks'] + " is posted to the billing ledger.");
                //console.log(jsonData);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR, textStatus, errorThrown);
            }
        });
    }
    $('#amt').val("");
    amount = null;
    remark = null;
}

$(".bi-clipboard").click(function () {
    var text = $(this).prev("input").val();
    navigator.clipboard.writeText(text); // copy to clipboard
    $(this).notify("Copied", "info");
});

var dateTimeStamp = function (dateInFirstColumn) {
    var date = new Date(dateInFirstColumn);
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();
    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ':' + seconds + " " + ampm;
    return (date.getMonth() + 1) + "/" + date.getDate() + "/" + date.getFullYear() + "  " + strTime;
}



var currencyFormatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
});

var format = function (data) {
    return currencyFormatter.format(data);
}

var currencyFormat = function (column, row, index) {
    return format(column);
}

//for ledger datatable
var runningTotal = 0;
//goes through every preceding row
var getBalance = function (column, row, index) {
    runningTotal += row.debit;
    runningTotal += row.credit;
    return format(runningTotal);
}

$(".bi-arrow-counterclockwise").on('click', function () {
    //$('#pymtDiv').load(document.URL + ' #pymtDiv');
    location.reload();

});

$('.popover-hover').popover({
    trigger: 'hover'
});

$(document).ready(function () {
    var $table = $('#dataTable')
    $table.bootstrapTable({
        data: jsonData
    });
    $table.dataTable();
 
});

