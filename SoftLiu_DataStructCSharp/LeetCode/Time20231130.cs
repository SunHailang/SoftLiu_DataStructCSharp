using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 确定两个字符串是否接近
    /// </summary>
    public static class Time20231130
    {
        public static void Run()
        {
            //var solution = new Solution();
            //var word1 = "abc";
            //var word2 = "bca";
            //var ret = solution.CloseStrings(word1, word2); // true
            //Console.WriteLine($"Value:{ret}");

            var nums = new int[] { 3, 1, 2, 4 };
            //RemoveElement(nums, 3);

            //Rotate(nums, 3);
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    Console.Write($"{nums[i]},");
            //}

            Console.WriteLine(SumSubarrayMins(nums));

        }

        public static int MinSwapsCouples(int[] row)
        {
            var count = 0;
            for (int i = 0; i < row.Length - 1; i += 2)
            {
                var val = row[i];
                var needVal = val % 2 == 0 ? val + 1 : val - 1;
                for (int j = i + 1; j < row.Length; j++)
                {
                    if (row[j] == needVal)
                    {
                        if (j - i != 1)
                        {
                            var temp = row[j];
                            row[j] = row[i + 1];
                            row[i + 1] = temp;
                            count++;
                        }
                        break;
                    }
                }
            }

            return count;
        }

        #region 907. 子数组的最小值之和
        /// <summary>
        /// 给定一个整数数组 arr，找到 min(b) 的总和，其中 b 的范围为 arr 的每个（连续）子数组。
        /// 由于答案可能很大，因此 返回答案模 10^9 + 7 。
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int SumSubarrayMins(int[] arr)
        {
            return (int)(SumSub(arr, 1) % ((int)Math.Pow(10, 9) + 7));
        }
        private static long SumSub(int[] arr, int len)
        {
            if (len > arr.Length) return 0;

            long sum = 0;
            var left = 0;

            for (var right = left + len; right <= arr.Length; right = left + len)
            {
                if (len > 1)
                {
                    var min = int.MaxValue;
                    for (int j = left; j < right; j++)
                    {
                        min = Math.Min(min, arr[j]);
                    }
                    sum += min;
                }
                else
                {
                    sum += arr[left];
                }
                left++;
            }

            sum += SumSub(arr, len + 1);

            return sum;
        }
        #endregion


        #region 189. 轮转数组
        /// <summary>
        /// 给定一个整数数组 nums，将数组中的元素向右轮转 k 个位置，其中 k 是非负数。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 1 || k <= 0) return;

            k %= nums.Length;

            if (k == 0) return;

            var temps = new int[k];
            for (int i = 0; i < k; i++)
            {
                temps[i] = nums[nums.Length - k + i];
            }
            var initLen = nums.Length - k - 1;

            for (int i = initLen; i >= 0; i--)
            {
                nums[i + k] = nums[i];
            }

            for (int i = 0; i < k; i++)
            {
                nums[i] = temps[i];
            }
        }


        #endregion
        #region 169. 多数元素
        public static int MajorityElement(int[] nums)
        {
            if (nums == null || nums.Length <= 0) return 0;
            if (nums.Length <= 1) return nums[0];

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.TryGetValue(nums[i], out var val))
                {
                    dict[nums[i]] = val + 1;
                }
                else
                {
                    dict[nums[i]] = 1;
                }
            }
            var key = 0;
            var count = int.MinValue;
            foreach (var item in dict)
            {
                if (item.Value > count)
                {
                    key = item.Key;
                    count = item.Value;
                }
            }

            return key;
        }
        #endregion

        #region 26. 删除有序数组中的重复项
        public static int RemoveDuplicates(int[] nums)
        {
            // var set = new HashSet<int>();
            var left = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[left] != nums[i])
                {
                    nums[++left] = nums[i];
                }
                //if (set.Add(nums[i]))
                //{
                //    nums[left++] = nums[i];
                //    continue;
                //}
            }

            return left + 1;// set.Count;
        }

        #endregion
        #region 80. 删除有序数组中的重复项 II
        /// <summary>
        /// 给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使得出现次数超过两次的元素只出现两次 ，返回删除后数组的新长度。
        /// 不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicatesII(int[] nums)
        {
            if (nums == null) return 0;
            if (nums.Length <= 1) return nums.Length;
            var left = 0;
            var count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[left] != nums[i])
                {
                    nums[++left] = nums[i];
                    count = 0;
                    continue;
                }

                count++;
                if (count < 2)
                {
                    nums[++left] = nums[i];
                }
            }

            return left + 1;
        }
        #endregion

        #region 88. 合并两个有序数组
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            if (m <= 0) return;
            if (n <= 0) return;

            var total = m + n;
            var index = 0;
            while (index < m)
            {
                var val = nums2[0];
                if (nums1[index] < val)
                {
                    index++;
                    continue;
                }
                // 交换
                nums2[0] = nums1[index];
                nums1[index] = val;
                for (int i = 0; i < n - 1; i++)
                {
                    if (nums2[i] >= nums2[i + 1]) break;
                    var temp = nums2[i];
                    nums2[i] = nums2[i + 1];
                    nums2[i + 1] = temp;
                }
            }

            for (var i = index; i < total; i++)
            {
                nums1[i] = nums2[i - index];
            }

        }
        #endregion
        #region 27. 移除元素
        public static int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length <= 0) return 0;
            var left = 0;
            var right = 0;
            while (right < nums.Length)
            {
                if (nums[right] != val)
                {
                    if (right != left)

                    {
                        // 交换数据
                        var temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                    left++;
                    right++;
                    continue;
                }

                right++;
            }
            return left;
        }
        #endregion

    }
    #region 380. O(1) 时间插入、删除和获取随机元素
    public class RandomizedSet
    {

        private Dictionary<int, int> dict;
        private List<int> list;

        private Random random;

        public RandomizedSet()
        {
            dict = new Dictionary<int, int>();
            list = new List<int>();
            random = new Random(33);
        }

        public bool Insert(int val)
        {
            if (dict.TryGetValue(val, out var index))
            {
                return false;
            }

            dict[val] = list.Count;
            list.Add(val);
            return true;
        }

        public bool Remove(int val)
        {
            if (dict.TryGetValue(val, out var index))
            {
                list.Remove(val);
                dict.Remove(val);
                return true;
            }
            return false;
        }

        public int GetRandom()
        {
            var index = random.Next(0, list.Count);
            return list[index];
        }
    }
    #endregion

    /// <summary>
    /// 两个字符串接近的充分必要条件为：
    /// 1. 两个字符串出现的字符集S1和S2相等
    /// 2. 分别将两个字符串的字符出现次数数组F1和F2进行排序后，两个数组相等。
    /// </summary>
    public class Solution
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2)) return false;

            if (word1.Length != word2.Length) return false;

            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();

            for (int i = 0; i < word1.Length; i++)
            {
                if (!word2.Contains(word1[i])) return false;

                if (dict1.TryGetValue(word1[i], out var value1))
                {
                    dict1[word1[i]] = value1 + 1;
                }
                else
                {
                    dict1[word1[i]] = 1;
                }

                if (dict2.TryGetValue(word2[i], out var value2))
                {
                    dict2[word2[i]] = value2 + 1;
                }
                else
                {
                    dict2[word2[i]] = 1;
                }
            }

            if (dict1.Count != dict2.Count) return false;

            var list1 = dict1.Values.ToList();
            list1.Sort();
            var list2 = dict2.Values.ToList();
            list2.Sort();

            if (list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i]) return false;
            }

            return true;
        }
    }
}
