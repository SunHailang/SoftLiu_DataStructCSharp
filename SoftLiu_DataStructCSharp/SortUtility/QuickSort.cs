using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.Utility
{
    /// <summary>
    /// 快速排序   （分治的排序算法）
    /// </summary>
    public class QuickSort
    {
        /// <summary>
        /// 快速排序   时间复杂度 
        /// </summary>
        /// <param name="array"></param>
        public static void sort(IComparable[] array)
        {
            int lo = 0;
            int hi = array.Length - 1;
            sort(array, lo, hi);
        }

        private static void sort(IComparable[] array, int lo, int hi)
        {
            if (lo >= hi) return;
            // 需要对数组中lo索引 到 hi 索引的元素进行分组(左子组， 右子组)
            int index = partition(array, lo, hi);
            // 让左子组有序
            sort(array, lo, index);
            // 让右子组有序
            sort(array, index + 1, hi);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns>返回的是分组值所在的索引，分界值位置变换后的索引</returns>
        private static int partition(IComparable[] array, int lo, int hi)
        {
            // 确定分界值
            IComparable key = array[lo];
            // 定义两个指针 p1 left， p2 right 的下一个位置
            int left = lo;
            int right = hi + 1;
            // 切分
            while (true)
            {
                // 先从右往左扫描，移动right指针 找到一个比分界值小的数，停止
                while (less(key, array[--right]))
                {
                    if (right == lo) break;
                }
                // 再从左往右扫描，移动left指针，找到一个比分界值大的数，停止
                while (less(array[++left], key))
                {
                    if (left == hi) break;
                }
                // 判断 left >= right， true则继续扫描， 否则交换元素
                if (left >= right)
                {
                    break;
                }
                else
                {
                    exch(array, left, right);
                }
            }
            // 交换分界值
            exch(array, lo, right);
            return right;
        }
        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static bool less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// 交换 次数：
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void exch(IComparable[] a, int i, int j)
        {
            IComparable temp;
            temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
