// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

for (int i = 0; i < 5; i++)
{
    Övning1a();
}
for (int i = 0; i < 5; i++)
{
    Övning1b();
}

static void Övning1a()
{
    // starta tidtagning
    Stopwatch timer = Stopwatch.StartNew();

    Random random = new Random();
    double[] array = new double[180000000];
    for(int i = 0; i < array.Length; i++)
    {
        array[i] = random.NextDouble() * 100 + 100;
    }

    // stoppa tidtagning, skriv ut resultatet
    timer.Stop();
    Console.WriteLine("1a Elapsed time: " + timer.ElapsedMilliseconds);
}
static void Övning1b()
{
    // starta tidtagning

    Random random = new Random();
    double[] array = new double[250000000];
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = random.NextDouble() * 100 + 100;
    }

    Stopwatch timer = Stopwatch.StartNew();
    double sum = 0;
    for(int i = 0; i < array.Length; i++)
    {
        sum += array[i];
    }

    // stoppa tidtagning, skriv ut resultatet
    timer.Stop();
    Console.WriteLine("1b Elapsed time: " + timer.ElapsedMilliseconds);
}