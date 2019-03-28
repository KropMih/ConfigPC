namespace ConfigPC
{
    class LowRange : Range
    {
        public LowRange(decimal start = 0, decimal end = 40000, decimal slope = 10000) : base (start, end, slope){}
        public float GetEntryFactor(decimal price)
        {
            float result = 0;
            if (price <= (End - Slope))
                result = 1;
            else if (price > End)
                result = 0;
            else
            {
                decimal temp = price - End + Slope;
                result = 1f - ((float)temp / (float)Slope);
            }
            return result;
        }
    }

    class MidRange : Range
    {
        public MidRange(decimal start = 30000, decimal end = 70000, decimal slope = 10000) : base(start, end, slope){}
        public float GetEntryFactor(decimal price)
        {
            float result = 0;
            if (price >= (Start + Slope) && price <= (End - Slope))
                result = 1;
            else if (price < Start || price > End)
                result = 0;
            else if (price <=(Start + Slope) && price > Start)
            {
                decimal temp = price - Start;
                result = ((float)temp / (float)Slope);
            }
            else if (price >= (End - Slope) && price < End)
            {
                decimal temp = price - End + Slope;
                result = 1f - ((float)temp / (float)Slope);
            }
                return result;
        }
    }

    class HighRange : Range
    {
        public HighRange(decimal start = 60000, decimal end = 500000, decimal slope= 10000) : base(start, end, slope){}
        public float GetEntryFactor(decimal price)
        {
            float result = 0;
            if (price >= (Start + Slope))
                result = 1;
            else if (price < Start)
                result = 0;
            else
            {
                decimal temp = price - Start;
                result = ((float)temp / (float)Slope);
            }
            return result;
        }
    }
}