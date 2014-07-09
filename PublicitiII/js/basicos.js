

/*
Autor: HAA
Método que realiza una búsqueda en la base de datos con las palabras clave que el usuario teclea.
Recibe la palabra clave (string) para hacer la búsqueda
*/
function realizaBusqueda(texto){
    //SI EL TEXTO A BUSCAR ES VACÍO, NO MOSTRAR RESULTADOS:
    if (texto == "") {
        document.getElementById("txtBusqueda").placeholder = "Negocio a buscar";
    }
    //DE LO CONTRARIO ENVIAR LA CONSULTA A PHP:
    else {
        //CALZAR ÁREA DE BÚSQUEDA AL TAMÑO DEL CONTENEDOR Y BORRAR MAPA
        document.getElementById("map").style.display = 'none';
        document.getElementById("busqCont").style.height = '89%';

        var parametros = {
            "busqueda": texto,
            "metodo": 0 //0 = OBTENER LISTA DE EMPRESAS.
        };
        $.ajax({
            data: parametros,
            url: 'motorBusqueda.php',
            type: 'post',
            beforeSend: function () {
                $("#resultado").html("Procesando, espere por favor...");
            },
            success: function (response) {
                var unico = response;
                //CHECAR SI EL USUARIO BUSCÓ UNA EMPRESA EN ESPECÍFICO:
                //Dividir el string resultado para obtener info de la búsqueda:
                var partsOfStr = unico.split(',');
                //En a segunda posición se obtiene si el resultado es único:
                var esUnico = partsOfStr[1];
                //Si lo fuera, poblar automáticamente la galería y anuncio principal:
                if (esUnico == "1") {
                    var ruta = "empresas/" + partsOfStr[2];
                    $("#resultado").html(partsOfStr[0]);
                    document.getElementById("imgPrincipal").src = ruta + "/principal.jpg";
                    document.getElementById("img1").src = ruta + "/01.png";
                    document.getElementById("img2").src = ruta + "/02.png";
                    document.getElementById("img3").src = ruta + "/03.png";
                    $('.carrusel').unslick();
                    iniciaCarr(); //-------------------------------------
                    for (n = 3; n < 7; n++) {
                        var link = partsOfStr[n];
                        if (partsOfStr[n] != "") {
                            var x = n - 2;
                            document.getElementById(x).src = "imgs/publiciti/" + x + ".png";
                            document.getElementById("a" + x).href = link;
                        }
                        else {
                            var x = n - 2;
                            document.getElementById(x).src = "imgs/publiciti/" + x + "bn.png";
                            //document.getElementById("a" + x).href = "";
                            document.getElementById("a" + x).removeAttribute('href');
                        }
                    }
                    //FOTOS--------------------
                    if (partsOfStr[10] != 0) {
                        document.getElementById('5').src = "imgs/publiciti/5.png";
                        document.getElementById('a5').href = ruta + "/1.jpg";
                        $("#a5").addClass("fancybox");
                        //document.getElementById('a5').addClass("fancybox");
                        for (y = 2; y < 16; y++) {
                            document.getElementById('pic' + y).href = ruta + "/" + y + ".jpg";
                        }
                    }
                    else {
                        document.getElementById('5').src = "imgs/publiciti/5bn.png";
                        $("#a5").removeClass("fancybox");
                        document.getElementById('a5').removeAttribute('href');
                        //document.getElementById('a5').removeClass("fancybox");
                    }
                    //FOTOS--------------------
                    var lat = partsOfStr[7];
                    var lon = partsOfStr[8];
                    if (lat == "") {
                        document.getElementById('6').src = "imgs/publiciti/6bn.png";
                        //document.getElementById('a6').href = "";
                        document.getElementById('a6').removeAttribute('href');
                    }
                    else {
                        var coordenada = lat + ',' + lon;
                        document.getElementById('6').src = "imgs/publiciti/6.png";
                        document.getElementById('a6').href = "http://www.maps.google.com/?q=" + coordenada;
                    }
                    var vid = partsOfStr[9];
                    if (vid == '') {
                        document.getElementById('7').src = "imgs/publiciti/7bn.png";
                        //document.getElementById('a7').href = "";
                        document.getElementById('a7').removeAttribute('href');
                    }
                    else {
                        document.getElementById('7').src = "imgs/publiciti/7.png";
                        document.getElementById('a7').href = vid;  //ruta + "/video.html";
                    }
                } //if (esUnico)
                //Si no es resultado único, mandar la lista de las empresas:
                else { $("#resultado").html(unico); }
            }
        });
    }//else
}

