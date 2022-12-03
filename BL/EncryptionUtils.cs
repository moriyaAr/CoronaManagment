using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CoronaManagment.BL
{
    public class EncryptionUtils
    {
        public static string Encrypt(string id) 
        {
            string encryptionNumber = WebConfigurationManager.AppSettings["EncryptionNumber"];
            long number = int.Parse(encryptionNumber) * int.Parse(id);
            return HttpContext.Current.Session.SessionID + number.ToString();
        }

        public static string Decrypt(string id)
        {
            id = id.Substring(HttpContext.Current.Session.SessionID.Length);
            string encryptionNumber = WebConfigurationManager.AppSettings["EncryptionNumber"];
            long number = long.Parse(id) / int.Parse(encryptionNumber);
            return number.ToString();
        }
    }
}