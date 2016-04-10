angular.module('app').controller('WorkOrderDetailController', function ($scope, $stateParams, WorkOrderResource) {
    $scope.workorder = WorkOrderResource.get({ workorderId: $stateParams.id });

    $scope.saveWorkOrder = function () {
        $scope.workorder.$update(function () {
            alert('save successful');
        });
    };
});