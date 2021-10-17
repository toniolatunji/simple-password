using Microsoft.Extensions.DependencyInjection;
using SimplePassword.Service.Contract;
using System;

namespace SimplePassword.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ServiceRegistration.GetServiceProvider();

            var simplePasswordService = serviceProvider.GetService<ISimplePasswordService>();


            var input1 = "passWord123!!!!";

            var output1 = simplePasswordService.SimplePassword(input1);

            Console.WriteLine($"Example 1:\nInput: {input1}\nOutput: {output1.IsValid}\n\n");


            var input2 = "turkey90AAA=";

            var output2 = simplePasswordService.SimplePassword(input2);

            Console.WriteLine($"Example 2:\nInput: {input2}\nOutput: {output2.IsValid}\n\n");

            Console.ReadLine();
        }
    }
}
