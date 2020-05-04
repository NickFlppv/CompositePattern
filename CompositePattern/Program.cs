using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //adding passenger to class
            var economyClass = new EconomyClass {Capacity = 150};
            economyClass.AddPassengers(130);
            
            var businessClass = new BusinessClass {Capacity = 20};
            businessClass.AddPassengers(15);
            
            var firstClass = new FirstClass {Capacity = 10};
            firstClass.AddPassengers(5);
            
            var plane = new PlaneBuilder()
                .WithFirstClass(firstClass)
                .WithBusinessClass(businessClass)
                .WithEconomyClass(economyClass)
                .WithPilot(new Pilot())
                .WithPilot(new Pilot())
                .WithStewardess(new Stewardess())
                .WithStewardess(new Stewardess())
                .WithStewardess(new Stewardess())
                .WithLuggageMaxWeight(10000)
                .Build();

            Console.WriteLine("Luggage weight: " + plane.GetLuggageWeight());
            Console.WriteLine("Stuff: " + plane.Stuff.Count);
            Console.WriteLine("Passengers in economy class: " + plane.EconomyClass.Stuff.Count);
            Console.WriteLine("Max weight on passenger in economy class: " + plane.EconomyClass.MaxWeightOnPassenger);
        }
    }
}