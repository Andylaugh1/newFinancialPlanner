financialPlannerApp.factory('transactionsService', function ($resource, $log) {
    var resource = $resource('/api/transactions/:id', {id: '@id'}, {
        save: {method: 'POST', url: '/api/transactions', isArray: true}});
    return {
        getTransactions: function(){
            return resource.query();
        },

        getTransactionById: function(id){
            return resource.get({id:id});
        },

        saveTransactions: function(transactionsToSave){
            return resource.save({}, transactionsToSave)
        }
    }
});