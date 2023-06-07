using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static Interface.GeoFigure;

namespace Interface
{

    //public class Angle
    //{
    //    int angles;
    //    public int GetNumberOfAngle()
    //    {
    //        return angles;
    //    }
    //}

    interface IAngle // интерфейс 1
    {
        //private int angles;   в интерфейсе нет полей ( пемеренных
        public int GetNumberOfAngle();
    }


    interface IPerimetr  // интерфейс 2 
    {
        public float GetNumberOfPerimetr();
    }

    interface IPrintInfo  
    {
        public void PrintInfo();
    }


    public class GeoFigure
    {
        private string name;
        public string Name { get { return name; } }
        public GeoFigure(string _name) 
        {
            name = _name;
        }
        public class Square : GeoFigure, IAngle, IPerimetr, IPrintInfo
        {
            private float side;
            public Square(string _name) : base(_name) { }

            public Square(string _name, float _side) :  base(_name){ }

            public int GetNumberOfAngle()
            {
                return 0;
            }

            public float GetNumberOfPerimetr()
            {
                throw new NotImplementedException();
            }

            public float GetPerimetr()
            {
                return this.GetNumberOfAngle() * side;
            }
            public void PrintInfo()
            {
                string info = $"Сторон {GetNumberOfAngle()} периметр {GetNumberOfPerimetr} имя {name}";
            }
        }
        public class Circle : GeoFigure, IAngle, IPerimetr, IPrintInfo
        {
            private float radius;
            public Circle(string _name) : base(_name) { }

            public Circle(string _name, float _radius) : base(_name) { this.radius = _radius; }

            public int GetNumberOfAngle()
            {
                return 0;
            }

            public float GetNumberOfPerimetr()
            {
                throw new NotImplementedException();
            }

            public float GetPerimetr()
            {
                return (float)(radius * 2 * Math.PI);
            }
            public void PrintInfo()
            {
                string filename = "output.txt";
                string info = $"Сторон {GetNumberOfAngle()} периметр {GetNumberOfPerimetr} имя {name}{DateTime.Now.ToString("D")}";
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    sw.WriteLine();
                }
            }

        }
        
    }
    internal class Program
    {
        static void talkAboutFigure(GeoFigure figure)
        {
            //реализация преобразования типов данных черех AS ( первый вариант )
            var isCircle = figure as Circle;
            if (isCircle != null)
            {
                Console.WriteLine($"{figure.Name} круг");
                ((Circle)figure).PrintInfo();
            }
            else
            {
                if ((figure as Circle) != null)
                {
                    Console.WriteLine($"{figure.Name} квадрат");
                    ((Circle)figure).PrintInfo();
                }
                else
                {
                    Console.WriteLine($"{figure.Name} ни круг ни квадрат");
                }
            }


            // реализация через IF ( второй вариант )
            //if(figure is Circle)
            //{
            //    Console.WriteLine($"{figure.Name} квадрат");
            //    ((Circle)figure).PrintInfo();
            //}
            //else
            //{
            //    Console.WriteLine($"{figure.Name} ни круг, ни квадрат");
            //}


            // реализация через try catch ( третий вариант ) 
            //try
            //{
            //    ((Circle)figure).PrintInfo();
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine($"{figure.Name} не круг");
            //}
            //try
            //{
            //    ((Square)figure).PrintInfo();
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine($"{figure.Name} не квадрат");
            //}

        }
        static void Main(string[] args)
        {
            

            var circle = new Circle("FirstCircle", 20); // объект класса можно создать через var
            var square = new Square("FirstSqure", 20);
            square.PrintInfo();





            Console.ReadLine();
        }
    }
}