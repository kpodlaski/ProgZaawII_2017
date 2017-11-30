using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarierExample {
    class Horse : IComparable<Horse>{
        public static int Distance { get; set; }
        public static Random rand = new Random();
        private double position = 0.0;
        private Barrier barierStart, barierMeta;
        private double v;
        public int Time { get; set; }
        public int Id;
        private static int lastId=1;
        private Thread t;
        public Semaphore kontrola { get; set; }

        public Horse(Barrier bS, Barrier bM) {
            lock (rand) {
                v = rand.NextDouble();
                Id = lastId++;
            }
            Time = 0;
            barierStart = bS;
            barierMeta = bM;
            t = new Thread(Run);
        }

        public void Start() {
            t.Start();
        }

        public void Run() {
            Time = 0;
            barierStart.SignalAndWait();
            Console.WriteLine("Koń startuje");
            while (position < Distance) {
                position += v;
                Time++;
            }
            Console.WriteLine("Koń na mecie");
            barierMeta.SignalAndWait();
            Console.WriteLine("Czekam na kontrole "+Id);
            kontrola.WaitOne();
            Console.WriteLine("Trwa kontrola " + Id);
            Thread.Sleep(1000);
            kontrola.Release();
            Console.WriteLine("Koń "+Id+" idzie do stajni");
        }

        public int CompareTo(Horse other) {
           return  Time - other.Time;
        }
    }
}
