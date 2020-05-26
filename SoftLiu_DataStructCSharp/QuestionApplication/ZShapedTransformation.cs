using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// Z 字形变换
    /// </summary>
    public class ZShapedTransformation
    {
        /*
        将一个给定字符串根据给定的行数，以从上往下、从左到右进行 Z 字形排列。

        比如输入字符串为 "LEETCODEISHIRING" 行数为 3 时，排列如下：

        L   C   I   R
        E T O E S I I G
        E   D   H   N

        输入: s = "LEETCODEISHIRING", numRows = 3
        输出: "LCIRETOESIIGEDHN"

         */

        public static void Awake()
        {
            string s = "LEETCODEISHIRING";
            int numRows = 3;

            string result = Convert(s, numRows);
            Console.WriteLine(result);
        }

        private static string Convert(string s, int numRows)
        {
            if (numRows <= 1)
            {
                return s;
            }

            List<StringBuilder> rows = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            {
                rows.Add(new StringBuilder());
            }
            int curRow = 0;
            bool goingDowm = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                rows[curRow].Append(c);
                if (curRow == 0 || curRow == numRows - 1)
                {
                    goingDowm = !goingDowm;
                }
                curRow += goingDowm ? 1 : -1;
            }
            //L,T,D,S,R,G,E,C,E,H,I,E,O,I,I,N,
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows.Count; i++)
            {
                sb.Append(rows[i].ToString());
            }

            return sb.ToString();
        }
    }
}
