using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;

namespace Unagi
{
    public partial class UnagiReadMailRibbon
    {
        private void UnagiReadMailRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            if (UnagiConfig.moveReportedToTrash)
            {
                btnReportPhish.Label = Culture.getText("btnReportDel");
            }
            else
            {
                btnReportPhish.Label = Culture.getText("btnReportNoDel");
            }
            unagiGroup.Label = Culture.getText("rptBtnGroup");
        }

        /*
         * Fire off the report via email action 
         */
        private void btnReportPhish_Click(object sender, RibbonControlEventArgs e)
        {
            Application application = new Application();
            Inspector inspector = application.ActiveInspector();
            ReportMail reportAction = new ReportMail(inspector.CurrentItem);
            reportAction.reportViaMail();
        }
    }
}
