using MarsRover.Business.Manager;
using MarsRover.Business.Servicec;
using MarsRover.Helper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = RegisterServices();
            var roverService = serviceProvider.GetRequiredService<IRoverService>();

            var maximumProgress = ReadMaximumProgress();
            var startPositions = ReadStartPositions();

            if (startPositions.Count() == 3)
            {
                roverService.X = Convert.ToInt32(startPositions[0]);
                roverService.Y = Convert.ToInt32(startPositions[1]);
                roverService.Direction = (DirectionType)Enum.Parse(typeof(DirectionType), startPositions[2]);
            }

            var advance = GetAdvance();

            try
            {
                roverService.StartRoverDiscovery(maximumProgress, advance);

                RoverResult(roverService);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private static void RoverResult(IRoverService roverService)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.WriteLine("------------------Result------------------");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine($"X: {roverService.X} {Environment.NewLine}Y: {roverService.Y} {Environment.NewLine}Direction: {roverService.Direction}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static string GetAdvance()
        {
            Console.Write("Sol için L sağ için R ve ilerlemek içim M (Example: LMLMLMLMM or MMRMMRMRRM) : ");
            return Console.ReadLine().ToUpper();
        }

        private static List<int> ReadMaximumProgress()
        {
            Console.Write("Maksimum ilerlenecek X Y sayısı (Example: 5 5) : ");
            return Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
        }

        private static string[] ReadStartPositions()
        {
            Console.Write("Başlangıç X Y pozisyonu ve yönü (Example: 1 2 N) : ");
            return Console.ReadLine().Trim().Split(' ');
        }

        private static ServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IRoverService, RoverManager>();
            services.BuildServiceProvider(true);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
