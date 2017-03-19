namespace MultiThreading
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ParallelExamples
    {
        public void RunForInSync()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(
                    "Hello from RunForInSync #" + i + " in thread " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(800);
            }
        }

        public void RunForInParallel()
        {
            Parallel.For(
                0,
                50,
                new ParallelOptions { MaxDegreeOfParallelism = 3 },
                (i) =>
                    {
                        Console.WriteLine(
                            "Hello from RunForInParallel #" + i + " in thread " + Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(800);
                    });
        }

        public void RunForeachInSync()
        {
            var intArray = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var listOfInts = intArray.ToList();
            foreach (int i in listOfInts)
            {
                Console.WriteLine(
                            "Hello from RunForeachInSync #" + i + " in thread " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(800);
            }
        }

        public void RunForeachInParallel()
        {
            var intArray = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var listOfInts = intArray.ToList();
            Parallel.ForEach(
                listOfInts,
                new ParallelOptions { MaxDegreeOfParallelism = 2 },
                i =>
                    {
                        Console.WriteLine(
                            "Hello from RunForeachInParallel #" + i + " in thread " + Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(800);
                    });
        }

        public void RunParallelInvoke()
        {
            Action action = () =>
                {
                    while (true)
                    {
                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is working very hard....");
                        Thread.Sleep(1000);
                    }
                };

            Parallel.Invoke(action, action);
        }
    }
}
