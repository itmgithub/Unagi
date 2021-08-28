using System;
using Microsoft.Office.Interop.Outlook;
using System.DirectoryServices.AccountManagement;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Unagi
{

    class ReportMail
    {
        string attachMailFile;
        MailItem mailItem;

        public ReportMail(MailItem mailItem)
        {
            this.mailItem = mailItem;
        }

        /*
         * Save the first email in the selection to an attachment.
         */
        //public string saveCurrentMail(Selection selection)
        private void saveCurrentMail()
        {
            //mailItem = selection[1] as MailItem;
            this.attachMailFile = Path.GetTempPath() + "Phish-" + Guid.NewGuid().ToString() + ".msg";
            mailItem.SaveAs(this.attachMailFile);
        }

        /*
         * Delete the previously saved attachment
         */
        private void deleteAttachmentFile()
        {
            try
            {
                File.Delete(attachMailFile);
            }
            catch (System.Exception ex)
            {

            }
        }

        /*
         * Delete the previously saved attachment
         */
        private void moveMailToTrash()
        {
            if (UnagiConfig.moveReportedToTrash)
            {
                try
                {
                    mailItem.Delete();
                }
                catch (System.Exception ex)
                {

                }
            } else
            {
                MessageBox.Show(Culture.getText("msgConfirmReport"), "Unagi");
            }
        }

        /*
         * Fill the mailMessage object with the correct values
         */
        private MailMessage setupNewMail(SmtpClient smtpServer)
        {
            MailMessage rptMail = new MailMessage();

            if ((String.IsNullOrEmpty(UnagiConfig.reportFrom)) && (UserPrincipal.Current.EmailAddress != string.Empty))
            {
                rptMail.From = new MailAddress(UserPrincipal.Current.EmailAddress);
            }
            else
            {
                rptMail.From = new MailAddress(UnagiConfig.reportFrom);
            }

            foreach (string toAddress in UnagiConfig.reportToSMTP)
            {
                rptMail.To.Add(toAddress);
            }
            rptMail.Subject = Culture.getText("rptSubject");
            rptMail.Body = Culture.getText("rptBody");

            return rptMail;
        }

        /*
         * Send the mail as attachment to the report mailbox (via SMTP)
         */
        private void sendViaSMTP()
        {
            SmtpClient smtpServer = new SmtpClient(UnagiConfig.smtpServer);

            if (!String.IsNullOrEmpty(UnagiConfig.smtpUsername))
            {
                smtpServer.UseDefaultCredentials = false;
                smtpServer.Credentials = new NetworkCredential(UnagiConfig.smtpUsername, UnagiConfig.smtpPassword);
            }

            MailMessage rptMail = setupNewMail(smtpServer);
            rptMail.Attachments.Add(new System.Net.Mail.Attachment(this.attachMailFile));
            try
            {
                smtpServer.Send(rptMail);
            } catch(System.Exception ex)
            {
                MessageBox.Show(Culture.getText("errFailSent"), "Unagi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            rptMail.Dispose();
            smtpServer.Dispose();
        }

        /*
         * Send the mail as attachment to the report mailbox (via MAPI)
         */
        private void sendViaMAPI()
        {
            Microsoft.Office.Interop.Outlook.Application mapi = new Microsoft.Office.Interop.Outlook.Application();
            MailItem rptMail = mapi.CreateItem(OlItemType.olMailItem);
            rptMail.Subject = Culture.getText("rptSubject");

            rptMail.To = UnagiConfig.reportToMAPI;

            rptMail.Body = Culture.getText("rptBody");

            rptMail.Attachments.Add(attachMailFile);
            rptMail.Importance = OlImportance.olImportanceHigh;

            rptMail.Send();
        }


        /*
        * The report phishing via mail workflow
        */
        public void reportViaMail()
        {
            saveCurrentMail();

            if (UnagiConfig.useSMTP) 
            {
                sendViaSMTP();
            }
            else {
                sendViaMAPI();
            }
            deleteAttachmentFile();
            moveMailToTrash();
        }

    }
}
