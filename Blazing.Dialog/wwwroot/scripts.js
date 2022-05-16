

window.bsModal = {

    show: function (id) {
        //var element = document.getElementById(id);
        //var modal = new bootstrap.Modal(document.getElementById(id), {});
        //modal.show();
        //$('#' + id).modal('show');
        getBootstrapModal(id).show();
    },

    hide: function (id) {
        //var modal = new bootstrap.Modal(document.getElementById(id), {});
        //modal.show();
        //$('#' + id).modal('hide');
        getBootstrapModal(id).hide();
    }
};

function getBootstrapModal(id)
{
    console.log(id);
    var element = document.getElementById(id);
    console.log(element);
    var modal = new bootstrap.Modal(element, {});
    return modal;
}

//$(document).on("hidden.bs.modal", ".modal", function () {
//    DotNet.invokeMethodAsync("Blazing.Dialog", "ShutBlazingDialog", $(this).attr("id"));
//});

