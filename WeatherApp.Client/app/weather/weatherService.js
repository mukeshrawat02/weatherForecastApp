(function (angular) {
    "use strict";

    angular.module("common.services")
           .factory("weatherService",
                    ["$resource",
                      weatherService]);

    function weatherService($resource) {
        var urlBase = "http://localhost:3000/api/weather";

        var weatherFactory = {};

        weatherFactory.getWeatherForecast = function () {
            return $resource(urlBase + '/:locationName');
        }

        return weatherFactory;
    };
}(window.angular));