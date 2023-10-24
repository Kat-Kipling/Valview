using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValoViewWebservice.App_Code.DAL;

namespace ValoViewWebservice.Code.BAL
{
    public class Profile
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string pronouns { get; set; }
        public string pfpUrl { get; set; }

        public Profile(string username)
        {
            List<String> details = DataAccess.getUserDetailsByName(username);
            id = Convert.ToInt32(details[0]);
            this.username = username;
            this.password = details[2];
            firstName = details[3];
            lastName = details[4];
            pronouns = details[5];
            pfpUrl = details[6];
        }

        public static int attemptLogin(string username, string password)
        {
            return DataAccess.validateLogin(username, password);
        }

        public List<string> getDetails()
        {
            List<String> details = new List<string>(7);
            details.Add(id.ToString());
            details.Add(username);
            details.Add(password);
            details.Add(firstName);
            details.Add(lastName);
            details.Add(pronouns);
            details.Add(pfpUrl);
            return details;
        }
    }
}