Dictionary<char, int> Seznam = new Dictionary<char, int>();

Console.WriteLine("Zadej vetu:");
string veta = Console.ReadLine();


foreach (char znak in veta)
{
	if (Seznam.ContainsKey(znak))
	{
		Seznam[znak] = Seznam[znak] + 1;
	}
	else
	{
		Seznam.Add(znak, 1);
	}
}

foreach (KeyValuePair<char, int> znak in Seznam)
{
	Console.WriteLine($"{znak.Key}\t{znak.Value}\t");
}