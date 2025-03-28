﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberDashboard
{
    public class _LastDestinations:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLast4Destination();
            return View(values);
        }
    }
}
