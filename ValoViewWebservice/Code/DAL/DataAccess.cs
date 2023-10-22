using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

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
                "LEFT JOIN tblTeams AS T3 ON S.[Winning Team ID] = T3.[Team ID];";

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
    }
}