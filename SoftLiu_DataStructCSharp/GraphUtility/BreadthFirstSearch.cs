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
    /// 广度优先搜索
    /// </summary>
    public class BreadthFirstSearch
    {

        /// <summary>
        /// 索引代表顶点，值表示当前顶点是否已经被搜索
        /// </summary>
        private bool[] markeds;
        /// <summary>
        /// 记录有多少个顶点与s相遇
        /// </summary>
        private int countNum;
        /// <summary>
        /// 用来存储待搜索邻接表的点
        /// </summary>
        private QueueList<int> waitSearch;
        public BreadthFirstSearch(GraphUndirected g, int s)
        {
            // 初始化 markeds的数组
            this.markeds = new bool[g.countV()];
            // 初始跟顶点s相通的顶点的数量
            this.countNum = 0;

            this.waitSearch = new QueueList<int>();

            bfs(g, s);
        }
        /// <summary>
        /// 使用广度优先搜索找到g图中v顶点的所有相遇顶点
        /// </summary>
        /// <param name="g"></param>
        /// <param name="v"></param>
        private void bfs(GraphUndirected g, int v)
        {
            // 把v顶点的 marked标为true
            this.markeds[v] = true;
            // 把顶点v进入队列，待搜索
            this.waitSearch.enqueue(v);
            // 通过循环 如果队列不为空，则从队列中弹出一个待搜索的顶点进行搜索
            while (!this.waitSearch.isEmpty())
            {
                int wait = this.waitSearch.dequeue();
                IEnumerator ie = g.adjGet(wait).GetEnumerator();
                while (ie.MoveNext())
                {
                    int w = (int)ie.Current;
                    if (!this.markeds[w])
                    {
                        bfs(g, w);
                    }
                }
            }
            // 相通顶点数量 +1
            this.countNum++;
        }
        /// <summary>
        /// 判断w顶点与s顶点是否相遇
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool marked(int w)
        {
            if (w >= this.markeds.Length) return false;
            return this.markeds[w];
        }
        /// <summary>
        /// 获取与顶点相通的所有顶点总数
        /// </summary>
        /// <returns></returns>
        public int count()
        {
            return this.countNum;
        }


    }
}
