using AlgoLab.Algorithms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;

namespace AlgoLab.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class DP_MCOBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(RPlotExporter.Default); // 启用 RPlotExporter
            }
        }

        private int[] p;
        private int n;
        private int[,] m;
        private int[,] s;

        [Params(5, 10, 15, 20)] // 设置矩阵链的规模
        public int MatrixCount;

        [GlobalSetup]
        public void Setup()
        {
            n = MatrixCount;
            p = GenerateRandomDimensions(n);
            m = new int[n + 1, n + 1];
            s = new int[n + 1, n + 1];
        }

        /// <summary>
        /// 生成随机的矩阵维度数组
        /// </summary>
        /// <param name="matrixCount">矩阵个数</param>
        /// <returns>矩阵维度数组</returns>
        private static int[] GenerateRandomDimensions(int matrixCount)
        {
            Random rand = new();
            int[] dimensions = new int[matrixCount + 1];
            for (int i = 0; i <= matrixCount; i++)
            {
                dimensions[i] = rand.Next(5, 50); // 随机生成 5 到 50 之间的维度
            }
            return dimensions;
        }

        [Benchmark]
        public void MatrixChainOrderBenchmark()
        {
            DynamicProgramming.MatrixChainOrder(p, n, m, s);
        }
    }
}
