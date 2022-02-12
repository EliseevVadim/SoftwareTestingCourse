using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ProductionCode
{
    public class Triangle
    {
        private double _a;
        private double _b;
        private double _c;

        public Triangle()
        {

        }

        public Triangle(double a, double b, double c)
        {
            SetSides(a, b, c);
        }

        public void SetSides(double a, double b, double c)
        {
            CheckSidesIsCorrect(a, b, c);
            CheckTriangleExistanse(a, b, c);
            _a = a;
            _b = b;
            _c = c;
        }

        public double Area()
        {
            double p = GetHalfOfThePerimeter();
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        private void CheckTriangleExistanse(double a, double b, double c)
        {
            if (a > (b + c) ||
                   b > (c + a) ||
                   c > (a + b))
            {
                throw new ArgumentException();
            }
        }

        private void CheckSidesIsCorrect(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new FormatException();
            }
        }

        private double GetHalfOfThePerimeter()
        {
            return (_a + _b + _c) / 2.0;
        }
    }
}
