using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 2646. 最小化旅行的价格总和
    /// </summary>
    public static class Time20231206
    {
        public static void Run()
        {
            var edges = new int[][]
            {
                new int[]{ 0, 1 },
                new int[]{ 1, 2 },
                new int[]{ 2, 3 }
            };
            var prices = new int[] { 2, 2, 10, 6 };
            var trips = new int[][]
            {
                new int[]{0, 3 },
                new int[]{2, 1 },
                new int[]{2, 3 }
            };
            MinimumTotalPrice(4, edges, prices, trips);
        }
        /// <summary>
        /// 现有一棵无向、无根的树，树中有 n 个节点，按从 0 到 n - 1 编号。
        /// 给你一个整数 n 和一个长度为 n - 1 的二维整数数组 edges ，其中 edges[i] = [ai, bi] 表示树中节点 ai 和 bi 之间存在一条边。
        /// 每个节点都关联一个价格。给你一个整数数组 price ，其中 price[i] 是第 i 个节点的价格。
        /// 给定路径的 价格总和 是该路径上所有节点的价格之和。
        /// 另给你一个二维整数数组 trips ，其中 trips[i] = [starti, endi] 表示您从节点 starti 开始第 i 次旅行，
        /// 并通过任何你喜欢的路径前往节点 endi 。
        /// 在执行第一次旅行之前，你可以选择一些 非相邻节点 并将价格减半。
        /// 返回执行所有旅行的最小价格总和。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="price"></param>
        /// <param name="trips"></param>
        /// <returns></returns>
        public static int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips)
        {
            var list = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                list[i] = new List<int>();
            }
            for (int i = 0; i < edges.Length; i++)
            {
                list[edges[i][0]].Add(edges[i][1]);
                list[edges[i][1]].Add(edges[i][0]);
            }

            var count = new int[n];
            foreach (var item in trips)
            {
                DFS(item[0], -1, item[1], list, count);
            }

            var pair = DP(0, -1, price, list, count);

            return Math.Min(pair[0], pair[1]);
        }

        private static bool DFS(int node, int parent, int end, List<int>[] next, int[] count)
        {
            if(node == end)
            {
                count[node]++;
                return true;
            }
            foreach (var child in next[node])
            {
                if (child == parent) continue;
                if(DFS(child, node, end, next, count))
                {
                    count[node]++;
                    return true;
                }
            }
            return false;
        }

        private static int[] DP(int node, int parent, int[] price, List<int>[] next, int[] count)
        {
            var res = new int[]{ price[node] * count[node], price[node] * count[node] / 2 };
            foreach (var child in next[node])
            {
                if (child == parent) continue;
                var pair = DP(child, node, price, next, count);
                // node 没有减半，因此可以取子树的两种情况的最小值
                res[0] += Math.Min(pair[0], pair[1]);
                // node减半，只能取子树没有减半的情况
                res[1] += pair[0];
            }
            return res;
        }

    }
}
