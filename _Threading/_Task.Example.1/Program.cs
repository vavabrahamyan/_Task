using System;
using System.Threading;
using System.Threading.Tasks;

namespace _Task.Example._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<Object> action = (Object obj) =>
            {
                Console.WriteLine($"Task = {Task.CurrentId}, obj = {obj}, " +
                    $"Thread = {Thread.CurrentThread.ManagedThreadId}");
            };

            //create task but don't start it
            Task task1 = new Task(action, "Alpha");

            //construct a startid task
            Task task2 = Task.Factory.StartNew(action, "beta");
            //block the main thread to demonstrate that t2 is executing
            task2.Wait();

            //wait for the task to finish
            task1.Wait();

            //construct the strated task using Task.Run
            string taskData = "delta";
            Task task3 = Task.Run(() =>
                {
                    Console.WriteLine($"Task = {Task.CurrentId}, obj = {taskData}, " +
                        $"Thread = {Thread.CurrentThread.ManagedThreadId}");
                }
            );

            //wait for the task to finish
            task3.Wait();

            //construct an unstarted task
            Task task4 = new Task(action, "Gamma");
            //run it synchronously
            task4.RunSynchronously();
            //...
            task4.Wait();
        }
    }
}
