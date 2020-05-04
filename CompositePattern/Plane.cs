using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositePattern
{
    public class Plane
    {
        public List<BoardingComponent> Components { get; private set; }

        public BoardingComponent FirstClass => Components.FirstOrDefault(c => c.GetType().Name == ClassTypes.FirstClass);
        public BoardingComponent EconomyClass => Components.FirstOrDefault(c => c.GetType().Name == ClassTypes.EconomyClass);
        public BoardingComponent BusinessClass => Components.FirstOrDefault(c => c.GetType().Name == ClassTypes.BusinessClass);
        public int LuggageMaxWeight { get; set; }
        public Plane()
        {
            Components = new List<BoardingComponent>();
        }

        public string CreateBoardingMap()
        {
            var builder = new StringBuilder();
            foreach (var component in Components)
            {
                builder.Append(component.CreateMap());
            }

            return builder.ToString();
        }

        public int GetLuggageWeight() =>
            FirstClass.GetLuggageWeight() + EconomyClass.GetLuggageWeight() + BusinessClass.GetLuggageWeight() +
            Components.Sum(s => s.GetLuggageWeight());
    }
}