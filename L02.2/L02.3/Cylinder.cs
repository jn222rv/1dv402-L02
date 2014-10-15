using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    class Cylinder : Shape3D
    {
        public override double MantelArea
        {
            get
            {
                return _baseShape.Perimeter * Height;
            }
        }
        public override double TotalSurfaceArea
        {
            get
            {
                return MantelArea + 2 * _baseShape.Area;
            }
        }
        public override double Volume
        {
            get
            {
                return _baseShape.Area * Height;
            }
        }
        public Cylinder(double hdiameter, double vdiameter, double height) : base(ShapeType.Cylinder, new Ellipse(hdiameter, vdiameter), height)
        {

        }
    }
}
