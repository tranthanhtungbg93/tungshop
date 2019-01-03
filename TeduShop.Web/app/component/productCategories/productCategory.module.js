/// 

(function () {
	angular.module('tedushop.productCategories', ['tedushop.common']).config(config);
	config.$inject = ['$stateProvider', '$urlRouterProvider'];

	function config($stateProvider, $urlRouterProvider) {
		$stateProvider.state('product_list_category', {
			url: "/product_list_category",
			templateUrl: "/app/component/productCategories/productListCategoryView.html",
			controller: "productCategoryListController"
		}).state('product_add_category', {
			url: "/product_add_category",
			templateUrl: "/app/component/productCategories/addProductCategory/productCategoryAddView.html",
			controller: "productCategoryAddController"
		}).state('product_update_category', {
			url: "/product_update_category/:id",
			templateUrl: "/app/component/productCategories/update/productCategoryUpdateView.html",
			controller: "productCategoryUpdateController"
		});
	}
})();