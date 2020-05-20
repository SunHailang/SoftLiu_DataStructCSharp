using SoftLiu_DataStructCSharp.SequenceUtility;
using SoftLiu_DataStructCSharp.TreeUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 最短路径树 Dijksra算法
    /// </summary>
    public class DijksraSP
    {
        /// <summary>
        /// 索引代表顶点，值表示顶点s到当前顶点的最短路径上的最后一条边
        /// </summary>
        private EdgeDirected[] edgeTo;
        /// <summary>
        /// 索引代表顶点，值表示顶点s到当前顶点的最短路径的总权重
        /// </summary>
        private double[] distToDouble;
        /// <summary>
        /// 存放树中顶点与非树中顶点之间的有效横切边
        /// </summary>
        private IndexMinPriorityQueue<double> pq;
        /// <summary>
        /// 根据加权有向图g和顶点s创建一个计算顶点为s的最短路径树对象
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        public DijksraSP(EdgeDirectedWeightedDirgraph g, int s)
        {
            // 初始化 edgeTo
            this.edgeTo = new EdgeDirected[g.countV()];
            // 初始化 distToDouble
            this.distToDouble = new double[g.countV()];
            for (int i = 0; i < this.distToDouble.Length; i++)
            {
                this.distToDouble[i] = Double.PositiveInfinity;
            }
            // 初始化 pq
            this.pq = new IndexMinPriorityQueue<double>(g.countV());
            // 找到图g中顶点s为起点的最短路径树
            // 默认让顶点s进入到最短路径树中
            this.distToDouble[s] = 0.0f;
            this.pq.insert(s, 0.0f);
            // 遍历pq
            while (!this.pq.isEmpty())
            {
                relax(g, this.pq.delMinIndex());
            }
        }

        /// <summary>
        /// 松弛图g中的顶点v
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void relax(EdgeDirectedWeightedDirgraph g, int v)
        {
            IEnumerator ie = g.adj(v).GetEnumerator();
            while (ie.MoveNext())
            {
                EdgeDirected e = (EdgeDirected)ie.Current;
                // 获取到该边的终点w
                int w = e.to();
                // 通过松弛技术，判断从起点s到顶点w的最短路径是否需要先从顶点s到顶点v，然后再由定点v到顶点w
                if (this.distTo(v) + e.weight() < this.distTo(w))
                {
                    this.distToDouble[w] = this.distToDouble[v] + e.weight();
                    this.edgeTo[w] = e;
                    // 判断pq中是否已经存在在顶点w，如果存在，则更新新权重，如果不存在则直接添加
                    if (this.pq.contains(w))
                    {
                        this.pq.changeItem(w, this.distTo(w));
                    }
                    else
                    {
                        this.pq.insert(w, distTo(w));
                    }
                }
            }
        }
        /// <summary>
        /// 获取从顶点s到顶点v的最短路径总权重
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double distTo(int v)
        {
            return this.distToDouble[v];
        }
        /// <summary>
        /// 判断从顶点s到达顶点v是否可达
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool hasPathTo(int v)
        {
            return this.distToDouble[v] < Double.PositiveInfinity;
        }
        /// <summary>
        /// 查询从起点s到顶点v的最短路径中所有的边
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public QueueList<EdgeDirected> pathTo(int v)
        {
            // 判断从顶点 s 到顶点v是否可达
            if (!this.hasPathTo(v))
            {
                return null;
            }
            // 创建队列对象
            QueueList<EdgeDirected> allEdges = new QueueList<EdgeDirected>();
            while (true)
            {
                EdgeDirected e = this.edgeTo[v];
                if (e == null) break;

                allEdges.enqueue(e);
                v = e.from();
            }
            return allEdges;
        }
    }
}
