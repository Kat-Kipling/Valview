using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using ValoViewWebservice.App_Code.BAL;
using ValoViewWebservice2.Code.BAL;
using System.Xml.Linq;

namespace ValoViewWebservice.App_Code.DAL
{
    public class DataAccess
    {
        public static OleDbConnection openConnection()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;data source=" +
                    System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/ValorantMatches.accdb"));
                conn.Open();
                return conn;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static DataSet getTeams()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlCmd = "SELECT tblTeams.[Team ID], tblTeams.[Team Name], tblTeams.Country, tblRegions.[Region Name], tblTeams.[Picture URL] " +
                "FROM tblTeams " +
                "INNER JOIN tblRegions ON tblTeams.[Region ID] = tblRegions.[Region ID];";

            OleDbDataAdapter daTeamNames = new OleDbDataAdapter(sqlCmd, conn);
            daTeamNames.Fill(ds, "dtTeams");
            conn.Close();

            return ds;
        }

        public static DataSet getTeamAsDataset(int id)
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT p.ID, p.Username, t.[Team Name] AS Team, p.Country, r.[Rank Name] AS Rank, IIf(IsNull(d.Division), '', d.Division) AS Division, mr.[Role Name] AS MainRole, IIf(IsNull(sr.[Role Name]), '', sr.[Role Name]) AS SecondaryRole, a.[Agent Name] AS MainAgent " +
                "FROM(((((tblPlayers AS p " +
                "INNER JOIN tblTeams AS t ON p.Team = t.[Team ID]) " +
                "INNER JOIN tblRanks AS r ON p.Rank = r.ID) " +
                "LEFT JOIN tblDivisions AS d ON p.Division = d.ID) " +
                "LEFT JOIN tblAgentRoles AS mr ON p.[Main Role] = mr.ID) " +
                "LEFT JOIN tblAgentRoles AS sr ON p.[Secondary Role] = sr.ID) " +
                "INNER JOIN tblAgents AS a ON p.[Main Agent] = a.ID " +
                "WHERE t.[Team ID] = " + id + ";";

            OleDbDataAdapter daTeamNames = new OleDbDataAdapter(sqlStr, conn);
            daTeamNames.Fill(ds, "dtTeams");
            conn.Close();

