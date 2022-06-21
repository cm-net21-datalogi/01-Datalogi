public class Product: IComparable<Product>
{
    public int Id { get; set; }

	// riktiga produkter innehåller många fler egenskaper
	// vi behöver bara produkt-id för att testa find-funktionen


	public int CompareTo(Product other)
	{
		if (Id < other.Id)
			return -1;
		else if (Id > other.Id)
			return 1;
		else
			return 0;
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
}