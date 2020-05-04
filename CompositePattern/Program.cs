using System;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var plane = CreatePlane();
            HandleInput(plane);
        }

        private static void HandleInput(Plane plane)
        {
            while (true)
            {
                ShowMenu();
                var key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '0': 
                        return;
                }
            }
        }

        private static Plane CreatePlane()
        {
            var economyClass = new EconomyClass {Capacity = 150};

            var businessClass = new BusinessClass {Capacity = 20};

            var firstClass = new FirstClass {Capacity = 10};

            var plane = new PlaneBuilder()
                .WithEconomyClass(economyClass)
                .WithBusinessClass(businessClass)
                .WithFirstClass(firstClass)
                .WithPilot(new Pilot())
                .WithPilot(new Pilot())
                .WithStewardess(new Stewardess())
                .WithStewardess(new Stewardess())
                .WithStewardess(new Stewardess())
                .WithLuggageMaxWeight(10000)
                .Build();
            foreach (var s in plane.Components)
            {
                Console.WriteLine(s.GetType().Name);
            }

            return plane;
        }

        private static void ShowMenu()
        {
            
        }
  
    }
}