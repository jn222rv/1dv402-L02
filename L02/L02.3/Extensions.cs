using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    public static class Extensions
    {
        public static string AsText(this ShapeType shapeType)
        {
            if(shapeType == ShapeType.Circle)
            {
                return "Cirkel";
            } 
            else if (shapeType == ShapeType.Ellipse)
            {
                return "Ellips";
            }
            else if (shapeType == ShapeType.Rectangle)
            {
                return "Rektangel";
            }
            else if (shapeType == ShapeType.Sphere)
            {
                return "Sfär";
            }
            else if (shapeType == ShapeType.Cylinder)
            {
                return "Cylinder";
            }
            else if (shapeType == ShapeType.Cuboid)
            {
                return "Rätblock";
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static string CenterAlignString(this string s, string other)
        {
            other = other.Insert(other.Length / 2 - s.Length / 2, s);
            other = other.Remove(other.Length-1-s.Length, s.Length);
            return other;
        }
    }
}
