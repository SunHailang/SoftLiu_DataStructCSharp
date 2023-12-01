using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.LeetCode
{
    /// <summary>
    /// 2661. 找出叠涂元素
    /// </summary>
    public static class Time20231201
    {
        public static void Run()
        {

        }
        /// <summary>
        /// 给你一个下标从 0 开始的整数数组 arr 和一个 m x n 的整数 矩阵 mat 。arr 和 mat 都包含范围 [1，m * n] 内的 所有 整数。
        /// 从下标 0 开始遍历 arr 中的每个下标 i ，并将包含整数 arr[i] 的 mat 单元格涂色。
        /// 请你找出 arr 中在 mat 的某一行或某一列上都被涂色且下标最小的元素，并返回其下标 i 。
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="mat"></param>
        /// <returns></returns>
        private static int FirstCompleteIndex(int[] arr, int[][] mat)
        {
            if (arr == null || mat == null) return -1;

            var m = mat.Length;
            var n = mat[0].Length;

            //var dict = new Dictionary<int, HashSet<int>>();

            //for (int i = 0; i < m; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        var val = mat[i][j];
            //        // 添加行
            //        if (dict.TryGetValue(i, out var setRow))
            //        {
            //            setRow.Add(val);
            //        }
            //        else
            //        {
            //            setRow = new HashSet<int> { val };
            //            dict[i] = setRow;
            //        }
            //        // 添加列
            //        if (dict.TryGetValue(m + j, out var setColumn))
            //        {
            //            setColumn.Add(val);
            //        }
            //        else
            //        {
            //            setColumn = new HashSet<int> { val };
            //            dict[m + j] = setColumn;
            //        }
            //    }
            //}


            //for (int i = 0; i < arr.Length; i++)
            //{
            //    foreach (var item in dict)
            //    {
            //        if(item.Value.Remove(arr[i]))
            //        {
            //            if(item.Value.Count <= 0)
            //            {
            //                return i;
            //            }
            //        }
            //    }
            //}
            var dict = new Dictionary<int, Tuple<int, int>>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dict[mat[i][j]] = new Tuple<int, int>(i, j);
                }
            }
            var rowArr = new int[n];
            var columnArr = new int[m];
            for (int i = 0; i < arr.Length; i++)
            {
                var data = dict[arr[i]];
                ++rowArr[data.Item1];
                if (rowArr[data.Item2] == m)
                    return i;
                ++columnArr[data.Item2];
                if (columnArr[data.Item2] == n)
                    return i;
            }


            return -1;
        }
    }
}
