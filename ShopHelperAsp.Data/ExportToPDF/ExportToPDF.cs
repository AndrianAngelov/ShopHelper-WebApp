namespace ShopHelperAsp.Data.ExportToPDF
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ShopHelperAsp.Data.Entities;
    using System.IO;
    using System.Drawing;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.Web;
    using System.Configuration;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using System.Web.UI.WebControls;

    public class ExportToPDF
    {
        public static void Users(HttpServerUtility page, List<UserApplication> users, string usersOffice, HiddenField savePdfVersion)
        {
            string pdfPathServerUsers = page.MapPath(@"~/App_Data/Users_"+usersOffice+".pdf");
            string pdfPathCloudinary = String.Format(@"http://res.cloudinary.com/hzgrm4rdh/image/upload/PDFs/Users");

            CreatePDFUsers(page, users, usersOffice, pdfPathServerUsers);
            DeleteCloudinaryPDF(pdfPathCloudinary);
            UploadCloudinaryPDF(pdfPathServerUsers, savePdfVersion,"Users_"+usersOffice);

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    Response.ContentType = "pdf/application";
            //    Response.AddHeader("content-disposition", "attachment;filename=First_PDF_document.pdf");
            //    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            //}
        }

        private static void CreatePDFUsers(HttpServerUtility page, List<UserApplication> users, string usersOffice, string pdfPathServerUsers)
        {
            string pdfPathServer = pdfPathServerUsers;

            FileStream fs = new FileStream(pdfPathServer, FileMode.Create, FileAccess.Write, FileShare.None);
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);

            rec.BackgroundColor = new BaseColor(Color.FromArgb(165, 206, 220));
            Document doc = new Document(rec, 20f, 20f, 80f, 20f);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            string headerImageURL = page.MapPath(@"~/Images/HeaderLogo_PDF.png");

            writer.PageEvent = new TemplatePDF(usersOffice + " " + " Users", headerImageURL);
            doc.Open();

            PdfPTable wrapperTable = new PdfPTable(2);
            wrapperTable.TotalWidth = 500f;
            wrapperTable.LockedWidth = true;

            PdfPCell wrapperCell;

            int counter = 0;
            foreach (UserApplication user in users)
            {

                //Current user info table
                PdfPTable userInfoTable = new PdfPTable(1);
                userInfoTable.HorizontalAlignment = 0;
                userInfoTable.SpacingAfter = 0;

                //Current user info table header
                PdfPTable userInfoHeaderTable = new PdfPTable(2);
                float[] widthsHeaderTable = new float[] { 0.8f, 2.2f };
                userInfoHeaderTable.SetWidths(widthsHeaderTable);

                //Current user info table header image cell
                iTextSharp.text.Image profileImage = iTextSharp.text.Image.GetInstance(user.ProfileImageURL);
                profileImage.ScaleToFit(50f, 50f);
                PdfPCell userHeaderImgCell = new PdfPCell(profileImage);
                userHeaderImgCell.HorizontalAlignment = Element.ALIGN_CENTER;
                userHeaderImgCell.BackgroundColor = BaseColor.WHITE;
                userHeaderImgCell.PaddingLeft = 2f;
                userHeaderImgCell.PaddingRight = 2f;
                userHeaderImgCell.PaddingTop = 5f;
                userHeaderImgCell.PaddingBottom = 5f;
                userHeaderImgCell.Border = 0;
                userInfoHeaderTable.AddCell(userHeaderImgCell);

                //Current user info table header Name+Roles table
                PdfPTable userHeaderNameRolesTable = new PdfPTable(1);

                //User name cell
                Phrase userNameLabel = new Phrase("Name:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE));
                Phrase nameName = new Phrase(user.UserName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE));
                Paragraph nameParagraph = new Paragraph();
                nameParagraph.Add(userNameLabel);
                nameParagraph.Add(nameName);

                PdfPCell nameCell = new PdfPCell(nameParagraph);
                nameCell.PaddingTop = 7f;
                nameCell.PaddingRight = 5f;
                nameCell.PaddingBottom = 12f;
                nameCell.Border = 0;
                userHeaderNameRolesTable.AddCell(nameCell);

                //Roles cell
                Phrase rolesLabel = new Phrase("Roles:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE));
                Phrase roles = new Phrase(user.UserRolesString, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.WHITE));
                Paragraph rolesParagraph = new Paragraph();
                rolesParagraph.Add(rolesLabel);
                rolesParagraph.Add(roles);

                PdfPCell rolesCell = new PdfPCell(rolesParagraph);
                rolesCell.Padding = 3f;
                rolesCell.PaddingTop = 0f;
                rolesCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                rolesCell.BorderColor = BaseColor.WHITE;
                userHeaderNameRolesTable.AddCell(rolesCell);

                //Add Name+Roles table to Name+Roles container cell 
                PdfPCell userHeaderNameRolesCell = new PdfPCell(userHeaderNameRolesTable);
                userHeaderNameRolesCell.Padding = 7f;
                userHeaderNameRolesCell.PaddingTop = 1f;
                userHeaderNameRolesCell.PaddingBottom = 18f;
                userInfoHeaderTable.AddCell(userHeaderNameRolesCell);

                //Add Header Image+Name+Roles container cell to info table
                PdfPCell userHeaderCell = new PdfPCell(userInfoHeaderTable);
                userHeaderCell.BackgroundColor = new BaseColor(Color.FromArgb(220, 77, 0));
                userHeaderCell.Border = 0;
                userHeaderCell.BorderWidthLeft = 0.1f;
                userHeaderCell.BorderWidthTop = 0.1f;
                userInfoTable.AddCell(userHeaderCell);

                //Current user info table body
                PdfPTable userInfoBodyTable = new PdfPTable(1);

                //ApplicationName info cell (user info table body)
                Phrase appNameLabel = new Phrase("AppName:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
                Phrase appName = new Phrase(user.AppName, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
                Paragraph appNameParagraph = new Paragraph();
                appNameParagraph.Add(appNameLabel);
                appNameParagraph.Add(appName);
                PdfPCell appNameCell = new PdfPCell(appNameParagraph);
                appNameCell.PaddingLeft = 5f;
                appNameCell.PaddingRight = 5f;
                appNameCell.PaddingBottom = 5f;
                appNameCell.Border = 0;
                userInfoBodyTable.AddCell(appNameCell);

                //LastActivityDate info cell (user info table body)
                Phrase ladLabel = new Phrase("LastActivityDate:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
                Phrase lad = new Phrase(user.LastActivityDate.ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
                Paragraph ladParagraph = new Paragraph();
                ladParagraph.Add(ladLabel);
                ladParagraph.Add(lad);
                PdfPCell ladCell = new PdfPCell(ladParagraph);
                ladCell.PaddingLeft = 5f;
                ladCell.PaddingRight = 5f;
                ladCell.PaddingBottom = 5f;
                ladCell.Border = 0;
                userInfoBodyTable.AddCell(ladCell);

                //CreationDate info cell (user info table body)
                Phrase creationDateLabel = new Phrase("CreationDate:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK));
                Phrase creationDate = new Phrase(user.CreationDate.ToString("d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK));
                Paragraph creationDateParagraph = new Paragraph();
                creationDateParagraph.Add(creationDateLabel);
                creationDateParagraph.Add(creationDate);
                PdfPCell creationDateCell = new PdfPCell(creationDateParagraph);
                creationDateCell.PaddingLeft = 5f;
                creationDateCell.PaddingRight = 5f;
                creationDateCell.PaddingBottom = 5f;
                creationDateCell.Border = 0;
                userInfoBodyTable.AddCell(creationDateCell);

                //Add user info table body to info table
                PdfPCell userBodyCells = new PdfPCell(userInfoBodyTable);
                userBodyCells.BackgroundColor = BaseColor.WHITE;
                userBodyCells.Border = 0;
                userBodyCells.BorderWidthLeft = 0.1f;
                userBodyCells.BorderWidthRight = 0.1f;
                userBodyCells.BorderWidthBottom = 0.1f;
                userInfoTable.AddCell(userBodyCells);

                

                //Add user info table to container cell
                wrapperCell = new PdfPCell(userInfoTable);
                wrapperCell.Padding = 10f;
                wrapperCell.Border = 0;
                wrapperCell.DisableBorderSide(1);
                wrapperCell.BackgroundColor = new BaseColor(Color.FromArgb(243, 243, 243));
                wrapperTable.AddCell(wrapperCell);
                counter++;
                if (counter == users.Count && users.Count / 2 != 0)
                {
                    PdfPCell emptyCell = new PdfPCell();
                    emptyCell.Border = 0;
                    emptyCell.BackgroundColor = new BaseColor(Color.FromArgb(243, 243, 243));
                    wrapperTable.AddCell(emptyCell);
                }
            }
            doc.Add(wrapperTable);
            doc.Close();
        }

        private static void UploadCloudinaryPDF(string pdfPathServer, HiddenField savePdfVersion ,string pdfName)
        {
            string cloudinaryAccount = ConfigurationManager.AppSettings["CLOUDINARY_URL"];
            string cloudinaryStoreURL = ConfigurationManager.AppSettings["AccountsStoreURL"];
            string cloudinaryAccountsFolder = ConfigurationManager.AppSettings["AccountsFolderName"];

            Cloudinary cloudinary = new Cloudinary(cloudinaryAccount);
            string profileImageVersion = null;

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(pdfPathServer),
                Folder = "PDFs",
                PublicId = pdfName,
                Invalidate = true
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            profileImageVersion = "v" + uploadResult.Version;
            savePdfVersion.Value = profileImageVersion;
        }

        private static void DeleteCloudinaryPDF(string pdfName)
        {
            string cloudinaryAccount = ConfigurationManager.AppSettings["CLOUDINARY_URL"];
            string cloudinaryStoreURL = ConfigurationManager.AppSettings["AccountsStoreURL"];
            string cloudinaryAccountsFolder = ConfigurationManager.AppSettings["AccountsFolderName"];

            Cloudinary cloudinaryDelete = new Cloudinary(cloudinaryAccount);

            var delParams = new DelResParams()
            {
                PublicIds = new List<string>() { pdfName },
                Invalidate = true
            };
            DelResResult result = cloudinaryDelete.DeleteResources(delParams);
        }
    }
}
