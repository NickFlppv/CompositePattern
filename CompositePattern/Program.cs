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
            ShowMenu();
            while (true)
            {
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
                            RegisterPassenger(plane);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case '2':
                        Console.WriteLine();
                        Task.Run(() => ShowBoardingMap(plane));
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowBoardingMap(Plane plane) => Console.WriteLine(plane.CreateBoardingMap());

        private static void RegisterPassenger(Plane plane)
        {
            Console.WriteLine("Choose class (Economy, Business, First):");
            var classType = Console.ReadLine();
            Console.WriteLine("Enter passenger`s name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter passenger`s ticket:");
            var ticket = Console.ReadLine();
            Console.WriteLine("Enter passenger`s luggage (kg):");
            var luggage = Console.ReadLine();

            (GetBoardingClass(plane, classType) ??
             throw new InvalidOperationException("Couldn't define boarding class"))
                .Add(new Passenger
                {
                    Id = new Random().Next(),
                    Name = name,
                    TicketHash = ticket,
                    Luggage = int.TryParse(luggage, out var res)
                        ? res
                        : throw new InvalidOperationException("Wrong luggage input")
                });
        }

        private static BoardingComponent GetBoardingClass(Plane plane, string classType) =>
            plane.GetType().InvokeMember($"{classType}Class",
                BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.GetProperty, null, plane, null) as BoardingComponent;

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
                .WithLuggageMaxWeight(10000)
                .Build();

        private static void ShowMenu()
        {
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - register passenger");
            Console.WriteLine("2 - show boarding map");
        }
    }
}