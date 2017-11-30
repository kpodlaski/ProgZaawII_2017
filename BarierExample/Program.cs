using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarierExample {
    class Program {
        static void Main(string[] args) {
            Horse.Distance = 10000;
            List<Horse> horse = new List<Horse>();
            Barrier barrierStart = new Barrier(6,
                (b) => {
                    Console.WriteLine("START!!!");                    
                });
            Barrier barrierMeta = new Barrier(6,
                (b) => {
                    Console.WriteLine("Wyniki:");
                    horse.Sort();
                    foreach (Horse h in horse) {
                        Console.WriteLine(h.Id + "\t" + h.Time + "[s]");
                    }
                    Thread.Sleep(1000);
                });
            Semaphore kontrola = new Semaphore(2,2);
            for (int i=0; i<5; i++) {
                horse.Add(new Horse(barrierStart,barrierMeta));
            }
            for (int i = 0; i < horse.Count; i++) {
                horse[i].kontrola = kontrola;
                horse[i].Start();
            }
            barrierStart.SignalAndWait();
            barrierMeta.SignalAndWait();
            Console.WriteLine("Koniec Części z Barierą");
            Console.WriteLine("Kontrola Antydopingowa");
            Console.ReadKey();
        }
    }
}
