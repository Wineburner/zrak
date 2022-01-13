using zrak.Models;

namespace zrak.Services
{
    public class HelloService : IHelloService
    {
        public HelloModel GetHello()
        {
            return new HelloModel
            {
                Greet = "Zrak"
            };
        }
    }
}
