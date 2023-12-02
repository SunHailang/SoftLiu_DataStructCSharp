using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 1094. 拼车
    /// </summary>
    public static class Time20231202
    {
        public static void Run()
        {
            //int[][] trips = new int[3][]
            //{
            //    new int[3]{ 7, 5, 6 },
            //    new int[3]{ 6, 7, 8 },
            //    new int[3]{ 10, 1, 6 }
            //};

            //int[][] trips = new int[][]
            //{
            //    new int[3]{8,2,3 },
            //    new int[3]{4, 1, 3 },
            //    new int[3]{ 1, 3, 6 },
            //    new int[3]{8, 4, 6 },
            //    new int[3]{4, 4, 8 }
            //};

            int[][] trips = new int[][]
            {
                new int[3]{2,1,5},new int[3]{3,3,7}
            };

            int capacity = 4;
            var ret = CarPooling(trips, capacity);
            Console.WriteLine($"{ret}");
        }

        #region 121. 买卖股票的最佳时机
        /// <summary>
        /// 给定一个数组 prices ，它的第 i 个元素 prices[i] 表示一支给定股票第 i 天的价格。
        /// 你只能选择 某一天 买入这只股票，并选择在 未来的某一个不同的日子 卖出该股票。设计一个算法来计算你所能获取的最大利润。
        /// 返回你可以从这笔交易中获取的最大利润。如果你不能获取任何利润，返回 0 。
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;
            int val = 0;

            



            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    val = Math.Max(val, prices[j] - prices[i]);
                }
            }

            return val;
        }

        #endregion

        public class SortType : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                if (x.Item2 == y.Item2) return x.Item1 - y.Item1;
                return x.Item2 - y.Item2;
            }
        }


        /// <summary>
        /// 车上最初有 capacity 个空座位。车 只能 向一个方向行驶（也就是说，不允许掉头或改变方向）
        /// 给定整数 capacity 和一个数组 trips, trip[i] = [numPassengersi, fromi, toi] 表示第 i 次旅行有 numPassengersi 乘客，
        /// 接他们和放他们的位置分别是 fromi 和 toi 。这些位置是从汽车的初始位置向东的公里数。
        /// 当且仅当你可以在所有给定的行程中接送所有乘客时，返回 true，否则请返回 false。
        /// </summary>
        /// <param name="trips"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        private static bool CarPooling(int[][] trips, int capacity)
        {
            if (trips[0][0] > capacity) return false;

            var curCapacity = 0;
            //var listSort = new List<Tuple<int, int>>(trips.Length);
            //for (int i = 0; i < trips.Length; i++)
            //{
            //    listSort.Add(new Tuple<int, int>(i, trips[i][1]));
            //}
            //listSort.Sort((x, y) => y.Item2 - x.Item2);

            var listSort = new SortedSet<Tuple<int, int>>(new SortType());
            for (int i = 0; i < trips.Length; i++)
            {
                listSort.Add(new Tuple<int, int>(i, trips[i][1]));
            }
            var list = new List<int>();
            while (listSort.Count > 0)
            {
                //var data = listSort[listSort.Count - 1];
                var data = listSort.Min;
                var numPassengers = trips[data.Item1][0];
                var fromPos = trips[data.Item1][1];
                var toPos = trips[data.Item1][2];
                // 判断有没有下车的
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    var val = GetValue(trips[list[j]]);
                    if (fromPos >= val.Item3)
                    {
                        // 下车
                        curCapacity -= val.Item1;
                        list.RemoveAt(j);
                    }
                }
                // 上车
                curCapacity += numPassengers;

                if (curCapacity > capacity) return false;
                list.Add(data.Item1);
                //listSort.RemoveAt(listSort.Count - 1);
                listSort.Remove(listSort.Min);
            }

            return true;
        }
        private static Tuple<int, int, int> GetValue(int[] aar)
        {
            return new Tuple<int, int, int>(aar[0], aar[1], aar[2]);
        }

    }
}
