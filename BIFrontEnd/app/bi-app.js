angular.module('bi-app', ['ngRoute', 'ui.bootstrap']).
    config(function ($routeProvider, $locationProvider) {
        $routeProvider.

            //CORE ROUTING
        when('/graficos', { templateUrl: 'BI/FaturamentoIvel/views/faturamentoIvel.html' }).
            otherwise({ redirectTo: '/index', templateUrl: 'BI/FaturamentoIvel/views/faturamentoIvel.html' });

    }).

controller("MainController", MainController);

MainController.$inject = ["$scope"];

function MainController($scope) {


}
