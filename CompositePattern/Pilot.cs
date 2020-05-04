namespace CompositePattern
{
    public class Pilot : BoardingComponent
    {
        public override void Add(BoardingComponent component)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(BoardingComponent component)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveLuggage(int weight)
        {
            throw new System.NotImplementedException();
        }

        public override int GetLuggageWeight()
        {
            return 0;
        }
    }
}