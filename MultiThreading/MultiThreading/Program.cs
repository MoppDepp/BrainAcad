namespace MultiThreading
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        private static AutoResetEvent event1 = new AutoResetEvent(false);
        private static AutoResetEvent event2 = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            var lockPayload = new WaitCallback(
                state =>
                    {
                        while (true)
                        {
                            var syncMeth = new SyncWithLock();
                            var result = syncMeth.GetData(5);
                            Console.WriteLine($"Accessing data {result} from thread {Thread.CurrentThread.ManagedThreadId}");
                            Thread.Sleep(100);
                        }
                    });

            var monitorPayload = new WaitCallback(
                state =>
                {
                    while (true)
                    {
                        var syncMeth = new SyncWithMonitor();
                        var result = syncMeth.GetData(5);
                        Console.WriteLine($"Accessing data {result} from thread {Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(100);
                    }
                });

            //ThreadPool.QueueUserWorkItem(monitorPayload);
            //ThreadPool.QueueUserWorkItem(monitorPayload);
            //ThreadPool.QueueUserWorkItem(monitorPayload);

            var autoResetPayload = new ThreadStart(
                () =>
                    {
                        string name = Thread.CurrentThread.ManagedThreadId.ToString();

                        Console.WriteLine("{0} waits on AutoResetEvent #1.", name);
                        event1.WaitOne();
                        Console.WriteLine("{0} is released from AutoResetEvent #1.", name);

                        Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
                        event2.WaitOne();
                        Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

                        Console.WriteLine("{0} ends.", name);
                    });

            var t1 = new Thread(autoResetPayload);
            var t2 = new Thread(autoResetPayload);

            //t1.Start();
            //t2.Start();
            //Thread.Sleep(35000);
            //event1.Set();
            //Thread.Sleep(35000);
            //event2.Set();

            var parallel = new ParallelExamples();
            //parallel.RunForInSync();
            //parallel.RunForInParallel();
            //parallel.RunForeachInParallel();
            //parallel.RunParallelInvoke();

            var readStream = new StreamExample();
            //readStream.ReadFromStreamApm();

            Task.Run(
                async () =>
                    {
                        await readStream.ReadFromStreamAsync();
                    });

            Task.Run(
                () =>
                    {
                        while (true)
                        {
                            Console.WriteLine("HELLO FROM OTHER TASK");
                            Thread.Sleep(500);
                        }
                    });

            Console.ReadLine();
        }
    }
}
