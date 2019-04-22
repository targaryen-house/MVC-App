using MVCswitchback.Models;
using System;
using Xunit;

namespace WebAppTests
{
    public class TrailModelTests
    {
        [Fact]
        public void CanGetTrailID()
        {
            Trail trail = new Trail()
            {
                ID = 1
            };

            Assert.Equal(1, trail.ID);
        }

        [Fact]
        public void CanSetTrailID()
        {
            Trail trail = new Trail()
            {
                ID = 1
            };
            trail.ID = 2;

            Assert.Equal(2, trail.ID);
        }

        [Fact]
        public void CanGetTrailName()
        {
            Trail trail = new Trail()
            {
                Name = "Foo"
            };

            Assert.Equal("Foo", trail.Name);
        }

        [Fact]
        public void CanSetTrailName()
        {
            Trail trail = new Trail()
            {
                Name = "Foo"
            };
            trail.Name = "Bar";

            Assert.Equal("Bar", trail.Name);
        }

        [Fact]
        public void CanGetTrailType()
        {
            Trail trail = new Trail()
            {
                Type = "Foo"
            };

            Assert.Equal("Foo", trail.Type);
        }

        [Fact]
        public void CanSetTrailType()
        {
            Trail trail = new Trail()
            {
                Type = "Foo"
            };
            trail.Type = "Bar";

            Assert.Equal("Bar", trail.Type);
        }

        [Fact]
        public void CanGetTrailSummary()
        {
            Trail trail = new Trail()
            {
                Summary = "FooBar"
            };

            Assert.Equal("FooBar", trail.Summary);
        }

        [Fact]
        public void CanSetTrailSummary()
        {
            Trail trail = new Trail()
            {
                Summary = "FooBar"
            };
            trail.Summary = "BarFoo";

            Assert.Equal("BarFoo", trail.Summary);
        }

        [Fact]
        public void CanGetTrailDifficulty()
        {
            Trail trail = new Trail()
            {
                Difficulty = "Foo"
            };

            Assert.Equal("Foo", trail.Difficulty);
        }

        [Fact]
        public void CanSetTrailDifficulty()
        {
            Trail trail = new Trail()
            {
                Difficulty = "Foo"
            };
            trail.Difficulty = "Bar";

            Assert.Equal("Bar", trail.Difficulty);
        }

        [Fact]
        public void CanSetTrailStars()
        {
            Trail trail = new Trail()
            {
                Stars = 3.3f
            };

            Assert.Equal(3.3f, trail.Stars);
        }

        [Fact]
        public void CanGetTrailStars()
        {
            Trail trail = new Trail()
            {
                Stars = 3.3f
            };
            trail.Stars = 5.0f;

            Assert.Equal(5.0f, trail.Stars);
        }

        [Fact]
        public void CanGetTrailStarVotes()
        {
            Trail trail = new Trail()
            {
                StarVotes = 50
            };

            Assert.Equal(50, trail.StarVotes);
        }

        [Fact]
        public void CanSetTrailStarVotes()
        {
            Trail trail = new Trail()
            {
                StarVotes = 50
            };
            trail.StarVotes = 100;

            Assert.Equal(100, trail.StarVotes);
        }

        [Fact]
        public void CanGetTrailLocation()
        {
            Trail trail = new Trail()
            {
                Location = "Seattle"
            };

            Assert.Equal("Seattle", trail.Location);
        }

        [Fact]
        public void CanSetTrailLocation()
        {
            Trail trail = new Trail()
            {
                Location = "Seattle"
            };
            trail.Location = "Denver";

            Assert.Equal("Denver", trail.Location);
        }

        [Fact]
        public void CanGetTrailUrl()
        {
            Trail trail = new Trail()
            {
                URL = "www.testurl.com"
            };

            Assert.Equal("www.testurl.com", trail.URL);
        }

        [Fact]
        public void CanSetTrailUrl()
        {
            Trail trail = new Trail()
            {
                URL = "www.testurl.com"
            };
            trail.URL = "www.testurlbutnotreally.com";

            Assert.Equal("www.testurlbutnotreally.com", trail.URL);
        }

        [Fact]
        public void CanGetTrailImgSqSmall()
        {
            Trail trail = new Trail()
            {
                ImgSqSmall = "smol"
            };

            Assert.Equal("smol", trail.ImgSqSmall);
        }

        [Fact]
        public void CanSetTrailImgSqSmall()
        {
            Trail trail = new Trail()
            {
                ImgSqSmall = "smol"
            };
            trail.ImgSqSmall = "verySmol";

            Assert.Equal("verySmol", trail.ImgSqSmall);
        }

        [Fact]
        public void CanGetTrailImgSmall()
        {
            Trail trail = new Trail()
            {
                ImgSmall = "tiny"
            };

            Assert.Equal("tiny", trail.ImgSmall);
        }

        [Fact]
        public void CanSetTrailImgSmall()
        {
            Trail trail = new Trail()
            {
                ImgSmall = "issaTest"
            };
            trail.ImgSmall = "issaJoke";

            Assert.Equal("issaJoke", trail.ImgSmall);
        }

        [Fact]
        public void CanGetTrailImgSmallMed()
        {
            Trail trail = new Trail()
            {
                ImgSmallMed = "smallishMedium"
            };

            Assert.Equal("smallishMedium", trail.ImgSmallMed);
        }

