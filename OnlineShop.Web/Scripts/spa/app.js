/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module('myModule', []);

myApp.controller ("myController", myController);

myController.$inject = ['$scope'];
//declare
function myController($scope) {
    $scope.message = "Math first grade";
} 

