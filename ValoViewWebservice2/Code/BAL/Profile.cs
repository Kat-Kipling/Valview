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
            username = details[1];
            password = details[2];
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
            List<String> details = new List<string>();
            var properties = this.GetType().GetProperties();
            foreach ( var property in properties ) 
            {
                if (property.GetValue(this, null) is string)
                {
                    details.Add((string)property.GetValue(this, null));
                }
            }

            return details;
        }
    }
}