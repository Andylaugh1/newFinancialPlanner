'use strict';

financialPlannerApp.controller('MainController',
    function MainController($scope) {

        $scope.display = 'This seems to be working, which is incredible!!';

        $scope.gotToTransactionsPage = function gotToTransactionsPage(){
            console.log("this is working");
            window.location = "/TransactionPage.html"
        }
    }
);