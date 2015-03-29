var monitoredCityService = function ($http,$q) {

    var monitoredCities = [];

    this.getTemperatureFromBackend = function (city) {
        var deferred = $q.defer();
        $http.get("http://localhost:62806/api/temperature?cityID=" + city)
       .success(function (response) {
           deferred.resolve(response);
          monitoredCities.push(deferred.promise);
           console.log("Recieved Temperature " + monitoredCity.temperature.toString());
       })
       .error(function () {
           deferred.reject("Error");
       }
       )
        return deferred.promise;
    }

    this.addCityToBackend = function (city) {
        var deferred = $q.defer();
        var request = {
            Id: city.Id,
            Name: city.Name
        }        
        $http.post(" http://localhost:62806/api/temperature ", JSON.stringify(request), {
            headers: {
                'Content-Type': 'application/json'
            }
        }).success(function (response) {
            deferred.resolve(response);
            monitoredCities.push(deferred.promise);
        })
        .error(function (error) {
            deferred.reject(error);
        }
        )
        return deferred.promise;
    }

    this.deleteCityFromBackend = function (nonMonitoredCity) {
        var deferred = $q.defer();
        var request = {
                Id: nonMonitoredCity.Id,
                CityId: nonMonitoredCity.CityId,
                Name: nonMonitoredCity.Name,
                SensingPeriod: nonMonitoredCity.SensingPeriod,
                LatestTemperature: nonMonitoredCity.LatestTemperature
        }
        var config = {
            params: request
        };
        $http.post(" http://localhost:62806/api/temperature/delete ", config, {
            headers: {
                'Content-Type': 'application/json'
            }}).
        success(function (response) {
            
            for(i=0; i <= monitoredCities.length; i++)
            {
                if (monitoredCities[i].Id === nonMonitoredCity.Id) {
                    monitoredCities.splice(i, 1);
                    deferred.resolve(monitoredCities);
                    break;
                }
            }
        }).
        error(function (error) {
            console.log("inside delete service error");
            deferred.reject(error);
        });
        return deferred.promise;
    }

    this.updateTemperature = function () {
        var deferred = $q.defer();
        $http.get("http://localhost:62806/api/temperature?cityID")
        .success(function (response) {
            deferred.resolve(response);
            monitoredCities = deferred.promise;    
        })
        .error(function () {
            deferred.reject("Error");
        }
        )
        return deferred.promise;
    }
   
}

app.service('monitoredCity', monitoredCityService);
