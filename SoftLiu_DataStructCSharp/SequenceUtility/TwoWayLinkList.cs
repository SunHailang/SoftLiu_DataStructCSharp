using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SequenceUtility
{
    /// <summary>
    /// 双向链表
    /// </summary>
    public class TwoWayLinkList<T> : IEnumerable
    {
        private Node head;
        private Node last;
        private int N;

        private class Node
        {
            /// <summary>
            /// 存储数据
            /// </summary>
            public T item;
            /// <summary>
            /// 指向前一个节点
            /// </summary>
            public Node pre;
            /// <summary>
            /// 指向后一个节点
            /// </summary>
            public Node next;
            public Node(T item, Node pre, Node next)
            {
                this.item = item;
                this.pre = pre;
                this.next = next;
            }
        }

        public TwoWayLinkList()
        {
            // 初始化头结点， 尾节点
            this.head = new Node(default(T), null, null);
            // 初始化元素个数
            this.N = 0;
        }

        public void clear()
        {
            this.head.pre = null;
            this.head.next = null;
            this.head.item = default(T);
            this.last = null;
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

        public T getFirst()
        {
            if (isEmpty())
                return default(T);
            return this.head.next.item;
        }

        public T getLast()
        {
            if (isEmpty()) return default(T);
            return last.item;
        }

        public void insert(T t)
        {
            if (isEmpty())
            {
                // 如果链表为空
                // 创建新节点
                Node newN = new Node(t, this.head, null);
                // 让新节点成为尾节点
                this.last = newN;
                // 让头结点指向尾节点
                this.head.next = this.last;

            }
            else
            {
                // 如果链表不为空 
                Node oldLast = this.last;
                // 创建新节点
                Node newN = new Node(t, oldLast, null);
                // 当前的尾节点指向新节点
                oldLast.next = newN;
                // 让新节点成为尾节点
                this.last = newN;
            }
            this.N++;
        }

        public void insert(int i, T t)
        {
            // 找到 i 位置的前一个节点
            Node pre = this.head;
            for (int index = 0; index < i; index++)
            {
                pre = pre.next;
            }
            // 找到 i 位置的当前节点
            Node cur = pre.next;
            // 创建新节点
            Node newN = new Node(t, pre, cur);
            // 让 i 位置的前一个节点的下一个节点变成新节点
            pre.next = newN;
            // 让 i 位置的前一个节点变成新节点
            cur.pre = newN;
            // 元素个数 +1
            this.N++;
        }

        public T get(int i)
        {
            if (i >= this.N) return default(T);
            Node n = head.next;
            for (int index = 0; index < i; index++)
            {
                n = n.next;
            }
            return n.item;
        }

        public int indexOf(T t)
        {
            Node n = this.head;
            for (int index = 0; n.next != null; index++)
            {
                n = n.next;
                if (n.next.Equals(t))
                {
                    return index;
                }
            }
            return -1;
        }

        public T remove(int i)
        {
            if (i >= this.N) return default(T);
            // 找到 i 位置的前一个节点
            Node preN = this.head;
            for (int index = 0; index < i; index++)
            {
                preN = preN.next;
            }
            // 找到 i 位置的节点
            Node curN = preN.next;
            // 找到 i 位置的后一个节点
            Node nextN = curN.next;
            // 让 i 位置的前一个节点的下一个节点变为 i 位置的下一个节点
            preN.next = nextN.next;
            // 让 i 位置的下一个节点的前一个节点变为 i 位置的前一个节点
            nextN.pre = preN;
            // 元素个数 -1
            this.N--;
            return curN.item;
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
