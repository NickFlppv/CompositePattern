﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class CompositeBoardingComponent : BoardingComponent
    {
        public CompositeBoardingComponent()
        {
        }

        public int Capacity { get; set; }

        public List<BoardingComponent> Components { get; set; } = new List<BoardingComponent>();


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
            Console.WriteLine("Removed passenger from plane");
        }

        public override void RemoveLuggage(int weight)
        {
            throw new NotImplementedException();
        }

        public override int GetLuggageWeight() => Components.Sum(s => s.LuggageWeight);
        public override string CreateMap() => new StringBuilder()
            .Append($"{GetType().Name}")
            .AppendLine()
            .Append(new string('-', 50))
            .AppendLine()
            .Append("Id\t\tName\tTicket\tLuggage")
            .AppendLine()
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