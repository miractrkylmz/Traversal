using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.ViewComponents.Dashboard
{
    public class _DashboardHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
