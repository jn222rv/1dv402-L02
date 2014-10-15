using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    class Sphere : Shape3D
    {
        public override double MantelArea
        {
            get
            {
                return _baseShape.Area * 4;
            }
        }
        public override double TotalSurfaceArea
        {
            get
            {
                return _baseShape.Area * 4;
            }
        }
        public override double Volume
        {
            get
            {
                return 4 / 3.0 * Math.PI * Math.Pow(_baseShape.Width / 2, 3);
            }
        }
        public Sphere(double radius) : base(ShapeType.Sphere, new Ellipse(radius*2), radius*2)
        {

        }
    }
}
