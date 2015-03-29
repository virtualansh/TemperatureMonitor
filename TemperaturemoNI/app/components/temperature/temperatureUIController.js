var temperatureUIController = function ($scope, $interval,orderByFilter, monitoredCity, city){

    $scope.cities = [];
    $scope.monitoredCities = [];

     $scope.addCity = function (newMonitoredCity) {
        console.log("inside add city");
        console.log($scope.newCity);
         monitoredCity.addCityToBackend(newMonitoredCity)
        .then(function (response) {
            console.log("after adding");
            console.log(response);
            $scope.monitoredCities.push(response);
            for (var i = 0; i < $scope.cities.length; i++) {
                if ($scope.cities[i].Name === newMonitoredCity.Name) {
                    $scope.cities.splice(i, 1);
                    $scope.newCity = $scope.cities[0];
                    break;
                }
            }
        }, function (error) {
           console.log(error);
        });
  
    }

     $scope.deleteCity = function (nonMonitoredCity) {
       monitoredCity.deleteCityFromBackend(nonMonitoredCity)
         .then(function (response) {
             console.log("after deleting");
             console.log(response);
             $scope.monitoredCities = response;
             $scope.cities.push(nonMonitoredCity);
             $scope.cities = orderByFilter($scope.cities, 'Name');
             $scope.newCity = $scope.cities[0];
         }, function (error) {
             console.log(error);
         });    
    }
    
    var getAllCities = function () {
        city.getCitiesFromBackend()
        .then(function (response) {
            console.log("on return");
            console.log(response);
            $scope.cities = response;
            $scope.newCity = $scope.cities[0];
        }, function (error) {
            console.log(error);
        });  
    }

    getAllCities();

    //$interval(function () {    
    //   $scope.monitoredCities = monitoredCity.updateTemperature();
    //}, 60000);
}

app.controller('temperature', temperatureUIController);



