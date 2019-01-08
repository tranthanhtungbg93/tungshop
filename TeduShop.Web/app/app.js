/// 

(function () {
	angular.module('tedushop', ['tedushop.product',
		'tedushop.common',
		'tedushop.productCategories'])
		.config(config)
		.config(configAuthentication);
	config.$inject = ['$stateProvider', '$urlRouterProvider'];

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('base', {
			url: '',
			templateUrl: "/app/baseView/baseView.html",
			abstract: true
		}).state('login', {
			url: "/login",
			templateUrl: "/app/component/login/login.html",
			controller: "loginController"
		}).state('home', {
			url: "/home/index",
			parent: 'base',
			templateUrl: "/app/component/home/home.html",
			controller: "homeController"
		});
		$urlRouterProvider.otherwise('/login');
	}

	function configAuthentication($httpProvider) {
		$httpProvider.interceptors.push(function ($q, $location) {
			return {
				request: function (config) {

					return config;
				},
				requestError: function (rejection) {

					return $q.reject(rejection);
				},
				response: function (response) {
					if (response.status === "401") {
						$location.path('/login');
					}
					//the same response/modified/or a new one need to be returned.
					return response;
				},
				responseError: function (rejection) {

					if (rejection.status === "401") {
						$location.path('/login');
					}
					return $q.reject(rejection);
				}
			};
		});
	}
})();