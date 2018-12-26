(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input)
                return 'Kich hoat';
            else
                return 'Khoa';

        }
    });
})(angular.module('tedushop.common'));
