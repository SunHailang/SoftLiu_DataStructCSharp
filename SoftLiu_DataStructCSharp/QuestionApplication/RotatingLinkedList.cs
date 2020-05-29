using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 旋转链表
    /// </summary>
    public class RotatingLinkedList
    {
        /*
         给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。

            链表可以为空

        输入: 1->2->3->4->5->NULL, k = 2
        输出: 4->5->1->2->3->NULL
        解释:
        向右旋转 1 步: 5->1->2->3->4->NULL
        向右旋转 2 步: 4->5->1->2->3->NULL


        */

        public static void Awake()
        {
            ListNode head = new ListNode(1);
            ListNode head1 = new ListNode(2);
            head.next = head1;
            ListNode head2 = new ListNode(4);
            head1.next = head2;

            ListNode head3 = new ListNode(1);
            ListNode head4 = new ListNode(3);
            head3.next = head4;
            ListNode head5 = new ListNode(4);
            head4.next = head5;
            ListNode head6 = new ListNode(4);
            head5.next = head6;

            //int k = 3;
            //ListNode node = RotateRight(head, k);
            //while (node != null)
            //{
            //    Console.WriteLine(node.val);
            //    node = node.next;
            //}

            ListNode node = MergeTwoLists(head, head3);
            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// 合并两个有序列表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        private static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            if (l1 == null && l2 == null) return null;
            if (l1 == null && l2 != null) return l2;
            if (l1 != null && l2 == null) return l1;

            ListNode head = new ListNode(-1);
            ListNode first = head;

            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    first.next = l2;//new ListNode(l2.val);                    
                    l2 = l2.next;
                }
                else if (l2 == null)
                {
                    first.next = l1;//new ListNode(l1.val);
                    l1 = l1.next;
                }
                else
                {
                    if (l1.val > l2.val)
                    {
                        first.next = l2;// new ListNode(l2.val);
                        l2 = l2.next;
                    }
                    else
                    {
                        first.next = l1;// new ListNode(l1.val);
                        l1 = l1.next;
                    }
                }
                first = first.next;
            }

            return head.next;
        }

        /// <summary>
        /// 旋转列表
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static ListNode RotateRight(ListNode head, int k)
        {
            // 链表可以为空
            if (head == null) return null;
            if (head.next == null || k <= 0) return head;

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            int length = 0;
            while (first.next != null)
            {
                length++;
                first = first.next;
            }
            first.next = head;

            ListNode new_tail = head;
            //找到新的尾部，第 (n - k % n - 1) 个节点 ，新的链表头是第 (n - k % n) 个节点。
            for (int i = 0; i < length - k % length - 1; i++)
                new_tail = new_tail.next;

            ListNode node = new_tail.next;
            new_tail.next = null;

            return node;
        }

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

    }
}
