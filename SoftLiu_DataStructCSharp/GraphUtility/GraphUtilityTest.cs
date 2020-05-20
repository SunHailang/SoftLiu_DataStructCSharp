using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.GraphUtility
{
    public class GraphUtilityTest
    {
        public static void Test()
        {
            //DepthFirstSearchTest();
            //BreadthFirstSearchTest();
            //GraphRoad();
            //DepthFirstPaths();
            //TopoLogicalOrderTest();
            //PrimMSTTest();
            //KruskalMSTTest();
            DijksraSPTest();
        }
        /// <summary>
        /// 深度优先搜索 测试
        /// </summary>
        private static void DepthFirstSearchTest()
        {
            // 准备 graph 对象
            GraphUndirected graph = new GraphUndirected(13);
            graph.addEdge(0, 5);
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(0, 6);
            graph.addEdge(5, 3);
            graph.addEdge(5, 4);
            graph.addEdge(3, 4);
            graph.addEdge(4, 6);

            graph.addEdge(7, 8);

            graph.addEdge(9, 11);
            graph.addEdge(9, 10);
            graph.addEdge(9, 12);
            graph.addEdge(11, 12);
            // 准备深度优先搜索对象
            int startPoint = 0;
            DepthFirstSearch search = new DepthFirstSearch(graph, startPoint);
            // 测试于某个顶点相遇的顶点数量
            int count = search.count();
            Console.WriteLine("start " + startPoint + " link count: " + count);

            // 测试某个顶点是否与 startPoint 相通
            bool marked = search.marked(5);
            Console.WriteLine("start " + startPoint + " and " + 5 + " marked: " + marked);

            bool marked2 = search.marked(7);
            Console.WriteLine("start " + startPoint + " and " + 7 + " marked: " + marked2);
        }
        /// <summary>
        /// 广度优先搜索
        /// </summary>
        private static void BreadthFirstSearchTest()
        {
            // 准备 graph 对象
            GraphUndirected graph = new GraphUndirected(13);
            graph.addEdge(0, 5);
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(0, 6);
            graph.addEdge(5, 3);
            graph.addEdge(5, 4);
            graph.addEdge(3, 4);
            graph.addEdge(4, 6);

            graph.addEdge(7, 8);

            graph.addEdge(9, 11);
            graph.addEdge(9, 10);
            graph.addEdge(9, 12);
            graph.addEdge(11, 12);
            // 准备深度优先搜索对象
            int startPoint = 0;
            BreadthFirstSearch search = new BreadthFirstSearch(graph, startPoint);
            // 测试于某个顶点相遇的顶点数量
            int count = search.count();
            Console.WriteLine("start " + startPoint + " link count: " + count);

            // 测试某个顶点是否与 startPoint 相通
            bool marked = search.marked(5);
            Console.WriteLine("start " + startPoint + " and " + 5 + " marked: " + marked);

            bool marked2 = search.marked(7);
            Console.WriteLine("start " + startPoint + " and " + 7 + " marked: " + marked2);
        }
        /// <summary>
        /// 判断 路是否相通
        /// </summary>
        private static void GraphRoad()
        {
            GraphUndirected graph = new GraphUndirected(20);

            // 已经修好的路 7条  0-1  6-9  3-8  5-11  2-12  6-10  4-8
            Dictionary<int, int> hadRoad = new Dictionary<int, int>();
            hadRoad.Add(0, 1);
            hadRoad.Add(6, 9);
            hadRoad.Add(3, 8);
            hadRoad.Add(5, 11);
            hadRoad.Add(2, 12);
            hadRoad.Add(4, 8);
            foreach (KeyValuePair<int, int> item in hadRoad)
            {
                // 调用并查集对象的 union方法让两个城市相交
                graph.addEdge(item.Key, item.Value);
            }
            graph.addEdge(6, 10);
            // 调用marked方法判断8顶点、10顶点是否和9顶点相遇 
            // 设置顶点 point 为 9
            int point = 9;
            DepthFirstSearch dSearch = new DepthFirstSearch(graph, point);
            bool markD1 = dSearch.marked(8);

            bool markD2 = dSearch.marked(10);
            Console.WriteLine(string.Format("Depth mark1: {0}, mark2: {1}", markD1, markD2));



            BreadthFirstSearch bSearch = new BreadthFirstSearch(graph, point);
            bool markB1 = bSearch.marked(8);

            bool markB2 = bSearch.marked(10);
            Console.WriteLine(string.Format("Breadth mark1: {0}, mark2: {1}", markB1, markB2));
        }
        /// <summary>
        /// 深度优先 的路径查询
        /// </summary>
        private static void DepthFirstPaths()
        {
            // 构建图
            GraphUndirected graph = new GraphUndirected(6);
            graph.addEdge(0, 2);
            graph.addEdge(0, 1);
            graph.addEdge(2, 1);
            graph.addEdge(2, 3);
            graph.addEdge(2, 4);
            graph.addEdge(3, 5);
            graph.addEdge(3, 4);
            graph.addEdge(0, 5);

            int s = 0;
            DepthFirstPaths path = new DepthFirstPaths(graph, s);
            int endW = 4;
            StackList<int> stack = path.pathTo(endW);

            //while (true)
            //{
            //    if (stack.isEmpty())
            //    {
            //        break;
            //    }
            //    int p = stack.pop();
            //    Console.Write(p + ",");
            //}
            Console.WriteLine();
            IEnumerator ie = stack.GetEnumerator();
            while (ie.MoveNext())
            {
                int point = (int)ie.Current;
                Console.Write(point + ",");
            }
        }
        /// <summary>
        /// 拓扑排序 测试
        /// </summary>
        private static void TopoLogicalOrderTest()
        {
            // 准备有向图
            GraphDigraph graph = new GraphDigraph(6);
            graph.addEdge(0, 2);
            graph.addEdge(0, 3);
            graph.addEdge(1, 3);
            graph.addEdge(2, 4);
            graph.addEdge(3, 4);
            graph.addEdge(4, 5);
            // 通过TopoLogicalOrder对象排序
            TopoLogicalOrder order = new TopoLogicalOrder(graph);
            if (!order.isCycle())
            {
                StackList<int> stack = order.order();
                // 获取顶点线性排序的打印
                if (stack != null)
                {
                    IEnumerator ie = stack.GetEnumerator();
                    while (ie.MoveNext())
                    {
                        int o = (int)ie.Current;
                        Console.Write(o + ",");
                    }
                }
                else
                {
                    Console.WriteLine("TopoLogicalOrder stack is null.");
                }
            }
            else
            {
                Console.WriteLine("has cycle.");
            }


        }
        /// <summary>
        ///  PrimMST 算法测试
        /// </summary>
        private static void PrimMSTTest()
        {
            // 准备一个加权无向图
            EdgeWeightedGraph graph = new EdgeWeightedGraph(8);
            graph.addEdge(new Edge(4, 5, 0.35f));
            graph.addEdge(new Edge(4, 7, 0.37f));
            graph.addEdge(new Edge(5, 7, 0.28f));
            graph.addEdge(new Edge(0, 7, 0.16f));
            graph.addEdge(new Edge(1, 5, 0.32f));
            graph.addEdge(new Edge(0, 4, 0.38f));
            graph.addEdge(new Edge(2, 3, 0.17f));
            graph.addEdge(new Edge(1, 7, 0.19f));
            graph.addEdge(new Edge(0, 2, 0.26f));
            graph.addEdge(new Edge(1, 2, 0.36f));
            graph.addEdge(new Edge(1, 3, 0.29f));
            graph.addEdge(new Edge(2, 7, 0.34f));
            graph.addEdge(new Edge(6, 2, 0.40f));
            graph.addEdge(new Edge(3, 6, 0.52f));
            graph.addEdge(new Edge(6, 0, 0.58f));
            graph.addEdge(new Edge(6, 4, 0.93f));
            // 创建一个 primMST对象， 计算加权无向图中的最小树
            PrimMST prim = new PrimMST(graph);
            // 获取最小生成树中的所有边
            QueueList<Edge> queue = prim.edges();
            // 遍历打印所有边
            IEnumerator ie = queue.GetEnumerator();
            while (ie.MoveNext())
            {
                Edge e = (Edge)ie.Current;
                int v = e.either();
                int w = e.other(v);
                Console.WriteLine(v + "->" + w + " : " + e.weight().ToString("F2") + ",");
            }
        }
        /// <summary>
        /// KruskalMST 算法的测试
        /// </summary>
        private static void KruskalMSTTest()
        {
            // 准备一个加权无向图
            EdgeWeightedGraph graph = new EdgeWeightedGraph(8);
            graph.addEdge(new Edge(4, 5, 0.35f));
            graph.addEdge(new Edge(4, 7, 0.37f));
            graph.addEdge(new Edge(5, 7, 0.28f));
            graph.addEdge(new Edge(0, 7, 0.16f));
            graph.addEdge(new Edge(1, 5, 0.32f));
            graph.addEdge(new Edge(0, 4, 0.38f));
            graph.addEdge(new Edge(2, 3, 0.17f));
            graph.addEdge(new Edge(1, 7, 0.19f));
            graph.addEdge(new Edge(0, 2, 0.26f));
            graph.addEdge(new Edge(1, 2, 0.36f));
            graph.addEdge(new Edge(1, 3, 0.29f));
            graph.addEdge(new Edge(2, 7, 0.34f));
            graph.addEdge(new Edge(6, 2, 0.40f));
            graph.addEdge(new Edge(3, 6, 0.52f));
            graph.addEdge(new Edge(6, 0, 0.58f));
            graph.addEdge(new Edge(6, 4, 0.93f));
            // 创建KruskalMST对象
            KruskalMST kruskal = new KruskalMST(graph);
            QueueList<Edge> allEdges = kruskal.edges();
            IEnumerator ie = allEdges.GetEnumerator();
            while (ie.MoveNext())
            {
                Edge e = (Edge)ie.Current;
                int v = e.either();
                int w = e.other(v);
                Console.WriteLine(v + "->" + w + " : " + e.weight().ToString("F2") + ",");
            }
        }
        /// <summary>
        /// 最短路径
        /// </summary>
        private static void DijksraSPTest()
        {
            // 创建加权有向图
            EdgeDirectedWeightedDirgraph graph = new EdgeDirectedWeightedDirgraph(8);
            graph.addEdge(new EdgeDirected(4, 5, 0.35f));
            graph.addEdge(new EdgeDirected(5, 4, 0.35f));
            graph.addEdge(new EdgeDirected(4, 7, 0.37f));
            graph.addEdge(new EdgeDirected(5, 7, 0.28f));
            graph.addEdge(new EdgeDirected(7, 5, 0.28f));
            graph.addEdge(new EdgeDirected(5, 1, 0.32f));
            graph.addEdge(new EdgeDirected(0, 4, 0.38f));
            graph.addEdge(new EdgeDirected(0, 2, 0.26f));
            graph.addEdge(new EdgeDirected(7, 3, 0.39f));
            graph.addEdge(new EdgeDirected(1, 3, 0.29f));
            graph.addEdge(new EdgeDirected(2, 7, 0.34f));
            graph.addEdge(new EdgeDirected(6, 2, 0.40f));
            graph.addEdge(new EdgeDirected(3, 6, 0.52f));
            graph.addEdge(new EdgeDirected(6, 0, 0.58f));
            graph.addEdge(new EdgeDirected(6, 4, 0.93f));
            // 创建 DijksraSP 对象 查找最短路径
            int start = 0;
            DijksraSP dijksra = new DijksraSP(graph, start);
            // 查找最短路径  0->6
            int end = 6;
            QueueList<EdgeDirected> allEdges = dijksra.pathTo(end);
            // 遍历打印
            if (allEdges == null)
            {
                Console.WriteLine("not path to " + end);
            }
            else
            {
                IEnumerator ie = allEdges.GetEnumerator();
                while (ie.MoveNext())
                {
                    EdgeDirected e = (EdgeDirected)ie.Current;
                    Console.WriteLine(e.from() + " -> " + e.to() + " : " + e.weight().ToString("F2"));
                }
            }
        }
    }
}
