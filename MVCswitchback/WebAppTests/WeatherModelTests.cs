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
        public void CanGetWeathersSummary()
        {
            Weather weather = new Weather()
            {
                Summary = "ITS SO NICE AND SUNNY AND WONDERFUL"
            };

            Assert.Equal("ITS SO NICE AND SUNNY AND WONDERFUL", weather.Summary);
        }

        [Fact]
        public void CanSetWeathersSummary()
        {
            Weather weather = new Weather()
            {
                Summary = "ITS SO NICE AND SUNNY AND WONDERFUL"
            };
            weather.Summary = "ITS RAINING SIDEWAYS";

            Assert.Equal("ITS RAINING SIDEWAYS", weather.Summary);
        }
    }
}
