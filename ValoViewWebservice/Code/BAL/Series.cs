using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValoViewWebservice.App_Code.BAL
{
    public class Series
    {
        public int id { get; set; }
        public int seriesTypeId {  get; set; }
        public int tournamentId { get; set; }
        public int winningTeamId {  get; set; }

    }
}