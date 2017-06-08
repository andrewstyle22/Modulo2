$(document).ready(function () {
    $("form").submit(function (e) {
        e.preventDefault();
    });

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

    $('#btnAddCombustible').click(function () {
        var nuevaCombustible = $('#txtComustibleDenominacion').val();
        var urlAPI = 'http://localhost:54704/api/tipocombustible';
        var dataNuevoCombustible = {
            id: 0,
            denominacion: nuevaCombustible
        };

        $.ajax({
            url: urlAPI,
            type: "POST",
            dataType: 'json',
            data: dataNuevoCombustible,
            success: function (data, textStatus, xhr) {
                //debugger;
                console.log("Data: " + JSON.stringify(data) + "\nXHR: " + JSON.stringify(xhr) + "\ntextStatus: " + JSON.stringify(textStatus));
                alert("Combustible " + data.datos + " insertada");
                $('#txtComustibleDenominacion').val('');
                GetTipoCombustible();
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(JSON.stringify(errorThrown) + "\n xhr: " + JSON.stringify(xhr) + "\n textStatus: " + JSON.stringify(textStatus));
            }
        });
    });

    $('#btnFindTipoCombustibleId').click(function () {
        var idTipoCombustible = $('#txtTipoCombustible').val();
        var idTipoCombustibleInt = parseInt(idTipoCombustible);
        // debugger;
        var urlAPI = 'http://localhost:54704/api/tipocombustible/' + idTipoCombustibleInt;
        $.get(urlAPI, function (respuesta, estado) {

            $('#resultados2').html('');
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

                    $('#resultados2').append(relleno);
                    // debugger;
                });
            }
        });
    });

    GetTipoCombustible();
});