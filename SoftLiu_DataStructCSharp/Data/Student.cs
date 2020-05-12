using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLiu_DataStructCSharp.Data
{
    public class Student : IComparable
    {
        public int cardID = 0;
        public string name = string.Empty;

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                Student s = obj as Student;
                return this.cardID - s.cardID;
            }
            return 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                Student s = obj as Student;
                return this.cardID - s.cardID == 0;
            }
            return false;
        }
    }
}
