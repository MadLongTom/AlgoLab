using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using static AlgoLab.Algorithms.Greedy;

namespace AlgoLab.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class Greedy_HCBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(RPlotExporter.Default); // 启用 RPlotExporter
            }
        }

        private char[] symbols;
        private int[] frequencies;

        [Params(100, 500, 1000, 5000)] // 设置符号数量
        public int SymbolCount;

        [GlobalSetup]
        public void Setup()
        {
            symbols = new char[SymbolCount];
            frequencies = new int[SymbolCount];
            Random rand = new(42); // 固定种子，保证结果可重复

            for (int i = 0; i < SymbolCount; i++)
            {
                symbols[i] = (char)('A' + i % 26); // 使用字母循环生成符号
                frequencies[i] = rand.Next(1, 1000);
            }
        }

        [Benchmark]
        public void BuildHuffmanTreeBenchmark()
        {
            _ = BuildHuffmanTree(symbols, frequencies);
        }
    }
}
