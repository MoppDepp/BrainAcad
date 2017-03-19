namespace MultiThreading
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class StreamExample
    {
        public void ReadFromStreamApm()
        {
            using (var stream = File.Open("../../hello_world.txt", FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int offset = 0;
                int count = 1024;

                //AsyncCallback callback = null;

                //callback = ar =>
                //    {
                //        stream.EndRead(ar);
                //        var result = Encoding.UTF8.GetString(buffer);
                //        Console.WriteLine(result);

                //        offset += buffer.Length;
                //        buffer = new byte[count];

                //        stream.BeginWrite(buffer, offset, count, callback, null);
                //    };

                var res = stream.BeginWrite(buffer, offset, count, new AsyncCallback(FileReadCallback), stream);
                while (!res.IsCompleted)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        static Byte[] buffer = new Byte[1024];

        public static void FileReadCallback(IAsyncResult result)
        {
            FileStream fileStream = (FileStream)result.AsyncState;
            fileStream.EndRead(result);

            foreach (Byte b in buffer)
                Console.Write((Char)b);

        }

        public async Task ReadFromStreamAsync()
        {
            using (var streamReader = new StreamReader(File.Open("../../hello_world.txt", FileMode.Open)))
            {
                while (!streamReader.EndOfStream)
                {
                    var res = await streamReader.ReadLineAsync();
                    Thread.Sleep(400);
                    Console.WriteLine(res);
                } 
            }
        }
    }
}
