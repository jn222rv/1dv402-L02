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
                                Shape3D[] shape3D = Randomize3DShapes();
                                ViewShapes(shape3D);
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

                Console.Write("Tryck tangent för att fortsätta");
                Console.ReadKey();
                Console.Clear();
            }
            while (true);
        }
        private static Shape2D[] Randomize2DShapes()
        {
            Random myRandom = new Random();
            int numberOfShapes = myRandom.Next(5, 21);

            Shape2D[] shape2D = new Shape2D[numberOfShapes];

            for(int i = 0; i < numberOfShapes; i++)
            {
                int shapeType = myRandom.Next(3);

                switch(shapeType)
                {
                    case 0:
                    {
                        double dimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                        shape2D[i] = new Ellipse(dimension);
                        break;
                    }
                    case 1:
                    {
                        double firstDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                        double secondDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                        shape2D[i] = new Ellipse(firstDimension, secondDimension);
                        break;
                    }
                    case 2:
                    {
                        double firstDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                        double secondDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                        shape2D[i] = new Rectangle(firstDimension, secondDimension);
                        break;
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

            for (int i = 0; i < numberOfShapes; i++)
            {
                int shapeType = myRandom.Next(3);

                double firstDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                double SecondDimension = myRandom.Next(5, 100) + myRandom.NextDouble();
                double thirdDimension = myRandom.Next(5, 100) + myRandom.NextDouble();

                switch (shapeType)
                {
                    case 0:
                        {
                            shape3D[i] = new Cuboid(firstDimension,SecondDimension, thirdDimension);
                            break;
                        }
                    case 1:
                        {
                            shape3D[i] = new Cylinder(firstDimension, SecondDimension, thirdDimension);
                            break;
                        }
                    case 2:
                        {
                            shape3D[i] = new Sphere(firstDimension/2);
                            break;
                        }
                }
            }
            return shape3D;
        }
        private static double[] ReadDimension(ShapeType shapeType)
        {
            Console.Clear();

            Console.WriteLine("=======================================");
            Console.WriteLine(Extensions.CenterAlignString(Extensions.AsText(shapeType), "=                                     ="));
            Console.WriteLine("=======================================");
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
                    return ReadDoublesGreaterThanZero("Skriv in höjddiamtern, bredddiametern och längd: ", 3);

                case ShapeType.Rectangle:
                    return ReadDoublesGreaterThanZero("Skriv in längd, bredd: ", 2);

                case ShapeType.Ellipse:
                    return ReadDoublesGreaterThanZero("Skriv in höjddiameter, bredddiameter: ", 2);

                default:
                    throw new ArgumentException();
            }
        }
        private static double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues = 1)
        {
            double[] db = new double[numberOfValues];
            double index = 0;
            bool correctDouble = true;
            do
            {
                Console.Write(prompt);
                string str = Console.ReadLine();
                Console.WriteLine();
                string[] str1 = str.Split(' ');

                if(str1.Length != numberOfValues)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Ett fel inträffade när figuerens dimensioner skulle tolkas.");
                    Console.ResetColor();
                    Console.WriteLine();
                    correctDouble = true;
                }
                else
                {
                    for (int i = 0; i < numberOfValues; i++)
                    {
                        if (double.TryParse(str1[i], out index))
                        {
                            db[i] = double.Parse(str1[i]);
                            correctDouble = false;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("FEL! Ett fel inträffade när figuerens dimensioner skulle tolkas.");
                            Console.ResetColor();
                            Console.WriteLine();                    
                            correctDouble = true;
                            break;
                        }
                    }
                }
            } while (correctDouble);
            return db;
        }
        private static void ViewMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("=                              =");
            Console.WriteLine("=           Figurer            =");
            Console.WriteLine("=                              =");
            Console.WriteLine("================================");
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
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.Write("Ange menyval [0-8]: ");
        }
        private static void ViewShapeDetail(Shape shape)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-                 Detaljer              -");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine(shape.ToString());
        }
        private static void ViewShapes(Shape[] shapes)
        {
            if(!shapes[0].IsShape3D)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Figur       Längd   Bredd Omkrets    Area");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
            }
            else if (shapes[0].IsShape3D)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Figur       Längd  Bredd   Höjd   Mantelarea  Bergäns.area       Volym");
                Console.WriteLine("-------------------------------------------------------------------------------");
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
