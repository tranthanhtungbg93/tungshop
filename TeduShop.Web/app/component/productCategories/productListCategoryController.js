
(function (app) {
	app.controller('productCategoryListController', productCategoryListController);

	productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$filter'];

	function productCategoryListController($scope, apiService, notificationService, $filter) {
		$scope.productCategories = [];
		$scope.getProductCategories = getProductCategories;
		$scope.page = 1;
		$scope.pageSize = 0;
		$scope.keyword = '';

		$scope.search = search;
		$scope.DeleteProductCategory = DeleteProductCategory;

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
					checkedProductCategories: JSON.stringify(listId) // tên biến trong params phải giống với input dưới API
				}
			};
			apiService.del('/api/productCategory/deleteMulti', config, function (result) {
				notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
				search();
			}, function (error) {
				notificationService.displayError('Xóa không thành công.');
			});
		}

		function checkAll() {
			if ($scope.isAll === false) {
				angular.forEach($scope.productCategories, function (item) {
					item.checked = true;
				});
				$scope.isAll = true;
			} else {
				angular.forEach($scope.productCategories, function (item) {
					item.checked = false;
				});
				$scope.isAll = false;
			}
		}
		// kiểm tra item được checked thì enable button xóa 
		$scope.$watch("productCategories", function (n, o) {
			var checked = $filter("filter")(n, { checked: true });
			if (checked.length) {
				$scope.selected = checked;
				$('#btnDelete').removeAttr('disabled');
			} else {
				$('#btnDelete').attr('disabled', 'disabled');
			}
		}, true);

		function DeleteProductCategory(id) {
			var config = {
				params: {
					id: id
				}
			};

			apiService.del('/api/productCategory/delete', config, function (result) {
				notificationService.displaySuccess('Xóa sản phẩm thành công.');
				search();
			}, function (error) {
				notificationService.displayError('Xóa không thành công.');
			});
		}

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
