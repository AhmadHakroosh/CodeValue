using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public interface IPersist
    {
        void Write(StringBuilder sb);
    }

    public abstract class Shape : IComparable<Shape>
    {
        public ConsoleColor Color { get; set; }

        public abstract double Area { get; }

        public Shape(ConsoleColor color)
        {
            Color = color;
        }

        public Shape()
        {
            Color = ConsoleColor.White;
        }

        public virtual void Display()
        {
            Console.BackgroundColor = Color;
        }

        public abstract int CompareTo(Shape other);
    }

    public class Rectangle : Shape, IPersist
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area => Math.Round(Width*Height, 2, MidpointRounding.AwayFromZero);

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override void Display()
        {
            Console.WriteLine($"This is a Rectangle which its width is {Width} and its height is: {Height}.");
        }
        
        void IPersist.Write(StringBuilder sb)
        {
            sb.AppendLine($"Width: {this.Width}, Height: {this.Height}");
        }

        public override int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }
    }

    public class Ellipse : Shape, IPersist
    {
        public double ShortRadius { get; set; }
        public double LongRadius { get; set; }

        public override double Area => Math.Round(Math.PI*ShortRadius*LongRadius, 2, MidpointRounding.AwayFromZero);

        public Ellipse(double sRadius, double lRadius)
        {
            ShortRadius = sRadius;
            LongRadius = lRadius;
        }

        public override void Display()
        {
            Console.WriteLine($"This is an Ellipse where its Short Radius is {ShortRadius} and its Long Radius is {LongRadius}.");
        }
        
        void IPersist.Write(StringBuilder sb)
        {
            sb.AppendLine($"Short Radius: {this.ShortRadius}, Long Radius: {this.LongRadius}");
        }
        
        public override int CompareTo(Shape other)
        {
            return Area.CompareTo(other.Area);
        }
    }

    public class Circle : Shape, IPersist
    {
        public double Radius { get; set; }

        public override double Area => Math.Round(Math.PI*Radius*Radius, 2, MidpointRounding.AwayFromZero);

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override void Display()
        {
            Console.WriteLine($"This is a Circle which its radius is {Radius}.");
        }

        void IPersist.Write(StringBuilder sb)
        {

        }

        public override int CompareTo(Shape other)
        {
            throw new NotImplementedException();
        }
    }
}
