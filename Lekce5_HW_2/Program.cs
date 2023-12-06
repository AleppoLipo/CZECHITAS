//Vytvoř si skutečně slovník. Tedy aplikaci kde přidáte slovo a jeho překlad (případně i více překladů). 

//Možné operace už jsou na vás, ale bylo by vhodné moct v takové aplikaci si vše uložit a načíst ze souboru, vyhledat apod.

using System.Text;

Dictionary<string, string> slovnik = new Dictionary<string, string>();
string cestaS = @"..\TP_HW\EN_slovnik.txt";

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

Console.WriteLine("Cesko-anglicky slovnik");

bool pp = false;
while (!pp)
{
	Console.WriteLine();
	Console.WriteLine("1 - Pridat preklad");
	Console.WriteLine("2 - Smazat preklad");
	Console.WriteLine("3 - Prelozit");
	Console.WriteLine("0 - Ukonceni");
	Console.WriteLine();

	Console.WriteLine();
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("Zadej moznost.");
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
				string slovoCz = "";
				string slovoEn = "";

				bool jeValidni = false;

				while (!jeValidni)
				{
					Console.Write("Slovo cesky:");
					slovoCz = Console.ReadLine();

					if (slovoCz.Length > 100 && slovoCz.Length <= 0)
					{
						Console.WriteLine("Zadej hodnotu s minimální délkou 0 a maximální délkou 100 znkaku");
					}
					else if (slovnik.ContainsKey(slovoCz))
					{
						Console.WriteLine($"Preklad pro slovo {slovoCz} jiz existuje.");
					}
					else
					{
						jeValidni = true;
					}
				}

				jeValidni = false;

				while (!jeValidni)
				{
					Console.Write("Slovo anglicky:");
					slovoEn = Console.ReadLine();

					if (slovoEn.Length > 100 && slovoEn.Length <= 0)
					{
						Console.WriteLine("Zadej hodnotu s minimální délkou 0 a maximální délkou 100 znkaku");
					}
					else
					{
						jeValidni = true;
					}
				}

				slovnik.Add(slovoCz, slovoEn);

				File.AppendAllText(cestaS, $"{slovoCz}%^%{slovoEn}{Environment.NewLine}");
			}
			break;
		case 2:
			{
				Console.Write("Zadej slovo cesky:");
				slovnik = NactiSlovnik();
				string slovo = Console.ReadLine();

				slovnik.Remove(slovo);

				StringBuilder sb = new StringBuilder();

				foreach (var preklad in slovnik)
				{
					sb.Append($"{preklad.Key}%^%{preklad.Value}{Environment.NewLine}");
				}

				File.WriteAllText(cestaS, sb.ToString());
			}
			break;
		case 3:
			{
				Console.Write("Zadej slovo cesky:");
				slovnik = NactiSlovnik();
				string slovo = Console.ReadLine();

				if (!slovnik.ContainsKey(slovo))
					Console.WriteLine($"Preklad pro slovo {slovo} neexistuje.");
				else
					Console.WriteLine(slovnik[slovo]);

				Console.WriteLine();
			}
			break;

	}

}

Dictionary<string, string> NactiSlovnik()
{
	Dictionary<string, string> slovnik = new Dictionary<string, string>();
	string ObsahSouboru = File.ReadAllText(cestaS);
	string[] radky = ObsahSouboru.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
	foreach (var radek in radky)
	{
		string[] info = radek.Split(new string[] { "%^%" }, StringSplitOptions.RemoveEmptyEntries);

		slovnik.Add(info[0], info[1]);
	}
	return slovnik;
}