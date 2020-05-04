﻿using System;

namespace CompositePattern
{
    public abstract class BoardingComponent
    {
        public int Luggage { get; set; } = 0;
        public abstract void Add(BoardingComponent component);

        public abstract void Remove(BoardingComponent component);

        public abstract void RemoveLuggage(int weight);

        public abstract int GetLuggageWeight();
    }
}