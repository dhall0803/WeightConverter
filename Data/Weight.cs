namespace WeightConverter.Data
{
    public enum WeightUnits
    {
        Stones,
        Pounds,
        Kilograms
    }
    struct WeightInStonesAndPounds
    {
        public double Stone { get; set; }
        public double Pounds {get; set;}
    }
    class Weight
    {
        public static double KilogramsInAPound { get; } = 2.204623;
        public static int PoundsInAStone { get; } = 14;
        public double Kilograms { get; set; }
        public double Stones { get; set; }
        public double Pounds { get; set; }
        public WeightInStonesAndPounds StonesAndPounds {get; set;}

        public Weight(double quantity, WeightUnits weightUnit)
        {
            switch (weightUnit)
            {
                case WeightUnits.Kilograms:
                    Kilograms = quantity;
                    Stones = KilogramsToStones(quantity);
                    Pounds = KilogramsToPounds(quantity);
                    StonesAndPounds = PoundsToStonesAndPounds(Pounds);
                    break;
                case WeightUnits.Stones:
                    Stones = quantity;
                    Kilograms = StonesToKilograms(Stones);
                    Pounds = StoneToPounds(Stones);
                    StonesAndPounds = PoundsToStonesAndPounds(Pounds);
                    break;
                case WeightUnits.Pounds:
                    Pounds = quantity;
                    Stones = PoundsToStones(Pounds);
                    Kilograms = PoundsToKilograms(Pounds);
                    StonesAndPounds = PoundsToStonesAndPounds(Pounds);
                    break;
            }
        }

        public static double KilogramsToPounds(double kilograms) => Math.Round(kilograms * KilogramsInAPound, 2);
        public static double KilogramsToStones(double kilograms) => Math.Round(KilogramsToPounds(kilograms) / PoundsInAStone, 2);
        public static double StoneToPounds(double stone) => Math.Round(stone * PoundsInAStone, 2);
        public static double PoundsToStones(double pounds) => Math.Round(pounds / PoundsInAStone, 2);
        public static double PoundsToKilograms(double pounds) => Math.Round(pounds / KilogramsInAPound, 2);
        public static double StonesToKilograms(double stone) => Math.Round(StoneToPounds(stone) / KilogramsInAPound, 2);
        public static WeightInStonesAndPounds PoundsToStonesAndPounds(double pounds) => new WeightInStonesAndPounds
        { 
            Stone = Math.Floor(PoundsToStones(pounds)), Pounds = Math.Round(pounds % PoundsInAStone, 2)
        };
        
    }
}