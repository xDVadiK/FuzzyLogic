namespace FuzzyLogic
{
    internal class FuzzyVariable
    {
        public string Name { get; set; }
        public double Start { get; set; }
        public double MinPeak { get; set; }
        public double MaxPeak { get; set; }
        public double End { get; set; }

        public FuzzyVariable(string name, double start, double minPeak, double maxPeak, double end)
        {
            this.Name = name;
            this.Start = start;
            this.MinPeak = minPeak;
            this.MaxPeak = maxPeak;
            this.End = end;
        }

        public double GetMembership(double value)
        {
            if (value <= Start || value >= End) return 0;
            if (value >= MinPeak && value <= MaxPeak) return 1;
            if (value < MinPeak) return (value - Start) / (MinPeak - Start + 1);
            return (MaxPeak - value) / (End - MaxPeak + 1);
        }
    }
}
