(function (app) {
	app.controller('rootController', rootController);

	rootController.$inject = ['$scope', '$state', 'authData', 'authenticationService', 'loginService'];

	function rootController($scope, $state, authData, authenticationService, loginService) {
		$scope.logOut = function () {
			loginService.logOut();
			$state.go('login');
		};
		$scope.authentication = authData.authenticationData;
		authenticationService.validateRequest();
	}
})(angular.module('tedushop'));