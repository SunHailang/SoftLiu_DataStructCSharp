using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 最长公共前缀
    /// </summary>
    public class LongestCommonPrefix
    {

        public static void Awake()
        {
            string[] strs = new string[] { "flower", "flow", "flight" };
            //string str = LongestCommonPrefixMethod(strs);

            string str = LongestCommonPrefixMethodY(strs);

            Console.WriteLine(str);
        }


        private static string LongestCommonPrefixMethod(string[] strs)
        {
            if (strs.Length == 0) return "";
            string str = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(str) != 0)
                {
                    str = str.Substring(0, str.Length - 1);
                    if (string.IsNullOrEmpty(str)) return "";
                }
            }
            return str;
        }

        private static string LongestCommonPrefixMethodY(string[] strs)
        {
            if (strs.Length <= 0) return "";
            if (string.IsNullOrEmpty(strs[0])) return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs[0].Length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (string.IsNullOrEmpty(strs[j])) return "";
                    if (strs[j].Length <= i) return sb.ToString();
                    if (strs[j][i] != c) return sb.ToString();
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

    }
}
