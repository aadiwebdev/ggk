using System;
using System.Security;
using System.Net;
namespace Domain
{
    public static class Extensions
    {
        public static String ToPlainString(this SecureString secureStr)
        {
            String plainStr = new NetworkCredential(string.Empty, secureStr).Password;
            return plainStr;
        }

        // convert a plain text string into a secure string
        public static SecureString ToSecureString(this String plainStr)
        {
            var secStr = new SecureString();
            secStr.Clear();
            foreach (char c in plainStr.ToCharArray())
            {
                secStr.AppendChar(c);
            }
            return secStr;
        }
    }
}
