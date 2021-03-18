using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RickAndMortyCharacterArchive.Models;
using RickAndMortyAPICore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RickAndMortyCharacterArchive.Controllers
{
    public class HomeController : Controller
    {
        private CharacterSearchResults searchResults;
        private readonly ILogger<HomeController> _logger;
        private int index = 0;
        private string name;
        RickAndMortyClient myClient = new RickAndMortyClient();
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // 1-671 character ids
            Random rand = new Random();
            int id = rand.Next(1, 671);

            Result result = await myClient.GetCharacterById(id);
            ViewData["result"] = result;

            
            return View(result);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Search(IFormCollection data)
        {
            
            int currIndex = index;
            if (!string.IsNullOrWhiteSpace(data["userInput"]))
            {
                name = data["userInput"];
                searchResults = await RickAndMortyClient.GetCharactersByName(name);
            }
            ViewData["Id"] = currIndex;

            
            Result[] results = searchResults.results;


            Result currResult = results[currIndex];
            ViewData["resultList"] = results;

            ViewData["Location"] = currResult.location.name;
            ViewData["CharacterList"] = currResult;
            ViewData["search"] = "searched";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
