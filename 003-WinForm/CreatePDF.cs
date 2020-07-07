using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace ParkingSystem
{
	public class CreatePDF
    {
        private Document doc;
        //private RichTextBox rtb;

        public CreatePDF(string FileName)
        {
            doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(FileName + ".pdf", FileMode.Create));
            doc.Open();
        }

        public void DataForPDF(RichTextBox rtb)
        {
            PdfPTable table = new PdfPTable(1);
            table.AddCell(rtb.Text);
            doc.Add(table);
        }

        //function to close report
        public void CloseReport()
        {
            if (doc.IsOpen() == true) doc.Close();
        }

        //destractor (garbage collector)
        ~CreatePDF()
        {
            if (doc.IsOpen() == true) doc.Close();
        }
    }
}
