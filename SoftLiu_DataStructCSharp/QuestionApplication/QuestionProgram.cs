﻿using SoftLiu_DataStructCSharp.QuestionApplication.AStar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication
{
    public static class QuestionProgram
    {
        public static void Awake()
        {
            #region A Star
            //AStarPaogram aStar = new AStarPaogram();
            //aStar.Awake();
            #endregion
            // 两数和  算法
            //SumOfTwoNumbers.Awake();
            // 两数相加 算法
            //AddTwoNumbers.Awake();
            // 无重复字符的最长子串
            //LongestStringWithoutRepetition.Awake();
            // 寻找两个正序数组的中位数
            //FindTheMedian.Awake();
            // 删除链表的倒数第N个节点
            //DeleteLinkedListNth.Awake();
            // 旋转链表
            //RotatingLinkedList.Awake();
            // Z 字形变换
            //ZShapedTransformation.Awake();
            //test1();
            // 有效的括号
            //ValidParenthesis.Awake();
            // 两数相除
            //DivisionOfTwoNumbers.Awake();
            // 字符串转换整数 (atoi)
            //StringToIntegerConversion.Awake();
            // 删除排序数组中的重复项
            //RemoveDuplicates.Awake();
            // 15. 三数之和
            ThreeSum.Awake();
            // 最长公共前缀
            //LongestCommonPrefix.Awake();
            //盛最多水的容器
            //ContainerForTheMostWater.Awake();
            // 回文数
            //Palindrome.Awake();
            // 整数 和 罗马数字 转换
            //IntegerAndRomanNumeral.Awake();
            //正则表达式匹配
            //RegularExpression.Awake();
        }
        /// <summary>
        /// 整数反转
        /// </summary>
        private static void test1()
        {
            int x = 1534236469;
            StringBuilder sb = new StringBuilder();
            string str = x.ToString();

            int start = 0;
            if (x < 0)
            {
                sb.Append(str[0]);
                start++;
            }
            for (int i = str.Length -1; i >= start; i--)
            {
                sb.Append(str[i]);
            }
            try
            {
                Convert.ToInt32(sb.ToString());
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            
            //Console.WriteLine(int.Parse(sb.ToString()));
        }
    }
}
