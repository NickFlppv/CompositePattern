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
            if (_plane.FirstClass != null)
            {
                //todo custom exception
                throw new Exception();
            }
            _plane.Components.Add(firstClass);
            return this;
        }
        
        public PlaneBuilder WithEconomyClass(EconomyClass economyClass)
        {
            if (_plane.EconomyClass != null)
            {
                //todo custom exception
                throw new Exception();
            }
            _plane.Components.Add(economyClass);
            return this;
        }
        
        public PlaneBuilder WithBusinessClass(BusinessClass businessClass)
        {
            if (_plane.BusinessClass != null)
            {
                //todo custom exception
                throw new Exception();
            }
            _plane.Components.Add(businessClass);
            return this;
        }
        
        public PlaneBuilder WithPilot(Pilot pilot)
        {
            _plane.Components.Add(pilot);
            return this;
        }
        
        public PlaneBuilder WithStewardess(Stewardess stewardess)
        {
            _plane.Components.Add(stewardess);
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