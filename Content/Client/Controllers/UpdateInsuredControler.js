app.controller('UpdateInsuredControler', ['$scope', 'coronaManagmentService', function ($scope, coronaManagmentService) {
    const queryString = window.location.search;
    const urlparameters = new URLSearchParams(queryString);
    $scope.id = urlparameters.get("insuredID");
    coronaManagmentService.getInsuredInform($scope.id,getInsureesSuccess);

    $scope.updateInsured = function (insured) {
        coronaManagmentService.update(insured, updateSuccess);
    }

    function addNewVacine() {
        return {
            InsuredID: $scope.id,
            Number: null,
            Company: null,
            ReceivingDate: null,
            type:'new'
        };
    }

    function getInsureesSuccess(response) {
        $scope.insuredinfo = response.data;
        for (var i = 0; i < $scope.insuredinfo.VacinesList.length; i++) {
            $scope.insuredinfo.VacinesList[i].type = "exist";
        }
        FirstName = $scope.insuredinfo.FirstName;
        $scope.insuredinfo.VacinesList.push(addNewVacine());
    }

    $scope.addVacine = function (vacine) {
        coronaManagmentService.addVacine(vacine, addVacineSuccess);
    }

    function addVacineSuccess(response) {
        $scope.insuredinfo.VacinesList = response.data;
        for (var i = 0; i < $scope.insuredinfo.VacinesList.length; i++) {
            $scope.insuredinfo.VacinesList[i].type = "exist";
        }
        $scope.insuredinfo.VacinesList.push(addNewVacine());
        alert("החיסון נוסף בהצלחה");
    }
    function updateSuccess(response) {
        $scope.insurees = response.data;
        alert("העדכון בוצע בהצלחה");
    }

    $scope.companyName = ["פייזר", "מודרנה"];
    $scope.vacineNum = ["1", "2" , "3"];
}]);