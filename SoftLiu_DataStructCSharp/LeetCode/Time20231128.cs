using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 请你设计一个队列，支持在前，中，后三个位置的 push 和 pop 操作。
    /// 思路： 使用单向链表
    /// </summary>
    public static class Time20231128
    {
        public static void Run()
        {
            var val = -1;
            FrontMiddleBackQueue q = new FrontMiddleBackQueue();
            q.PushMiddle(3);
            LogQueue(q, val);
            q.PushFront(6);
            LogQueue(q, val);
            q.PushMiddle(6);
            LogQueue(q, val);
            q.PushMiddle(3);
            LogQueue(q, val);
            val = q.PopMiddle();
            LogQueue(q, val);
            //val = q.PopMiddle(); 
            //LogQueue(q, val);
            //val = q.PopMiddle(); 
            //LogQueue(q, val);

            //q.PushFront(1);   // [1]
            //LogQueue(q, val);
            //q.PushBack(2);    // [1, 2]
            //LogQueue(q, val);
            //q.PushMiddle(3);  // [1, 3, 2]
            //LogQueue(q, val);
            //q.PushMiddle(4);  // [1, 4, 3, 2]
            //LogQueue(q, val);
            //val = q.PopFront();     // 返回 1 -> [4, 3, 2]
            //LogQueue(q, val);
            //val = q.PopMiddle();    // 返回 3 -> [4, 2]
            //LogQueue(q, val);
            //val = q.PopMiddle();    // 返回 4 -> [2]
            //LogQueue(q, val);
            //val = q.PopBack();      // 返回 2 -> []
            //LogQueue(q, val);
            //val = q.PopFront();     // 返回 -1 -> []
            //LogQueue(q, val);


        }

        private static void LogQueue(FrontMiddleBackQueue q, int value)
        {
            var head = q.Head;
            while (head != null)
            {
                Console.Write($"{head.val},");
                head = head.next;
            }
            Console.Write($"val = {value}");
            Console.WriteLine(Environment.NewLine);
        }
    }

    public class FrontMiddleBackQueue
    {

        public class Node
        {
            public int val = 0;
            public Node next = null;
        }

        private Node m_head;
        private int m_count = 0;

        public Node Head => m_head;

        public FrontMiddleBackQueue()
        {

            m_head = null;
            m_count = 0;

        }

        public void PushFront(int val)
        {

            m_count++;
            var node = new Node();
            node.val = val;
            if (m_head != null)
            {
                node.next = m_head;
                m_head = node;
            }
            else
            {
                m_head = node;
            }
        }

        public void PushMiddle(int val)
        {
            var node = new Node();
            node.val = val;
            if (m_head == null)
            {
                m_head = node;
            }
            else if (m_head.next == null)
            {
                node.next = m_head;
                m_head = node;
            }
            else
            {
                // 1,3,2 -> 4 -> 1,4,3,2
                var mind = m_count / 2;
                var index = 0;
                var head = m_head;
                while (index < mind - 1)
                {
                    index++;
                    head = head.next;
                }
                // 插在head后面

                var next = head.next;
                head.next = node;
                node.next = next;
            }
            m_count++;
        }

        public void PushBack(int val)
        {
            m_count++;
            var node = new Node();
            node.val = val;
            var head = m_head;
            if (m_head == null)
            {
                m_head = node;
            }
            else
            {
                while (head.next != null)
                {
                    head = head.next;
                }
                head.next = node;
            }
        }

        public int PopFront()
        {
            if (m_count <= 0) return -1;
            var val = m_head.val;
            m_head = m_head.next;
            m_count--;
            return val;
        }

        public int PopMiddle()
        {
            var val = -1;
            if (m_count <= 0) return val;

            if (m_head.next == null)
            {
                val = m_head.val;
                m_head = null;
                m_count--;
                return val;
            }
            if (m_head.next.next == null)
            {
                val = m_head.val;
                m_head = m_head.next;
                m_count--;
                return val;
            }
            // 3,6,3,6
            var mind = m_count / 2;
            var index = 0;
            var head = m_head;
            var data = m_count % 2;
            while (index < (data == 0 ? mind - 2 : mind - 1))
            {
                index++;
                head = head.next;
            }
            // 移除 head.next
            val = head.next.val;
            head.next = head.next.next;
            m_count--;
            return val;
        }

        public int PopBack()
        {
            var val = -1;
            if (m_count <= 0) return val;
            if (m_head.next == null)
            {
                val = m_head.val;
                m_head = null;
            }
            else
            {
                var head = m_head;
                while (head.next.next != null)
                {
                    head = head.next;
                }
                val = head.next.val;
                head.next = null;
            }
            m_count--;
            return val;
        }
    }


}
