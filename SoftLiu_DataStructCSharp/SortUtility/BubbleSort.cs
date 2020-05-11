using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.Utility
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// 冒泡排序， 时间复杂对是： O(n^2)
        /// 当 大数据排序的时候  冒泡排序的性能还是很低的
        /// </summary>
        /// <param name="array"></param>
        public static void sort(IComparable[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    //比较 索引 J ， 和 J+1 的数
                    if(greater(array[j], array[j+1]))
                    {
                        exch(array, i, j);
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
