/// 

(function () {
    angular.module('tedushop.productCategories', ['tedushop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_list_category', {
            url: "/product_list_category",
            templateUrl: "/app/component/productCategories/productListCategoryView.html",
            controller: "productCategoryListController"
        });
    }
})();