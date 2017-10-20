using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia_2 {
    abstract class Figure : IComparable {

        public abstract double area();

        public abstract double perimeter();

        public virtual void draw() {
            Console.WriteLine("Rysuje Figure o polu "
                +area()+" i obwodzie "+perimeter() );
        }

        public abstract int CompareTo(object obj);
    }
}
