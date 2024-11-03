using System.Runtime.CompilerServices;

namespace AlgoLab.Algorithms
{
    public class DivideAndConquer
    {
        /// <summary>
        /// 二分搜索算法
        /// </summary>
        /// <param name="arr">已排序的数组</param>
        /// <param name="x">目标元素</param>
        /// <returns>目标元素的索引，未找到返回 -1</returns>
        public static int BinarySearch(int[] arr, int x)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1); // 使用位运算代替除法

                if (arr[mid] == x)
                    return mid; // 找到目标元素，返回索引
                else if (arr[mid] < x)
                    left = mid + 1; // 继续在右半部分搜索
                else
                    right = mid - 1; // 继续在左半部分搜索
            }

            return -1; // 未找到目标元素
        }
        /// <summary>
        /// 快速排序算法
        /// </summary>
        /// <param name="arr">待排序的数组</param>
        /// <param name="low">起始索引</param>
        /// <param name="high">结束索引</param>
        public static void QuickSort(int[] arr, int low, int high)
        {
            while (low < high)
            {
                // 划分数组，获得枢纽元素的位置
                int pivotIndex = Partition(arr, low, high);

                // 优化递归调用，先处理较小的子数组
                if (pivotIndex - low < high - pivotIndex)
                {
                    QuickSort(arr, low, pivotIndex - 1);
                    low = pivotIndex + 1;
                }
                else
                {
                    QuickSort(arr, pivotIndex + 1, high);
                    high = pivotIndex - 1;
                }
            }
        }
        /// <summary>
        /// 划分函数
        /// </summary>
        /// <param name="arr">待划分的数组</param>
        /// <param name="low">起始索引</param>
        /// <param name="high">结束索引</param>
        /// <returns>枢纽元素的位置</returns>
        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // 选择最后一个元素作为枢纽
            int i = low - 1; // i 为小于枢纽的元素的索引

            for (int j = low; j < high; j++)
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j); // 交换小于枢纽的元素到前面
                }

            Swap(arr, i + 1, high); // 将枢纽元素放到正确的位置
            return i + 1; // 返回枢纽元素的位置
        }
        /// <summary>
        /// 交换函数，已启用内联优化
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="i">索引 i</param>
        /// <param name="j">索引 j</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(int[] arr, int i, int j)
        {
            (arr[j], arr[i]) = (arr[i], arr[j]);
        }
        /// <summary>
        /// 线性时间选择算法（Quick Select）
        /// </summary>
        /// <param name="arr">无序数组</param>
        /// <param name="k">第 k 小的元素</param>
        /// <returns>第 k 小的元素的值</returns>
        public static int QuickSelect(int[] arr, int k)
        {
            if (arr == null || arr.Length == 0 || k < 1 || k > arr.Length)
            {
                throw new ArgumentException("参数不合法");
            }

            return QuickSelect(arr, 0, arr.Length - 1, k - 1);
        }
        /// <summary>
        /// Quick Select 递归函数
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="low">起始索引</param>
        /// <param name="high">结束索引</param>
        /// <param name="k">目标索引（0-based）</param>
        /// <returns>第 k 小的元素的值</returns>
        public static int QuickSelect(int[] arr, int low, int high, int k)
        {
            while (low <= high)
            {
                // 随机化枢纽元素的选择，避免最坏情况
                int pivotIndex = Random.Shared.Next(low, high + 1);

                pivotIndex = Partition(arr, low, high, pivotIndex);

                if (k == pivotIndex)
                    return arr[k];
                else if (k < pivotIndex)
                    high = pivotIndex - 1;
                else
                    low = pivotIndex + 1;
            }

            throw new InvalidOperationException("未找到第 k 小的元素");
        }
        /// <summary>
        /// 划分函数
        /// </summary>
        /// <param name="arr">数组</param>
        /// <param name="low">起始索引</param>
        /// <param name="high">结束索引</param>
        /// <param name="pivotIndex">枢纽元素索引</param>
        /// <returns>新的枢纽元素索引</returns>
        public static int Partition(int[] arr, int low, int high, int pivotIndex)
        {
            int pivotValue = arr[pivotIndex];
            Swap(arr, pivotIndex, high); // 将枢纽元素移到末尾
            int storeIndex = low;

            for (int i = low; i < high; i++)
                if (arr[i] < pivotValue)
                {
                    Swap(arr, storeIndex, i);
                    storeIndex++;
                }

            Swap(arr, high, storeIndex); // 将枢纽元素移到正确的位置
            return storeIndex;
        }
    }
}
