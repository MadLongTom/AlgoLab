using AlgoLab.Algorithms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;

namespace AlgoLab.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class DACBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(RPlotExporter.Default); // 启用 RPlotExporter
            }
        }
        private int[] arr;
        private int k;
        private int target;
        [Params(10, 100, 1000, 10000)]
        public int N;
        [GlobalSetup]
        public void Setup()
        {
            arr = GenerateRandomArray(N);
            Random rand = new();
            k = rand.Next(1, N); // k 在 1 到数组长度之间
            target = rand.Next(0, N);
        }
        private static int[] GenerateRandomArray(int size)
        {
            int[] arr = new int[size];
            Random rand = new();

            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next();
            }
            return arr;
        }
        [Benchmark]
        [BenchmarkCategory("QuickSort")]
        public void QuickSort()
        {
            DivideAndConquer.QuickSort(arr, 0, arr.Length - 1);
        }

        [Benchmark]
        [BenchmarkCategory("QuickSelect")]
        public void QuickSelect()
        {
            DivideAndConquer.QuickSelect(arr, Math.Min(k, arr.Length));
        }

        [Benchmark]
        [BenchmarkCategory("BinarySearch")]
        public void BinarySearch()
        {
            DivideAndConquer.BinarySearch(arr, target);
        }
    }
}
