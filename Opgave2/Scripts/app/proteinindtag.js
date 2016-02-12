angular.module('kost-indtag', [])
    .directive('proteinIndtag', function() {
        return {
            restrict: 'E',
            templateUrl: '/html/protein-indtag.html',
            controller: function($scope, $http) {
                $scope.personalList = [];
                $scope.proteinkilder = [];
                $scope.selectedOption = null;
                $scope.inputGrams = 0.0;
                $scope.totalProtein = 0.0;
                
                $scope.calcTotalProtein = function() {
                    $scope.totalProtein = 0.0;
                    $scope.personalList.forEach(function(item) {
                        $scope.totalProtein = $scope.calcConsumedProtein(item) + $scope.totalProtein;
                    });
                };

                $scope.calcConsumedProtein = function(item) {
                    return ((item.proteinKilde.protein / 100) * item.maengde);
                };

                $scope.clearInput = function() {
                    $scope.selectedOption = null;
                    $scope.inputGrams = 0.0;
                };

                $scope.deleteAll= function() {
                    $http.delete("/api/proteinIndtag").success(function (data, status, headers, config) {
                        $scope.personalList = data;
                        $scope.calcTotalProtein();
                    }).error(function(data, status, headers, config) {

                    });
                };

                $scope.getProteinSources = function () {
                    $http.get("/api/register").success(function (data, status, headers, config) {
                        $scope.proteinkilder = data;
                        $scope.selectedOption = data[0];
                        $scope.getPersonalList();
                    }).error(function (data, status, headers, config) {

                    });
                };

                $scope.getPersonalList = function () {
                    $http.get("/api/proteinIndtag").success(function (data, status, headers, config) {
                        $scope.personalList = data;
                        $scope.calcTotalProtein();
                    }).error(function (data, status, headers, config) {

                    });
                };

                $scope.addFood = function (proteinkildeId, indtagetGram) {
                    $http.post('/api/proteinIndtag', { 'proteinkildeId': proteinkildeId, 'maengde': indtagetGram }).success(function (data, status, headers, config) {
                        $scope.personalList = data;
                        $scope.calcTotalProtein();
                        $scope.clearInput();
                    }).error(function (data, status, headers, config) {
                        console.log('error posting item');
                    });
                };
            }
        };
    });