using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickAndMortyAPICore
{
    /// <summary>
    /// Client class to consume TheRickAndMortyAPI
    /// Docs: https://rickandmortyapi.com/
    /// </summary>
    public class RickAndMortyClient
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Retrieve characters by name.
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<string> GetCharactersByName(string name)
        {
            try
            {
                string url = $"https://rickandmortyapi.com/api/character/?name={name}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }

        public void GetCharacterById(int id)
        {

        }
    }
}
