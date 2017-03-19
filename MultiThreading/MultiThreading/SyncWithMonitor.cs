namespace MultiThreading
{
    using System.Threading;

    public class SyncWithMonitor
    {
        private static int counter = 0;

        private static object lockObj = new object();

        public int GetData(int someInput)
        {
            Monitor.Enter(lockObj);
            Thread.Sleep(3000);
            counter += someInput;
            Monitor.Exit(lockObj);
            return counter;
        }
    }
}
