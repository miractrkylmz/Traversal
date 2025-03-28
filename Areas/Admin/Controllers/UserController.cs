﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _userService.TGetList();
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            var values = _userService.GetByID(id);
            _userService.TDelete(values);
            return View("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _userService.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser p)
        {
            _userService.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser(int id)
        {
            _userService.TGetList();
            return View();
        }
        public IActionResult HistoryUser(int id)
        {
            var values = _reservationService.GetReservationListByAccepted(id);
            return View(values);
        }
    }
}
