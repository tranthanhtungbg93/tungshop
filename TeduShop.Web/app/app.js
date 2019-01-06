/// 

(function () {
	angular.module('tedushop', ['tedushop.product', 'tedushop.common', 'tedushop.productCategories']).config(config);
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
})();