using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.SequenceUtility
{

    /// <summary>
    /// 扩容 / 减容
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceList<T>
    {
        // 存储元素数组
        private T[] eles;
        // 记录当前顺序表中的元素个数
        private int N;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="capacity"></param>
        public SequenceList(int capacity)
        {
            // 初始化数组
            this.eles = new T[capacity];
            //初始化长度
            this.N = 0;
        }

        public void clear()
        {
            this.N = 0;
        }

        public bool isEmpty()
        {
            return this.N <= 0;
        }

        public int length()
        {
            return this.N;
        }

        public T get(int index)
        {
            if (index >= this.N || index < 0) return default(T);
            return this.eles[index];
        }

        public void insert(T t)
        {
            if (this.N == this.eles.Length)
            {
                resize(this.eles.Length * 2);
            }
            this.eles[this.N++] = t;
        }
        /// <summary>
        /// 插入元素到固定的位置， 
        /// 如果index 小于 0 则默认index 等于 0
        /// 如果index 大于 this.N 则默认index 等于 this.N,
        /// </summary>
        /// <param name="index"></param>
        /// <param name="t"></param>
        public void insert(int index, T t)
        {
            if (index < 0) { index = 0; }
            else if (index > this.N) { index = this.N; }

            if (index == this.N) resize(this.eles.Length * 2);

            // 先把 i 索引处的元素及其后面的元素往后移一个位置
            for (int i = this.N; i > index; i--)
            {
                this.eles[i] = this.eles[i - 1];
            }
            // 再把 t 放到 index 的位置
            this.eles[index] = t;
            this.N++;
        }

        public T remove(int index)
        {
            if (index < 0 || index >= this.N) return default(T);
            // 记录索引 index 的值
            T current = this.eles[index];
            // index 后面的值 向前移动1
            for (int i = index; i < this.N - 1; i++)
            {
                this.eles[i] = this.eles[i + 1];
            }
            // 元素个数 减1
            this.N--;

            if (this.N < this.eles.Length / 2)
            {
                resize(this.eles.Length / 2);
            }
            return current;
        }
        /// <summary>
        /// 查找 元素 t 在链表中第一次出现的索引
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int indexOf(T t)
        {
            for (int i = 0; i < this.N; i++)
            {
                if (this.eles[i].Equals(t))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 根据newsize 重置 eles的大小
        /// </summary>
        /// <param name="newsize"></param>
        private void resize(int newsize)
        {
            // 定义一个临时数组 指向原数组
            T[] temp = this.eles;
            this.eles = new T[newsize];
            for (int i = 0; i < temp.Length; i++)
            {
                this.eles[i] = temp[i];
            }
        }
    }
}
