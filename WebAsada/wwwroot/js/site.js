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

    executeWhitConfirmation = function (route, icon,message,data, callback, callbackError) {
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
                doPost(route, data, callback, callbackError);
            }
        });
    };   

    doPost = function (route, data, callback, callbackError) {
        $.post(route, data).done(function (result) {
            if (result.hasError) {
                Swal.fire({
                    title: "Error",
                    text: result.message,
                    icon: "error"
                })
            }
            else {
                callback(result);
            }
        }).fail(function (result) { 
            callbackError(result);
        })
    };  

    //doPost = function (route, datatosend, callback) {
    //    $.ajax({
    //        type: "POST", // perform POST request
    //        url: route, 
    //        data: JSON.stringify(datatosend), // serialize your data into JSON
    //        contentType: 'application/json; charset=utf-8',
    //        dataType: 'json',
    //        success: function (dataas) {
    //            callback(dataas);
    //        },
    //        error: function () {
    //            alert("failure");
    //        }
    //    });
    // };   
   


});


function showVerificationMessage(icon, message, callback) {
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
            callback(result);
        }
    });
}

function showSuccessMessage() {
    Swal.fire(
        'Acción Exitosa',
        'Registro Procesado Satisfactoriamente!!',
        'success'
    );
}
function showInformationMessage(message) {
    Swal.fire(
        'Información',
         message,
        'info'
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
