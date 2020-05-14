using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 最小优先队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinPriorityQueue<T>
         where T : IComparable
    {
        private T[] items;
        private int N;

        public MinPriorityQueue(int capacity)
        {
            this.items = new T[capacity + 1];
            this.N = 0;
        }

        public int length()
        {
            return this.N;
        }

        public bool isEmpty()
        {
            return this.N <= 0;
        }

        public void insert(T t)
        {
            this.items[++this.N] = t;
            swim(this.N);
        }
        /// <summary>
        /// 下沉法
        /// </summary>
        /// <param name="k"></param>
        private void swim(int k)
        {
            // 通过循环不断地比较 当前节点k和父节点
            while (k > 1)
            {
                if (less(k, k / 2))
                {
                    exch(k, k / 2);
                }
                k = k / 2;
            }
        }
        public T delMin()
        {
            T min = this.items[1];
            exch(1, this.N);
            this.items[this.N] = default(T);
            this.N--;
            sink(1);
            return min;
        }
        /// <summary>
        /// 上浮法
        /// </summary>
        /// <param name="k"></param>
        private void sink(int k)
        {
            // 通过循环比较当前节点和其子节点中的较小值
            while (2 * k <= this.N)
            {
                // 找到子节点中的较小值
                int min = this.N;
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
                // 判断较小值
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
