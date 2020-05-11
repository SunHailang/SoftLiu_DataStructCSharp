using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SortUtility
{
    /// <summary>
    /// 选择排序
    /// </summary>
    public class SelectionSort
    {

        public static void sort(IComparable[] arrary)
        {
            for (int i = 0; i <= arrary.Length - 2; i++)
            {
                // 定义一个变量记录最小元素的所有， 默认未参与排序的第一个元素所在的位置
                int minIndex = i;
                for (int j = i + 1; j < arrary.Length; j++)
                {
                    // 需要比较最小所引处 miniIndex 和 j 所引处的值
                    if(greater(arrary[minIndex], arrary[j]))
                    {
                        minIndex = j;
                    }
                }
                // 交换最小元素的值 和 索引 i 处的值
                exch(arrary, minIndex, i);
            }
        }

        /// <summary>
        /// 比较 次数 ： 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static bool greater(IComparable v, IComparable w)
        {
            return v.CompareTo(w) > 0;
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
