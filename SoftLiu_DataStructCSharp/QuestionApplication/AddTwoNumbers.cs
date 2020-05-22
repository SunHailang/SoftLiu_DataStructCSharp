using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    /// <summary>
    /// 两数相加
    /// </summary>
    public class AddTwoNumbers
    {
        /*
        给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。
        如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。
        假设除了数字 0 之外，这两个数都不会以 0 开头。
        */


        public static void Awake()
        {
            LinkList<int> listA = new LinkList<int>();
            listA.insert(3);
            listA.insert(5);
            listA.insert(8);
            LinkList<int> listB = new LinkList<int>();
            listB.insert(4);
            listB.insert(0);
            listB.insert(2);


            LinkList<int> queue = Add(listA, listB);


            Console.WriteLine(queue.length());
            IEnumerator ie = queue.GetEnumerator();
            while (ie.MoveNext())
            {
                int q = (int)ie.Current;
                Console.Write(q + ",");
            }
        }

        private static LinkList<int> Add(LinkList<int> listA, LinkList<int> listB)
        {
            int lengthA = listA.length();
            int lengthB = listB.length();
            LinkList<int> queue = new LinkList<int>();
            int length = Math.Max(lengthA, lengthB);
            int common = 0;
            for (int i = length - 1; i >= 0; i--)
            {
                int a = 0;
                int b = 0;
                if (i < lengthA)
                {
                    a = listA.get(i);
                }
                if (i < lengthB)
                {
                    b = listB.get(i);
                }
                int sum = a + b + common;
                common = 0;
                int x = sum / 10;
                int y = sum % 10;
                
                queue.insert(y);
                if (x > 0)
                {
                    if (i > 0)
                    {
                        common = x;
                    }
                    else
                    {
                        queue.insert(x);
                    }
                }
            }

            return queue;
        }
    }
}
