using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace AccessiblePDFSample {
    internal class Program {
        static void Main(string[] args) {

            ImageTag();
            //OrderAutoTag();
            //AutoTag();
        }
        /// <summary>
        /// Adding tag to image 
        /// </summary>
        static void ImageTag() {
            //Creates new PDF document.
            PdfDocument document = new PdfDocument();
            //Set the document title.
            document.DocumentInformation.Title = "Image";
            //Creates new page.
            PdfPage page = document.Pages.Add();
            //Draw string.
            page.Graphics.DrawString("JPEG Image:", new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold), PdfBrushes.Blue, new PointF(0, 0));
            //Load the image as stream.
            FileStream imageStream = new FileStream(Path.GetFullPath("../../../pdf.jpg"), FileMode.Open, FileAccess.Read);
            //Create a new PDF bitmap object
            PdfBitmap bitmap = new PdfBitmap(imageStream);
            //Set the tag type
            PdfStructureElement imageElement = new PdfStructureElement(PdfTagType.Figure);
            //Set the alternate text
            imageElement.AlternateText = "GreenTree";
            //adding tag to the PDF image
            bitmap.PdfTag = imageElement;
            //Draw image
            bitmap.Draw(page.Graphics, new PointF(50, 20));

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
        /// <summary>
        /// Order the tagged elements in a PDF document
        /// </summary>
        static void OrderAutoTag() {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Sets document title.
            document.DocumentInformation.Title = "Order";
            //Add a new page to the document.
            PdfPage page = document.Pages.Add();
            //Initialize the structure element with tag type paragraph.
            PdfStructureElement structureElement = new PdfStructureElement(PdfTagType.Paragraph);
            //Order the tag in third position.
            structureElement.Order = 3;
            //Create the text element. 
            PdfTextElement element = new PdfTextElement("This is paragraph ONE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));
            //Set the text element brush. 
            element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            //Adding tag to the text element.
            element.PdfTag = structureElement;
            //Draw the text element. 
            element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));
            //Initialize the structure element with tag type paragraph.
            PdfStructureElement paraStruct1 = new PdfStructureElement(PdfTagType.Paragraph);
            //Order the tag in first position.
            paraStruct1.Order = 1;
            //Creates new text element.
            PdfTextElement element1 = new PdfTextElement("This is paragraph TWO.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));
            //Set the brush for text element. 
            element1.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            //Adding tag to the text element.
            element1.PdfTag = paraStruct1;
            //Draw text element in PDF page. 
            element1.Draw(page, new RectangleF(0, 50, page.Graphics.ClientSize.Width / 2, 200));
            //Initialize the structure element with tag type paragraph.
            PdfStructureElement paraStruct2 = new PdfStructureElement(PdfTagType.Paragraph);
            //Order the tag in second position.
            paraStruct2.Order = 2;
            //Creates new text element.
            PdfTextElement element2 = new PdfTextElement("This is paragraph THREE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));
            element2.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            //Adding tag to the text element.
            element2.PdfTag = paraStruct2;
            //Draw the next text element in PDF page. 
            element2.Draw(page.Graphics, new PointF(0, 100));

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
        /// <summary>
        /// Auto Tagging a new document
        /// </summary>
        static void AutoTag() {
            //Creates new PDF document.
            PdfDocument document = new PdfDocument();
            //Set true to auto tag all elements in document.
            document.AutoTag = true;
            //Set the document information title. 
            document.DocumentInformation.Title = "AutoTag";
            //Add a new page to the document.
            PdfPage page = document.Pages.Add();
            //Creates new text element.
            PdfTextElement element = new PdfTextElement("This is paragraph ONE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));
            //Set the brush for text element. 
            element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            //Draw the text element in PDF page.  
            element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));
            //Creates new text element.
            PdfTextElement element1 = new PdfTextElement("This is paragraph TWO.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));
            //Set the brush for text element. 
            element1.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            //Draw the next element in PDF page. 
            element1.Draw(page, new RectangleF(0, 50, page.Graphics.ClientSize.Width / 2, 200));
            //Creates new text element.
            PdfTextElement element2 = new PdfTextElement("This is paragraph THREE.", new PdfStandardFont(PdfFontFamily.Helvetica, 12));
            //Set the brush for text element. 
            element2.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            //Draw the next element in PDF page. 
            element2.Draw(page.Graphics, new PointF(0, 100));

            //Create file stream.
            using (FileStream outputFileStream = new FileStream("Output.pdf", FileMode.Create, FileAccess.ReadWrite)) {
                //Save the PDF document to file stream.
                document.Save(outputFileStream);
            }
            //Close the document.
            document.Close(true);
        }
    }
}