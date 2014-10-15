using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    abstract class Shape3D : Shape
    {
        protected Shape2D _baseShape;
        private double _height;

        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if(value > 0)
                {
                    _height = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public abstract double MantelArea
        {
            get;
        }
        public abstract double TotalSurfaceArea
        {
            get;
        }
        public abstract double Volume
        {
            get;
        }
        public int CompareTo(object obj)
        {
            return 3;
        }
        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height) : base(shapeType)
        {
            Height = height;
            _baseShape = baseShape;
        }
        public override string ToString(string format)
        {
            if (format == "G" || format == "" || format == null)
            {
                return "meme";
                //return String.Format("Längd  : {0,10:f1}\nBredd  : {1,10:f1}\nOmkrets: {2,10:f1}\nArea   : {3,10:f1}\n", _baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurfaceArea, Volume);
            }
            else if (format == "R")
            {
                return String.Format("{0,-10}{1,7:f1}{2,7:f1}{3,7:f1}{4,13:f1}{5,14:f1}{6,12:f1}", ShapeType, _baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurfaceArea, Volume);
            }
            else
            {
                throw new FormatException();
            }
        }
        public override string ToString()
        {
            return String.Format("Längd: {0:f1}\nBredd: {1:f1}\nHöjd: {2:f1}\nMantelArea: {3:f1}\nBegränsningarea: {4:f1}\nVolym: {5:f1}\n", _baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurfaceArea, Volume);
        }
    }
}
