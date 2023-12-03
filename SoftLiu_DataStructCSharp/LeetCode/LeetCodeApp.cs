using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    public static class LeetCodeApp
    {
        public static void Run()
        {
            //Time20231128.Run();
            //Time20231129.Run();
            //Time20231130.Run();
            //Time20231202.Run();
            //Time20231203.Run();


            LeetCodeRun();
        }

        public static void LeetCodeRun()
        {
            int[] nums = new int[] { 3, 2, 1, 0, 4 };
            Console.WriteLine(CanJump(nums));
        }

        #region 45. 跳跃游戏 II
        /// <summary>
        /// 给定一个长度为 n 的 0 索引整数数组 nums。初始位置为 nums[0]。
        /// 每个元素 nums[i] 表示从索引 i 向前跳转的最大长度。
        /// 换句话说，如果你在 nums[i] 处，你可以跳转到任意 nums[i + j] 处:
        /// 0 <= j <= nums[i]
        /// i + j < n
        /// 返回到达 nums[n - 1] 的最小跳跃次数。生成的测试用例可以到达 nums[n - 1]。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int JumpII(int[] nums)
        {
            var sum = nums[0];
            if (sum >= nums.Length - 1) return 1;

            var count = 0;

            var index = 0;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                var val = nums[i];
                if (val >= nums.Length - i - 1)
                {
                    count = 1;
                }


                if (val > 0)
                {
                    if (val > index)
                    {
                        index = 0;
                        continue;
                    }
                }
                index++;
            }
            return 0;
        }
        #endregion

        #region 55. 跳跃游戏
        /// <summary>
        /// 给你一个非负整数数组nums，你最初位于数组的第一个下标。数组中的每个元素代表你在该位置可以跳跃的最大长度。
        /// 判断你是否能够到达最后一个下标，如果可以，返回 true ；否则，返回 false 。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums)
        {
            var sum = nums[0];
            if (sum == 0 && nums.Length > 1) return false;
            if (sum >= nums.Length - 1) return true;

            var index = 0;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                var val = nums[i];
                if(val > 0)
                {
                    if (val > index)
                    {
                        index = 0;
                        continue;
                    }
                }
                index++;
            }
            return nums[0] >= index;
        }

        #endregion

    }
}
