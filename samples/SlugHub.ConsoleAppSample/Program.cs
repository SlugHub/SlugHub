using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SlugHub.ConsoleAppSample
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

            var tasks = new List<Task>();

            for (var i = 1; i <= 10000; i++)
            {
                var t = Task.Run(async () =>
                {
                    var slug = await slugGenerator.GenerateSlug("Some text that needs slugging " + i);
                    Console.WriteLine(slug);
                });

                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray(), CancellationToken.None);

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
