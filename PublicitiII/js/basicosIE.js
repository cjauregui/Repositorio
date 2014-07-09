

/*
Autor: HAA
Método que realiza una búsqueda en la base de datos con las palabras clave que el usuario teclea.
Recibe la palabra clave (string) para hacer la búsqueda
*/
function realizaBusqueda(texto){
        var parametros = "busqueda=" +texto+ "&metodo=0";
        var xdr = new XDomainRequest();
        //xdr.contentType = "text/plain";
        xdr.open("post", "motorBusquedaIE.php");
        xdr.onload = function () {
        //parse response as JSON
        var unico = xdr.responseText;

        processData(unico);
        };
        xdr.send(parametros);
        };

        function processData(variable) {
            var partsOfStr = variable.split(',');
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
                           //document.getElementById("a" + x).href = "#";
                        }
                    }
                    document.getElementById('5').src = "imgs/publiciti/5.png";
                    document.getElementById('a5').href = ruta + "/1.jpg";
                    for (y = 2; y < 6; y++) {
                        document.getElementById('pic' + y).href = ruta + "/" + y + ".jpg";
                    }
                    var lat = partsOfStr[7];
                    var lon = partsOfStr[8];
                    if (lat == "") {
                        document.getElementById('6').src = "imgs/publiciti/6bn.png";
                        //document.getElementById('a6').href = "#";
                    }
                    else {
                        var coordenada = lat + ',' + lon;
                        document.getElementById('6').src = "imgs/publiciti/6.png";
                        document.getElementById('a6').href = "http://www.maps.google.com/?q=" + coordenada;
                    }
                    var vid = partsOfStr[9];
                    if (vid == '') {
                        document.getElementById('7').src = "imgs/publiciti/7bn.png";
                        //document.getElementById('a7').href = "#";
                    }
                    else {
                        document.getElementById('7').src = "imgs/publiciti/7.png";
                        document.getElementById('a7').href = ruta + "/video.html";
                    }
                } //if (esUnico)
                //Si no es resultado único, mandar la lista de las empresas:
                else { $("#resultado").html(variable); }
        }


        function mostrarInformacion(item) {
            var myList = document.getElementsByName("lista");
    var cuantos = myList.length;
    for (i = 0; i < cuantos;i++ )
    {
        myList[i].className = "list-group-item";
    }
    item.className = "list-group-item active";
            var parametros2 = "referencia=" + item.innerHTML + "&metodo=1";
            var xdr = new XDomainRequest();
            //xdr.contentType = "text/plain";
            xdr.open("post", "motorBusquedaIE.php");
            xdr.onload = function () {
                //parse response as JSON
                var unico = xdr.responseText;

                processData2(unico);
            };
            xdr.send(parametros2);

            function processData2(variable) {
                var unico = variable;
                var partsOfStr2 = unico.split(',');
                var ruta = partsOfStr2[0];
                debugger;
                //POBLAR ANUNCIO PRINCIPAL Y GALERÍA DEL ELEMENTO CLICKEADO:
                document.getElementById("imgPrincipal").src = ruta + "/principal.jpg";
                document.getElementById("img1").src = ruta + "/01.png";
                document.getElementById("img2").src = ruta + "/02.png";
                document.getElementById("img3").src = ruta + "/03.png";
                document.getElementById("img4").src = ruta + "/04.png";
                //ACTIVAR / DESACTIVAR ICONOS DE LA BOTONERA:
                for (i = 1; i < 5; i++) {
                    var link = partsOfStr2[i];
                    if (partsOfStr2[i] != "") {
                        document.getElementById(i).src = "imgs/publiciti/" + i + ".png";
                        document.getElementById("a" + i).href = link;
                    }
                    else {
                        document.getElementById(i).src = "imgs/publiciti/" + i + "bn.png";
                        //document.getElementById("a" + i).href = "#";
                    }
                }
                document.getElementById('5').src = "imgs/publiciti/5.png";
                document.getElementById('a5').href = ruta + "/1.jpg";

                for (y = 2; y < 6; y++) {
                    document.getElementById('pic' + y).href = ruta + "/" + y + ".jpg";
                }
                var lat = partsOfStr2[5];
                var lon = partsOfStr2[6];
                if (lat == "") {
                    document.getElementById('6').src = "imgs/publiciti/6bn.png";
                    //document.getElementById('a6').href = "#";
                }
                else {
                    var coordenada = lat + ',' + lon;
                    document.getElementById('6').src = "imgs/publiciti/6.png";
                    document.getElementById('a6').href = "http://www.maps.google.com/?q=" + coordenada;
                }
                var vid = partsOfStr2[7];
                if (vid == '') {
                    document.getElementById('7').src = "imgs/publiciti/7bn.png";
                    //document.getElementById('a7').href = "#";
                }
                else {
                    document.getElementById('7').src = "imgs/publiciti/7.png";
                    document.getElementById('a7').href = ruta + "/video.html";
                    Shadowbox.clearCache(); Shadowbox.setup(); 
                }
            }
        }