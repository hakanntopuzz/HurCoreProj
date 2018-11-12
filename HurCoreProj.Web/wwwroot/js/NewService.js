angular.module('HurCore', [])
    .controller('NewsController', function ($scope, $http) {
        $http.get('http://localhost:64932/api/contents'). //
            then(function (response) {
                $scope.news = response.data;
            });
    });