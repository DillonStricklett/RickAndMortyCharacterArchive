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
        /// <param name="name">User searched name.</param>
        /// <returns></returns>
        public async Task<Character> GetCharactersByName(string name)
        {
            return await GetCharactersByNameOrId(name);
        }

        /// <summary>
        /// Gets a character by their id
        /// </summary>
        /// <param name="id">User searched id</param>
        /// <returns></returns>
        public async Task<Character> GetCharacterById(int id)
        {
            return await GetCharactersByNameOrId(id.ToString());
        }

        /// <summary>
        /// Retrieve characters by name or id.
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name">User searched name.</param>
        /// <exception cref="ArgumentException">Thrown when character is not found.</exception>
        /// <returns></returns>
        private static async Task<Character> GetCharactersByNameOrId(string name)
        {
            int id;
            bool isNum = int.TryParse(name, out id);
            if (isNum)
            {
                string url = $"https://rickandmortyapi.com/api/character/{id}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Character>(responseBody);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"{id} does not exist.");
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
            else
            {
                string url = $"https://rickandmortyapi.com/api/character/?name={name}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Character>(responseBody);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ArgumentException($"{name} does not exist.");
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}
