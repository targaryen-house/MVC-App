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
            Trail trail = new Trail();
            trail.ID = 2;

            Assert.Equal(2, trail.ID);
        }

        [Fact]
        public void CanGetTrailName()
        {
            Trail trail = new Trail()
            {
                Name = "giggity"
            };

            Assert.Equal("giggity", trail.Name);
        }

        [Fact]
        public void CanSetTrailName()
        {
            Trail trail = new Trail();
            trail.Name = "Yeet";

            Assert.Equal("Yeet", trail.Name);
        }

        [Fact]
        public void CanGetTrailType()
        {
            Trail trail = new Trail()
            {
                Type = "long"
            };

            Assert.Equal("long", trail.Type);
        }

        [Fact]
        public void CanSetTrailType()
        {
            Trail trail = new Trail();
            trail.Type = "No";

            Assert.Equal("No", trail.Type);
        }

        [Fact]
        public void CanGetTrailSummary()
        {
            Trail trail = new Trail()
            {
                Summary = "It was long"
            };

            Assert.Equal("It was long", trail.Summary);
        }

        [Fact]
        public void CanSetTrailSummary()
        {
            Trail trail = new Trail();
            trail.Summary = "What day is it";

            Assert.Equal("What day is it", trail.Summary);
        }

        [Fact]
        public void CanGetTrailDifficulty()
        {
            Trail trail = new Trail()
            {
                Difficulty = "tuff"
            };

            Assert.Equal("tuff", trail.Difficulty);
        }

        [Fact]
        public void CanSetTrailDifficulty()
        {
            Trail trail = new Trail();
            trail.Summary = "easy peasy";

            Assert.Equal("easy peasy", trail.Summary);
        }

        //[Fact]
        //public void CanGetTrailID()
        //{
        //    Trail trail = new Trail()
        //    {
        //        ID = 1
        //    };

        //    Assert.Equal(1, trail.ID);
        //}

        //[Fact]
        //public void CanSetTrailID()
        //{
        //    Trail trail = new Trail();
        //    trail.ID = 2;

        //    Assert.Equal(2, trail.ID);
        //}

        //[Fact]
        //public void CanGetTrailID()
        //{
        //    Trail trail = new Trail()
        //    {
        //        ID = 1
        //    };

        //    Assert.Equal(1, trail.ID);
        //}

        //[Fact]
        //public void CanSetTrailID()
        //{
        //    Trail trail = new Trail();
        //    trail.ID = 2;

        //    Assert.Equal(2, trail.ID);
        //}

        //[Fact]
        //public void CanGetTrailID()
        //{
        //    Trail trail = new Trail()
        //    {
        //        ID = 1
        //    };

        //    Assert.Equal(1, trail.ID);
        //}

        //[Fact]
        //public void CanSetTrailID()
        //{
        //    Trail trail = new Trail();
        //    trail.ID = 2;

        //    Assert.Equal(2, trail.ID);
        //}

    }
}
