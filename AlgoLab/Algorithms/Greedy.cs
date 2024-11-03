using AlgoLab.Models;

namespace AlgoLab.Algorithms
{
    public class Greedy
    {
        /// <summary>
        /// 贪心算法实现活动选择问题
        /// </summary>
        /// <param name="activities">活动列表</param>
        /// <returns>选择的最大可安排的活动列表</returns>
        public static List<Activity> ActivitySelection(List<Activity> activities)
        {
            // 按照活动的结束时间从小到大排序
            activities.Sort((a, b) => a.Finish.CompareTo(b.Finish));

            //性能优化，预先分配列表大小
            List<Activity> result = new(activities.Count);
            int n = activities.Count;

            // 第一个活动一定被选择
            result.Add(activities[0]);
            int lastFinishTime = activities[0].Finish;

            for (int i = 1; i < n; i++)
                if (activities[i].Start >= lastFinishTime)
                {
                    result.Add(activities[i]);
                    lastFinishTime = activities[i].Finish;
                }

            return result;
        }
        /// <summary>
        /// 构建哈夫曼树
        /// </summary>
        /// <param name="symbols">字符列表</param>
        /// <param name="frequencies">对应的权重列表</param>
        /// <returns>哈夫曼树的根节点</returns>
        public static HuffmanNode BuildHuffmanTree(char[] symbols, int[] frequencies)
        {
            int n = symbols.Length;
            PriorityQueue<HuffmanNode, int> priorityQueue = new();

            // 初始化最小堆，将所有字符作为单节点树插入
            for (int i = 0; i < n; i++)
            {
                HuffmanNode node = new(symbols[i], frequencies[i]);
                priorityQueue.Enqueue(node, node.Frequency);
            }

            // 构建哈夫曼树
            while (priorityQueue.Count > 1)
            {
                // 取出两个最低频率的节点
                HuffmanNode left = priorityQueue.Dequeue();
                HuffmanNode right = priorityQueue.Dequeue();

                // 创建新节点，频率为两子节点频率之和
                HuffmanNode parent = new(null, left.Frequency + right.Frequency)
                {
                    Left = left,
                    Right = right
                };

                // 将新节点插入优先队列
                priorityQueue.Enqueue(parent, parent.Frequency);
            }

            // 返回哈夫曼树的根节点
            return priorityQueue.Dequeue();
        }

        /// <summary>
        /// 生成哈夫曼编码表
        /// </summary>
        /// <param name="root">哈夫曼树根节点</param>
        /// <returns>字符与编码的映射表</returns>
        public static Dictionary<char, string> GenerateCodes(HuffmanNode root)
        {
            Dictionary<char, string> codes = [];
            GenerateCodesHelper(root, "", codes);
            return codes;
        }

        /// <summary>
        /// 递归生成哈夫曼编码
        /// </summary>
        private static void GenerateCodesHelper(HuffmanNode node, string code, Dictionary<char, string> codes)
        {
            if (node == null)
                return;

            // 叶子节点，保存编码
            if (node.Symbol.HasValue)
                codes[node.Symbol.Value] = code;

            // 递归遍历左子树，路径编码加 '0'
            GenerateCodesHelper(node.Left, code + "0", codes);

            // 递归遍历右子树，路径编码加 '1'
            GenerateCodesHelper(node.Right, code + "1", codes);
        }
    }
}
