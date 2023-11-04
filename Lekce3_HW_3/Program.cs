//VYtvoř program podobný tomu, který jsi dělala v breakout roomu na lekci.

//Tedy načítej řádky, dokud není načtený prázdný řádek a zapisuj je do souboru.

//Následně obsah souboru vypiš.

//Možná vylepšení:

//udělej na úvod menu jestli chce uživatel přidávat řádky nebo vypsat soubor.
//pořeš aby prvním řádkem se soubor přepsal a další se jen přidávaly
//dej na výběr jestli se zápisem má soubor přepsat nebo se má přidat na konec
//umožni zadání cesty uživatelem
//případně další dle fantazie a kreativity


using System.Text;

int pridaniVypsaniHodnota;
int pridaniPrepsaniHodnota = 0;
string cestaS;

#region Vstupy

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(@"Pro přidání radku/textu do souboru zadej 1, pro vypsani textu ze souboru zadej 0:");
Console.ResetColor();

string pridaniVypsani = Console.ReadLine();


while (!int.TryParse(pridaniVypsani, out pridaniVypsaniHodnota) && !(pridaniVypsaniHodnota == 0 || pridaniVypsaniHodnota == 1))
{
	Console.WriteLine("Toto není správně, zadej znovu:");
	pridaniVypsani = Console.ReadLine();
}

if (pridaniVypsaniHodnota == 1)
{
	Console.WriteLine();
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("Pro pridani textu do souboru zadej 1, pro prepsani souboru novym textem zadej 0:");
	Console.ResetColor();

	string pridaniPrepsani = Console.ReadLine();

	while (!int.TryParse(pridaniPrepsani, out pridaniPrepsaniHodnota) && !(pridaniPrepsaniHodnota == 0 || pridaniPrepsaniHodnota == 1))
	{
		Console.WriteLine("Toto není správně, zadej znovu:");
		pridaniPrepsani = Console.ReadLine();
	}

}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Zadej cestu souboru nebo prikaz odentrujes, data se ulozi do vychoziho souboru (cesta k souboru se vypise nize).");
Console.ResetColor();

string cestaD = @"C:\Temp\TP_HW\test_text.txt";

cestaS = Console.ReadLine();

if (string.IsNullOrEmpty(cestaS))
{
	cestaS = cestaD;
}

if (!File.Exists(cestaS))
{
	Console.WriteLine("Soubor neexituje, zkus to znovu.");
	Directory.CreateDirectory(Path.GetDirectoryName(cestaS));
	File.Create(cestaS);
}


#endregion

if (pridaniVypsaniHodnota == 0)
{
	Console.WriteLine(File.ReadAllText(cestaS));
	return;
}

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Zacni psat text:");
Console.ResetColor();

string radek;

bool jePrazdnyRadek = false;

StringBuilder sb = new StringBuilder();

while (!jePrazdnyRadek)
{
	radek = Console.ReadLine();
	if (!string.IsNullOrEmpty(radek))
	{
		sb.AppendLine(radek);
	}
	else
	{
		jePrazdnyRadek = true;
	}
}


if (pridaniPrepsaniHodnota == 1)
{
	File.AppendAllText(cestaS, sb.ToString());
}

else
{
	File.WriteAllText(cestaS, sb.ToString());
}



Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Obsah souboru:");
Console.ResetColor();
Console.WriteLine(File.ReadAllText(cestaS));