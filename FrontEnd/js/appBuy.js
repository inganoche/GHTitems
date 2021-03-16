var app = angular.module("appBuy", ["ngRoute"]);


app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "buys.html",
            controller: "Controller"
        })
        .when("/items", {
            templateUrl: "items.html",
            controller: "Controller"
        });
});


app.controller("Controller", function ($scope, $http) {

    var list = this;
    $http.get('https://localhost:5001/api/Items')
        .then(function (response) {
            $scope.list.items = response.data;
        });

    $http.get('https://localhost:5001/api/Buys')
        .then(function (response) {
            $scope.list.buys = response.data;
        });

    list.AddBuys = function () {
        var idItem = list.buy.idItem;
        var quantity = list.buy.quantity;
        list.buy.dateBuy = Date.now();

        if (idItem != "" && quantity != "" && !isNaN(quantity) ) {

            $http({
                url: 'http://localhost:5000/api/Buys',
                method: 'POST',
                data: JSON.stringify(list.buy),
                withCredentials: false,
                headers: { 'Content-Type': 'application/json; charset=utf-8' }
            }).then(function (response) {
                if (response.data) {
                    console.log(response.data);
                    $scope.msg = "Ok!";
                    list.buy.idItem = '';
                    list.buy.quantity = '0';
                    list.buys.push(response.data);
                }

            }, function (response) {
                $scope.msg = "Service not Exists";
                $scope.statusval = response.status;
                $scope.statustext = response.statusText;
                $scope.headers = response.headers();
            });
        }

    }

    list.RemoveItems = function(id)
    {
        $http.delete('https://localhost:5001/api/Buys/' + id)
        .then(function (response) {
            $scope.list.result = response.data;
        });

    }

    list.AddItems = function () {
        var nameItems = list.item.nameItems;
        var unitValue = list.item.unitValue;
        var residue = list.item.residue;
        if (nameItems != "" && unitValue != "" && !isNaN(unitValue) && residue != "" && !isNaN(residue)) {

            $http({
                url: 'http://localhost:5000/api/Items',
                method: 'POST',
                data: JSON.stringify(list.item),
                withCredentials: false,
                headers: { 'Content-Type': 'application/json; charset=utf-8' }
            }).then(function (response) {
                if (response.data) {
                    console.log(response.data);
                    $scope.msg = "Ok!";
                    list.item.nameItems = '';
                    list.item.unitValue = '0';
                    list.item.residue = '0';
                    list.items.push(response.data);
                }

            }, function (response) {
                $scope.msg = "Service not Exists";
                $scope.statusval = response.status;
                $scope.statustext = response.statusText;
                $scope.headers = response.headers();
            });
        }
    }
});





