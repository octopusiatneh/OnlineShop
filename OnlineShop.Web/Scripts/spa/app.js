﻿/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module('myModule', []);

myApp.controller("schoolController", schoolController);
myApp.service('Validator', Validator);

schoolController.$inject = ['$scope', 'Validator'];

function schoolController($scope, Validator) {
    $scope.checkNumber = function(){
        $scope.message = Validator.checkNumber($scope.num);
    }
   
}
function Validator($window) {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0)
            return 'this is even';
        else {
            return 'this is odd';
        }
            }
}


