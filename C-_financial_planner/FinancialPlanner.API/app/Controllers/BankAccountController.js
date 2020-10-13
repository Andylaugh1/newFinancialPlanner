'use strict'

financialPlannerApp.controller('BankAccountController', 
    function bankAccountController($scope, bankAccountService) {

        $scope.displayAccounts = false;
        $scope.bankAccounts = [];
        $scope.displayAllAccounts = function displayAllAccounts() {
            $scope.displayAccounts = true;
        };
        
        function getAllBankAccounts(){
            bankAccountService.getAllAccounts()
                .$promise
                .then(function(bankAccounts) { $scope.bankAccounts = bankAccounts })
                .catch(function(response) { console.log(response); }
                );
        }
        
        function loadPage() {
            getAllBankAccounts();
        }
        
        loadPage();
    });