using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 两数相除
    /// </summary>
    public class DivisionOfTwoNumbers
    {
        public static void Awake()
        {
            int dividend = -214748368;
            int divisor = -2147483648;
            //int result = Divide(dividend, divisor);
            //Console.WriteLine(result);
            int result = divide(dividend, divisor);
            Console.WriteLine(result);
        }

        private static int Divide(int dividend, int divisor)
        {
            int result = 0;
            bool negative = false;
            if (divisor == -2147483648 && dividend != -2147483648) return 0;
            if (dividend == -2147483648)
            {
                if (divisor == -1) return 2147483647;
                if (divisor == 1) return -2147483648;
                if (divisor == -2147483648) return 1;
                if (divisor > 0)
                {
                    negative = true;
                }
                divisor = divisor < 0 ? 0 - divisor : divisor;
                while (dividend < 0)
                {
                    dividend += divisor;
                    result++;
                }
            }
            else
            {
                if ((dividend < 0 && divisor > 0) || (divisor < 0 && dividend > 0)) negative = true;

                dividend = dividend < 0 ? 0 - dividend : dividend;
                divisor = divisor < 0 ? 0 - divisor : divisor;
                if (divisor != 1)
                {
                    while (dividend >= divisor)
                    {
                        result++;
                        dividend -= divisor;
                    }
                }
                else
                {
                    result = dividend;
                }
            }
            return negative ? 0 - result : result;
        }


        /// <summary>
        /// a/b , 用b翻n番 去试探是否能达到a
        ///比如，7除以2， 2不翻番为2，没达到，2翻一番为4，没达到；2翻两番为8，超过了，于是商就是2加上（7-4）/2（递归出现了）
        ///左移n，就是翻n番
        ///溢出，可以用long接管int来解决
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        private static int divide(int dividend, int divisor)
        {
            if (divisor == 1) return dividend;
            if (divisor == -1 && dividend == int.MinValue)
                return int.MaxValue;

            long a = dividend;
            long b = divisor;

            long ans;
            if (a > 0 && b > 0)
                ans = div(a, b);
            else if (a < 0 && b < 0)
                ans = div(-a, -b);
            else
                ans = -div(Math.Abs(a), Math.Abs(b));

            return (int)ans;

        }

        private static long div(long a, long b)
        {
            // 如果小于，就无法放置任何
            if (a < b) return 0;
            int i = 0;
            while (a >= (b << i))
            {
                i++;
            }
            i--;

            return (1 << i) + div(a - (b << i), b);
        }
    }
}
