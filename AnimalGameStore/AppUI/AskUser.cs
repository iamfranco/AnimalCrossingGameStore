using AnimalGameStore.Models;
using AnimalGameStore.Services;
using Spectre.Console;

namespace AnimalGameStore.AppUI;
public static class AskUser
{
    public static async Task AskUserForFossilOrArt(HttpGetServices httpGetServices)
    {
        Console.Clear();
        string fossilOrArt = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Search [green]fossil item[/] or [green]art item[/]?")
                .AddChoices(new[]
                {
            "Fossil",
            "Art"
                })
            );

        if (fossilOrArt == "Fossil")
            await AskUserForFossilName(httpGetServices);

        if (fossilOrArt == "Art")
            await AskUserForArtName(httpGetServices);
    }

    public static async Task AskUserForFossilName(HttpGetServices httpGetServices)
    {
        Console.Clear();
        string fossilName = AnsiConsole.Ask<string>("Enter [green]fossil[/] name to search:").ToLower();

        var getFossilAsync = httpGetServices.GetFossilAsync(fossilName);
        AnsiConsole.MarkupLine($"\nSending GET request to Animal Crossing API for fossil: [green]{fossilName}[/]");

        Fossil? fossil = await getFossilAsync;

        if (fossil is null)
        {
            AnsiConsole.MarkupLine($"\nFossil [green]{fossilName}[/] not found");
            await AskUserToContinueAsync(httpGetServices);
        }

        AnsiConsole.MarkupLine($"\n  Fossil Name: [green]{fossil.Name}[/]");
        AnsiConsole.MarkupLine($"        Price: [green]{fossil.Price}[/]");
        AnsiConsole.MarkupLine($"Museum Phrase: [green]{fossil.MuseumPhrase}[/]");
        await AskUserToContinueAsync(httpGetServices);
    }

    public static async Task AskUserForArtName(HttpGetServices httpGetServices)
    {
        Console.Clear();
        int artId = AnsiConsole.Ask<int>("Enter [green]art[/] id number to search (number greater than 0):");

        var getArtAsync = httpGetServices.GetArtAsync(artId);
        AnsiConsole.MarkupLine($"\nSending GET request to Animal Crossing API for Art at id: [green]{artId}[/]");

        Art? art = await getArtAsync;

        if (art is null)
        {
            AnsiConsole.MarkupLine($"\nArt at id [green]{artId}[/] not found");
            await AskUserToContinueAsync(httpGetServices);
        }

        AnsiConsole.MarkupLine($"\n          Art Name: [green]{art.Name}[/]");
        AnsiConsole.MarkupLine($"          Has Fake: [green]{art.HasFake}[/]");
        AnsiConsole.MarkupLine($"         Buy Price: [green]{art.BuyPrice}[/]");
        AnsiConsole.MarkupLine($"        Sell Price: [green]{art.SellPrice}[/]");
        AnsiConsole.MarkupLine($"Museum Description: [green]{art.MuseumDescription}[/]");
        await AskUserToContinueAsync(httpGetServices);
    }

    public static async Task AskUserToContinueAsync(HttpGetServices httpGetServices)
    {
        Console.WriteLine();
        string options = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Search for another item or Quit?")
                .AddChoices(new[]
                {
                "Search for another item",
                "Quit"
                })
            );

        if (options == "Quit")
            Environment.Exit(0);

        await AskUserForFossilOrArt(httpGetServices);
    }
}
