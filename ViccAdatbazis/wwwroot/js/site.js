// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function lajkolas(id) {
    var ajaxKeres = new XMLHttpRequest();

    ajaxKeres.withCredentials = true;

    ajaxKeres.addEventListener("readystatechange", () => {
        if (this.readyState === 4) {
            console.log(this.responseText);
            document.getElementById("tetszikDb").innerHTML = Tetszik();
        }
    })

    ajaxKeres.open("PATCH", "https://localhost:7193/api/NapiVicc")
    ajaxKeres.send();
}