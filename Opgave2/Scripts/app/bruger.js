angular.module('kost-bruger', [])
    .directive('brugerData', function() {
        return {
            restrict: 'E',
            templateUrl: '/html/bruger-data.html',
            controller: function($scope, $http) {
                $scope.brugerId = "";
                $scope.vaegt = null;
                $scope.tilstand = "";
                $scope.hasProfile = false;
                $scope.dataSaved = false;

                $scope.getUser = function() {
                    $http.get("/api/bruger").success(function(data, status, headers, config) {
                        $scope.brugerId = data.brugerId;
                        $scope.vaegt = data.vaegt;
                        $scope.tilstand = data.tilstand;
                        $scope.hasProfile = data.hasProfile;

                    }).error(function(data, status, headers, config) {

                    });
                };

                $scope.sendUser = function(brugerId, vaegt, tilstand) {
                    $http.post('/api/bruger', { 'brugerId': brugerId, 'vaegt': vaegt, 'tilstand': tilstand }).success(function(data, status, headers, config) {
                        $scope.hasProfile = (data === true);

                    }).error(function(data, status, headers, config) {

                    });
                };
            }
        };
    });