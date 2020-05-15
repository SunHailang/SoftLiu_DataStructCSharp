using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 红黑树  本身要是一个平衡树
    /// </summary>
    public class RedBlackTree<TKey, TValue>
        where TKey : IComparable
    {
        /// <summary>
        /// 根节点
        /// </summary>
        private Node root;
        /// <summary>
        /// 记录树中元素个数
        /// </summary>
        private int N;
        /// <summary>
        /// 红色链接
        /// </summary>
        private const bool RED = true;
        /// <summary>
        /// 黑色链接
        /// </summary>
        private const bool BLACK = false;

        private class Node
        {
            /// <summary>
            /// 记录左子节点
            /// </summary>
            public Node left;
            /// <summary>
            /// 记录右子节点
            /// </summary>
            public Node right;
            /// <summary>
            /// 键
            /// </summary>
            public TKey key;
            /// <summary>
            /// 值
            /// </summary>
            public TValue value;
            /// <summary>
            /// 由父节点指向他的链接颜色
            /// </summary>
            public bool color;


            public Node(TKey key, TValue value, Node left, Node right, bool color)
            {
                this.key = key;
                this.value = value;
                this.left = left;
                this.right = right;
                this.color = color;
            }
        }


        public RedBlackTree()
        {
            this.root = null;
            this.N = 0;
        }
        /// <summary>
        /// 获取树的元素个数
        /// </summary>
        /// <returns></returns>
        public int length()
        {
            return this.N;
        }
        /// <summary>
        /// 判断当前节点的父指向节点是否为红色, 空连接默认是黑色
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool isRed(Node x)
        {
            if (x == null) return false;
            return x.color == RED;
        }
        /// <summary>
        /// 左旋转
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private Node rotateLeft(Node h)
        {
            // 获取h节点的右子节点，表示为x
            Node x = h.right;
            // 让x节点的左子节点成为h节点的右子节点
            h.right = x.left;
            // 让h成为x节点的左子节点
            x.left = h;
            // 让x节点的color属性等于h节点的color属性
            x.color = h.color;
            // 让h节点的color属性变为红色
            h.color = RED;
            return x;
        }
        /// <summary>
        /// 右旋转
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        private Node rotateRight(Node h)
        {
            // 获取h节点的左子节点，表示x
            Node x = h.left;
            // 让h节点的左子节点成为x节点的右子节点
            h.left = x.right;
            // 让h成为x节点的右子节点
            x.right = h;
            // 让h节点的color属性等于x节点的color属性
            x.color = h.color;
            // 让h节点的color属性变为红色
            h.color = RED;
            return x;
        }
        /// <summary>
        /// 颜色反转
        /// </summary>
        /// <param name="h"></param>
        private void flipColor(Node h)
        {
            // 当前节点 设为红色
            h.color = RED;
            // 左子节点，和右子节点都为黑色
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        public void insert(TKey key, TValue value)
        {
            this.root = insert(this.root, key, value);
            // 根节点的颜色总是黑色
            this.root.color = BLACK;
        }

        private Node insert(Node h, TKey key, TValue value)
        {
            // 判断h是否为空， 如果是空直接返回一个红色的节点
            if (h == null)
            {
                this.N++;
                return new Node(key, value, null, null, RED);
            }
            // 比较h节点的键和key的大小， 如果key小往左走，如果大往右走
            int cmp = key.CompareTo(h.key);
            if (cmp <= 0)
            {
                h.left = insert(h.left, key, value);
            }
            else if (cmp > 0)
            {
                h.right = insert(h.right, key, value);
            }
            else
            {
                h.value = value;
            }
            // 保证树的平衡性
            // 左旋, 当前节点h的左子节点 是黑色  ，右子节点是红色
            if (isRed(h.right) && !isRed(h.left))
            {
                h = rotateLeft(h);
            }
            // 右旋,当前节点h的左子节点和左子节点的左子节点都是红色
            if (isRed(h.left) && isRed(h.left.left))
            {
                h = rotateRight(h);
            }
            // 颜色反转, 当前节点的左子节点和右子节点都是红色
            if (isRed(h.left) && isRed(h.right))
            {
                flipColor(h);
            }
            return h;
        }

        public TValue get(TKey key)
        {
            return get(this.root, key);
        }

        private TValue get(Node x, TKey key)
        {
            if (x == null) return default(TValue);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                return get(x.left, key);
            }
            else if (cmp > 0)
            {
                return get(x.right, key);
            }
            else
            {
                return x.value;
            }
        }

    }
}
