using SoftLiu_DataStructCSharp.SequenceUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.TreeUtility
{
    public class QuadTree
    {

        public Rectangle boundary;
        public int capacity;
        public QueueList<Point> points;

        public QuadTree northeast;
        public QuadTree northwest;
        public QuadTree southeast;
        public QuadTree southwest;

        public bool divided;
        public QuadTree(Rectangle boundary, int n)
        {
            this.boundary = boundary;
            this.capacity = n;
            this.points = new QueueList<Point>();
            this.divided = false;
        }

        private void subdivde()
        {
            int x = this.boundary.x;
            int y = this.boundary.y;
            int w = this.boundary.w;
            int h = this.boundary.h;
            Rectangle ne = new Rectangle(x + w / 2, y - h / 2, w / 2, h / 2);
            this.northeast = new QuadTree(ne, this.capacity);
            Rectangle nw = new Rectangle(x - w / 2, y - h / 2, w / 2, h / 2);
            this.northwest = new QuadTree(nw, this.capacity);
            Rectangle se = new Rectangle(x + w / 2, y + h / 2, w / 2, h / 2);
            this.southeast = new QuadTree(se, this.capacity);
            Rectangle sw = new Rectangle(x - w / 2, y + h / 2, w / 2, h / 2);
            this.southwest = new QuadTree(sw, this.capacity);
            this.divided = true;
        }

        public bool insert(Point point)
        {
            if (!this.boundary.constains(point)) return false;

            if (this.points.length() < this.capacity)
            {
                this.points.enqueue(point);
                return true;
            }
            else
            {
                if (!divided)
                {
                    this.subdivde();
                }
                if (this.northeast.insert(point)) return true;
                else if (this.northwest.insert(point)) return true;
                else if (this.southeast.insert(point)) return true;
                else if (this.southwest.insert(point)) return true;
                else
                    return false;
            }
        }

        public QueueList<Point> query(Rectangle range, QueueList<Point> found = null)
        {
            if (found == null) found = new QueueList<Point>();

            if (!this.boundary.intersects(range))
            {
                return found;
            }
            else
            {
                IEnumerator ie = this.points.GetEnumerator();
                while (ie.MoveNext())
                {
                    Point p = ie.Current as Point;
                    if (p != null && range.constains(p))
                    {
                        found.enqueue(p);
                    }
                }
                if (this.divided)
                {
                    this.northwest.query(range, found);
                    this.northeast.query(range, found);
                    this.southwest.query(range, found);
                    this.southeast.query(range, found);
                }
            }
            return found;
        }

    }
    /// <summary>
    /// 坐标点位置在中心点
    /// </summary>
    public class Point
    {
        public int x;
        public int y;

        private string m_name;
        public string name { get { return m_name; } }
        public Point(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.m_name = name;
        }
    }
    /// <summary>
    /// 坐标点位置在中心点
    /// </summary>
    public class Rectangle
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public Rectangle(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public bool constains(Point point)
        {
            return (point.x >= this.x - this.w / 2 &&
                point.x <= this.x + this.w / 2 &&
                point.y >= this.y - this.h / 2 &&
                point.y <= this.y + this.h / 2);
        }

        public bool intersects(Rectangle range)
        {
            return !(range.x - range.w / 2 > this.x + this.w / 2 ||
                range.x + range.w / 2 < this.x + this.w / 2 ||
                range.y - range.h / 2 > this.y + this.h / 2 ||
                range.y + range.h / 2 < this.y - this.h / 2);
        }
    }

}
