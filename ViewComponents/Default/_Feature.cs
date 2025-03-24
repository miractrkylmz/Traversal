using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _Feature:ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}