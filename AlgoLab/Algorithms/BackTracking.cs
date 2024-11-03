using AlgoLab.Models;

namespace AlgoLab.Algorithms
{
    public class BackTracking
    {
        public class KnapsackSolverBT
        {
            private readonly int n; // 物品数量
            private readonly int W; // 背包容量
            private readonly Item[] items; // 物品数组
            private readonly int[] x; // 当前物品选择方案
            public int[] bestX; // 最佳物品选择方案
            private int cw; // 当前重量
            private int cv; // 当前价值
            public int vmax; // 最大总价值

            public KnapsackSolverBT(int W, Item[] items)
            {
                this.W = W;
                this.items = items;
                this.n = items.Length;
                x = new int[n];
                bestX = new int[n];

                // 按照单位价值从大到小排序
                Array.Sort(this.items, (a, b) => b.Density.CompareTo(a.Density));
            }

            public void Solve() => Backtrack(0);

            private void Backtrack(int i)
            {
                if (i >= n)
                {
                    if (cv > vmax)
                    {
                        vmax = cv;
                        Array.Copy(x, bestX, n);
                    }
                    return;
                }

                // 尝试选取第 i 个物品
                if (cw + items[i].Weight <= W)
                {
                    x[i] = 1;
                    cw += items[i].Weight;
                    cv += items[i].Value;

                    Backtrack(i + 1);

                    // 回溯
                    cw -= items[i].Weight;
                    cv -= items[i].Value;
                }

                // 不选取第 i 个物品
                x[i] = 0;
                Backtrack(i + 1);
            }
        }
    }
}
