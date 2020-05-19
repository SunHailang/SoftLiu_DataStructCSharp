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
    /// kruskal 算法
    /// (贪心算法的一种)
    /// </summary>
    public class KruskalMST
    {
        /// <summary>
        /// 保存最小生成树所有的边
        /// </summary>
        private QueueList<Edge> mst;
        /// <summary>
        /// 索引代表顶点 ，使用 uf.connect(v, w) 可以判断顶点vhe顶点我是否在同一棵树，使用uf.union(v, w)可以把顶点v所在的树和顶点w所在的树合并
        /// </summary>
        private UnionFindTreeWeighted uf;
        /// <summary>
        /// 存储图中所有的边，使用最小优先队列按照边的权重排序
        /// </summary>
        private MinPriorityQueue<Edge> pq;
        /// <summary>
        /// 根据加权无向图，创建最小生成树对象
        /// </summary>
        /// <param name="g"></param>
        public KruskalMST(EdgeWeightedGraph g)
        {
            // 图中所有的顶点
            int count = g.countV();
            // 初始化 mst
            this.mst = new QueueList<Edge>();
            // 初始化 uf
            this.uf = new UnionFindTreeWeighted(count);
            // 初始化 pq
            this.pq = new MinPriorityQueue<Edge>(g.countE());
            // 把图中所有的边存储到pq中
            IEnumerator ie = g.edges().GetEnumerator();
            while (ie.MoveNext())
            {
                Edge e = (Edge)ie.Current;
                this.pq.insert(e);
            }
            // 遍历pq队列拿到最小权重的边，进行处理
            while (!this.pq.isEmpty() && this.mst.length() < g.countV() - 1)
            {
                // 找到权重最小边
                Edge e = this.pq.delMin();
                // 找到该边的两个顶点
                int v = e.either();
                int w = e.other(v);
                // 判断这两个顶点是否已经在同一个树中， 如果在同一个树中，则不处理，如果不在同一个树中则合并这两个顶点的树
                if (this.uf.connected(v, w)) continue;
                this.uf.union(v, w);
                // 让e进入到mst中
                this.mst.enqueue(e);
            }
        }
        /// <summary>
        /// 获取最小生成树所有的边
        /// </summary>
        /// <returns></returns>
        public QueueList<Edge> edges()
        {
            return this.mst;
        }
    }
}
