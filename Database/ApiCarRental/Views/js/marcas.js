$(document).ready(function () {
     
     /*
     return false from within a jQuery event handler is effectively the same as calling both 
     e.preventDefault and e.stopPropagation on the passed jQuery.Event object.
     https://stackoverflow.com/questions/1357118/event-preventdefault-vs-return-false
     e.preventDefault() will prevent the default event from occuring, e.stopPropagation() will prevent the event from bubbling up 
     and return false will do both. Note that this behaviour differs from normal (non-jQuery) event handlers, in which, notably, 
     return false does not stop the event from bubbling up.
     return false does e.preventDefault() and e.stopPropagation().
     */
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
    /*
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
    */
    /*
     * https://weblog.west-wind.com/posts/2012/may/08/passing-multiple-post-parameters-to-web-api-controller-methods
     * 
     */
    $('#btnAddMarca').bind("click", GeneralPost);
    function GeneralPost() {
        var nuevaMarca = $('#txtMarcaDenominacion').val();
        console.log("nuevaMarca: ", nuevaMarca);
        //debugger;
        $.ajax({
            type: 'POST',
            url: 'http://localhost:54704/api/marcas/',
            data: JSON.stringify({
                denominacion: nuevaMarca
            }),
            crossDomain: true,
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                console.log("Respuesta: ", data);
                $('#txtMarcaDenominacion').val('');
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log(JSON.stringify(errorThrown) + "\n xhr: " + JSON.stringify(xhr) + "\n textStatus: " + JSON.stringify(textStatus));
            }
        });
    }
    

    $('#btnFindMarcaId').click(function () {
        var idMarca = $('#idMarcaDenominacionBuscar').val();
        var idMarcaInt = parseInt(idMarca);
       // alert("hola"+ idMarca);
        console.log("id de la marca: ");
       // debugger;
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
                   // debugger;
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
