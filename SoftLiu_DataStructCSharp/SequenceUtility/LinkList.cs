using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SequenceUtility
{
    /// <summary>
    /// 单向链表
    /// </summary>
    public class LinkList<T> : IEnumerable
    {
        //初始化头结点
        private Node head;
        // 记录链表的长度
        private int N;

        private class Node
        {
            // 存储数据
            public T item;
            // 记录下一个节点
            public Node next;

            public Node(T item, Node next)
            {
                this.item = item;
                this.next = next;
            }
        }
        public LinkList()
        {
            // 初始化头结点
            this.head = new Node(default(T), null);
            // 初始化元素个数
            this.N = 0;
        }

        public void clear()
        {
            this.head.next = null;
            this.N = 0;
        }

        public int length()
        {
            return this.N;
        }

        public bool isEmpty()
        {
            return this.N <= 0;
        }

        public T get(int i)
        {
            Node n = this.head.next;
            for (int index = 0; index < i; index++)
            {
                n = n.next;
            }
            return n.item;
        }

        public void insert(T t)
        {
            // 找到当前最后节点
            Node n = this.head;
            while (n.next != null)
            {
                n = n.next;
            }
            // 创建新节点，保存元素
            Node newN = new Node(t, null);
            // 让当前最后一个节点，指向新节点
            n.next = newN;
            this.N++;
        }

        public bool insert(int i, T t)
        {
            if (i >= this.N) return false;
            // 找到 i位置前的节点
            Node n = this.head;
            for (int index = 0; index < i - 1; index++)
            {
                n = n.next;
            }
            // 找到 i 位置的节点
            Node cur = n.next;
            // 创建新节点，并且新节点指向原来 i 位置的节点
            Node newN = new Node(t, cur);
            // 原来的 i 位置的前一个节点指向新的节点
            n.next = newN;
            // 元素个数 +1
            this.N++;
            return true;
        }

        public T remove(int i)
        {
            // 找到 i 位置的前一个节点
            Node n = this.head;
            for (int index = 0; index < i - 1; index++)
            {
                n = n.next;
            }
            // 找到 i 位置的节点
            Node cur = n.next;
            // 找到 i 位置的下一个节点
            Node nextN = cur.next;
            // 前一个节点 指向下一个节点
            n.next = nextN;
            // 元素个数 -1
            this.N--;
            return cur.item;
        }

        public int indexOf(T t)
        {
            // 从头结点开始 依次取出 item 和 t 比较
            Node n = this.head;
            for (int i = 0; n.next != null; i++)
            {
                n = n.next;
                if (n.item.Equals(t))
                    return i;
            }
            return -1;
        }

        public void reverse()
        {
            // 判断当前链表是否时空链表， 如果是 则结束运行， 否则 调用 重载的 reverse 方法翻转
            if (isEmpty()) return;

            reverse(this.head.next);
        }
        /// <summary>
        /// 单向链表的 翻转
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private Node reverse(Node n)
        {
            // 翻转指定节点 n ，并把翻转后的节点返回
            if (n.next == null)
            {
                this.head.next = n;
                return n;
            }
            // 递归的调用翻转当前节点的下一个节点， 返回值就是链表翻转后的当前节点的上一个节点
            Node preN = reverse(n.next);
            // 让返回的节点的下一个节点变为当前节点
            preN.next = n;
            // 把当前节点的下一个节点变为 null
            n.next = null;
            return n;
        }

        /// <summary>
        /// 快慢指针
        /// </summary>
        /// <returns></returns>
        public T getMid()
        {
            // 定义两个指针
            Node fast = this.head;
            Node slow = this.head;
            // 使用两个指针遍历链表 
            while (fast != null && fast.next != null)
            {
                // 变化 fast 和 slow 的值 
                fast = fast.next.next;
                slow = slow.next;
            }

            return slow.item;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.N; i++)
            {
                yield return get(i);
            }
        }

    }
}
