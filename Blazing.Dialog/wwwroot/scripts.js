

window.bsModal = {

    show: function (id) {
        $('#' + id).modal('show');
    },

    hide: function (id) {
        $('#' + id).modal('hide');
    }
};

$(document).on("hidden.bs.modal", ".modal", function () {
    DotNet.invokeMethodAsync("Blazing.Dialog", "ShutBlazingDialog", $(this).attr("id"));
});
