using SoftLiu_DataStructCSharp.Data;
using SoftLiu_DataStructCSharp.GraphUtility;
using SoftLiu_DataStructCSharp.QuestionApplication;
using SoftLiu_DataStructCSharp.QuestionApplication.AStar;
using SoftLiu_DataStructCSharp.SequenceUtility;
using SoftLiu_DataStructCSharp.SortUtility;
using SoftLiu_DataStructCSharp.TreeUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            //LinkListHasCircleTest();
            //JosephTest();
            //TwoWayLinkListTest();
            //StackListTest();
            //BracketsMatchTest();
            //ReversePolishNotationTest();
            //QueueListTest();
            //SymbolTableTest();
            //SymbolOrderTableTest();
            //TreeUtilityTest.Test();
            //GraphUtilityTest.Test();

            //QuestionProgram.Awake();

            // PathFinding.PathFindingTest.Testing();

            IntToRom();
            Console.Write("\nAny Key Continue...");
            Console.Read();
        }


        private static void IntToRom()
        {
            int[] nums = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            string[] strs = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            StringBuilder sb = new StringBuilder();
            int index = 1;
            while (index < 1000)
            {
                int num = index;
                sb.Clear();
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    int value = num / nums[i];

                    for (int j = 0; j < value; j++)
                    {
                        sb.Append(strs[i]);
                    }
                    num -= nums[i] * value;
                }
                Console.WriteLine(sb.ToString());
                index++;
            }

        }


        /// <summary>
        /// 排序测试
        /// </summary>
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
        /// <summary>
        /// 顺序表 测试
        /// </summary>
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
        /// <summary>
        /// 单向链表测试
        /// </summary>
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
            Node<string> first = new Node<string>("11", null);
            Node<string> second = new Node<string>("22", null);
            Node<string> thred = new Node<string>("33", null);
            Node<string> four = new Node<string>("44", null);
            Node<string> five = new Node<string>("55", null);
            Node<string> six = new Node<string>("66", null);
            Node<string> seven = new Node<string>("77", null);
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
        /// <summary>
        /// 约瑟夫问题   循环链表
        /// </summary>
        private static void JosephTest()
        {
            // 解决我们的 约瑟夫问题
            // 1. 构建循环链表， 包含41个节点，分别存储 1~41 
            //用来记录首节点
            Node<int> first = null;
            //用来记录前一个节点
            Node<int> pre = null;
            for (int i = 1; i <= 41; i++)
            {
                //  如果是第一个节点
                if (i == 1)
                {
                    first = new Node<int>(i, null);
                    pre = first;
                    continue;
                }
                // 如果不是第一个节点
                Node<int> newN = new Node<int>(i, null);
                pre.next = newN;
                pre = newN;
                // 如果是最有一个节点
                if (i == 41)
                {
                    pre.next = first;
                }
            }
            // 2. 需要count计数器， 模拟报数
            int count = 0;
            // 3. 遍历循环链表
            //记录每次遍历拿到的节点，默认从首节点开始
            Node<int> cur = first;
            //记录当前节点的上一个节点
            Node<int> befor = null;

            while (cur != cur.next)
            {
                // 模拟报数
                count++;
                // 判断当前报数是否是3 true：删除当前节点， 打印当前节点， 重置count 让当前后移
                if (count == 3)
                {
                    befor.next = cur.next;
                    Console.Write(cur.item + ",");
                    count = 0;
                    cur = cur.next;
                }
                else
                {
                    //不是3 让befor变为当前节点，让当前节点后移
                    befor = cur;
                    cur = cur.next;
                }
            }
            // 打印最后一个元素
            //befor = cur;
            Console.Write(cur.item + ",");
        }
        /// <summary>
        /// 双向链表 测试
        /// </summary>
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
        /// <summary>
        /// C# 自带的 双向链表 测试
        /// </summary>
        private static void LinkedListTest()
        {
            // LinkedList  就是一个双向链表
            LinkedList<Student> list = new LinkedList<Student>();
        }
        /// <summary>
        /// 栈 测试
        /// </summary>
        private static void StackListTest()
        {
            StackList<Student> list = new StackList<Student>();
            for (int i = 0; i < 5; i++)
            {
                list.push(new Student() { cardID = i, name = "sun" + i });
            }
            Console.WriteLine("StackList Length: " + list.length());
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
            Student popStu = list.pop();
            Console.WriteLine("StackList pop Stu: " + popStu.cardID);
            Console.WriteLine("StackList Length: " + list.length());
            IEnumerator tor1 = list.GetEnumerator();
            while (tor1.MoveNext())
            {
                if (tor1.Current is Student)
                {
                    Student s = tor1.Current as Student;
                    Console.WriteLine("cardID: " + s.cardID);
                }
                else
                {
                    Console.WriteLine("LinkList GetEnumerator is null.");
                }
            }
        }
        /// <summary>
        /// 小括号 匹配问题  用栈的思想解决
        /// </summary>
        private static void BracketsMatchTest()
        {
            string str = "(Hello)(Hi(Sun)))";
            bool isMatch = true;
            // 创建一个栈对象，用来存储左括号
            StackList<string> stack = new StackList<string>();
            // 从左往右遍历字符串
            for (int i = 0; i < str.Length; i++)
            {
                string s = str[i].ToString();
                if (s.Equals("("))
                {
                    // 判断当前是否是左括号，是：把字符放到栈中
                    stack.push(s);
                }
                else if (s.Equals(")"))
                {
                    // 继续判断是否是右括号，是：从栈中弹出左括号， 判断弹出的元素是否为null，是：退出， 否继续
                    string p = stack.pop();
                    if (p == null)
                    {
                        isMatch = false;
                        break;
                    }
                }
            }
            if (isMatch)
            {
                // 遍历结束,判断栈中是否有剩余的左括号，有：不匹配 否则匹配
                if (stack.length() > 0)
                {
                    isMatch = false;
                }
            }
            Console.WriteLine("Brackets Match Result: " + isMatch);
        }
        /// <summary>
        /// 中缀表达式 转 逆波兰表达式 -> 逆波兰表达式解决问题
        /// 逆波兰表达式 问题解决  用栈的思想
        /// 仅仅支持 + - * / 四则运算
        /// </summary>
        private static void ReversePolishNotationTest()
        {
            //string[] str = new string[] { "1", "*", "(", "2", "+", "6", ")" };
            string[] str = new string[] { "5", "*", "2", "+", "2", "*", "(", "3", "+", "4", ")", "-", "58", "/", "2" };
            Stack<string> stack = new Stack<string>();
            List<string> list = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                string data = str[i];
                switch (data)
                {
                    case "(":
                        stack.Push("(");
                        break;
                    case ")":
                        while (stack.Count > 0)
                        {
                            string data1 = stack.Pop();
                            if (data1 == "(")
                                break;
                            list.Add(data1);
                        }
                        break;
                    case "+":
                        if (stack.Count > 0 && stack.Peek() != "(")
                        {
                            list.Add(stack.Pop());
                        }
                        stack.Push("+");
                        break;
                    case "-":
                        if (stack.Count > 0 && stack.Peek() != "(")
                        {
                            list.Add(stack.Pop());
                        }
                        stack.Push("-");
                        break;
                    case "*":
                        stack.Push("*");
                        break;
                    case "/":
                        stack.Push("/");
                        break;
                    default:
                        list.Add(data);
                        break;
                }
            }
            while (stack.Count > 0)
            {
                list.Add(stack.Pop());
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
            }
            Console.WriteLine();

            // 中缀表达式  (3*(17-5)+18/6) = 9 转换成逆波兰表达式字符串数组
            string[] notation = list.ToArray();//new string[] { "3", "17", "15", "-", "*", "18", "6", "/", "+" };

            // 定义一个栈存储操作数
            StackList<int> oprands = new StackList<int>();
            int result = 0;
            int o1;
            int o2;
            // 从左往右遍历 逆波兰表达式， 得到每一个元素
            for (int i = 0; i < notation.Length; i++)
            {
                string curr = notation[i].ToString();
                // 判断当前元素是运算符还是操作数
                switch (curr)
                {
                    // 运算符，从栈中弹出两个操作数，完成运算再压入栈中
                    case "+":
                        o1 = oprands.pop();
                        o2 = oprands.pop();
                        result = o2 + o1;
                        oprands.push(result);
                        break;
                    case "-":
                        o1 = oprands.pop();
                        o2 = oprands.pop();
                        result = o2 - o1;
                        oprands.push(result);
                        break;
                    case "*":
                        o1 = oprands.pop();
                        o2 = oprands.pop();
                        result = o2 * o1;
                        oprands.push(result);
                        break;
                    case "/":
                        o1 = oprands.pop();
                        o2 = oprands.pop();
                        result = o2 / o1;
                        oprands.push(result);
                        break;
                    default:
                        // 操作数，直接把该操作数压到栈中
                        oprands.push(int.Parse(curr));
                        break;
                }
            }
            // 得到栈中最后一个元素就是 逆波兰表达式的结果
            result = oprands.pop();
            Console.WriteLine("Reverse Polish Notation Result: " + result);
        }
        /// <summary>
        /// 队列 测试
        /// </summary>
        private static void QueueListTest()
        {
            // 创建队列对象
            QueueList<Student> list = new QueueList<Student>();

            // 测试队列的enqueue方法
            for (int i = 0; i < 5; i++)
            {
                list.enqueue(new Student() { cardID = i, name = "sun" + i });
            }
            Student stu = list.dequeue();
            Console.WriteLine("Result: " + stu.cardID);
            Console.WriteLine();
            IEnumerator ie = list.GetEnumerator();
            while (ie.MoveNext())
            {
                if (ie.Current is Student)
                {
                    Student s = ie.Current as Student;
                    Console.WriteLine("cardID: " + s.cardID);
                }
                else
                {
                    Console.WriteLine("QueueList GetEnumerator is null.");
                }
            }
        }
        /// <summary>
        /// 符号表 测试
        /// </summary>
        private static void SymbolTableTest()
        {
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            // 创建 符号表
            SymbolTable<string, Student> table = new SymbolTable<string, Student>();
            // 测试插入 put方法
            for (int i = 0; i < 5; i++)
            {
                table.put(i.ToString(), new Student() { cardID = i, name = "sun" + i });
            }
            Console.WriteLine("Symbol Table Length: " + table.length());

            table.put("2", new Student() { cardID = 22, name = "sun" + 22 });
            Student stu = table.get("2");
            Console.WriteLine("new put: " + stu.cardID);
            table.delete("0");

            IEnumerator ie = table.GetEnumerator();

            while (ie.MoveNext())
            {
                if (ie.Current is KeyValuePair<string, Student>)
                {
                    KeyValuePair<string, Student> s = (KeyValuePair<string, Student>)ie.Current;
                    Console.WriteLine(string.Format("key: {0}, value cardID: {1}", s.Key, s.Value.cardID));
                }
                else
                {
                    Console.WriteLine("SymbolTable GetEnumerator is null.");
                }
            }
        }
        /// <summary>
        /// 有序符号表 测试
        /// </summary>
        private static void SymbolOrderTableTest()
        {
            // 创建 符号表
            SymbolOrderTable<string, Student> table = new SymbolOrderTable<string, Student>();
            // 测试插入 put方法
            for (int i = 0; i < 8; i += 2)
            {
                table.put(i.ToString(), new Student() { cardID = i, name = "sun" + i });
            }
            Console.WriteLine("Symbol Table Length: " + table.length());

            table.put("2", new Student() { cardID = 22, name = "sun" + 22 });
            Student stu = table.get("2");
            Console.WriteLine("new put: " + stu.cardID);
            table.delete("0");

            table.put("05", new Student() { cardID = 50, name = "sun05" });
            table.put("7", new Student() { cardID = 7, name = "sun7" });
            table.put("87", new Student() { cardID = 87, name = "sun87" });
            table.put("18", new Student() { cardID = 18, name = "sun18" });

            IEnumerator ie = table.GetEnumerator();

            while (ie.MoveNext())
            {
                if (ie.Current is KeyValuePair<string, Student>)
                {
                    KeyValuePair<string, Student> s = (KeyValuePair<string, Student>)ie.Current;
                    Console.WriteLine(string.Format("key: {0}, value cardID: {1}", s.Key, s.Value.cardID));
                }
                else
                {
                    Console.WriteLine("SymbolTable GetEnumerator is null.");
                }
            }
        }


    }

    public class Node<T>
    {
        public T item;
        public Node<T> next;
        public Node(T t, Node<T> next)
        {
            this.item = t;
            this.next = next;
        }
    }
}
