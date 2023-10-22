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

        public static int attemptLogin(string username, string password)
        {
            return DataAccess.validateLogin(username, password);
        }
    }
}