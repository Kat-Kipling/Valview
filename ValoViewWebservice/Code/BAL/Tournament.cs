using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValoViewWebservice.App_Code.DAL;

namespace ValoViewWebservice.App_Code.BAL
{
    public class Tournament
    {
        public int id {  get; set; }
        public string name { get; set; }

        public Tournament(string name)
        {
            this.name = name;
        }

        public static DataSet getAllTournaments()
        {
            return DataAccess.getAllTournaments();
        }

        public DataSet getMatches()
        {
            return DataAccess.getTournamentMatches(name);
        }
    }


}