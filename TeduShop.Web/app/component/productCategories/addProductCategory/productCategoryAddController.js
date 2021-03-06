﻿(function (app) {
	app.controller('productCategoryAddController', productCategoryAddController);

	productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

	function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
		$scope.productCategory = {
			CreateDate: new Date(),
			Status: true
		};
		$scope.parentCategories = [];
		$scope.AddProductCategory = AddProductCategory;
		$scope.GetSeoTitle = GetSeoTitle;

		function GetSeoTitle() {
			$scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
		}

		function AddProductCategory() {
			apiService.post('/api/productCategory/create', $scope.productCategory, function (result) {
				notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
				$state.go('product_list_category');
			}, function (error) {
				notificationService.displayError('Thêm mới sản phẩm không thành công.');
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
	}
})(angular.module('tedushop.productCategories'));