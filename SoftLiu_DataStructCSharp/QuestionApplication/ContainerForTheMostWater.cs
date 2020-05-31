using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 盛最多水的容器
    /// Container for the most water
    /// </summary>
    public class ContainerForTheMostWater
    {

        public static void Awake()
        {
            int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            //int result = MaxArea(height);
            int result = MaAreaMethod(height);
            Console.WriteLine(result);
        }

        private static int MaxArea(int[] height)
        {
            if (height.Length < 2) return 0;
            int left = 0;
            int right = height.Length - 1;
            int max = 0;
            while (left < right)
            {
                do
                {
                    max = Math.Max(max, Math.Min(height[left], height[right]) * (right - left));
                    left++;
                    while (height[left] <= height[left - 1] && left < right)
                    {
                        left++;
                    }
                }
                while (left < right);
                left = 0;
                right--;
                while (height[right] <= height[right + 1] && right > left)
                {
                    right--;
                }
            }
            return max;
        }


        private static int MaAreaMethod(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int res = 0;
            while (i<j)
            {
                res = height[i] < height[j] ?
                    Math.Max(res, (j - i) * height[i++]) :
                    Math.Max(res, (j - i) * height[j--]);
            }
            return res;
        }
    }
}
