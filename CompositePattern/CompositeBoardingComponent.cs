using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositePattern
{
    public class CompositeBoardingComponent : BoardingComponent
    {
        public CompositeBoardingComponent()
        {
            
        }
        
        public CompositeBoardingComponent(int maxWeightOnPassenger, int capacity)
        {
            MaxWeightOnPassenger = maxWeightOnPassenger;
            Capacity = capacity;
        }

        public virtual int MaxWeightOnPassenger { get; } = 60;

        public int Capacity { get; set; }
        public List<BoardingComponent> Stuff { get; set; } = new List<BoardingComponent>();


        public override void Add(BoardingComponent component)
        {
            if (Capacity - Stuff.Count < 0)
            {
                throw new Exception();
            }

            Stuff.Add(component);
        }

        public override void Remove(BoardingComponent component)
        {
            Stuff.Remove(component);
            Console.WriteLine("Removed passenger from plane");
        }

        public override void RemoveLuggage(int weight)
        {
            throw new NotImplementedException();
        }

        public override int GetLuggageWeight() => Stuff.Sum(s => s.Luggage);

        public void AddPassengers(int count)
        {
            if (count + Stuff.Count > Capacity)
            {
                //todo custom exception
                throw new Exception();
            }

            for (int i = 0; i < count; i++)
            {
                Add(new Passenger{Luggage = 20});
            }

            Console.WriteLine($"Added {count} passengers");
        }
    }
}