(function (app) {
	app.controller('productCategoryUpdateController', productCategoryUpdateController);

	productCategoryUpdateController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

	function productCategoryUpdateController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
		$scope.productCategory = {
			CreateDate: new Date(),
			Status: true
		};
		$scope.parentCategories = [];
		$scope.UpdateProductCategory = UpdateProductCategory;
		$scope.GetSeoTitle = GetSeoTitle;

		function GetSeoTitle() {
			$scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
		}

		function loadDetailProductCategory() {
			apiService.get('/api/productCategory/getbyid/' + $stateParams.id, null, function (result) {
				$scope.productCategory = result.data;
			}, function (error) {
				notificationService.displayError(error.data);
			});
		}

		function UpdateProductCategory() {
			apiService.put('/api/productCategory/update', $scope.productCategory, function (result) {
				notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công.');
				$state.go('product_list_category');
			}, function (error) {
				notificationService.displayError('Sản phẩm cập nhật không thành công.');
			});
		}

		function loadProductCategory() {
			apiService.get('/api/productCategory/loadListDanhMuc', null, function (result) {
				$scope.parentCategories = result.data;
			}, function () {
				console.log('load fail list parent');
			});
		}

		loadProductCategory();
		loadDetailProductCategory();
	}
})(angular.module('tedushop.productCategories'));