﻿$(document).ready(function () {
    $('#MenuItems').DataTable({
        "ajax": {
            "url": "/api/MenuItem",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": " 25%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "foodType.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div>
                                <a href="/Admin/MenuItems/Upsert?id=${data}" class="btn btn-success text-white mx-2">
                                    <i class="bi bi-pencil-square"></i> 
                                </a>
                                <a href="/Admin/MenuItems/Upsert?id=${data}" class="btn btn-danger text-white mx-2">
                                    <i class="bi bi-trash-fill"></i> 
                                </a>
                            </div>`
                },
                "width": "15%"
            }
        ],
        "width": "100%"
    });
});