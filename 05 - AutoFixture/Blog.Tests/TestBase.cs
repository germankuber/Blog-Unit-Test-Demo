using System;
using Xunit.Abstractions;

namespace Blog.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected ITestOutputHelper Output { get; }
        public abstract void Dispose();
        protected TestBase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}