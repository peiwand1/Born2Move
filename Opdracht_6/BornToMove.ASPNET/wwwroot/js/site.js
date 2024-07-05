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
        var moverating = {};
        var move = {};

        $.each(form.serializeArray(), function () {
            if (this.name.startsWith("move.")) {
                let temp = this.name.replace("move.", '')
                move[temp] = this.value;
            }
            else {
                moverating[this.name] = this.value;
            }
        });
        moverating["move"] = move;
        var json = JSON.stringify(moverating);
        alert(json);

        // TODO fix error:
        // alles lijkt te functioneren (rating wordt toegevoegd), maar ik krijg een grote error
        //An unhandled exception has occurred while executing the request.
        //    System.Text.Json.JsonException: A possible object cycle was detected.This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
        //    Consider using ReferenceHandler.Preserve on JsonSerializerOptions to support cycles.Path: $.move.ratings.move.ratings.move.ratings.move.ratings.move.ratings.move.ratings.move.ratings.move.ratings.move.ratings.move.ratings.move.id.
        // at System.Text.Json.ThrowHelper.ThrowJsonException_SerializerCycleDetected(Int32 maxDepth)

        //sample json:
        //{ "rating": "4", "intensity": "4", "move": { "id": "8", "name": "sdga", "description": "gregre", "sweatrate": "7" } }

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