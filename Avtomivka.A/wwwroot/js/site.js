// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('html').ready((e) => {
    $('table').tablesorter()
})

$('.worker-select').change((e) => {
    let workerId = $('.worker-select').val()
    let url = $('#form').data('worker-image')

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

$('.program-select').change((e) => {
    let programId = $('.program-select').val()
    let url = $('#form').data('program-description')

    $.ajax({
        url: url,
        dataType: "json",
        type: "POST",
        data: { id: programId },
        success: function (data) {
            let programDescription = $('.program-description')
            if (data.description) {
                programDescription.show()
                programDescription.val(data.description)
            } else {
                programDescription.hide()
            }
        }
    })
})

$('.search-button').click((e) => {
    let searchValue = $('.search-value').val()
})

