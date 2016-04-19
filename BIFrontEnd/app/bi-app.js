angular.module('bi-app', ['ngRoute', 'ui.bootstrap', 'ngToast', 'ngCookies', 'ng-sweet-alert', 'angularMoment', 'ngTable', 'treeGrid', 'ngTagsInput', 'ngHandsontable']).
    config(function ($routeProvider, $locationProvider) {
        $routeProvider.

            //CORE ROUTING
        when('/index', { templateUrl:'core/views/login.html' }).
            otherwise({ redirectTo: '/index', templateUrl: '~/index.html' });

    }).

controller("MainController", MainController);

MainController.$inject = ["$scope"];

function MainController($scope) {


}
;