// See https://aka.ms/new-console-template for more information

using FindTheStarWars.Entities;
using FindTheStarWars.Helper;
using Newtonsoft.Json;
var results = new Output();
bool allMoviesMatch = false;
List<string> actors = new();
List<string> buddies = new();

try
{
    using (var httpClient = new HttpClient())
    {
        using (var response = await httpClient.GetAsync(BaseUrl.GetBaseUrl()))
        {
            var apiResponse = await response.Content.ReadAsStringAsync();
            results = JsonConvert.DeserializeObject<Output>(apiResponse);
        }
    }

    foreach (var firstActor in results.Results)
    {
        string mainActor = firstActor.Name;

        foreach (var secondActor in results.Results)
        {
            if (firstActor.Films.Count == secondActor.Films.Count)
            {
                if (firstActor.Name != secondActor.Name)
                {
                    for (int i = 0; i < firstActor.Films.Count; i++)
                    {
                        if (firstActor.Films[i] == secondActor.Films[i])
                        {
                            allMoviesMatch = true;
                        }
                        else
                        {
                            allMoviesMatch = false;
                            break;
                        }
                    }
                    if (allMoviesMatch)
                    {
                        if (!actors.Contains(firstActor.Name) && !actors.Contains(secondActor.Name))
                        {
                            actors.Add(firstActor.Name);
                            buddies.Add("Buddies" +
                                 " " + firstActor.Name + "," + "  " + secondActor.Name);
                        }
                    }
                }

            }
        }
    }

    foreach (var buddie in buddies)
    {
        Console.WriteLine(buddie);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}