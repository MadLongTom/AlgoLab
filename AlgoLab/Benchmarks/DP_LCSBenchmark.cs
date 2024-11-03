using AlgoLab.Algorithms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;

namespace AlgoLab.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class DP_LCSBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(RPlotExporter.Default); // 启用 RPlotExporter
            }
        }

        private string X;
        private string Y;
        private int[,] c;
        private char[,] b;

        [Params(100, 200, 500, 1000)] // 设置序列长度
        public int SequenceLength;

        [GlobalSetup]
        public void Setup()
        {
            X = GenerateRandomString(SequenceLength);
            Y = GenerateRandomString(SequenceLength);

            c = new int[SequenceLength + 1, SequenceLength + 1];
            b = new char[SequenceLength + 1, SequenceLength + 1];
        }

        private static string GenerateRandomString(int length)
        {
            Random rand = new();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                // 生成随机大写字母
                chars[i] = (char)rand.Next('A', 'Z' + 1);
            }
            return new string(chars);
        }

        [Benchmark]
        public void LCSLengthBenchmark()
        {
            DynamicProgramming.LCSLength(X, Y, c, b);
        }
    }
}
