using System;
using System.Collections.Generic;
using Blog.Core;
using FluentAssertions;
using Xunit;

namespace Blog.Tests
{
    public class BlogShould
    {
        private readonly Core.Blog _sut;
        private readonly Post _postToSearch = new Post("Primer post", "Test", DateTime.Now.AddDays(-5));
        public BlogShould()
        {
            _sut = new Core.Blog("Primer Blog",
                new List<Post>
                {
                    _postToSearch,
                    new Post("Segundo post", "Test 1", DateTime.Now.AddDays(-4)),
                    new Post("Tercer post", "Test 2", DateTime.Now.AddDays(-3)),
                    new Post("Cuarto post", "Test 3", DateTime.Now.AddDays(-2)),
                });
        }

        [Fact(DisplayName = "Throws Exception, Parameter is null")]
        public void Throws_Exception_Parameter_Null()
        {
            Action act = () => _sut.ExistPost(string.Empty);

            act.Should().Throw<ArgumentNullException>();
        }


        [Fact(DisplayName = "Return true, Post Exists")]
        public void Return_True_Post_Exists()
        {
            bool existPost = default;

            existPost = _sut.ExistPost(_postToSearch.Title);

            existPost.Should().BeTrue();
        }

        [Theory(DisplayName = "Return False, Post Does not Exist")]
        [InlineData("Bad Post")]
        [InlineData("Post Test")]
        public void Return_False_Post_Does_Not_Exist(string postTitle)
        {
            bool existPost = default;

            existPost = _sut.ExistPost(postTitle);

            existPost.Should().BeFalse();
        }
    }
}

