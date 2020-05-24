using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 无重复字符的最长子串
    /// </summary>
    public class LongestStringWithoutRepetition
    {
        /*
         给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。


        这道题主要用到思路是：滑动窗口

        什么是滑动窗口？

        其实就是一个队列,比如例题中的 abcabcbb，进入这个队列（窗口）为 abc 满足题目要求，当再进入 a，队列变成了 abca，这时候不满足要求。所以，我们要移动这个队列！

        如何移动？

        我们只要把队列的左边的元素移出就行了，直到满足题目要求！

        一直维持这样的队列，找出队列出现最长的长度时候，求出解！

        时间复杂度：O(n)
        */

        public static void Awake()
        {
            string target = "abcabcbb";
            string result = GetLongestString(target);
            Console.WriteLine("longest : " + result);
        }
        #region 我自己写的

        private static string GetLongestString(string str)
        {
            List<char> charList = new List<char>();
            Dictionary<char, int> charDic = new Dictionary<char, int>();
            int result = 0;

            for (int end = 0, start = 0; end < str.Length; end++)
            {
                char alpha = str[end];
                if (charDic.ContainsKey(alpha))
                {
                    start = Math.Max(charDic[alpha], start);
                    charDic.Remove(alpha);
                }
                result = Math.Max(result, end - start + 1);
                
                charDic.Add(str[end], end + 1);
            }

            Console.WriteLine(result);

            return null;
        }

        #endregion

    }
}
