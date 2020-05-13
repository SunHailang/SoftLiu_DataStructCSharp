using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SequenceUtility
{
    public class QueueList<T> : IEnumerable
    {
        private Node head;
        private int N;
        private Node last;

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
        public QueueList()
        {
            this.head = new Node(default(T), null);
            this.last = null;
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

        public void enqueue(T t)
        {
            // 当前last==null
            if (this.last == null)
            {
                this.last = new Node(t, null);
                this.head.next = this.last;
            }
            else
            {
                Node oldLast = this.last;
                this.last = new Node(t, null);
                oldLast.next = this.last;
            }
            this.N++;
        }

        public T dequeue()
        {
            if (isEmpty()) return default(T);
            Node oldFirst = this.head.next;
            this.head.next = oldFirst.next;
            this.N--;
            // 因为 出队列是在删除元素， 如果队列中的元素被删除完了，需要重置 last=null
            if (isEmpty())
            {
                this.last = null;
            }
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
