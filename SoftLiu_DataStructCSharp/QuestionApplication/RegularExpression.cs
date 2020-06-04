using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 正则表达式  
    /// </summary>
    public class RegularExpression
    {
        /*
         给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。

            '.' 匹配任意单个字符
            '*' 匹配零个或多个前面的那一个元素
         */
        public static void Awake()
        {
            string s = "mississippi";
            string p = "mis*is*p*.";
            bool result = IsMatch(s, p);
            Console.WriteLine(result);
        }

        private static bool IsMatch(string s, string p)
        {
            if (p == "") return s == "";
            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[s.Length, p.Length] = true;

            for (int i = s.Length; i >= 0; i--)
            {
                for (int j = p.Length - 1; j >= 0; j--)
                {
                    bool first = (i < s.Length && (p[j] == s[i] || p[j] == '.'));
                    if (j + 1 < p.Length && p[j + 1] == '*')
                    {
                        dp[i, j] = dp[i, j + 2] || first && dp[i + 1, j];
                    }
                    else
                    {
                        dp[i, j] = first && dp[i + 1, j + 1];
                    }
                }
            }
            return dp[0, 0];
        }
    }
}
