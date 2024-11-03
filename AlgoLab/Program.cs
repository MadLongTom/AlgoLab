// See https://aka.ms/new-console-template for more information
using AlgoLab.Benchmarks;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<DACBenchmark>();
BenchmarkRunner.Run<DP_MCOBenchmark>();
BenchmarkRunner.Run<DP_LCSBenchmark>();
BenchmarkRunner.Run<Greedy_ASBenchmark>();
BenchmarkRunner.Run<Greedy_HCBenchmark>();
BenchmarkRunner.Run<BackTrackingBenchmark>();
BenchmarkRunner.Run<BAB_BPBenchmark>();
BenchmarkRunner.Run<BAB_SPBenchmark>();