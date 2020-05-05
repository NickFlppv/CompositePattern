using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public abstract class CompositeBoardingComponent : BoardingComponent
    {

        private List<BoardingComponent> Components { get; set; } = new List<BoardingComponent>();

        public int Capacity { get; set; }

        public override void Add(BoardingComponent component)
        {
            if (Capacity - Components.Count < 0)
            {
                throw new Exception();
            }

            Components.Add(component);
        }

        public override void Remove(BoardingComponent component)
        {
            Components.Remove(component);
            Console.WriteLine($"Removed passenger from {GetType().Name}");
        }

        public override bool RemoveLuggage(int weight)
        {
            Components
                .ForEach(p =>
                {
                    if (weight <= 0) return;

                    weight -= p.LuggageWeight;
                    p.LuggageWeight = 0;
                });
            return true;
        }

        public override int GetLuggageWeight() => Components.Sum(s => s.LuggageWeight);
        public override string CreateMap() => new StringBuilder()
            .AppendLine($"{GetType().Name}")
            .AppendLine(new string('-', 50))
            .AppendLine("Id\t\tName\tSeat\tLuggage")
            .AppendJoin("\n", Components.Select(c => c.ToString()))
            .AppendLine()
            .Append(new string('-', 50))
            .ToString();

        public void AddPassengers(int count)
        {
            if (count + Components.Count > Capacity)
            {
                //todo custom exception
                throw new Exception();
            }

            for (int i = 0; i < count; i++)
            {
                Add(new Passenger{LuggageWeight = 20});
            }

            Console.WriteLine($"Added {count} passengers");
        }
    }
}