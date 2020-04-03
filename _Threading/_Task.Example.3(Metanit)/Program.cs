using System;
using System.Threading.Tasks;

namespace _Task.Example._3_Metanit_
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task1 = new Task<int>(() => Factorial(5));
            task1.Start();

            Console.WriteLine($"Fatorial of number 5 is {task1.Result}");

            Task<Book> task2 = new Task<Book>(() =>
            {
                return new Book { Title = "World and war", Author = "Lev  Tolstoy" };
            });
            task2.Start();

            Book b = task2.Result;  // ожидаем получение результата
            Console.WriteLine($"Book namespase: {b.Title}, autor: {b.Author}");

            Console.ReadLine();
        }


        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
