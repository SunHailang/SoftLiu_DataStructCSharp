using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    public enum MoveDir
    {
        Up,
        Down,
        Left,
        Right
    }

    /// <summary>
    /// 1631. 最小体力消耗路径
    /// </summary>
    public static class Time20231211
    {
        public static void Run()
        {

        }

    }
    public class SolutionTime20231211
    {
        int[][] dirs = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        /// <summary>
        /// 你准备参加一场远足活动。给你一个二维 rows x columns 的地图 heights ，其中 heights[row][col] 表示格子 (row, col) 的高度。
        /// 一开始你在最左上角的格子 (0, 0) ，且你希望去最右下角的格子 (rows-1, columns-1) （注意下标从 0 开始编号）。
        /// 你每次可以往 上，下，左，右 四个方向之一移动，你想要找到耗费 体力 最小的一条路径。
        /// 一条路径耗费的 体力值 是路径上相邻格子之间 高度差绝对值 的 最大值 决定的。
        /// 请你返回从左上角走到右下角的最小 体力消耗值 。
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int MinimumEffortPath(int[][] heights)
        {
            int a = heights.Length;
            int b = heights[0].Length;
            int left = 0, right = 999999, ans = 0;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[] { 0, 0 });
                bool[] seen = new bool[a * b];
                seen[0] = true;
                while (queue.Count != 0)
                {
                    int[] cell = queue.Dequeue();
                    int x = cell[0], y = cell[1];
                    for (int i = 0; i < 4; ++i)
                    {
                        int nx = x + dirs[i][0];
                        int ny = y + dirs[i][1];
                        if (nx >= 0 && nx <= a && ny >= 0 && ny < b && nx * b + ny <= a * b - 1 && !seen[nx * b + ny] && Math.Abs(heights[x][y] - heights[nx][ny]) <= mid)
                        {
                            queue.Enqueue(new int[] { nx, ny });
                            seen[nx * b + ny] = true;
                        }
                    }
                }
                if (seen[a * b - 1])
                {
                    ans = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return ans;
        }
    }

}
}