        [Fact]
        public void CanSetTrailImgSmallMed()
        {
            Trail trail = new Trail()
            {
                ImgSmallMed = "maybeJustMedium"
            };
            trail.ImgSmallMed = "justMedium";

            Assert.Equal("justMedium", trail.ImgSmallMed);
        }

        [Fact]
        public void CanGetTrailImgMedium()
        {
            Trail trail = new Trail()
            {
                ImgMedium = "soRealMedium"
            };

            Assert.Equal("soRealMedium", trail.ImgMedium);
        }

        [Fact]
        public void CanSetTrailImgMedium()
        {
            Trail trail = new Trail()
            {
                ImgMedium = "soRealMedium"
            };
            trail.ImgMedium = "bigMed";

            Assert.Equal("bigMed", trail.ImgMedium);
        }

        [Fact]
        public void CanGetTrailLength()
        {
            Trail trail = new Trail()
            {
                Length = 420f
            };

            Assert.Equal(420f, trail.Length);
        }

        [Fact]
        public void CanSetTrailLength()
        {
            Trail trail = new Trail()
            {
                Length = 420f
            };
            trail.Length = 123f;

            Assert.Equal(123f, trail.Length);
        }

        [Fact]
        public void CanGetTrailAscent()
        {
            Trail trail = new Trail()
            {
                Ascent = 8999
            };

            Assert.Equal(8999, trail.Ascent);
        }

        [Fact]
        public void CanSetTrailAscent()
        {
            Trail trail = new Trail()
            {
                Ascent = 8999
            };
            trail.Ascent = 9001;

            Assert.Equal(9001, trail.Ascent);
        }

        [Fact]
        public void CanGetTrailDescent()
        {
            Trail trail = new Trail()
            {
                Descent = 459
            };

            Assert.Equal(459, trail.Descent);
        }

        [Fact]
        public void CanSetTrailDescent()
        {
            Trail trail = new Trail()
            {
                Descent = 7
            };
            trail.Descent = 8;

            Assert.Equal(8, trail.Descent);
        }

        [Fact]
        public void CanGetTrailHigh()
        {
            Trail trail = new Trail()
            {
                High = 67
            };

            Assert.Equal(67, trail.High);
        }

        [Fact]
        public void CanSetTrailHigh()
        {
            Trail trail = new Trail()
            {
                High = 99
            };
            trail.High = 100;

            Assert.Equal(100, trail.High);
        }

        [Fact]
        public void CanGetTrailLow()
        {
            Trail trail = new Trail()
            {
                Low = 1
            };

            Assert.Equal(1, trail.Low);
        }

        [Fact]
        public void CanSetTrailLow()
        {
            Trail trail = new Trail()
            {
                Low = 2
            };
            trail.Low = 3;

            Assert.Equal(3, trail.Low);
        }

        [Fact]
        public void CanGetTrailLongitude()
        {
            Trail trail = new Trail()
            {
                Longitude = 47
            };

            Assert.Equal(47, trail.Longitude);
        }

        [Fact]
        public void CanSetTrailLongitude()
        {
            Trail trail = new Trail()
            {
                Longitude = 56
            };
            trail.Longitude = 57;

            Assert.Equal(57, trail.Longitude);
        }

        [Fact]
        public void CanGetTrailLatitude()
        {
            Trail trail = new Trail()
            {
                Latitude = 25
            };

            Assert.Equal(25, trail.Latitude);
        }

        [Fact]
        public void CanSetTrailLatitude()
        {
            Trail trail = new Trail()
            {
                Latitude = 68
            };
            trail.Latitude = 71;

            Assert.Equal(71, trail.Latitude);
        }

        [Fact]
        public void CanGetTrailConditionStatus()
        {
            Trail trail = new Trail()
            {
                ConditionStatus = "Open? maybe"
            };

            Assert.Equal("Open? maybe", trail.ConditionStatus);
        }

        [Fact]
        public void CanSetTrailConditionStatus()
        {
            Trail trail = new Trail()
            {
                ConditionStatus = "Open? maybe"
            };
            trail.ConditionStatus = "Nope";

            Assert.Equal("Nope", trail.ConditionStatus);
        }

        [Fact]
        public void CanGetTrailConditionDetails()
        {
            Trail trail = new Trail()
            {
                ConditionDetails = "rough"
            };

            Assert.Equal("rough", trail.ConditionDetails);
        }

        [Fact]
        public void CanSetTrailConditionDetails()
        {
            Trail trail = new Trail()
            {
                ConditionDetails = "rough"
            };
            trail.ConditionDetails = "very rough";

            Assert.Equal("very rough", trail.ConditionDetails);
        }

        [Fact]
        public void CanGetTrailConditionDate()
        {
            Trail trail = new Trail()
            {
                ConditionDate = "27APR"
            };

            Assert.Equal("27APR", trail.ConditionDate);
        }

        [Fact]
        public void CanSetTrailConditionDate()
        {
            Trail trail = new Trail()
            {
                ConditionDate = "27APR"
            };
            trail.ConditionDate = "3MAR";

            Assert.Equal("3MAR", trail.ConditionDate);
        }
    }
}
