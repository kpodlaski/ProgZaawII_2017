using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszaApp {
    class Program {
        
        static void Main(string[] args) {
            Console.WriteLine("Hello C#");
            Program p = new Program();
            p.Name = "Nazwa";
            p.Number = 13;
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Number);
            Console.WriteLine(p);
            Console.WriteLine(p.ToString());
            Console.WriteLine(p.Name+" :"+p.Number+p);
            Point p1 = new Point(1, 12);
            Point p2 = new Point(1.1, 12.3);
            Point p3 = new Point(1, 12);
            Point p4 = p1;
            if (p1 == p3)
                Console.WriteLine("Równe");
            else
                Console.WriteLine("Inne");

            if (p1.Equals(p3))
                Console.WriteLine("Równe_2");
            else
                Console.WriteLine("Inne_2");
            Console.ReadKey();
        }
        public string Name;
        public int Number;
        public override string ToString() {
            return this.Name;
        }
    }
}
