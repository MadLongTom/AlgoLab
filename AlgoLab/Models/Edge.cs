namespace AlgoLab.Models
{
    public class Edge(string to, int weight)
    {
        public string To { get; set; } = to;
        public int Weight { get; set; } = weight;
    }
}
