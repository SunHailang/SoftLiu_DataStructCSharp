using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 加权无向图边的表示
    /// </summary>
    public class Edge : IComparable
    {
        private int V;
        private int W;
        private double weightCount;
        public Edge(int v, int w, double weight)
        {
            this.V = v;
            this.W = w;
            this.weightCount = weight;
        }

        public double weight()
        {
            return this.weightCount;
        }

        public int either()
        {
            return this.V;
        }
        /// <summary>
        /// 获取边上除了顶点vertex外的另外一个顶点
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int other(int vertex)
        {
            if (vertex == this.V)
            {
                return this.W;
            }
            else
            {
                return this.V;
            }
        }

        public int CompareTo(object obj)
        {
            // 使用一个变量记录比较的结果
            int cmp = 0;
            if (obj is Edge)
            {
                Edge edge = obj as Edge;
                // 如果当前边的权重值大 1
                if (this.weight() > edge.weight()) cmp = 1;
                // 如果当前边的权重值小 -1
                if (this.weight() < edge.weight()) cmp = -1;
                // 如果当前边的权重值和这条边一样大 0
            }
            return cmp;
        }
    }
}
