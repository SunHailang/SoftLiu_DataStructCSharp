using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.Utility
{
    /// <summary>
    /// 希尔排序，  优化后的插入排序
    /// </summary>
    public class ShellSort
    {
        /// <summary>
        /// 希尔排序   事后分析法 
        /// 大数据排序，比常规的排序 性能较高
        /// </summary>
        /// <param name="array"></param>
        public static void sort(IComparable[] array)
        {
            int h = 1;
            while (h < array.Length / 2)
            {
                h = 2 * h + 1;
            }
            while (h >= 1)
            {
                // 找到待插入的元素
                for (int i = h; i < array.Length; i++)
                {
                    // 把待插入的元素插入到有序数列
                    for (int j = i; j >= h; j -= h)
                    {
                        // 待插入的元素是 array[j] , 比较 array[j] 和 arra[j-h]
                        if (greater(array[j-h], array[j]))
                        {
                            exch(array, j - h, j);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                h = h / 2;
            }
        }

        /// <summary>
        /// 比较 次数 ： (n^2)/2 - n/2 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static bool greater(IComparable v, IComparable w)
        {
            return v.CompareTo(w) > 0;
        }
        /// <summary>
        /// 交换 次数：(n^2)/2 - n/2 
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
