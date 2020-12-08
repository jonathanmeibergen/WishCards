using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.ITextSharpPdfCreator
{
    public static class GeneratefileForCustomers
    {

        public static string GeneratePdfFileForCustomer(string filename)
        {
            filename = filename + ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
            doc.Open();
            string storestring1 = "Dear Sir/Ma'am @ have a very merry Christmas and a happy new year";
            string addnewlines1 = storestring1.Replace("@", Environment.NewLine);
            Paragraph paragraph = new Paragraph(addnewlines1);
            paragraph.IndentationRight = 100;
            paragraph.IndentationLeft = 100;
            doc.Add(paragraph);
            doc.Close();
            var pathpdffile = Path.GetFullPath(filename);
            return pathpdffile;
        }
    }
}
