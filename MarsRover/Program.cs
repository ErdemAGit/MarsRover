using System;
using System.Text;
using MarsRover.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mars!");

            var serviceProvider = Startup.Configure();

            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");

            var marsRoverController = serviceProvider.GetService<IMarsRoverController>();
            var result = marsRoverController.ExecuteCommand(commandStringBuilder.ToString());

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
