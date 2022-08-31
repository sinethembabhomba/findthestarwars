
namespace FindTheStarWars.Helper
{
    public static class BaseUrl
    {
        private const string baseUrl = "https://swapi.dev/api/people/?page=2";
        public static string GetBaseUrl()
        {
            return baseUrl;
        }
    }
}
