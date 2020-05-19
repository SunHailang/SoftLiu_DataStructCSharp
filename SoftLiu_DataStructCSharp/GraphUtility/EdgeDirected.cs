using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 加权有向图的边
    /// </summary>
    public class EdgeDirected
    {
        /// <summary>
        /// 起点
        /// </summary>
        private int V;
        /// <summary>
        /// 终点
        /// </summary>
        private int W;
        /// <summary>
        /// 当前边的权重
        /// </summary>
        private double weightDouble;
        /// <summary>
        /// 通过顶点v和w，以及权重weight值构建一个边对象
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <param name="weight"></param>
        public EdgeDirected(int v, int w, double weight)
        {
            this.V = v;
            this.W = w;
            this.weightDouble = weight;
        }
        /// <summary>
        /// 获取边的权重
        /// </summary>
        /// <returns></returns>
        public double weight()
        {
            return this.weightDouble;
        }
        /// <summary>
        /// 获取有向边的起点
        /// </summary>
        /// <returns></returns>
        public int from()
        {
            return -1;
        }
        /// <summary>
        /// 获取有向边的终点
        /// </summary>
        /// <returns></returns>
        public int to()
        {
            return -1;
        }
    }
}
