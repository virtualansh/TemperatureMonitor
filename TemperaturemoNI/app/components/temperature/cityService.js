var cityService = function ($http,$q) {
  var cities = [];

  this.getCitiesFromBackend = function () {
      var deferred = $q.defer();

      $http.get("http://localhost:62806/api/cities")
      .success(function (response){
          deferred.resolve(response);
          cities = deferred.promise;
      }).error(function(errror){
          deferred.reject(error);
      })   
      return deferred.promise;
      }
}

app.service('city', cityService);