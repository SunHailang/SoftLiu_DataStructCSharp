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
    /// 加权有向图
    /// </summary>
    public class EdgeDirectedWeightedDirgraph
    {
        /// <summary>
        /// 记录顶点的数量
        /// </summary>
        private int V;
        /// <summary>
        /// 记录边的数量
        /// </summary>
        private int E;
        /// <summary>
        /// 邻接表
        /// </summary>
        private QueueList<EdgeDirected>[] adjQueue;

        public EdgeDirectedWeightedDirgraph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adjQueue = new QueueList<EdgeDirected>[v];
            for (int i = 0; i < this.adjQueue.Length; i++)
            {
                this.adjQueue[i] = new QueueList<EdgeDirected>();
            }
        }
        /// <summary>
        /// 获取图中顶点的数量
        /// </summary>
        /// <returns></returns>
        public int countV()
        {
            return this.V;
        }
        /// <summary>
        /// 获取图中边的数量
        /// </summary>
        /// <returns></returns>
        public int countE()
        {
            return this.E;
        }
        /// <summary>
        /// 向加权有向图中添加一条边e
        /// </summary>
        /// <param name="e"></param>
        public void addEdge(EdgeDirected e)
        {
            // 边e是有方向的，所以只需要让e出现在起点的邻接表中即可
            int v = e.from();
            this.adjQueue[v].enqueue(e);
            this.E++;

        }
        /// <summary>
        /// 获取由顶点v指出的所有的边
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public QueueList<EdgeDirected> adj(int v)
        {
            return this.adjQueue[v];
        }
        /// <summary>
        /// 获取加权有向图的所有边
        /// </summary>
        /// <returns></returns>
        public QueueList<EdgeDirected> edges()
        {
            // 遍历图中的每一个顶点，得到该顶点的邻阶表遍历得到每一条边，添加到队列中返回即可
            QueueList<EdgeDirected> allEdges = new QueueList<EdgeDirected>();
            for (int v = 0; v < this.V; v++)
            {
                IEnumerator ie = this.adjQueue[v].GetEnumerator();
                while (ie.MoveNext())
                {
                    EdgeDirected e = (EdgeDirected)ie.Current;
                    allEdges.enqueue(e);
                }
            }
            return allEdges;
        }
    }
}
