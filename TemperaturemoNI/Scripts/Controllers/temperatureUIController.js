var temperatureUIController = function ($scope, $http) {
    //$scope.cities = [
    //    //{ id: '1', name: 'Jani', country: 'Norway' },
    //    //{ id: '2', name: 'Hege', country: 'Sweden' },
    //    //{ id: '3', name: 'Kai', country: 'Denmark' }
    //];

    var getCitiesFromBackend = function () {
        $http.get("http://localhost:62806/api/cities")
        .success(function (response) {
            $scope.cities = response;
            console.log(response);
            $scope.somethingHere = $scope.cities[0];
        });
    }

    $scope.hello = "hello";

    $scope.addedCities = [];



    $scope.addCity = function (city) {
        console.log(city);
        $scope.addedCities.push(city);
    }
    $scope.deleteCity = function (city) {
        for (var i = 0; i <   $scope.addedCities.length; i++) {
            if ($scope.addedCities[i].Name === city) {
                $scope.addedCities.splice(i, 1);
                break;
            }
        }
    }
    
    getCitiesFromBackend();
}

angular.module('temperatureApp', [])
       .controller('temperatureUIController', temperatureUIController);



