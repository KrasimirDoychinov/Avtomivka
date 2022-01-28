﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.worker-select').change((e) => {
    let workerId = $('.worker-select').val()
    let url = $('#form').attr('data-worker-image')

    $.ajax({
        url: url,
        dataType: "json",
        type: "POST",
        data: { id: workerId },
        success: function (data) {
            let workerImage = $('.worker-image')
            if (data.workerImage) {
                workerImage.show()
                workerImage.attr('src', `/Images/${data.workerImage}`)
            } else {
                workerImage.hide()
            }
        }
    })
})