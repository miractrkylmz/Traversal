using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly DestinationManager dm = new (new EfDestinationDal());
        private readonly ReservationManager rm = new (new EfReservationDal());
        private readonly UserManager<AppUser> _usermanager;

        public ReservationController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            var valuesList = rm.GetReservationListByAccepted(values.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            var valuesList = rm.GetReservationListByPrevious(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            var valuesList = rm.GetReservationListByWaitApproval(values.Id);
            return View(valuesList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in dm.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList(); 
            ViewBag.v = values;    
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 1;
            p.ReservationStatus = "Onay Bekliyor";
            rm.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }

        public IActionResult Deneme()
        {
            return View();
        }
    }
}
