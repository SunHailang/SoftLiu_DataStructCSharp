using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 1466. 重新规划路线
    /// </summary>
    public static class Time20231207
    {
        public static void Run()
        {

        }
        /// <summary>
        /// n 座城市，从 0 到 n-1 编号，其间共有 n-1 条路线。
        /// 因此，要想在两座不同城市之间旅行只有唯一一条路线可供选择（路线网形成一颗树）。
        /// 去年，交通运输部决定重新规划路线，以改变交通拥堵的状况。
        /// 路线用 connections 表示，其中 connections[i] = [a, b] 表示从城市 a 到 b 的一条有向路线。
        /// 今年，城市 0 将会举办一场大型比赛，很多游客都想前往城市 0 。
        /// 请你帮助重新规划路线方向，使每个城市都可以访问城市 0 。返回需要变更方向的最小路线数。
        /// 题目数据 保证 每个城市在重新规划路线方向后都能到达城市 0 。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public static int MinReorder(int n, int[][] connections)
        {
            IList<Tuple<int, int>>[] e = new IList<Tuple<int, int>>[n];
            for (int i = 0; i < n; i++)
            {
                e[i] = new List<Tuple<int, int>>();
            }
            foreach (int[] edge in connections)
            {
                e[edge[0]].Add(new Tuple<int, int>(edge[1], 1));
                e[edge[1]].Add(new Tuple<int, int>(edge[0], 0));
            }
            return DFS(0, -1, e);
        }

        public static int DFS(int x, int parent, IList<Tuple<int, int>>[] e)
        {
            int res = 0;
            foreach (Tuple<int, int> edge in e[x])
            {
                if (edge.Item1 == parent)
                {
                    continue;
                }
                res += edge.Item2 + DFS(edge.Item1, x, e);
            }
            return res;
        }
    }
}
