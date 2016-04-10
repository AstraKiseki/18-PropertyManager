angular.module('app').controller('WorkOrderGridController', function ($scope, WorkOrderResource) {
    function activate() {
        $scope.workorders = WorkOrderResource.query();
    }
    activate();
});