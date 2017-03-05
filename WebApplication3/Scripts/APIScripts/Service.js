app.service('APIService', function ($http) {
    this.getPets = function () {
        return $http.get("api/Pets");
    };
    
    this.deletePet = function (id) {
        var url = "api/Pets/" + id;
        return $http({
            method: 'delete',
            data: id,
            url: url
        });
    }

    this.getUsers = function () {
        return $http.get("api/Users");
    };
    this.deleteUser = function (id) {
        var url = "api/Users/" + id;
        return $http({
            method: 'delete',
            data: id,
            url: url
        });

    }
})