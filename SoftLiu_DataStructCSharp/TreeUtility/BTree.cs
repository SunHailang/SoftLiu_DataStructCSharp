using SoftLiu_DataStructCSharp.SortUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    /// <summary>
    /// B树  
    /// 磁盘的存储采用的就是 B树

    /// </summary>
    public class BTree<TKey, TValue>
        where TKey : IComparable
    {

        private class Data : IComparable
        {
            public TKey key;
            public TValue value;
            public Data(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
            }

            public int CompareTo(object obj)
            {
                if (obj is Data)
                {
                    Data n = obj as Data;
                    if (n != null)
                    {
                        return this.key.CompareTo(n.key);
                    }
                }
                return 1;
            }
        }

        private class Node
        {
            //public int steps;
            public int N;

            public Data[] datas;

            public Node[] nodes; 

            public Node(int steps)
            {
                //this.steps = steps;
                this.datas = new Data[steps];
            }

            public Data put(TKey key, TValue value)
            {
                this.datas[this.N++] = new Data(key, value);
                ShellSort.sort(this.datas);
                if (this.N == this.datas.Length)
                {
                    return this.datas[(this.N + 1) / 2];
                }
                return null;
            }
        }

        private Node root;
        private int steps;

        // m介 B树 
        public BTree(int steps)
        {
            this.root = null;
            this.steps = steps;
        }

        // 树中每个节点至多有m壳树
        // 
    }
    /// <summary>
    /// B+ 树 
    /// 存储值的地方是叶子节点 ， 非叶子节点只存key
    /// </summary>
    public class BPlusTree
    {
        // 
    }
}
