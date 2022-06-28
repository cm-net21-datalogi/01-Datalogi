public class Product: IComparable<Product>
{
    public int Id { get; set; }
	public string Name { get; set; }
	public Product() { Id = 0;Name = ""; }
	public Product(int id, string name)
	{
		Id = id;
		Name = name;
	}

	// riktiga produkter innehåller många fler egenskaper
	// vi behöver bara produkt-id för att testa find-funktionen


	public int CompareTo(Product? other)
	{
		// if( product1 < product2 )  <- går inte
		// en sorteringsalgoritm kommer att göra: int result = product1.CompareTo(product2)
		if (other == null)
			return -1;
		else if (Id < other.Id)
			return -1;  // this kommer före other i vår sorteringsordning
		else if (Id > other.Id)
			return 1;  // this kommer efter
		else
			return 0;  // produkterna är lika
	}

	static void Demo()
	{
		Product p1 = new Product();
		p1.Id = 100;

		Product p2 = new Product();
		p2.Id = 250;

		// p1.Id är mindre. Vid stigande ordning ska p1 visas först
		// compareTo ska returnera ett negativt tal (-1)
		int result = p1.CompareTo(p2);  // -1
		result = p2.CompareTo(p1);      // +1
	}
	public static void Demo2()
	{
		Product[] products = new Product[]
		{
			new Product(20, "Gräsklippare"),new Product(10, "Trimmer"),new Product(32, "Vattenspridare"),
			new Product(27, "Vattenpistol")
		};

		for (int j = 0; j < products.Length; j++)
		{
			for (int i = 0; i < products.Length - 1 - j; i++)
			{
				int compareValue = products[i].CompareTo(products[i + 1]);  // products[i] < products[i+1]
				if (compareValue < 0) { /* produkterna är redan i rätt ordning */}
				else if (compareValue == 0) { /* produkterna ska inte byta plats */ }
				else
				{
					Product temp = products[i];
					products[i] = products[i + 1];
					products[i + 1] = temp;
				}
			}
		}
		foreach(var p in products)
		{
			Console.WriteLine($"Produkt: {p.Name} med id {p.Id}.");
		}
	}
}