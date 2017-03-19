namespace MultiThreading
{
    using System.Threading;

    public class SyncWithLock
    {
        private static int counter = 0;

        private static object lockObj = new object();

        public int GetData(int someInput)
        {
            lock (lockObj)
            {
                counter += someInput;
                Thread.Sleep(3000);
            }

            //counter += someInput;
            //Thread.Sleep(3000);
            return counter;
        }
    }
}
