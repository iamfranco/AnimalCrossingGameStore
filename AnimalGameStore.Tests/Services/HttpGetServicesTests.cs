using AnimalGameStore.Models;
using AnimalGameStore.Services;

namespace AnimalGameStore.Tests.Services;
internal class HttpGetServicesTests
{
    HttpGetServices fossilServices;

    [SetUp]
    public void Setup()
    {
        fossilServices = new();
    }

    [Test]
    public async Task GetFossilAsync_With_Amber_As_Input_Should_Return_Amber_FossilAsync()
    {
        Fossil? fossil = await fossilServices.GetFossilAsync("amber");

        Fossil expectedResult = new Fossil { 
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
        Fossil? fossil = await fossilServices.GetFossilAsync("someNonExistentFossil");

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetFossilAsync_With_Empty_Fossil_Input_Should_Return_Null()
    {
        Fossil? fossil = await fossilServices.GetFossilAsync("");

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetFossilAsync_With_Whitespace_Fossil_Input_Should_Return_Null()
    {
        Fossil? fossil = await fossilServices.GetFossilAsync("  ");

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public async Task GetFossilAsync_With_Null_Fossil_Input_Should_Return_Null()
    {
        Fossil? fossil = await fossilServices.GetFossilAsync(null);

        Fossil? expectedResult = null;

        fossil.Should().BeEquivalentTo(expectedResult);
    }
}
