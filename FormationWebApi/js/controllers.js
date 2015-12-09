var rest = "phones/";

(function () {
    var app = angular.module('PhonecatControllers', []);

    app.controller('PhoneController', ['Phone', '$routeParams', function (Phone, $routeParams) {
        this.phone = {};

        this.setImage = function (imageUrl) {
            this.mainImageUrl = imageUrl;
        }
		
        this.email = "contact@cyrilvincent.com";
        this.postPhone = function (c) {
            alert(c.email + " post the phone " + c.phone.name + " (" + c.phone.id + ")\nIl ne reste qu'à poster le c.phone sur le serveur");
        }

		var c = this;
        Phone.get({phoneId: $routeParams.phoneId}, function(p) {
			c.phone = p;
			c.mainImageUrl = p.images[0];
		});

    }]);

    app.controller('PhoneListController', ['Phone', function (Phone) {
        this.phones = Phone.query();
        this.orderProp = 'age';
        this.query = '';
    }]);

    app.controller('AboutController', ['Counter', function (Counter) {
        this.email = "contact@cyrilvincent.com";
        this.web = "www.cyrilvincent.com";
		Counter.count();
		this.count = Counter.getCount();
	}]);

})();