            return ds;
        }

        public static DataSet getRanks()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlCmd = "SELECT * FROM tblRanks;";

            OleDbDataAdapter daRanks = new OleDbDataAdapter(sqlCmd, conn);
            daRanks.Fill(ds, "dtRanks");
            conn.Close();

            return ds;
        }

        public static DataSet getRoles()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlCmd = "SELECT * FROM tblAgentRoles;";

            OleDbDataAdapter daRoles = new OleDbDataAdapter(sqlCmd, conn);
            daRoles.Fill(ds, "dtRoles");
            conn.Close();

            return ds;
        }

        public static DataSet getAgents()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlCmd = "SELECT * FROM tblAgents;";

            OleDbDataAdapter daAgents = new OleDbDataAdapter(sqlCmd, conn);
            daAgents.Fill(ds, "dtAgents");
            conn.Close();

            return ds;
        }

        public static DataSet getDivisions()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlCmd = "SELECT * FROM tblDivisions;";

            OleDbDataAdapter daDivisions = new OleDbDataAdapter(sqlCmd, conn);
            daDivisions.Fill(ds, "dtDivisions");
            conn.Close();

            return ds;
        }

        public static DataSet getTournamentMatches(string tournamentName)
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlCmd = "SELECT S.[Series ID] AS[Series ID], ST.[Series Type], TOURN.[Tournament Name], T1.[Team Name] AS[Team One], T2.[Team Name] AS[Team Two], T3.[Team Name] AS[Winning Team] " +
                "FROM((((tblSeries AS S " +
                "INNER JOIN tblSeriesTypes AS ST ON S.[Series Type ID] = ST.[Series Type ID]) " +
                "INNER JOIN tblTournaments AS TOURN ON S.[Tournament ID] = TOURN.[Tournament ID]) " +
                "LEFT JOIN tblTeams AS T1 ON S.[Team One ID] = T1.[Team ID]) " +
                "LEFT JOIN tblTeams AS T2 ON S.[Team Two ID] = T2.[Team ID]) " +
                "LEFT JOIN tblTeams AS T3 ON S.[Winning Team ID] = T3.[Team ID] " +
                "WHERE TOURN.[Tournament Name] = '" + tournamentName + "';";

            OleDbDataAdapter daTournamentMatches = new OleDbDataAdapter(sqlCmd, conn);
            daTournamentMatches.Fill(ds, "dtTournamentMatches");
            conn.Close();

            return ds;
        }

        public static DataSet getAllTournaments()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT * FROM tblTournaments";

            OleDbDataAdapter daTournaments = new OleDbDataAdapter(sqlStr, conn);
            daTournaments.Fill(ds, "dtTournaments");
            conn.Close();

            return ds;
        }

        public static int validateLogin(string username, string pwd)
        {
            int userID = -1;

            try
            {
                OleDbConnection con = openConnection();
                string strSQL = "SELECT tblUsers.ID FROM tblUsers WHERE " +
                    "(((tblUsers.Username) ='" + username + "') AND ((tblUsers.Pass) ='" + pwd + "'))";

                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                OleDbDataReader reader = cmd.ExecuteReader();

                reader.Read();
                userID = Convert.ToInt32(reader["ID"]);
                con.Close();
                reader.Close();
            }
            catch (Exception ex)
            {


            }
            return userID;
        }

        public static List<String> getUserDetailsByName(string usernameToFind)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT * " +
                "FROM tblUsers " +
                "WHERE tblUsers.[Username] = '" + usernameToFind + "';";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            List<String> userDetails = new List<String>(7);
            while (reader.Read())
            {
                userDetails.Add(reader.GetValue(0).ToString());
                userDetails.Add(reader.GetString(1));
                userDetails.Add(reader.GetString(2));
                userDetails.Add(reader.GetString(3));
                userDetails.Add(reader.GetString(4));
                userDetails.Add(reader.GetString(5));
                userDetails.Add(reader.GetString(6));
            }
            reader.Close();
            conn.Close();
            return userDetails;
        }

        public static DataSet getAllPlayers()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT tblPlayers.[ID], tblPlayers.[Username], tblTeams.[Team Name], tblPlayers.[Picture URL] " +
                "FROM(tblPlayers " +
                "INNER JOIN tblTeams ON tblPlayers.Team = tblTeams.[Team ID])";

            OleDbDataAdapter daPlayers = new OleDbDataAdapter(sqlStr, conn);
            daPlayers.Fill(ds, "dtPlayers");
            conn.Close();

            return ds;
        }

        public static List<String> getPlayerInfo(int id)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT p.ID, p.Username, t.[Team Name] AS Team, p.Country, r.[Rank Name] AS Rank, IIf(IsNull(d.Division), '', d.Division) AS Division, mr.[Role Name] AS MainRole, IIf(IsNull(sr.[Role Name]), '', sr.[Role Name]) AS SecondaryRole, a.[Agent Name] AS MainAgent, p.[Picture URL] " +
                "FROM(((((tblPlayers AS p " +
                "INNER JOIN tblTeams AS t ON p.Team = t.[Team ID]) " +
                "INNER JOIN tblRanks AS r ON p.Rank = r.ID) " +
                "LEFT JOIN tblDivisions AS d ON p.Division = d.ID) " +
                "LEFT JOIN tblAgentRoles AS mr ON p.[Main Role] = mr.ID) " +
                "LEFT JOIN tblAgentRoles AS sr ON p.[Secondary Role] = sr.ID) " +
                "INNER JOIN tblAgents AS a ON p.[Main Agent] = a.ID " +
                "WHERE p.ID = " + id + ";";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            List<string> playerInfo = new List<string>(10);
            while (reader.Read())
            {
                playerInfo.Add(reader.GetValue(0).ToString());
                playerInfo.Add(reader.GetString(1));
                playerInfo.Add(reader.GetString(2));
                playerInfo.Add(reader.GetString(3));
                playerInfo.Add(reader.GetString(4));
                playerInfo.Add(reader.GetString(5));
                playerInfo.Add(reader.GetString(6));
                playerInfo.Add(reader.GetString(7));
                playerInfo.Add(reader.GetString(8));
                playerInfo.Add(reader.GetString(9));
            }
            reader.Close();
            conn.Close();
            return playerInfo;
        }
        public static List<String> getTeamInfo(int id)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT tblTeams.[Team ID], tblTeams.[Team Name], tblTeams.Country, tblRegions.[Region Name], tblTeams.[Picture URL] " +
                "FROM tblTeams " +
                "INNER JOIN tblRegions ON tblTeams.[Region ID] = tblRegions.[Region ID]" +
                "WHERE tblTeams.[Team ID] = " + id + ";";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            List<string> teamInfo = new List<string>(5);
            while (reader.Read())
            {
                teamInfo.Add(reader.GetValue(0).ToString());
                teamInfo.Add(reader.GetString(1));
                teamInfo.Add(reader.GetString(2));
                teamInfo.Add(reader.GetString(3));
                teamInfo.Add(reader.GetString(4));
            }
            reader.Close();
            conn.Close();
            return teamInfo;
        }

        public static List<String> getTeamMembers(int id)
        {
            OleDbConnection conn = openConnection();

            string sqlStr = "SELECT tblPlayers.[Username] " +
                "FROM tblPlayers " +
                "WHERE tblPlayers.[Team] = " + id + ";";
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            List<string> teamMembers = new List<string>(5);
            int totalTeamMems = 0;
            while (reader.Read())
            {
                teamMembers.Add(reader.GetString(0));
                totalTeamMems++;
            }

            while(totalTeamMems < 5)
            {
                teamMembers.Add("---EMPTY---");
                totalTeamMems++;
            }

            return teamMembers;
        }
            public static DataSet getAllPlayerInfo()
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT p.ID, p.Username,  IIf(IsNull(t.[Team Name]), '', t.[Team Name]) AS Team, p.Country, r.[Rank Name] AS Rank, IIf(IsNull(d.Division), '', d.Division) AS Division, IIf(IsNull(mr.[Role Name]), '', mr.[Role Name]) AS MainRole, IIf(IsNull(sr.[Role Name]), '', sr.[Role Name]) AS SecondaryRole, a.[Agent Name] AS MainAgent, p.[Picture URL] " +
                "FROM(((((tblPlayers AS p " +
                "LEFT JOIN tblTeams AS t ON p.Team = t.[Team ID]) " +
                "INNER JOIN tblRanks AS r ON p.Rank = r.ID) " +
                "LEFT JOIN tblDivisions AS d ON p.Division = d.ID) " +
                "LEFT JOIN tblAgentRoles AS mr ON p.[Main Role] = mr.ID) " +
                "LEFT JOIN tblAgentRoles AS sr ON p.[Secondary Role] = sr.ID) " +
                "INNER JOIN tblAgents AS a ON p.[Main Agent] = a.ID;";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataAdapter daPlayers = new OleDbDataAdapter(sqlStr, conn);
            daPlayers.Fill(ds, "dtPlayers");
            conn.Close();

            return ds;
        }

        public static List<string> getTournamentInfo(string tournamentName)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT * " +
                "FROM tblTournaments " +
                "WHERE tblTournaments.[Tournament Name] = '" + tournamentName + "';";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            List<String> tournamentInfo = new List<String>(6);
            while (reader.Read())
            {
                tournamentInfo.Add(reader.GetValue(0).ToString());
                tournamentInfo.Add(reader.GetString(1));
                tournamentInfo.Add(reader.GetValue(2).ToString());
                tournamentInfo.Add(reader.GetValue(3).ToString());
                tournamentInfo.Add(reader.GetString(4));
                tournamentInfo.Add(reader.GetString(5));
            }
            reader.Close();
            conn.Close();
            return tournamentInfo;
        }

        public static void deletePlayer(int id)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "DELETE * " +
                "FROM tblPlayers " +
                "WHERE tblPlayers.[ID] = " + id + ";";


            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }

        public static void deleteTeam(int id)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "DELETE * " +
                "FROM tblTeam " +
                "WHERE tblTeam.[Team ID] = " + id + ";";


            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }


        public static void removePlayerFromTeam(int id)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "UPDATE tblPlayers " +
                "SET Team = 19 " +
                "WHERE tblPlayers.[ID] = " + id + ";";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Close();
            conn.Close();
        }

        public static int GetPlayerIdByName(string name)
        {
            if (!name.Equals("---EMPTY---"))
            {
                OleDbConnection conn = openConnection();
                string sqlStr = "SELECT tblPlayers.[ID] " +
                    "FROM tblPlayers " +
                    "WHERE tblPlayers.[Username] = '" + name + "';";

                OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
                int id = (int)cmd.ExecuteScalar();
                conn.Close();
                return id;
            }
            else
            {
                return -1;
            }
        }

        public static int GetTeamIdByName(string name)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT tblTeams.[Team ID] " +
                "FROM tblTeams " +
                "WHERE tblTeams.[Team Name] = '" + name + "';";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            int id = (int)cmd.ExecuteScalar();
            conn.Close();
            return id;
        }

        public static void addEmptyTeam(string teamName, int regionId, string country, string teamLogo)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "INSERT INTO tblTeams ([Team Name], [Region ID], Country, [Picture URL]) " +
                                    "VALUES ('" + teamName + "', " +
                                    "" + regionId + ", " +
                                    "'" + country + ", " +
                                    "'" + teamLogo + "');";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }

        public static void addPlayerToTeam(int playerId, int teamId)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "UPDATE tblPlayers " +
                "SET Team = ' " + teamId + "' " +
                "WHERE tblPlayers.[ID] = " + playerId + ";";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }

        public static void editPlayer(int id, string name, int team, string country, int rank, int division, int mainRole, int secRole, int mainAgent, string imageUrl)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "";
            if (division == -1 && secRole != -1) // Has a secondary role, doesn't have a division
            {
                sqlStr = "UPDATE tblPlayers " +
                "SET Username = '" + name + "', " +
                "Team = " + team + ", " +
                "Country = '" + country + "', " +
                "Rank = " + rank + ", " +
                "Division = NULL, " +
                "[Main Role] = " + mainRole + ", " +
                "[Secondary Role] = " + secRole + ", " +
                "[Main Agent] = " + mainAgent + ", " +
                "[Picture URL] = '" + imageUrl + "' " +
                "WHERE tblPlayers.[ID] = " + id + ";";
            }
            else if (division != -1 && secRole == -1) // Has a division, doesn't have a secondary role
            {
                sqlStr = "UPDATE tblPlayers " +
                "SET Username = '" + name + "', " +
                "Team = " + team + ", " +
                "Country = '" + country + "', " +
                "Rank = " + rank + ", " +
                "Division = " + division + ", " +
                "[Main Role] = " + mainRole + ", " +
                "[Secondary Role] = NULL, " +
                "[Main Agent] = " + mainAgent + ", " +
                "[Picture URL] = '" + imageUrl + "' " +
                "WHERE tblPlayers.[ID] = " + id + ";";
            }
            else if (division == -1 && secRole == -1) // Has neither a division, or a secondary role
            {
                sqlStr = "UPDATE tblPlayers " +
                "SET Username = '" + name + "', " +
                "Team = " + team + ", " +
                "Country = '" + country + "', " +
                "Rank = " + rank + ", " +
                "Division = NULL, " +
                "[Main Role] = " + mainRole + ", " +
                "[Secondary Role] = NULL, " +
                "[Main Agent] = " + mainAgent + ", " +
                "[Picture URL] = '" + imageUrl + "' " +
                "WHERE tblPlayers.[ID] = " + id + ";";
            }
            else // Has both a division, and a secondary role
            {
                sqlStr = "UPDATE tblPlayers " +
                "SET Username = '" + name + "', " +
                "Team = " + team + ", " +
                "Country = '" + country + "', " +
                "Rank = " + rank + ", " +
                "Division = " + division + ", " +
                "[Main Role] = " + mainRole + ", " +
                "[Secondary Role] = " + secRole + ", " +
                "[Main Agent] = " + mainAgent + ", " +
                "[Picture URL] = '" + imageUrl + "' " +
                "WHERE tblPlayers.[ID] = " + id + ";";
            }

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }
        public static DataSet getRegions()
        {
            DataSet regions = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlCmd = "SELECT * FROM tblRegions;";

            OleDbDataAdapter daRegions = new OleDbDataAdapter(sqlCmd, conn);
            daRegions.Fill(regions, "dtRegions");
            conn.Close();

            return regions;
        }

        public static void addNewPlayer(string name, int team, string country, int rank, int division, int mainRole, int secRole, int mainAgent, string imageUrl)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "";


            if (division == -1 && secRole != -1) // Has a secondary role, doesn't have a division
            {
                sqlStr = "INSERT INTO tblPlayers (Username, Team, Country, Rank, Division, [Main Role], [Secondary Role], [Main Agent]) " +
                                    "VALUES ('" + name + "', " +
                                    team + ", " +
                                    "'" + country + "', " +
                                    rank + ", " +
                                    "NULL, " +
                                    mainRole + ", " +
                                    secRole + ", " +
                                    mainAgent + ", " +
                                    "'" + imageUrl + "');";
            }
            else if(division != -1 && secRole == -1) // Has a division, doesn't have a secondary role
            {
                sqlStr = "INSERT INTO tblPlayers (Username, Team, Country, Rank, Division, [Main Role], [Secondary Role], [Main Agent], [Picture URL]) " +
                                    "VALUES ('" + name + "', " +
                                    team + ", " +
                                    "'" + country + "', " +
                                    rank + ", " +
                                    division + ", " +
                                    mainRole + ", " +
                                    "NULL, " +
                                    mainAgent + ", " +
                                    "'" + imageUrl + "');";
            }
            else if(division == -1 && secRole == -1) // Has neither a division, or a secondary role
            {
                sqlStr = "INSERT INTO tblPlayers (Username, Team, Country, Rank, Division, [Main Role], [Secondary Role], [Main Agent], [Picture URL]) " +
                                    "VALUES ('" + name + "', " +
                                    team + ", " +
                                    "'" + country + "', " +
                                    rank + ", " +
                                    "NULL, " +
                                    mainRole + ", " +
                                    "NULL, " +
                                    mainAgent + ", " +
                                    "'" + imageUrl + "');";
            }
            else // Has both a division, and a secondary role
            {
                sqlStr = "INSERT INTO tblPlayers (Username, Team, Country, Rank, Division, [Main Role], [Secondary Role], [Main Agent], [Picture URL]) " +
                                    "VALUES ('" + name + "', " +
                                    team + ", " +
                                    "'" + country + "', " +
                                    rank + ", " +
                                    division + ", " +
                                    mainRole + ", " +
                                    secRole + ", " +
                                    mainAgent + ", " +
                                    "'" + imageUrl + "');";
            }

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }

        public static void updateTeamDetails(int teamId, string teamName, int regionId, string country, string teamLogoUrl)
        {
            OleDbConnection conn = openConnection();
            string sqlStr = "UPDATE tblTeams " +
                "SET [Team Name] = '" + teamName + "', " +
                "[Region ID] = " + regionId + ", " +
                "Country = '" + country + "', " +
                "[Picture URL] = '" + teamLogoUrl + "' " +
                "WHERE [Team ID] = " + teamId + ";";

            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
        }
    }
}