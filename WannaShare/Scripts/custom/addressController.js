(function(){
    angular.module('wannaShareApp').controller('addressController', addressController);

    addressController.$inject = ['$scope', '$http', 'NgMap'];


    function addressController($scope, $http, NgMap) {

        NgMap.getMap().then(function (map) {
            console.log(map.getCenter());
            console.log('markers', map.markers);
            console.log('shapes', map.shapes);
        });

        $scope.center = [32.7766642, -96.79698789999998];
        $scope.latlng = [32.7766642, -96.79698789999998];
        $scope.getpos = function (event) {
            $scope.lat = event.latLng.lat();
            $scope.lng = event.latLng.lng();
            $scope.latlng = [event.latLng.lat(), event.latLng.lng()];
        };

        function getCity(components) {
            var city = 'n/a';
            if (components) {
                for (var c = 0; c < components.length; ++c) {
                    console.log(components[c].types.join('|'))
                    if (components[c].types.indexOf('locality') > -1
                        &&
                        components[c].types.indexOf('political') > -1
                    ) {
                        city = components[c].long_name;
                        break;
                    }
                }
            }
            return city;
        }

        function getState(components) {
            var state = 'n/a';
            if (components) {
                for (var c = 0; c < components.length; ++c) {
                    console.log(components[c].types.join('|'))
                    if (components[c].types.indexOf('administrative_area_level_1') > -1
                        &&
                        components[c].types.indexOf('political') > -1
                    ) {
                        state = components[c].long_name;
                        break;
                    }
                }
            }
            return state;
        }
        function getCountry(components) {
            var country = 'n/a';
            if (components) {
                for (var c = 0; c < components.length; ++c) {
                    console.log(components[c].types.join('|'))
                    if (components[c].types.indexOf('country') > -1
                        &&
                        components[c].types.indexOf('political') > -1
                    ) {
                        country = components[c].long_name;
                        break;
                    }
                }
            }
            return country;
        }

        function getZipCode(components) {
            var zipCode = 'n/a';
            if (components) {
                for (var c = 0; c < components.length; ++c) {
                    console.log(components[c].types.join('|'))
                    if (components[c].types.indexOf('postal_code') > -1
                    ) {
                        zipCode = components[c].long_name;
                        break;
                    }
                }
            }
            return zipCode;
        }

        $scope.placeMarker = function () {
            console.log(this.getPlace());
            var loc = this.getPlace().geometry.location;
            $scope.latlng = [loc.lat(), loc.lng()];
            $scope.center = [loc.lat(), loc.lng()];
            $scope.city = getCity(this.getPlace().address_components);
            $scope.state = getState(this.getPlace().address_components);
            $scope.country = getCountry(this.getPlace().address_components);
            $scope.zipCode = getZipCode(this.getPlace().address_components);
        };

        $scope.googleMapsUrl = "https://maps.googleapis.com/maps/api/js?key=AIzaSyAXMD_tc_2ilRdXhQrQQWP5LIvWj0as7wk&libraries=places";

        //loadMap();
        //function loadMap() {
        //    return $http.get('https://maps.googleapis.com/maps/api/js?key=AIzaSyAmtuY0OJAGSyLV0wY2G7F161QWVxZs6Cw&libraries=places&callback=initializeMap').then(function (results) {
        //        return results;
        //    });
        //}

        $scope.initializeMap = 
        function initializeMap() {
            var mapOptions = {
                center: new google.maps.LatLng(17.385044, 78.486671),
                zoom: 10,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map_canvas"),
              mapOptions);
            // Create the search box and link it to the UI element.
            var input = document.getElementById('pac-input');
            var searchBox = new google.maps.places.SearchBox(input);
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

            // Bias the SearchBox results towards current map's viewport.
            map.addListener('bounds_changed', function () {
                searchBox.setBounds(map.getBounds());
            });

            var markers = [];
            // Listen for the event fired when the user selects a prediction and retrieve
            // more details for that place.
            searchBox.addListener('places_changed', function () {
                var places = searchBox.getPlaces();

                if (places.length == 0) {
                    return;
                }

                // Clear out the old markers.
                markers.forEach(function (marker) {
                    marker.setMap(null);
                });
                markers = [];

                // For each place, get the icon, name and location.
                var bounds = new google.maps.LatLngBounds();
                places.forEach(function (place) {
                    if (!place.geometry) {
                        console.log("Returned place contains no geometry");
                        return;
                    }
                    var icon = {
                        url: place.icon,
                        size: new google.maps.Size(71, 71),
                        origin: new google.maps.Point(0, 0),
                        anchor: new google.maps.Point(17, 34),
                        scaledSize: new google.maps.Size(25, 25)
                    };

                    // Create a marker for each place.
                    markers.push(new google.maps.Marker({
                        map: map,
                        icon: icon,
                        title: place.name,
                        position: place.geometry.location
                    }));

                    if (place.geometry.viewport) {
                        // Only geocodes have viewport.
                        bounds.union(place.geometry.viewport);
                    } else {
                        bounds.extend(place.geometry.location);
                    }
                });
                map.fitBounds(bounds);
            });
        }
    }


    
})();