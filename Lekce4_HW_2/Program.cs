using Lekce4_HW_2;



List<Osoba> osoby = new List<Osoba>();
string cestaS = @"C:\Temp\TP_HW\osoby_kartoteka.txt";
if (!File.Exists(cestaS))
{
	Directory.CreateDirectory(Path.GetDirectoryName(cestaS));
	File.Create(cestaS);
}

bool posledniosoba = false;
while (!posledniosoba)
{
	Console.WriteLine("1 - Pridat osobu");
	Console.WriteLine("2 - Smazat osobu");
	Console.WriteLine("3 - Vypsat osobu");
	Console.WriteLine("4 - Uloženi");
	Console.WriteLine("5 - Vypsani ze souboru");
	Console.WriteLine("0 - Ukonceni");

	Console.WriteLine();
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("Zadej informace o osobe.");
	Console.ResetColor();


	int moznost;
	string smoznost = Console.ReadLine();
	while (!int.TryParse(smoznost, out moznost))
	{
		Console.WriteLine("Toto není správně, zadej znovu:");
		smoznost = Console.ReadLine();
	}

	switch (moznost)
	{
		case 0:
			posledniosoba = true;
			break;
		case 1:
			Osoba osoba = new Osoba();
			Console.Write("Jmeno:");
			osoba.Jmeno = Console.ReadLine();
			Console.Write("Vek:");
			osoba.Vek = Console.ReadLine();
			Console.Write("Zeme původu:");
			osoba.Zeme = Console.ReadLine();
			osoby.Add(osoba);
			break;
		case 2:
			Console.Write("Zadej jmeno:");
			int index = Convert.ToInt32(Console.ReadLine());
			osoby.RemoveAt(index);
			break;
		case 3:
			int i = 0;
			foreach (Osoba polozka in osoby)
			{
				Console.WriteLine($"{i}\t{polozka.Jmeno}\t{polozka.Vek}\t{polozka.Zeme}");
				i++;
				Console.WriteLine();
			}
			break;
		case 4:
			i = 0;
			foreach (Osoba polozka in osoby)
			{
				File.AppendAllText(cestaS, $"{i}\t{polozka.Jmeno}\t{polozka.Vek}\t{polozka.Zeme}");
				i++;
			}
			break;
		case 5:
			Console.WriteLine(File.ReadAllText(cestaS));
			Console.WriteLine();
			break;

	}

}