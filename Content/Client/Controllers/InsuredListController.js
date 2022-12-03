
app.controller('InsuredListController', ['$scope','coronaManagmentService', function ($scope, coronaManagmentService) {
    coronaManagmentService.getInsurees(getInsureesSuccess);

    function getInsureesSuccess(response) {
        $scope.insurees = response.data;
    }

    $scope.delete = function (id)
    {
        coronaManagmentService.delete(id, deleteSuccess);
    }

    function deleteSuccess(response)
    {
        $scope.insurees = response.data;
        alert("המבוטח נמחק בהצלחה");
    }

    

    function deleteSuccess(response) {
        $scope.insurees = response.data;
        alert("המבוטח נמחק בהצלחה");
    }
}]);