// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#create_move_form').on('click', '.btn', function (e) {
        e.preventDefault();
        var form = $('#create_move_form');
        alert('id=0&ratings=&' +form.serialize());
        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            contentType: "application/json; charset=utf-8",
            data: 'id=0&ratings=&'+form.serialize(),
            dataType: "json",
            success: function (result) {
                //alert('Success');// handle success response
            },
            error: function () {
                //alert('Error');// handle error response
            }
        });
    });
    //$("#create_move_form").on("click", ".btn", function (e) {
    //    alert('clicked');
    //    e.preventDefault();
    //    $.ajax({
    //        type: "POST",
    //        url: '@Url.Action("CreateMove", "MovesController")',
    //        contentType: "application/json; charset=utf-8",
    //        data: {
    //            name: "testing",
    //            description: "descrio",
    //            sweatrate: 5
    //        },
    //        dataType: "json",
    //        success: function () { alert('Success'); },
    //        error: function () { alert('Error'); }
    //    });
    //});

});