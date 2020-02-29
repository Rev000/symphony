using System;
using RevLibrary.Tools;

namespace RevTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager log = new LogManager(null, "_RevLibrary");

            log.WriteLine("[Begin Processing]-------");
            for (int index = 0; index < 10; index++)
            {
                log.WriteLine("Processing: " + index);
                //Do

                System.Threading.Thread.Sleep(500);

                log.WriteLine("Done:" + index);
            }
            log.WriteLine("[End Processing]---------");
        }
    }
}
