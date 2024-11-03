using AlgoLab.Models;

namespace AlgoLab.Algorithms
{
    public class BranchAndBound
    {
        public class KnapsackSolverBAB
        {
            private readonly int n; // 物品数量
            private readonly int W; // 背包容量
            private readonly Item[] items; // 物品数组
            public int maxValue; // 最大总价值
            public bool[] bestItems; // 最佳物品选择方案

            public KnapsackSolverBAB(int W, Item[] items)
            {
                this.W = W;
                this.items = items;
                n = items.Length;

                // 按价值密度从大到小排序
                Array.Sort(this.items, (a, b) => b.Density.CompareTo(a.Density));
            }

            /// <summary>
            /// 计算结点的上界
            /// </summary>
            private double CalculateBound(BPNode node)
            {
                if (node.Weight >= W)
                    return 0;

                double bound = node.Value;
                int totalWeight = node.Weight;
                int i = node.Level;

                while (i < n && totalWeight + items[i].Weight <= W)
                {
                    totalWeight += items[i].Weight;
                    bound += items[i].Value;
                    i++;
                }

                // 装入部分物品
                if (i < n)
                    bound += (W - totalWeight) * items[i].Density;

                return bound;
            }

            public void Solve()
            {
                PriorityQueue<BPNode, double> queue = new();

                BPNode root = new(n)
                {
                    Level = 0,
                    Weight = 0,
                    Value = 0,
                };
                root.Bound = CalculateBound(root);

                queue.Enqueue(root, root.Bound);

                maxValue = 0;
                bestItems = new bool[n];

                while (queue.Count > 0)
                {
                    BPNode node = queue.Dequeue();

                    if (node.Bound <= maxValue || node.Level >= n)
                        continue;

                    // 左子结点：选择当前物品
                    BPNode leftNode = new(n)
                    {
                        Level = node.Level + 1,
                        Weight = node.Weight + items[node.Level].Weight,
                        Value = node.Value + items[node.Level].Value,
                        Include = (bool[])node.Include.Clone()
                    };
                    leftNode.Include[node.Level] = true;

                    if (leftNode.Weight <= W && leftNode.Value > maxValue)
                    {
                        maxValue = leftNode.Value;
                        bestItems = leftNode.Include;
                    }

                    leftNode.Bound = CalculateBound(leftNode);
                    if (leftNode.Bound > maxValue)
                        queue.Enqueue(leftNode, leftNode.Bound);

                    // 右子结点：不选择当前物品
                    BPNode rightNode = new(n)
                    {
                        Level = node.Level + 1,
                        Weight = node.Weight,
                        Value = node.Value,
                        Include = node.Include
                    };
                    rightNode.Include[node.Level] = false;
                    rightNode.Bound = CalculateBound(rightNode);

                    if (rightNode.Bound > maxValue)
                        queue.Enqueue(rightNode, rightNode.Bound);
                }
            }
        }

        public static Dictionary<string, int> FindShortestPaths(Graph graph, string source)
        {
            Dictionary<string, int> distances = new(graph.Vertexes.Count);
            HashSet<string> visited = [];
            var queue = new PriorityQueue<string, int>();

            // 初始化距离和源点
            foreach (var vertex in graph.Vertexes)
                distances[vertex] = int.MaxValue;
            distances[source] = 0;
            queue.Enqueue(source, 0);

            while (queue.Count > 0)
            {
                queue.TryDequeue(out string currentVertex, out _);

                if (visited.Contains(currentVertex))
                    continue;

                visited.Add(currentVertex);

                // 检查当前节点是否在邻接表中
                if (!graph.AdjacencyList.ContainsKey(currentVertex))
                    continue;

                // 遍历相邻节点
                foreach (var (neighbor, newDistance) in
                from Edge edge in graph.AdjacencyList[currentVertex]
                let neighbor = edge.To
                let newDistance = distances[currentVertex] + edge.Weight
                select (neighbor, newDistance))
                {
                    // 如果邻居节点不在 distances 中，进行初始化
                    if (!distances.TryGetValue(neighbor, out int value))
                    {
                        value = int.MaxValue;
                        distances[neighbor] = value;
                    }

                    if (newDistance < value)
                    {
                        distances[neighbor] = newDistance;
                        queue.Enqueue(neighbor, newDistance);
                    }
                }
            }

            return distances;
        }


    }
}
