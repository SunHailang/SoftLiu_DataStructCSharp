using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.PathFinding
{
    public class PathFindingTest
    {
        public static void Testing()
        {
            UniquePaths();
        }

        private static void UniquePaths()
        {
            int m = 1;
            int n = 1;

            int[] pre = new int[n];
            int[] cur = new int[n];
            for (int i = 0; i < pre.Length; i++)
            {
                pre[i] = 1;
            }
            for (int i = 0; i < cur.Length; i++)
            {
                cur[i] = 1;
            }


            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    cur[j] = cur[j - 1] + pre[j];
                }
                cur.CopyTo(pre, 0);
            }
            Console.WriteLine($"Path: {pre[n - 1]}");
        }
    }
}
