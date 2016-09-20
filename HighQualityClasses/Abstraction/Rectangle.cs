using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle()
            : base()
        {
        }

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (Validator.IsPositiveNumber(value, "Width must be a positive number!"))
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (Validator.IsPositiveNumber(value, "Height must be a positive number!"))
                {
                    this.height = value;
                }
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
