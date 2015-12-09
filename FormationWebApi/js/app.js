(function(){
    var app = angular.module('PhonecatApp', [
        'phonecatFilters',
        'phonecatAnimations',
        'ngRoute',
        'PhonecatControllers',
		'PhonecatServices',
        'PhonecatDirectives'
    ]);

    app.config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider.
            when('/phones', {
                templateUrl: 'views/phones.html',
                controller: 'PhoneListController'
            }).
            when('/phone/:phoneId', {
                templateUrl: 'views/phone.html',
                controller: 'PhoneController'
            }).
            when('/phoneform/:phoneId', {
                templateUrl: 'views/phoneform.html',
                controller: 'PhoneController'
            }).
            when('/about', {
                templateUrl: 'views/about.html',
                controller: 'AboutController'
            }).
            otherwise({
                redirectTo: '/phones'
            });
    }]);

})();

