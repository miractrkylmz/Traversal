﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetById(int id)
        {
            var values = _destinationService.GetByID(id);
            return Json(values);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.GetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }

        public readonly static List<CityClass> Cities = new()
        {
            new CityClass()
            {
                CityID = 1,
                CityName = "Üsküp",
                CityCountry = "Makedonya"
            },

            new CityClass()
            {
                CityID = 2,
                CityName = "Roma",
                CityCountry = "İtalya"
            },

            new CityClass()
            {
                CityID = 3,
                CityName = "Paris",
                CityCountry = "Fransa"
            }
        };
    }
}
