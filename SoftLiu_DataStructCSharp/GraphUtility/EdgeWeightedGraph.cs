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
    /// 加权无向图表示
    /// </summary>
    public class EdgeWeightedGraph
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
        private QueueList<Edge>[] adjQueue;

        public EdgeWeightedGraph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adjQueue = new QueueList<Edge>[v];
            for (int i = 0; i < this.adjQueue.Length; i++)
            {
                this.adjQueue[i] = new QueueList<Edge>();
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
        /// 向加权无向图中添加一条边 e
        /// </summary>
        /// <param name="e"></param>
        public void addEdge(Edge e)
        {
            // 需要让边 e 同时出现在 e这两个顶点的邻接表中
            int v = e.either();
            int w = e.other(v);

            this.adjQueue[v].enqueue(e);
            this.adjQueue[w].enqueue(e);

            this.E++;
        }
        /// <summary>
        /// 获取顶点v关联的所有边
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public QueueList<Edge> adj(int v)
        {
            return this.adjQueue[v];
        }
        /// <summary>
        /// 获取加权无向图所有的边
        /// </summary>
        /// <returns></returns>
        public QueueList<Edge> edges()
        {
            // 创建队列存储所有的边
            QueueList<Edge> allEdge = new QueueList<Edge>();
            //遍历图中的每一个边，找到该顶点的邻接表，邻接表中存储了该顶点关联的每一条边
            for (int v = 0; v < this.countV(); v++)
            {
                // 遍历v顶点的邻接表，找到每一条和v关联的边
                IEnumerator ie = this.adj(v).GetEnumerator();
                while (ie.MoveNext())
                {
                    Edge e = (Edge)ie.Current;
                    if (e.other(v) < v)
                    {
                        // 因为是无向图，所以同一条边会同时出现在了它关联的两个顶点的邻接表，需要让一条边只记录一次
                        allEdge.enqueue(e);
                    }
                }
            }
            return allEdge;
        }
    }
}
