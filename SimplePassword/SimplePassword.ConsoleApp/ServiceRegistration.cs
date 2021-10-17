using Microsoft.Extensions.DependencyInjection;
using SimplePassword.Service.Contract;
using SimplePassword.Service.Implementation;

namespace SimplePassword.ConsoleApp
{
    public class ServiceRegistration
    {
        public static ServiceProvider GetServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISimplePasswordService, SimplePasswordService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
