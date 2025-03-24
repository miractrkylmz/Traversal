using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAdressFrom = new MailboxAddress("Admin","frprojects01@gmail.com");
            mimeMessage.From.Add(mailboxAdressFrom);

            MailboxAddress mailBoxAddressTo = new MailboxAddress("User",p.ReceiverMail);
            mimeMessage.To.Add(mailBoxAddressTo);

            mimeMessage.Subject = p.Subject;

            mimeMessage.Body = new TextPart("plain")
            {
                Text = p.Body
            };

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("frprojects01@gmail.com", "wiqqovvzujaoyrpw");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
