var icons = document.getElementById('icon-all');

var item1 = $("#w3s").text();
var item2 = $("#w4s").text();
var item3 = $("#w5s").text();
var item4 = $("#w6s").text();
var item5 = $("#w7s").text();
var item6 = $("#w8s").text();
var item7 = $("#w9s").text();
var item8 = $("#w10s").text();

var dem = 1;
function displayicon() {
    dem += 1;
    if (dem % 2 === 0) {
        icons.style.display = 'block';
    } else {
        icons.style.display = 'none';
    }

}

$(document).ready(function () {
    $("#w3s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item1;
        $("#input").val(text);
    });
    $("#w4s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item2;
        $("#input").val(text);
    });
    $("#w5s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item3;
        $("#input").val(text);
    });
    $("#w6s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item4;
        $("#input").val(text);
    });
    $("#w7s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item5;
        $("#input").val(text);
    });
    $("#w8s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item6;
        $("#input").val(text);
    });
    $("#w9s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item7;
        $("#input").val(text);
    });
    $("#w10s").on("click", function () {
        var cu = $("#input").val();
        var text = cu + item8;
        $("#input").val(text);
    });

});