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

    }
}
