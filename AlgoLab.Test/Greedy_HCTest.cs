using AlgoLab.Models;
using static AlgoLab.Algorithms.Greedy;

namespace AlgoLab.Test
{
    [TestClass]
    public class Greedy_HCTest
    {
        /// <summary>
        /// 封装测试逻辑的方法
        /// </summary>
        private static void RunTest(char[] symbols, int[] frequencies, Dictionary<char, string> expectedCodes)
        {
            HuffmanNode root = BuildHuffmanTree(symbols, frequencies);
            Dictionary<char, string> codes = GenerateCodes(root);

            // 验证生成的编码是否与预期一致
            foreach (var symbol in symbols)
            {
                Assert.IsTrue(codes.ContainsKey(symbol), $"缺少字符 {symbol} 的编码");
                Assert.AreEqual(expectedCodes[symbol], codes[symbol], $"字符 {symbol} 的编码不匹配");
            }
        }

        [TestMethod]
        public void TestCase1()
        {
            char[] symbols = ['A', 'B', 'C', 'D', 'E', 'F'];
            int[] frequencies = [45, 13, 12, 16, 9, 5];

            // 预期编码（可能有多种正确编码，这里仅验证编码长度）
            Dictionary<char, string> expectedCodes = new()
            {
                {'A', "0"},
                {'B', "101"},
                {'C', "100"},
                {'D', "111"},
                {'E', "1101"},
                {'F', "1100"}
            };

            RunTest(symbols, frequencies, expectedCodes);
        }

        [TestMethod]
        public void TestCase2()
        {
            char[] symbols = ['a', 'b', 'c', 'd', 'e', 'f'];
            int[] frequencies = [5, 9, 12, 13, 16, 45];

            // 预期编码长度
            Dictionary<char, string> expectedCodesLength = new()
            {
                {'a', "1100"},
                {'b', "1101"},
                {'c', "100"},
                {'d', "101"},
                {'e', "111"},
                {'f', "0"}
            };

            RunTest(symbols, frequencies, expectedCodesLength);
        }

        [TestMethod]
        public void TestCase3()
        {
            char[] symbols = ['G', 'H', 'I', 'J', 'K', 'L'];
            int[] frequencies = [2, 3, 7, 10, 15, 20];

            // 预期编码长度
            Dictionary<char, int> expectedCodesLength = new()
            {
                {'G', 4},
                {'H', 4},
                {'I', 3},
                {'J', 2},
                {'K', 2},
                {'L', 2}
            };

            HuffmanNode root = BuildHuffmanTree(symbols, frequencies);
            Dictionary<char, string> codes = GenerateCodes(root);

            // 验证编码长度是否符合预期
            foreach (var symbol in symbols)
            {
                Assert.IsTrue(codes.ContainsKey(symbol), $"缺少字符 {symbol} 的编码");
                Assert.AreEqual(expectedCodesLength[symbol], codes[symbol].Length, $"字符 {symbol} 的编码长度不匹配");
            }
        }
    }
}
