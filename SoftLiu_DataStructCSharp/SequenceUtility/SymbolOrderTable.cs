using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SequenceUtility
{
    /// <summary>
    /// 有序符号表
    /// </summary>
    /// <typeparam name="TKey"> 是支持 IComparable 比较</typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SymbolOrderTable<TKey, TValue> : IEnumerable 
        where TKey : IComparable<TKey>
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

        public SymbolOrderTable()
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
            // 定义两个变量， 记录当前节点 和当前节点的上一个节点
            Node curr = this.head.next;
            Node pre = this.head;
            while (curr != null && key.CompareTo(curr.key) > 0)
            {
                // 变换当前 节点和前一个节点
                pre = curr;
                curr = curr.next;
            }
            // 如果当前节点的键和要插入的key一样则替换value， 否则把新插入的节点插入到当前节点之前
            if (curr != null && key.CompareTo(curr.key) == 0)
            {
                curr.value = value;
                return;
            }
            Node newNode = new Node(key, value, curr);
            pre.next = newNode;
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
