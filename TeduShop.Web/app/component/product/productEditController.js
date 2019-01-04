(function (app) {
	app.controller('productEditController', productEditController);

	productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

	function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
		$scope.product = {
			CreateDate: new Date(),
			Status: true
		};

		$scope.ckeditorOption = {
			language: 'vi',
			heght: '200px'
		};

		$scope.productCategories = [];
		$scope.UpdateProduct= UpdateProduct;
		$scope.GetSeoTitle = GetSeoTitle;

		function GetSeoTitle() {
			$scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
		}

		function loadDetailProductCategory() {
			console.log($stateParams.id);
			apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
				$scope.product = result.data;
			}, function (error) {
				notificationService.displayError(error.data);
			});
		}

		function UpdateProduct() {
			apiService.put('/api/product/update', $scope.product, function (result) {
				notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công.');
				$state.go('product_list');
			}, function (error) {
				notificationService.displayError('Sản phẩm cập nhật không thành công.');
			});
		}

		function loadProductCategory() {
			apiService.get('/api/product/loadListDanhMuc', null, function (result) {
				$scope.productCategories = result.data;
			}, function () {
				console.log('load fail list parent');
			});
		}

		$scope.ChooseImage = function () {
			var finder = new CKFinder();
			finder.selectActionFunction = function (urlFile) {
				$scope.product.Image = urlFile;
			};
			finder.popup();
		};

		loadProductCategory();
		loadDetailProductCategory();
    }
})(angular.module('tedushop.product'));