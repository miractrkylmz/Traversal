using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.MemberDashboard
{
    public class _GuideList:ViewComponent
    {
        private readonly GuideManager gm = new(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = gm.TGetList();
            return View(values);
        }
    }
}
