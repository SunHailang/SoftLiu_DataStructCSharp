using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 确定两个字符串是否接近
    /// </summary>
    public static class Time20231130
    {
        public static void Run()
        {
            var solution = new Solution();
            var word1 = "abc";
            var word2 = "bca";
            var ret = solution.CloseStrings(word1, word2); // true
            Console.WriteLine($"Value:{ret}");
        }
    }
    /// <summary>
    /// 两个字符串接近的充分必要条件为：
    /// 1. 两个字符串出现的字符集S1和S2相等
    /// 2. 分别将两个字符串的字符出现次数数组F1和F2进行排序后，两个数组相等。
    /// </summary>
    public class Solution
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2)) return false;

            if (word1.Length != word2.Length) return false;

            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();

            for (int i = 0; i < word1.Length; i++)
            {
                if (!word2.Contains(word1[i])) return false;

                if(dict1.TryGetValue(word1[i], out var value1))
                {
                    dict1[word1[i]] = value1 + 1;
                }
                else
                {
                    dict1[word1[i]] = 1;
                }

                if (dict2.TryGetValue(word2[i], out var value2))
                {
                    dict2[word2[i]] = value2 + 1;
                }
                else
                {
                    dict2[word2[i]] = 1;
                }
            }

            if (dict1.Count != dict2.Count) return false;

            var list1 = dict1.Values.ToList();
            list1.Sort();
            var list2 = dict2.Values.ToList();
            list2.Sort();

            if (list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i]) return false;
            }
            
            return true;
        }
    }
}
