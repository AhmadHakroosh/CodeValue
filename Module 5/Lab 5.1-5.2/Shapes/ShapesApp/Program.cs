using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class ShapeManager
    {
        private ArrayList shapes = new ArrayList();

        public int Count
        {
            get { return shapes.Count; }
        }

        public Shape this[int i]
        {
            get { return (Shape)shapes[i]; }
        }

        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }

        public void DisplayAll()
        {
            int i = 1;
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Shape {i++}:");
                shape.Display();
                Console.Write("Area: ");
                Console.WriteLine(shape.Area);
                Console.WriteLine("");
            }
        }

        public void Save(StringBuilder sb)
        {
            foreach (IPersist shape in shapes)
            {
                shape.Write(sb);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShapeManager shapes = new ShapeManager();
            shapes.Add(new Circle(5));
            shapes.Add(new Rectangle(2.7, 8));
            shapes.Add(new Ellipse(3.5, 10));
            shapes.Add(new Rectangle(5, 7));
            shapes.Add(new Rectangle(17.5, 2));
            shapes.Add(new Ellipse(6, 3.5));
            shapes.Add(new Ellipse(3, 7));

            Rectangle rect = new Rectangle(2.5, 4);
            Console.WriteLine($"{rect.CompareTo(new Rectangle(4, 2.5))}");
            
            Console.WriteLine($"There are {shapes.Count} shapes.");
            shapes.DisplayAll();

            shapes[1].Display();

            StringBuilder sb = new StringBuilder();
            shapes.Save(sb);
            Console.WriteLine($"{sb.ToString()}");

            Console.WriteLine($"{shapes[1].CompareTo(shapes[3])}");
            
            Console.Read();
        }
    }
}
