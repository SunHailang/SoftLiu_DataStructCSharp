using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 并查集
    /// </summary>
    public class UnionFind
    {
        /// <summary>
        /// 这个数组的索引看作是当前每个节点存的元素
        /// 时间复杂度  O(n^2)
        /// </summary>
        private int[] eleAndGroup;

        private int countNum;

        public UnionFind(int N)
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

        public int find(int p)
        {
            return this.eleAndGroup[p];
        }

        public void union(int p, int q)
        {
            // 判断元素q和p是否已经在同一分组中，如果已经在同一分组中则结束
            if (connected(p, q)) return;

            // 找到p所在分组的标识符
            int pGroup = find(p);
            // 找到q所在分组的标识符
            int qGroup = find(q);
            // 合并组, 让p所在组的所有元素的标识符变为q所在分组的标识符
            for (int i = 0; i < this.eleAndGroup.Length; i++)
            {
                if (this.eleAndGroup[i] == pGroup)
                {
                    this.eleAndGroup[i] = qGroup;
                }
            }
            // 分组个数 -1
            this.countNum--;
        }
    }
}
