var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax":
        {
            "url": "/Customer/Home/GetAll"
        },
        "columns": [
            {
                "data": "imageUrl",
                "render": function (data) {
                    return `<img src="${data}" style="width:50%;"   class="rounded" />`
                },
                "width": "15%"
            },
            { "data": "title", "width": "15%"},
            { "data": "author", "width": "10%" },
            {
                "data": "description",
                "render": function (data) {
                    return `<div style="overflow:auto; height:150px" class="text-secondary">${data}</div>`
                },
                "width": "20%"
            },
            {
                "data": "price",
                "render": function (data) {
                    return `<div>${data} lei</div>`
                },
                "width": "5%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div style="align-text:center">
                        <a href="/Customer/Home/Details?productId=${data}"
                            class="btn btn-secondary">Details</a>
                    </div>`
                    
                },
                "width": "10%"
            }
        ]
    });
}