using System;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public void SurfaceArea()
        {
            var area = 2 * (this.Length * this.Width + this.Width * this.Height + this.Height * this.Length);
            Console.WriteLine($"Surface Area - {area:f2}");
        }

        public void LateralSurfaceArea()
        {
            var area = 2 * Height * (Length + Width);
            Console.WriteLine($"Lateral Surface Area - {area:f2}");
        }

        public void Volume()
        {
            var area = Height * Length * Width;
            Console.WriteLine($"Volume - {area:f2}");
        }

        public double Length
        {
            get { return length; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }
    }
}