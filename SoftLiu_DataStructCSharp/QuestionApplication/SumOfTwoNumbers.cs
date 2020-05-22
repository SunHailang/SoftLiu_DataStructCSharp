using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 两数和
    /// </summary>
    public class SumOfTwoNumbers
    {
        /*
            给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
         你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。
        */
        static int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        static int target = 8;

        static List<int> avable = new List<int>();
        public static void Awake()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //int[] result = TwoSum(nums, target);
            int[] result = TwoSumOther(nums, target);
            sw.Stop();
            Console.WriteLine("Total Time: " + sw.ElapsedMilliseconds);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
                if (i < result.Length - 1)
                    Console.Write(",");
            }
        }

        #region 我自己写的

        private static int[] TwoSum(int[] nums, int target)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (avable.Contains(i)) continue;

                int result = Add(i, i + 1, nums, target, hs);
                if (result == target)
                    break;
            }
            return hs.ToArray();
        }


        public static int Add(int value, int index, int[] nums, int target, HashSet<int> hs)
        {
            if (index >= nums.Length)
            {
                return target - 1;
            }
            int sum1 = nums[value] + nums[index];

            if (sum1 == target)
            {
                avable.Add(value);
                avable.Add(index);
                return target;
            }
            do
            {
                index++;
            }
            while (avable.Contains(index));
            return Add(value, index, nums, target, hs);
        }

        #endregion

        #region 别人写的  假设每种输入只会对应一个答案

        private static int[] TwoSumOther(int[] nums, int target)
        {
            Hashtable ht = new Hashtable();

            for (int i = 0; i < nums.Length; i++)
            {
                int num = target - nums[i];
                if (ht.Contains(num))
                {
                    return new int[] { (int)ht[num], i };
                }
                if (!ht.ContainsKey(nums[i]))
                    ht.Add(nums[i], i);
            }
            return nums;
        }

        #endregion

    }
}
