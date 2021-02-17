// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    $("input[type=radio]").click(function (event) {
        var valor = $(event.target).val();
        if (valor == "credit") {
            $("#cash-form").hide();
            $("#bankTransfer-form").hide();
            $("#credit-form").show();
        } else if (valor == "bankTransfer") {
            $("#credit-form").hide();
            $("#cash-form").hide();
            $("#bankTransfer-form").show();
        } else if (valor == "cash") {
            $("#credit-form").hide();
            $("#bankTransfer-form").hide();
            $("#cash-form").show();
        } else {
            // Otra cosa
        }
    });
});
