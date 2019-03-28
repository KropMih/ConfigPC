namespace ConfigPC
{
    abstract class Range
    {
        public decimal Start { get; set; }
        public decimal End { get; set; }
        public decimal Slope { get; set; }
        public Range(decimal start, decimal end, decimal slope)
        {
            Start = start;
            End = end;
            Slope = slope;
        }
    }
}
