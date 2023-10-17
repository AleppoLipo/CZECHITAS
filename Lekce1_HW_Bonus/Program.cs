using System;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("C# - 2: Domácí úkoly - 1. lekce - opakování - Bonus");
Console.ResetColor();

//-----------------------------------------------------------------------------------------------
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine();
Console.WriteLine("Úkol 1:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine("Schody - Vypiš zadaný počet schodů (řádků) podle uvedeného příkladu.");
Console.WriteLine("Napiš program tak, aby uživatel mohl zadat počet schodů, které se mají vypsat.(první řádek obsahuje 5 mezer a 1 mřížku, druhý řádek obsahuje 4 mezery a 2 mřížky, …., poslední řádek obsahuje 6 mřížek).");
Console.ResetColor();

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Zadej pocet schodů:");

string pocetschodu = Console.ReadLine();

int pocet;
while (!int.TryParse(pocetschodu, out pocet))

{
	Console.WriteLine("Toto není číslo, zadej znovu:");
	pocetschodu = Console.ReadLine();
}

int mezera = pocet - 1;

for (int i = 1; i <= pocet; i++)
{
	Console.WriteLine($"{new string(' ', mezera)}{new string('#', i)}");
	mezera--;
}


//-----------------------------------------------------------------------------------------------
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine();
Console.WriteLine("Úkol 2:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine("Minimální a maximální součet n-1 prvků.");
Console.WriteLine("Zvol si libovolné pole délky n a najdi v něm takovou kombinaci n-1 prvků, které dávají nejnižší a nejvyšší součet. Tyto dva součty vypiš jako výsledek. Příklad: Pole s prvky {3, 1, 9, 7, 5} o délce n = 5. Jde nám o to, vybrat z tohoto pole takovou kombinaci n-1 (tedy čtyř) čísel,která dává nejmenší a největší součet. Správná odpověď  v tomto případě je 1 + 3 + 5 + 7 = 16, což je minimum a 3 + 5 + 7 + 9 = 24, což je maximum.");
Console.ResetColor();

Console.WriteLine();
Console.WriteLine();



Console.WriteLine("Hodnoty:");

int[] poleHodnot = { 43, 6, 7, 21, 101, 16, 7, 30, 13, 23, 4 }; 

Console.WriteLine(string.Join(", ", poleHodnot));
//vypis hodnot z poleHodnot s čárkami

Console.WriteLine();

int n = poleHodnot.Length;
int[] cis = poleHodnot;
bool swapped = true;
while (swapped)

{
	swapped = false;
	for (int i = 1; i < n; i++)
	{
		if (cis[i - 1] > cis[i])
		{
			int temp = cis[i - 1];
			cis[i - 1] = cis[i];
			cis[i] = temp;
			swapped = true;
		}
	}
}

Console.WriteLine("Serazene hodnoty:");
for (int i = 0; i < cis.Length; i++)
{
	Console.Write(cis[i]);

	if (i < cis.Length - 1)
	{
		Console.Write(", ");
	}
}

//seřazení poleHodnot od nejnižšího po nejvyšší

Console.WriteLine();
Console.WriteLine();

int min = 0;
int max = 0;

for (int i = 0; i < cis.Length; i++)
{
	if (i < cis.Length - 1)
		min = cis[i] + min;

	if (i > 0)
		max = cis[i] + max;
}
Console.WriteLine("Nejnizsi soucet prvnich " + (n - 1) + " cislic je: " + min);

Console.WriteLine("Nevyssi soucet poslednich " + (n - 1) + " cislic je: " + max);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();






