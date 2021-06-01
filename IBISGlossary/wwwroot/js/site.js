// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
var dataTable;

// Write your JavaScript code.
function loadGlossary() {
    jQuery.support.cors = true;
    dataTable = $("#tblGlossary").DataTable({
        ajax: {
            url: "/api/Glossary/GetAll",
            type: 'GET',
            dataType: 'json',
            error: function (e) {
                toastr["error"]("There has been a problem retrieving the information. ", "Error:");
            },
        },
        columns: [
            {
                data: "term", "width": "25%"
            },
            {
                data: "definition", "width": "50%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Glossary/upsert/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;"> 
                            <i class="far fa-edit"></i> Edit
                            </a>
                            &nbsp;
                            <a onclick=Delete("/api/Glossary/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;"> 
                            <i class="far fa-trash-alt"></i> Delete
                            </a>
                            </div>`
                }, "width": "25%"
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
    dataTable = $("#tblGlossary").DataTable({
        ajax: {
            url: "/api/Glossary/GetBySearch?Term=" + Term,
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
                data: "term", "width": "25%"
            },
            {
                data: "definition", "width": "50%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="/Glossary/upsert/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;"> 
                            <i class="far fa-edit"></i> Edit
                            </a>
                            &nbsp;
                            <a onclick=Delete("/api/Glossary/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;"> 
                            <i class="far fa-trash-alt"></i> Delete
                            </a>
                            </div>`
                }, "width": "25%"
            }
        ]
    }
    );
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: "DELETE",
            url: url,
            dataType: 'json',
            success: function (data) {
                if (data.success) {
                    ShowMessage(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.error);
                }
            }
        });
    }
    )
}

function ShowMessage(msg) {
    toastr.success(msg);
}