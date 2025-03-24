using BusinessLayer.Abstract;
using BusinessLayer.ValidationRule;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide p)
        {
            GuideValidator gv = new();
            ValidationResult result = gv.Validate(p);
            if (result.IsValid)
            {
                _guideService.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide p)
        {
            _guideService.TUpdate(p);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index");
        }
    }
}