using Spectre.Console;

var poleMesicu = AnsiConsole.Prompt(  //vytvoří tabulky s měsíci
    new SelectionPrompt<string>()
        .Title("string s otázkou nebo nadpis")
        .PageSize(10)
        .MoreChoicesText("[grey]Měsíce vyber šipkamy[/]")
        .AddChoices("Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec"));

string[] mesic30 = { "Duben", "Červen", "Žáří", "Listopad" };
string[] mesic31 = { "Leden", "Březen", "Květen", "Říjen", "Prosinec" };
string[] mesic28 = { "Únor" };

bool cyklus = true;
int pocetDnu = 0;

if (mesic30.Contains(poleMesicu)) pocetDnu = 30;
if (mesic31.Contains(poleMesicu)) pocetDnu = 31;
if (mesic28.Contains(poleMesicu)) pocetDnu = 28;

var teploty = new List<float>();
var dny = new List<string>();

for (int i = 1; i <= pocetDnu; i++) dny.Add($"{i}. den");
dny.Add("Statistiky teplot");
dny.Add("KONEC");
while (cyklus) //vytvori cyklus na zapis teplot k dnum
{
    Console.Clear();

    var cisalDnu = AnsiConsole.Prompt( //vytvoří tabulku s dny
        new SelectionPrompt<string>()
            .Title("Kolik stupňů bylo tento den")
            .PageSize(10)
            .MoreChoicesText("[grey]Šipkami vybírej dny[/]")
            .AddChoices(dny));

    if (cisalDnu == "KONEC") // pouze ukončí cyklus
    {
        cyklus = false;
        break;
    }

    if (cisalDnu == "Statistiky teplot")
    {
        Console.WriteLine($"Minimální teplota je {teploty.Min()}");
        Console.WriteLine($"Maximální teplota je {teploty.Max()}");   //vytvoři statistiky pro zadané teploty a ukončí cyklus
        Console.WriteLine($"Průměrná teplota je{teploty.Average()}");
        cyklus = false;
        break;
    }
    float teplota = AnsiConsole.Ask<float>("Zadej tepotu: "); //zeptá se na teplotu kterou chcete zadat
    int pozice = dny.IndexOf(cisalDnu); //vytvoří int pozice index pro list dny
    teploty.Add(teplota); //umožní vytvoření statistik
    dny[pozice] = $"{pozice + 1}. den = {teplota}°C"; //přepíše datum na datum s teplotou
}