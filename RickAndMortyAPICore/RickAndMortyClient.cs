using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        /// Gets a character by their id
        /// </summary>
        /// <param name="id">User searched id</param>
        /// <returns></returns>
        public async Task<Result> GetCharacterById(int id)
        {
            Result searchResults = new Result();
            string url = $"https://rickandmortyapi.com/api/character/{id}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                searchResults = JsonConvert.DeserializeObject<Result>(responseBody);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{id} does not exist.");
            }
            else
            {
                throw new HttpRequestException();
            }
            return searchResults;
        }

        /// <summary>
        /// Retrieve characters by name or id.
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name">User searched name.</param>
        /// <exception cref="ArgumentException">Thrown when character is not found.</exception>
        /// <returns></returns>
        public static async Task<CharacterSearchResults> GetCharactersByName(string name)
        {
            string url = $"https://rickandmortyapi.com/api/character/?name={name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CharacterSearchResults>(responseBody);
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
