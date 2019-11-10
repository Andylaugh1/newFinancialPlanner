'use strict';

financialPlannerApp.controller('TransactionController',
    function TransactionController($scope, transactionsService) {

        $scope.displayAllTransactions = false;
        $scope.transactionIdToSearch = null;
        $scope.transactions = [];

        $scope.showAllTransactions = function showAllTransactions() {
            transactionsService.getTransactions(function(transactions) {
                $scope.transactions = transactions;
                $scope.displayTransactions = true;
            });
        }

        $scope.findTransactionById  = function findTransactionById(transactionIdToSearch) {
            transactionsService.getTransactionById(transactionIdToSearch, function(transaction) {
                $scope.transactions = transaction;
                $scope.displayTransactions = true;
            });
            console.log($scope.transactions);
        }
        
    }
);