using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius;

        public Circle()
            :base()
        {
        }

        public Circle(double radius)
            :base()
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (Validator.IsPositiveNumber(value,"Radius must be a positive number"))
                {
                    this.radius = value;
                }
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
