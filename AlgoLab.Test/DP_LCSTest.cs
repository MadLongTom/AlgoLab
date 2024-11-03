using AlgoLab.Algorithms;

namespace AlgoLab.Test
{
    [TestClass]
    public class DP_LCSTest
    {
        /// <summary>
        /// 封装测试逻辑的方法
        /// </summary>
        /// <param name="X">序列 X</param>
        /// <param name="Y">序列 Y</param>
        /// <param name="expectedLength">预期的 LCS 长度</param>
        /// <param name="possibleLCS">可能的 LCS 列表</param>
        private static void RunTest(string X, string Y, int expectedLength, string[] possibleLCS)
        {
            int m = X.Length;
            int n = Y.Length;
            int[,] c = new int[m + 1, n + 1];
            char[,] b = new char[m + 1, n + 1];

            DynamicProgramming.LCSLength(X, Y, c, b);
            string lcs = DynamicProgramming.ConstructLCS(b, X, m, n);

            // 验证 LCS 长度
            Assert.AreEqual(expectedLength, c[m, n], "LCS 长度不匹配");

            // 验证 LCS 是否在可能的列表中
            CollectionAssert.Contains(possibleLCS, lcs, "构造的 LCS 不在预期的列表中");
        }

        [TestMethod]
        public void TestCase1()
        {
            string X = "ABCBDAB";
            string Y = "BDCABA";
            int expectedLength = 4;
            string[] possibleLCS = ["BCBA", "BDAB", "BCAB"];

            RunTest(X, Y, expectedLength, possibleLCS);
        }

        [TestMethod]
        public void TestCase2()
        {
            string X = "XMJYAUZ";
            string Y = "MZJAWXU";
            int expectedLength = 4;
            string[] possibleLCS = ["MJAU"];

            RunTest(X, Y, expectedLength, possibleLCS);
        }

        [TestMethod]
        public void TestCase3()
        {
            string X = "ABCDEF";
            string Y = "FBDAMN";
            int expectedLength = 2;
            string[] possibleLCS = ["BD"];

            RunTest(X, Y, expectedLength, possibleLCS);
        }
    }
}
