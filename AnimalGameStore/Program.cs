using AnimalGameStore.AppUI;
using AnimalGameStore.Services;

HttpGetServices httpGetServices = new HttpGetServices();

await AskUser.AskUserForFossilOrArt(httpGetServices);