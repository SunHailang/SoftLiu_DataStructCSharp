using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 字符串转换整数 (atoi)
    /// </summary>
    public class StringToIntegerConversion
    {

        /*
            请你来实现一个 atoi 函数，使其能将字符串转换成整数。
            首先，该函数会根据需要丢弃无用的开头空格字符，直到寻找到第一个非空格的字符为止。接下来的转化规则如下：
            如果第一个非空字符为正或者负号时，则将该符号与之后面尽可能多的连续数字字符组合起来，形成一个有符号整数。
            假如第一个非空字符是数字，则直接将其与之后连续的数字字符组合起来，形成一个整数。
            该字符串在有效的整数部分之后也可能会存在多余的字符，那么这些字符可以被忽略，它们对函数不应该造成影响。
            注意：假如该字符串中的第一个非空格字符不是一个有效整数字符、字符串为空或字符串仅包含空白字符时，
            则你的函数不需要进行转换，即无法进行有效转换。
            在任何情况下，若函数不能进行有效的转换时，请返回 0 。
            提示：
            本题中的空白字符只包括空格字符 ' ' 。
            假设我们的环境只能存储 32 位大小的有符号整数，那么其数值范围为 [−2^31,  2^31 − 1]。
            如果数值超过这个范围，请返回  INT_MAX (2^31 − 1) 或 INT_MIN (−2^31) 。
         */
        public static void Awake()
        {
            string str = "++020000000000000000000000000000+5";
            int result = MyAtoi(str);
            Console.WriteLine(result);
        }

        private static int MyAtoi(string str)
        {
            List<char> chars = new List<char>() { '+', '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            str = str.Trim(' ');
            if (str.Length <= 0 || !chars.Contains(str[0]))
            {
                return 0;
            }
            StringBuilder sb = new StringBuilder();
            bool negative = str[0] == '-';
            int start = 0;
            if (negative)
            {
                start = 1;
                sb.Append('-');
            }
            long res = 0;
            int x = 0;
            for (int i = start; i < str.Length; i++)
            {
                char c = str[i];
                if (!chars.Contains(c) || c == '-')
                    break;
                if (c == '+')
                {
                    if (sb.Length <= 0 && x < 1)
                    {
                        x++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                sb.Append(c);
                string conv = sb.ToString();
                if (conv.Length == 1 && conv[0] == '-') return 0;
                res = Convert.ToInt64(conv);
                if (res > int.MaxValue) return int.MaxValue;
                if (res < int.MinValue) return int.MinValue;
            }
            return (int)res;
        }
    }
}
