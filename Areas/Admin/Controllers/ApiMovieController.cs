using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Traversal.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMovies = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                            {
                                { "x-rapidapi-key", "9c5c657e55mshde116bd615667b7p1f3c75jsnbf87afac269b" },
                                { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
                            },
            };
            using var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovies = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMovies);
        }
    }
}