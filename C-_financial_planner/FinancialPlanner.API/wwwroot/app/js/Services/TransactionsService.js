financialPlannerApp.factory('transactionsService', function ($resource, $log) {
    var resource = $resource('/api/transactions/:id', {id: '@id'});
    return {
        getTransactions: function(){
            return resource.query();
        },

        getTransactionById: function(id){
            return resource.get({id:id});
        }
    }
});