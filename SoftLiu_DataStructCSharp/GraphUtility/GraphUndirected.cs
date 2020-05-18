using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 无向图
    /// </summary>
    public class GraphUndirected
    {
        /// <summary>
        /// 记录顶点的数量
        /// </summary>
        private int V = 0;
        /// <summary>
        /// 记录边数
        /// </summary>
        private int E;
        /// <summary>
        /// 邻接表
        /// </summary>
        private QueueList<int>[] adj;

        public GraphUndirected(int v)
        {
            // 初始化顶点数量
            this.V = v;
            // 初始化边的数量
            this.E = 0;
            // 初始化邻接表
            this.adj = new QueueList<int>[this.V];
            for (int i = 0; i < this.adj.Length; i++)
            {
                this.adj[i] = new QueueList<int>();
            }
        }
        /// <summary>
        /// 获取图中顶点的个数
        /// </summary>
        /// <returns></returns>
        public int countV()
        {
            return this.V;
        }
        /// <summary>
        /// 获取图中边的个数
        /// </summary>
        /// <returns></returns>
        public int countE()
        {
            return this.E;
        }
        /// <summary>
        /// 向图中添加一条边 v-w
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        public void addEdge(int v, int w)
        {
            // 在无向图中便是没有方向的，所以该边既可以是v到w的边，也可以说是w到 v的边，
            // 因此 需要让w出现在v的邻接表，也要让v出现在w的邻接表中
            this.adj[v].enqueue(w);
            this.adj[w].enqueue(v);
            // 边的数量 +1
            this.E++;
        }
        /// <summary>
        /// 获取和顶点v相邻的所有顶点
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public QueueList<int> adjGet(int v)
        {
            return this.adj[v];
        }
    }
}
