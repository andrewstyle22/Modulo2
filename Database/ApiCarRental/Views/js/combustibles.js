$(document).ready(function () {
    function GetTipoCombustible() {
        var urlAPI = 'http://localhost:54704/api/tipocombustible';

        $.get(urlAPI, function (respuesta, estado) {

            // console.log(respuesta);
            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR

                var relleno = '';

                $.each(respuesta.data, function (indice, elemento) {

                    relleno = '<ul>';
                    relleno += '    <li>';
                    relleno += elemento.denominacion;
                    relleno += '    </li>';
                    relleno += '</ul>';

                    $('#resultados').append(relleno);
                });
            }
        });
    }

    $('#btnAddTipoCombustible').click(function () {
        debugger;
        var nuevaTipoCombustible = $('#txtTipoCombustible').val();
        var urlAPI = 'http://localhost:54704/api/tipocombustible';
        var data = {
            id: 0,
            denominacion: nuevaTipoCombustible
        };
        debugger;
        $.ajax({
            url: urlapi,
            type: "post",
            data: JSON.stringify({
                id: 0,
                denominacion: nuevaTipoCombustible
            }),
            //data: {
            //    id: 0,
            //    denominacion: nuevamarca
            //},
            contenttype: "application/json",
            complete: function (respuesta, estado) {
                debugger;
                console.log(respuesta);
            }
        });
        //$.post(urlAPI, data, function (result) {
        //    debugger;
        //    $("span").html(result);
        //});


    });

    GetTipoCombustible();
});