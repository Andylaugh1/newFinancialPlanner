financialPlannerApp.factory('transactionsService', function ($http, $log) {
    return {
        getTransactions: function(successCB){
            $http({method: 'GET', url: '/api/transactions'}).
            success(function (data, status, headers, config) {
                successCB(data);
            }).
            error(function (data, status, headers, config) {
                $log.warn(data, status, headers(), config);
            });
        },

        // getTransactionById: function(id, successCB){
        //     $http({method: 'GET', url: '/api/transactions/' + id}).
        //     success(function (data, status, headers, config) {
        //         successCB(data);
        //     }).
        //     error(function (data, status, headers, config) {
        //         $log.warn(data, status, headers(), config);
        //     });
        // }
    }
});