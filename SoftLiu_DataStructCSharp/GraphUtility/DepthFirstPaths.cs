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
    /// 基于深度优先 查询路径
    /// </summary>
    public class DepthFirstPaths
    {

        private bool[] markeds;
        /// <summary>
        /// 记录路径的起点
        /// </summary>
        private int s;
        /// <summary>
        /// 索引代表顶点 值代表起点s到当前顶点路径上的最后一个顶点
        /// </summary>
        private int[] edgeTo;

        public DepthFirstPaths(GraphUndirected g, int s)
        {
            // 初始化 markeds数组
            this.markeds = new bool[g.countV()];
            // 初始化起点
            this.s = s;

            this.edgeTo = new int[g.countV()];

            dfs(g, s);
        }

        private void dfs(GraphUndirected g, int v)
        {
            this.markeds[v] = true;
            // 遍历顶点v的邻接表，拿到每一个相邻的顶点继续递归
            IEnumerator ie = g.adjGet(v).GetEnumerator();
            while (ie.MoveNext())
            {
                int w = (int)ie.Current;
                // 如果顶点我没有被搜索，递归搜索
                if (!this.markeds[w])
                {
                    // 到达顶点w的路径上的最后一个顶点是v
                    edgeTo[w] = v;
                    dfs(g, w);
                }
            }
        }
        /// <summary>
        /// 判断v顶点与s顶点是否存在路径
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool hasPathTo(int v)
        {
            return this.markeds[v];
        }

        public StackList<int> pathTo(int v)
        {
            if (!hasPathTo(v)) return null;

            // 创建栈对象 保存路径中的所有顶点
            StackList<int> path = new StackList<int>();
            // 通过循环从顶点v开始一直往前找，知道找到起点
            for (int x = v; x != this.s; x = edgeTo[x])
            {
                path.push(x);
            }
            // 把起点s放进去
            path.push(this.s);
            return path;
        }

    }
}
