using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class Plane
    {
        public List<BoardingComponent> Components { get; private set; }

        public BoardingComponent FirstClass =>
            Components.FirstOrDefault(c => c.GetType().Name == ClassTypes.FirstClass);

        public BoardingComponent EconomyClass =>
            Components.FirstOrDefault(c => c.GetType().Name == ClassTypes.EconomyClass);

        public BoardingComponent BusinessClass =>
            Components.FirstOrDefault(c => c.GetType().Name == ClassTypes.BusinessClass);

        public int LuggageMaxWeight { get; set; } = 60 * 180;

        public Plane()
        {
            Components = new List<BoardingComponent>();
        }

        public string CreateBoardingMap() => new StringBuilder()
            .AppendJoin("\n", Components.Select(c => c.CreateMap()))
            .ToString();

        public int GetLuggageWeight() => Components.Sum(s => s.GetLuggageWeight());
    }
}