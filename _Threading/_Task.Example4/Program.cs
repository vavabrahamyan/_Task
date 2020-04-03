using System;
using System.Threading.Tasks;
using System.Threading;

namespace _Task.Example4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => Thread.Sleep(2000));
            Console.WriteLine($"Task(t1)'s status {t1.Status}");

            try
            {
                Console.WriteLine($"Task(t1)'s status {t1.Status}");
                //
                t1.Wait();
                Console.WriteLine($"Task(t1)'s status {t1.Status}");
            }

            catch(AggregateException ex)
            {
                Console.WriteLine($"Task(t1) in Exception {ex.Message}");
            }

            //Console.ReadLine();
        }
    }
}
