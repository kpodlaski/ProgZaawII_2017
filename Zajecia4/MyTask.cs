using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zajecia4 {
    class MyTask {

        public static  volatile int Value = 0 ;
        private static Object monitor = new Object();
        public int Id { get; set; }

        public void Do() {
            
                for (int i =0; i<10000; i++) {
                if (i % 100 == 0) {
                    lock (monitor) {
                        Value = Value + 1;
                    }
                    Console.WriteLine(Id + " " + i);
                }
            }
            Console.WriteLine("Koniec Wątku " + Id);
        }
    }
}
