(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.getProducCategories = getProducCategories;

        function getProducCategories() {
            apiService.get('/api/productCategory/getlist', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Load list fail');
            });
        }

        $scope.getProducCategories();
    }
})(angular.module('tedushop.productCategories'));