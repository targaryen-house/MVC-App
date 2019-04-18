using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MVCswitchback.Models;

namespace WebAppTests
{
    public class WeatherModelTests
    {
        [Fact]
        public void CanGetWeathersWeather()
        {
            WeatherModel weather = new WeatherModel()
            {
                Weather = "ITS SO NICE AND SUNNY AND WONDERFUL"
            };

            Assert.Equal("ITS SO NICE AND SUNNY AND WONDERFUL", weather.Weather);
        }

        [Fact]
        public void CanSetWeathersWeather()
        {
            WeatherModel weather = new WeatherModel()
            {
                Weather = "ITS SO NICE AND SUNNY AND WONDERFUL"
            };
            weather.Weather = "ITS RAINING SIDEWAYS";

            Assert.Equal("ITS RAINING SIDEWAYS", weather.Weather);
        }
    }
}
