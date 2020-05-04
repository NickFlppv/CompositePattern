using System;

namespace CompositePattern
{
    public class PlaneBuilder
    {
        private readonly Plane _plane;
        public PlaneBuilder()
        {
            _plane = new Plane();
        }
        public PlaneBuilder WithFirstClass(FirstClass firstClass)
        {
            _plane.FirstClass = firstClass;
            return this;
        }
        
        public PlaneBuilder WithEconomyClass(EconomyClass economyClass)
        {
            _plane.EconomyClass = economyClass;
            return this;
        }
        
        public PlaneBuilder WithBusinessClass(BusinessClass businessClass)
        {
            _plane.BusinessClass = businessClass;
            return this;
        }
        
        public PlaneBuilder WithPilot(Pilot pilot)
        {
            _plane.Stuff.Add(pilot);
            return this;
        }
        
        public PlaneBuilder WithStewardess(Stewardess stewardess)
        {
            _plane.Stuff.Add(stewardess);
            return this;
        }

        public PlaneBuilder WithLuggageMaxWeight(int weight)
        {
            if (weight < 0)
            {
                //todo custom exception
                throw new Exception();
            }
            _plane.LuggageMaxWeight = weight;
            return this;
        }

        public Plane Build() => _plane;
    }
}