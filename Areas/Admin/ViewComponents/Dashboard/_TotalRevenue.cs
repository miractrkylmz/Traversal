using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.ViewComponents.Dashboard
{
    public class _TotalRevenue:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
