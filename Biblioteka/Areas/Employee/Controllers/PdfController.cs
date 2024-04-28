using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Biblioteka.Utility;
using Microsoft.AspNetCore.Authorization;
using Biblioteka.Data;
using iTextSharp.text.pdf.draw;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = SD.Role_Employee)]
    public class PdfController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PdfController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult GeneratePdf()
        {

            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED, 12);
            Font largeFont = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED, 16);
            Font largeBoldFont = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED, 16, Font.BOLD);
            Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED, 12, Font.BOLD);

            Paragraph header = new Paragraph("Raport", largeBoldFont);
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);
            document.Add(new Chunk(new LineSeparator()));

            #region Podsumowanie

            int totalBooksCount = _db.Books.Count();
            int totalUsersCount = _db.Users.Count();

            Paragraph summary = new Paragraph("Liczba książek w naszej bibliotece wzrosła do: " + totalBooksCount + ".", largeFont);
            Paragraph summary2 = new Paragraph("Liczba zarejestrowanych użytkowników wynosi aktualnie: " + totalUsersCount + ".", largeFont);
            summary.Alignment = Element.ALIGN_CENTER;
            summary2.Alignment = Element.ALIGN_CENTER;
            document.Add(summary);
            document.Add(summary2);
            document.Add(new Chunk(new LineSeparator()));

            #endregion

            #region Najlepiej oceniane książki

            //wyświetlenie najlepeij ocenianych książek
            Paragraph bookRatingHeader = new Paragraph("Najlepiej oceniane książki:", largeFont);
            bookRatingHeader.Alignment = Element.ALIGN_CENTER;
            bookRatingHeader.SpacingAfter = 20f;
            document.Add(bookRatingHeader);

            List<Book> objBookList = _db.Books.ToList();

            PdfPTable table = new PdfPTable(4);
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 4;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            table.AddCell("");
            table.AddCell (new Phrase("Tytuł", boldFont));
            table.AddCell (new Phrase("Autor", boldFont));
            table.AddCell(new Phrase("Ocena", boldFont));
            int bookPlace = 1;
            foreach (Book book in objBookList.OrderByDescending(b => b.UserRating).Take(5))
            {
                table.AddCell(new Phrase(bookPlace.ToString() + ".", boldFont));
                table.AddCell(new Phrase(book.Title, font));
                table.AddCell(new Phrase(book.Author, font));
                table.AddCell(new Phrase(book.UserRating.ToString("0.0"), font));
                bookPlace++;
            }
            document.Add(table);
            document.Add(new Chunk(new LineSeparator()));

            #endregion

            #region Najczęściej wypożyczający użytkownicy

            Paragraph userBorrowHeader = new Paragraph("Użytkownicy którzy najczęściej wypożyczali książki:", largeFont);
            userBorrowHeader.Alignment = Element.ALIGN_CENTER;
            userBorrowHeader.SpacingAfter = 20f;
            document.Add(userBorrowHeader);
                       
            var topBorrowers = _db.BorrowHistorys
                .GroupBy(b => b.UserId)
                .Select(g => new
                    {
                        UserId = g.Key,
                        BorrowCount = g.Count()  
                     })
                .OrderByDescending(x => x.BorrowCount)  
                .Take(3)  
                .ToList();


            PdfPTable tableUsers = new PdfPTable(3);
            PdfPCell cell2 = new PdfPCell();
            cell2.Colspan = 3;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            tableUsers.AddCell(cell2);

            tableUsers.AddCell("");
            tableUsers.AddCell(new Phrase("Nazwa", boldFont));
            tableUsers.AddCell(new Phrase("Liczba wypożyczeń", boldFont));
            int userPlace = 1;
            foreach (var obj in topBorrowers)
            {                
                tableUsers.AddCell (new Phrase(userPlace.ToString()+".", boldFont));
                tableUsers.AddCell (new Phrase(obj.UserId, font));
                tableUsers.AddCell (new Phrase(obj.BorrowCount.ToString(), font)); 
                userPlace++;
            }
            document.Add(tableUsers);
            document.Add(new Chunk(new LineSeparator()));

            #endregion

            #region Najczęściej wypożyczane książki

            Paragraph bookBorrowHeader = new Paragraph("Najczęściej wypożyczane książki:", largeFont);
            bookBorrowHeader.Alignment = Element.ALIGN_CENTER;
            bookBorrowHeader.SpacingAfter = 20f;
            document.Add(bookBorrowHeader);

            var topBorrowerBook = _db.BorrowHistorys.Include(u => u.Book)
                .GroupBy(b => b.BookId)
                .Select(g => new
                {
                    BookId = g.Key,
                    Title = g.FirstOrDefault().Book.Title,
                    BorrowCountBooks = g.Count()
                })
                .OrderByDescending(x => x.BorrowCountBooks)
                .Take(3)
                .ToList();


            PdfPTable tableBooks = new PdfPTable(3);
            PdfPCell cell3 = new PdfPCell();
            cell3.Colspan = 3;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            tableUsers.AddCell(cell2);

            tableBooks.AddCell("");
            tableBooks.AddCell(new Phrase("Tytuł", boldFont));
            tableBooks.AddCell(new Phrase("Liczba wypożyczeń", boldFont));
            int borrowedBookPlace = 1;
            foreach (var obj in topBorrowerBook)
            {
                tableBooks.AddCell(new Phrase(borrowedBookPlace.ToString() + ".", boldFont));
                tableBooks.AddCell(new Phrase(obj.Title));
                tableBooks.AddCell(new Phrase(obj.BorrowCountBooks.ToString()));
                borrowedBookPlace++;
            }
            document.Add(tableBooks);
            document.Add(new Chunk(new LineSeparator()));

            #endregion

            Paragraph endSummary = new Paragraph("Stan na dzień: " + DateTime.Now.ToString("dd-MM-yyyy"), font);
            endSummary.Alignment = Element.ALIGN_RIGHT;
            document.Add(endSummary);

            document.Close();

            // Zwracanie pliku PDF jako FileResult
            byte[] bytes = memoryStream.ToArray();
            return File(bytes, "application/pdf", "raport.pdf");
        }
    }
}
