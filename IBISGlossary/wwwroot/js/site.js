// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function loadGlossary() {
    jQuery.support.cors = true;
    $("#tblGlossary").DataTable({
        ajax: {
            url: "/api/Glossary/GetAll",
            dataSrc: "",
            type: 'GET',
            dataType: 'json',
            error: function (e) {
                toastr["error"]("There has been a problem retrieving the information. ", "Error:");
            },
        },
        columns: [
            {
                data: "Term"
            },
            {
                data: "Definition"
            }
        ]
    }
    );
}

function loadGlossaryByParams() {
    if ($.fn.dataTable.isDataTable('#tblGlossary')) {
        $('#tblGlossary').DataTable().destroy();
    }
    jQuery.support.cors = true;
    var Term = $('#txtTerm').val();
    $("#tblGlossary").DataTable({
        ajax: {
            url: "/api/Glossary/GetBySearch?Term=" + Term,
            dataSrc: "",
            type: 'GET',
            dataType: 'json',
            error: function (e) {
                toastr["error"]("There has been a problem retrieving the information. ", "Error:");
            },
            data: {
                Term: Term
            },
        },
        columns: [
            {
                data: "Term"
            },
            {
                data: "Definition"
            }
        ]
    }
    );
}