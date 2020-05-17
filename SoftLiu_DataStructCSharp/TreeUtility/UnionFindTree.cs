using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 并查集树
    /// 时间复杂对 最坏的情况(线性树) O(n)
    /// </summary>
    public class UnionFindTree
    {
        private int[] eleAndGroup;

        private int countNum;

        public UnionFindTree(int N)
        {
            // 初始化分组的数量
            this.countNum = N;
            //初始化eleAndGroup中的元素及其所在组的标识符
            this.eleAndGroup = new int[N];
            // 让eleAndGroup数组的索引作为并查集的每个节点的元素，并且让每个索引处的值(该元素所在的组的标识符)就是该索引
            for (int i = 0; i < this.eleAndGroup.Length; i++)
            {
                this.eleAndGroup[i] = i;
            }
        }

        public int count()
        {
            return this.countNum; ;
        }

        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }
        /// <summary>
        /// 元素所在分组的标识符
        /// 时间复杂度  在最坏的情况(线性树)：O(n)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int find(int p)
        {
            while (true)
            {
                if (p == this.eleAndGroup[p])
                {
                    return p;
                }
                p = this.eleAndGroup[p];
            }
        }
        /// <summary>
        /// 时间复杂度  O(1)
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void union(int p, int q)
        {
            // 找到 p元素 和 p元素所在组对应的树的根节点
            int pRoot = find(p);
            int qRoot = find(q);
            // 如果p和q应经在同一个分组则不需要合并
            if (pRoot == qRoot) return;

            // 让p所在的根节点 的父节点为q所在的根节点
            this.eleAndGroup[pRoot] = qRoot;
            // 组数量 -1
            this.countNum--;
        }
    }
}
