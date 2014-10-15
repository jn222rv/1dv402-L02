using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    class Rectangle : Shape2D
    {
        public override double Area
        {
            get
            {
                return Length*Width;
            }
        }
        public override double Perimeter
        {
            get
            {
                return 2*Length+2*Width;
            }
        }
        public Rectangle(double length, double width) : base(ShapeType.Rectangle, length, width)
        {

        }
    }
}
