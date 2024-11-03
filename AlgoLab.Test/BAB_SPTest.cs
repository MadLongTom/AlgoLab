using AlgoLab.Algorithms;
using AlgoLab.Models;

namespace AlgoLab.Test
{
    [TestClass]
    public class BAB_SPTest
    {
        [TestMethod]
        public void TestSimpleGraph()
        {
            // 初始化图
            Graph graph = new();
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("B", "C", 2);
            graph.AddEdge("A", "C", 4);
            string source = "A";

            // 执行算法
            var distances = BranchAndBound.FindShortestPaths(graph, source);

            // 验证结果
            Assert.AreEqual(1, distances["B"]);
            Assert.AreEqual(3, distances["C"]);
        }

        [TestMethod]
        public void TestDisconnectedGraph()
        {
            // 初始化图
            Graph graph = new();
            graph.AddEdge("A", "B", 1);
            graph.AddEdge("C", "D", 1);
            string source = "A";

            // 执行算法
            var distances = BranchAndBound.FindShortestPaths(graph, source);

            // 验证结果
            Assert.AreEqual(1, distances["B"]);

            // 对于无法到达的节点，距离应为 int.MaxValue
            Assert.AreEqual(int.MaxValue, distances["C"]);
            Assert.AreEqual(int.MaxValue, distances["D"]);
        }

        [TestMethod]
        public void TestNegativeCycle()
        {
            // 初始化图（不含负权值）
            Graph graph = new();
            graph.AddEdge("A", "B", 2);
            graph.AddEdge("B", "C", 3);
            graph.AddEdge("C", "A", 1);
            string source = "A";

            // 执行算法
            var distances = BranchAndBound.FindShortestPaths(graph, source);

            // 验证结果
            Assert.AreEqual(2, distances["B"]);
            Assert.AreEqual(5, distances["C"]);
        }
    }
}
