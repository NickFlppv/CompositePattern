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
            this.LuggageWeight -= weight;
            Console.WriteLine($"Removed {weight} from luggage");
        }

        public override int GetLuggageWeight()
        {
            return LuggageWeight;
        }

        public override string CreateMap() => null;

        public override string ToString() => $"{Id}\t{Name}\t{TicketHash}\t{LuggageWeight}";
    }
}