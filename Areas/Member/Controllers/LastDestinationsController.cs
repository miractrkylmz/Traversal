using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class LastDestinationsController : Controller
    {
        private readonly IDestinationService _destinationService;

        public LastDestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetLast4Destination();
            return View(values);
        }
    }
}
