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
    /// 有向图
    /// </summary>
    public class GraphDigraph
    {

        private int V;
        private int E;

        private QueueList<int>[] adj;

        public GraphDigraph(int v)
        {
            this.V = v;
            this.E = 0;

            this.adj = new QueueList<int>[v];

            for (int i = 0; i < this.adj.Length; i++)
            {
                this.adj[i] = new QueueList<int>();
            }
        }

        public int countV()
        {
            return this.V;
        }

        public int countE()
        {
            return this.E;
        }

        public void addEdge(int v, int w)
        {
            // 只需要让顶点w出现在顶点v的邻接表中，因为边是有方向的， 最终顶点v的邻接表中存储的相邻顶点的含义， v->其他顶点
            this.adj[v].enqueue(w);
            this.E++;
        }

        public QueueList<int> adjGet(int v)
        {
            return this.adj[v];
        }

        private GraphDigraph reverse()
        {
            // 创建图
            GraphDigraph g = new GraphDigraph(this.V);
            // 添加边， 遍历原图的每个顶点
            for (int v = 0; v < this.V; v++)
            {
                //  获取由该顶点v指出的所有的边
                IEnumerator ie = this.adj[v].GetEnumerator();
                while (ie.MoveNext())
                {
                    // 原图中表示的是由顶点v->w的边
                    int w = (int)ie.Current;
                    g.addEdge(w, v);
                }
            }
            return g;
        }


    }
}
