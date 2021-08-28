using System;
using System.Reflection;
using System.Resources;

namespace Unagi
{
    /*
     * A static class that contains all the language/culture messages
     * If it as a file Lang_xx_XX for ISO culture code xx_XX (example en_US, en_GB, nl_NL, etc) it tried to read that file. 
     */
    static public class Culture
    {
        private static ResourceManager res_man;

        static Culture()
        {
            res_man = new ResourceManager("Unagi.Lang_" + UnagiConfig.isoLanguageName, Assembly.GetExecutingAssembly());
        }

        public static string getText(string token)
        {
            if (!String.IsNullOrEmpty(res_man.GetString(token)))
            {
                String msgString = res_man.GetString(token);
                msgString = msgString.Replace("[D]",Environment.UserDomainName.ToUpper());  // Replace [D] with the domain name of this PC
                msgString = msgString.Replace("[U]", Environment.UserName);                 // Replace [U] with the username logged-on on this PC

                return msgString;
            } else
            {
                switch (token) // Default value fall-backs.
                {
                    case "author":
                        return "Mark Feenstra";
                    case "btnReportNoDel":
                        return "Report";
                    case "btnReportDel":
                        return "Report and Delete";
                    case "rptBtnGroup":
                        return "Report phishing";
                    case "rptSubject":
                        return "Phishing report";
                    case "rptBody":
                        return "User \""+Environment.UserDomainName.ToUpper() + "\\" + Environment.UserName+"\" has made a report of possible phishing.\nThis email requires investigation."; // Add {0} for username
                    case "msgConfirmReport":
                        return "Message has been reported";
                    case "errNoSelection":
                        return "You need to select an eMail before pressing the report button.";
                    case "errOnlyOne":
                        return "You can only report one eMail at a time. Select and press the button once for each eMail";
                    case "errFailSent":
                        return "Unable to send report. Please call the servicedesk for assistance.";
                    case "errNoAppConfig":
                        return "Unable to read App.config or one of it sections; using defaults";
                    default:
                        return "Unknown";
                }
            }
        }
    }
}
