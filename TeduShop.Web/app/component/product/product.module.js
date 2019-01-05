/// 

(function () {
    angular.module('tedushop.product', ['tedushop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_list', {
            url: "/product_list",
            templateUrl: "/app/component/product/productListView.html",
			controller: "productListController",
			parent: 'base'
        }).state('product_edit', {
			url: "/product_edit/:id",
            templateUrl: "/app/component/product/productEditView.html",
			controller: "productEditController",
			parent: 'base'
        }).state('product_add', {
            url: "/product_add",
            templateUrl: "/app/component/product/productAddView.html",
			controller: "productAddController",
			parent: 'base'
        });
    }
})();