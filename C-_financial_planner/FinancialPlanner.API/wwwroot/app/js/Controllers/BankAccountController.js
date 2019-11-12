'use strict'

financialPlannerApp.controller('BankAccountController', 
    function bankAccountController($scope, bankAccountService) {

        $scope.displayAccounts = false;
        $scope.getAllAccounts = function getAllAccounts() {
            $scope.bankAccounts = [];
            bankAccountService.getAllAccounts()
                .$promise
                .then(function(bankAccounts) { $scope.bankAccounts = bankAccounts; })
                .catch(function(response) { console.log(response); }
                );
            $scope.displayAccounts = true;
        };
    });