using AlgoLab.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using static AlgoLab.Algorithms.Greedy;

namespace AlgoLab.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Config))]
    public class Greedy_ASBenchmark
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddExporter(RPlotExporter.Default); // 启用 RPlotExporter
            }
        }

        private List<Activity> activities;

        [Params(1000, 5000, 10000, 50000)] // 设置活动数量
        public int ActivityCount;

        [GlobalSetup]
        public void Setup()
        {
            activities = GenerateRandomActivities(ActivityCount);
        }

        /// <summary>
        /// 生成随机的活动列表
        /// </summary>
        /// <param name="count">活动数量</param>
        /// <returns>随机活动列表</returns>
        private static List<Activity> GenerateRandomActivities(int count)
        {
            Random rand = new(42); // 固定种子，保证结果可重复
            List<Activity> activities = [];

            for (int i = 0; i < count; i++)
            {
                int start = rand.Next(0, 100000);
                int finish = start + rand.Next(1, 1000); // 确保结束时间大于开始时间
                activities.Add(new Activity(i + 1, start, finish));
            }

            return activities;
        }

        [Benchmark]
        public void ActivitySelectionBenchmarkTest()
        {
            _ = ActivitySelection(activities);
        }
    }
}

