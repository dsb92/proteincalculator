angular.module('kost-register', [])
    .directive('register', function() {
        return {
            restrict: 'E',
            templateUrl: '/html/register.html',
            controller: function($scope, $http) {
                $scope.proteinkilder = [];

                $scope.showAll = function() {
                    $http.get("/api/register").success(function(data, status, headers, config) {
                        $scope.proteinkilder = data;
                    }).error(function(data, status, headers, config) {

                    });
                };
            }
        };
    });
