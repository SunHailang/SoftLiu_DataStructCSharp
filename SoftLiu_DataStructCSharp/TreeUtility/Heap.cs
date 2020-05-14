using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 堆  完全二叉树
    /// 堆中 父节点都是大于他的两个子节点
    /// </summary>
    public class Heap<T> where T : IComparable
    {
        private T[] items;
        private int N;


        public Heap(int capacity)
        {
            this.items = new T[capacity + 1];
            this.N = 0;
        }
        /// <summary>
        /// 比较元素 大小
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private bool less(int i, int j)
        {
            return this.items[i].CompareTo(this.items[j]) < 0;
        }
        /// <summary>
        /// 交换元素
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void exch(int i, int j)
        {
            T temp = this.items[i];
            this.items[i] = this.items[j];
            this.items[j] = temp;
        }

        /// <summary>
        /// 插入一个元素
        /// </summary>
        /// <param name="t"></param>
        public void insert(T t)
        {
            this.items[++this.N] = t;
            swim(this.N);
        }
        /// <summary>
        /// 使用上浮算法，使元素k能在堆中处在一个正确的位置
        /// </summary>
        /// <param name="k"></param>
        private void swim(int k)
        {
            // 通过循环不断地比较 当前节点k和父节点，如果父节点小于当前节点，交换位置，否则结束
            while (k > 1)
            {
                // 比较当前节点和父节点
                if (less(k / 2, k))
                {
                    exch(k / 2, k);
                }
                k = k / 2;
            }
        }
        /// <summary>
        /// 删除堆中最大的元素
        /// </summary>
        /// <returns></returns>
        public T delMax()
        {
            T max = this.items[1];
            // 交换索引为1和最大索引处的元素， 让完全二叉树中最右侧的元素变为临时跟节点
            exch(1, this.N);
            // 删除最大索引处的元素
            this.items[this.N] = default(T);
            // 元素个数 -1
            this.N--;
            // 让我们的堆重新有序， 通过下沉法调整堆， 让堆重新有序
            sink(1);
            return max;
        }
        /// <summary>
        /// 使用下沉法，使元素k能在堆中处在一个正确的位置
        /// </summary>
        /// <param name="k"></param>
        private void sink(int k)
        {
            // 通过循环不断的对比，当前 k 节点和其子节点 左子节点2k、右子节点2k+1 中的较大值比较大小 如果当前节点小，则交换，否则结束
            while (2 * k <= this.N)
            {
                // 记录较大节点的索引， 初始为最大索引
                int max = this.N;
                // 获取当前节点 子节点中的较大者
                if (2 * k + 1 <= this.N)
                {
                    if (less(2 * k, 2 * k + 1))
                    {
                        max = 2 * k + 1;
                    }
                    else
                    {
                        max = 2 * k;
                    }
                }
                // 比较当前节点和较大节点的值
                if (!less(k, max))
                {
                    break;
                }
                // 交换k索引处和max索引处的值
                exch(k, max);
                // 变换k的值
                k = max;
            }
        }
    }
}
