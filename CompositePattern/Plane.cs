using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositePattern
{
    public class Plane
    {
        private CompositeBoardingComponent _economyClass;
        private CompositeBoardingComponent _firstClass;
        private CompositeBoardingComponent _businessClass;
        public List<BoardingComponent> Stuff { get; private set; }

        public CompositeBoardingComponent FirstClass
        {
            get
            {
                if (_firstClass != null)
                {
                    return _firstClass;
                }
                //todo custom exception
                throw new Exception();
            }
            set => _firstClass = value;
        }

        public CompositeBoardingComponent BusinessClass
        {
            get
            {
                if (_businessClass != null)
                {
                    return _businessClass;
                }
                //todo custom exception
                throw new Exception();
            } 
            set => _businessClass = value;
        }

        public CompositeBoardingComponent EconomyClass
        {
            get
            {
                if (_economyClass != null)
                {
                    return _economyClass;
                }
                //todo custom exception
                throw new Exception();
            }

            set => _economyClass = value;
        }

        public int LuggageMaxWeight { get; set; }
        public Plane()
        {
            Stuff = new List<BoardingComponent>();
        }

        public int GetLuggageWeight() =>
            FirstClass.GetLuggageWeight() + EconomyClass.GetLuggageWeight() + BusinessClass.GetLuggageWeight() +
            Stuff.Sum(s => s.GetLuggageWeight());
    }
}