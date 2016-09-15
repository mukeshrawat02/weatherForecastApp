(function (angular) {
    "using strict";

    angular.module("weatherApp")
           .controller("WeatherController",
                        [
                           'weatherService',
                            weatherController
                        ]);

    function weatherController(weatherService) {
        var self = this;

        self.forecast = {};
        self.place = "";
        self.message = "";
        self.findWeather = function () {
            if (!self.place) {
                self.message = 'Please provide a location';
                return;
            }

            var forecast = weatherService.getWeatherForecast().query({ locationName: self.place });
            forecast.$promise
                .then(function (weatherForecast) {
                    //success angular.toJson(weatherForecast, true);
                    self.forecast = weatherForecast;
                },
                function (error) {
                    //error
                    self.message = 'Unable to load data from OpenWeatherMap API: ' + error.message;
                });
        };
    };
}(window.angular));