using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/pdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "dosya23.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfpTable = new PdfPTable(3);
            pdfpTable.AddCell("Misafir Adı");
            pdfpTable.AddCell("Misafir Soyadı");
            pdfpTable.AddCell("Misafir TC");

            pdfpTable.AddCell("Eylül");
            pdfpTable.AddCell("Yücedağ");
            pdfpTable.AddCell("11111111111");

            pdfpTable.AddCell("Falan");
            pdfpTable.AddCell("Keşmır");
            pdfpTable.AddCell("111111111132");

            pdfpTable.AddCell("Kamala");
            pdfpTable.AddCell("Harris");
            pdfpTable.AddCell("111111112312");

            document.Add(pdfpTable);
            document.Close();
            return File("/pdfReports/dosya1.pdf", "application/pdf", "dosya23.pdf");
        }
    }
}
