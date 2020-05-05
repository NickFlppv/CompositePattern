using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        private const int ArgsCount = 3;

        static void Main(string[] args)
        {
            try
            {
                var parameters = HandleArgs(args);
                HandleInput(CreatePlane(parameters));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static PlaneParameters HandleArgs(string[] args)
        {
            if (args.Count() < ArgsCount)
            {
                return new PlaneParameters();
            }

            return new PlaneParameters
            {
                EconomyClassCapacity = int.Parse(args[0]),
                BusinessClassCapacity = int.Parse(args[1]),
                FirstClassCapacity = int.Parse(args[2])
            };
        }

        private static void HandleInput(Plane plane)
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Enter command: ");
                var key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '0':
                        return;
                    case '1':
                        try
                        {
                            Console.WriteLine();
                            plane.RegisterPassenger();
                        }
                        catch (MissingMethodException e)
                        {
                            Console.WriteLine("Couldn't define boarding class");
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case '2':
                        Console.WriteLine();
                        plane.ShowBoardingMap();
                        break;
                    case '3':
                        Console.WriteLine();
                        Console.WriteLine(plane.LuggageWeightCheckToString());
                        break;
                    case '4':
                        Console.WriteLine();
                        Console.WriteLine("Enter weight to remove:");
                        try
                        {
                            var _ = int.TryParse(Console.ReadLine(), out var weight)
                                ? plane.RemoveLuggageFromEconomyClass(weight)
                                : throw new InvalidOperationException("Wrong weight input");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static Plane CreatePlane(PlaneParameters parameters) =>
            new PlaneBuilder()
                .WithEconomyClass(new EconomyClass {Capacity = parameters.EconomyClassCapacity})
                .WithBusinessClass(new BusinessClass {Capacity = parameters.BusinessClassCapacity})
                .WithFirstClass(new FirstClass {Capacity = parameters.FirstClassCapacity})
                .WithPilot(new Pilot())
                .WithPilot(new Pilot())
                .WithStewardess(new Stewardess())
                .WithStewardess(new Stewardess())
                .WithStewardess(new Stewardess())
                .Build();

        private static void ShowMenu()
        {
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - register passenger");
            Console.WriteLine("2 - show boarding map");
            Console.WriteLine("3 - check luggage weight");
            Console.WriteLine("4 - remove luggage");
        }
    }
}