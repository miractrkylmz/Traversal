using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _PopularDestinations:ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EfDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values= dm.TGetList();
            return View(values);
        }
    }
}
