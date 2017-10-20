using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia_2 {
    interface IMovableObject {
        void Move(double x, double y); //public by default
        void FlipUdDwn();

    }
}
