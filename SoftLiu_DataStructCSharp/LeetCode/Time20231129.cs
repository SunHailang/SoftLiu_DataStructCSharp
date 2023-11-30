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
            //var val = -1;
            //var set = new SmallestInfiniteSet();
            //LogData(-1);
            //// [[],[2],[],[],[],[1],[],[],[]]
            //set.AddBack(2);
            //LogData(-1);
            //val = set.PopSmallest();
            //LogData(val);
            //set.AddBack(2);
            //LogData(-1);
            //val = set.PopSmallest();
            //LogData(val);
            //set.AddBack(1);
            //LogData(-1);
            //val = set.PopSmallest();
            //LogData(val);
            //val = set.PopSmallest();
            //LogData(val);
            //val = set.PopSmallest();
            //LogData(val);
            //var nums = new int[] { 1, 3, 5, 6 };
            //Console.WriteLine(SearchInsert(nums, 2));
            LetterCombinations("23");
        }

        #region 17. 电话号码的字母组合
        public static IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits)) return new List<string>();

            Dictionary<char, char[]> keyValues = new Dictionary<char, char[]>
            {
                {'2', new char[]{ 'a', 'b', 'c'} },
                {'3', new char[]{ 'd', 'e', 'f'} },
                {'4', new char[]{ 'g', 'h', 'i'} },
                {'5', new char[]{ 'j', 'k', 'l'} },
                {'6', new char[]{ 'm', 'n', 'o'} },
                {'7', new char[]{ 'p', 'q', 'r', 's'} },
                {'8', new char[]{ 't', 'u', 'v'} },
                {'9', new char[]{ 'w', 'x', 'y', 'z'} },
            };

            var sbList = new List<string>();
            GetChar(0, digits, new StringBuilder(digits.Length), sbList, keyValues);
            for (int i = 0; i < sbList.Count; i++)
            {
                Console.WriteLine(sbList[i]);
            }

            return sbList;
        }

        private static void GetChar(int index, string digits, StringBuilder sb, List<string> sbList, Dictionary<char, char[]> keyValues)
        {
            if (keyValues.TryGetValue(digits[index], out var data))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i]);

                    if (index == digits.Length - 1)
                    {
                        sbList.Add(sb.ToString());
                    }
                    if (index < digits.Length - 1)
                    {
                        GetChar(index + 1, digits, sb, sbList, keyValues);
                    }

                    sb.Remove(sb.Length - 1, 1);
                }
            }

        }
        #endregion
        #region 35. 搜索插入位置
        public static int SearchInsert(int[] nums, int target)
        {
            return Find(0, nums.Length - 1, nums, target);
        }

        private static int Find(int left, int right, int[] nums, int target)
        {
            if (nums[left] >= target) return left;
            if (nums[right] == target) return right;
            if (nums[right] < target) return right + 1;

            if (right - left == 1)
            {
                return left + 1;
            }

            var mid = (left + right) / 2;
            var value = nums[mid];
            if (value == target) return mid;
            if (value > target)
            {
                return Find(left, mid, nums, target);
            }
            return Find(mid, right, nums, target);
        }
        #endregion
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
                set.Add(i + 1);
            }

            thers = 1;
        }

        public int PopSmallest()
        {
            if (set.Count <= 0)
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
