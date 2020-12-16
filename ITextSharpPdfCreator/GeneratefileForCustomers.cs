using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;

namespace WishCards.ITextSharpPdfCreator
{
    #region Generate pdf file
    public class GeneratefileForCustomers
    {

        public static string GeneratePdfFileForCustomer(string filename,string firstname, string lastname, string contenttext, BackgroundImageEnum backgroundimage, Mp3Enum song, FontsEnum font, string addition = "empty")
        {
            filename = filename + ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 0f, 0f, 0f, 0f);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            //string backgroundfilepath;
            //if (backgroundimage == BackgroundImageEnum.Background1)
            //{
            //    string backgroundfile = "christmas-background1.jpg";
            //    FileInfo f = new FileInfo(backgroundfile);
            //    backgroundfilepath = f.FullName;
            //}
            //if (backgroundimage == BackgroundImageEnum.Background2)
            //{
            //    string backgroundfile = "Christmas-background2.jpg";
            //    FileInfo f = new FileInfo(backgroundfile);
            //    backgroundfilepath = f.FullName;
            //}
            //if (backgroundimage == BackgroundImageEnum.Background3)
            //{
            //    string backgroundfile = "christmas-background3.jpg";
            //    FileInfo f = new FileInfo(backgroundfile);
            //    backgroundfilepath = f.FullName;
            //}
            doc.Open();
            //string storestring1 = "Dear Sir/Ma'am @ thank you heartilly for de purchase at Sjonnie's liquor store @ we will keep you up to date with the latest news";
            //string addnewlines1 = storestring1.Replace("@", Environment.NewLine);
            string storestring1 = "From: @";
            storestring1 = storestring1 + "@" + firstname + " " + lastname + "@";
            storestring1 = storestring1 + "@" + contenttext;
            string backgroundfile;
            if (backgroundimage == BackgroundImageEnum.Background1)
            {
                backgroundfile = "christmas-background1.jpg";
            }
            if (backgroundimage == BackgroundImageEnum.Background1)
            {
                backgroundfile = "Christmas-background2.jpg";
            }
            else
            {
                backgroundfile = "christmas-background3.jpg";
            }

            FileInfo f = new FileInfo(backgroundfile);
            var backgroundfilepath = f.FullName;
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(backgroundfilepath);
            jpg.SetAbsolutePosition(0, 0);
            jpg.ScaleAbsolute(iTextSharp.text.PageSize.A4.Width, iTextSharp.text.PageSize.A4.Height);
            jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
            string addnewlines1 = storestring1.Replace("@", Environment.NewLine);
            //Paragraph paragraph = new Paragraph(addnewlines1);
            Paragraph paragraph = new Paragraph();
            if (font == FontsEnum.Courier)
            {
             paragraph = new Paragraph(addnewlines1, new Font(Font.FontFamily.COURIER, 22));
            }
            if (font == FontsEnum.Helvetica)
            {
                paragraph = new Paragraph(addnewlines1, new Font(Font.FontFamily.HELVETICA, 22));
            }
            if (font == FontsEnum.TimesNewRoman)
            {
                paragraph = new Paragraph(addnewlines1, new Font(Font.FontFamily.TIMES_ROMAN, 22));
            }
            //paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.PaddingTop = Element.ALIGN_MIDDLE;
            //ColumnText.ShowTextAligned(wri.DirectContent, Element.ALIGN_CENTER, new Phrase("test",), (PageSize.A4.Width/2),(PageSize.A4.Height/2), 0f);
            ColumnText column = new ColumnText(wri.DirectContent);
            column.SetSimpleColumn(new Rectangle((PageSize.A4.Width/2) - 100, 0, PageSize.A4.Width,((int)Math.Floor(PageSize.A4.Height/1.5))));
            column.AddElement(new Paragraph(addnewlines1));
            column.Go();
            //paragraph.IndentationRight = 100;
            //paragraph.IndentationLeft = 100;
            //if (font == FontsEnum.Arial)
            //{
            //    paragraph.Font = FontFactory.GetFont("Arial");
            //}
            //else 
            //{
            //    paragraph.Font = FontFactory.GetFont("Times New Roman");
            //}
            doc.Add(jpg);
            //doc.Add(paragraph);
            doc.Close();
            var pathpdffile = Path.GetFullPath(filename);
            return pathpdffile;
        }
    }

    #endregion
}
