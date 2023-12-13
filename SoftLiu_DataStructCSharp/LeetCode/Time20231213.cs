using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 2697. 字典序最小回文串
    /// </summary>
    public static class Time20231213
    {
        public static void Run()
        {

        }

        /// <summary>
        /// 给你一个由 小写英文字母 组成的字符串 s ，你可以对其执行一些操作。在一步操作中，你可以用其他小写英文字母 替换  s 中的一个字符。
        /// 请你执行 尽可能少的操作 ，使 s 变成一个 回文串 。如果执行 最少 操作次数的方案不止一种，则只需选取 字典序最小 的方案。
        /// 对于两个长度相同的字符串 a 和 b ，在 a 和 b 出现不同的第一个位置，
        /// 如果该位置上 a 中对应字母比 b 中对应字母在字母表中出现顺序更早，则认为 a 的字典序比 b 的字典序要小。
        /// 返回最终的回文字符串。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string MakeSmallestPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;

            var chars = s.ToCharArray();

            for (; left < right; )
            {
                if(chars[left] != chars[right])
                {
                    var ch = (char)Math.Min(chars[left], chars[right]);
                    chars[left] = ch;
                    chars[right] = ch;
                }
                left++;
                right--;
            }
            var sb = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                sb.Append(chars[i]);
            }

            return sb.ToString();
        }
    }
}
