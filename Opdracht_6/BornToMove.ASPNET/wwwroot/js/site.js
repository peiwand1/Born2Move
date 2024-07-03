// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#create_move_form').on('click', '.btn', function (e) {
        e.preventDefault();
        var form = $('#create_move_form');
        var object = {};
        $.each(form.serializeArray(), function () {
            object[this.name] = this.value;
        });
        var json = JSON.stringify(object);

        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                //alert('Success');// handle success response
            },
            error: function () {
                //alert('Error');// handle error response
            }
        });
    });
});