using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ValoViewWebservice.App_Code.DAL;

namespace ValoViewWebservice2.Code.BAL
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegionID { get; set; }
        public string Country { get; set; }
        public string TeamLogoUrl { get; set; }
        public List<string> Members = new List<string>(4);

        public Team(int id)
        {
            List<string> members = DataAccess.getTeamMembers(id);
            List<string> teamDetails = DataAccess.getTeamInfo(id);

            Id = Convert.ToInt32(teamDetails[0]);
            Name = teamDetails[1];
            RegionID = teamDetails[2];
            Country = teamDetails[3];
            TeamLogoUrl = teamDetails[4];

            foreach(var member in members)
            {
                Members.Add(member);
            }
        }

        public List<String> getDetails()
        {
            List<String> info = new List<string>(10);
            info.Add(Id.ToString());
            info.Add(Name);
            info.Add(RegionID); 
            info.Add(Country);
            info.Add(TeamLogoUrl);

            foreach (string member in Members)
            {
                info.Add(member.ToString());
            }
            return info;
        }
    }
}