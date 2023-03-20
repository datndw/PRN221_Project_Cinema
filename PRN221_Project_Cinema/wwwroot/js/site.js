// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/cinemaHub").build();

connection.on("ReloadMovie", function () {
    location.reload();
});

connection.start().then().catch(function (err) {
    return console.log(err.toString());
});
