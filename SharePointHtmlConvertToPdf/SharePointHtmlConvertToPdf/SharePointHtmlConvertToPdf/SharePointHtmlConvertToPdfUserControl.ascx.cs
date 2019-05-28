using Microsoft.SharePoint;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SharePointHtmlConvertToPdf.SharePointHtmlConvertToPdf
{
    public partial class SharePointHtmlConvertToPdfUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                string htmlStart = "<html><head><meta http-equiv='content-type' content='text/html; charset=UTF-8'></head><body>";
                string htmlContent = tbPdfContent.Text;
                string htmlFinish = "</body></html>";

                string htmlPath = @"C:\pdf\";
                string htmlName = (string.IsNullOrEmpty(tbFileName.Text) ? "yunusemrearac" : tbFileName.Text) + ".pdf";

                string htmlSavePath = htmlPath + htmlName;
                string html = htmlStart + htmlContent + htmlFinish;

                NReco.PdfGenerator.HtmlToPdfConverter htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.GeneratePdf(html, "", htmlSavePath);
            });
        }
    }
}
