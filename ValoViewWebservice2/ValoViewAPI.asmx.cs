using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using ValoViewWebservice.App_Code.BAL;
using ValoViewWebservice.App_Code.DAL;
using ValoViewWebservice.Code.BAL;
using ValoViewWebservice2.Code.BAL;

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
        public string getTournamentId(string tournamentName)
        {

            Tournament tournament = new Tournament(tournamentName);
            return tournament.id.ToString();
        }

        [WebMethod]
        public int attemptSignIn(string username, string password)
        {
            return Profile.attemptLogin(username, password);
        }
        /// <summary>
        /// Takes the name of a user and gets all the details from the database for that user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Array of strings; each element is a single attribute of a Profile.</returns>
        [WebMethod]
        public List<string> getUserDetails(string username)
        {
            Profile userAccount = new Profile(username);
            return userAccount.getDetails();
        }

        [WebMethod]
        public DataSet getAllPlayers()
        {
            return Player.getAllPlayers();
        }

        [WebMethod]
        public List<string> getPlayerDetails(int id)
        {
            Player player = new Player(id);
            return player.getDetails();
        }

        [WebMethod]
        public int getPlayerIdByName(string name)
        {
            return DataAccess.GetPlayerIdByName(name);
        }

        [WebMethod]
        public DataSet getAllPlayerInfo()
        {
            return DataAccess.getAllPlayerInfo();
        }

        [WebMethod]
        public DataSet getRanks()
        {
            return DataAccess.getRanks();
        }
        [WebMethod]
        public DataSet getTeams()
        {
            return DataAccess.getTeams();
        }

        [WebMethod]
        public DataSet getDivisions()
        {
            return DataAccess.getDivisions();
        }

        [WebMethod]
        public DataSet getAgents()
        {
            return DataAccess.getAgents();
        }

        [WebMethod]
        public DataSet getRoles()
        {
            return DataAccess.getRoles();
        }

        [WebMethod]
        public void deletePlayer(int id)
        {
            DataAccess.deletePlayer(id);
        }

        [WebMethod]
        public void editPlayer(int id, string name, int team, string country, int rank, int division, int mainRole, int secRole, int mainAgent)
        {
            DataAccess.editPlayer(id, name, team, country, rank, division, mainRole, secRole, mainAgent);
        }

        [WebMethod]
        public void addNewPlayer(string name, int team, string country, int rank, int division, int mainRole, int secRole, int mainAgent)
        {
            DataAccess.addNewPlayer(name, team, country, rank, division, mainRole, secRole, mainAgent);
        }

        [WebMethod]
        public List<string> getTeamInfo(int id)
        {
            Team team = new Team(id);
            return team.getDetails();
        }

        [WebMethod]
        public DataSet getTeamData(int id)
        {
            return DataAccess.getTeamAsDataset(id);
        }

        [WebMethod]
        public DataSet getRegions()
        {
            return DataAccess.getRegions();
        }

        [WebMethod]
        public void removePlayerFromTeam(int id)
        {
            DataAccess.removePlayerFromTeam(id);
        }

        [WebMethod]
        public void addPlayerToTeam(int playerId, int teamId)
        {
            DataAccess.addPlayerToTeam(playerId, teamId);
        }

        [WebMethod]
        public void addTeam(string teamName, int regionId, string country)
        {
            DataAccess.addEmptyTeam(teamName, regionId, country);
        }

        [WebMethod]
        public int getTeamIdByName(string name)
        {
            return DataAccess.GetTeamIdByName(name);
        }

        [WebMethod]
        public void deleteTeam(int id)
        {
            DataAccess.deleteTeam(id);
        }
    }
}
