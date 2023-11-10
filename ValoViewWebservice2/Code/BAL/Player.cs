using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using ValoViewWebservice.App_Code.DAL;

namespace ValoViewWebservice.App_Code.BAL
{
    public class Player
    {
        public int id {  get; set; }
        public string userName { get; set; }
        public string team {  get; set; }
        public string country {  get; set; }
        public string rank { get; set; }
        public string division { get; set; }
        public string mainRole { get; set; }
        public string secondaryRole { get; set; }
        public string mainAgent { get; set; }

        public Player(int id)
        {
            List<String> details = DataAccess.getPlayerInfo(id);
            this.id = Convert.ToInt32(details[0]);
            this.userName = details[1];
            this.team = details[2];
            this.country = details[3];
            this.rank = details[4];
            this.division = details[5];
            this.mainRole = details[6];
            this.secondaryRole = details[7];
            this.mainAgent = details[8];
        }

        public static DataSet getAllPlayers()
        {
            return DataAccess.getAllPlayers();
        }

        public List<string> getDetails()
        {
            List<String> details = new List<string>(9);
            details.Add(id.ToString());
            details.Add(userName);
            details.Add(team);
            details.Add(country);
            details.Add(rank);
            details.Add(division);
            details.Add(mainRole);
            details.Add(secondaryRole);
            details.Add(mainAgent);
            return details;
        }
    }
}