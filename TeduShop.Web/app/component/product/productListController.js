(function (app) {
	app.controller('productListController', productListController);

	productListController.$inject = ['$scope', 'apiService', 'notificationService', '$filter'];

	function productListController($scope, apiService, notificationService, $filter) {
		$scope.products = [];
		$scope.getProducts = getProducts;
		$scope.page = 1;
		$scope.pageSize = 0;
		$scope.keyword = '';

		$scope.search = search;
		$scope.DeleteProduct = DeleteProduct;

		$scope.checkAll = checkAll;
		$scope.isAll = false;

		$scope.deleteMulti = deleteMulti;

		function deleteMulti() {
			var listId = [];
			$.each($scope.selected, function (i, item) {
				listId.push(item.ID);
			});
			var config = {
				params: {
					checkedProducts: JSON.stringify(listId) // tên biến trong params phải giống với input dưới API
				}
			};
			apiService.del('/api/product/deleteMulti', config, function (result) {
				notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
				search();
			}, function (error) {
				notificationService.displayError('Xóa không thành công.');
			});
		}

		function checkAll() {
			if ($scope.isAll === false) {
				angular.forEach($scope.products, function (item) {
					item.checked = true;
				});
				$scope.isAll = true;
			} else {
				angular.forEach($scope.products, function (item) {
					item.checked = false;
				});
				$scope.isAll = false;
			}
		}
		// kiểm tra item được checked thì enable button xóa 
		$scope.$watch("products", function (n, o) {
			var checked = $filter("filter")(n, { checked: true });
			if (checked.length) {
				$scope.selected = checked;
				$('#btnDelete').removeAttr('disabled');
			} else {
				$('#btnDelete').attr('disabled', 'disabled');
			}
		}, true);

		function DeleteProduct(id) {
			var config = {
				params: {
					id: id
				}
			};

			apiService.del('/api/product/delete', config, function (result) {
				notificationService.displaySuccess('Xóa sản phẩm thành công.');
				search();
			}, function (error) {
				notificationService.displayError('Xóa không thành công.');
			});
		}

		function search() {
			$scope.getProducts();
		}

		function getProducts(page) {
			page = page || 1;
			var config = {
				params: {
					keyword: $scope.keyword,
					page: page,
					pageOfSize: 3
				}
			};

			apiService.get('/api/product/getList', config, function (result) {
				if (result.data.TotalCount === 0) {
					notificationService.displayWarning('Không tìm sản phẩm nào.');
				}

				$scope.products = result.data.Items;
				$scope.page = result.data.Page;
				$scope.pageSize = result.data.PageSize;
				$scope.totalCount = result.data.TotalCount;
			}, function () {
				console.log('Load list fail');
			});
		}

		$scope.getProducts();
    }
})(angular.module('tedushop.product'));