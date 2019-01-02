//<reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http','notificationService'];
	function apiService($http, notificationService) {
        return {
			get: get,
			post: post
        };

		function post(url, data, success, failed) {
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
            $http.get(url, param).then(function (result) {
                success(result);
            }, function (error) {
                failed(error);
            });
        }
    }
})(angular.module('tedushop.common'));