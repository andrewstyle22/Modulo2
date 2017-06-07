$(document).ready(function () {
    function GetCoches() {
        var urlAPI = 'http://localhost:54704/api/coches';

        $.get(urlAPI, function (respuesta, estado) {

            // console.log(respuesta);
            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR

                var relleno = '';

                $.each(respuesta.data, function (indice, elemento) {

                    relleno = '<ul>';
                    relleno += '    <li>id: ';
                    relleno += elemento.id;
                    relleno += '    </li>';
                    relleno += '    <li>Matrícula: ';
                    relleno += elemento.matricula;
                    relleno += '    </li>';
                    relleno += '    <li>Color: ';
                    relleno += elemento.color;
                    relleno += '    </li>';
                    relleno += '    <li>Cilindrada: ';
                    relleno += elemento.cilindrada;
                    relleno += '    </li>';
                    relleno += '    <li>Número de Plazas: ';
                    relleno += elemento.nPlazas;
                    relleno += '    </li>';
                    relleno += '    <li>Fecha de matriculación: ';
                    relleno += elemento.fechaMatriculacion;
                    relleno += '    </li>';
                    relleno += '     <li>Datos de la marca<ul>';
                    relleno += '    <li>Id: ';
                    relleno += elemento.marca.id;
                    relleno += '    </li>';
                    relleno += '    <li>Denominación: ';
                    relleno += elemento.marca.denominacion;
                    relleno += '    </li></ul></li>';
                    relleno += '     <li>Tipo de Combustible<ul>';
                    relleno += '    <li>ID: ';
                    relleno += elemento.tipoCombustible.id;
                    relleno += '    </li>';
                    relleno += '    <li>Denominación: ';
                    relleno += elemento.tipoCombustible.denominacion;
                    relleno += '    </li></ul></li>';
                    relleno += '</ul>';

                    $('#resultados').append(relleno);
                });
            }
        });
    }
     
    $('#btnAddCoche').click(function () {
        //debugger;
        var nuevoCoche = $('#txtCocheMarcaDenominacion').val();
        var urlAPI = 'http://localhost:54704/api/coches';
        var data = {
            id: 0,
            denominacion: nuevoCoche
        };
        //debugger;
        $.ajax({
            url: urlapi,
            type: "post",
            data: JSON.stringify({
                id: 0,
                denominacion: nuevoCoche
            }),
            //data: {
            //    id: 0,
            //    denominacion: nuevamarca
            //},
            contenttype: "application/json",
            complete: function (respuesta, estado) {
                //debugger;
                console.log(respuesta);
            }
        });
        //$.post(urlAPI, data, function (result) {
        //    debugger;
        //    $("span").html(result);
        //});


    });

    GetCoches();
});