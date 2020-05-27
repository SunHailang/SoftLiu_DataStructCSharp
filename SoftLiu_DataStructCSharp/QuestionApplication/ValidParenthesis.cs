using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 有效的括号
    /// Valid parenthesis
    /// </summary>
    public class ValidParenthesis
    {
        public static void Awake()
        {
            string s = "()()((";
            //bool result = IsValid(s);
            //Console.WriteLine(result);

            int result = LongestValidParentheses(s);
            Console.WriteLine(result);
        }
        /// <summary>
        /// 有效的括号        
        /// 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
        /// 有效字符串需满足：
        ///     左括号必须用相同类型的右括号闭合。
        ///     左括号必须以正确的顺序闭合。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (stack.Count > 0)
                {
                    char x = stack.Pop();
                    bool yes = x == '(' && c == ')' || x == '{' && c == '}' || x == '[' && c == ']';
                    if (!yes)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (stack.Count > 0) return false;
            return true;
        }

        /// <summary>
        /// 给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static int LongestValidParentheses(string s)
        {
            int longest = 0;

            int count = 0;

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        char x = stack.Pop();
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                    longest = Math.Max(longest, count * 2);
                }
            }
            return longest - longest % 2;
        }

    }
}
