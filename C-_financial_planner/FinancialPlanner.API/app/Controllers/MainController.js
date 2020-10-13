'use strict';

financialPlannerApp.controller('MainController',
    function MainController($scope) {

        $scope.display = 'Welcome to your Financial planner!!';

        $scope.gotToTransactionsPage = function gotToTransactionsPage(){
            console.log("this is working");
            window.location = "/Views/TransactionPage.html"
        }
        
        $scope.gotToBankAccountsPage = function gotToBankAccountsPage(){
            window.location = "/Views/BankAccountPage.html"
        }
    }
);