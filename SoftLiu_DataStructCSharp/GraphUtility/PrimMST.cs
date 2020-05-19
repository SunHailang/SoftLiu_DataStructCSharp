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
    /// Prim 算法
    /// 贪心算法的一种特殊情况
    /// </summary>
    public class PrimMST
    {
        /// <summary>
        /// 索引代表顶点，值表示当前顶点和最小生成树之间最短边
        /// </summary>
        private Edge[] edgeTo;
        /// <summary>
        /// 索引代表顶点，值表示当前顶点和最小生成树之间最短边的权重
        /// </summary>
        private double[] distTo;
        /// <summary>
        /// 索引代表顶点，如果顶点已经在树中 true， 否则 false
        /// </summary>
        private bool[] markeds;
        /// <summary>
        /// 存放数中顶点和非树中顶点之间的有效横切边
        /// </summary>
        private IndexMinPriorityQueue<double> pq;

        public PrimMST(EdgeWeightedGraph g)
        {
            // 初始化 EdgeTo
            this.edgeTo = new Edge[g.countV()];
            // 初始化distTo
            this.distTo = new double[g.countV()];
            for (int i = 0; i < this.distTo.Length; i++)
            {
                this.distTo[i] = Double.PositiveInfinity;
            }
            // 初始化 markeds
            this.markeds = new bool[g.countV()];
            // 初始化pq
            this.pq = new IndexMinPriorityQueue<double>(g.countV());
            // 默认让顶点 0 进入到树中， 但是树中只有一个顶点0， 因此0顶点默认没有和其他顶点相连， 所以让distTo对应位置处值存储0.0f
            this.distTo[0] = 0.0f;
            this.pq.insert(0, 0.0f);
            // 遍历索引最小优先队列，拿到最小N和N切边对应的顶点，把该顶点加入到最小生成树中
            while (!this.pq.isEmpty())
            {
                this.visit(g, this.pq.delMinIndex());
            }
        }
        /// <summary>
        /// 将顶点v添加到最小生成树中，并且更新数据
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void visit(EdgeWeightedGraph g, int v)
        {
            // 把顶点v添加到最小生成树中，
            this.markeds[v] = true;
            // 更新数据
            IEnumerator ie = g.adj(v).GetEnumerator();
            while (ie.MoveNext())
            {
                Edge e = (Edge)ie.Current;
                // 获取e边的另一个顶点(当前顶点v)
                int w = e.other(v);
                // 判断另一个顶点是不是已经在树中，如果在树中，则不作处理，否则更新数据
                if (this.markeds[w])
                {
                    continue;
                }
                // 判断边e的权重是否小于从w顶点到树中已存在最小边的权重
                if (e.weight() < this.distTo[w])
                {
                    // 更新数据
                    this.edgeTo[w] = e;
                    this.distTo[w] = e.weight();
                    if (pq.contains(w))
                    {
                        this.pq.changeItem(w, e.weight());
                    }
                    else
                    {
                        this.pq.insert(w, e.weight());
                    }
                }
            }
        }
        /// <summary>
        /// 获取最小生成树的所有边
        /// </summary>
        /// <returns></returns>
        public QueueList<Edge> edges()
        {
            // 创建队列对象
            QueueList<Edge> allEdges = new QueueList<Edge>();
            // 遍历 edgeTo数组，拿到每一条边，如果不为null，则添加到队列中
            for (int i = 0; i < this.edgeTo.Length; i++)
            {
                if(this.edgeTo[i] !=null)
                {
                    allEdges.enqueue(this.edgeTo[i]);
                }
            }
            return allEdges;
        }

    }
}
