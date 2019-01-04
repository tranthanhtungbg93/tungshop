(function (app) {
	app.controller('productAddController', productAddController);

	productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

	function productAddController(apiService, $scope, notificationService, $state, commonService) {
		$scope.product = {
			CreateDate: new Date(),
			Status: true
		};
		$scope.ckeditorOption = {
			language: 'vi',
			heght: '200px'
		};

		$scope.productCategories = [];
		$scope.AddProduct = AddProduct;
		$scope.GetSeoTitle = GetSeoTitle;

		function GetSeoTitle() {
			$scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
		}

		function AddProduct() {
			apiService.post('/api/product/create', $scope.product, function (result) {
				notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
				$state.go('product_list');
			}, function (error) {
				notificationService.displayError('Thêm mới sản phẩm không thành công.');
			});
		}

		function loadproductCategories() {
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

		loadproductCategories();
	}
})(angular.module('tedushop.product'));