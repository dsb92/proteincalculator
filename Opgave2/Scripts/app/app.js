angular.module('kost', ['kost-bruger', 'kost-register', 'kost-indtag', 'kost-statestik'])
    .controller('PanelController', function($scope, $http) {
        $scope.tab = 1;

        $scope.selectTab = function(setTab) {
            $scope.tab = setTab;
        };

        $scope.isSelected = function(checkTab) {
            return $scope.tab === checkTab;
        };

    });
    



    
