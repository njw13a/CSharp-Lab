using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    enum Color { BLACK, RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN, WHITE };

    abstract class Shape
    {
        private Color hue;

        protected Shape( Shape a) { return; }
        /*protected string getColor( int a)
        {
            if (a == 0)
                return "BLACK";
            if (a == 1)
                return "RED";
            if (a == 2)
                return "GREEN";
            if (a == 3)
                return "YELLOW";
            if (a == 4)
                return "BLUE";
            if (a == 5)
                return "MAGENTA";
            if (a == 6)
                return "CYAN";
            if (a == 7)
                return "WHITE";
            else
                return "0";
        }*/
        protected class Position
        {
            public double x;
            public double y;
        }

        public Shape(Color a) { hue = a; }

        public void color(Color a) { hue = a; }     //Color setter
        public Color color() { return hue; }        //Color getter

        public abstract double area();
        public abstract double perimeter();
        public abstract void move(double a, double b);
        public abstract void render();
        public double thickness() { return area() / perimeter(); }
    }

    class Box : Shape
    {
        Position height;
        Position width;

        public Box(Color a, double l, double t, double r, double b) : base(a) { width.x = l; height.x = t; width.y = r; height.y = b; }
        public override double perimeter() { return ((height.x - height.y) * 2 + (width.y - width.x) * 2); }
        public override double area() { return ((height.x - height.y) * (width.y - width.x)); }

        public override void move(double a, double b)
        {
            height.x += b;
            height.y += b;
            width.x += a;
            width.y += a;
        }
        public override void render()
        {
            Console.WriteLine( "Box(" + color() + "," + width.x + "," + height.x + "," + width.y + "," + height.y + ")");
        }

        public void left( double a) {width.x = a;}      //Corner Settter
        public void right( double a) { width.y = a; }
        public void top( double a) { height.x = a; }
        public void bottom( double a) { height.y = a; }

        public double left() {return width.x;}          //Corner Getter
        public double right() {return width.y;}
        public double top() {return height.x;}
        public double bottom() {return height.y;}
    }

    class Circle : Shape
    {
        double radius_r;
        Position center;

        public Circle(Color a, double x, double y, double r) : base(a) { center.x = x; center.y = y; radius_r = r; }
        public override double perimeter() { return (2 * radius_r * Math.PI); }
        public override double area() { return (Math.PI * (radius_r * radius_r)); }

        public override void move(double a, double b)
        {
            center.x += a;
            center.y += b;
        }
        public override void render()
        {
            Console.WriteLine("Circle(" + color() + "," + center.x + "," + center.y + "," + radius_r + ")");
        }

        void centerX( double a) {center.x=a;}       //Center Setter
        void centerY( double a) { center.y = a; }   //Center Setter
        void radius( double a) { radius_r = a; }    //Radius Setter
        double centerX()  {return center.x;}        //Center Getter
        double centerY()  {return center.y;}        //Center Setter
        double radius()  {return radius_r;}         //Radius Getter
    }

    class Triangle : Shape
    {
        Position corner_1;
        Position corner_2;
        Position corner_3;

        public Triangle(Color a, double x1, double y1, double x2, double y2, double x3, double y3) : base(a) { corner_1.x = x1; corner_1.y = y1; corner_2.x = x2; corner_2.y = y2; corner_3.x = x3; corner_3.y = y3; }
        public override double perimeter() { return ((Math.Sqrt(Math.Pow((corner_1.x - corner_2.x), 2) + Math.Pow((corner_1.y - corner_2.y), 2))) + (Math.Sqrt(Math.Pow((corner_2.x - corner_3.x), 2) + Math.Pow((corner_2.y - corner_3.y), 2))) + (Math.Sqrt(Math.Pow((corner_3.x - corner_1.x), 2) + Math.Pow((corner_3.y - corner_1.y), 2)))); }
        public override double area() { return (Math.Abs((corner_1.x * (corner_2.y - corner_3.y) + corner_2.x * (corner_3.y - corner_1.y) + corner_3.x * (corner_1.y - corner_2.y)) / 2)); }

        public override void move(double a, double b)
        {
            corner_1.x += a;
            corner_2.x += a;
            corner_3.x += a;
            corner_1.y += b;
            corner_2.y += b;
            corner_3.y += b;
        }
        public override void render()
        {
            Console.WriteLine("Triangle(" + color() + "," + corner_1.x + "," + corner_1.y + "," + corner_2.x + "," + corner_2.y + corner_3.x + corner_3.y + ")");
        }

        void cornerX1( double a) {corner_1.x=a;} //Corner Setter
        void cornerX2( double a) { corner_2.x = a; }
        void cornerX3( double a) { corner_3.x = a; }
        void cornerY1( double a) { corner_1.y = a; }
        void cornerY2( double a) { corner_2.y = a; }
        void cornerY3( double a) { corner_3.y = a; }

        double cornerX1()  {return corner_1.x;}  //Corner Getter
        double cornerX2()  {return corner_2.x;}
        double cornerX3()  {return corner_3.x;}
        double cornerY1()  {return corner_1.y;}
        double cornerY2()  {return corner_2.y;}
        double cornerY3()  {return corner_3.y;}
    }

    class Polygon : Shape
    {
        int pointies;
        double[] hold;

        public Polygon( Color a, double[] array, int p) : base(a)
        {
            pointies = p;
            hold = new double[p * 2];
            for (int n = 0; n < p * 2; n++)
            {
                hold[n] = array[n];
            }
        }

        public override double perimeter()
        {
            double sum = 0;
            int n = 0;
            for (; n < pointies * 2 - 2; n += 2)
            {
                sum += (Math.Sqrt(Math.Pow((hold[n] - hold[n + 2]), 2) + Math.Pow((hold[n + 1] - hold[n + 3]), 2)));
            }
            sum += (Math.Sqrt(Math.Pow((hold[n] - hold[0]), 2) + Math.Pow((hold[n + 1] - hold[1]), 2)));
            return sum;
        }
        public override double area()
        {
            double sum = 0;
            int n = 0;
            for (; n < pointies * 2 - 2; n += 2)
            {
                sum += (hold[n] * hold[n + 3]) - (hold[n + 2] * hold[n + 1]);
            }
            sum += (hold[n] * hold[1]) - (hold[n + 1] * hold[0]);
            return sum / 2;
        }

        public override void move(double a, double b)
        {
            for (int n = 0; n < pointies * 2; n += 2)
            {
                hold[n] += a;
            }
            for (int nn = 1; nn < pointies * 2; nn += 2)
            {
                hold[nn] += b;
            }
        }
        public override void render()
        {
            Console.WriteLine("Polygon(" + color() + "," + pointies + ",");
            int n = 0;
            for (; n < pointies * 2 - 1; n++)
            {
                Console.WriteLine(hold[n] + ",");
            }

            Console.WriteLine(hold[n] + ")");
        }

        void points( int a) {pointies = a;}         //Number Point Setter
        int points() {return pointies;}             //Number Point Getter
        double vertexX( int vertex) {return hold[vertex * 2];}          //Point Getter
        double vertexY( int vertex) {return hold[vertex * 2 + 1];}      //Point Getter
        void vertexX( int vertex, double a) {hold[vertex * 2] = a;}     //Point Setter
        void vertexY( int vertex, double a) {hold[vertex * 2 + 1] = a;} //Point Setter
    }

    static class Program
    {
        [STAThread]
        static void Main(string[] args, Enum color)
        {


            double[] pts = { 1, 1, 7, 2, 3, 5, 6, 8, 4, 3 };
            Shape[] list = new Shape[100];
            int count = 0;
            list[count++] = new Box(Color.BLUE, 0, 1, 1, 0);
            list[count++] = new Box(Color.CYAN, 2, 9, 4, 3);
            list[count++] = new Circle(Color.WHITE, 5, 5, 3);
            list[count++] = new Triangle(Color.BLACK, 1, 1, 5, 1, 3, 3);
            list[count++] = new Polygon(Color.GREEN, pts, 5);

            double distance = 0;
            double area = 0;

            for (int i = 0; i < count; i++)
            {
                distance += list[i].perimeter();
                area += list[i].area();
                list[i].render();
            }

            for (int i = 0; i < count; i++)
            {
                list[i].move(10, 10);
                list[i].render();
            }

            Console.WriteLine("distance: " + distance + " area: " + area + "\n");

        }
    }
}
