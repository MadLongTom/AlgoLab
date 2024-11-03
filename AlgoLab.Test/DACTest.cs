using AlgoLab.Algorithms;

namespace AlgoLab.Test
{
    [TestClass]
    public class DACTest
    {
        [TestMethod]
        public void Test_BinarySearch_ElementExists()
        {
            int[] arr = [1, 3, 5, 7, 9];
            int x = 5;
            int index = DivideAndConquer.BinarySearch(arr, x);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_ElementDoesNotExist()
        {
            int[] arr = [2, 4, 6, 8, 10];
            int x = 7;
            int index = DivideAndConquer.BinarySearch(arr, x);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void Test_BinarySearch_EmptyArray()
        {
            int[] arr = [];
            int x = 1;
            int index = DivideAndConquer.BinarySearch(arr, x);
            Assert.AreEqual(-1, index);
        }
        [TestMethod]
        public void Test_QuickSort_UnsortedArray()
        {
            int[] arr = [10, 7, 8, 9, 1, 5];
            int[] expected = [1, 5, 7, 8, 9, 10];

            DivideAndConquer.QuickSort(arr, 0, 5);
            CollectionAssert.AreEqual(expected, arr);
        }

        [TestMethod]
        public void Test_QuickSort_AllElementsSame()
        {
            int[] arr = [3, 3, 3, 3, 3];
            int[] expected = [3, 3, 3, 3, 3];

            DivideAndConquer.QuickSort(arr, 0, 4);
            CollectionAssert.AreEqual(expected, arr);
        }

        [TestMethod]
        public void Test_QuickSort_EmptyArray()
        {
            int[] arr = [];
            int[] expected = [];

            DivideAndConquer.QuickSort(arr, 0, 0);
            CollectionAssert.AreEqual(expected, arr);
        }
        [TestMethod]
        public void Test_SelectKthSmallest_ElementExists()
        {
            int[] arr = [7, 10, 4, 3, 20, 15];
            int k = 3;
            int result = DivideAndConquer.QuickSelect(arr, k);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Test_SelectKthSmallest_AllElementsSame()
        {
            int[] arr = [5, 5, 5, 5, 5];
            int k = 2;
            int result = DivideAndConquer.QuickSelect(arr, k);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Test_SelectKthSmallest_KIsLast()
        {
            int[] arr = [1, 2];
            int k = 2;
            int result = DivideAndConquer.QuickSelect(arr, k);
            Assert.AreEqual(2, result);
        }
    }
}
