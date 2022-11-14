using AirQuality.Models;
using AirQuality.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirQuality.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> City(string city)
        {
            // Get result from CityService
            Root root = new Root();
            if (!string.IsNullOrEmpty(city))
            {
                root = await _cityService.GetAllCities(city);
            }
            return View(root);
        }
        public async Task<IActionResult> Country(string country)
        {
            Root root = new Root();
            if (!string.IsNullOrEmpty(country))
            {
                root = await _cityService.GetAllCountries(country);
            }
            return View(root);
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