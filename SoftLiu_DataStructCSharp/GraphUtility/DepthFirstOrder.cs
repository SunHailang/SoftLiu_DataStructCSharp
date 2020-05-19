using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 基于深度优先的顶点排序
    /// </summary>
    public class DepthFirstOrder
    {

        /// <summary>
        /// 索引代表顶点，值表示当前顶点是否已经被搜索
        /// </summary>
        private bool[] markeds;

        /// <summary>
        /// 使用栈，存储顶点序列
        /// </summary>
        private StackList<int> reversePostStack;
        /// <summary>
        /// 创建一个顶点排序对象 生成顶点线性队列
        /// </summary>
        /// <param name="g"></param>
        public DepthFirstOrder(GraphDigraph g)
        {
            // 初始markeds 数组
            this.markeds = new bool[g.countV()];
            // 初始化 reversePost stack 栈
            this.reversePostStack = new StackList<int>();
            // 遍历图中的每一个顶点，让每一个定点做作为入口，完成一次深度优先搜索
            for (int v = 0; v < g.countV(); v++)
            {
                if (!this.markeds[v])
                {
                    dfs(g, v);
                }
            }
        }

        /// <summary>
        /// 基于深度优先搜索，生成顶点线性排序
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void dfs(GraphDigraph g, int v)
        {
            // 标记当前v已经被搜索
            this.markeds[v] = true;
            // 通过循环深度搜索v
            IEnumerator ie = g.adjGet(v).GetEnumerator();
            while (ie.MoveNext())
            {
                int w = (int)ie.Current;
                if (!this.markeds[w])
                {
                    dfs(g, w);
                }
            }
            // 让当前这个顶点进栈
            this.reversePostStack.push(v);
        }

        /// <summary>
        /// 获取顶点线性队列
        /// </summary>
        /// <returns></returns>
        public StackList<int> reversePost()
        {
            return this.reversePostStack;
        }
    }
}
