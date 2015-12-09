(function () {
    var app = angular.module('PhonecatDirectives', []);
    app.directive('phoneItem', function () {
        return {
            restrict: 'E',
            templateUrl: 'views/phoneitemdirective.html'
        }
    });
	
	app.directive('phoneAddtobasket', ['$rootScope', 'Basket', function ($rootScope, Basket) {
        return {
            restrict: 'E',
            templateUrl: 'views/addtobasketdirective.html',
			controller: function() {
				this.addToBasket = function (phone) {
					Basket.add(phone);
					toast("Phone succesfully added to the basket");
					$rootScope.$broadcast('addToBasket');
				}
			},
			controllerAs: 'atb'
        }
    }]);
	
	app.directive('phoneBasketCount', ['$rootScope', 'Basket', function ($rootScope, Basket) {
        return {
            restrict: 'A',
            templateUrl: 'views/basketcountdirective.html',
			controller: function() {
				this.basketCount = Basket.count();
				var that = this;
				$rootScope.$on('addToBasket', function() {
					that.basketCount = Basket.count();
				});
			},
			controllerAs: 'bc'
        }
    }]);

})();