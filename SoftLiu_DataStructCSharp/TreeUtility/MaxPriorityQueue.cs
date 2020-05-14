using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 最大优先队列  使用的是 堆的思想
    /// </summary>
    public class MaxPriorityQueue<T>
        where T : IComparable
    {
        /// <summary>
        /// 记录堆中的元素
        /// </summary>
        private T[] items;
        /// <summary>
        /// 记录堆中元素个数
        /// </summary>
        private int N;
        /// <summary>
        /// 用于扩容使用  n^2
        /// </summary>
        private int capacity;

        public MaxPriorityQueue(int capacity)
        {
            this.items = new T[capacity + 1];
            this.N = 0;
            this.capacity = capacity;
        }
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return this.N == 0;
        }
        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        public int length()
        {
            return this.N;
        }

        public void insert(T t)
        {
            // 直接将 t 放到数组的最后的位置
            this.items[++this.N] = t;
            swim(this.N);
        }
        /// <summary>
        /// 上浮法
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

        public T delMax()
        {
            T max = this.items[1];
            exch(1, this.N);
            this.items[this.N] = default(T);
            this.N--;
            // 下沉法 重新排序
            sink(1);
            return max;
        }
        /// <summary>
        /// 下沉法
        /// </summary>
        /// <param name="k"></param>
        private void sink(int k)
        {
            // 通过循环不断的对比，当前 k 节点和其子节点 左子节点2k、右子节点2k+1 中的较大值比较大小 如果当前节点小，则交换，否则结束
            while (2 * k <= this.N)
            {
                int max = this.N;
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
                else
                {
                    max = 2 * k;
                }
                if (!less(k, max))
                {
                    break;
                }
                exch(k, max);
                k = max;
            }
        }

        private bool less(int i, int j)
        {
            return this.items[i].CompareTo(this.items[j]) < 0;
        }

        private void exch(int i, int j)
        {
            T temp = this.items[i];
            this.items[i] = this.items[j];
            this.items[j] = temp;
        }
    }
}
