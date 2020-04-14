using System;
using Xunit.Abstractions;

namespace Blog.Tests
{
    //TODO: 01 - Creo Clase base
    public abstract class TestBase : IDisposable
    {
        protected ITestOutputHelper Output { get; }
        public abstract void Dispose();
        //TODO: 02 -Inyecto el Output (para loguear)
        protected TestBase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}