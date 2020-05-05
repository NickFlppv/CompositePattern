namespace CompositePattern
{
    public class Pilot : BoardingComponent
    {
        public override void Add(BoardingComponent component)
        {
        }

        public override void Remove(BoardingComponent component)
        {
        }

        public override bool RemoveLuggage(int weight)
        {
            return true;
        }

        public override int GetLuggageWeight()
        {
            return 0;
        }

        public override string CreateMap() => null;
    }
}