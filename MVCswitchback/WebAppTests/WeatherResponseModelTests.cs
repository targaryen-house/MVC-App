using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MVCswitchback.Models;

namespace WebAppTests
{
   public class WeatherResponseModelTests
    {
        [Fact]
        public void CanGetWeathersResponseName()
        {
            WeatherResponse weatherResponse = new WeatherResponse()
            {
                Name = "El Nino"
            };

            Assert.Equal("El Nino", weatherResponse.Name);
        }

        [Fact]
        public void CanSetWeatherResponseName()
        {
            WeatherResponse weatherResponse = new WeatherResponse()
            {
                Name = "El Nino"
            };
            weatherResponse.Name = "Santa Maria";

            Assert.Equal("Santa Maria", weatherResponse.Name);
        }

        [Fact]
        public void CanGetWeathersResponseWeatherDescriptionMain()
        {
            WeatherDescription weatherResponse = new WeatherDescription()
            {
                Main = "its the main description"
            };

            Assert.Equal("its the main description", weatherResponse.Main);
        }

        [Fact]
        public void CanSetWeatherResponseWeatherDescriptionMain()
        {
            WeatherDescription weatherResponse = new WeatherDescription()
            {
                Main = "its the main description"
            };
            weatherResponse.Main = "Or is it?";

            Assert.Equal("Or is it?", weatherResponse.Main);
        }

        [Fact]
        public void CanGetWeathersResponseWeatherDescriptionDescription()
        {
            WeatherDescription weatherResponse = new WeatherDescription()
            {
                Description = "its the REAL DESCRIPTION!"
            };

            Assert.Equal("its the REAL DESCRIPTION!", weatherResponse.Description);
        }

        [Fact]
        public void CanSetWeatherResponseWeatherDescriptionDescription()
        {
            WeatherDescription weatherResponse = new WeatherDescription()
            {
                Description = "its the REAL DESCRIPTION!"
            };
            weatherResponse.Description = "Or is it?";

            Assert.Equal("Or is it?", weatherResponse.Description);
        }

        [Fact]
        public void CanGetWeathersResponseMainTemp()
        {
            Main weatherResponse = new Main()
            {
                Temp = "its Hot"
            };

            Assert.Equal("its Hot", weatherResponse.Temp);
        }

        [Fact]
        public void CanSetWeatherResponseWeatherMainTemp()
        {
            Main weatherResponse = new Main()
            {
                Temp = "its Hot"
            };
            weatherResponse.Temp = "wait, no... its cold";

            Assert.Equal("wait, no... its cold", weatherResponse.Temp);
        }
    }

    }
