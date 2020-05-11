using SoftLiu_DataStructCSharp.Data;
using SoftLiu_DataStructCSharp.SequenceUtility;
using SoftLiu_DataStructCSharp.SortUtility;
using System;
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
            SequenceTest();
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
    }
}
