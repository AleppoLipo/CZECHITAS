//Úkol je obdobou úkolu zápisu do souboru (viz. https://moje.czechitas.cz/cs/udalosti/prehled/2090-c-2/domaci-ukol/551 )

//Jen zde se nebudou zadávat řádky, ale údaje o osobě(případně o knize a podobně) jako jméno, příjměné, rok narození apod. (opět dle fantazie a kreativity)

//Každá osoba se takto uloží do souboru. Co osoba to řádek v souboru.

//Uživatel by v minimálním provedení měl mít možnost přidat osobu a vypsat všechny osoby. Pokud si budeš chtít vyhrát jde udělat mnoho dalších funkcí jako vypsat jen osoby nějakého roku narození apod. Tedy lze dát velký prostor kreativitě.


using Lekce3_HW_4;
using System.Text;

List<Pes> psi = new List<Pes>();
string cestaS = @"..\TP_HW\psi_kartoteka.txt";

if (!File.Exists(cestaS))
{
	try
	{
		Directory.CreateDirectory(Path.GetDirectoryName(cestaS));
		using (var stream = File.Create(cestaS)) ;
	}
	catch (Exception ex)
	{
		Console.WriteLine("Soubor se nepodarilo vytvorit.");
		return;
	}
}

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
			{
				bool jeValidni = false;
				string plemeno = "";
				string pohlavi = "";
				int vekCislo = 0;

				while (!jeValidni)
				{
					Console.Write("Plemeno:");
					plemeno = Console.ReadLine();

					if (plemeno.Length >= 100 || plemeno.Length <= 0)
					{
						Console.WriteLine("Zadej hodnotu s delkou od 1 do 100 znaku.");
					}
					else
					{
						jeValidni = true;
					}
				}

				jeValidni = false;

				while (!jeValidni)
				{
					Console.Write("Pohlavi:");
					pohlavi = Console.ReadLine();

					if (pohlavi.Equals(nameof(PohlaviKod.Pes), StringComparison.OrdinalIgnoreCase) || pohlavi.Equals(nameof(PohlaviKod.Fena), StringComparison.OrdinalIgnoreCase))
					{
						jeValidni = true;
					}
					else
					{
						Console.WriteLine("Zadej hodnotu \"Pes\" nebo \"Fena\"");
					}
				}

				jeValidni = false;

				while (!jeValidni)
				{
					Console.Write("Vek:");

					if (int.TryParse(Console.ReadLine(), out vekCislo) && vekCislo > 0 && vekCislo <= 25)
					{
						jeValidni = true;
					}
					else
					{
						Console.WriteLine("Zadej hodnotu mezi 1 a 25");
					}
				}

				Pes pes = VytvorPsa(plemeno, pohlavi, vekCislo);
				File.AppendAllText(cestaS, $"{pes.Plemeno}%^%{pes.Pohlavi}%^%{pes.Vek}{Environment.NewLine}");
			}
			break;
		case 2:
			{
				Console.Write("Zadej plemeno:");
				psi = ZiskatListPsu();
				string plemeno = Console.ReadLine();

				psi.RemoveAll(x => x.Plemeno.Equals(plemeno));

				StringBuilder sb = new StringBuilder();

				foreach (var pes in psi)
				{
					sb.Append($"{pes.Plemeno}%^%{pes.Pohlavi}%^%{pes.Vek}{Environment.NewLine}");
				}

				File.WriteAllText(cestaS, sb.ToString());
			}
			break;
		case 3:
			int i = 0;

			psi = ZiskatListPsu();

			foreach (Pes polozka in psi)
			{
				Console.WriteLine($"{i}\t{polozka.Plemeno}\t{polozka.Pohlavi}\t{polozka.Vek}");
				i++;
			}
			Console.WriteLine();
			break;

	}

}

Pes VytvorPsa(string plemeno, string pohlavi, int vek)
{
	Pes pes = new Pes();

	pes.Plemeno = plemeno;
	Enum.TryParse(pohlavi, true, out PohlaviKod pohlaviKod);
	pes.Pohlavi = pohlaviKod;
	pes.Vek = vek;

	return pes;
}

List<Pes> ZiskatListPsu()
{
	List<Pes> psi = new List<Pes>();
	string ObsahSouboru = File.ReadAllText(cestaS);
	string[] radky = ObsahSouboru.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
	foreach (var radek in radky)
	{
		string[] info = radek.Split(new string[] { "%^%" }, StringSplitOptions.RemoveEmptyEntries);

		int.TryParse(info[2], out int vek);
		psi.Add(VytvorPsa(info[0], info[1], vek));
	}
	return psi;
}