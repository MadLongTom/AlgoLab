# AlgoLab
使用C#编写的算法课程实验代码，使用MSTest进行功能测试，使用BenchmarkDotnet进行性能测试。
## Tests
1. 用分治算法设计实现二分搜索问题、快速排序问题、线性时间选择问题
2. 用动态规划算法设计实现矩阵连乘问题、最长公共子序列问题
3. 用贪心算法设计并实现活动安排问题、哈夫曼编码问题
4. 用回溯法设计并实现 0-1 背包问题
5. 用分支限界法设计并实现 0-1背包问题、单源最短路径问题
## Functional Unit Test Report
测试项目已集成10个算法的30个单元测试，代码覆盖率100%
```
测试摘要: 总计: 30, 失败: 0, 成功: 30, 已跳过: 0, 持续时间: 0.2 秒
```
## Performance Test Report
```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2161)
AMD Ryzen 7 9700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
```
| Method       | N     | Mean              | Error          | StdDev         | Allocated |
|------------- |------ |------------------:|---------------:|---------------:|----------:|
| **BinarySearch** | **10**    |          **1.368 ns** |      **0.0167 ns** |      **0.0156 ns** |         **-** |
| **BinarySearch** | **100**   |          **2.735 ns** |      **0.0045 ns** |      **0.0035 ns** |         **-** |
| **BinarySearch** | **1000**  |          **4.523 ns** |      **0.0045 ns** |      **0.0042 ns** |         **-** |
| **BinarySearch** | **10000** |          **6.734 ns** |      **0.0170 ns** |      **0.0159 ns** |         **-** |
| **QuickSelect**  | **10**    |         **47.181 ns** |      **0.3449 ns** |      **0.2880 ns** |         **-** |
| **QuickSelect**  | **100**   |        **221.412 ns** |      **1.9843 ns** |      **1.8561 ns** |         **-** |
| **QuickSelect**  | **1000**  |      **1,113.518 ns** |      **2.4512 ns** |      **2.1729 ns** |         **-** |
| **QuickSelect**  | **10000** |     **12,005.161 ns** |     **48.6697 ns** |     **45.5256 ns** |         **-** |
| **QuickSort**    | **10**    |         **30.323 ns** |      **0.0342 ns** |      **0.0303 ns** |         **-** |
| **QuickSort**    | **100**   |      **2,874.391 ns** |      **4.1966 ns** |      **3.9255 ns** |         **-** |
| **QuickSort**    | **1000**  |    **220,997.816 ns** |    **285.5801 ns** |    **267.1318 ns** |         **-** |
| **QuickSort**    | **10000** | **21,670,936.354 ns** | **40,537.3262 ns** | **37,918.6401 ns** |       **4 B** |

| Method                    | MatrixCount | Mean        | Error     | StdDev    | Allocated |
|-------------------------- |------------ |------------:|----------:|----------:|----------:|
| **MatrixChainOrderBenchmark** | **5**           |    **38.54 ns** |  **0.544 ns** |  **0.509 ns** |         **-** |
| **MatrixChainOrderBenchmark** | **10**          |   **280.82 ns** |  **3.656 ns** |  **3.420 ns** |         **-** |
| **MatrixChainOrderBenchmark** | **15**          |   **953.14 ns** | **12.428 ns** | **11.625 ns** |         **-** |
| **MatrixChainOrderBenchmark** | **20**          | **1,941.38 ns** | **30.400 ns** | **28.436 ns** |         **-** |

| Method             | SequenceLength | Mean        | Error    | StdDev   | Allocated |
|------------------- |--------------- |------------:|---------:|---------:|----------:|
| **LCSLengthBenchmark** | **100**            |    **19.33 μs** | **0.111 μs** | **0.098 μs** |         **-** |
| **LCSLengthBenchmark** | **200**            |    **75.11 μs** | **0.440 μs** | **0.390 μs** |         **-** |
| **LCSLengthBenchmark** | **500**            |   **472.72 μs** | **1.279 μs** | **1.068 μs** |         **-** |
| **LCSLengthBenchmark** | **1000**           | **1,944.55 μs** | **8.649 μs** | **7.667 μs** |       **1 B** |

| Method                         | ActivityCount | Mean       | Error      | StdDev    | Gen0     | Gen1     | Gen2     | Allocated |
|------------------------------- |-------------- |-----------:|-----------:|----------:|---------:|---------:|---------:|----------:|
| **ActivitySelectionBenchmarkTest** | **1000**          |   **6.881 μs** |  **0.0760 μs** | **0.0711 μs** |   **0.4807** |        **-** |        **-** |   **7.87 KB** |
| **ActivitySelectionBenchmarkTest** | **5000**          |  **35.000 μs** |  **0.6822 μs** | **0.6382 μs** |   **2.3804** |   **0.2441** |        **-** |  **39.12 KB** |
| **ActivitySelectionBenchmarkTest** | **10000**         |  **73.984 μs** |  **1.4286 μs** | **1.8576 μs** |   **4.7607** |   **0.8545** |        **-** |  **78.18 KB** |
| **ActivitySelectionBenchmarkTest** | **50000**         | **672.723 μs** | **10.3551 μs** | **9.6862 μs** | **124.0234** | **124.0234** | **124.0234** | **390.72 KB** |

