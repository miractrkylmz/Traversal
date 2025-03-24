using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Traversal.Areas.Admin.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class BookingHotelSearchController : Controller
    {
        private readonly HttpClient _client;

        public BookingHotelSearchController()
        {
            _client = new HttpClient();
        }

        public async Task<IActionResult> Index(string destId = "-755070") //default İstanbul ID
        {
            string url = $"https://booking-com.p.rapidapi.com/v1/hotels/search?page_number=0&order_by=popularity&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&units=metric&dest_id={destId}&room_number=1&checkin_date=2025-06-16&include_adjacency=true&filter_by_currency=USD&locale=en-gb&children_ages=5%2C0&children_number=2&dest_type=city&checkout_date=2025-06-17";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", "f4865aaf4emshe3bd019a31f204bp1636f1jsnaf0c997e72b9" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };

            using var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var jsonObj = JObject.Parse(body);
            var searchResult = jsonObj.ToObject<BookingHotelSearchViewModel>();

            if (searchResult?.result == null)
            {
                return View(new List<BookingHotelSearchViewModel.Result>());
            }

            return View(searchResult.result);
        }

        [HttpPost]
        public async Task<IActionResult> GetCityID(string cityName)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                Headers =
                {
                    { "x-rapidapi-key", "f4865aaf4emshe3bd019a31f204bp1636f1jsnaf0c997e72b9" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };

            using var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var jsonArray = JArray.Parse(body);
            string destId = jsonArray.Count > 0 ? jsonArray[0]["dest_id"]?.ToString() : null;

            if (destId == null)
            {
                TempData["Error"] = "Şehir bulunamadı.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", new { destId });
        }
    }
}
