// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
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