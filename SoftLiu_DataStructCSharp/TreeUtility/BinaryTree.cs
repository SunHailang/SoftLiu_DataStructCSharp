using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 二叉查找树   二分法[时间复杂度:O(LogN)] 转化成数据结构 就是一个二叉查找树
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class BinaryTree<TKey, TValue>
        where TKey : IComparable
    {
        private Node root;
        private int N;

        private class Node
        {
            public TKey key;
            public TValue value;
            public Node left;
            public Node right;
            public Node(TKey key, TValue value, Node left, Node right)
            {
                this.key = key;
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }

        public BinaryTree()
        {
            this.root = null;// new Node(default(TKey), default(TValue), null, null);
            this.N = 0;
        }

        public int length()
        {
            return this.N;
        }

        public void put(TKey key, TValue value)
        {
            this.root = put(this.root, key, value);
        }
        private Node put(Node x, TKey key, TValue value)
        {
            // 如果当前 x 子树中没有任何节点，为空， 则直接把插入的节点当做根节点
            if (x == null)
            {
                this.N++;
                return new Node(key, value, null, null);
            }
            // 当前树 x 子树不为空
            // 比较x节点的键和key大小
            int cmp = key.CompareTo(x.key);
            if (cmp > 0)
            {
                // 如果key大于x节点的键，则继续找x节点的右子树
                x.right = put(x.right, key, value);
            }
            else if (cmp < 0)
            {
                // 如果key小于x节点的键，则继续找x节点的左子树
                x.left = put(x.left, key, value);
            }
            else
            {
                // 如果key等于x节点的键，ze替换x节点的值
                x.value = value;
            }
            return x;
        }

        public TValue get(TKey key)
        {
            return get(this.root, key);
        }
        private TValue get(Node x, TKey key)
        {
            // x 树为null
            if (x == null) return default(TValue);
            // x 树不是null
            // 比好key和x节点的键的大小
            int cmp = key.CompareTo(x.key);
            if (cmp > 0)
            {
                // 如果key小于x节点的键，则继续找x节点的右子树
                return get(x.right, key);
            }
            else if (cmp < 0)
            {
                // 如果key大于x节点的键，则继续找x节点的左子树
                return get(x.left, key);
            }
            else
            {
                // 如果key等于x节点的键，ze替换x节点的值 就找到了键为key的节点返回此时的 value
                return x.value;
            }
        }

        public void delete(TKey key)
        {
            delete(this.root, key);
        }
        private Node delete(Node x, TKey key)
        {
            // x树为null
            if (x == null) return null;
            // x 树不是 null
            // 比好key和x节点的键的大小
            int cmp = key.CompareTo(x.key);
            if (cmp > 0)
            {
                // 如果key小于x节点的键，则继续找x节点的右子树
                x.right = delete(x.right, key);
            }
            else if (cmp < 0)
            {
                // 如果key大于x节点的键，则继续找x节点的左子树
                x.left = delete(x.left, key);
            }
            else
            {
                this.N--;
                // 如果key等于x节点的键，ze替换x节点的值 就找到了键为key的节点返回此时的 完成要删除的节点 x
                // 首选找到一个节点替换当前节点：找到右子树中最小的节点
                if (x.right == null)
                {
                    return x.left;
                }
                if (x.left == null)
                {
                    return x.right;
                }
                // 找右子树最小节点
                Node minNode = x.right;
                while (minNode.left != null)
                {
                    minNode = minNode.left;
                }
                // 删除 右子树最小节点
                Node n = x.right;
                while (n.left != null)
                {
                    if (n.left.left == null)
                    {
                        n.left = null;
                    }
                    else
                    {
                        // 变换n节点
                        n = n.left;
                    }
                }
                // 让x节点的左子树成为 minNode的左子树
                minNode.left = x.left;
                // 让x节点的右子树成为 minNode的右子树
                minNode.right = x.right;
                // 让x节点的父节点成为 nimNode的父节点
                x = minNode;
                // 让元素个数 -1
            }
            return x;
        }
        /// <summary>
        /// 查找整个树中最小键
        /// </summary>
        /// <returns></returns>
        public TKey minKey()
        {
            if (this.root == null) return default(TKey);
            return minKey(this.root).key;
        }
        /// <summary>
        /// 在指定节点x中找出最小键
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private Node minKey(Node x)
        {
            // 判断 x 有左子节点.  有：继续查找左子健
            if (x.left != null)
            {
                return minKey(x.left);
            }
            else
            {
                return x;
            }
        }
        /// <summary>
        /// 在整个树中找到最大键
        /// </summary>
        /// <returns></returns>
        public TKey maxKey()
        {
            if (this.root == null) return default(TKey);
            return maxKey(this.root).key;
        }
        /// <summary>
        /// 在指定节点找到最小键
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private Node maxKey(Node x)
        {
            // 判断 x 节点的右子节点， 有：继续向右，没有：x就是最大键的节点
            if (x.right != null)
                return maxKey(x.right);
            else
                return x;
        }
        /// <summary>
        /// 前序遍历法
        /// 深度优先的思想
        /// </summary>
        /// <returns></returns>
        public QueueList<TKey> preErgodic()
        {
            if (this.root == null) return null;
            QueueList<TKey> keys = new QueueList<TKey>();
            preErgodic(this.root, keys);
            return keys;
        }
        /// <summary>
        /// 获取指定节点的所有键
        /// </summary>
        /// <param name="x"></param>
        /// <param name="keys"></param>
        private void preErgodic(Node x, QueueList<TKey> keys)
        {
            if (x == null) return;
            // 把x节点的key放到keys中
            keys.enqueue(x.key);
            // 递归调用遍历x节点的左子树
            if (x.left != null)
                preErgodic(x.left, keys);
            // 递归遍历x节点的右子树
            if (x.right != null)
                preErgodic(x.right, keys);
        }
        /// <summary>
        /// 使用 中序遍历 把整个数的键返回   
        /// 中序遍历 得到的是一个从小到大的队列
        /// 深度优先的思想
        /// </summary>
        /// <returns></returns>
        public QueueList<TKey> midErgodic()
        {
            if (this.root == null) return null;
            QueueList<TKey> keys = new QueueList<TKey>();
            midErgodic(this.root, keys);
            return keys;
        }
        /// <summary>
        /// 使用中序遍历 获取指定树x中的所有键，放到keys中
        /// </summary>
        /// <param name="x"></param>
        /// <param name="keys"></param>
        private void midErgodic(Node x, QueueList<TKey> keys)
        {
            if (x == null) return;
            // 先递归 把左子树的键放到 keys中
            if (x.left != null)
            {
                midErgodic(x.left, keys);
            }
            // 在把根节点的键放到 keys中
            keys.enqueue(x.key);
            // 递归把右子键放到keys中
            if (x.right != null)
            {
                midErgodic(x.right, keys);
            }
        }
        /// <summary>
        /// 使用 后序遍历 把整个树的键返回
        /// </summary>
        /// <returns></returns>
        public QueueList<TKey> afterErgodic()
        {
            if (this.root == null) return null;
            QueueList<TKey> keys = new QueueList<TKey>();
            afterErgodic(this.root, keys);
            return keys;
        }
        /// <summary>
        /// 使用后序遍历 把指定树x中的键放到 keys中
        /// 深度优先的思想
        /// </summary>
        private void afterErgodic(Node x, QueueList<TKey> keys)
        {
            if (x == null) return;
            // 递归 先把左子树的键放到keys中
            if (x.left != null)
                afterErgodic(x.left, keys);
            // 递归 把右子树的键放到keys中
            if (x.right != null)
                afterErgodic(x.right, keys);
            // 把 x 节点的键放到keys中
            keys.enqueue(x.key);
        }
        /// <summary>
        /// 层序遍历
        /// 广度优先的思想
        /// </summary>
        /// <returns></returns>
        public QueueList<TKey> layerErgodic()
        {
            // 定义两个队列， 分别存储树中的键，和树中的节点
            QueueList<Node> nodes = new QueueList<Node>();
            QueueList<TKey> keys = new QueueList<TKey>();

            // 默认往队列中放入根节点
            nodes.enqueue(this.root);
            while (!nodes.isEmpty())
            {
                // 从 nodes队列中弹出节点，把键放到keys中
                Node n = nodes.dequeue();
                keys.enqueue(n.key);
                // 判断当前节点有没有左子节点， 有：放入nodes中
                if (n.left != null)
                    nodes.enqueue(n.left);
                // 判断当前节点有没有右子节点，有：放入nodes中
                if (n.right != null)
                    nodes.enqueue(n.right);
            }
            return keys;
        }
        /// <summary>
        /// 获取整个树的最大深度
        /// </summary>
        /// <returns></returns>
        public int maxDepth()
        {
            return maxDepth(this.root);
        }
        /// <summary>
        /// 获取指定树x的最大深度
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int maxDepth(Node x)
        {
            if (x == null) return 0;
            // x 的最大深度
            int max = 0;
            // 左子树 的最大深度
            int maxL = 0;
            // 右子树 的最大深度
            int maxR = 0;
            // 计算 x节点 左子树的最大深度
            if (x.left != null)
                maxL = maxDepth(x.left);
            // 计算 x节点 右子树的最大深度
            if (x.right != null)
                maxR = maxDepth(x.right);
            // 比较 左子树的最大深度， 右子树的最大深度  +1
            max = Math.Max(maxL, maxR) + 1;
            return max;
        }
    }
}
