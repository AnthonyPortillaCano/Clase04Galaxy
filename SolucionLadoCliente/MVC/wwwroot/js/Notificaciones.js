$.notifyDefaults({
    element: 'body',
    type: 'info',
    allow_dismiss: true,
    placement: {
        from: "bottom",
        align: "right"
    },
    //timer: 5000,
    offset: 20,
    spacing: 5,
    showProgressbar: false,
    mouse_over: 'pause',
    z_index: 1060,
    animate: {
        enter: 'animated fadeInUp',
        exit: 'animated fadeOutDown'
    }
});

function notificacionExito(mensaje, url) {
    var msj = mensaje == undefined
        ? 'Operación exitosa'
        : mensaje;

    $.notify({
        icon: 'fa fa-check',
        message: msj,
        url: url
    }, {
            type: 'success'
        });
}

function notificacionError(mensaje) {
    var msj = mensaje == undefined
        ? 'Operación erronea'
        : mensaje;

    $.notify({
        icon: 'fa fa-exclamation',
        message: msj
    }, {
            type: 'danger'
        });
}

function notificacionInfo(mensaje) {
    var msj = mensaje == undefined
        ? 'Información'
        : mensaje;

    $.notify({
        icon: 'fa fa-info',
        message: msj
    });
}

function notificacionAlerta(mensaje) {
    var msj = mensaje == undefined
        ? 'Alerta'
        : mensaje;

    $.notify({
        icon: 'fa fa-warning',
        message: msj
    }, {
            type: 'warning'
        });
}
