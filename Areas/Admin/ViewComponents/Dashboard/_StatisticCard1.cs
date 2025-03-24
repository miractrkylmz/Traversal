using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Traversal.Areas.Admin.ViewComponents.Dashboard
{
    public class _StatisticCard1:ViewComponent
    {
        Context c = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Users.Count();

            return View();
        }
    }
}
