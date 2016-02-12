angular.module('kost-statestik', ['ng-fusioncharts'])
    .directive('statestik', function () {
        return {
            restrict: 'E',
            templateUrl: '/html/statestik.html',
            controller: function ($scope, $http) {
                $scope.vaegt = null;
                $scope.tilstand = "";
                $scope.personalList = [];
                $scope.totalProtein = 0.0;
                $scope.proteinBehov = 0.0;

                $scope.calcTotalProtein = function () {
                    $scope.totalProtein = 0.0;
                    $scope.personalList.forEach(function (item) {
                        $scope.totalProtein = $scope.calcConsumedProtein(item) + $scope.totalProtein;
                    });
                };

                $scope.calcConsumedProtein = function (item) {
                    return ((item.proteinKilde.protein / 100) * item.maengde);
                };

                $scope.getStatestics = function () {
                    $http.get("/api/proteinIndtag").success(function (data, status, headers, config) {
                        $scope.personalList = data;
                        $scope.calcTotalProtein();
                        $scope.getUser();
                    }).error(function (data, status, headers, config) {

                    });
                };

                $scope.getUser = function () {
                    $http.get("/api/bruger").success(function (data, status, headers, config) {
                        $scope.vaegt = data.vaegt;
                        $scope.tilstand = data.tilstand;
                        $scope.calcProteinNeeds();
                    }).error(function (data, status, headers, config) {

                    });
                };

                $scope.calcProteinNeeds = function() {
                    if ($scope.tilstand === "Voksen") {
                        $scope.proteinBehov = 0.8 * $scope.vaegt;
                    } else if ($scope.tilstand === "Syg") {
                        $scope.proteinBehov = 1.5 * $scope.vaegt;
                    } else if ($scope.tilstand === "Muskel") {
                        $scope.proteinBehov = 2.0 * $scope.vaegt;
                    }
                };

                $scope.hasReached = function() {
                    return $scope.proteinBehov < $scope.totalProtein;
                };

                $scope.myDataSource = {
                    chart: {
                        caption: "Proteinbehov",
                        subcaption: "Daglig",
                        startingangle: "120",
                        showlabels: "0",
                        showlegend: "1",
                        enablemultislicing: "0",
                        slicingdistance: "15",
                        showpercentvalues: "1",
                        showpercentintooltip: "0",
                        plottooltext: "Daglig indtag : $label Daglig behov : $datavalue",
                        theme: "fint"
                    },
                    data: [
                        {
                            label: "Proteinindtag",
                            value: $scope.totalProtein
                        },
                        {
                            label: "Proteinbehov",
                            value: $scope.proteinBehov
                        }
                    ]
                };
            }
        };
    });
