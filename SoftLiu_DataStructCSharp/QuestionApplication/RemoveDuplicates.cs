using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 删除排序数组中的重复项
    /// RemoveDuplicates
    /// </summary>
    public static class RemoveDuplicates
    {

        public static void Awake()
        {
            int[] nums = new int[] { 1, 1, 2 };
            int result = RemoveDuplicatesMethod(nums);
            Console.WriteLine("result: " + result);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }

        private static int RemoveDuplicatesMethod(int[] nums)
        {
            if (nums == null) return -1;
            if (nums.Length <= 1) return nums.Length;

            int curNum = nums[0];
            int index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[index])
                {
                    nums[++index] = nums[i];
                }
            }
            return index + 1;
        }
    }
}
