using AlgoLab.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using static AlgoLab.Algorithms.BranchAndBound;

namespace AlgoLab.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class BAB_SPBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(RPlotExporter.Default); // 启用 RPlotExporter
            }
        }

        private Graph graph;

        [Params(10, 100, 1000)]
        public int VerticesCount;

        [Params(20, 500, 5000)]
        public int EdgesCount;

        [GlobalSetup]
        public void Setup()
        {
            graph = CreateGraph(VerticesCount, EdgesCount);
        }

        private static Graph CreateGraph(int verticesCount, int edgesCount)
        {
            Graph graph = new();

            for (int i = 0; i < edgesCount; i++)
            {
                string from = $"V{Random.Shared.Next(verticesCount)}";
                string to = $"V{Random.Shared.Next(verticesCount)}";
                int weight = Random.Shared.Next(1, 10);

                graph.AddEdge(from, to, weight);
            }

            // 确保所有顶点都在图中
            for (int i = 0; i < verticesCount; i++)
            {
                string vertex = $"V{i}";
                if (!graph.AdjacencyList.ContainsKey(vertex))
                {
                    graph.AdjacencyList[vertex] = [];
                }
            }

            return graph;
        }

        [Benchmark]
        public void BenchmarkGraph()
        {
            FindShortestPaths(graph, "V0");
        }
    }
}

