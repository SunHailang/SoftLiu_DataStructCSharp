using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp
{

    /// <summary>
    /// 2454. 下一个更大元素 IV
    /// </summary>
    public static class Time20231212
    {
        public static void Run()
        {

        }
        /// <summary>
        /// 给你一个下标从 0 开始的非负整数数组 nums 。对于 nums 中每一个整数，你必须找到对应元素的 第二大 整数。
        /// 如果 nums[j] 满足以下条件，那么我们称它为 nums[i] 的 第二大 整数：
        /// 1. j > i 
        /// 2. nums[j] > nums[i] 
        /// 3. 恰好存在 一个 k 满足 i<k < j 且 nums[k] > nums[i] 。
        /// 如果不存在 nums[j] ，那么第二大整数为 -1 。
        /// 比方说，数组[1, 2, 4, 3] 中，1 的第二大整数是 4 ，2 的第二大整数是 3 ，3 和 4 的第二大整数是 -1 。
        /// 请你返回一个整数数组 answer ，其中 answer[i] 是 nums[i] 的第二大整数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SecondGreaterElement(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = -1;
            }
            IList<int> stack1 = new List<int>();
            IList<int> stack2 = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                int v = nums[i];
                while (stack2.Count > 0 && nums[stack2[stack2.Count - 1]] < v)
                {
                    res[stack2[stack2.Count - 1]] = v;
                    stack2.RemoveAt(stack2.Count - 1);
                }
                int pos = stack1.Count - 1;
                while (pos >= 0 && nums[stack1[pos]] < v)
                {
                    --pos;
                }
                for (int j = pos + 1; j < stack1.Count; j++)
                {
                    stack2.Add(stack1[j]);
                }
                for (int j = stack1.Count - 1; j >= pos + 1; j--)
                {
                    stack1.RemoveAt(j);
                }
                stack1.Add(i);
            }
            return res;
        }
    }
}
