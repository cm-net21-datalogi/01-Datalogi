// See https://aka.ms/new-console-template for more information
using Datalogi_1;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

/*for (int i = 0; i < 5; i++)
{
    Övning1a();
}
for (int i = 0; i < 5; i++)
{
    Övning1b();
}*/
/*for(int i=0; i < 5; i++)
{
    Övning3();
}*/

TestStack();

static void TestStack()
{
    MyStack<int> stack = new MyStack<int>();
    Console.WriteLine("Stacken är tom, length==" + stack.Length());
    stack.AddLast(10);
    Console.WriteLine("Stacken har 1 nod, length==" + stack.Length());

    stack.AddLast(11);
    stack.AddLast(12);
    stack.AddLast(13);
    Console.WriteLine("Stacken har 4 noder, length==" + stack.Length());
    stack.AddLast(14);
    stack.AddLast(15);
    stack.AddLast(16);
    Console.WriteLine("Stacken har 7 noder, length==" + stack.Length());

    stack.RemoveAt(2);  // ta bort 12
    stack.RemoveFirst();  // ta bort 10
    stack.RemoveLast();  // ta bort 16
    Console.WriteLine("Stacken har 4 noder, length==" + stack.Length());

    stack.Print();

    Console.WriteLine("stack.getAt(1) == " + stack.GetAt(1));
    stack.SetAt(1, 110);
    Console.WriteLine("stack.getAt(1) == " + stack.GetAt(1));

    Console.WriteLine("Och nu baklänges!");
    stack.PrintReverse();
}





static void TestLinkedList()
{
    MyLinkedList<string> lista = new MyLinkedList<string>();
    lista.Push("äpple");
    lista.Push("päron");
    lista.Push("banan");
    lista.Reset();
    Console.WriteLine(lista.Current.Data);
    lista.Next();
    Console.WriteLine(lista.Current.Data);
    lista.Next();
    Console.WriteLine(lista.Current.Data);
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

static void Övning2() {
    const int count = 180000000;
    Stopwatch timer = Stopwatch.StartNew();
    List<double> list = new();
    Random random = new Random();
    for (int i = 0; i < count; i++)
    {
        list.Add(random.NextDouble() * 100 + 100);
    }
    timer.Stop();
    Console.WriteLine("2a Elapsed time: " + timer.ElapsedMilliseconds);

    timer = Stopwatch.StartNew();
    double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += list[i];
    }
    timer.Stop();
    Console.WriteLine("2b Elapsed time: " + timer.ElapsedMilliseconds);
}
static void Övning3(int count=72000)
{
    Stopwatch timer = Stopwatch.StartNew();
    MyLinkedList<double> list = new();
    Random random = new Random();
    for (int i = 0; i < count; i++)
    {
        list.Push(random.NextDouble() * 100 + 100);
    }
    timer.Stop();
    Console.WriteLine("3a Elapsed time: " + timer.ElapsedMilliseconds);

    timer = Stopwatch.StartNew();
    double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += list.Get(i);
    }
    timer.Stop();
    Console.WriteLine("3b Elapsed time: " + timer.ElapsedMilliseconds);
}