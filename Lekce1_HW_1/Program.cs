using System;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("C# - 2: Domácí úkoly - 1. lekce - opakování");
Console.ResetColor();

//zápis zadaných hodnot
int[] hodnoty = new int[] { 3, -4, 0, 21, 3, 16, 7, 0, 1, 3, 4, -2 };

//-----------------------------------------------------------------------------------------------
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine();
Console.WriteLine("Úkol 1:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine("Vytvoř pole typu int s těmito hodnotami {3, -4, 0, 21, 3, 16, 7, 0, 1, 3, 4,-2}. Pro kontrolu si obsah pole vypiš.");
Console.ResetColor();


Console.WriteLine($"Hodnoty:");

for (int i = 0; i < hodnoty.Length; i++)
{
    Console.Write(hodnoty[i]);

    if (i < hodnoty.Length - 1)
    {
        Console.Write(", ");
    }
}

Console.WriteLine();


//-----------------------------------------------------------------------------------------------
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine();
Console.WriteLine("Úkol 2:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine("Vyhledej záporná čísla a změň je na kladné číslo, zároveň vyhledej nuly a ke každé přičti hodnotu jejího indexu. Výsledné pole si vypiš.");
Console.ResetColor();

for (int i = 0; i < hodnoty.Length; i++)
{
    if (hodnoty[i] < 0)
    {
        //změna negativních hodnot na kladná
        hodnoty[i] = Math.Abs(hodnoty[i]);
    }
    else if (hodnoty[i] == 0)
    {
        //0 přepsaná na index
        hodnoty[i] = i;
    }

}

Console.WriteLine($"Záporné se mění na kladné a 0 na hodnotu indexu:");


for (int i = 0; i < hodnoty.Length; i++)
{
    Console.Write(hodnoty[i]);

    if (i < hodnoty.Length - 1)
    {
        Console.Write(", ");
    }
}

Console.WriteLine();

//-----------------------------------------------------------------------------------------------
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine();
Console.WriteLine("Úkol 3:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine("Vyhledej největší číslo v poli a vypiš ho.");
Console.ResetColor();

int maxHodnotafce = hodnoty.Max();

Console.WriteLine($"Nejvyšší číslo přes fci je: {maxHodnotafce}");

int max = int.MinValue;
for (int i = 0; i < hodnoty.Length; i++)
{
    if (hodnoty[i] > max)
    {
        max = hodnoty[i];
    }
}

Console.WriteLine($"Nejvyšší číslo přes cyklus je: {max}");


//-----------------------------------------------------------------------------------------------
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine();
Console.WriteLine("Úkol 4:");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine();
Console.WriteLine("Seřaď prvky v poli od nejmenšího po největší. Můžeš například využít toho, že už umíš najít největší číslo v poli. Prosím, nepoužívej už hotovou funkci na sortování, jde o to, aby sis takovou funkci zkusila napsat sama.");
Console.ResetColor();




int n = hodnoty.Length;
bool swapped = true;
while (swapped)
{
    swapped = false; for (int i = 1; i < n; i++)
    {
        if (hodnoty[i - 1] > hodnoty[i])
        {
            // Swap arr[i-1] and arr[i]
            int temp = hodnoty[i - 1];
            hodnoty[i - 1] = hodnoty[i];
            hodnoty[i] = temp;
            swapped = true;
        }
    }
}

Console.WriteLine("Upravene hodnoty:");

for (int i = 0; i < hodnoty.Length; i++)
{
    Console.Write(hodnoty[i]);

    if (i < hodnoty.Length - 1)
    {
        Console.Write(", ");
    }
}

Console.WriteLine();

Console.WriteLine();

int[] cis = new int[] { 3, -4, 0, 21, 3, 16, 7, 0, 1, 3, 4, -2 };
swapped = true;
while (swapped)

{
    swapped = false; for (int i = 1; i < n; i++)
    {
        if (cis[i - 1] > cis[i])
        {
            // Swap arr[i-1] and arr[i]
            int temp = cis[i - 1];
            cis[i - 1] = cis[i];
            cis[i] = temp;
            swapped = true;
        }
    }
}

Console.WriteLine("Originalni hodnoty:");
for (int i = 0; i < cis.Length; i++)
{
    Console.Write(cis[i]);

    if (i < cis.Length - 1)
    {
        Console.Write(", ");
    }
}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
