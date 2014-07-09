window.onload = function(){
    var options = {
        zoom: 15
        , center: new google.maps.LatLng(21.154372, -101.697542)
        , mapTypeId: google.maps.MapTypeId.MAP
        , scaleControl: true
        , scrollwheel: false
        , streetViewControl: false
    };
    var map = new google.maps.Map(document.getElementById('map'), options);

    var marker = new google.maps.Marker({
        position: map.getCenter()
        , map: map
        , title: 'Haz click'
        , icon: 'imgs/marker.png'
        , cursor: 'default'
        , draggable: false
    });

    var popup = new google.maps.InfoWindow({
        content: 'EUROMOTORS LEÓN<br /><a href="company-page.html">Ir al sitio</a>'
        , position: map.getCenter()
    });
 
    google.maps.event.addListener(marker, 'click', function(){
        popup.open(map, marker);
    });
};