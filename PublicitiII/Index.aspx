<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>


<html lang="es">

    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta name="author" content="HAA">
        <title>CATÁLGO WEB :: PUBLICITI</title>
        
        <link rel="stylesheet" href="css/normalize.css">
	    <link rel="stylesheet" href="css/foundation.css" />
        <link rel="stylesheet" href="css/publiciti.css" />
        <link rel="stylesheet" type="text/css" href="slick/slick.css"/>
        <link rel="stylesheet" type="text/css" href="fancybox/jquery.fancybox.css?v=2.1.4" media="screen" />
        
        <script src="js/vendor/jquery.js"></script>
        <script src="js/vendor/modernizr.js"></script>
    
    </head>

    <body style="background-color: #000;">
    
            <form id="form1" runat="server">
    
                <div class="row" style="height: 100%;">
        
                    <div class="row" style="margin-top: 10px;">
                        <a href="index.html"><img alt="pub" src="imgs/BotPub01.png" /></a>
                    </div>
    
                    <!--CONTENEDOR BASE-->
                    <div class="row" style="margin-top: 10px;" data-equalizer> <!--border: 12px; border-color: #d90000; border-style: groove; border-radius: 8px;-->
  
                    
                    <!--SECCIÓN IZQUIERDA (BÚSQUEDA / MARQUESINA)-->
                    <div class="medium-3 columns" data-equalizer-watch>
    
                        <div class="row" id="busqCont" style="height: 33%; padding-top: 15px; background-color: #808080; border-radius: 10px; padding-left: 5px; padding-right: 5px;">
    
                            
                            <div style="font-size: 1.4em; font-family: Prototype; text-align: center; padding: 10px; color: #d90000; text-shadow: 0px 2px 1px rgba(255, 255, 255, 1);">
                                BÚSQUEDA
                            </div>     
    
                            <div>
    
                                <div class="medium-10 columns" style="padding-top: 10px;">
                                    <input type="text" id="txtBusqueda" runat="server" style=" border-radius: 8px; height: 28px; width: 95%"> <!--ANCHO en porcentaje-->
                                </div>
    
                                <div id="imgLupa" class="" style="padding-top: 10px;">
                                    
                                    
                              

                                    <input type="image" value="" OnServerClick="btnConsultar_Click" runat="server" src="imgs/Btn_Lup_01.png"/>

                                    
                                    
                                </div>
    
                                <!--hr-->
    
                                <div class="row">
    
                                    <div class="medium-12 columns">
    
                                        <div id="resultado" class="list-group" style="overflow-y: auto; max-height: 300px; margin-top: 10px" >
    
                                            <!--AQUÍ VAN LOS RESULTADOS DE LA CONSULTA:-->

                                            <asp:Literal ID="litEmpresas" runat="server"></asp:Literal>
    
                                        </div>
    
                                    </div>
    
                                </div>
        
    
                            </div>
    
                        </div>
    
                        <div class="row" id="map" style="height: 54.5%; margin-top: 3%; background-color: #fff; border-radius: 10px;">
                        </div>
    
                        <div class="row" style="height: 10%; margin-top: 3%; background-color: #fff; border-radius: 10px;">

                            <div class="marquee" style="max-width: 80%; margin: 0 auto;">
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/bmw.gif"/>
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/mitsubishi.gif"/>
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/subaru.gif"/>
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/infiniti.gif"/>
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/vw.gif"/>
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/seat.gif"/>
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/nissan.gif"/>
                                &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/minicooper.gif"/>
                            </div>

                        </div>
    
                    </div>

    
                    <!--IMAGEN PRINCIPAL (ANUNCIO)-->
    
                    <div class="medium-6 columns" id="principalCont" style="background-image: url('carbono.jpg'); background-position: center;" data-equalizer-watch>
                        <img id="imgPrincipal" src="imgs/bmw/principal.jpg" style="margin-left: 10%; max-width: 80%;" alt="anuncio" ><!--margin-right: 10%;-->>
                    </div>

                    <!--SECCIÓN DERECHA (CARRUSEL / TOP / BOTONERA)-->
                    <div class="medium-3 columns" style="//border: 2px solid #f00;" data-equalizer-watch>

                        <div class="row" id="miniTop" style="height: 35%; border: 2px solid #f00;">
                            <div class="carrusel">
                                <div><img id="img1" src="imgs/cinepolis/01.png" alt="" /></div>
                                <div><img id="img2" src="imgs/cinepolis/02.png" alt="" /></div>
                                <div><img id="img3" src="imgs/cinepolis/03.png" alt="" /></div>
                            </div>
                        </div>
    
                        <div class="row" id="botonera" style="height: 10%; padding-left: 3%; padding-top: 2%; border:  2px solid #0094ff;">
                            <div class="medium-2 columns">
                                <div class="row">
                                    <a id="a1" target="_blank"><img id="1" src="imgs/publiciti/1bn.png" alt="Página" /></a>
                                </div>
                            </div>
                            <div class="medium-2 columns">
                                <div class="row">
                                    <a id="a2" target="_blank"><img id="2" src="imgs/publiciti/2bn.png" alt="Correo" /></a>
                                </div>
                            </div>
                            <div class="medium-2 columns">
                                <div class="row">
                                    <a id="a3" target="_blank"><img id="3" src="imgs/publiciti/3bn.png" alt="Facebook" /></a>
                                </div>
                            </div>
                            <div class="medium-2 columns">
                                <div class="row">
                                    <a id="a4" target="_blank"><img id="4" src="imgs/publiciti/4bn.png" alt="Twitter" /></a>
                                </div>
                            </div>
                            <div class="medium-2 columns">
                                <div class="row">
                                    <a class="" id="a5" data-fancybox-group="gallery" title="01 / 08">
                                        <img id="5" src="imgs/publiciti/5bn.png" alt=""/>
                                    </a>
                                    <a id="pic2" style="display: none;" class="fancybox" href="" data-fancybox-group="gallery" title="02 / 08"></a>
                                    <a id="pic3" style="display: none;" class="fancybox" href="" data-fancybox-group="gallery" title="03 / 08"></a>
                                    <a id="pic4" style="display: none;" class="fancybox" href="" data-fancybox-group="gallery" title="04 / 08"></a>
                                    <a id="pic5" style="display: none;" class="fancybox" href="" data-fancybox-group="gallery" title="05 / 08"></a>
                                    <a id="pic6" style="display: none;" class="fancybox" href="" data-fancybox-group="gallery" title="06 / 08"></a>
                                    <a id="pic7" style="display: none;" class="fancybox" href="" data-fancybox-group="gallery" title="07 / 08"></a>
                                    <a id="pic8" style="display: none;" class="fancybox" href="" data-fancybox-group="gallery" title="08 / 08"></a>
                                </div>
                            </div>
    
                            <div class="medium-2 columns">
                                <div class="row">
                                    <a id="a6" target="_blank"><img id="6" src="imgs/publiciti/6bn.png" alt="Mapa" /></a>    
                                </div>   
                            </div>

                        </div>
    
                        <div class="row" id="clima" style="height: 22%; border: 2px solid #ff0; border-radius: 10px; overflow-y: auto;">
    
                        <!--div id="cont_181665d08dcdbf566208e0f3202cf75e">
    
                            <span id="h_181665d08dcdbf566208e0f3202cf75e"></span>
   
                            <script type="text/javascript" src="http://www.yourweather.co.uk/wid_loader/181665d08dcdbf566208e0f3202cf75e"></script>

                        </div-->
    
                    </div>
    
                    <div class="row" id="divisas" style="height: 21%; margin-top: 1%; border: 2px solid #f0f; border-radius: 10px; overflow-y: auto;">
                        <!--table style="margin: auto;">
                            <tr>
                                <td><img src="imgs/flags/peso.jpg" style="height: 40%;" alt="peso"></td><td id="peso">PESOS</td>
                            </tr>
                            <tr>
                                <td><img src="imgs/flags/dolar.jpg" style="height: 40%;" alt="dolar"></td><td id="dolar"></td>
                            </tr>
                            <tr>
                                <td><img src="imgs/flags/euro.jpg" style="height: 40%;" alt="euro"></td><td id="euro"></td>
                            </tr>
                            <tr>
                                <td><img src="imgs/flags/libra.jpg" style="height: 40%;" alt="libra"></td><td id="libra"></td>
                            </tr>
                            <tr>
                                <td><img src="imgs/flags/yen.jpg" style="height: 40%;" alt="yen"></td><td id="yen"></td>
                            </tr>
                        </table-->
                    </div>
    
                    <div class="row" style="height: 10%; margin-top: 3%; background-color: #fff; border-radius: 10px;">

                        <div class="marquee" style="max-width: 80%; margin: 0 auto;">
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/bancomer.gif"/>
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/axa.gif"/>
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/banamex.gif"/>
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/hsbc.gif"/>
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/banorte.gif"/>
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/santander.gif"/>
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/bajio.gif"/>
                            &nbsp;<img style="max-width: 38%;" alt="central" class="logos" src="imgs/logos/scotia.gif"/>
                        </div>

                    </div>


                </div>
    
            </div>

            <div class="row" id="cintilloCont" style="margin-top: 30px; border-radius: 8px; background-color: #fff; height: 9.1%;">
                <div class="medium-12 columns">
                    <div class="row" id="cintillo">
                        <div class="medium-2 columns" >
                            <img src="imgs/logos/audi1.jpg" alt="" />
                        </div>
                        <div class="medium-2 columns" >
                            <img src="imgs/logos/nextel1.jpg" alt="" />
                        </div>
                        <div class="medium-2 columns" >
                            <img src="imgs/logos/liverpool1.jpg" alt="" />
                        </div>
                        <div class="medium-2 columns" >
                            <img src="imgs/logos/cinepolis1.jpg" alt="" />
                        </div>
                        <div class="medium-2 columns" >
                            <img src="imgs/logos/dhl1.jpg" alt="" />
                        </div>
                        <div class="medium-2 columns" >
                            <img src="imgs/logos/marti1.jpg" alt="" />
                        </div>
                    </div>
                </div>
            </div>


        </div>


    </form>

    <script src="js/vendor/jquery.js"></script>
    <script src="js/foundation.min.js"></script>
    <script type="text/javascript" src="slick/slick.min.js"></script>

    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false&;amp;language=es"></script>
    <script type="text/javascript" src="js/map.js"></script>

    <script type="text/javascript" src="js/detecta.js"></script>
    
    <script type="text/javascript">
        if (BrowserDetect.browser == "Explorer") {
            document.write("<script type='text/javascript' src='js/basicosIE.js' charset='utf-8'><\/script>");
        }
        else {
            document.write("<script type='text/javascript' src='js/basicos.js' charset='utf-8'><\/script>");
        }
    </script>

    <script type="text/javascript" src="fancybox/jquery.fancybox.js?v=2.1.4"></script>

    <script type="text/javascript">
        $(document).ready(function () {
        $('.fancybox').fancybox();
        });
    </script>

    <!--script type="text/javascript">

        function getRate(from, to) {
            var script = document.createElement('script');
            script.setAttribute('src', "http://query.yahooapis.com/v1/public/yql?q=select%20rate%2Cname%20from%20csv%20where%20url%3D'http%3A%2F%2Fdownload.finance.yahoo.com%2Fd%2Fquotes%3Fs%3D" + from + to + "%253DX%26f%3Dl1n'%20and%20columns%3D'rate%2Cname'&format=json&callback=parseExchangeRate");
            document.body.appendChild(script);
            }

        function parseExchangeRate(data) {
            var name = data.query.results.row.name;
            var rate = parseFloat(data.query.results.row.rate, 10);
            //alert("Exchange rate " + name + " is " + rate);
            if (name == 'USD to MXN')
            {
                document.getElementById("dolar").innerHTML = "$ " + rate;
            }
            else if (name == 'EUR to MXN')
            {
                document.getElementById("euro").innerHTML = "$ " + rate;
            }
                else if (name == 'GBP to MXN')
            {
                document.getElementById("libra").innerHTML = "$ " + rate;
            }
            else if (name == 'JPY to MXN')
            {
                document.getElementById("yen").innerHTML = "$ " + rate;
            }
        }

        getRate("USD", "MXN");
        getRate("EUR", "MXN");
        getRate("GBP", "MXN");
        getRate("JPY", "MXN");

    </script-->

    <script>
        $(document).ready(function () {
        iniciaCarr();
        $(document).foundation();
        //document.getElementById("cont_181665d08dcdbf566208e0f3202cf75e").style.margin = 'auto';
        });
    </script>

    </body>

</html>





