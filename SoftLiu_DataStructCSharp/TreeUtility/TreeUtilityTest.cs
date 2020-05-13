using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    public class TreeUtilityTest
    {
        public static void Test()
        {
            //BinaryTreeTest();
            //BinaryTreePreErgodicTest();
            //BinaryTreeMidErgodicTest();
            //BinaryTreeAfterErgodicTest();
            //BinaryTreeLayerErgodicTest();
            //BinaryTreeMaxDepthTest();
            //PagerFolderTest
            QuadTreeTest();
        }

        private static void QuadTreeTest()
        {
            Rectangle rect = new Rectangle(200, 200, 200, 200);
            QuadTree tree = new QuadTree(rect, 4);

            for (int i = 0; i < 5; i++)
            {
                Random rd = new Random(i);
                Point point = new Point(rd.Next(0, 400), rd.Next(0, 400));
                Console.WriteLine(tree.insert(point));
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 二叉树的测试
        /// </summary>
        private static void BinaryTreeTest()
        {
            BinaryTree<int, string> tree = new BinaryTree<int, string>();
            tree.put(1, "zhangsan");
            tree.put(2, "lisi");
            tree.put(3, "wangwu");
            Console.WriteLine("Length: " + tree.length());

            string t1 = tree.get(3);
            Console.WriteLine("Get: " + t1);
            tree.delete(1);

            Console.WriteLine("Length: " + tree.length());
        }
        /// <summary>
        /// 前序遍历 的测试
        /// </summary>
        private static void BinaryTreePreErgodicTest()
        {
            BinaryTree<string, string> tree = new BinaryTree<string, string>();
            tree.put("E", "5");
            tree.put("B", "2");
            tree.put("G", "7");
            tree.put("A", "1");
            tree.put("D", "4");
            tree.put("F", "6");
            tree.put("H", "8");
            tree.put("C", "3");

            QueueList<string> keys = tree.preErgodic();
            if (keys != null)
            {
                IEnumerator ie = keys.GetEnumerator();
                while (ie.MoveNext())
                {
                    string value = tree.get(ie.Current.ToString());
                    Console.WriteLine(ie.Current.ToString() + "------" + value);
                }
            }
            else
            {
                Console.WriteLine("not keys.");
            }
        }
        /// <summary>
        /// 中序遍历 的测试 
        /// 中序遍历 得到的是 从小大大的顺序
        /// </summary>
        private static void BinaryTreeMidErgodicTest()
        {
            BinaryTree<string, string> tree = new BinaryTree<string, string>();
            tree.put("E", "5");
            tree.put("B", "2");
            tree.put("G", "7");
            tree.put("A", "1");
            tree.put("D", "4");
            tree.put("F", "6");
            tree.put("H", "8");
            tree.put("C", "3");

            QueueList<string> keys = tree.midErgodic();
            if (keys != null)
            {
                IEnumerator ie = keys.GetEnumerator();
                while (ie.MoveNext())
                {
                    string value = tree.get(ie.Current.ToString());
                    Console.WriteLine(ie.Current.ToString() + "------" + value);
                }
            }
            else
            {
                Console.WriteLine("not keys.");
            }
        }
        /// <summary>
        /// 后续遍历 的测试
        /// </summary>
        private static void BinaryTreeAfterErgodicTest()
        {
            BinaryTree<string, string> tree = new BinaryTree<string, string>();
            tree.put("E", "5");
            tree.put("B", "2");
            tree.put("G", "7");
            tree.put("A", "1");
            tree.put("D", "4");
            tree.put("F", "6");
            tree.put("H", "8");
            tree.put("C", "3");

            QueueList<string> keys = tree.afterErgodic();
            if (keys != null)
            {
                IEnumerator ie = keys.GetEnumerator();
                while (ie.MoveNext())
                {
                    string value = tree.get(ie.Current.ToString());
                    Console.WriteLine(ie.Current.ToString() + "------" + value);
                }
            }
            else
            {
                Console.WriteLine("not keys.");
            }
        }
        /// <summary>
        /// 层序遍历 的测试
        /// </summary>
        private static void BinaryTreeLayerErgodicTest()
        {
            BinaryTree<string, string> tree = new BinaryTree<string, string>();
            tree.put("E", "5");
            tree.put("B", "2");
            tree.put("G", "7");
            tree.put("A", "1");
            tree.put("D", "4");
            tree.put("F", "6");
            tree.put("H", "8");
            tree.put("C", "3");

            QueueList<string> keys = tree.layerErgodic();
            if (keys != null)
            {
                IEnumerator ie = keys.GetEnumerator();
                while (ie.MoveNext())
                {
                    string value = tree.get(ie.Current.ToString());
                    Console.WriteLine(ie.Current.ToString() + "------" + value);
                }
            }
            else
            {
                Console.WriteLine("not keys.");
            }
        }
        /// <summary>
        /// 最大深度的测试
        /// </summary>
        private static void BinaryTreeMaxDepthTest()
        {
            BinaryTree<string, string> tree = new BinaryTree<string, string>();
            tree.put("E", "5");
            tree.put("B", "2");
            tree.put("G", "7");
            tree.put("A", "1");
            tree.put("D", "4");
            tree.put("F", "6");
            tree.put("H", "8");
            tree.put("C", "3");

            int maxDepth = tree.maxDepth();
            Console.WriteLine("Max Depth: " + maxDepth);
        }
        /// <summary>
        /// 折纸问题
        /// </summary>
        private static void PagerFolderTest()
        {
            // 模拟折纸 生成树
            int count = 3;
            // 定义根节点
            Node<string> root = null;
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    root = new Node<string>("down", null, null);
                }
                else
                {
                    // 当前不是第一次对折
                }
            }
            // 遍历树 打印每个节点
        }


        public class Node<T>
        {
            public T item;
            public Node<T> left;
            public Node<T> right;
            public Node(T t, Node<T> left, Node<T> right)
            {
                this.item = t;
                this.left = left;
                this.right = right;
            }
        }
    }
}
