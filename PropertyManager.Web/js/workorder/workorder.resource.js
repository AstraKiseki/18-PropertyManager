angular.module('app').factory('WorkOrderResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/workorders/:workorderId', { workOrderId: '@WorkOrderId' },
    {
        'update': {
            method: 'PUT'
        }
    });
});