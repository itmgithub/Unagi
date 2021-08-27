using System;
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Unagi
{
    // A static class that contrains all the values with defaults in one place. This makes it easier to use the values without having to recheck them all over the codes.

    static public class UnagiConfig
    {
        public static Boolean useSMTP { get; set; } = false;
        public static Boolean moveReportedToTrash { get; set; } = true;
        public static string reportFrom { get; set; } = "noreply@localhost";
        public static string[] reportToSMTP { get; set; } = { "noreply@localhost" };
        public static string reportToMAPI { get; set; } = "noreply@localhost";
        public static string smtpServer { get; set; } = "localhost";
        public static string isoLanguageName { get; set; } = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        public static string smtpUsername { get; set; } = "";
        public static string smtpPassword { get; set; } = "";

        static UnagiConfig()
        {
            NameValueCollection unagiSettings;
            NameValueCollection smtpSettings;

            unagiSettings = (NameValueCollection)ConfigurationManager.GetSection("unagiSettings");
            if (unagiSettings==null)  // If the section isn't found in App.config; use defaults but warn the user about this.
            {
                MessageBox.Show(Culture.getText("errNoAppConfig"), "Unagi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                useSMTP = Boolean.Parse(unagiSettings["useSMTP"] ?? "false");
                moveReportedToTrash = Boolean.Parse(unagiSettings["moveReportedToTrash"] ?? "true");
                reportToMAPI = unagiSettings["reportTo"] ?? "noreply@localhost"; 
                reportToSMTP = reportToMAPI.Split(';').Select(str => str.Trim()).ToArray(); // Yes, I know I can split the string later, but here it is a tiny bit more obvious and penalty is minimal.
                isoLanguageName = unagiSettings["isoLanguageName"] ?? System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            }

            if (useSMTP) // Also get SMTP section if smtp was enabled in unagiSettings.
            { 
                smtpSettings = (NameValueCollection)ConfigurationManager.GetSection("smtpSettings");
                if (smtpSettings == null) // If the section isn't found in App.config; use defaults but warn the user about this.
                {
                    MessageBox.Show(Culture.getText("errNoAppConfig"), "Unagi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    reportFrom = smtpSettings["reportFrom"] ?? "noreply@localhost";
                    smtpServer = smtpSettings["smtpServer"] ?? "localhost";
                    smtpUsername = smtpSettings["username"] ?? "";
                    smtpPassword = smtpSettings["password"] ?? "";
                }
            }

        }
    }
}
