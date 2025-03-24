using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TGetListContactUsByTrueStatus();
            return View(values);
        }
        public IActionResult Passivate(int id)
        {
            var value = _contactUsService.GetByID(id);
            value.MessageStatus = false;
            _contactUsService.TUpdate(value);
            return RedirectToAction("Index");
        }

        public IActionResult Activate(int id)
        {
            var value = _contactUsService.GetByID(id);
            value.MessageStatus = true;
            _contactUsService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
