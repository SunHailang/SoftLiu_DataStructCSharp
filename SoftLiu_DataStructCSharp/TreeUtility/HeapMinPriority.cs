using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 最小优先堆
    /// </summary>
    public class HeapMinPriority<T>
        where T : IHeapItem<T>
    {
        T[] items;
        int currentItemCount;

        public HeapMinPriority(int maxHeapSize)
        {
            items = new T[maxHeapSize];
            currentItemCount = 0;
        }

        public void insert(T item)
        {
            item.HeapIndex = this.currentItemCount;
            this.items[this.currentItemCount] = item;
            this.sortUp(item);
            this.currentItemCount++;
        }
        private void sortUp(T item)
        {
            int parentIndex = (item.HeapIndex - 1) / 2;
            while (true)
            {
                T parentItem = this.items[parentIndex];
                if (item.CompareTo(parentItem) > 0)
                {
                    this.swap(item, parentItem);
                }
                else
                {
                    break;
                }
                parentIndex = (item.HeapIndex - 1) / 2;
            }
        }

        public T delMin()
        {
            T firstItem = this.items[0];
            this.currentItemCount--;
            items[0] = items[this.currentItemCount];
            items[0].HeapIndex = 0;
            this.sortDown(this.items[0]);
            return firstItem;
        }
        private void sortDown(T item)
        {
            while (true)
            {
                int childIndexLeft = item.HeapIndex * 2 + 1;
                int childIndexRight = item.HeapIndex * 2 + 2;
                int swapIndex = 0;
                if (childIndexLeft < this.currentItemCount)
                {
                    swapIndex = childIndexLeft;
                    if (childIndexRight < this.currentItemCount)
                    {
                        if (this.items[childIndexLeft].CompareTo(this.items[childIndexRight]) < 0)
                        {
                            swapIndex = childIndexRight;
                        }
                    }

                    if (item.CompareTo(this.items[swapIndex]) < 0)
                    {
                        this.swap(item, this.items[swapIndex]);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        public void updateItem(T item)
        {
            this.sortUp(item);
        }

        public bool containsItem(T item)
        {
            return Equals(this.items[item.HeapIndex], item);
        }

        public int Count
        {
            get { return this.currentItemCount; }
        }

        private void swap(T itemA, T itemB)
        {
            items[itemA.HeapIndex] = itemB;
            items[itemB.HeapIndex] = itemA;
            int itemAIndex = itemA.HeapIndex;
            itemA.HeapIndex = itemB.HeapIndex;
            itemB.HeapIndex = itemAIndex;
        }
    }

    public interface IHeapItem<T> : IComparable<T>
    {
        int HeapIndex { get; set; }
    }
}
