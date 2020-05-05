using System;

namespace CompositePattern
{
    public class Passenger : BoardingComponent
    {
        public override void Add(BoardingComponent component)
        {
        }

        public override void Remove(BoardingComponent component)
        {
        }

        public override bool RemoveLuggage(int weight)
        {
            this.LuggageWeight -= weight;
            Console.WriteLine($"Removed {weight} from luggage");
            return true;
        }

        public override int GetLuggageWeight()
        {
            return LuggageWeight;
        }

        public override string CreateMap() => null;

        public override string ToString() => $"{Id}\t{Name}\t{Seat}\t{LuggageWeight}";
    }
}