using AlgoLab.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using static AlgoLab.Algorithms.BranchAndBound;

namespace AlgoLab.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class BAB_BPBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(RPlotExporter.Default); // 启用 RPlotExporter
            }
        }

        private Item[] items;
        private int W;

        [Params(10, 15, 20)] // 设置物品数量
        public int ItemCount;

        [GlobalSetup]
        public void Setup()
        {
            items = GenerateRandomItems(ItemCount);
            // 背包容量设为总重量的一半
            int totalWeight = 0;
            foreach (var item in items)
            {
                totalWeight += item.Weight;
            }
            W = totalWeight / 2;
        }

        /// <summary>
        /// 生成随机的物品列表
        /// </summary>
        private static Item[] GenerateRandomItems(int count)
        {
            Random rand = new(42); // 固定种子，保证结果可重复
            Item[] items = new Item[count];

            for (int i = 0; i < count; i++)
            {
                int weight = rand.Next(1, 20);
                int value = rand.Next(1, 100);
                items[i] = new Item(i + 1, weight, value);
            }

            return items;
        }

        [Benchmark]
        public void KnapsackBranchAndBoundBenchmark()
        {
            KnapsackSolverBAB solver = new(W, items);
            solver.Solve();
        }
    }
}
