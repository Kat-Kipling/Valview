using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using ValoViewWebservice.App_Code.DAL;

namespace ValoViewWebservice.App_Code.BAL
{
    public class Tournament
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
        public string logoUrl { get; set; }

        public Tournament(string name)
        {
            List<string> tournamentInfo = DataAccess.getTournamentInfo(name);
            id = Convert.ToInt32(tournamentInfo[0]);
            this.name = tournamentInfo[1];
            startDate = tournamentInfo[2];
            endDate = tournamentInfo[3];
            description = tournamentInfo[4];
            logoUrl = tournamentInfo[5];
        }

        public static DataSet getAllTournaments()
        {
            return DataAccess.getAllTournaments();
        }

        public DataSet getMatches()
        {
            return DataAccess.getTournamentMatches(name);
        }

        public List<String> getInfo()
        {
            List<String> info = new List<String>(6);
            info.Add(id.ToString());
            info.Add(name);
            info.Add(startDate);
            info.Add(endDate);
            info.Add(description);
            info.Add(logoUrl);

            return info;
        }
    }


}