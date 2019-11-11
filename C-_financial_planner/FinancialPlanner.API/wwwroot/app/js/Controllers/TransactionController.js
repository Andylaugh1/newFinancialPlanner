'use strict';

financialPlannerApp.controller('TransactionController',
    function TransactionController($scope, transactionsService) {

        $scope.displayTransactions = false;
        $scope.transactionIdToSearch = null;
        $scope.transactions = [];

        $scope.getAllTransactions = function getAllTransactions() {
            $scope.transactions = [];
            transactionsService.getTransactions()
            .$promise
            .then(function(transactions) { $scope.transactions = transactions; })
            .catch(function(response) { console.log(response); }
            );
            $scope.displayTransactions = true;
        };

        $scope.getSingleTransactionById  = function getSingleTransactionById() {
            $scope.transactions = [];
            transactionsService.getTransactionById($scope.transactionIdToSearch)
            .$promise
            .then(function(transaction) { $scope.transactions.push(transaction); })
            .catch(function(response) { console.log(response); }
            );
            $scope.displayTransactions = true;
            console.log($scope.transactions);
        };
        console.log($scope);
    }

);
