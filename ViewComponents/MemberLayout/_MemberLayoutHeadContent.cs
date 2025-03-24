using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberLayout
{
    public class _MemberLayoutHeadContent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
