app.controller('AddInsuredController', ['$scope','coronaManagmentService', function ($scope, coronaManagmentService) {
   
    $scope.AddInsured = function (firstName, lastName, id, address, birth, tel, phone)
    {
        var request = {
            FirstName: firstName,
            LastName: lastName,
            InsuredID: id,
            Addres: address,
            BirthDate: birth,
            Tel: tel,
            Phone: phone
        }
        coronaManagmentService.AddInsured(request, AddSuccess);
    }

    function AddSuccess(response) {
        $scope.insurees = response.data;
        alert("המבוטח נוסף בהצלחה");
        location.href = "/Home/Home";
    }

}]);