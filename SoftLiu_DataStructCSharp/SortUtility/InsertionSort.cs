using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.Utility
{
    /// <summary>
    /// 插入排序
    /// </summary>
    public class InsertionSort
    {
        /// <summary>
        /// 插入排序    O(n^2)
        /// 大数据的情况下， 性能还是很低
        /// </summary>
        /// <param name="array"></param>
        public static void sort(IComparable[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    // 比较 j-1 的值 和 j 的值， 如果 j-1 的值比 j de 
                    if (greater(array[j - 1], array[j]))
                    {
                        exch(array, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
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
