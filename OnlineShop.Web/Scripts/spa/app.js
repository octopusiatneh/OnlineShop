/// <reference path="../plugins/angular/angular.js" />

//how to use module

var myApp = angular.module('myModule', []);

//how to use Controller & Scope

myApp.controller("myController", myController);
myApp.controller("schoolController", schoolController);
myApp.controller("studentController", studentController);
myApp.controller("teacherController", teacherController);
myApp.controller("houseController", houseController);
myApp.controller("peopleController", peopleController);
//declare

function myController($scope) {
    $scope.message = "Math first grade";
} 

//Scope lồng nhau
function schoolController($scope) {
    $scope.message = "Announcement from school";
} 

function studentController($scope) {
    $scope.message = "This is message from student";
} 
function teacherController($scope) {
    $scope.message = "This is message from teacher";
} 
//rootScope
function houseController($rootScope,$scope) {
    $rootScope.message = "From house";
}

function peopleController($scope) {
   // $scope.message = "This is message from people";
} 



