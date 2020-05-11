using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.Utility
{
    /// <summary>
    /// 归并排序  以空间换时间
    /// </summary>
    public class MergeSort
    {
        /// <summary>
        /// 辅助数组
        /// </summary>
        private static IComparable[] assist;

        /// <summary>
        /// 归并排序  (以空间换时间的操作)  时间复杂度  O(N*logN) 
        /// 和希尔排序时间差不多
        /// </summary>
        /// <param name="array"></param>
        public static void sort(IComparable[] array)
        {
            // 初始化辅助数组 assist
            assist = new IComparable[array.Length];
            // 定义一个变量lo变量，和hi变量,分别记录数组中最小索引，和最大索引
            int lo = 0;
            int hi = array.Length - 1;
            // 调用sort重载方法完成array的排序， 从lo到hi排序
            sort(array, lo, hi);
        }

        private static void sort(IComparable[] array, int lo, int hi)
        {
            if (lo >= hi) return;
            // 对 lo 到 hi之间的数据分成两个组
            int mid = lo + (hi - lo) / 2;
            // 分别对两个数组排序
            sort(array, lo, mid);
            sort(array, mid + 1, hi);
            // 再把两个数组中的数据进行归并
            merge(array, lo, mid, hi);
        }
        /// <summary>
        /// 把 lo到mid 和 mid+1到hi两组数据归并
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lo"></param>
        /// <param name="mid"></param>
        /// <param name="hi"></param>
        private static void merge(IComparable[] array, int lo, int mid, int hi)
        {
            // 定义三个指针
            int i = lo;
            int p1 = lo;
            int p2 = mid + 1;
            // 便利移动p1 指针 p2指针 比较对应索引处值 找出小的那个，放到辅助数组对应的索引处
            while (p1 <= mid && p2 <= hi)
            {
                // 比较对应索引处的值
                if (less(array[p1], array[p2]))
                {
                    assist[i++] = array[p1++];
                }
                else
                {
                    assist[i++] = array[p2++];
                }
            }
            // 遍历 如果p1的指针没有移动完， 那么移动p1指针， 把对应的元素放到辅助数组对应的索引处
            while (p1 <= mid)
            {
                assist[i++] = array[p1++];
            }
            // 遍历 如果p2的指针没有移动完， 那么移动p2指针， 把对应的元素放到辅助数组对应的索引处
            while (p2 <= hi)
            {
                assist[i++] = array[p2++];
            }
            // 把辅助数组中的元素拷贝到原数组中
            for (int index = 0; index <= hi; index++)
            {
                array[index] = assist[index];
            }
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
