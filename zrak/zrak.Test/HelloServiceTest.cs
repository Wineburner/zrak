using System;
using Xunit;
using zrak.Services;

namespace zrak.Test
{
    public class HelloServiceTest
    {
        [Fact]
        public void Should_Say_Hello_Successful()
        {
            var service = new HelloService();

            var result = service.GetHello();

            Assert.Equal("Hello World", result.Greet);

        }
    }
}
