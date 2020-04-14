using System;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Blog.Tests
{
    public class BlogShould : TestBase
    {
        private Core.Blog _sut;
        private readonly Fixture _fixture = new Fixture();

        public BlogShould(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(DisplayName = "Throws Exception, Parameter is null")]
        public void Throws_Exception_Parameter_Null()
        {
            Initialize();

            Action act = () => _sut.ExistPost(string.Empty);

            act.Should().Throw<ArgumentNullException>();
        }

        //[Fact(DisplayName = "Return true, Post Exists")]
        //public void Return_True_Post_Exists()
        //{
        //    bool existPost = default;

        //    existPost = _sut.ExistPost(_postToSearch.Title);

        //    existPost.Should().BeTrue();
        //}

        [Fact(DisplayName = "Return true, Post Exists")]
        public void Return_True_Post_Exists()
        {
            //TODO: 06 - Inicializo mi test
            Initialize();

            //Refactorizo mi test
            _sut.ExistPost(_sut.Posts.First().Title)
                .Should()
                .BeTrue();
        }

        [Theory(DisplayName = "Return False, Post Does not Exist")]
        [InlineData("Bad Post")]
        [InlineData("Post Test")]
        public void Return_False_Post_Does_Not_Exist(string postTitle)
        {
            Initialize();

            bool existPost = default;

            existPost = _sut.ExistPost(postTitle);

            existPost.Should().BeFalse();
        }

        //TODO: 03 - Inicializo toda la data necesaria para mi test
        public void Initialize()
        {
            //TODO: 04 - Utilizo AutoFixture
            _sut = _fixture.Create<Core.Blog>();
            Output.WriteLine("Initialize Test");
        }

        //TODO: 05 - Limpio mi test
        public override void Dispose()
        {
            _sut = new Core.Blog(default, default);
            Output.WriteLine("CleanUp Test");
        }
    }
}

