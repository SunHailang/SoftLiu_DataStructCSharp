using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 现有一个包含所有正整数的集合 [1, 2, 3, 4, 5, ...] 。
    /// 实现 SmallestInfiniteSet 类：
    /// SmallestInfiniteSet() 初始化 SmallestInfiniteSet 对象以包含 所有 正整数。
    /// int popSmallest() 移除 并返回该无限集中的最小整数。
    /// void addBack(int num) 如果正整数 num 不 存在于无限集中，则将一个 num 添加 到该无限集中。
    /// </summary>
    public static class Time20231129
    {
        public static void Run()
        {
            var val = -1;
            var set = new SmallestInfiniteSet();
            LogData(-1);
            // [[],[2],[],[],[],[1],[],[],[]]
            set.AddBack(2);
            LogData(-1);
            val = set.PopSmallest();
            LogData(val);
            set.AddBack(2);
            LogData(-1);
            val = set.PopSmallest();
            LogData(val);
            set.AddBack(1);
            LogData(-1);
            val = set.PopSmallest();
            LogData(val);
            val = set.PopSmallest();
            LogData(val);
            val = set.PopSmallest();
            LogData(val);
        }

        private static void LogData(int data)
        {
            var str = data < 0 ? "null" : $"{data}";
            Console.Write($"{str},");
        }
    }

    public class SmallestInfiniteSet
    {

        private SortedSet<int> set;
        private int thers;
        public class ComparerType : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x - y;
            }
        }

        public SmallestInfiniteSet()
        {
            set = new SortedSet<int>(new ComparerType());

            for (int i = 0; i < 1000; i++)
            {
                set.add(i + 1);
            }

            thers = 1;
        }

        public int PopSmallest()
        {
            if (set == null)
            {
                var data = thers;
                thers++;
                return data;
            }
            var min = set.Min;
            set.Remove(min);
            thers = min + 1;
            return min;
        }

        public void AddBack(int num)
        {
            set.Add(num);
        }
    }
}
