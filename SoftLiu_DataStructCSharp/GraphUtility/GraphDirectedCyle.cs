using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 有向图中的环 检测
    /// </summary>
    public class GraphDirectedCyle
    {
        private bool[] markeds;

        private bool hasCycleBool;

        /// <summary>
        /// 索引代表顶点，使用栈的思想，记录当前顶点有没有已经处于正在搜索的有向路径
        /// </summary>
        private bool[] onStack;

        public GraphDirectedCyle(GraphDigraph g)
        {
            // 初始化 markeds 数组
            this.markeds = new bool[g.countV()];
            // 初始化 hasCycleBool
            this.hasCycleBool = false;
            //初始化onStack
            this.onStack = new bool[g.countV()];

            // 找到图中每一个顶点 让每一个顶点作为入口调用一次 dfs 函数
            for (int v = 0; v < g.countV(); v++)
            {
                // 如果当前顶点 还没有搜索过 则调用dfs搜索
                if (!this.markeds[v])
                {
                    dfs(g, v);
                }
            }
        }

        private void dfs(GraphDigraph g, int v)
        {
            // 将顶点v设置成已搜索
            this.markeds[v] = true;
            // 把当前顶点进栈
            this.onStack[v] = true;
            // 进行深度搜索
            IEnumerator ie = g.adjGet(v).GetEnumerator();
            while (ie.MoveNext())
            {
                int w = (int)ie.Current;
                if (!this.markeds[w])
                {
                    dfs(g, w);
                }
                else
                {
                    // 判断当前顶点是否已经在栈中， true表示是环，
                    if (this.onStack[w])
                    {
                        this.hasCycleBool = true;
                        return;
                    }
                }
            }
            // 把当前顶点出栈
            this.onStack[v] = false;
        }
        /// <summary>
        /// 判断 有向图是否有环
        /// </summary>
        /// <returns></returns>
        public bool hasCycle()
        {
            return this.hasCycleBool;
        }
    }
}
