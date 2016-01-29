'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers', [])
    .controller('CustomerAPI', function ($scope, $http, $filter) {
        var controllerURI = '/Result/Customers';
        $scope.fetchID = '';
        $scope.getID = '';
        $scope.deleteID = '';
        $scope.updateID = '';
        $scope.addID = '';
        $scope.action = '';

        $scope.keyEnter = function (event) {
            if (event.which == 13) {
                fetch();
            }
        };

        $scope.getAPI = function () {
            $scope.fetchID = $scope.getID;
            fetch();
            $scope.action = 'G';
        };

        $scope.updateAPI = function (id) {
            if (id > 0) {
                $scope.fetchID = id;
                fetch();
            }
            else {

                $scope.details = [{ "CustomerID": 0, "Email": "", "Password": "tempPwd"}];
            }
            $scope.action = 'U';
        };

        $scope.saveAPI = function (customerID) {
            addUpdate(customerID);
        };

        $scope.deleteAPI = function () {
            remove();
            $scope.action = 'D';
        };

        function fetch() {
            $scope.details = "";
            $scope.Message = "";
            var uri = controllerURI + '/Get';
            if ($scope.fetchID.length > 0)
                uri = uri + '/' + $scope.fetchID;

            $http.get(uri).success(function (response) {
                if (response.ResultSet && response.ResultSet.length > 0)
                    $scope.details = response.ResultSet;
                else {
                    $scope.details = "";
                    $scope.Message = "No results found.";
                }
                //alert($scope.details[0]);
            }).
              error(function (data, status, headers, config) {
                  alert("Error");
              });

        }

        function remove() {
            $scope.details = "";
            $scope.Message = "";
            if ($scope.deleteID.length > 0) {
                var uri = controllerURI + '/Delete/' + $scope.deleteID;


                $http.delete(uri).success(function (response) {
                    $scope.action = 'G';
                    if (response.ResultSet && response.ResultSet.length > 0)
                        $scope.Message = ' Record deleted ID:' + response.ResultSet;
                    else
                        $scope.Message = "No Record Deleted";
                    //alert($scope.details[0]);
                }).
                  error(function (data, status, headers, config) {
                      alert("Error");
                  });
            }
            else
                alert("Please enter id");

        }


        function addUpdate(customerID) {
            $scope.Message = "";
            var myRedObjects = $filter('filter')($scope.details, { CustomerID: customerID });

            $scope.details = "";
            var uri = controllerURI + '/Post';
            if ($scope.updateID.length > 0)
                uri = uri + '/' + customerID;

            $http.post(uri + '/?id=' + customerID, myRedObjects[0]).success(function (response) {
                $scope.action = 'G';
                $scope.Message = response.Description;
                //alert(response.Description);
            }).
              error(function (data, status, headers, config) {
                  alert("Error");
              });

        }
    })

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = '3D Cart';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /about
    .controller('CustomerCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = '3D Cart | Customer';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /login
    .controller('LoginCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = '3D Cart | Sign In';
        // TODO: Authorize a user
        $scope.login = function () {
            $location.path('/');
            return false;
        };
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);