using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using ValoViewWebservice.App_Code.BAL;
using ValoViewWebservice.Code.BAL;

namespace ValoViewWebservice


{
    /// <summary>
    /// Summary description for ValoViewAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ValoViewAPI : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet getTournamentSeriesByName(string tournamentName)
        {
            Tournament tournament = new Tournament(tournamentName);
            return tournament.getMatches();
        }

        [WebMethod]
        public DataSet getAllTournaments()
        {
            return Tournament.getAllTournaments();
        }

        [WebMethod]
        public int attemptSignIn(string username, string password)
        {
            return Profile.attemptLogin(username, password);
        }

        [WebMethod]
        public List<string> getUserDetails(string username)
        {
            Profile userAccount = new Profile(username);
            return userAccount.getDetails();
        }
    }
}
