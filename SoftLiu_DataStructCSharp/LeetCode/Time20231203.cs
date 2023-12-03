using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    public static class Time20231203
    {
        public static void Run()
        {
            var carPoints = new int[] { 1, 2, 3, 4, 5, 6, 1 };
            for (int i = 0; i < carPoints.Length; i++)
            {
                Console.Write($"{carPoints[i]},");
            }
            Console.WriteLine("");
            var val = MaxScoreII(carPoints, 3);
            Console.WriteLine($"{val}, True:{12}");
        }

        public static int MaxScoreII(int[] cardPoints, int k)
        {
            var left = 0;
            var sumMax = 0;
            for (int i = 0; i < cardPoints.Length; i++)
            {
                sumMax += cardPoints[i];
            }
            var minLen = cardPoints.Length - k;
            var sumMin = 0;            

            for (int i = 0; i < minLen; i++)
            {
                sumMin += cardPoints[i];
            }
            var sum = sumMin;
            for (; left + minLen < cardPoints.Length; left++)
            {
                sum += cardPoints[left + minLen];
                sum -= cardPoints[left];
                sumMin = Math.Min(sum, sumMin);
            }
            return sumMax - sumMin;
        }


        public static int MaxScore(int[] cardPoints, int k)
        {
            if (cardPoints == null) return 0;
            if (k > cardPoints.Length) return 0;

            var left = 0;
            var len = cardPoints.Length;
            var right = len - 1;

            if (k == 1)
            {
                return Math.Max(cardPoints[left], cardPoints[right]);
            }

            var sumMax = 0;
            var selectVal = 0;
            for (int i = 0; i < k; i++)
            {
                var leftVal = cardPoints[left];
                var rightVal = cardPoints[right];

                var leftEnd = left - 1 + k - i;
                var rightEnd = right - k + i + 1;
                var leftEndVal = cardPoints[leftEnd];
                var rightEndVal = cardPoints[rightEnd];

                if (rightVal > leftVal)
                {
                    if (rightVal > leftEndVal || (rightVal + rightEndVal > leftEndVal + leftVal))
                    {
                        right--;
                        selectVal = rightVal;
                    }
                    else
                    {
                        left++;
                        selectVal = leftVal;
                    }
                }
                else if (leftVal > rightVal)
                {
                    // 如果选左边 假设右边一直选的值
                    if (leftVal > rightEndVal || (leftVal + leftEndVal) > (rightEndVal + rightVal))
                    {
                        left++;
                        selectVal = leftVal;
                    }
                    else
                    {
                        right--;
                        selectVal = rightVal;
                    }
                }
                else
                {
                    if (leftVal + leftEndVal > rightVal + rightEndVal)
                    {
                        left++;
                        selectVal = leftVal;
                    }
                    else
                    {
                        right--;
                        selectVal = rightVal;
                    }
                }
                sumMax += selectVal;
                Console.WriteLine($"Selct:{selectVal},Sum:{sumMax}, Index:{i}, Left:{left},LeftEnd:{leftEnd}, Right:{right},RightEnd:{rightEnd}");
            }

            return sumMax;
        }

    }
}
