namespace ConfigPC
{
    class LowPrice : IRange
    {
        public decimal Start { get; set; } = 0;
        public decimal End { get; set; } = 40000;
    }

    class MidPrice : IRange
    {
        public decimal Start { get; set; } = 30000;
        public decimal End { get; set; } = 70000;
    }

    class HighPrice : IRange
    {
        public decimal Start { get; set; } = 60000;
        public decimal End { get; set; } = 500000;
    }
}