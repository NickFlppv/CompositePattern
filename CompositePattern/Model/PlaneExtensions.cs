using System;
using System.Reflection;
using System.Text;

namespace CompositePattern
{
    public static class PlaneExtensions
    {
        public static void ShowBoardingMap(this Plane plane) => Console.WriteLine(plane.CreateBoardingMap());

        public static void RegisterPassenger(this Plane plane)
        {
            Console.WriteLine("Choose class (Economy, Business, First):");
            var classType = Console.ReadLine();
            Console.WriteLine("Enter passenger`s name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter passenger`s seat:");
            var seat = Console.ReadLine();
            Console.WriteLine($"*Allowed weights (kg)*\nEconomy: < {plane.EconomyClass.AllowedLuggageWeight}\n" +
                              $"Business: < {plane.BusinessClass.AllowedLuggageWeight}\nFirst: < {plane.FirstClass.AllowedLuggageWeight}");
            Console.WriteLine("Enter passenger`s luggage (kg):");
            var luggageWeight = Console.ReadLine();

            var boardingClass = plane.GetBoardingClass($"{classType}Class");

            boardingClass.Add(new Passenger
            {
                Id = new Random().Next(),
                Name = name,
                Seat = seat,
                LuggageWeight = int.TryParse(luggageWeight, out var res) && res >= 0 &&
                                res <= boardingClass.AllowedLuggageWeight
                    ? res
                    : throw new InvalidOperationException("Wrong luggage input")
            });
        }
        public static string CreateBoardingMap(this Plane plane) => new StringBuilder()
            .AppendJoin("\n", plane.CreateMap())
            .ToString();
        
        public static string LuggageWeightCheckToString(this Plane plane) => new StringBuilder()
            .AppendLine("Actual luggage weight\t\tAllowed luggage weight")
            .AppendLine(new string('-', 55))
            .Append($"{plane.GetLuggageWeight()}\t\t\t\t{plane.LuggageMaxWeight}")
            .ToString();
    }
}