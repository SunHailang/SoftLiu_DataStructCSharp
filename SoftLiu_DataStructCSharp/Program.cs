using SoftLiu_DataStructCSharp.Data;
using SoftLiu_DataStructCSharp.SequenceUtility;
using SoftLiu_DataStructCSharp.SortUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortTest();
            //SequenceTest();
            //LinkListTest();
            LinkListHasCircleTest();
            //TwoWayLinkListTest();

            Console.Read();
        }

        private static void SortTest()
        {
            List<Student> students = new List<Student>();

            for (int i = 10000; i >= 0; i--)
            {
                students.Add(new Student() { cardID = i, name = "name" + i });
            }


            Student[] stuArray = students.ToArray();
            Console.WriteLine("Student Start Sort...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //BubbleSort.sort(stuArray);//2373
            //SelectionSort.sort(stuArray);// 1867ms
            //InsertionSort.sort(stuArray);// 2926ms
            //ShellSort.sort(stuArray);// 6ms
            //MergeSort.sort(stuArray);//
            QuickSort.sort(stuArray);
            sw.Stop();
            Console.WriteLine("Total Time: " + sw.ElapsedMilliseconds + "ms");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stuArray.Length; i++)
            {
                if (i <= stuArray.Length - 2)
                    sb.Append(stuArray[i].cardID + ", ");
                else
                    sb.Append(stuArray[i].cardID);
            }
            //Console.WriteLine(sb.ToString());
        }

        private static void SequenceTest()
        {
            List<string> s = new List<string>();

            SequenceList<Student> list = new SequenceList<Student>(10);
            list.insert(new Student() { cardID = 1, name = "sun" });
            list.insert(0, new Student() { cardID = 2, name = "hai" });
            list.insert(new Student() { cardID = 4, name = "lang" });
            Console.WriteLine((list.get(4)) == null);

            list.insert(6, new Student() { cardID = 6, name = "hello" });

            Console.WriteLine((list.get(3)) == null);

            Console.WriteLine("Length: " + list.length());
        }

        private static void LinkListTest()
        {
            LinkList<Student> list = new LinkList<Student>();
            for (int i = 0; i < 5; i++)
            {
                list.insert(new Student() { cardID = i, name = "sun" + i });
            }

            list.insert(0, new Student() { cardID = 124, name = "sun" + 124 });

            Console.WriteLine("LinkList Length: " + list.length());
            // 链表翻转
            list.reverse();

            Student s1 = list.getMid();
            Console.WriteLine(s1.cardID);

            Console.WriteLine();
            Student stu = list.get(1);
            Console.WriteLine("1 index : " + stu.cardID);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            IEnumerator tor = list.GetEnumerator();
            while (tor.MoveNext())
            {
                if (tor.Current is Student)
                {
                    Student s = tor.Current as Student;
                    Console.WriteLine("cardID: " + s.cardID);
                }
                else
                {
                    Console.WriteLine("LinkList GetEnumerator is null.");
                }
            }
            sw.Stop();
            Console.WriteLine("LinkList Total Time: " + sw.ElapsedMilliseconds + "ms");
        }
        /// <summary>
        /// 快慢指针解决 单向链表是否有环的问题
        /// </summary>
        private static void LinkListHasCircleTest()
        {
            Node<string> first = new Node<string>("11");
            Node<string> second = new Node<string>("22");
            Node<string> thred = new Node<string>("33");
            Node<string> four = new Node<string>("44");
            Node<string> five = new Node<string>("55");
            Node<string> six = new Node<string>("66");
            Node<string> seven = new Node<string>("77");
            // 创建链表
            first.next = second;
            second.next = thred;
            thred.next = four;
            four.next = five;
            five.next = six;
            six.next = seven;
            // 创建 环
            seven.next = thred;

            // 创建 快慢指针
            Node<string> fast = first;
            Node<string> slow = first;
            bool isCircle = false;

            while (fast != null && fast.next != null)
            {
                // 变化我们的快慢指针
                fast = fast.next.next; // 一次走两步
                slow = slow.next;// 一次走一步

                if (fast.Equals(slow))
                {
                    isCircle = true;
                    break;
                }
            }
            if (isCircle)
            {
                Console.WriteLine("True");
                // 定义一个中间指针 指向起始点的位置 first
                Node<string> temp = first;
                // 此时的 fast 和 slow 指向是快慢指针相遇的地方
                // 遍历链表 直到慢指针 和 临时指针相遇
                while (true)
                {
                    bool same = temp.Equals(slow);

                    if (same)
                    {
                        // 相遇了
                        Console.WriteLine("ID：" + temp.item);
                        break;
                    }
                    slow = slow.next;
                    temp = temp.next;
                }
            }
            else
                Console.WriteLine("False");
        }

        private static void TwoWayLinkListTest()
        {
            TwoWayLinkList<Student> list = new TwoWayLinkList<Student>();
            for (int i = 0; i < 1; i++)
            {
                list.insert(new Student() { cardID = i, name = "sun" + i });
            }

            list.insert(0, new Student() { cardID = 124, name = "sun" + 124 });

            Console.WriteLine("LinkList Length: " + list.length());

            Student stuFirst = list.getFirst();
            Console.WriteLine("First index : " + stuFirst.cardID);
            Student stuLast = list.getLast();
            Console.WriteLine("Last index : " + stuLast.cardID);
            Console.WriteLine();
            int index = 1;
            Student stu = list.get(index);
            Console.WriteLine(index + " index : " + stu.cardID);
            Console.WriteLine();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IEnumerator tor = list.GetEnumerator();
            while (tor.MoveNext())
            {
                if (tor.Current is Student)
                {
                    Student s = tor.Current as Student;
                    Console.WriteLine("cardID: " + s.cardID);
                }
                else
                {
                    Console.WriteLine("LinkList GetEnumerator is null.");
                }
            }
            sw.Stop();
            Console.WriteLine("LinkList Total Time: " + sw.ElapsedMilliseconds + "ms");
        }

        private static void LinkedListTest()
        {
            // LinkedList  就是一个双向链表
            LinkedList<Student> list = new LinkedList<Student>();
        }
    }

    public class Node<T>
    {
        public T item;
        public Node<T> next;
        public Node(T t)
        {
            this.item = t;
            this.next = null;
        }
    }
}
