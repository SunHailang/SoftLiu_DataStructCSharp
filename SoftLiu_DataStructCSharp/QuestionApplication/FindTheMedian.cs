using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 寻找两个正序数组的中位数
    /// </summary>
    public class FindTheMedian
    {
        /*
            给定两个大小为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。

            请你找出这两个正序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

            你可以假设 nums1 和 nums2 不会同时为空。
         */

        public static void Awake()
        {
            float result = FindMedian();
            Console.WriteLine(result);
        }

        private static float FindMedian()
        {
            /*
             归并法排序 合并两个数组，
             */

            // 数组 A 和 B 不会同时为空
            int[] arrayA = new int[] { 1, 3,5 };
            int[] arrayB = new int[] { 2,4 };

            int m = arrayA.Length;
            int n = arrayB.Length;


            int[] arrayNums = new int[m + n];
            int count = 0;
            int i = 0;
            int j = 0;

            while (count != (m + n))
            {
                if (i == m)
                {
                    while (j != n)
                    {
                        arrayNums[count++] = arrayB[j++];
                    }
                    break;
                }
                if (j == n)
                {
                    while (i != m)
                    {
                        arrayNums[count++] = arrayA[i++];
                    }
                    break;
                }
                // A B 为有序列表
                if (arrayA[i] < arrayB[j])
                {
                    arrayNums[count++] = arrayA[i++];
                }
                else
                {
                    arrayNums[count++] = arrayB[j++];
                }
            }
            if (count % 2 == 0)
            {
                return (arrayNums[count / 2 - 1] + arrayNums[count / 2]) / 2.0f;
            }
            else
            {
                return arrayNums[count / 2];
            }

        }
    }
}
