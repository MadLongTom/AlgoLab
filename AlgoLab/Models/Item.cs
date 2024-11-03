namespace AlgoLab.Models
{
    public class Item(int index, int weight, int value)
    {
        public int Index { get; set; } = index;
        public int Weight { get; set; } = weight;
        public int Value { get; set; } = value;
        public double Density => (double)Value / Weight;
    }
}
