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

        [Fact(DisplayName = "Return true, Post Exists")]
        public void Return_True_Post_Exists()
        {
            Initialize();

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
            _sut.ExistPost(postTitle)
                .Should().BeFalse();
        }

        public void Initialize()
        {
            _sut = _fixture.Create<Core.Blog>();
            Output.WriteLine("Initialize Test");
        }

        public override void Dispose()
        {
            _sut = new Core.Blog(default, default);
            Output.WriteLine("CleanUp Test");
        }
    }
}

