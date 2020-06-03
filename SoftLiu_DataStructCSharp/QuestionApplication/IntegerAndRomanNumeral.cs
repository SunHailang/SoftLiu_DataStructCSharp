using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    ///  整数 和 罗马数字 转换
    /// </summary>
    public class IntegerAndRomanNumeral
    {
        public static void Awake()
        {
            //int num = 1994;
            //string result = IntToRoman(num);
            string s = "MCMXCIV";
            int result = RomanToIntY(s);

            Console.WriteLine(result);
        }
        private static string IntToRoman(int num)
        {
            int[] nums = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] strs = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            StringBuilder sb = new StringBuilder();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int value = num / nums[i];
                for (int j = 0; j < value; j++)
                {
                    sb.Append(strs[i]);
                }
                num -= nums[i] * value;
            }

            return sb.ToString();
        }

        private static int RomanToInt(string s)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>()
            {
                { "I", 1 },
                { "IV", 4 },
                { "V", 5 },
                { "IX", 9 },
                { "X", 10 },
                { "XL", 40 },
                { "L", 50 },
                { "XC", 90 },
                { "C", 100 },
                { "CD", 400 },
                { "D", 500 },
                { "CM", 900 },
                { "M", 1000 }
            };
            int index = 0;
            int sum = 0;
            while (index < s.Length)
            {
                if (index < s.Length - 1 && dic.ContainsKey(string.Format("{0}{1}", s[index], s[index + 1])))
                {
                    sum += dic[string.Format("{0}{1}", s[index], s[index + 1])];
                    index += 2;
                }
                else
                {
                    string key = string.Format("{0}", s[index]);
                    if (dic.ContainsKey(key))
                    {
                        sum += dic[key];
                        index++;
                    }
                }
            }

            return sum;
        }

        private static int RomanToIntY(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int sum = 0;
            int preNum = getValue(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                int num = getValue(s[i]);
                if (preNum < num)
                {
                    sum -= preNum;
                }
                else
                {
                    sum += preNum;
                }
                preNum = num;
            }
            sum += preNum;
            return sum;
        }
        private static int getValue(char ch)
        {
            switch (ch)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }
    }
}
