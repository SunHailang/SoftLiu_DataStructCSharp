using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 2008. 出租车的最大盈利
    /// </summary>
    public static class Time20231208
    {
        public static void Run()
        {

        }

        /// <summary>
        /// 你驾驶出租车行驶在一条有 n 个地点的路上。这 n 个地点从近到远编号为 1 到 n ，你想要从 1 开到 n ，通过接乘客订单盈利。
        /// 你只能沿着编号递增的方向前进，不能改变方向。
        /// 乘客信息用一个下标从 0 开始的二维数组 rides 表示，其中 rides[i] = [starti, endi, tipi] 表示第 i 位乘客需要从地点 starti 前往 endi ，愿意支付 tipi 元的小费。
        /// 每一位 你选择接单的乘客 i ，你可以 盈利 endi - starti + tipi 元。你同时 最多 只能接一个订单。
        /// 给你 n 和 rides ，请你返回在最优接单方案下，你能盈利 最多 多少元。
        /// 注意：你可以在一个地点放下一位乘客，并在同一个地点接上另一位乘客。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rides"></param>
        /// <returns></returns>
        public static long MaxTaxiEarnings(int n, int[][] rides)
        {
            Array.Sort(rides, (a, b) => a[1] - b[1]);
            int m = rides.Length;
            long[] dp = new long[m + 1];
            for (int i = 0; i < m; i++)
            {
                int j = BinarySearch(rides, i, rides[i][0]);
                dp[i + 1] = Math.Max(dp[i], dp[j] + rides[i][1] - rides[i][0] + rides[i][2]);
            }
            return dp[m];
        }

        private static int BinarySearch(int[][] rides, int high, int target)
        {
            int low = 0;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (rides[mid][1] > target)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }
    }
}
