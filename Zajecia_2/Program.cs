using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia_2 {
    class Program {
        static void Main(string[] args) {
            Figure f = new Square(3.5,7,12);
            f.draw();
            IMovableObject mO = (IMovableObject)f;
            mO.FlipUdDwn();
            ((IMovableObject)f).Move(1, 17);
            Figure[] tab = new Figure[5];
            Random r = new Random();
            for (int i=0; i<tab.Length; i++) {
                tab[i] = new Square(r.NextDouble() * 10 - 5,//x
                    r.NextDouble() * 10 - 5,//y
                    r.NextDouble() * 10);//a
            } 
            tab[2].draw();
            Console.WriteLine("Pola Figur ");
            for (int i = 0; i < tab.Length; i++) {
                Console.WriteLine(i + " : " + tab[i].area()+  " : "
                    +tab[i].perimeter());
            }
            Array.Sort(tab, new PerimeterSquareComparer());
            Console.WriteLine("Pola Figur Po sortowaniu");
            for (int i = 0; i < tab.Length; i++) {
                Console.WriteLine(i + " : " + tab[i].area() + " : "
                    + tab[i].perimeter());
            }

            Console.ReadKey();

        }
    }
}
