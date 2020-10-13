
financialPlannerApp.controller('TransactionController',
    function TransactionController($scope, transactionsService, bankAccountService, timesAndDatesService, $window) {

        $scope.displayTransactions = false;
        let allTransactions = [];
        let allBankAccountsById = new Map();
        $scope.transactionsToDisplay = []
        $scope.bankAccountNames = [];
        $scope.showNewTransactionForm = false;
        $scope.addedTransactions = [];
        $scope.saveButton = false;
        
        
        function initPageData() {
            getBankAccountsById();
        }
        initPageData();
        
        function getBankAccountsById () {
            let allBankAccounts = [];
            bankAccountService.getAllAccounts()
            .$promise
                .then(function(bankAccounts) {allBankAccounts = bankAccounts
                    for (let i = 0; i < allBankAccounts.length; i++){
                        let account = allBankAccounts[i];
                        allBankAccountsById.set(account.id,account);
                        $scope.bankAccountNames.push(account.accountName)
                    }
                    getAllTransactions();
                })
                .catch(function(response) { console.log(response); }
                );
        } 

       function getAllTransactions() {
            transactionsService.getTransactions()
            .$promise
            .then(function populate(transactions) { 
                allTransactions = transactions;
                allTransactions.forEach(i => {
                    let key = i.bankAccountId;
                    i.$accountName = allBankAccountsById.get(key).accountName;
                    i.$displayDate = timesAndDatesService.getDisplayDateFromIsoOffset(i.dateAndTime);
                    i.$displayTime = timesAndDatesService.getDisplayTimeFromIsoOffset(i.dateAndTime);
                })
            })
            .catch(function(response) { console.log(response); }
            );
        }
        
        $scope.displayAllTransactions = function displayAllTransactions(){
            $scope.transactionsToDisplay = allTransactions;
            $scope.displayTransactions = true;
        }

        $scope.getSingleTransactionById  = function getSingleTransactionById(transactionIdToSearch) {
            $scope.transactionsToDisplay = [];
            const transaction = allTransactions.find(i => i.id === transactionIdToSearch);
            $scope.transactionsToDisplay.push(transaction);
            $scope.displayTransactions = true;
        };
        
        $scope.addNewTransaction = function addNewTransaction(){
            $scope.transactionToAdd = {};
            $scope.showNewTransactionForm = true;
        }
        
        function getBankAccountIdFromName(accountName){
            let keys = allBankAccountsById.keys();
            for (let key of keys){
                if (allBankAccountsById.get(key).accountName === accountName) {
                    return allBankAccountsById.get(key).id;
                }
            }
        }
        
        $scope.createTransaction = function createTransaction() {
            $scope.transactionToAdd.bankAccountId = getBankAccountIdFromName($scope.transactionToAdd.$accountName);
            const dateTime = new Date();
            $scope.transactionToAdd.dateAndTime = timesAndDatesService.getDateInStandardTimezone(dateTime);
            $scope.addedTransactions.push($scope.transactionToAdd);
            $scope.transactionToAdd = {};
            $scope.showNewTransactionForm = false;
        }
        
        $scope.saveChanges = function saveChanges(){
            transactionsService.saveTransactions($scope.addedTransactions)
                .$promise
                .then(function success(response) { 
                    console.log($scope.addedTransactions.length + " new transaction(s) added");
                    $window.location.reload();
                })
                .catch(function(response) { console.log(response); }
                );
        }
    }

);
