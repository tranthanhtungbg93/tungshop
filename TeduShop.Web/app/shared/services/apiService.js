//<reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {
	app.factory('apiService', apiService);

	apiService.$inject = ['$http', 'notificationService','authenticationService'];
	function apiService($http, notificationService, authenticationService) {
		return {
			get: get,
			post: post,
			put: put,
			del: del
		};

		function del(url, data, success, failed) {
			authenticationService.setHeader();
			$http.delete(url, data).then(function (result) {
				success(result);
			}, function (error) {
				if (error.status === 401) {
					notificationService.displayError('Authenticate is require');
				} else if (failed) {
					failed(error);
				}
				failed(error);
			});
		}

		function put(url, data, success, failed) {
			authenticationService.setHeader();
			$http.put(url, data).then(function (result) {
				success(result);
			}, function (error) {
				if (error.status === 401) {
					notificationService.displayError('Authenticate is require');
				} else if (failed) {
					failed(error);
				}
				failed(error);
			});
		}

		function post(url, data, success, failed) {
			authenticationService.setHeader();
			$http.post(url, data).then(function (result) {
				success(result);
			}, function (error) {
				if (error.status === 401) {
					notificationService.displayError('Authenticate is require');
				} else if (failed) {
					failed(error);
				}
				failed(error);
			});
		}

		function get(url, param, success, failed) {
			authenticationService.setHeader();
			$http.get(url, param).then(function (result) {
				success(result);
			}, function (error) {
				failed(error);
			});
		}
	}
})(angular.module('tedushop.common'));