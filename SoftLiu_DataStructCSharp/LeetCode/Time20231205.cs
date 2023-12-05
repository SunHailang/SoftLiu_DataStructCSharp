using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 2477. 到达首都的最少油耗
    /// </summary>
    public static class Time20231205
    {
        public static void Run()
        {
            // [3,1],[3,2],[1,0],[0,4],[0,5],[4,6]
            var roads = new int[][]
            {
                new int[]{ 3, 1 },
                new int[]{ 3, 2 },
                new int[]{ 1, 0 },
                new int[]{ 0, 4 },
                new int[]{ 0, 5 },
                new int[]{ 4, 6 },
            };
            var resute = MinimumFuelCost(roads, 2);
            Console.WriteLine($"7 -> Value:{resute}");
        }
        /// <summary>
        /// 给你一棵 n 个节点的树（一个无向、连通、无环图），
        /// 每个节点表示一个城市，编号从 0 到 n - 1 ，且恰好有 n - 1 条路。0 是首都。
        /// 给你一个二维整数数组 roads ，其中 roads[i] = [ai, bi] ，表示城市 ai 和 bi 之间有一条 双向路 。
        /// 每个城市里有一个代表，他们都要去首都参加一个会议。
        /// 每座城市里有一辆车。给你一个整数 seats 表示每辆车里面座位的数目。
        /// 城市里的代表可以选择乘坐所在城市的车，或者乘坐其他城市的车。相邻城市之间一辆车的油耗是一升汽油。
        /// 请你返回到达首都最少需要多少升汽油。
        /// </summary>
        /// <param name="roads"></param>
        /// <param name="seats"></param>
        /// <returns></returns>
        public static long MinimumFuelCost(int[][] roads, int seats)
        {
            int n = roads.Length;
            IList<int>[] g = new IList<int>[n + 1];
            for (int i = 0; i <= n; i++)
            {
                g[i] = new List<int>();
            }
            foreach (int[] e in roads)
            {
                g[e[0]].Add(e[1]);
                g[e[1]].Add(e[0]);
            }
            int res = 0;
            DFS(0, -1, seats, g, ref res);
            return res;
        }

        public static int DFS(int cur, int fa, int seats, IList<int>[] g, ref int res)
        {
            int peopleSum = 1;
            foreach (int ne in g[cur])
            {
                if (ne != fa)
                {
                    int peopleCnt = DFS(ne, cur, seats, g, ref res);
                    peopleSum += peopleCnt;
                    res += (peopleCnt + seats - 1) / seats;
                }
            }
            return peopleSum;
        }
    }
}
