using System;

namespace LawOfCosines
{

    class Triangle
    {
        public double Side1;
        public double Side2;
        public double Side3;

        public Triangle(double a, double b, double c)
        {
            Side1 = a; Side2 = b; Side3 = c;
        }

        public bool IsValid()
        {
            return (Side1 + Side2 > Side3) &&
                (Side1 + Side3 > Side2) &&
                (Side2 + Side3 > Side1);
        }

        //using Law of Cosines cos(A) = (b^2 + c^2 - a^2) / 2bc
        public double[] Angles()
        {
            double[] angles = new double[3];

            angles[0] = Math.Acos((Math.Pow(Side2, 2) + Math.Pow(Side3, 2) - Math.Pow(Side1, 2)) / (2 * Side2 * Side3)) * (180 / Math.PI);
            angles[1] = Math.Acos((Math.Pow(Side3, 2) + Math.Pow(Side1, 2) - Math.Pow(Side2, 2)) / (2 * Side3 * Side1)) * (180 / Math.PI);
            angles[2] = Math.Acos((Math.Pow(Side1, 2) + Math.Pow(Side2, 2) - Math.Pow(Side3, 2)) / (2 * Side1 * Side2)) * (180 / Math.PI);

            return angles;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            double total = 0.0;

            double a = Convert.ToDouble(args[0]);
            double b = Convert.ToDouble(args[1]);
            double c = Convert.ToDouble(args[2]);

            //side1, side2, side3
            Triangle triangle1 = new Triangle(a, b, c);

            if (triangle1.IsValid())
            {
                foreach (double val in triangle1.Angles())
                {
                    total += val;
                    Console.WriteLine(val);

                }
                Console.WriteLine("\nTotal of angles = " + total);
            }
            else
            {
                Console.WriteLine("Error: side lengths entered do not create a proper triangle");
            }

            

        }
    }
}
