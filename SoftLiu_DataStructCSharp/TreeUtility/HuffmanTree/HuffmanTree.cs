using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 最优二叉树 (他是n个带权叶子节点构成的所有二叉树中，带权路径最小的二叉树)
    /// 赫夫曼树
    /// </summary>
    public class HuffmanTree
    {
        /*
                叶节点的带权路径 
                树的带权路径长度WPL -> 树中所有叶子节点的带权路径长度之和

        1. 排序
            每个对象就是一个节点
         */

        public void Awake()
        {
            int[] arr = new int[] { 3, 7, 8, 29, 5, 11, 23, 14 };
            Node root = createHuffmanTree(arr);
            Console.WriteLine(root.ToString());
        }

        private Node createHuffmanTree(int[] arr)
        {
            // 先使用数组中所有的元素创建若干个二叉树  （只有一个节点）
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < arr.Length; i++)
            {
                nodes.Add(new Node(arr[i]));
            }
            // 循环处理
            while (nodes.Count > 1)
            {
                // 排序
                nodes.Sort();
                // 取出权值最小的两个二叉树
                Node left = nodes[nodes.Count - 1];
                nodes.RemoveAt(nodes.Count - 1);

                Node right = nodes[nodes.Count - 1];
                nodes.RemoveAt(nodes.Count - 1);
                Node parent = new Node(left.value + right.value);
                parent.left = left;
                parent.right = right;
                nodes.Add(parent);
            }
            return nodes[0];
        }
    }


    public class Node : IComparable<Node>
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int _value)
        {
            this.value = _value;
        }

        public int CompareTo(Node other)
        {
            return -(this.value - other.value);
        }

        public override string ToString()
        {
            return string.Format("Node [value:{0}]", this.value);
        }
    }
}
