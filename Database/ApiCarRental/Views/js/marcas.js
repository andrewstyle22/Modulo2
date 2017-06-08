$(document).ready(function () {
    //coloco esto para que cuando ejecute cada botón no se ejecute todos los form a la vez
    $("form").submit(function (e) {
        e.preventDefault();
    });
    function GetMarcas() {
        var urlAPI = 'http://localhost:54704/api/marcas';
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
    
    $('#btnAddMarca').click(function () {
      //  debugger;
        var nuevaMarca = $('#txtMarcaDenominacion').val();
        var urlAPI = 'http://localhost:54704/api/marcas';
        var data = {
            id: 0,
            denominacion: nuevaMarca
        };
       // debugger;
        $.ajax({
            url: urlAPI,
            type: "post",
            data: JSON.stringify({
                id: 0,
                denominacion: nuevaMarca
            }),
            //data: {
            //    id: 0,
            //    denominacion: nuevamarca
            //},
            contenttype: "application/json"
        });
        //$.post(urlAPI, data, function (result) {
        //    debugger;
        //    $("span").html(result);
        //});


    });
    

    $('#btnFindMarcaId').click(function () {
        var idMarca = $('#idMarcaDenominacionBuscar').val();
        var idMarcaInt = parseInt(idMarca);
       // alert("hola"+ idMarca);
        console.log("id de la marca: ");
        debugger;
        var urlAPI = 'http://localhost:54704/api/marcas/'+idMarcaInt;
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
                    debugger;
                });
            }
        });

    });

    $('#btnCargarCoches').click(function () {
        var urlAPI = 'http://localhost:54704/api/marcas';
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
    });
});