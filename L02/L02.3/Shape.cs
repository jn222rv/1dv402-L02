using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    abstract class Shape
    {
        public bool IsShape3D
        {
            get
            {
                if (ShapeType == ShapeType.Cuboid || ShapeType == ShapeType.Cylinder || ShapeType == ShapeType.Sphere)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ShapeType ShapeType
        {
            get;
            private set;
        }
        protected Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }
        public abstract string ToString(string format);
    }

    public enum ShapeType
    {
        Rectangle,
        Circle,
        Ellipse,
        Cuboid,
        Cylinder,
        Sphere
    }
}
