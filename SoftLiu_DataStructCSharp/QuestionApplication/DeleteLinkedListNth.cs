using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 删除链表的倒数第N个节点
    /// </summary>
    public class DeleteLinkedListNth
    {
        /*
         给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。

         给定一个链表: 1->2->3->4->5, 和 n = 2.
         当删除了倒数第二个节点后，链表变为 1->2->3->5.

            给定的 n 保证是有效的。
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
            int n = 2;
            ListNode node = RemoveNthFromEnd(head, n);
            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }
        }

        private static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            int length = 0;
            ListNode firstNode = head;
            while (firstNode != null)
            {
                length++;
                firstNode = firstNode.next;
            }
            length -= n;
            firstNode = dummy;
            while (length > 0)
            {
                length--;
                firstNode = firstNode.next;
            }
            firstNode.next = firstNode.next.next;

            return dummy.next;
        }

        #region Other 
        private static ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            int i = 0;
            ListNode p1 = new ListNode(0);
            p1.next = head;
            abc(ref p1, ref n, ref i);
            return p1.next;
        }
        private static void abc(ref ListNode head, ref int n, ref int i)
        {
            if (head.next != null)
            {
                abc(ref head.next, ref n, ref i);
            }
            ++i;
            if (i == n + 1)
            {
                head.next = head.next.next;
            }

        }
        #endregion

        private class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
