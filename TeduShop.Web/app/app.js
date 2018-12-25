/// 

(function () {
    angular.module('tedushop', ['tedushop.product','tedushop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/home/index",
            templateUrl: "/app/component/home/home.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/home/index');
    }
})();