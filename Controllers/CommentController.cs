using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Traversal.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());

        [HttpGet]
        public PartialViewResult AddComment()
        { 
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {

            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            cm.TAdd(p);
            return RedirectToAction("DestinationDetails","Destination",new {id=p.DestinationID});
        }
    }
}