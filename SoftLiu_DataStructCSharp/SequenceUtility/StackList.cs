using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SequenceUtility
{
    /// <summary>
    /// 栈 列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StackList<T> : IEnumerable
    {
        private Node head;
        private int N;
        private class Node
        {
            public T item;
            public Node next;
            public Node(T t, Node next)
            {
                this.item = t;
                this.next = next;
            }
        }
        public StackList()
        {
            this.head = new Node(default(T), null);
            this.N = 0;
        }
        public bool isEmpty()
        {
            return this.N <= 0;
        }
        public int length()
        {
            return this.N;
        }
        public void push(T t)
        {
            // 找到首节点指向的第一个节点
            Node oldFirst = this.head.next;
            // 创建新节点
            Node newNode = new Node(t, null);
            // 首节点指向新节点
            this.head.next = newNode;
            // 新节点指向原来的第一个节点
            newNode.next = oldFirst;
            // 个数  +1
            this.N++;
        }

        public T pop()
        {
            // 找到首节点指向的第一个节点
            Node oldFirst = this.head.next;
            if (this.head.next == null) return default(T);
            // 让首节点指向原来的第一个节点的下一个节点
            this.head.next = oldFirst.next;
            // 元素个数 -1
            this.N--;
            return oldFirst.item;
        }


        public IEnumerator GetEnumerator()
        {
            Node first = this.head.next;
            for (int i = 0; first != null; i++)
            {
                yield return first.item;
                first = first.next;
            }
        }
    }
}
