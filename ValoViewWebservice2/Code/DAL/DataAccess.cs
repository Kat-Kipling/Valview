using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Drawing;

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
            string sqlStr = "SELECT tblPlayers.[ID], tblPlayers.[Username], tblTeams.[Team Name] " +
                "FROM(tblPlayers " +
                "INNER JOIN tblTeams ON tblPlayers.Team = tblTeams.[Team ID])";

            OleDbDataAdapter daPlayers = new OleDbDataAdapter(sqlStr, conn);
            daPlayers.Fill(ds, "dtPlayers");
            conn.Close();

            return ds;
        }

        public static List<String> getPlayerInfo(int id)
        {
            DataSet ds = new DataSet();

            OleDbConnection conn = openConnection();
            string sqlStr = "SELECT p.ID, p.Username, t.[Team Name] AS Team, p.Country, r.[Rank Name] AS Rank, IIf(IsNull(d.Division), '', d.Division) AS Division, IIf(IsNull(mr.[Role Name]), '', mr.[Role Name]) AS MainRole, IIf(IsNull(sr.[Role Name]), '', sr.[Role Name]) AS SecondaryRole, a.[Agent Name] AS MainAgent, p.[Picture URL] " +
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

            List<string> playerInfo = new List<string>(9);
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
            }
            reader.Close();
            conn.Close();
            return playerInfo;
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
    }
}