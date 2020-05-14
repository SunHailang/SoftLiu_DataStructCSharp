using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// 堆 排序
    /// </summary>
    public class HeapSort<T>
        where T : IComparable
    {

        public static void sort(T[] source)
        {
            T[] heap = new T[source.Length + 1];
            createHeap(source, heap);
            // 定义一个变量, 记录堆中的最大索引
            int N = heap.Length - 1;
            while (N > 1)
            {
                // 交换元素
                exch(heap, N, 1);
                N--;
                // 排除最大索引元素
                sink(heap, 1, N);
            }
            // heap中的数据就是 从小到大的数据
            Array.Copy(heap, 1, source, 0, heap.Length - 1);
        }

        private static void createHeap(T[] source, T[] heap)
        {
            // 把 source 中的元素拷贝到heap中  heap的元素就形成了一个无序堆
            Array.Copy(source, 0, heap, 1, source.Length);
            // 对堆中的元素下沉调整(从长度的一半开始，往索引为1处扫描)
            for (int i = (heap.Length / 2); i > 0; i--)
            {
                sink(heap, i, heap.Length - 1);
            }
        }
        private static void sink(T[] heap, int target, int range)
        {
            while (2 * target <= range)
            {
                // 找出当前节点的较大的子节点
                int max = target;
                if (2 * target + 1 <= range)
                {
                    if (less(heap, 2 * target, 2 * target + 1))
                    {
                        max = 2 * target + 1;
                    }
                    else
                    {
                        max = 2 * target;
                    }
                }
                // 比较当前节点的值和较大子节点的值
                if (!less(heap, target, max))
                {
                    break;
                }
                // 交换元素
                exch(heap, target, max);
                // 变换target
                target = max;
            }
        }

        private static bool less(T[] heap, int i, int j)
        {
            return heap[i].CompareTo(heap[j]) < 0;
        }

        private static void exch(T[] heap, int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
