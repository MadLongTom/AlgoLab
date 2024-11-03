namespace AlgoLab.Models
{
    public class Graph
    {
        public Dictionary<string, List<Edge>> AdjacencyList { get; set; }
        public List<string> Vertexes => ((IEnumerable<string>)[.. AdjacencyList.Keys, .. AdjacencyList.Values.SelectMany(v => v).Select(e => e.To)]).Distinct().ToList();

        public Graph()
        {
            AdjacencyList = [];
        }

        // 添加边
        public void AddEdge(string from, string to, int weight)
        {
            if (!AdjacencyList.TryGetValue(from, out List<Edge>? value))
            {
                value = ([]);
                AdjacencyList[from] = value;
            }

            value.Add(new Edge(to, weight));
        }
    }
}
