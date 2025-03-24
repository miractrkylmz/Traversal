using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _SubAbout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            SubAboutManager ms = new SubAboutManager(new EfSubAboutDal());
            var values = ms.TGetList();
            return View(values);
        }
    }
}
