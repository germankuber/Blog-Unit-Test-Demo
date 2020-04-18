using System;
using System.Collections.Generic;
using Blog.Core;
using FluentAssertions;
using Xunit;

namespace Blog.Tests
{
    //TODO: 01 - Name of class
    public class BlogShould
    {
        //TODO: 02 - Name of Object
        private readonly Core.Blog _sut;

        public BlogShould()
        {
            //TODO: 03 -Initialization
            _sut = new Core.Blog("Primer Blog",
                new List<Post>
                {
                    new Post("Primer post", "Test", DateTime.Now.AddDays(-5)),
                    new Post("Segundo post", "Test 1", DateTime.Now.AddDays(-4)),
                    new Post("Tercer post", "Test 2", DateTime.Now.AddDays(-3)),
                    new Post("Cuarto post", "Test 3", DateTime.Now.AddDays(-2)),
                });
        }

        [Fact]
        public void Throws_Exception_Parameter_Null()
        {
            Action act = () => _sut.ExistPost(string.Empty);

            act.Should().Throw<ArgumentNullException>();
        }


        [Fact]
        public void Return_True_Post_Exists()
        {
            //TODO : 04 - Structure - FluentAssertions
            //arrange
            bool existPost = default;

            //act
            existPost = _sut.ExistPost("Primer post");

            //assert
            existPost.Should().BeTrue();
        }

        [Fact]
        public void Return_False_Post_Does_Not_Exist()
        {
            bool existPost = default;

            existPost = _sut.ExistPost("Test");


            existPost.Should().BeFalse();
        }
    }
}

