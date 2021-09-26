// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    var $table = $('#dataTable')
    $table.bootstrapTable({
        data: jsonData
    });
    $table.dataTable();

});

var jsonItem = {};
function postCharge() {
    jsonItem.debit = amount;
    //console.log(JSON.stringify(jsonItem));
    $('#amt').val("");

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
            console.log(jsonData);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("ERROR");
            console.log(jqXHR, textStatus, errorThrown);
        }

    });


}


//billing charge section
var amount = 0;
$('#amounts li').on('click', function () {
    amount1 = 0;
    //set charge field display
    $('#amt').val($(this).text());
    amount1 = $('#amt').val();
    amount = parseFloat(amount1);
    //console.log(amount1);

    var purchase = {
        items: [{ id: "item", amount: amount1 }]
    };

});


//used in home page
$(function () {
    $('data-toggle="tooltip"').tooltip();
});

//popover bootstrap
$('.popover-hover').popover({
    trigger: 'hover'
})


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

