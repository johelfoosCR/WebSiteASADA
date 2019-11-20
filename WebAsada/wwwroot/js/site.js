$(document).ready(function () {

    $('select:not(.swal2-select)').selectpicker();

    $.fn.serializeObjectIntoJson = function () {
        // var $form = $("#IdForm");
        // var jsonData = $form.serializeObjectIntoJson();

        var o = {};
        var a = this.serializeArray();
        console.log(a);

        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            }
            else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };  

    executeWhitConfirmation = function (route, icon,message,data, callback) {
        Swal.fire({
            title: "Confirmación",
            text: message,
            icon: icon,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí!'
        }).then((result) => {
            if (result.value) {
                $.post(route, data).done(function (response) {
                    callback(response);
                });
            }
        });
    };

});

function showSuccessMessage() {
    Swal.fire(
        'Acción Exitosa',
        'Registro Procesado Satisfactoriamente!!',
        'success'
    );
}

function showDeleteMessage() {
    Swal.fire(
        'Acción Exitosa',
        'Registro Eliminado Satisfactoriamente!!',
        'info'
    );
} 

function showUpdateMessage() {
    Swal.fire(
        'Acción Exitosa!',
        'Registro Actualizado Satisfactoriamente!!',
        'success'
    );
}
