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

    public class Figure 
    {
        public virtual void SayName()
        {
            Console.WriteLine("I am a Figure \n");
        }
        public virtual void Move(Direction d)
        {
            Console.WriteLine("Moving " + d + "\n");
        }

        public virtual void Rotate(Rotation r)
        {
            Console.WriteLine("Rotating " + r + "\n"); 
        }
    }

    public class Point : Figure
    {

        public override void SayName()
        {
            Console.WriteLine("I am a Point. ");
        }
    }

    public class Circle : Figure
    {
        public override void SayName()
        {
            Console.WriteLine("I am a Circle. ");
        }
    }


    public class Line : Figure 
    {
        public override void SayName()
        {
            Console.WriteLine("I am a Line. ");
        }
    }

    public class Aggregate
    {
        //private List<Figure> FiguresList { get; set; }

        //private Figure[] FigureArray;
        public Figure Figure { set; get; }
        public Direction Dir { set; get; }
        public Rotation Rot { set; get; }
        public int No_figs { set;  get; }
        public int Fig_Quantity { set; get; }
        
        public Aggregate (Figure F, Direction D, Rotation R)
        {
            Figure = F;
            Dir = D;
            Rot = R;
            Figure.SayName();
        }

        public void Move ()
        {
            Figure.Move(Dir);
        }

        public void Rotate ()
        {
            Figure.Rotate(Rot); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Figure circle = new Circle();
            Aggregate aggregate = new Aggregate(circle, Direction.Left, Rotation.Clockwise);
            aggregate.Move();
            aggregate.Rotate();
        }
    }
}
