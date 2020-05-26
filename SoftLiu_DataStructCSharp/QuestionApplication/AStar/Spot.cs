using SoftLiu_DataStructCSharp.TreeUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.QuestionApplication.AStar
{
    public class Spot : IHeapItem<Spot>
    {
        public bool walkAble;

        /// <summary>
        /// 行坐标
        /// </summary>
        public int x = 0;
        /// <summary>
        /// 列坐标
        /// </summary>
        public int y = 0;

        public int gCost = Int32.MaxValue;
        public int hCost = Int32.MaxValue;

        /// <summary>
        /// 父节点 打印时候用到
        /// </summary>
        public Spot parent;

        private int heapIndex;

        public int HeapIndex
        {
            get { return this.heapIndex; }
            set { this.heapIndex = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Spot(int _x, int _y, bool _walkable)
        {
            this.x = _x;
            this.y = _y;
            walkAble = _walkable;
        }

        public int fCost
        {
            get { return gCost + hCost; }
        }

        public int CompareTo(Spot other)
        {
            int compare = fCost.CompareTo(other.fCost);
            if (compare == 0)
            {
                compare = hCost.CompareTo(other.hCost);
            }
            return -compare;
        }
    }
}

