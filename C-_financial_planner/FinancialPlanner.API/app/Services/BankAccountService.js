financialPlannerApp.factory('bankAccountService', function ($resource, $log) {
    var resource = $resource('/api/bankAccounts/:id', {id: '@id'});
    return {
        getAllAccounts: function(){
            return resource.query();
        },

        getAccountById: function(id){
            return resource.get({id:id});
        }
    }
});