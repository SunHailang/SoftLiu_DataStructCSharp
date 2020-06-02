using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 回文数
    /// </summary>
    public class Palindrome
    {
        public static void Awake()
        {
            //int x = 1244521;
            ////bool result = IsPalindrome(x);
            //bool result = IsPalindromeY(x);
            //Console.WriteLine(result);

            string s = "aabices";
            string result = LongestPalindrome(s);
            Console.WriteLine(result);
        }
        #region 是否是 回文数
        private static bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) return false;

            string str = x.ToString();
            IEnumerable<char> str1 = str.Reverse();
            char[] chars = str1.ToArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != chars[i]) return false;
            }
            return true;
        }

        private static bool IsPalindromeY(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) return false;

            int returnNum = 0;
            while (x > returnNum)
            {
                returnNum = returnNum * 10 + x % 10;
                x /= 10;
            }
            return x == returnNum || x == returnNum / 10;
        }
        #endregion

        #region 最长回文子串
        private static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int value1 = getvalue(s, i, i);
                int value2 = getvalue(s, i, i + 1);
                int value = Math.Max(value1, value2);
                if (value > end - start)
                {
                    start = i - (value - 1) / 2;
                    end = i + value / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }
        private static int getvalue(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length)
            {
                if (s[left] != s[right]) break;
                left--;
                right++;
            }
            return right - left - 1;
        }

        /// <summary>
        /// 马拉松 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string LongestPalindromeY(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            // 构建新的字符串
            int n = s.Length;
            StringBuilder sb = new StringBuilder();
            sb.Append('^');
            for (int i = 0; i < n; i++)
            {
                sb.Append("#" + s[i]);
            }
            sb.Append("#$");
            string T = sb.ToString();

            int len = T.Length;
            int[] P = new int[len];
            int C = 0;
            int R = 0;
            for (int i = 1; i < len - 1; i++)
            {
                int i_mirrir = 2 * C - i;
                if (R > i)
                {
                    // 防止超出R
                    P[i] = Math.Min((R - i), P[i_mirrir]);
                }
                else
                {
                    // 等于R
                    P[i] = 0;
                }
                // 用中心扩展法
                while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                {
                    P[i]++;
                }
                // 判断是否需要更新R
                if (i + P[i] > R)
                {
                    C = i;
                    R = i + P[i];
                }
            }
            //找出P的最大值
            int maxLen = 0;
            int centerIndex = 0;
            for (int i = 1; i < len - 1; i++)
            {
                if (P[i] > maxLen)
                {
                    maxLen = P[i];
                    centerIndex = i;
                }
            }
            int start = (centerIndex - maxLen) / 2;
            return s.Substring(start, start + maxLen);
        }
    }

    #endregion
}
}
