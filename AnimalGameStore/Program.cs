using AnimalGameStore.Models;
using AnimalGameStore.Services;
using Spectre.Console;

HttpGetServices fossilServices = new HttpGetServices();

await AskUserForFossilName(fossilServices);

static async Task AskUserForFossilName(HttpGetServices fossilServices)
{
    Console.Clear();
    string fossilName = AnsiConsole.Ask<string>("What type of animal crossing [green]fossil[/] " +
        "would you like more info on?").ToLower();

    var getFossilAsync = fossilServices.GetFossilAsync(fossilName);
    AnsiConsole.MarkupLine($"\nSending GET request to Animal Crossing API for fossil: [green]{fossilName}[/]");

    Fossil? fossil = await getFossilAsync;

    if (fossil is null)
    {
        AnsiConsole.MarkupLine($"\nFossil [green]{fossilName}[/] not found");
        await AskUserToContinueAsync(fossilServices);
    }

    AnsiConsole.MarkupLine($"\n  Fossil Name: [green]{fossil.Name}[/]");
    AnsiConsole.MarkupLine($"        Price: [green]{fossil.Price}[/]");
    AnsiConsole.MarkupLine($"Museum Phrase: [green]{fossil.MuseumPhrase}[/]");
    await AskUserToContinueAsync(fossilServices);
}

static async Task AskUserToContinueAsync(HttpGetServices fossilServices)
{
    Console.WriteLine();
    string options = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Get info for another fossil or Quit?")
            .AddChoices(new[]
            {
                "Get info for another fossil",
                "Quit"
            })
        );

    if (options == "Quit")
        Environment.Exit(0);

    await AskUserForFossilName(fossilServices);
}