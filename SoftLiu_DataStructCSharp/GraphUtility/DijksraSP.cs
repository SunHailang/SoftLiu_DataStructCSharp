using SoftLiu_DataStructCSharp.SequenceUtility;
using SoftLiu_DataStructCSharp.TreeUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 最短路径树
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

        }

        /// <summary>
        /// 松弛图g中的顶点v
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void relax(EdgeDirectedWeightedDirgraph g, int v)
        {

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
            return false;
        }
        /// <summary>
        /// 查询从起点s到顶点v的最短路径中所有的边
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public QueueList<EdgeDirected> pathTo(int v)
        {
            return null;
        }
    }
}
