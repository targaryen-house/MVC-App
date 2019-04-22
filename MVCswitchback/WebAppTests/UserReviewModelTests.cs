using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MVCswitchback.Models;

namespace WebAppTests
{
    public class UserCommentsModelTests
    {
        [Fact]
        public void CanGetUserReviewID()
        {
            UserComments userComment = new UserComments()
            {
                ID = 1
            };

            Assert.Equal(1, userComment.ID);
        }

        [Fact]
        public void CanSetUserReviewID()
        {
            UserComments userComment = new UserComments()
            {
                ID = 1
            };
            userComment.ID = 2;

            Assert.Equal(2, userComment.ID);
        }

        [Fact]
        public void CanGetUserReviewUserID()
        {
            UserComments userComment = new UserComments()
            {
                UserInfoID = 1
            };

            Assert.Equal(1, userComment.UserInfoID);
        }

        [Fact]
        public void CanSetUserReviewUserID()
        {
            UserComments userComment = new UserComments()
            {
                UserInfoID = 1
            };
            userComment.UserInfoID = 2;

            Assert.Equal(2, userComment.UserInfoID);
        }

        [Fact]
        public void CanGetUserReviewTrailID()
        {
            UserComments userComment = new UserComments()
            {
                TrailID = 1
            };

            Assert.Equal(1, userComment.TrailID);
        }

        [Fact]
        public void CanSetUserReviewTrailID()
        {
            UserComments userComment = new UserComments()
            {
                TrailID = 1
            };
            userComment.TrailID = 2;

            Assert.Equal(2, userComment.TrailID);
        }

        [Fact]
        public void CanGetUserReviewUserComment()
        {
            UserComments userComment = new UserComments()
            {
                UserComment = "Was Fun"
            };

            Assert.Equal("Was Fun", userComment.UserComment);
        }

        [Fact]
        public void CanSetUserReviewUserComment()
        {
            UserComments userReviews = new UserComments()
            {
                UserComment = "Was Fun"
            };
            userReviews.UserComment = "Nevermind";

            Assert.Equal("Nevermind", userReviews.UserComment);
        }
    }
}
