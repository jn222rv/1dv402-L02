using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    abstract class Shape2D : Shape
    {
        private double _length;
        private double _width;

        public abstract double Area
        {
            get;
        }
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if(value > 0)
                { 
                    _length = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public abstract double Perimeter
        {
            get;
        }
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if(value > 0)
                {
                    _width = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int CompareTo(object obj)
        {
            return 3;
        }
        protected Shape2D(ShapeType shapeType, double length, double width) : base(shapeType)
        {
            Length = length;
            Width = width;
        }
        public override string ToString(string format)
        {
            if(format == "G"||format==""||format==null)
            {
                return String.Format("Längd  : {0,10:f1}\nBredd  : {1,10:f1}\nOmkrets: {2,10:f1}\nArea   : {3,10:f1}\n", Length, Width, Perimeter, Area);
            }
            else if(format == "R")
            {
                return String.Format("{0,-10}{1,7:f1}{2,7:f1}{3,9:f1}{4,8:f1}", ShapeType, Length, Width, Perimeter, Area);
            }
            else
            {
                throw new FormatException();
            }
        }
        public override string ToString()
        {
            return String.Format("Längd: {0:f1}\nBredd: {1:f1}\nOmkrets: {2:f1}\nArea: {3:f1}\n", Length, Width, Perimeter, Area);
        }

    }
}
