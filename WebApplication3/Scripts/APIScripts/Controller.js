app.controller('APIController', function ($scope, $filter, $http, APIService) {
    GetPets();
    GetUsers();
    $scope.petsFiltered = 0;

    function GetPets() {
        var getData = APIService.getPets();
        getData.then(function (d) {
            $scope.pets = d.data;
            $scope.counted = $scope.pets.length;
            $scope.totalPetsCount = $scope.petsFiltered;
            $scope.PerPagePetsItems = 3;
            $scope.PetsCurrentPage = 1;

        }, function (err) {
            console.log(err);
        })
    };

    function GetUsers() {
        var getData = APIService.getUsers();
        getData.then(function (d) {
            $scope.users = d.data;
            $scope.totalUserCount = $scope.users.length;
            $scope.PerPageUserItems = 3;
            $scope.UserCurrentPage = 1;

        }, function (err) {
            console.log(err);
        })
    };


    $scope.numberOfPagesUsers = function () {
        return Math.ceil($scope.totalUserCount / $scope.PerPageUserItems);
    } 

    $scope.numberOfPagesPets = function () {
        return Math.ceil($scope.petsFiltered / $scope.PerPagePetsItems);
    } 

    $scope.deletePet = function (id) {
        APIService.deletePet(id);
        location.reload();
    }

    $scope.addPet = function () {
        $http.post('/api/Pets', $scope.model).then(
            function (successResponse) {
                GetPets();
                $scope.model = {};
                console.log('success');
            },
            function (errorResponse) {
                // handle errors here
            });
    };

    $scope.addOwner = function () {
        $http.post('/api/Users', $scope.model).then(
            function (successResponse) {
                GetUsers();
                $scope.model = {};
                console.log('success');
            },
            function (errorResponse) {
                // handle errors here
            });
    };

    $scope.deleteOwner = function (id) {
        APIService.deleteUser(id);
        location.reload();
    }
})

app.filter('Pagestart', function () {
    return function (input, start) {
        if (!input || !input.length) { return; }
        start = +start; //parse to int
        return input.slice(start);
    }
});    