| Method                    | SymbolCount | Mean       | Error     | StdDev    | Gen0    | Gen1    | Gen2    | Allocated |
|-------------------------- |------------ |-----------:|----------:|----------:|--------:|--------:|--------:|----------:|
| **BuildHuffmanTreeBenchmark** | **100**         |   **2.153 μs** | **0.0109 μs** | **0.0096 μs** |  **0.7248** |  **0.0076** |       **-** |   **11.9 KB** |
| **BuildHuffmanTreeBenchmark** | **500**         |  **14.663 μs** | **0.2458 μs** | **0.2299 μs** |  **3.3722** |  **0.3052** |       **-** |   **55.2 KB** |
| **BuildHuffmanTreeBenchmark** | **1000**        |  **31.615 μs** | **0.6268 μs** | **1.2372 μs** |  **6.7139** |  **1.0986** |       **-** | **110.28 KB** |
| **BuildHuffmanTreeBenchmark** | **5000**        | **662.679 μs** | **6.0070 μs** | **5.3251 μs** | **41.0156** | **41.0156** | **41.0156** | **646.87 KB** |

| Method                        | ItemCount | Mean         | Error     | StdDev    | Gen0   | Allocated |
|------------------------------ |---------- |-------------:|----------:|----------:|-------:|----------:|
| **KnapsackBacktrackingBenchmark** | **10**        |     **1.932 μs** | **0.0225 μs** | **0.0199 μs** | **0.0114** |     **192 B** |
| **KnapsackBacktrackingBenchmark** | **15**        |    **73.863 μs** | **0.2075 μs** | **0.1732 μs** |      **-** |     **240 B** |
| **KnapsackBacktrackingBenchmark** | **20**        | **2,255.401 μs** | **4.5415 μs** | **3.7924 μs** |      **-** |     **274 B** |

| Method                          | ItemCount | Mean      | Error     | StdDev    | Gen0    | Gen1   | Allocated |
|-------------------------------- |---------- |----------:|----------:|----------:|--------:|-------:|----------:|
| **KnapsackBranchAndBoundBenchmark** | **10**        |  **5.742 μs** | **0.0234 μs** | **0.0219 μs** |  **2.2202** |      **-** |  **36.31 KB** |
| **KnapsackBranchAndBoundBenchmark** | **15**        | **34.613 μs** | **0.1710 μs** | **0.1428 μs** | **12.1460** |      **-** |  **198.8 KB** |
| **KnapsackBranchAndBoundBenchmark** | **20**        | **78.500 μs** | **0.9401 μs** | **0.7850 μs** | **28.5645** | **0.1221** | **468.09 KB** |

| Method         | VerticesCount | EdgesCount | Mean       | Error     | StdDev    | Gen0     | Gen1    | Gen2    | Allocated  |
|--------------- |-------------- |----------- |-----------:|----------:|----------:|---------:|--------:|--------:|-----------:|
| **BenchmarkGraph** | **10**            | **20**         |   **2.159 μs** | **0.0192 μs** | **0.0160 μs** |   **0.5569** |       **-** |       **-** |     **9.1 KB** |
| **BenchmarkGraph** | **10**            | **500**        |  **32.242 μs** | **0.2303 μs** | **0.2154 μs** |   **5.0049** |  **0.1221** |       **-** |   **82.02 KB** |
| **BenchmarkGraph** | **10**            | **5000**       | **336.604 μs** | **6.5291 μs** | **6.9860 μs** |  **58.5938** | **58.5938** | **58.5938** |  **711.32 KB** |
| **BenchmarkGraph** | **100**           | **20**         |   **5.452 μs** | **0.0428 μs** | **0.0380 μs** |   **1.0834** |  **0.0229** |       **-** |   **17.72 KB** |
| **BenchmarkGraph** | **100**           | **500**        |  **51.313 μs** | **0.2915 μs** | **0.2584 μs** |   **9.7656** |  **0.4883** |       **-** |  **159.71 KB** |
| **BenchmarkGraph** | **100**           | **5000**       | **385.599 μs** | **2.3808 μs** | **1.8588 μs** |  **58.5938** | **58.5938** | **58.5938** |  **828.55 KB** |
| **BenchmarkGraph** | **1000**          | **20**         |  **42.617 μs** | **0.1953 μs** | **0.1827 μs** |   **8.4839** |  **1.5259** |       **-** |  **139.33 KB** |
| **BenchmarkGraph** | **1000**          | **500**        |  **68.975 μs** | **0.4151 μs** | **0.3883 μs** |  **11.4746** |  **1.9531** |       **-** |  **188.55 KB** |
| **BenchmarkGraph** | **1000**          | **5000**       | **643.545 μs** | **4.4998 μs** | **4.2092 μs** | **136.7188** | **68.3594** | **68.3594** | **1609.28 KB** |
