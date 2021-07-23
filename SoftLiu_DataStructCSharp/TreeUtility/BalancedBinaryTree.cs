using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    public class BalancedBinaryTree<TKey, TValue> where TKey : IComparable
    {

        public class Node
        {
            public TKey key;
            public TValue value;
            public Node left, right;
            public int height;// 记录节点的高度

            public Node(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
                left = null;
                right = null;
                height = 1;
            }
        }

        private Node root;
        private int size;

        public BalancedBinaryTree()
        {
            root = null;
            size = 0;
        }

        public int getSize()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }
        /// <summary>
        /// 获得节点node的高度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int getHeight(Node node)
        {
            if (node == null)
                return 0;
            return node.height;
        }

        /// <summary>
        /// 获得节点node的平衡因子
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int getBalanceFactor(Node node)
        {
            if (node == null)
                return 0;
            return getHeight(node.left) - getHeight(node.right);
        }

        /// <summary>
        ///  添加元素
        /// </summary>
        /// <param name="k"></param>
        /// <param name="e"></param>
        public void add(TKey k, TValue e)
        {
            root = add(root, k, e);
        }


        /// <summary>
        /// 向以node为根的二分搜索树中插入元素(key, value)，递归算法
        /// 时间复杂度 O(log n)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>返回插入新节点后二分搜索树的根</returns>
        private Node add(Node node, TKey key, TValue value)
        {

            if (node == null)
            {
                size++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) < 0)
                node.left = add(node.left, key, value);
            else if (key.CompareTo(node.key) > 0)
                node.right = add(node.right, key, value);
            else // key.compareTo(node.key) == 0
                node.value = value;

            // 更新height
            node.height = 1 + Math.Max(getHeight(node.left), getHeight(node.right));

            // 计算平衡因子
            int balanceFactor = getBalanceFactor(node);

            // 平衡维护
            //
            // LL  T1<>//
            // y x //
            // / \ /   \ //
            // x   T4 向右旋转 (y) z y //
            // / \ - - - - - - - -> / \   / \ //
            // z   T3 T1 T2 T3 T4 //
            //   / \ //
            // T1   T2 //
            //
            if (balanceFactor > 1 && getBalanceFactor(node.left) >= 0)
                return rightRotate(node);
            //
            //  LR  T1<>//
            // y y z //
            // / \ / \ /   \ //
            // x  t4 向左旋转（x） z   T4 向右旋转（y） x y //
            // / \ ---------------> / \ --------------->   / \   / \ //
            // T1  z x   T3 T1  T2 T3 T4 //
            // / \ / \ //
            // T2  T3 T1   T2 //
            //
            if (balanceFactor > 1 && getBalanceFactor(node.left) < 0)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }
            //
            // RR: T1<>//
            // y x //
            //  /  \ /   \ //
            // T1   x 向左旋转 (y) y z //
            // / \   - - - - - - - -> / \   / \ //
            //   T2   z T1 T2 T3 T4 //
            // / \ //
            // T3 T4 //
            //
            if (balanceFactor < -1 && getBalanceFactor(node.right) <= 0)
                return leftRotate(node);

            //
            // RL: T1<>//
            // y y z //
            // / \ / \ /   \ //
            // T1  x 向右旋转（x） T1  z 向左旋转（y） y x //
            // / \ - - - - - - -> / \ - - - - - - - - -> / \   / \ //
            // z  T4 T2  x T1 T2 T3 T4 //
            // / \ / \ //
            // T2  T3 T3  T4 //
            //
            if (balanceFactor < -1 && getBalanceFactor(node.right) > 0)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            return node;
        }



        /// <summary>
        /// 对节点y进行向右旋转操作，返回旋转后新的根节点x
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T3 = x.right;

            // 向右旋转过程
            x.right = y;
            y.left = T3;

            // 更新height
            y.height = Math.Max(getHeight(y.left), getHeight(y.right)) + 1;
            x.height = Math.Max(getHeight(x.left), getHeight(x.right)) + 1;

            return x;
        }


        /// <summary>
        /// 对节点y进行向左旋转操作，返回旋转后新的根节点x
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private Node leftRotate(Node y)
        {
            Node x = y.right;
            Node T2 = x.left;

            // 向左旋转过程
            x.left = y;
            y.right = T2;

            // 更新height
            y.height = Math.Max(getHeight(y.left), getHeight(y.right)) + 1;
            x.height = Math.Max(getHeight(x.left), getHeight(x.right)) + 1;

            return x;
        }

        /// <summary>
        /// 从二分搜索树中删除键为key的节点
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue remove(TKey key)
        {

            Node node = getNode(root, key);
            if (node != null)
            {
                root = remove(root, key);
                return node.value;
            }
            return default;
        }


        /// <summary>
        /// 删除指定的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node remove(Node node, TKey key)
        {

            if (node == null)
                return null;

            Node retNode;
            if (key.CompareTo(node.key) < 0)
            {
                node.left = remove(node.left, key);
                // return node;
                retNode = node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.right = remove(node.right, key);
                // return node;
                retNode = node;
            }
            else
            {   // key.compareTo(node.key) == 0 找到待删除的节点 node
                // 待删除节点左子树为空，直接将右孩子替代当前节点
                if (node.left == null)
                {
                    Node rightNode = node.right;
                    node.right = null;
                    size--;
                    // return rightNode;
                    retNode = rightNode;
                }

                // 待删除节点右子树为空，直接将左孩子替代当前节点
                else if (node.right == null)
                {
                    Node leftNode = node.left;
                    node.left = null;
                    size--;
                    // return leftNode;
                    retNode = leftNode;
                }

                // 待删除节点左右子树均不为空的情况
                else
                {
                    // 待删除节点左右子树均不为空
                    // 找到右子树最小的元素，替代待删除节点
                    Node successor = minimum(node.right);
                    //successor.right = removeMin(node.right);
                    successor.right = remove(node.right, successor.key);
                    successor.left = node.left;

                    node.left = node.right = null;

                    // return successor;
                    retNode = successor;
                }
            }

            if (retNode == null)
                return null;

            // 更新height
            retNode.height = 1 + Math.Max(getHeight(retNode.left), getHeight(retNode.right));

            // 计算平衡因子
            int balanceFactor = getBalanceFactor(retNode);

            // 平衡维护
            // LL
            if (balanceFactor > 1 && getBalanceFactor(retNode.left) >= 0)
                return rightRotate(retNode);

            // RR
            if (balanceFactor < -1 && getBalanceFactor(retNode.right) <= 0)
                return leftRotate(retNode);

            // LR
            if (balanceFactor > 1 && getBalanceFactor(retNode.left) < 0)
            {
                retNode.left = leftRotate(retNode.left);
                return rightRotate(retNode);
            }

            // RL
            if (balanceFactor < -1 && getBalanceFactor(retNode.right) > 0)
            {
                retNode.right = rightRotate(retNode.right);
                return leftRotate(retNode);
            }

            return retNode;
        }

        /// <summary>
        /// 返回以node为根的二分搜索树的最小值所在的节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node minimum(Node node)
        {
            if (node.left == null)
                return node;
            return minimum(node.left);
        }

        /// <summary>
        /// 返回以node为根节点的二分搜索树中，key所在的节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node getNode(Node node, TKey key)
        {

            if (node == null)
                return null;

            if (key.CompareTo(node.key) == 0)
                return node;
            else if (key.CompareTo(node.key) < 0)
                return getNode(node.left, key);
            else // if(key.compareTo(node.key) > 0)
                return getNode(node.right, key);
        }

        /**
         * 判断是否包含 key
         * @param key
         * @return
        */
        public bool contains(TKey key)
        {
            return getNode(root, key) != null;
        }

        /**
         * 获取指定 key 的 value
         * @param key
         * @return
        */
        public TValue get(TKey key)
        {

            Node node = getNode(root, key);
            return node == null ? default : node.value;
        }

        /**
         * 设置 key 对应元素的值 value
         * @param key
         * @param newValue
        */
        public void set(TKey key, TValue newValue)
        {
            Node node = getNode(root, key);
            if (node == null)
                throw new Exception(key + " doesn't exist!");

            node.value = newValue;
        }


        /// <summary>
        /// 判断该二叉树是否是一棵二分搜索树
        /// </summary>
        /// <returns></returns>
        public bool isBST()
        {
            List<TKey> keys = new List<TKey>();
            inOrder(root, keys);
            for (int i = 1; i < keys.Count; i++)
                if (keys[i - 1].CompareTo(keys[i]) > 0)
                    return false;
            return true;
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node"></param>
        /// <param name="keys"></param>
        private void inOrder(Node node, List<TKey> keys)
        {

            if (node == null)
                return;

            inOrder(node.left, keys);
            keys.Add(node.key);
            inOrder(node.right, keys);
        }

        /// <summary>
        /// 判断该二叉树是否是一棵平衡二叉树
        /// </summary>
        /// <returns></returns>
        public bool isBalanced()
        {
            return isBalanced(root);
        }

        /// <summary>
        /// 判断以Node为根的二叉树是否是一棵平衡二叉树，递归算法
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool isBalanced(Node node)
        {

            if (node == null)
                return true;

            int balanceFactor = getBalanceFactor(node);
            if (Math.Abs(balanceFactor) > 1)
                return false;
            return isBalanced(node.left) && isBalanced(node.right);
        }
    }
}
