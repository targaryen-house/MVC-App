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

    }
}
