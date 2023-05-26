using System;
using System.Collections.Generic;

namespace T1SimpleFigures_Mubasshera
{
    public enum Direction
    {
        Left, 
        Right, 
        Up, 
        Down
    }

    public enum Rotation
    {
        Clockwise, 
        AntiClockwise
    }

    public abstract class Figure 
    {
        protected Direction dir { set; get; }
        protected Rotation rot;
        public virtual void SayName()
        {
            Console.WriteLine("I am a simple Figure ");
        }
        public virtual void Move(Direction d)
        {
            dir=d;
        }

        public virtual void Rotate(Rotation r)
        {
            rot=r;
        }
        public virtual void Display() { }
    }

    public class Point : Figure
    {
        public override void Display()
        {
            Console.WriteLine("I am a Point. Moving "+ dir+ " And rotating "+ rot);  
        }
    }

    public class Circle : Figure
    {
        public override void Display()
        {
            Console.WriteLine("I am a Circle. Moving " + dir + " And rotating " + rot);
        }
    }


    public class Line : Figure 
    {
        public override void Display()
        {
            Console.WriteLine("I am a Line. Moving " + dir + " And rotating " + rot);
        }
    }

    public class Aggregate
    {
        public Direction Dir { set; get; }
        public Rotation Rot { set; get; }

        private List<Figure> figures;
        public int No_circles { set;  get; }
        public int No_points { set; get; }
        public int No_lines { set; get; }

        public Aggregate(List<Figure> F, Direction D, Rotation R, int no_c=0, int no_p=0, int no_l=0)
        {
            No_circles = no_c;
            No_points = no_p;
            No_lines = no_l;

            figures = F;

            AddFigures(new Circle(), no_c);
            AddFigures(new Point(), no_p);
            AddFigures(new Line(), no_l);

            Dir = D;
            Rot = R;
        }

        public void AddFigures(Figure f, int quantity)
        { 
            if(quantity>0)
            {
                for (int i = 0; i < quantity; i++)
                {
                    figures.Add((Figure)Activator.CreateInstance(f.GetType()));
                }
            }
            
        }

        public void MoveAll()
        {
            foreach (Figure f in figures)
            {
                f.Move(Dir);
            }
        }

        public void RotateAll()
        {
            foreach (Figure f in figures)
            {
                f.Rotate(Rot);
            }
        }

        public void DisplayAll()
        {
            foreach (Figure f in figures)
            {
                f.Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure> ();

            //Getting random no. number of Figures 
            Console.WriteLine("Enter the number of circles: ");
            int No_circles = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of points: ");
            int No_points = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of lines: ");
            int No_lines = Convert.ToInt32(Console.ReadLine());

            //Getting directions for Move and Rotation
            Console.WriteLine("Enter the direction (Left, Right, Up, Down): ");
            string directionInput = Console.ReadLine();

            Direction direction=Direction.Left;//default
            if (Enum.TryParse(directionInput, true, out Direction result))
            {
                direction = result;
                Console.WriteLine("Direction: " + direction + "\n");
            }
            else
            {
                Console.WriteLine("Invalid direction input!");
            }

            Console.WriteLine("Enter the rotation (Clockwise, AntiClockwise): ");
            string rotationInput = Console.ReadLine();

            Rotation rotation=Rotation.Clockwise;//default
            if (Enum.TryParse(rotationInput, true, out Rotation rotResult))
            {
                rotation = rotResult;
                Console.WriteLine("Rotation: " + rotation + "\n");
            }
            else
            {
                Console.WriteLine("Invalid rotation input!");
            }


            Aggregate aggregate = new Aggregate(figures, direction, rotation, No_circles, No_points, No_lines);
            aggregate.MoveAll();
            aggregate.RotateAll();
            aggregate.DisplayAll();
        }
    }
}
