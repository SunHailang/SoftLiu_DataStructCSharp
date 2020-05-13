using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SequenceUtility
{
    /// <summary>
    /// 符号表
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SymbolTable<TKey, TValue> : IEnumerable
    {
        private Node head;
        private int N;

        private class Node
        {
            public TKey key;
            public TValue value;

            public Node next;

            public Node(TKey key, TValue value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        public SymbolTable()
        {
            this.head = new Node(default(TKey), default(TValue), null);
            this.N = 0;
        }

        public int length()
        {
            return this.N;
        }

        public void put(TKey key, TValue value)
        {
            // 判断符号表中 key 是否已经存在， 那么就直接 修改 value
            Node n = this.head;
            while (n.next != null)
            {
                // 变换 n 
                n = n.next;
                // 判断 n 节点 存储的键是否为key，
                if (n.key.Equals(key))
                {
                    n.value = value;
                    return;
                }
            }
            // 如果符号表中 没有 key， 那么创建新节点 并插入到链表的头部， this.head.next = 新节点
            Node newNode = new Node(key, value, null);
            Node oldFirst = this.head.next;
            newNode.next = oldFirst;
            this.head.next = newNode;

            // 元素个数 +1
            this.N++;
        }

        public void delete(TKey key)
        {
            // 找到 键为key的节点，把该节点删除
            Node n = this.head;
            while (n.next != null)
            {
                // 判断 n 节点的下一个节点的键是否为key 是：删除该节点
                if (n.next.key.Equals(key))
                {
                    n.next = n.next.next;
                    this.N--;
                    return;
                }
                // 变换 n
                n = n.next;
            }
        }

        public TValue get(TKey key)
        {
            // 找到 key 所在的节点
            Node n = this.head;
            while (n.next != null)
            {
                // 变换n
                n = n.next;
                if (n.key.Equals(key))
                {
                    return n.value;
                }
            }
            return default(TValue);
        }

        public IEnumerator GetEnumerator()
        {
            Node first = this.head.next;
            for (int i = 0; first != null; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(first.key, first.value);
                first = first.next;
            }
        }
    }
}
