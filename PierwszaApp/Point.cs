using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszaApp {
    class Point {
        public double x { get; private set; }
        public double y;
        public double R {
            get {
                return Math.Sqrt(x * x + y * y);
            }

            private set { //Bezsens dla promienia
                R = value;
            }
        }
        public Point(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public double Radius() {
            return Math.Sqrt(x * x + y * y);
        }

        public void Move(Point p) {
            //TODO
           
        }

        public override string ToString() {
            return "["+x+","+y+"]";
        }

        public override bool Equals(object obj) {
            Point o = (Point) obj;
            return x == o.x && y == o.y;
        }
    }
}
