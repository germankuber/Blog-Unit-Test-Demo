using System;
using System.Collections;
using System.Collections.Generic;
using Blog.Core;
using FluentAssertions;
using Xunit;
using static FluentAssertions.FluentActions;

namespace Blog.Tests
{
    public class AssertsShould
    {


        [Fact]
        public void Match_String()
        {
            string theString = "ABCDEFGHI";
            theString.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
            theString.Should().NotBeEmpty("because the string is not empty");
        }


        [Fact]
        public void Assert_Null()
        {
            short? theShort = null;

            theShort.Should().BeNull();
            theShort.Should().Match(x => !x.HasValue || x > 0);
        }

        [Fact]
        public void Assert_Not_Null()
        {
            int? theInt = 3;

            theInt.Should().HaveValue();
            theInt.Should().NotBeNull();
        }

        [Fact]
        public void Assert_In_List()
        {
            var valueToCheck = 1;

            valueToCheck.Should().BeOneOf(new List<int> { 2, 3, 4, 5, 1 });
        }

        [Fact]
        public void Assert_List()
        {
            IEnumerable collection = new[] { 1, 2, 5, 8 };

            collection.Should().NotBeEmpty()
                .And.HaveCount(4)
                .And.ContainInOrder(new[] { 2, 5 })
                .And.OnlyHaveUniqueItems()
                .And.NotContain(new[] { 82, 83 })
                .And.ContainItemsAssignableTo<int>();
        }


        [Fact]
        public void Assert_Exceptions()
        {
            Invoking(() => CheckException(null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.StartsWith("Value cannot be nul")); ;
        }

        [Fact]
        public void Assert_Objects()
        {
            var time = DateTime.Now;
            var blog1 = new Core.Blog("Test", new List<Post> { new Post("title", "description", time) });
            var blog2 = new Core.Blog("Test", new List<Post> { new Post("title", "description", time) });

            blog1.Should().BeEquivalentTo(blog2);
            blog1.Should().BeSameAs(blog1);
        }

        private void CheckException(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentNullException(nameof(parameter));
        }
    }
}

