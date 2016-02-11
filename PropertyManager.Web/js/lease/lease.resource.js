angular.module('app').factory('LeaseResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/Leases/:leaseId', { leaseId: '@LeaseId' },
    {
        'update': {
            method: 'PUT'
        }
    });
});