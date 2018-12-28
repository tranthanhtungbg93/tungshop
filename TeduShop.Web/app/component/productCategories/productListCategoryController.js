
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;
        $scope.page = 0;
        $scope.pagesCount = 0;

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: 10
                }
            };
            apiService.get('/api/productCategory/getlist', config, function (result) {
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalCount;
				console.log($scope.page + '-' + $scope.pagesCount + '-' + $scope.totalCount);
            }, function () {
                console.log('Load list fail');
            });
        }

        $scope.getProductCategories();
    }
})(angular.module('tedushop.productCategories'));