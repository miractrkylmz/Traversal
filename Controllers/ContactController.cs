using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUSService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUSService, IMapper mapper)
        {
            _contactUSService = contactUSService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDTO model)
        {
            if (ModelState.IsValid)
            {
                _contactUSService.TAdd(new ContactUs()
                {
                    MessageDate = model.MessageDate,
                    MessageBody = model.MessageBody,
                    Mail = model.Mail,
                    MessageStatus = true,
                    Name = model.Name,
                    Subject = model.Subject,
                });
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
