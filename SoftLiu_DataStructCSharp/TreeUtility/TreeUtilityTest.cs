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
            //PagerFolderTest();
            //QuadTreeTest();
            //HeapTest();
            //HeapSortTest();
            //MaxPriorityQueueTest();
            //MinPriorityQueueTest();
            IndexMinPriorityQueueTest();
        }
        /// <summary>
        /// 四叉树的测试
        /// </summary>
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
        /// 堆  测试
        /// </summary>
        private static void HeapTest()
        {
            // 创建堆对象
            Heap<string> heap = new Heap<string>(10);
            // 往堆中插入数据
            heap.insert("Z");
            heap.insert("A");
            heap.insert("C");
            heap.insert("B");
            Console.WriteLine("Insert end");
            // 循环删除数据
            StringBuilder sb = new StringBuilder();
            string result = default(string);
            while ((result = heap.delMax()) != default(string))
            {
                sb.Append(result + ",");
            }
            Console.WriteLine(sb.ToString());
        }
        /// <summary>
        /// 堆排序 测试
        /// </summary>
        private static void HeapSortTest()
        {
            // 待排序的数组
            string[] array = new string[] { "Z", "A", "C", "B" };
            HeapSort<string>.sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
        }

        private static void MaxPriorityQueueTest()
        {
            MaxPriorityQueue<string> queue = new MaxPriorityQueue<string>(10);
            // 往队列中存储元素
            queue.insert("Z");
            queue.insert("A");
            queue.insert("C");
            queue.insert("B");
            queue.insert("D");
            queue.insert("F");
            queue.insert("E");
            // 通过循环获取队列中的元素
            Console.WriteLine("Length: " + queue.length());
            while (!queue.isEmpty())
            {
                string max = queue.delMax();
                Console.Write(max + ",");
            }
        }
        /// <summary>
        /// 最小优先队列 测试
        /// </summary>
        private static void MinPriorityQueueTest()
        {
            MinPriorityQueue<string> queue = new MinPriorityQueue<string>(10);
            queue.insert("Z");
            queue.insert("A");
            queue.insert("C");
            queue.insert("B");
            queue.insert("D");
            queue.insert("F");
            queue.insert("E");
            // 通过循环获取队列中的元素
            Console.WriteLine("Length: " + queue.length());
            while (!queue.isEmpty())
            {
                string min = queue.delMin();
                Console.Write(min + ",");
            }
        }
        /// <summary>
        /// 索引优先最小队列 测试
        /// </summary>
        private static void IndexMinPriorityQueueTest()
        {
            // 创建索引优先最小队列
            IndexMinPriorityQueue<string> queue = new IndexMinPriorityQueue<string>(10);
            queue.insert(0, "Z");
            queue.insert(1, "A");
            queue.insert(2, "C");
            queue.insert(3, "B");
            Console.WriteLine("Length: " + queue.length());
            //queue.changeItem(2, "M");
            Console.WriteLine("Length: " + queue.length());

            queue.delete(0);
            Console.WriteLine("Length: " + queue.length());
            while (!queue.isEmpty())
            {
                int index = queue.delMinIndex();
                Console.Write(index + ",");
            }
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
                    continue;
                }
                // 当前不是第一次对折
                // 定义一个辅助队列， 通过层序遍历的思想，找到叶子节点，叶子节点添加子节点
                QueueList<Node<string>> queue = new QueueList<Node<string>>();
                queue.enqueue(root);
                while (!queue.isEmpty())
                {
                    // 从队列中弹出一个节点
                    Node<string> temp = queue.dequeue();
                    // 如果有左子节点 或 右子节点，把子节点放到队列中
                    if (temp.left != null) queue.enqueue(temp.left);
                    if (temp.right != null) queue.enqueue(temp.right);
                    // 如果没有子节点， 则需要该节点添加左子节点和右子节点
                    if (temp.left == null && temp.right == null)
                    {
                        temp.left = new Node<string>("down", null, null);
                        temp.right = new Node<string>("up", null, null);
                    }
                }
            } // create root tree

            // 遍历树 (中序遍历) 打印每个节点
            printTree(root);
        }
        private static void printTree(Node<string> root)
        {
            if (root == null) return;
            // 打印左子树的每个节点
            if (root.left != null)
                printTree(root.left);
            // 打印当前节点
            Console.Write(root.item + " ");

            // 打印右子树每个节点
            if (root.right != null)
                printTree(root.right);
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
