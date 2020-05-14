using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 索引优先队列
    /// </summary>
    public class IndexMinPriorityQueue<T>
        where T : IComparable
    {
        // 存储元素
        private T[] items;
        // 保存items元素的索引
        private int[] pq;
        // 保存qp的逆序，pq作为值的索引， pq的索引作为值
        private int[] qp;
        // 记录堆中元素的个数
        private int N;

        public IndexMinPriorityQueue(int capacity)
        {
            this.items = new T[capacity + 1];
            this.pq = new int[capacity + 1];
            this.qp = new int[capacity + 1];
            this.N = 0;

            // 默认情况下队列中都没有存储任何元素, 让qp元素为-1
            for (int i = 0; i < capacity + 1; i++)
            {
                qp[i] = -1;
                pq[i] = -1;
            }
        }

        public bool isEmpty()
        {
            return this.N <= 0;
        }
        public int length()
        {
            return this.N;
        }
        public bool contains(int k)
        {
            return this.qp[k] != -1;
        }
        public int minIndex()
        {
            return this.pq[1];
        }

        public void insert(int i, T t)
        {
            // 判断i是否已经被关联， 如果已关联不能插入，否则插入
            if (contains(i)) return;
            // 元素个数 +1
            this.N++;
            // 把数据存放到items对应的位置
            this.items[i] = t;
            // 把i存放到pq里
            this.pq[this.N] = i;
            // 通过qp记录pq中的i
            this.qp[i] = this.N;
            // 上浮法
            swim(this.N);
        }
        private void swim(int k)
        {
            while (k > 1)
            {
                if (less(k, k / 2))
                {
                    exch(k, k / 2);
                }
                k = k / 2;
            }
        }

        public void changeItem(int i, T t)
        {
            // 修改 items中 i 位置的元素为t
            this.items[i] = t;
            // 找到i在pq中的位置
            int k = this.qp[i];
            // 调整堆
            sink(k);
            swim(k);
        }

        public int delMinIndex()
        {
            // 获取最小元素，关联的索引
            int minIndex = this.pq[1];
            // 删除items中的元素
            this.items[this.pq[minIndex]] = default(T);
            // 交换pq中1和最大索引的元素
            exch(1, this.N);
            // 删除qp中对应的内容
            this.qp[this.pq[this.N]] = -1;
            // 删除掉 pq最大索引数
            this.pq[this.N] = -1;
            
            // 元素个数 -1
            this.N--;
            // 下沉矫正
            sink(1);
            return minIndex;
        }
        /// <summary>
        /// 删除 索引为 i 处的元素
        /// </summary>
        /// <param name="i"></param>
        public void delete(int i)
        {
            //i++;
            int k = this.pq[i];
            // 交换pq中索引k的值和最大索引的值
            exch(k, this.N);
            // 删除qp的值
            this.qp[this.pq[this.N]] = -1;
            // 删除pq的值
            this.pq[this.N] = -1;
            // 删除 items的值
            this.items[k] = default(T);
            // 元素个数 -1
            this.N--;
            // 堆调整
            sink(k);
            swim(k);
        }
        private void sink(int k)
        {
            while (2 * k <= this.N)
            {
                int min = 2 * k;
                // 找到子节点中的较小值，在进行比较
                if (2 * k + 1 <= this.N)
                {
                    if (less(2 * k, 2 * k + 1))
                    {
                        min = 2 * k;
                    }
                    else
                    {
                        min = 2 * k + 1;
                    }
                }
                else
                {
                    min = 2 * k;
                }
                if (less(k, min))
                {
                    break;
                }
                exch(k, min);
                k = min;
            }
        }

        private bool less(int i, int j)
        {
            return (this.items[this.pq[i]].CompareTo(this.items[this.pq[j]])) < 0;
        }
        private void exch(int i, int j)
        {
            // 交换 pq的数据
            int tmp = this.pq[i];
            this.pq[i] = this.pq[j];
            this.pq[j] = tmp;
            // 更新qp的值
            this.qp[this.pq[i]] = i;
            this.qp[this.pq[j]] = j;
        }
    }
}
