using System;
using System.Diagnostics;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Idioms;
using Blog.Core;
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



        [Fact]
        public void AutoFixture_CreateMany()
        {
            //TODO: 01 - Create Many
            var fixture = new Fixture();

            var posts = fixture.CreateMany<Post>(10);

            posts.Count().Should().Be(10);
        }


        [Fact]
        public void AutoFixture_SetProperty()
        {
            const string blogTitle = "Primer Blog";
            var fixture = new Fixture();

            var mc = fixture.Build<Core.Blog>()
                .With(x => x.Title, blogTitle)
                .Create();

            mc.Title.Should().Be(blogTitle);
        }

        [Fact]
        public void AutoFixture_AutoMoqCustomization()
        {
            const string blogTitle = "Primer Blog";
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

            var blog = fixture.Create<IBlog>();
            blog.Title.Should().NotBeNullOrWhiteSpace();
        }


        [Fact]
        public void AutoFixture_Idioms()
        {
            //arrange
            var fixture = new Fixture();

            var assertion = new WritablePropertyAssertion(fixture);
            //act
            var sut = fixture.Create<Core.Blog>();
            var props = sut.GetType().GetProperties();

            //assert

            assertion.Verify(props);
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