/*
Método que obtiene las imágenes relacionadas a una empresa buscada, asignando su logo y galería en las secciones correspondientes del documento.
Recibe el objeto (<a></a>) seleccionado para hacer la búsqueda de archivos.
*/
function mostrarInformacion(item)
{
    var myList = document.getElementsByName("lista");
    var cuantos = myList.length;
    for (i = 0; i < cuantos;i++ )
    {
        myList[i].className = "list-group-item";
    }
    item.className = "list-group-item active";
    var parametros = {
                "referencia" : item.innerHTML, //VALOR DEL ELEMENTO DE LA LISTA CLICKEADO.
                "metodo": 1 //1 = OBTENER RUTAS.
        };
        $.ajax({
            data: parametros,
            url: 'motorBusqueda.php',
            type: 'post',
            beforeSend: function () {
                //MOSTRAR IMAGEN DE PRECARGA:
                document.getElementById("imgPrincipal").src = "imgs/precarga.gif";
                document.getElementById("img1").src = "imgs/precarga.gif";
                document.getElementById("img2").src = "imgs/precarga.gif";
                document.getElementById("img3").src = "imgs/precarga.gif";
            },
            success: function (response) {
                var unico = response;
                var partsOfStr2 = unico.split(',');
                var ruta = partsOfStr2[0];
                //POBLAR ANUNCIO PRINCIPAL Y GALERÍA DEL ELEMENTO CLICKEADO:
                document.getElementById("imgPrincipal").src = ruta + "/principal.jpg";
                document.getElementById("img1").src = ruta + "/01.png";
                document.getElementById("img2").src = ruta + "/02.png";
                document.getElementById("img3").src = ruta + "/03.png";
                $('.carrusel').unslick();
                iniciaCarr(); //-------------------------------------
                //ACTIVAR / DESACTIVAR ICONOS DE LA BOTONERA:
                for (i = 1; i < 5; i++) {
                    var link = partsOfStr2[i];
                    if (partsOfStr2[i] != "") {
                        document.getElementById(i).src = "imgs/publiciti/" + i + ".png";
                        document.getElementById("a" + i).href = link;
                    }
                    else {
                        document.getElementById(i).src = "imgs/publiciti/" + i + "bn.png";
                        //document.getElementById("a" + i).href = "";
                        document.getElementById("a" + i).removeAttribute('href');
                    }
                }
                //FOTOS--------------------
                if (partsOfStr2[8] != 0) {
                    document.getElementById('5').src = "imgs/publiciti/5.png";
                    document.getElementById('a5').href = ruta + "/1.jpg";
                    $("#a5").addClass("fancybox");
                    //document.getElementById('a5').addClass("fancybox");
                    for (y = 2; y < 16; y++) {
                        document.getElementById('pic' + y).href = ruta + "/" + y + ".jpg";
                    }
                }
                else {
                    document.getElementById('5').src = "imgs/publiciti/5bn.png";
                    $("#a5").removeClass("fancybox");
                    document.getElementById('a5').removeAttribute('href');
                    //document.getElementById('a5').removeClass("fancybox");
                }
                //FOTOS--------------------
                var lat = partsOfStr2[5];
                var lon = partsOfStr2[6];
                if (lat == "") {
                    document.getElementById('6').src = "imgs/publiciti/6bn.png";
                    //document.getElementById('a6').href = "";
                    document.getElementById('a6').removeAttribute('href');
                }
                else {
                    var coordenada = lat + ',' + lon;
                    document.getElementById('6').src = "imgs/publiciti/6.png";
                    document.getElementById('a6').href = "http://www.maps.google.com/?q=" + coordenada;
                }
                var vid = partsOfStr2[7];
                if (vid == '') {
                    document.getElementById('7').src = "imgs/publiciti/7bn.png";
                    //document.getElementById('a7').href = "";
                    document.getElementById('a7').removeAttribute('href');
                }
                else {
                    document.getElementById('7').src = "imgs/publiciti/7.png";
                    document.getElementById('a7').rel = "shadowbox;width=640;height=480;";
                    document.getElementById('a7').href = vid;
                    Shadowbox.clearCache(); Shadowbox.setup();
                }
            }
        });
}

function iniciaCarr () {
	$('.carrusel').slick({
	  autoplay: true,
      autoplaySpeed: 4000,
      dots: false,
      vertical: false,
      arrows: false
      //centerMode: true,
      //slidesToShow: 1
	});
}

function iniciaTodo() {
    iniciaCarr();
    foundation();
}





    
