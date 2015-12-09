var phonecatServices = angular.module('PhonecatServices', ['ngResource']);

phonecatServices.factory('Phone', ['$resource',
  function($resource){
      return $resource('http://localhost:64760/api/;phoneId', {}, {
      query: {method:'GET', params:{phoneId:'phones'}, isArray:true}
    });
}]);

phonecatServices.factory('Counter', function() {
	var s = {};              
	var i = 0;
             
	s.count = function() {
		i++;
	};
	
	s.getCount = function() {
		return i;
	}
                    
    return s;
});

phonecatServices.value('User', {
	user: {
		firstname: 'Cyril',
		lastname: 'Vincent',
    },
	role: 'admin'
});

var basket = function() {
	this.phones = [];
	
	this.add = function(p) {
		this.phones.push(p);
	}
	
	this.count = function() {
		return this.phones.length;
	}
}

phonecatServices.service('Basket',[basket]);


