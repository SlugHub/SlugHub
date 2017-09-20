using System;
using System.Diagnostics;

namespace SlugFarm.ConsoleAppSample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This sample will create a slug for a piece of text, with 10000 iterations");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            
            Console.Clear();
            
            var slugGenerator = new SlugGenerator();

            var stopwatch = Stopwatch.StartNew();

            for (var i = 1; i <= 10000; i++)
            {
                var slug = slugGenerator.GenerateSlug("Some text that needs slugging " + i);
                Console.WriteLine(slug);
            }

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine("Took " + stopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine("");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
            
            Environment.Exit(0);
        }
    }
}
