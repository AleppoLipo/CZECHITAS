using System.Text;

//Vytvoř program, který převede zadaný text na morseovku. 

//Pro zjednodušení vycházej z toho, že bude zadaný text bez háčků a čárek(následně můžeš o tuto možnost vylepšit) a čísel(můžeš taky o toto vylepšit).

//Ať nemusíš hledat morseovku, zde je rovnou pole se všemi náhradami za klascké znaky

//Pokud budeš chtít program vylepšit i o čísla, budeš si muset už patřičné morseovy znaky dohledat a doplnit.

string[] morseovyZnaky = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."};



Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Zapiš text, který chceš převést na morseovku. ");
Console.ResetColor();

Console.WriteLine();
Console.WriteLine();


string text = Console.ReadLine();

StringBuilder sb = new StringBuilder();

foreach (char velkyZnak in text.ToUpper())
{

	if (velkyZnak == ' ')
	{

	}
	else if (velkyZnak >= 'A' && velkyZnak <= 'Z')
	{
		sb.Append(morseovyZnaky[velkyZnak - 'A']);
	}
	sb.Append('|');
}

Console.WriteLine(sb.ToString());

Console.WriteLine();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(@"Pomůcka: ""|"" oddeluje jednotlivá písmena, ""||"" odděluje slova. ");
Console.ResetColor();