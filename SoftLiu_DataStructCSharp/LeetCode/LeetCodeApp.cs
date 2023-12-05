using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    public static class LeetCodeApp
    {
        public static void Run()
        {
            //Time20231128.Run();
            //Time20231129.Run();
            //Time20231130.Run();
            //Time20231202.Run();
            //Time20231203.Run();
            //Time20231205.Run();
            LeetCodeRun();
        }

        public static void LeetCodeRun()
        {
            NumTrees(4);
        }

        #region 13. 罗马数字转整数
        /// <summary>
        /// 罗马数字包含以下七种字符: I， V， X， L，C，D 和 M。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            var dict = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var perValue = dict[s[0]];
            var sum = 0;
            for (int i = 1; i < s.Length; i++)
            {
                var num = dict[s[i]];
                if (num > perValue)
                {
                    sum -= perValue;
                }
                else
                {
                    sum += perValue;
                }
                perValue = num;
            }
            return sum + perValue;
        }

        #endregion

        #region 45. 跳跃游戏 II
        /// <summary>
        /// 给定一个长度为 n 的 0 索引整数数组 nums。初始位置为 nums[0]。
        /// 每个元素 nums[i] 表示从索引 i 向前跳转的最大长度。
        /// 换句话说，如果你在 nums[i] 处，你可以跳转到任意 nums[i + j] 处:
        /// 0 <= j <= nums[i]
        /// i + j < n
        /// 返回到达 nums[n - 1] 的最小跳跃次数。生成的测试用例可以到达 nums[n - 1]。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Jump(int[] nums)
        {
            if (nums.Length <= 1) return 0;
            var sum = nums[0];
            if (sum >= nums.Length - 1) return 1;
            var list = new List<int>();

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                var val = nums[i];
                if (val >= nums.Length - i - 1)
                {
                    list.Clear();
                    list.Add(i);
                    continue;
                }
                // 然后计算后面的到当前位置的步数
                var jumpIndex = list.Count;
                for (int j = 0; j < list.Count; j++)
                {
                    var index = list[j];
                    if (index - i <= val)
                    {
                        jumpIndex = j;
                        break;
                    }
                }
                for (int j = list.Count - 1; j > jumpIndex; j--)
                {
                    list.RemoveAt(j);
                }
                if (list.Count > 0 && val >= list[list.Count - 1] - i)
                {
                    list.Add(i);
                }
            }
            return list.Count;
        }
        #endregion

        #region 55. 跳跃游戏
        /// <summary>
        /// 给你一个非负整数数组nums，你最初位于数组的第一个下标。数组中的每个元素代表你在该位置可以跳跃的最大长度。
        /// 判断你是否能够到达最后一个下标，如果可以，返回 true ；否则，返回 false 。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums)
        {
            var sum = nums[0];
            if (sum == 0 && nums.Length > 1) return false;
            if (sum >= nums.Length - 1) return true;

            var index = 0;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                var val = nums[i];
                if (val > 0)
                {
                    if (val > index)
                    {
                        index = 0;
                        continue;
                    }
                }
                index++;
            }
            return nums[0] >= index;
        }

        #endregion

        #region 95. 不同的二叉搜索树 II
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static IList<TreeNode> GenerateTrees(int n)
        {
            if (n <= 0) return new List<TreeNode>();
            return generateTreesII(1, n);
        }

        public static List<TreeNode> generateTreesII(int start, int end)
        {
            var allTrees = new List<TreeNode>();
            if (start > end)
            {
                allTrees.Add(null);
                return allTrees;
            }
            for (int i = start; i <= end; i++)
            {
                // 获得所有可行的左子树集合
                var leftTrees = generateTreesII(start, i - 1);
                // 获得所有可行的右子树集合
                var rightTrees = generateTreesII(i + 1, end);
                // 从左子树集合中选出一棵左子树，从右子树集合中选出一棵右子树，拼接到根节点上
                for (int j = 0; j < leftTrees.Count; j++)
                {
                    for (int k = 0; k < rightTrees.Count; k++)
                    {
                        var root = new TreeNode(i);
                        root.left = leftTrees[j];
                        root.right = rightTrees[k];
                        allTrees.Add(root);
                    }
                }
            }
            return allTrees;
        }

        #endregion

        #region 96. 不同的二叉搜索树
        /// <summary>
        /// 给你一个整数 n ，求恰由 n 个节点组成且节点值从 1 到 n 互不相同的 二叉搜索树 有多少种？返回满足题意的二叉搜索树的种数。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumTrees(int n)
        {
            if (n <= 0) return 0;
            return generateTrees(1, n);
        }

        public static int generateTrees(int start, int end)
        {
            int count = 1;
            if (start > end)
            {
                return count;
            }
            for (int i = start; i <= end; i++)
            {
                // 获得所有可行的左子树集合
                var leftCount = generateTrees(start, i - 1);
                // 获得所有可行的右子树集合
                var rightCount = generateTrees(i + 1, end);
                // 从左子树集合中选出一棵左子树，从右子树集合中选出一棵右子树，拼接到根节点上
                count += leftCount * rightCount;
            }
            return count;
        }

        #endregion

        #region 222. 完全二叉树的节点个数
        public static int CountNodes(TreeNode root)
        {
            var count = 0;
            if (root == null) return count;
            count++;
            count += CountNodes(root.left);
            count += CountNodes(root.right);

            return count;
        }



        #endregion

        #region 226. 翻转二叉树
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
        #endregion

        #region 238. 除自身以外数组的乘积
        /// <summary>
        /// 给你一个整数数组 nums，返回 数组 answer ，其中 answer[i] 等于 nums 中除 nums[i] 之外其余各元素的乘积 。
        /// 题目数据 保证 数组 nums之中任意元素的全部前缀元素和后缀的乘积都在  32 位 整数范围内。
        /// 请 不要使用除法，且在 O(n) 时间复杂度内完成此题。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] ProductExceptSelf(int[] nums)
        {
            var arr = new int[nums.Length];

            var arrL = new int[nums.Length];
            var arrR = new int[nums.Length];

            arrL[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                arrL[i] = nums[i - 1] * arrL[i - 1];
            }
            arrR[nums.Length - 1] = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                arrR[i] = nums[i + 1] * arrR[i + 1];
            }


            for (int i = 0; i < nums.Length; i++)
            {
                arr[i] = arrL[i] * arrR[i];
            }

            return arr;
        }


        #endregion

        #region 257. 二叉树的所有路径
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            var list = new List<string>();
            var sb = new StringBuilder();
            BinaryTreePaths(root, list, sb);
            return list;
        }

        private static void BinaryTreePaths(TreeNode root, List<string> list, StringBuilder sb)
        {
            if (root == null) return;
            var str = $"{root.val}";
            if (root.left == null && root.right == null)
            {
                // 叶子节点
                sb.Append(str);
                list.Add(sb.ToString());
                sb.Remove(sb.Length - str.Length, str.Length);
                return;
            }
            sb.Append(str);
            sb.Append('-');
            sb.Append('>');
            if (root.left != null)
            {
                BinaryTreePaths(root.left, list, sb);
            }
            if (root.right != null)
            {
                BinaryTreePaths(root.right, list, sb);
            }
            sb.Remove(sb.Length - 2 - str.Length, 2 + str.Length);
        }

            #endregion

            #region 274. H 指数
            /// <summary>
            /// 给你一个整数数组 citations ，其中 citations[i] 表示研究者的第 i 篇论文被引用的次数。计算并返回该研究者的 h 指数。
            /// 根据维基百科上 h 指数的定义：h 代表“高引用次数” ，一名科研人员的 h 指数 是指他（她）至少发表了 h 篇论文，并且每篇论文 至少 被引用 h 次。如果 h 有多种可能的值，h 指数 是其中最大的那个。
            /// </summary>
            /// <param name="citations"></param>
            /// <returns></returns>
            public static int HIndex(int[] citations)
        {
            if (citations == null || citations.Length <= 0) return 0;
            if (citations.Length == 1)
            {
                return Math.Min(1, citations[0]);
            }

            Array.Sort(citations);
            var i = citations.Length - 1;
            var h = 0;
            while (i >= 0 && citations[i] > h)
            {
                h++;
                i--;
            }
            return h;

            //var sortSet = new SortedList<int, HIndexData>(new SortHIndex());

            //for (int i = 0; i < citations.Length; i++)
            //{
            //    var val = citations[i];
            //    var perCount = 1;
            //    foreach (var item in sortSet)
            //    {
            //        if (val >= item.Key)
            //        {
            //            item.Value.refCount += 1;
            //        }
            //        if(item.Key >= val && perCount <= 1)
            //        {
            //            perCount += item.Value.refCount;
            //        }
            //    }
            //    if (!sortSet.TryGetValue(val, out var count))
            //    {
            //        sortSet[val] = new HIndexData { count = val, refCount = perCount };
            //    }
            //}
            //var refCount = 0;
            //foreach (var item in sortSet)
            //{
            //    refCount = Math.Max(refCount, Math.Min(item.Key, item.Value.refCount));
            //}

            //return refCount;
        }

        public class SortHIndex : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x - y;
            }
        }

        public class HIndexData
        {
            public int count;
            public int refCount;
        }

        #endregion
    }
}
