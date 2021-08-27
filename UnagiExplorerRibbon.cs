using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace Unagi
{
    public partial class UnagiExplorerRibbon
    {
        private void UnagiExplorerRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            if (UnagiConfig.moveReportedToTrash)
            {
                btnReportPhish.Label = Culture.getText("btnReportDel");
            } else {
                btnReportPhish.Label = Culture.getText("btnReportNoDel");
            }
            unagiGroup.Label = Culture.getText("rptBtnGroup");
        }

        /*
         * Check if only one email is selected and if so fire off the report via email action 
         */
        private void btnReportPhish_Click(object sender, RibbonControlEventArgs e)
        {
            Selection selection = Globals.ThisAddIn.Application.ActiveExplorer().Selection;

            if (selection.Count < 1) // no item is selected
            {
                MessageBox.Show(Culture.getText("errNoSelection"), "Unagi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selection.Count > 1) // many items selected
            {
                MessageBox.Show(Culture.getText("errOnlyOne"), "Unagi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ReportMail reportAction = new ReportMail(selection[1]);
                reportAction.reportViaMail();
            }
        }
    }
}
