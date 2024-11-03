using AlgoLab.Models;
using static AlgoLab.Algorithms.Greedy;

namespace AlgoLab.Test
{
    [TestClass]
    public class Greedy_ASTest
    {
        /// <summary>
        /// 封装测试逻辑的方法
        /// </summary>
        /// <param name="activities">活动列表</param>
        /// <param name="expectedCount">预期的最大可安排活动数</param>
        /// <param name="expectedIds">预期选择的活动编号列表</param>
        private static void RunTest(List<Activity> activities, int expectedCount, List<int> expectedIds)
        {
            var selectedActivities = ActivitySelection(activities);

            // 验证选择的活动数是否正确
            Assert.AreEqual(expectedCount, selectedActivities.Count, "选择的活动数量不正确");

            // 验证选择的活动编号是否与预期一致
            List<int> selectedIds = [.. selectedActivities.Select(activity => activity.Id)];
            CollectionAssert.AreEqual(expectedIds, selectedIds, "选择的活动编号与预期不符");
        }

        [TestMethod]
        public void TestCase1()
        {
            List<Activity> activities =
            [
                new Activity(1, 1, 4),
                new Activity(2, 3, 5),
                new Activity(3, 0, 6),
                new Activity(4, 5, 7),
                new Activity(5, 3, 9),
                new Activity(6, 5, 9),
                new Activity(7, 6, 10),
                new Activity(8, 8, 11),
                new Activity(9, 8, 12),
                new Activity(10, 2, 14),
                new Activity(11, 12, 16)
            ];

            int expectedCount = 4;
            List<int> expectedIds = [1, 4, 8, 11];

            RunTest(activities, expectedCount, expectedIds);
        }

        [TestMethod]
        public void TestCase2()
        {
            List<Activity> activities =
            [
                new Activity(1, 1, 2),
                new Activity(2, 2, 3),
                new Activity(3, 3, 4),
                new Activity(4, 4, 5),
                new Activity(5, 5, 6)
            ];

            int expectedCount = 5;
            List<int> expectedIds = [1, 2, 3, 4, 5];

            RunTest(activities, expectedCount, expectedIds);
        }

        [TestMethod]
        public void TestCase3()
        {
            List<Activity> activities =
            [
                new Activity(1, 7, 9),
                new Activity(2, 0, 2),
                new Activity(3, 3, 5),
                new Activity(4, 1, 4),
                new Activity(5, 5, 8),
                new Activity(6, 5, 7)
            ];

            int expectedCount = 4;
            List<int> expectedIds = [2, 3, 6, 1];

            RunTest(activities, expectedCount, expectedIds);
        }
    }
}
