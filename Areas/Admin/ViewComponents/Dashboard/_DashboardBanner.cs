using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.ViewComponents.Dashboard
{
    public class _DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
