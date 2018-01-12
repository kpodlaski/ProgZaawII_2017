using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PuleWatkow {
    class Parameter {
        public int x,y;
    }
    class Program {
        int zadanieId = 0;
        static void Main(string[] args) {
            int _in, _out;
            ThreadPool.GetMinThreads(out _in, out _out);
            Console.WriteLine(_in+"::"+_out);
            ThreadPool.SetMaxThreads(15, 15);
            for(int i=0; i<15; i++) {
                int v = i;
                Program p = new Program(v);
                ThreadPool.QueueUserWorkItem(p.Zadanie,
                    new Parameter {x=2*v,y=3*v});
            }
            /*Console.ReadKey();
            for (int i = 0; i < 15; i++) {
                int v = i;
                Program p = new Program(v);
                Thread t = new Thread(p.Zadanie);
                t.Start();
            }
            */
            Console.ReadKey();

            Console.Clear();
            BlockingQueue<int>.Test();
            Console.ReadKey();

        }
        public Program(int id) {
            zadanieId = id;
        }
        public void Zadanie(Object O) {
            Parameter o = (Parameter) O;
            Console.WriteLine("Początek zadania: " + zadanieId);
            Console.WriteLine("Parameter "+o.x);
            for (int i=0; i<3; i++) {
                //Console.WriteLine(zadanieId+" "+i);
                Thread.Sleep(500);
            }
            Console.WriteLine("Koniec zadania: "+zadanieId);
            
        }
    }
}
