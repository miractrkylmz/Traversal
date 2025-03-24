using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberLayout
{
    public class _MemberLayoutTopBar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
