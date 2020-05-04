using System;

namespace CompositePattern
{
    public class Passenger : BoardingComponent
    {
        public Passenger()
        {
            
        }
        
        public override void Add(BoardingComponent component)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(BoardingComponent component)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveLuggage(int weight)
        {
            this.Luggage -= weight;
            Console.WriteLine($"Removed {weight} from luggage");
        }

        public override int GetLuggageWeight()
        {
            return Luggage;
        }

        public override string CreateMap() => null;
    }
}