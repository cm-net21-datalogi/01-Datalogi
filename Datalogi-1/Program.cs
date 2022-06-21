using Datalogi_1;
using System.Diagnostics;


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

//TestStack();

static void TestForEach()
{
    MyStack<string> stack = new MyStack<string>();
    stack.AddLast("apple");
    stack.AddLast("orange");
    stack.AddLast("pear");
    stack.AddLast("grape");
    stack.AddLast("banana");

    stack.ForEach((x) => Console.WriteLine(x));

    string concat = "";
    stack.ForEach((x) => concat += x + ", ");
    Console.WriteLine(concat);
}
//TestForEach();

static void TestStack()
{
    MyStack<object> stack = new MyStack<object>();
    Console.WriteLine("Stacken är tom, length==" + stack.Length());
    stack.AddLast(10);
    Console.WriteLine("Stacken har 1 nod, length==" + stack.Length());

    stack.AddLast(11);
    stack.AddLast(12);
    stack.AddLast(13);
    Console.WriteLine("Stacken har 4 noder, length==" + stack.Length());
    stack.AddLast(14);
    stack.AddLast("15");
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

    Console.WriteLine("Hittade 15 på index == " + stack.IndexOf("15"));
	try
	{
        Console.WriteLine("Hittade 150 på index == " + stack.IndexOf(150));
	}
	catch (Exception)
	{
		Console.WriteLine("150 fanns inte i stacken.");
	}
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

/*
static void TestFind()
{
    OnlyStack<int> stack = new OnlyStack<int>();
    stack.Push(5);
    stack.Push(4);
    stack.Push(2);
    stack.Push(5);
    stack.Push(12);
    stack.Push(50);
	Console.WriteLine("Letar efter värdet 12 i stacken...");
    try
    {
        int? maybe = stack.Find(element => element == 12);
        Console.WriteLine("Hittade " + maybe);

        maybe = stack.Find(element => element == 13);
        Console.WriteLine("Hittade " + maybe);
    }
    catch (Exception e)
    {
        Console.WriteLine("Hittade inget element. Felmeddelande: " + e.Message);
    }
}

TestFind();
*/

static void TestExists()
{
    OnlyStack<int> stack = new OnlyStack<int>();
    Random r = new Random();

    for(int i=0;i<1000; i++)
	{
        stack.Push(r.Next(1, 1001));
	}

	// Kör Exists några gånger utan att ha sorterat
	Console.WriteLine("Utan sortering:");
    for(int i=0; i<12; i++)
	{
        int x = r.Next(1, 1001);
        stack.Exists(num => num == x);
        int count = stack.existsLoopCounter;
		Console.WriteLine("Antal varv i loopen: " + count);
	}
}
TestExists();

static void TestExistsSorted()
{
    const int ARRAY_LENGTH = 1000;
    int[] array = new int[ARRAY_LENGTH];
    Random r = new Random();

    for (int i = 0; i < array.Length; i++)
    {
        array[i] = r.Next(1, ARRAY_LENGTH + 1);
    }

    Array.Sort(array);

    // Kör Exists några gånger efter sortering
    Console.WriteLine("Med sortering:");
    for (int i = 0; i < 12; i++)
    {
        int x = r.Next(1, ARRAY_LENGTH + 1);
        bool result = Sort.ExistsInSorted(array, x);
        int count = Sort.existsInSortedLoopCounter;
        Console.WriteLine("Antal varv i loopen: " + count);
    }
}
TestExistsSorted();

static void TestObjectStackFind()
{
    ObjectStack<Product> stack = new ObjectStack<Product>();
    const int NUM_PRODUCTS = 1000;
    Random r = new Random();

    for (int i = 0; i < NUM_PRODUCTS; i++)
    {
        Product p = new Product();
        p.Id = r.Next(1, NUM_PRODUCTS+1);
        stack.Push(p);
    }

	Console.WriteLine("Söka efter produkt med ett specifikt id - utan att sortera stacken:");
    for(int i=0; i < 12; i++)
	{
        int targetId = r.Next(1, NUM_PRODUCTS + 1);
        stack.Find(p => p.Id == targetId);
        int counter = stack.loopCounter;
		Console.WriteLine("Antal varv i loopen: " + counter);
    }
}
TestObjectStackFind();

static void TestFindInSortedGenericArray()
{
    const int ARRAY_LENGTH = 1000;
    Product[] array = new Product[ARRAY_LENGTH];
    Random r = new Random();

    for (int i = 0; i < array.Length; i++)
    {
        Product p = new Product();
        p.Id = r.Next(1, ARRAY_LENGTH + 1);
        array[i] = p;
    }

    Array.Sort(array);  // går att sortera pga IComparable<Product>

    // Kör Exists några gånger efter sortering
    Console.WriteLine("Med sortering:");
    for (int i = 0; i < 12; i++)
    {
        Product target = new Product();
        target.Id = r.Next(1, ARRAY_LENGTH + 1);
        Product? maybeFound = Sort.FindInSorted<Product>(array, target);
        int count = Sort.existsInSortedLoopCounter;
        Console.WriteLine("Antal varv i loopen: " + count);
    }
}
TestFindInSortedGenericArray();