using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zajecia4 {
    class Program {
        static void Main2(string[] args) {
            Thread[] th = new Thread[100];
            for (int i = 0; i < th.Length; i++) {
                MyTask task = new MyTask { Id = i };
                th[i] = new Thread(task.Do);
            }
            for (int i = 0; i < th.Length; i++) {
                th[i].Start();
                
            }
            Console.WriteLine("Koniec Programu");
            Console.ReadKey();
            Console.WriteLine(MyTask.Value);
            Console.ReadKey();
        }

        static void Main(string[] args) {
            
            Task.Factory.StartNew(() => {
                for(int i=0; i<100; i++) {
                    Console.WriteLine(i);
                }
            });
            Console.WriteLine("Koniec");
            Console.ReadKey();
            UseCount(1200);
            Console.WriteLine("Z Main");
            Console.WriteLine("Z Main");
            Console.ReadKey();

        }

        static async void UseCount(int x) {
            Task<int> t = Task.FromResult<int>(CountSomething(x));
            Console.WriteLine("Licze ... ");
            int res = await t;
            Console.WriteLine("Wynik "+res);
        }

        static int CountSomething(int v) {
            int result =0;
            for (int i=0; i<v; i++) {
                result += v;
                if (i%100==0) Console.WriteLine(i);
            }
            Thread.Sleep(1000);
            return result;
        }
    }
}
