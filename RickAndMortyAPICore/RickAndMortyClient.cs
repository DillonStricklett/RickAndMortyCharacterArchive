using Newtonsoft.Json;
using System;
using System.Net;
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
        /// <param name="name">User searched name.</param>
        /// <exception cref="ArgumentException">Thrown when character is not found.</exception>
        /// <returns></returns>
        public async Task<Character> GetCharactersByName(string name)
        {
            string url = $"https://rickandmortyapi.com/api/character/?name={name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Character>(responseBody);
            }
            else if(response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{name} does not exist.");
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public void GetCharacterById(int id)
        {

        }
    }
}
