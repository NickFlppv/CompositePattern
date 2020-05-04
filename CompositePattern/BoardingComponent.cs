using System;

namespace CompositePattern
{
    public abstract class BoardingComponent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TicketHash { get; set; }
        public int Luggage { get; set; } = 0;
        public abstract void Add(BoardingComponent component);

        public abstract void Remove(BoardingComponent component);

        public abstract void RemoveLuggage(int weight);

        public abstract int GetLuggageWeight();

        public abstract string CreateMap();
    }
}