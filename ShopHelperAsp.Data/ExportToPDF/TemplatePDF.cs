namespace ShopHelperAsp.Data.ExportToPDF
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using iTextSharp.text.pdf;
    using iTextSharp.text;
    
    public class TemplatePDF : PdfPageEventHelper
    {
        #region Fields
        private PdfContentByte cb;
        private PdfTemplate headerTemplate, footerTemplate;
        private BaseFont bf = null;
        private DateTime printDateTime = DateTime.Now;
        private string _headerText;
        private string _headerImageURL;
        #endregion

        #region Constructors
        public TemplatePDF(string headerText, string headerImageURL)
        {
            string officeTown = headerText;
            int index = officeTown.IndexOf('_');
            if (index > 0)
            {
                _headerText = officeTown.Substring(index + 1);
            }
            else
            {
                _headerText = headerText;
            }
            _headerImageURL = headerImageURL;
        } 
        #endregion

        #region Events
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                printDateTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(0f, 0f);
                headerTemplate.SetHorizontalScaling(3f);
                footerTemplate = cb.CreateTemplate(40, 40);
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);

            //Fill light gray body background
            cb.SetColorStroke(new BaseColor(Color.FromArgb(212, 222, 223)));
            cb.SetColorFill(new BaseColor(Color.FromArgb(212, 222, 223)));

            cb.MoveTo(15, 800);
            cb.LineTo(580, 800);
            cb.LineTo(580, 10);
            cb.LineTo(15, 10);

            cb.Fill();

            //Header table fonts
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font headerFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE);

            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font headerFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);

            //Create header table
            PdfPTable headerTable = new PdfPTable(3);
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(_headerImageURL);
            PdfPCell logoCell = new PdfPCell(logo);
            logoCell.HorizontalAlignment = Element.ALIGN_CENTER;
            Phrase officeName = new Phrase(_headerText, headerFontNormal);

            //Create Header table row 1 cells
            PdfPCell headerRow1Cell1 = new PdfPCell();
            PdfPCell headerRow1Cell2 = new PdfPCell(logoCell);
            PdfPCell headerRow1Cell3 = new PdfPCell();
            String text = "Page " + writer.PageNumber + " of ";

            //Create Header table row 2 cells
            PdfPCell headerRow2ColspanCell = new PdfPCell(officeName);

            //Create Header table row 3 cells
            PdfPCell headerRow3Cell1 = new PdfPCell(new Phrase("Date: " + printDateTime.ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture), headerFontBig));
            PdfPCell headerRow3Cell2 = new PdfPCell();
            PdfPCell headerRow3Cell3 = new PdfPCell(new Phrase("TIME: " + string.Format("{0:T}", DateTime.Now, System.Globalization.CultureInfo.InvariantCulture), headerFontBig));

            //Set the background color of all Header table cells
            headerRow1Cell1.BackgroundColor = new BaseColor(Color.FromArgb(40, 40, 40));
            headerRow1Cell2.BackgroundColor = new BaseColor(Color.FromArgb(40, 40, 40));
            headerRow1Cell3.BackgroundColor = new BaseColor(Color.FromArgb(40, 40, 40));
            headerRow2ColspanCell.BackgroundColor = new BaseColor(Color.FromArgb(40, 40, 40));
            headerRow3Cell1.BackgroundColor = new BaseColor(Color.FromArgb(40, 40, 40));
            headerRow3Cell2.BackgroundColor = new BaseColor(Color.FromArgb(40, 40, 40));
            headerRow3Cell3.BackgroundColor = new BaseColor(Color.FromArgb(40, 40, 40));

            //Set the horizontal alignment of all three Header table cells
            headerRow1Cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRow1Cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRow1Cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRow2ColspanCell.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRow3Cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRow3Cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            headerRow3Cell3.HorizontalAlignment = Element.ALIGN_CENTER;

            //Set the vertical alignment of all three Header table cells
            headerRow1Cell2.VerticalAlignment = Element.ALIGN_BOTTOM;
            headerRow1Cell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerRow2ColspanCell.VerticalAlignment = Element.ALIGN_TOP;
            headerRow3Cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerRow3Cell2.VerticalAlignment = Element.ALIGN_MIDDLE;
            headerRow3Cell3.VerticalAlignment = Element.ALIGN_MIDDLE;

            headerRow2ColspanCell.Colspan = 3;

            //Set the border of all three Header table cells to 0
            headerRow1Cell1.Border = 0;
            headerRow1Cell2.Border = 0;
            headerRow1Cell3.Border = 0;
            headerRow2ColspanCell.Border = 0;
            headerRow3Cell1.Border = 0;
            headerRow3Cell2.Border = 0;
            headerRow3Cell3.Border = 0;

            //Add all cells into Header table
            headerTable.AddCell(headerRow1Cell1);
            headerTable.AddCell(headerRow1Cell2);
            headerTable.AddCell(headerRow1Cell3);
            headerTable.AddCell(headerRow2ColspanCell);
            headerTable.AddCell(headerRow3Cell1);
            headerTable.AddCell(headerRow3Cell2);
            headerTable.AddCell(headerRow3Cell3);

            //Header table width and position
            headerTable.TotalWidth = document.PageSize.Width;
            headerTable.WriteSelectedRows(0, -1, 0, (document.PageSize.Height), writer.DirectContent);

        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            String text = "Page " + writer.PageNumber + " of ";

            //Fill footer rectangle
            cb.SetColorStroke(new BaseColor(Color.FromArgb(40, 40, 40)));
            cb.SetColorFill(new BaseColor(Color.FromArgb(40, 40, 40)));

            cb.MoveTo(0, 70);
            cb.LineTo(620, 70);
            cb.LineTo(620, 0);
            cb.LineTo(0, 0);
            cb.Fill();

            //Add paging to footer
            {
                cb.BeginText();
                cb.SetColorFill(BaseColor.WHITE);
                cb.SetFontAndSize(bf, 12);
                cb.SetTextMatrix(document.PageSize.GetRight(180), document.PageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 12);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
            }

        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetColorFill(BaseColor.RED);

            headerTemplate.SetFontAndSize(bf, 12);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 12);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();


        } 
        #endregion
    }
}
