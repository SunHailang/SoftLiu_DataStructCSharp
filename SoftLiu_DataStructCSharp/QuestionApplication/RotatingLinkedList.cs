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
            ListNode head2 = new ListNode(3);
            head1.next = head2;
            ListNode head3 = new ListNode(4);
            head2.next = head3;
            ListNode head4 = new ListNode(5);
            head3.next = head4;
            int k = 3;
            ListNode node = RotateRight(head, k);
            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }
        }


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
