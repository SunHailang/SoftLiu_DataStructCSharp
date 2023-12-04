using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    public static class Time20231204
    {
        public static void Run()
        {
            var root = BstToGst(new TreeNode());



        }
        // 左右中
        // 左中右
        // 根左右

        public static void LogTree(TreeNode root, Queue<int> queue)
        {
            if(root != null)
            {
                queue.Enqueue(root.val);
                LogTree(root.left, queue);
                LogTree(root.right, queue);
            }            
        }

        
        public static TreeNode BstToGst(TreeNode root)
        {
            var stack = new Stack<int>();
            var value = 0;
            GetNode(root, stack, ref value);

            return root;
        }

        private static void GetNode(TreeNode root, Stack<int> stack, ref int value)
        {
            if(root.right != null)
            {
                GetNode(root.right, stack, ref value);
            }
            stack.Push(root.val);
            value += root.val;
            root.val = value;
            if(root.left != null)
            {
                GetNode(root.left, stack, ref value);
            }
        }
    }

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

}
