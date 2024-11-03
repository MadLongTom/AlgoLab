using AlgoLab.Algorithms;

namespace AlgoLab.Test
{
    [TestClass]
    public class DP_MCOTest
    {
        /// <summary>
        /// 计算矩阵链乘法的测试方法
        /// </summary>
        /// <param name="p">矩阵维度数组</param>
        /// <param name="expectedCost">预期最少标量乘法次数</param>
        /// <param name="expectedParens">预期最优括号化方案</param>
        private static void RunTest(int[] p, int expectedCost, string expectedParens)
        {
            int n = p.Length - 1;
            int[,] m = new int[n + 1, n + 1];
            int[,] s = new int[n + 1, n + 1];

            DynamicProgramming.MatrixChainOrder(p, n, m, s);
            Assert.AreEqual(expectedCost, m[1, n], "最小乘法次数不匹配");
            string resultParens = DynamicProgramming.GetOptimalParens(s, 1, n);
            Assert.AreEqual(expectedParens, resultParens, "最优括号化方案不匹配");
        }

        [TestMethod]
        public void TestCase1()
        {
            int[] p = [30, 35, 15, 5, 10, 20, 25];
            int expectedCost = 15125;
            string expectedParens = "((A1(A2A3))((A4A5)A6))";

            RunTest(p, expectedCost, expectedParens);
        }

        [TestMethod]
        public void TestCase2()
        {
            int[] p = [10, 20, 30, 40, 30];
            int expectedCost = 30000;
            string expectedParens = "(((A1A2)A3)A4)";

            RunTest(p, expectedCost, expectedParens);
        }

        [TestMethod]
        public void TestCase3()
        {
            int[] p = [5, 10, 3, 12, 5, 50, 6];
            int expectedCost = 2010;
            string expectedParens = "((A1A2)((A3A4)(A5A6)))";

            RunTest(p, expectedCost, expectedParens);
        }


    }
}
