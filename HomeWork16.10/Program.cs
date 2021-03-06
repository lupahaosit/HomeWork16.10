using System;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork16._10
{
    class Program
    {
        static void Method()
        {
            int secondThread = Thread.CurrentThread.ManagedThreadId;
            var th = Thread.CurrentThread;
            th.Name = "SecondThread";
            Console.WriteLine($"начал работу Thread id = {secondThread}");
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"{i}- ");
                Thread.Sleep(200);
            }
            Console.WriteLine($"{th.Name}, id = {secondThread} закончил работу");
        }
        static void Method2()
        {
            int ThirdThread = Thread.CurrentThread.ManagedThreadId;
            var th = Thread.CurrentThread;
            th.Name = "ThirdThread";
            Console.WriteLine($"начал работу Thread id = {ThirdThread}");
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine($"{i}+ ");
                Thread.Sleep(250);
            }
            Console.WriteLine($"{th.Name}, id = {ThirdThread} закончил работу");
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"основной поток id = {Thread.CurrentThread.ManagedThreadId}");
            var th = Thread.CurrentThread;
            th.Name = "MainThread";
            Task t1 = new Task(Method);
            Task t2 = new Task(Method2);
            t1.Start();
            t2.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}* ");
                Thread.Sleep(500);

            }
            Console.WriteLine($"{th.Name}, id = {Thread.CurrentThread.ManagedThreadId} закончил работу");

            Task.WaitAll(t1, t2);

            Console.WriteLine("работа завершена");
        }
    }
}
