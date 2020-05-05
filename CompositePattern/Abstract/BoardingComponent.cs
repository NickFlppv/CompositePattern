using System;

namespace CompositePattern
{
    public abstract class BoardingComponent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Seat { get; set; }
        public int LuggageWeight { get; set; } = 0;
        public virtual int AllowedLuggageWeight { get; set; }

        public abstract void Add(BoardingComponent component);

        public abstract void Remove(BoardingComponent component);

        public abstract bool RemoveLuggage(int weight);

        public abstract int GetLuggageWeight();

        public abstract string CreateMap();
    }
}