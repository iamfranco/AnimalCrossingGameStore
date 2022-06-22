using AnimalGameStore.Models;
using AnimalGameStore.Services;

namespace AnimalGameStore.Tests.Services;
internal class HttpGetServicesTests
{
    HttpGetServices httpGetServices;

    [SetUp]
    public void Setup()
    {
        httpGetServices = new();
    }

    [Test]
    public async Task GetFossilAsync_With_Amber_As_Input_Should_Return_Amber_Fossil()
    {
        Fossil? fossil = await httpGetServices.GetFossilAsync("amber");

        Fossil expectedResult = new Fossil
        {
            Name = "amber",
            Price = 1200,
            MuseumPhrase = "Amber is formed from the sap of ancient trees that hardened over time. " +
                "Because of its beauty, it has often been traded and used as jewelry throughout history. " +
                "However, individual specimens may contain ancient plants or insects trapped inside them! " +
                "These are valuable resources for learning about ancient eras, such as when the dinosaurs roamed... " +
                "And this is why they are sometimes displayed in certain...ahem... exceptional museums! Like mine."
        };

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetFossilAsync_With_NonExistent_Fossil_Input_Should_Return_Null()
    {
        Fossil? fossil = await httpGetServices.GetFossilAsync("someNonExistentFossil");

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetFossilAsync_With_Empty_Fossil_Input_Should_Return_Null()
    {
        Fossil? fossil = await httpGetServices.GetFossilAsync("");

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetFossilAsync_With_Whitespace_Fossil_Input_Should_Return_Null()
    {
        Fossil? fossil = await httpGetServices.GetFossilAsync("  ");

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetFossilAsync_With_Null_Fossil_Input_Should_Return_Null()
    {
        Fossil? fossil = await httpGetServices.GetFossilAsync(null);

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetArtAsync_With_1_As_Input_Should_Return_Academic_Painting_Art()
    {
        Art? art = await httpGetServices.GetArtAsync(1);

        Art expectedResult = new Art
        {
            Name = "academic_painting",
            HasFake = true,
            BuyPrice = 4980,
            SellPrice = 1245,
            MuseumDescription = "This drawing is based on the \"ideal\" human-body ratio, " +
                "as stated in \"De architectura.\" \"De architectura\" was a treatise by Vitruvius, " +
                "an architect from the early 1st century BCE."
        };

        art.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetArtAsync_With_NonExistent_Fossil_Input_Should_Return_Null()
    {
        Art? art = await httpGetServices.GetArtAsync(0);

        Art? expectedResult = null;

        art.Should().BeEquivalentTo(expectedResult);
    }
}
