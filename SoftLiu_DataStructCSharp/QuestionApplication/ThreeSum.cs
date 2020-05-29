using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 15. 三数之和
    /// </summary>
    public class ThreeSum
    {
        /*
         给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？
         请你找出所有满足条件且不重复的三元组。

        注意：答案中不可以包含重复的三元组。
         */

        public static void Awake()
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            //IList<IList<int>> list = ThreeSumMethod(nums);

            IList<IList<int>> list = threeSum(nums);

            Console.WriteLine(list.Count);
        }

        #region 4数之和
        public static IList<IList<int>> FourSumY(int[] nums, int target)
        {
            
            IList<IList<int>> list = new List<IList<int>>();
            if (nums == null || nums.Length < 4) return list;
            Array.Sort(nums);
            int len = nums.Length;
            for (int i = 0; i < len - 3; i++)
            {
                int numi = nums[i];
                if (numi > target && nums[i + 1] > 0) break;
                if (numi + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) break;
                if (i > 0 && numi == nums[i - 1]) continue;
                if (numi + nums[len - 1] + nums[len - 2] + nums[len - 3] < target) continue;
                for (int j = i + 1; j < len - 2; j++)
                {
                    if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target) break;
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    if (nums[i] + nums[j] + nums[len - 1] + nums[len - 2] < target) continue;

                    int l = j + 1;
                    int r = len - 1;
                    while (l < r)
                    {
                        var s = nums[i] + nums[j] + nums[l] + nums[r];
                        if (s == target)
                        {
                            list.Add(new List<int>() { numi, nums[j], nums[l], nums[r] });
                            l++;
                            r--;
                            while (nums[l] == nums[l - 1] && l < r) l++;
                            while (nums[r] == nums[r + 1] && l < r) r--;
                        }
                        else if (s > target) r--;
                        else l++;
                    }
                }
            }
            return list;
        }


        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            /*定义一个返回值*/
            List<IList<int>> result = new List<IList<int>>();
            /*当数组为null或元素小于4个时，直接返回*/
            if (nums == null || nums.Length < 4)
            {
                return result;
            }
            /*对数组进行从小到大排序*/
            Array.Sort(nums);
            /*数组长度*/
            int length = nums.Length;
            /*定义4个指针k，i，j，h  k从0开始遍历，i从k+1开始遍历，留下j和h，j指向i+1，h指向数组最大值*/
            for (int k = 0; k < length - 3; k++)
            {
                /*当k的值与前面的值相等时忽略*/
                if (k > 0 && nums[k] == nums[k - 1])
                {
                    continue;
                }
                /*获取当前最小值，如果最小值比目标值大，说明后面越来越大的值根本没戏*/
                int min1 = nums[k] + nums[k + 1] + nums[k + 2] + nums[k + 3];
                if (min1 > target)
                {
                    break;
                }
                /*获取当前最大值，如果最大值比目标值小，说明后面越来越小的值根本没戏，忽略*/
                int max1 = nums[k] + nums[length - 1] + nums[length - 2] + nums[length - 3];
                if (max1 < target)
                {
                    continue;
                }
                /*第二层循环i，初始值指向k+1*/
                for (int i = k + 1; i < length - 2; i++)
                {
                    /*当i的值与前面的值相等时忽略*/
                    if (i > k + 1 && nums[i] == nums[i - 1])
                    {
                        continue;
                    }
                    /*定义指针j指向i+1*/
                    int j = i + 1;
                    /*定义指针h指向数组末尾*/
                    int h = length - 1;
                    /*获取当前最小值，如果最小值比目标值大，说明后面越来越大的值根本没戏，忽略*/
                    int min = nums[k] + nums[i] + nums[j] + nums[j + 1];
                    if (min > target)
                    {
                        continue;
                    }
                    /*获取当前最大值，如果最大值比目标值小，说明后面越来越小的值根本没戏，忽略*/
                    int max = nums[k] + nums[i] + nums[h] + nums[h - 1];
                    if (max < target)
                    {
                        continue;
                    }
                    /*开始j指针和h指针的表演，计算当前和，如果等于目标值，j++并去重，h--并去重，当当前和大于目标值时h--，当当前和小于目标值时j++*/
                    while (j < h)
                    {
                        int curr = nums[k] + nums[i] + nums[j] + nums[h];
                        if (curr == target)
                        {
                            result.Add(new List<int>() { nums[k], nums[i], nums[j], nums[h] });
                            j++;
                            while (j < h && nums[j] == nums[j - 1])
                            {
                                j++;
                            }
                            h--;
                            while (j < h && i < h && nums[h] == nums[h + 1])
                            {
                                h--;
                            }
                        }
                        else if (curr > target)
                        {
                            h--;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
            }
            return result;
        }
        #endregion


        #region 优化后的
        public static IList<IList<int>> threeSum(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();
            int len = nums.Length;
            if (nums == null || len < 3) return ans;
            Array.Sort(nums); // 排序
            for (int i = 0; i < len; i++)
            {
                if (nums[i] > 0) break; // 如果当前数字大于0，则三数之和一定大于0，所以结束循环
                if (i > 0 && nums[i] == nums[i - 1]) continue; // 去重
                int L = i + 1;
                int R = len - 1;
                while (L < R)
                {
                    if (nums[i] + nums[L] > 0) break;
                    int sum = nums[i] + nums[L] + nums[R];
                    if (sum == 0)
                    {
                        ans.Add(new List<int> { nums[i], nums[L], nums[R] });
                        while (L < R && nums[L] == nums[L + 1]) L++; // 去重
                        while (L < R && nums[R] == nums[R - 1]) R--; // 去重
                        L++;
                        R--;
                    }
                    else if (sum < 0) L++;
                    else if (sum > 0) R--;
                }
            }
            return ans;
        }
        #endregion

        private static IList<IList<int>> ThreeSumMethod(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
            {
                return result;
            }
            List<Data> datas = new List<Data>();
            List<int> list = nums.ToList();
            list.Sort((x, y) => { return x - y; });
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0) break;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if ((list[i] + list[j]) > 0) break;
                    for (int k = j + 1; k < list.Count; k++)
                    {
                        int sum = list[i] + list[j] + list[k];
                        if (sum != 0) continue;

                        Data d = new Data(list[i], list[j], list[k]);
                        if (!datas.Contains(d))
                        {
                            datas.Add(d);
                            result.Add(d.ToList());
                        }
                    }
                }
            }

            return result;
        }

        private class Data
        {
            public int x;
            public int y;
            public int z;

            public Data(int _x, int _y, int _z)
            {
                x = _x;
                y = _y;
                z = _z;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                Data d = (Data)obj;
                return x == d.x && y == d.y && z == d.z;
            }


            public IList<int> ToList()
            {
                IList<int> list = new List<int>();
                list.Add(x);
                list.Add(y);
                list.Add(z);
                return list;
            }

        }
    }
}
