using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia_2 {
    class Square : Figure, IMovableObject {
        private double a,x,y;
        public Square(double x, double y, double a) {
            this.a = a;
            this.x = x;
            this.y = y;
        }

        public override double area() {
            return a*a;
        }

        public override int CompareTo(object obj) {
            if (!(obj is Figure)) return 0; 
            Figure f = (Figure)obj;
            return Math.Sign(area() - f.area());
        }

        public void FlipUdDwn() {
        }

        public void Move(double x, double y) {
            this.x += x;
            this.y += y;
        }

        public override double perimeter() {
            return 4 * a;
        }
    }

    class PerimeterSquareComparer : IComparer {
        public int Compare(object x, object y) {
            if ((!(x is Figure)) || (!(y is Figure))) return 0;
            Figure f1 = (Figure)x;
            Figure f2 = (Figure)y;
            //f1.perimeter().CompareTo(f2.perimeter());
            return Math.Sign(f1.perimeter() - f2.perimeter());
        }
    }
}
