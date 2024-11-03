namespace AlgoLab.Models
{
    /// <summary>
    /// 分支限界法结点类
    /// </summary>
    public class BPNode(int n) : IComparable<BPNode>
    {
        public int Level { get; set; } // 层次
        public int Weight { get; set; } // 当前重量
        public int Value { get; set; } // 当前价值
        public double Bound { get; set; } // 上界
        public bool[] Include { get; set; } = new bool[n];

        // 按照上界从大到小进行排序
        public int CompareTo(BPNode? other)
        {
            return other!.Bound.CompareTo(this.Bound);
        }
    }

}
