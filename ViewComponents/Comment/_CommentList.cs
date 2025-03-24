using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Traversal.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.TGetCommentListWithDestinationAndUser(id);
            ViewBag.count =  values.Count;
            return View(values);
        }
    }
}
