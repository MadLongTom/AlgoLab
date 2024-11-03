using AlgoLab.Models;
using static AlgoLab.Algorithms.BranchAndBound;

namespace AlgoLab.Test
{
    [TestClass]
    public class BAB_BPTest
    {
        /// <summary>
        /// 封装测试逻辑的方法
        /// </summary>
        private static void RunTest(int W, Item[] items, int expectedValue, List<int> expectedIndices)
        {
            KnapsackSolverBAB solver = new(W, items);
            solver.Solve();

            // 验证最大总价值是否正确
            Assert.AreEqual(expectedValue, solver.maxValue, "最大总价值不正确");

            // 验证选择的物品索引是否与预期一致
            List<int> selectedItems = [];
            for (int i = 0; i < items.Length; i++)
            {
                if (solver.bestItems[i])
                {
                    selectedItems.Add(items[i].Index);
                }
            }
            selectedItems.Sort();

            CollectionAssert.AreEqual(expectedIndices, selectedItems, "选择的物品索引与预期不符");
        }

        [TestMethod]
        public void TestCase1()
        {
            Item[] items =
            [
                new(1, 2, 6),
                new(2, 2, 3),
                new(3, 6, 5),
                new(4, 5, 4),
                new(5, 4, 6)
            ];
            int W = 10;
            int expectedValue = 15;
            List<int> expectedIndices = [1, 2, 5]; // 物品 1、2、5

            RunTest(W, items, expectedValue, expectedIndices);
        }

        [TestMethod]
        public void TestCase2()
        {
            Item[] items =
            [
                new(1, 3, 9),
                new(2, 5, 10),
                new(3, 2, 7),
                new(4, 1, 4)
            ];
            int W = 8;
            int expectedValue = 21;
            List<int> expectedIndices = [2, 3, 4]; // 物品 2、3、4

            RunTest(W, items, expectedValue, expectedIndices);
        }

        [TestMethod]
        public void TestCase3()
        {
            Item[] items =
            [
                new(1, 5, 12),
                new(2, 4, 3),
                new(3, 7, 10),
                new(4, 2, 3),
                new(5, 6, 6),
                new(6, 3, 6)
            ];
            int W = 15;
            int expectedValue = 28;
            List<int> expectedIndices = [1, 3, 6]; // 物品 1、3、6

            RunTest(W, items, expectedValue, expectedIndices);
        }
    }
}
