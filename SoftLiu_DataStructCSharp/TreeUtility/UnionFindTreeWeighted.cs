using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 并查集 权重树
    /// </summary>
    public class UnionFindTreeWeighted
    {
        /// <summary>
        /// 记录节点元素和该元素所在分组的标识
        /// </summary>
        private int[] eleAndGroup;
        /// <summary>
        /// 初始化分组的数量，有N个分组
        /// </summary>
        private int countNum;
        /// <summary>
        /// 用来存储每一个根节点对应的树保存的节点的个数
        /// </summary>
        private int[] sz;
        /// <summary>
        /// 初始化合并集
        /// </summary>
        /// <param name="N"></param>
        public UnionFindTreeWeighted(int N)
        {
            this.countNum = N;
            this.eleAndGroup = new int[N];

            for (int i = 0; i < this.eleAndGroup.Length; i++)
            {
                this.eleAndGroup[i] = i;
            }
            this.sz = new int[N];
            // 默认情况，sz中每一个索引的值都是1
            for (int i = 0; i < this.sz.Length; i++)
            {
                this.sz[i] = 1;
            }
        }

        public int count()
        {
            return this.countNum;
        }

        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }
        /// <summary>
        /// 元素p在分组中的标识符
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

        public void union(int p, int q)
        {
            // 找到p元素和q元素所在的组对应的树的根节点
            int pRoot = find(p);
            int qRoot = find(q);
            // 如果p和q已经在同一分组，则不需要合并
            if (pRoot == qRoot) return;

            // 判断pRoot对应的树大还是qRoot对应的树大，最终需要把较小的树合并到较大的树
            if(this.sz[pRoot] < this.sz[qRoot])
            {
                this.eleAndGroup[pRoot] = qRoot;
                this.sz[qRoot] += this.sz[pRoot];
            }
            else
            {
                this.eleAndGroup[qRoot] = pRoot;
                this.sz[pRoot] += this.sz[qRoot];
            }

            // 组的数量 -1
            this.countNum--;
        }

    }
}
