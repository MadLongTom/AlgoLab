namespace AlgoLab.Models
{
    /// <summary>
    /// 哈夫曼树节点类
    /// </summary>
    public class HuffmanNode(char? symbol, int frequency) : IComparable<HuffmanNode>
    {
        public char? Symbol { get; set; } = symbol;
        public int Frequency { get; set; } = frequency;
        public HuffmanNode Left { get; set; } = null;
        public HuffmanNode Right { get; set; } = null;

        // 实现 CompareTo 方法，以便在优先队列中排序
        public int CompareTo(HuffmanNode? other)
        {
            return Frequency.CompareTo(other!.Frequency);
        }
    }
}
