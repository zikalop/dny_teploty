using Spectre.Console;
var poolOfMonths = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("string s otázkou nebo nadpis")
        .PageSize(10)
        .MoreChoicesText("[grey]Měsíce vyber šipkamy[/]")
        .AddChoices("Leden", "Únor", "Březen", "Duben", "Květen", "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec" ));

string[] month30 = { "Duben", "Červen", "Žáří", "Listopad" };
string[] month31 = { "Leden", "Březen", "Květen", "Říjen", "Prosinec" };
string[] month28 ={"Únor"};

bool enblLoop = true;

int nbrdays1 = 30;
var days1 = new List<string>();
for (int i = 1; i <= nbrdays1; i++) days1.Add($"{i}. den");
days1.Add("KONEC");
if (month30.Contains(poolOfMonths))
{
    while(enblLoop)
    {
        var x = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Kolik stupňů bylo tento den")
            .PageSize(14)
            .MoreChoicesText("")
            .AddChoices(days1));
        
        if (x == "KONEC")
        {
            enblLoop = false;
            break;
        }
    }
}


int nbrdays2 = 31;
var days2 = new List<string>();
for (int i = 1; i <= nbrdays2; i++) days2.Add($"{i}. den");
days2.Add("KONEC");
if (month31.Contains(poolOfMonths))
{
    while (enblLoop)
    {
        var x = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Kolik bylo stupňů tento den")
            .PageSize(14)
            .MoreChoicesText("")
            .AddChoices(days2));

        if (x == "KONEC")
        {
            enblLoop = false;
            break;
        }
    }
}



int nbrdays3 = 28;
var days3 = new List<string>();
for (int i = 1; i <= nbrdays3; i++) days3.Add($"{i}. den");
days3.Add("KONEC");
if (month28.Contains(poolOfMonths))
{
    while (enblLoop)
    {
        var x = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Kolik bylo stupňů tento den")
            .PageSize(14)
            .MoreChoicesText("")
            .AddChoices(days3));

        if(x=="KONEC")
        {
            enblLoop = false;
            break;
        }
    }
}
