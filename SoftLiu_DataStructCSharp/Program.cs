using SoftLiu_DataStructCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = new string[]
            {
                "2",
                "11",
                "21",
                "13",
                "14",
                "153",
                "16",
            };


            //Bubble.sort(str);
            Selection.sort(str);
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine(str[i]);
            }

            Console.Read();
        }
    }
}
