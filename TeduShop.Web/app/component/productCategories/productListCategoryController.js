
(function (app) {
	app.controller('productCategoryListController', productCategoryListController);

	productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

	function productCategoryListController($scope, apiService, notificationService) {
		$scope.productCategories = [];
		$scope.getProductCategories = getProductCategories;
		$scope.page = 1;
		$scope.pageSize = 0;
		$scope.keyword = '';

		$scope.search = search;

		function search() {
			$scope.getProductCategories();
		}

		function getProductCategories(page) {
			page = page || 1;
			var config = {
				params: {
					keyword: $scope.keyword,
					page: page,
					pageOfSize: 3
				}
			};

			apiService.get('/api/productCategory/getlist', config, function (result) {
				if (result.data.TotalCount === 0) {
					notificationService.displayWarning('Không tìm sản phẩm nào.');
				} else {
					notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' sản phẩm.');
				}

				$scope.productCategories = result.data.Items;
				$scope.page = result.data.Page;
				$scope.pageSize = result.data.PageSize;
				$scope.totalCount = result.data.TotalCount;
			}, function () {
				console.log('Load list fail');
			});
		}

		$scope.getProductCategories();
	}
})(angular.module('tedushop.productCategories'));