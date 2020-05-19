using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    /// <summary>
    /// 拓扑排序(无环)
    /// </summary>
    public class TopoLogicalOrder
    {
        /// <summary>
        /// 顶点的拓扑排序
        /// </summary>
        private StackList<int> orderStack;
        /// <summary>
        /// 构造拓扑排序对象
        /// </summary>
        /// <param name="g">有向图</param>
        public TopoLogicalOrder(GraphDigraph g)
        {
            // 检测图是否有环
            GraphDirectedCyle cycle = new GraphDirectedCyle(g);
            bool hasCycle = cycle.hasCycle();
            if (!hasCycle)
            {
                DepthFirstOrder depth = new DepthFirstOrder(g);
                orderStack = depth.reversePost();
            }
        }
        /// <summary>
        /// 判断 g 图是否有环
        /// </summary>
        /// <returns></returns>
        public bool isCycle()
        {
            return this.orderStack == null;
        }
        /// <summary>
        /// 获取拓扑排序的所有顶点
        /// </summary>
        /// <returns></returns>
        public StackList<int> order()
        {
            return this.orderStack;
        }
    }
}
