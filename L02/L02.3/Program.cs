using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02._3
{
    class Program
    {
        private static Shape CreateShape(ShapeType shapeType)
        {
            double[] db = ReadDimension(shapeType);

            if(shapeType == ShapeType.Circle)
            {
                return new Ellipse(db[0]);
            }
            else if (shapeType == ShapeType.Ellipse)
            {
                return new Ellipse(db[0], db[1]);
            }
            else if (shapeType == ShapeType.Rectangle)
            {
                return new Rectangle(db[0], db[1]);
            }
            else if (shapeType == ShapeType.Cuboid)
            {
                return new Cuboid(db[0], db[1], db[2]);
            } 
            else if (shapeType == ShapeType.Sphere)
            {
                return new Sphere(db[0]);
            }
            else if (shapeType == ShapeType.Cylinder)
            {
                return new Cylinder(db[0], db[1], db[2]);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        static void Main(string[] args)
        {
            int index;
            do
            {
                ViewMenu();
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 8)
                {
                    switch (index)
                    {
                        case 0:
                            {
                                return;
                            }
                        case 1:
                            {
                                Shape myShape = CreateShape(ShapeType.Rectangle);
                                ViewShapeDetail(myShape);
                                break;
                            }
                        case 2:
                            {
                                Shape myShape = CreateShape(ShapeType.Circle);
                                ViewShapeDetail(myShape);
                                break;
                            }
                        case 3:
                            {
                                Shape myShape = CreateShape(ShapeType.Ellipse);
                                ViewShapeDetail(myShape);
                                break;
                            }
                        case 4:
                            {
                                Shape myShape = CreateShape(ShapeType.Cuboid);
                                ViewShapeDetail(myShape);
                                break;
                            }
                        case 5:
                            {
                                Shape myShape = CreateShape(ShapeType.Cylinder);
                                ViewShapeDetail(myShape);
                                break;
                            }
                        case 6:
                            {
                                Shape myShape = CreateShape(ShapeType.Sphere);
                                ViewShapeDetail(myShape);
                                break;
                            }
                        case 7:
                            {
                                ViewShapes(Randomize2DShapes());
                                break;
                            }
                        case 8:
                            {
                                ViewShapes(Randomize3DShapes());
                                break;
                            }
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("FEL! Ange ett tal mellan 0 och 8");
                    Console.WriteLine();
                    Console.ResetColor();
                }

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("   Tryck tangent för att fortsätta   ");
                Console.ResetColor();
                Console.CursorVisible = false;
                Console.ReadKey();
                Console.CursorVisible = true;
                Console.Clear();
            }
            while (true);
        }
        private static Shape2D[] Randomize2DShapes()
        {
            Random myRandom = new Random();
            int numberOfShapes = myRandom.Next(5, 21);

            Shape2D[] shape2D = new Shape2D[numberOfShapes];
            ShapeType shapeType;

            for(int i = 0; i < numberOfShapes; i++)
            {
                int randomNumber = myRandom.Next(3);

                if (randomNumber == 0)
                {
                    shapeType = ShapeType.Ellipse;
                }
                else if (randomNumber == 1)
                {
                    shapeType = ShapeType.Circle;
                }
                else if (randomNumber == 2)
                {
                    shapeType = ShapeType.Rectangle;
                }
                else
                {
                    throw new ArgumentException();
                }

                double firstDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                double secondDimension = myRandom.Next(5, 100) + myRandom.NextDouble();

                switch(shapeType)
                {
                    case ShapeType.Circle:
                    {
                        shape2D[i] = new Ellipse(firstDimension);
                        break;
                    }
                    case ShapeType.Ellipse:
                    {
                        shape2D[i] = new Ellipse(firstDimension, secondDimension);
                        break;
                    }
                    case ShapeType.Rectangle:
                    {
                        shape2D[i] = new Rectangle(firstDimension, secondDimension);
                        break;
                    }
                }
            }
            
            for (int i = 0; i < shape2D.Length; i++)
            {
                for (int j = 0; j < shape2D.Length; j++)
                {
                    int number = shape2D[i].CompareTo(shape2D[j]);
                    if (number == -1)
                    {
                        Shape2D temp = shape2D[i];
                        shape2D[i] = shape2D[j];
                        shape2D[j] = temp;
                    }
                }
            }
            return shape2D;
        }
        private static Shape3D[] Randomize3DShapes()
        {
            Random myRandom = new Random();
            int numberOfShapes = myRandom.Next(5, 21);

            Shape3D[] shape3D = new Shape3D[numberOfShapes];
            ShapeType shapeType;

            for (int i = 0; i < numberOfShapes; i++)
            {
                int randomNumber = myRandom.Next(3,6);

                if(randomNumber == 3)
                {
                    shapeType = ShapeType.Cuboid;
                }
                else if(randomNumber == 4)
                {
                    shapeType = ShapeType.Cylinder;
                }
                else if (randomNumber == 5)
                {
                    shapeType = ShapeType.Sphere;
                }
                else
                {
                    throw new ArgumentException();
                }

                double firstDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                double SecondDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                double thirdDimension = myRandom.Next(5, 100) + myRandom.NextDouble();

                switch (shapeType)
                {
                    case ShapeType.Cuboid:
                    {
                        shape3D[i] = new Cuboid(firstDimension, SecondDimension, thirdDimension);
                        break;
                    }
                    case ShapeType.Cylinder:
                    {
                        shape3D[i] = new Cylinder(firstDimension, SecondDimension, thirdDimension);
                        break;
                    }
                    case ShapeType.Sphere:
                    {
                        shape3D[i] = new Sphere(firstDimension);
                        break;
                    }
                }
            }

            for (int i = 0; i < shape3D.Length; i++ )
            {
                for(int j = 0; j < shape3D.Length; j++)
                {
                    int number = shape3D[i].CompareTo(shape3D[j]);
                    if(number == -1)
                    {
                        Shape3D temp = shape3D[i];
                        shape3D[i] = shape3D[j];
                        shape3D[j] = temp;
                    }
                }
            }

            return shape3D;
        }
        private static double[] ReadDimension(ShapeType shapeType)
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=======================================");
            Console.WriteLine(Extensions.CenterAlignString(Extensions.AsText(shapeType), "=                                     ="));
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.WriteLine();

            switch(shapeType)
            {
                case ShapeType.Circle:
                    return ReadDoublesGreaterThanZero("Skriv in diametern: ", 1);

                case ShapeType.Cuboid:
                    return ReadDoublesGreaterThanZero("Skriv in längd, bredd och höjd: ", 3);

                case ShapeType.Sphere:
                    return ReadDoublesGreaterThanZero("Skriv in radius: ", 1);

                case ShapeType.Cylinder:
                    return ReadDoublesGreaterThanZero("Skriv in längddiamtern, breddiametern och höjd: ", 3);

                case ShapeType.Rectangle:
                    return ReadDoublesGreaterThanZero("Skriv in längd och bredd: ", 2);

                case ShapeType.Ellipse:
                    return ReadDoublesGreaterThanZero("Skriv in längddiameter och breddiameter: ", 2);

                default:
                    throw new ArgumentException();
            }
        }
        private static double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues = 1)
        {
            double[] db = new double[numberOfValues];
            double doubleOut = 0;
            do
            {
                Console.Write(prompt);
                string[] str = Console.ReadLine().Split(' ');
                Console.WriteLine();

                if(str.Length != numberOfValues)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Ett fel inträffade när figuerens dimensioner skulle tolkas.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    for (int i = 0; i < numberOfValues; i++)
                    {
                        if (double.TryParse(str[i], out doubleOut) && doubleOut>0)
                        {
                            db[i] = doubleOut;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("FEL! Ett fel inträffade när figuerens dimensioner skulle tolkas.");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }
                    }
                }
            } while (db.Last() == 0);
            return db;
        }
        private static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("================================");
            Console.WriteLine("=                              =");
            Console.WriteLine("=           Figurer            =");
            Console.WriteLine("=                              =");
            Console.WriteLine("================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("0. Avsluta.");
            Console.WriteLine("1. Rektangel.");
            Console.WriteLine("2. Cirkel.");
            Console.WriteLine("3. Ellips.");
            Console.WriteLine("4. Rätblock.");
            Console.WriteLine("5. Cylinder.");
            Console.WriteLine("6. Sfär.");
            Console.WriteLine("7. Slumpa 2D-figurer.");
            Console.WriteLine("8. Slumpa 3D-figurer.");
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.Write("Ange menyval [0-8]: ");
        }
        private static void ViewShapeDetail(Shape shape)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=======================================");
            Console.WriteLine("=                 Detaljer            =");
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(shape.ToString());
        }
        private static void ViewShapes(Shape[] shapes)
        {
            if(!shapes[0].IsShape3D)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Figur       Längd   Bredd Omkrets    Area");
                Console.WriteLine("-----------------------------------------");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (shapes[0].IsShape3D)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Figur       Längd  Bredd   Höjd   Mantelarea  Bergäns.area       Volym");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.ResetColor();
                Console.WriteLine();
            }
            for(int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("{0}    ",shapes[i].ToString("R"));
            }
            Console.WriteLine();
        }
    }
}
