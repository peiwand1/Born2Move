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
        alert(json);

        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                document.location.href = "/Moves";
            },
            error: function () {
            }
        });
    });

    $('#rate_form').on('click', '.btn', function (e) {
        e.preventDefault();
        var form = $('#rate_form');
        var object = {};
        $.each(form.serializeArray(), function () {
            object[this.name] = this.value;
        });
        var json = JSON.stringify(object);
        //json = json.replace("BornToMove.DAL.Move", "{id=5, name:\"asdg\", description: \"dsgasdgsdag\", sweatrate:4}");
        json = json.replace("BornToMove.DAL.Move", "1");
        alert(json);
        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                //document.location.href = "/Moves";
                alert("suc");
            },
            error: function () {
                alert("err");
            }
        });
    });

    $('[id*="delete-"]').on('click', function (e) {
        e.preventDefault();
        var button = $(this);
        $.ajax({
            type: 'GET',
            url: button.attr('href'),
            success: function (result) {
                document.location.href = "/Moves";
            },
            error: function () {
            }
        });
    })
});