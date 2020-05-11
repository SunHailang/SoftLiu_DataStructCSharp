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
    public class LinkList<T>
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

        public bool isEnpty()
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

        public Enumerator GetEnumerator()
        {
            return default(Enumerator);
        }

        public struct Enumerator : IEnumerator<T>, IDisposable
        {
            public T Current { get; }


            //
            // Summary:
            //     Releases all resources used by the System.Collections.Generic.List`1.Enumerator.
            public void Dispose()
            {

            }
            public bool MoveNext()
            {
                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
