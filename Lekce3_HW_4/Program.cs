using Lekce3_HW_4;

List<Pes> psi = new List<Pes>();

bool pp = false;
while (!pp)
{
	Console.WriteLine("1 - Pridat psa");
	Console.WriteLine("2 - Smazat psa");
	Console.WriteLine("3 - Vypsat psa");
	Console.WriteLine("0 - Ukonceni");
	Console.WriteLine();

	Console.WriteLine();
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("Zadej informace o psu.");
	Console.ResetColor();

	int moznost;
	string smoznost = Console.ReadLine();
	while (!int.TryParse(smoznost, out moznost))
	{
		Console.WriteLine("Toto není správně, zadej znovu:");
		smoznost = Console.ReadLine();
	}


	Console.WriteLine();

	switch (moznost)
	{
		case 0:
			pp = true;
			break;
		case 1:
			Pes pes = new Pes();
			Console.Write("Plemeno:");
			pes.Plemeno = Console.ReadLine();
			Console.Write("Pohlavi:");
			pes.Pohlavi = Console.ReadLine();
			Console.Write("Vek:");
			pes.Vek = Console.ReadLine();
			psi.Add(pes);
			break;
		case 2:
			Console.Write("Zadej jmeno:");
			int index = Convert.ToInt32(Console.ReadLine());
			psi.RemoveAt(index);
			break;
		case 3:
			int i = 0;
			foreach (Pes polozka in psi)
			{
				Console.WriteLine($"{i}\t{polozka.Plemeno}\t{polozka.Pohlavi}\t{polozka.Vek}");
				i++;
			}
			break;

	}

}

