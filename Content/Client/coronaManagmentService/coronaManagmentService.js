app.service('coronaManagmentService', function ($http) {
    this.getInsurees = function (success) {
        
        $http({
            method: "POST",
            url: "/Home/GetInsurees",
            dataType: 'json',
            data: null,
            headers: { "Content-Type": "application/json" },
            
        })
        .then(function onSuccess(response) {
            success(response);
         }).catch(function onError(response) {
             alert("onError");
      });

    }

    this.getInsuredInform = function (id, success) {

        $http({
            method: "POST",
            url: "/Home/getInsuredInform",
            dataType: 'json',
            data: { id: id },
            headers: { "Content-Type": "application/json" },

        })
            .then(function onSuccess(response) {
                success(response);
            }).catch(function onError(response) {
                alert("onError");
            });

    }

    this.delete = function (id,success) {

        
        $http({
            method: "POST",
            url: "/Home/Delete",
            dataType: 'json',
            data: { id: id},
            headers: { "Content-Type": "application/json" },

        })
            .then(function onSuccess(response) {
                success(response);
            }).catch(function onError(response) {
                alert("אירעה שגיאה בתהליך");
            });

    }

    this.AddInsured = function (request, success) {
        $http({
            method: "POST",
            url: "/Home/AddInsured",
            dataType: 'json',
            data: { insured: request },
            headers: { "Content-Type": "application/json" },

        })
            .then(function onSuccess(response) {
                success(response);
            }).catch(function onError(response) {
                alert("אירעה שגיאה בתהליך");
            });

    }

    this.update = function (insured, success) {
        $http({
            method: "POST",
            url: "/Home/updateInsured",
            dataType: 'json',
            data: { insured: insured },
            headers: { "Content-Type": "application/json" },

        })
            .then(function onSuccess(response) {
                success(response);
            }).catch(function onError(response) {
                alert("אירעה שגיאה בתהליך");
            });

    }
    this.addVacine = function (vacine, success) {
        $http({
            method: "POST",
            url: "/Home/AddVacine",
            dataType: 'json',
            data: { vacine: vacine },
            headers: { "Content-Type": "application/json" },

        })
            .then(function onSuccess(response) {
                success(response);
            }).catch(function onError(response) {
                alert("אירעה שגיאה בתהליך");
            });

    }
});

