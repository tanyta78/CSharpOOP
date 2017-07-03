using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTool
{
    class Program
    {
        static void Main()
        {
            var figure = Console.ReadLine();

            switch (figure)
            {
                case "Square":
                    var sizes = int.Parse(Console.ReadLine());
                    var square = new Square(sizes);
                    square.Draw();
                    break;

                case "Rectangle":
                    var width = int.Parse(Console.ReadLine());
                    var height = int.Parse(Console.ReadLine());

                    var rectangle = new Rectangle(width, height);
                    rectangle.Draw();
                    break;
            }
        }
    }
}
