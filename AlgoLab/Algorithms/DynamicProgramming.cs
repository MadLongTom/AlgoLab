using System.Text;

namespace AlgoLab.Algorithms
{
    public class DynamicProgramming
    {
        /// <summary>
        /// 计算矩阵链乘法的最小标量乘法次数
        /// </summary>
        /// <param name="p">矩阵维度数组</param>
        /// <param name="n">矩阵个数</param>
        /// <param name="m">最小乘法次数表</param>
        /// <param name="s">括号化位置表</param>
        public static void MatrixChainOrder(int[] p, int n, int[,] m, int[,] s)
        {
            for (int i = 1; i <= n; i++) // 初始化对角线
                m[i, i] = 0;

            for (int r = 2; r <= n; r++) // r个矩阵连乘
            {
                for (int i = 1; i <= n - r + 1; i++) // r个矩阵的r-1个空隙中依次测试最优点
                {
                    int j = i + r - 1;
                    m[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++) // 变换分隔位置，逐一测试
                    {
                        int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if (q < m[i, j]) // 如果变换后的位置更优，则替换原来的分隔方法
                        {
                            m[i, j] = q;
                            s[i, j] = k;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 返回最优括号化方案字符串
        /// </summary>
        /// <param name="s">括号化位置表</param>
        /// <param name="i">起始矩阵索引</param>
        /// <param name="j">结束矩阵索引</param>
        /// <returns>最优括号化方案字符串</returns>
        public static string GetOptimalParens(int[,] s, int i, int j)
        {
            if (i == j)
            {
                return $"A{i}";
            }
            else
            {
                string left = GetOptimalParens(s, i, s[i, j]);
                string right = GetOptimalParens(s, s[i, j] + 1, j);
                return $"({left}{right})";
            }
        }
        /// <summary>
        /// 计算两个序列的最长公共子序列
        /// </summary>
        /// <param name="X">序列 X</param>
        /// <param name="Y">序列 Y</param>
        /// <param name="c">LCS 长度表</param>
        /// <param name="b">决策表</param>
        public static void LCSLength(string X, string Y, int[,] c, char[,] b)
        {
            int m = X.Length;
            int n = Y.Length;

            for (int i = 0; i <= m; i++)
                c[i, 0] = 0;
            for (int j = 0; j <= n; j++)
                c[0, j] = 0;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                        b[i, j] = '↖'; // 来自左上方
                    }
                    else if (c[i - 1, j] >= c[i, j - 1])
                    {
                        c[i, j] = c[i - 1, j];
                        b[i, j] = '↑'; // 来自上方
                    }
                    else
                    {
                        c[i, j] = c[i, j - 1];
                        b[i, j] = '←'; // 来自左方
                    }
                }
            }
        }

        /// <summary>
        /// 构造最长公共子序列
        /// </summary>
        /// <param name="b">决策表</param>
        /// <param name="X">序列 X</param>
        /// <param name="i">当前索引 i</param>
        /// <param name="j">当前索引 j</param>
        /// <returns>最长公共子序列字符串</returns>
        public static string ConstructLCS(char[,] b, string X, int i, int j)
        {
            StringBuilder lcs = new();
            while (i > 0 && j > 0)
            {
                if (b[i, j] == '↖')
                {
                    lcs.Insert(0, X[i - 1]);
                    i--;
                    j--;
                }
                else if (b[i, j] == '↑')
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }
            return lcs.ToString();
        }
    }
}
