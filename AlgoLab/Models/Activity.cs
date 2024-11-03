namespace AlgoLab.Models
{
    /// <summary>
    /// 活动类，包含活动编号、开始时间和结束时间
    /// </summary>
    public class Activity(int id, int start, int finish)
    {
        public int Id { get; set; } = id;
        public int Start { get; set; } = start;
        public int Finish { get; set; } = finish;
    }
}
