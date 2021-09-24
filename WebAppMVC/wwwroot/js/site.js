// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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