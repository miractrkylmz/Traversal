using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager dm = new(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = dm.TGetList();
            return View(values);
        }

        public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewBag.CurrentFilter = searchString;
            var values = from x in dm.TGetList() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.Contains(searchString));
            }
            return View(values.ToList());
        }
    }
}
