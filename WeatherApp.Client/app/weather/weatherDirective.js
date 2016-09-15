(function (angular) {
    "use strict";

    angular.module("weatherApp")
           .directive("ngWeatherPanel",
                      weatherPanel);

    function weatherPanel() {
        return {
            restrict: 'E',
            scope: {
                weatherDetail: '=forecast',
                panelType: '@type'
            },
            templateUrl: '/app/weather/templates/_weatherPanel.html'
        }
    };
}(window.angular));